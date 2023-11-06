using EnocaTestProject.AspNetCore;
using EnocaTestProject.Infrastucture.Filters;
using EnocaTestProject.Persistence;
using EnocaTestProject.Persistence.Context;
using EnocaTestProject.Persistence.Jobs;
using EnocaTextProject.Application;
using EnocaTextProject.Application.Mappers;
using FluentValidation.AspNetCore;
using Hangfire;
using Hangfire.Common;
using Hangfire.MemoryStorage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Add services to the container.
builder.Services.AddContainerWithDependenciesPersistence();
builder.Services.AddContainerWithDependenciesApplication();
builder.Services.AddAutoMapper(typeof(CarrierProfile));//automapper eklendi

#region hangfire
builder.Services.AddHangfire(x =>
{
    x.UseMemoryStorage();
    
    RecurringJob.AddOrUpdate<DailyCarrierCost>(j => j.AddDailyCost(), "0 * * * *", TimeZoneInfo.Local);

});
builder.Services.AddHangfireServer();
#endregion

#region Controller - Fluent Validation - Json
// IServiceCollection arabirimine Controllers hizmetini ekler. Bu, Web API projesinde denetleyicilerin (Controller'larýn) kullanýlmasýný saðlar.
builder.Services.AddControllers(opt =>
{
    //opt.Filters.Add(typeof(UserActivity_));
    opt.Filters.Add<ValidationFilter>();
})
    // FluentValidation kütüphanesinin yapýlandýrmasýný ekler. 
    .AddFluentValidation(configuration =>
    {
        // Veri anotasyonlarý tabanlý doðrulama özelliðini devre dýþý býrakýr. Bu, veri modellerinin üzerindeki DataAnnotations doðrulama özelliklerini kullanmadan sadece FluentValidation kurallarýný kullanmayý saðlar.
        configuration.DisableDataAnnotationsValidation = true;

        // YoneticiValidator sýnýfýnýn bulunduðu derlemedeki doðrulayýcýlarý FluentValidation yapýlandýrmasýna kaydeder. Bu þekilde, belirtilen derlemedeki tüm doðrulayýcýlar otomatik olarak kullanýlabilir hale gelir.
        //configuration.RegisterValidatorsFromAssemblyContaining<YoneticiValidator>(); -->validatorleri yazdýktan sonra eklicez

        //otomatik doðrulama özelliðini etkinleþtirir. Bu, bir HTTP isteði alýndýðýnda, doðrulama kurallarýnýn otomatik olarak uygulanmasýný saðlar.
        configuration.AutomaticValidationEnabled = true;
    })

    //JSON serileþtirme yapýlandýrmasýný ekler.
    .AddJsonOptions(configurations =>
    {
        // Serileþtirmesinde döngüsel referanslarý iþlemek için referans iþleyiciyi ayarlar. IgnoreCycles, döngüsel referanslarý görmezden gelerek olasý bir sonsuz döngüyü önler.
        configurations.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });
#endregion

#region Swagger
// Swagger yapýlandýrma seçeneklerini SwaggerGenOptions için yapýlandýran ConfigureSwaggerOptions sýnýfýný IConfigureOptions arabirimine ekler. Bu, Swagger belgelendirmesinin yapýlandýrýlmasýný saðlar.
builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

// IServiceCollection arabirimine SwaggerGen hizmetini ekler.
builder.Services.AddSwaggerGen(options =>
{
    // Mevcut projenin XML belgelendirme dosyasýnýn adýný oluþturur. Bu dosya, projenin içinde API hakkýnda detaylý bilgileri içerir.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

    // XML belgelendirme dosyasýnýn tam yolunu oluþturur. AppContext.BaseDirectory, uygulamanýn çalýþtýðý dizini temsil eder.
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    // Swagger belgelendirmesine XML belgelendirme dosyasýný dahil etme ayarýný yapar. Bu sayede, API Controller'larýndaki örnekler, parametreler ve dönüþ deðerleri gibi detaylý açýklamalarý Swagger belgelerine ekler.
});
#endregion

#region Api Versioning & Api Explorer
// IServiceCollection arabirimine ApiVersioning hizmetini ekler. 
builder.Services.AddApiVersioning(options =>
{
    // Varsayýlan API sürümünü ayarlar. Burada 1.0 sürümü, projenin varsayýlan API sürümü olarak belirlenir.
    options.DefaultApiVersion = new ApiVersion(1, 0);

    // Belirtilmeyen durumlarda varsayýlan API sürümünün kullanýlmasýný saðlar. Yani istemci bir API sürümü belirtmezse, options.DefaultApiVersion ile belirtilen varsayýlan sürüm kullanýlýr.
    options.AssumeDefaultVersionWhenUnspecified = true;

    // API sürümlerini yanýtta raporlama ayarýný etkinleþtirir. Bu, API yanýtlarýnda kullanýlan sürüm bilgisini gönderir.
    options.ReportApiVersions = true;
});

// IServiceCollection arabirimine VersionedApiExplorer hizmetini ekler. 
builder.Services.AddVersionedApiExplorer(options =>
{
    // API grup adý biçimini belirler. 'v'VVV formatý kullanýlarak grup adlarý oluþturulur. VVV, API sürümünü temsil eden yer tutucudur.
    options.GroupNameFormat = "'v'VVV";

    // API sürümünü URL içinde yerine koyma ayarýný etkinleþtirir. Böylece, API isteklerinde URL içindeki sürüm belirtilmiþ olur.
    options.SubstituteApiVersionInUrl = true;
});
#endregion


#region Cors
// IServiceCollection arabirimine CORS (Cross-Origin Resource Sharing) hizmetini ekler. CORS, web uygulamalarýnýn farklý kaynaklardan gelen isteklere izin vermesini saðlayan bir mekanizmadýr.
// CORS hizmetini eklemek, Web API'nin farklý etki alanlarýndan gelen istekleri kabul etmesini ve gerekirse yanýtlara uygun CORS baþlýklarýný eklemesini saðlar. Bu þekilde, Web API'ye dýþ kaynaklardan eriþim saðlanabilir.
builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
policy.WithOrigins("http://localhost:4200", "https://localhost:4200").AllowAnyHeader().AllowAnyMethod() //default olarak localhost:4200 verdim bunun ilgili cliente göre deðiþtirilmesi gerekecek
));
#endregion
#region context config
builder.Services.AddDbContext<EnocaTestProjectDB>(options =>
{
    // SQL Server veritabaný saðlayýcýsýný kullanarak veritabaný baðlamýnýn yapýlandýrýlmasýný yapar. connectionString parametresi, SQL Server baðlantý dizesini temsil eder. 
    // b => b.MigrationsAssembly("SalihPoc.Api") ifadesi, veritabaný migrasyonlarýný uygulamak için kullanýlacak olan migrasyon derlemesinin adýný belirtir. Bu ad, "SalihPoc.Api" olarak belirtilmiþtir.

    options.UseSqlServer(connectionString, builder => builder.MigrationsAssembly("EnocaTestProject.Persistence"));
});
#endregion   




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

var provider = builder.Services.BuildServiceProvider().GetRequiredService<IApiVersionDescriptionProvider>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        foreach (var description in provider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint(
                $"{description.GroupName}/swagger.json",
                $"LawyerProject API {description.GroupName.ToUpperInvariant()}");
        }
    });

    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();
app.UseHangfireDashboard();

app.MapControllers();

app.Run();

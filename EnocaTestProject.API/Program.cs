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
// IServiceCollection arabirimine Controllers hizmetini ekler. Bu, Web API projesinde denetleyicilerin (Controller'lar�n) kullan�lmas�n� sa�lar.
builder.Services.AddControllers(opt =>
{
    //opt.Filters.Add(typeof(UserActivity_));
    opt.Filters.Add<ValidationFilter>();
})
    // FluentValidation k�t�phanesinin yap�land�rmas�n� ekler. 
    .AddFluentValidation(configuration =>
    {
        // Veri anotasyonlar� tabanl� do�rulama �zelli�ini devre d��� b�rak�r. Bu, veri modellerinin �zerindeki DataAnnotations do�rulama �zelliklerini kullanmadan sadece FluentValidation kurallar�n� kullanmay� sa�lar.
        configuration.DisableDataAnnotationsValidation = true;

        // YoneticiValidator s�n�f�n�n bulundu�u derlemedeki do�rulay�c�lar� FluentValidation yap�land�rmas�na kaydeder. Bu �ekilde, belirtilen derlemedeki t�m do�rulay�c�lar otomatik olarak kullan�labilir hale gelir.
        //configuration.RegisterValidatorsFromAssemblyContaining<YoneticiValidator>(); -->validatorleri yazd�ktan sonra eklicez

        //otomatik do�rulama �zelli�ini etkinle�tirir. Bu, bir HTTP iste�i al�nd���nda, do�rulama kurallar�n�n otomatik olarak uygulanmas�n� sa�lar.
        configuration.AutomaticValidationEnabled = true;
    })

    //JSON serile�tirme yap�land�rmas�n� ekler.
    .AddJsonOptions(configurations =>
    {
        // Serile�tirmesinde d�ng�sel referanslar� i�lemek i�in referans i�leyiciyi ayarlar. IgnoreCycles, d�ng�sel referanslar� g�rmezden gelerek olas� bir sonsuz d�ng�y� �nler.
        configurations.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });
#endregion

#region Swagger
// Swagger yap�land�rma se�eneklerini SwaggerGenOptions i�in yap�land�ran ConfigureSwaggerOptions s�n�f�n� IConfigureOptions arabirimine ekler. Bu, Swagger belgelendirmesinin yap�land�r�lmas�n� sa�lar.
builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

// IServiceCollection arabirimine SwaggerGen hizmetini ekler.
builder.Services.AddSwaggerGen(options =>
{
    // Mevcut projenin XML belgelendirme dosyas�n�n ad�n� olu�turur. Bu dosya, projenin i�inde API hakk�nda detayl� bilgileri i�erir.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

    // XML belgelendirme dosyas�n�n tam yolunu olu�turur. AppContext.BaseDirectory, uygulaman�n �al��t��� dizini temsil eder.
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    // Swagger belgelendirmesine XML belgelendirme dosyas�n� dahil etme ayar�n� yapar. Bu sayede, API Controller'lar�ndaki �rnekler, parametreler ve d�n�� de�erleri gibi detayl� a��klamalar� Swagger belgelerine ekler.
});
#endregion

#region Api Versioning & Api Explorer
// IServiceCollection arabirimine ApiVersioning hizmetini ekler. 
builder.Services.AddApiVersioning(options =>
{
    // Varsay�lan API s�r�m�n� ayarlar. Burada 1.0 s�r�m�, projenin varsay�lan API s�r�m� olarak belirlenir.
    options.DefaultApiVersion = new ApiVersion(1, 0);

    // Belirtilmeyen durumlarda varsay�lan API s�r�m�n�n kullan�lmas�n� sa�lar. Yani istemci bir API s�r�m� belirtmezse, options.DefaultApiVersion ile belirtilen varsay�lan s�r�m kullan�l�r.
    options.AssumeDefaultVersionWhenUnspecified = true;

    // API s�r�mlerini yan�tta raporlama ayar�n� etkinle�tirir. Bu, API yan�tlar�nda kullan�lan s�r�m bilgisini g�nderir.
    options.ReportApiVersions = true;
});

// IServiceCollection arabirimine VersionedApiExplorer hizmetini ekler. 
builder.Services.AddVersionedApiExplorer(options =>
{
    // API grup ad� bi�imini belirler. 'v'VVV format� kullan�larak grup adlar� olu�turulur. VVV, API s�r�m�n� temsil eden yer tutucudur.
    options.GroupNameFormat = "'v'VVV";

    // API s�r�m�n� URL i�inde yerine koyma ayar�n� etkinle�tirir. B�ylece, API isteklerinde URL i�indeki s�r�m belirtilmi� olur.
    options.SubstituteApiVersionInUrl = true;
});
#endregion


#region Cors
// IServiceCollection arabirimine CORS (Cross-Origin Resource Sharing) hizmetini ekler. CORS, web uygulamalar�n�n farkl� kaynaklardan gelen isteklere izin vermesini sa�layan bir mekanizmad�r.
// CORS hizmetini eklemek, Web API'nin farkl� etki alanlar�ndan gelen istekleri kabul etmesini ve gerekirse yan�tlara uygun CORS ba�l�klar�n� eklemesini sa�lar. Bu �ekilde, Web API'ye d�� kaynaklardan eri�im sa�lanabilir.
builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
policy.WithOrigins("http://localhost:4200", "https://localhost:4200").AllowAnyHeader().AllowAnyMethod() //default olarak localhost:4200 verdim bunun ilgili cliente g�re de�i�tirilmesi gerekecek
));
#endregion
#region context config
builder.Services.AddDbContext<EnocaTestProjectDB>(options =>
{
    // SQL Server veritaban� sa�lay�c�s�n� kullanarak veritaban� ba�lam�n�n yap�land�r�lmas�n� yapar. connectionString parametresi, SQL Server ba�lant� dizesini temsil eder. 
    // b => b.MigrationsAssembly("SalihPoc.Api") ifadesi, veritaban� migrasyonlar�n� uygulamak i�in kullan�lacak olan migrasyon derlemesinin ad�n� belirtir. Bu ad, "SalihPoc.Api" olarak belirtilmi�tir.

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

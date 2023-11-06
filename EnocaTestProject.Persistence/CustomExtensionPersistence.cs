using EnocaTestProject.Persistence.Repositories.CarrierConfigurationRepositories;
using EnocaTestProject.Persistence.Repositories.CarrierReportRepositories;
using EnocaTestProject.Persistence.Repositories.CarrierRepositories;
using EnocaTestProject.Persistence.Repositories.OrderRepositories;
using EnocaTestProject.Persistence.Services;
using EnocaTextProject.Application.Abstracts;
using EnocaTextProject.Application.Repositories.CarrierConfigurationRepositories;
using EnocaTextProject.Application.Repositories.CarrierReportRepositories;
using EnocaTextProject.Application.Repositories.CarrierRepositories;
using EnocaTextProject.Application.Repositories.OrderRepositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaTestProject.Persistence
{
    public static class CustomExtensionPersistence
    {
        public static void AddContainerWithDependenciesPersistence(this IServiceCollection services)
        {

            services.AddScoped<ICarrierReadRepository, CarrierReadRepository>();
            services.AddScoped<ICarrierWriteRepository, CarrierWriteRepository>();

            services.AddScoped<ICarrierConfigurationReadRepository, CarrierConfigurationReadRepository>();
            services.AddScoped<ICarrierConfigurationWriteRepository, CarrierConfigurationWriteRepository>();

            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();

            services.AddScoped<ICarrierReportReadRepository, CarrierReportReadRepository>();
            services.AddScoped<ICarrierReportWriteRepository, CarrierReportWriteRepository>();

            services.AddScoped<IOrderService, OrderManager>();
        }
    }
}

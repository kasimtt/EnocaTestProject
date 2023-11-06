using AutoMapper;
using EnocaTestProject.Domain.Entities;
using EnocaTextProject.Application.Dtos.CarrierConfigurationDto;
using EnocaTextProject.Application.Feature.Commands.CarrierConfiguration.CreateCarrierConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaTextProject.Application.Mappers
{
    public class CarrierConfigurationProfile: Profile
    {
        public CarrierConfigurationProfile() 
        { 
         
            CreateMap<CarrierConfiguration, GetConfigurationDto>().ReverseMap();
            CreateMap<CarrierConfiguration, CreateCarrierConfigurationDto>().ReverseMap();
            CreateMap<GetCarrierConfigurationDto, CarrierConfiguration>().ReverseMap();
             
        }
    }
}

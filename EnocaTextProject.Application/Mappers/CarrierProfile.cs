using AutoMapper;
using EnocaTestProject.Domain.Entities;
using EnocaTextProject.Application.Dtos.CarrierDtos;
using EnocaTextProject.Application.Feature.Commands.Carrier.CreateCarrier;
using EnocaTextProject.Application.Feature.Commands.Carrier.UpdateCarrier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaTextProject.Application.Mappers
{
    public class CarrierProfile: Profile
    {
        public CarrierProfile()
        {

            CreateMap<Carrier, CreateCarrierDto>().ReverseMap();
            CreateMap<Carrier, GetCarrierDto>().ReverseMap();
            CreateMap<CreateCarrierCommandRequest,Carrier>().ReverseMap();
            CreateMap<UpdateCarrierCommandRequest,Carrier>().ReverseMap();

        }
    }
}

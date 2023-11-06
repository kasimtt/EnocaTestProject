using AutoMapper;
using EnocaTestProject.Domain.Entities;
using EnocaTextProject.Application.Dtos.CarrierReportDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaTextProject.Application.Mappers
{
    public class CarrierReportProfile: Profile
    {
        public CarrierReportProfile()
        {
            CreateMap<GetCarrierReportDto,CarrierReport>().ReverseMap();
        }
    }
}

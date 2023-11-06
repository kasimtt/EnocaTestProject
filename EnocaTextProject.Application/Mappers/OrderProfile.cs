using AutoMapper;
using EnocaTestProject.Domain.Entities;
using EnocaTextProject.Application.Dtos.OrderDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaTextProject.Application.Mappers
{
    public class OrderProfile: Profile
    {
        public OrderProfile() 
        {
          CreateMap<Order, GetOrderDto>().ReverseMap();        
        }
    }
}

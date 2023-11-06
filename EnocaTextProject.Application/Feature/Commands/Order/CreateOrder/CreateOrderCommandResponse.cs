using EnocaTextProject.Application.Dtos.OrderDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaTextProject.Application.Feature.Commands.Order.CreateOrder
{
    public class CreateOrderCommandResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public GetOrderDto Order { get; set; }
    }
}

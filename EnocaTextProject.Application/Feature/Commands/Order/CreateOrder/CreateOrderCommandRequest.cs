using EnocaTestProject.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaTextProject.Application.Feature.Commands.Order.CreateOrder
{
    public class CreateOrderCommandRequest: IRequest<CreateOrderCommandResponse>
    {
        public int OrderDesi { get; set; }
        public DateTime OrderDate { get; set; }
        
       
    }
}

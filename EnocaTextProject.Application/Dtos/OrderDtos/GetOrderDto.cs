using EnocaTestProject.Domain.Entities;
using EnocaTextProject.Application.Dtos.CarrierDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaTextProject.Application.Dtos.OrderDtos
{
    public class GetOrderDto
    {
        public int OrderDesi { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderCarrierCost { get; set; }
        public GetCarrierDto? Carrier { get; set; }
       
    }
}

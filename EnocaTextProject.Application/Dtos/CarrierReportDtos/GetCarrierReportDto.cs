using EnocaTestProject.Domain.Entities;
using EnocaTextProject.Application.Dtos.CarrierDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaTextProject.Application.Dtos.CarrierReportDtos
{
    public class GetCarrierReportDto
    {
      
        public GetCarrierDto Carrier { get; set; }
        public Decimal CarrierCost { get; set; }
        public DateTime CarrierReportDate { get; set; }
    }
}

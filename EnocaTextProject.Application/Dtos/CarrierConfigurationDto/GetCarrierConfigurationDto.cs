using EnocaTestProject.Domain.Entities;
using EnocaTextProject.Application.Dtos.CarrierDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaTextProject.Application.Dtos.CarrierConfigurationDto
{
    public class GetCarrierConfigurationDto
    {
        public GetCarrierDto Carrier { get; set; }
        public int CarrierMaxDesi { get; set; }
        public int CarrierMinDesi { get; set; }
        public decimal CarrierCost { get; set; }
    }
}

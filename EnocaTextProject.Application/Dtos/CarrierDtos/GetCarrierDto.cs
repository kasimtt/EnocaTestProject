using EnocaTestProject.Domain.Entities;
using EnocaTextProject.Application.Dtos.CarrierConfigurationDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaTextProject.Application.Dtos.CarrierDtos
{
    public class GetCarrierDto
    {
        public string CarrierName { get; set; }
        public bool CarrierIsActive { get; set; }
        public int CarrierPlusDesiCost { get; set; }
        public GetConfigurationDto? CarrierConfiguration { get; set; }
        
    }
}

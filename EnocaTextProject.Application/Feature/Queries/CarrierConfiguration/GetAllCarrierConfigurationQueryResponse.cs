using EnocaTextProject.Application.Dtos.CarrierConfigurationDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaTextProject.Application.Feature.Queries.CarrierConfiguration
{
    public class GetAllCarrierConfigurationQueryResponse
    {
        public int TotalCount { get; set; }
        public IEnumerable<GetCarrierConfigurationDto> CarrierConfigurations { get; set; }
    }
}

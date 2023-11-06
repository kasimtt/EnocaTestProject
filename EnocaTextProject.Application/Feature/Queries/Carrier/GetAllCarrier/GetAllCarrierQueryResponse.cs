using EnocaTextProject.Application.Dtos.CarrierDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaTextProject.Application.Feature.Queries.Carrier.GetAllCarrier
{
    public class GetAllCarrierQueryResponse
    {
        public int TotalCount { get; set; }
        public IEnumerable<GetCarrierDto> Carriers { get; set; }
    }
}

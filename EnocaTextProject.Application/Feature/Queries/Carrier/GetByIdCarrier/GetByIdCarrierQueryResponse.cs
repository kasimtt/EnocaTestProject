using EnocaTextProject.Application.Dtos.CarrierDtos;
using EnocaTextProject.Application.Dtos.OrderDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaTextProject.Application.Feature.Queries.Carrier.GetByIdCarrier
{
    public class GetByIdCarrierQueryResponse
    {
        public GetCarrierDto Carrier { get; set; }
    }
}

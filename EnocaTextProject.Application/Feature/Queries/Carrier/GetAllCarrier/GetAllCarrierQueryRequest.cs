using EnocaTextProject.Application.RequestParameters;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaTextProject.Application.Feature.Queries.Carrier.GetAllCarrier
{
    public class GetAllCarrierQueryRequest: IRequest<GetAllCarrierQueryResponse>
    {
        public Pagination Pagination { get; set; }
    }
}

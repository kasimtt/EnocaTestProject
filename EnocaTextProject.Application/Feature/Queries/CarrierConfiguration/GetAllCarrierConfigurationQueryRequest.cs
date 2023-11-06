using EnocaTextProject.Application.RequestParameters;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaTextProject.Application.Feature.Queries.CarrierConfiguration
{
    public class GetAllCarrierConfigurationQueryRequest: IRequest<GetAllCarrierConfigurationQueryResponse>
    {
        public Pagination Pagination { get; set; }
    }
}

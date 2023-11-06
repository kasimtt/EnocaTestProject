using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaTextProject.Application.Feature.Queries.Carrier.GetByIdCarrier
{
    public class GetByIdCarrierQueryRequest: IRequest<GetByIdCarrierQueryResponse>
    {
        public int  Id { get; set; }
    }
}

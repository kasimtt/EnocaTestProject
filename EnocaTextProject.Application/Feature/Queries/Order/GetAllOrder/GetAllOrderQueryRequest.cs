using EnocaTextProject.Application.RequestParameters;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaTextProject.Application.Feature.Queries.Order.GetAllOrder
{
    public class GetAllOrderQueryRequest: IRequest<GetAllOrderQueryResponse>
    {
        public Pagination Pagination { get; set; }
    }
}

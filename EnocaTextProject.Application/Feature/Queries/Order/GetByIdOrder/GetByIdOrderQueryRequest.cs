using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaTextProject.Application.Feature.Queries.Order.GetByIdOrder
{
    public class GetByIdOrderQueryRequest: IRequest<GetByIdOrderQueryResponse>
    {
        public int Id { get; set; }
    }
}

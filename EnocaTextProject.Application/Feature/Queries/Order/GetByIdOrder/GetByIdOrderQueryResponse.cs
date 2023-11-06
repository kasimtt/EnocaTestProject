using EnocaTextProject.Application.Dtos.OrderDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaTextProject.Application.Feature.Queries.Order.GetByIdOrder
{
    public class GetByIdOrderQueryResponse
    {
        public GetOrderDto Order { get; set; }
    }
}

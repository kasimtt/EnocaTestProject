using EnocaTextProject.Application.Dtos.OrderDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaTextProject.Application.Feature.Queries.Order.GetAllOrder
{
    public class GetAllOrderQueryResponse
    {
        public int TotalCount { get; set; }
        public IEnumerable<GetOrderDto>? Orders { get; set; }
    }
}

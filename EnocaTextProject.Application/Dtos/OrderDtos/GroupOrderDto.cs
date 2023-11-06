using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaTextProject.Application.Dtos.OrderDtos
{
    public class GroupOrderDto
    {
        public int CarrierId { get; set; }
        public DateTime ReportDate { get; set; }
        public Decimal TotalCarrierCost { get; set; }
    }
}

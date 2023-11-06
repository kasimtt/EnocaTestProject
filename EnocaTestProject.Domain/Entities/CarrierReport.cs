using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaTestProject.Domain.Entities
{
    public class CarrierReport: BaseEntity
    {
        public int CarrierId { get; set; }
        public Carrier Carrier { get; set; }
        public Decimal CarrierCost { get; set; }
        public DateTime CarrierReportDate { get; set; }
    }
}

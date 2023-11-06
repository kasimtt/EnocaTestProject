using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaTestProject.Domain.Entities
{
    public class Carrier : BaseEntity
    {
       
        public string CarrierName { get; set; }
        public bool CarrierIsActive { get; set; }
        public int CarrierPlusDesiCost { get; set; }
       // public int CarrierConfigrationId { get; set; }
        public CarrierConfiguration CarrierConfiguration { get; set; }
        public ICollection<Order>? Orders { get; set; }
        public ICollection<CarrierReport>? CarrierReports { get; set;}

    }
}

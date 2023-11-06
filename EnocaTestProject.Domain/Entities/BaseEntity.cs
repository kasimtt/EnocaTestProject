using EnocaTestProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaTestProject.Domain.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        virtual public DateTime? UpdatedDate { get; set; }  //bazı verilerin güncellenmesini istemeyebiliriz. ondan dolayı ezilebilir olarak eklemek istedim
        public DataState DataState { get; set; }
    }
}

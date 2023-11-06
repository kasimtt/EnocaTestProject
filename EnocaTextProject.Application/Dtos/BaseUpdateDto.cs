using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaTextProject.Application.Dtos
{
    public class BaseUpdateDto
    {
        public int ObjectId { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
}

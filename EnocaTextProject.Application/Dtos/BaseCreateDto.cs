using EnocaTestProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaTextProject.Application.Dtos
{
    public class BaseCreateDto
    {
        public DateTime CreatedDate { get; set; }
        public DataState DataState { get; set; } = DataState.Active;
    }
}

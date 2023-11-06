using EnocaTestProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaTextProject.Application.Abstracts
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(int OrderDesi, DateTime OrderDate); 

    }
}

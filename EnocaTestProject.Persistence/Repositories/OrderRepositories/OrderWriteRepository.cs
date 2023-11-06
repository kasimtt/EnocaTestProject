using EnocaTestProject.Domain.Entities;
using EnocaTestProject.Persistence.Context;
using EnocaTextProject.Application.Repositories.OrderRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaTestProject.Persistence.Repositories.OrderRepositories
{
    public class OrderWriteRepository : WriteRepository<Order>, IOrderWriteRepository
    {
        private readonly EnocaTestProjectDB _context;
        public OrderWriteRepository(EnocaTestProjectDB context) : base(context)
        {
            _context = context;
        }
    }
}

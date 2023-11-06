using EnocaTestProject.Domain.Entities;
using EnocaTestProject.Persistence.Context;
using EnocaTextProject.Application.Repositories.CarrierRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaTestProject.Persistence.Repositories.CarrierRepositories
{
    public class CarrierReadRepository : ReadRepository<Carrier>, ICarrierReadRepository
    {
        private readonly EnocaTestProjectDB _context;
        public CarrierReadRepository(EnocaTestProjectDB context) : base(context)
        {
            _context = context;
        }
    }
}

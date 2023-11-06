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
    public class CarrierWriteRepository : WriteRepository<Carrier>, ICarrierWriteRepository
    {
        private readonly EnocaTestProjectDB _context;
        public CarrierWriteRepository(EnocaTestProjectDB context) : base(context)
        {
            _context = context;
        }
    }
}

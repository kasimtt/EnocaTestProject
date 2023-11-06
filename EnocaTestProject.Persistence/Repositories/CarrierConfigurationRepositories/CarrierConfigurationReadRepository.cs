using EnocaTestProject.Domain.Entities;
using EnocaTestProject.Persistence.Context;
using EnocaTextProject.Application.Repositories.CarrierConfigurationRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaTestProject.Persistence.Repositories.CarrierConfigurationRepositories    
{
    public class CarrierConfigurationReadRepository : ReadRepository<CarrierConfiguration>, ICarrierConfigurationReadRepository
    {
        private readonly EnocaTestProjectDB _context;
        public CarrierConfigurationReadRepository(EnocaTestProjectDB context) : base(context)
        {
            _context = context;
        }
    }
}

using EnocaTestProject.Domain.Entities;
using EnocaTestProject.Persistence.Context;
using EnocaTextProject.Application.Repositories.CarrierReportRepositories;
using EnocaTextProject.Application.Repositories.OrderRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaTestProject.Persistence.Repositories.CarrierReportRepositories
{
    public class CarrierReportReadRepository : ReadRepository<CarrierReport>, ICarrierReportReadRepository
    {
        private readonly EnocaTestProjectDB _context;
        public CarrierReportReadRepository(EnocaTestProjectDB context) : base(context)
        {
            _context = context;
        }
    }
}

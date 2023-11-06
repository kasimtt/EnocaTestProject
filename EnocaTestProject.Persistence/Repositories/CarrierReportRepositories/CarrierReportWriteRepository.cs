using EnocaTestProject.Domain.Entities;
using EnocaTestProject.Persistence.Context;
using EnocaTextProject.Application.Repositories.CarrierReportRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaTestProject.Persistence.Repositories.CarrierReportRepositories
{
    public class CarrierReportWriteRepository : WriteRepository<CarrierReport>, ICarrierReportWriteRepository
    {
        private readonly EnocaTestProjectDB _context;
        public CarrierReportWriteRepository(EnocaTestProjectDB context) : base(context)
        {
            _context = context; 
        }
    }
}

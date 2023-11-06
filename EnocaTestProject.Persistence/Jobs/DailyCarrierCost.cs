using EnocaTestProject.Domain.Entities;
using EnocaTextProject.Application.Repositories.CarrierReportRepositories;
using EnocaTextProject.Application.Repositories.OrderRepositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaTestProject.Persistence.Jobs
{
    public class DailyCarrierCost
    {
        private readonly IOrderReadRepository _orderReadRepository;
        private readonly ICarrierReportWriteRepository _carrierReportWriteRepository;

        public DailyCarrierCost(IOrderReadRepository orderReadRepository, ICarrierReportWriteRepository carrierReportReadRepository, ICarrierReportWriteRepository carrierReportWriteRepository)
        {
            _orderReadRepository = orderReadRepository;
            _carrierReportWriteRepository = carrierReportWriteRepository;
        }

        public async Task AddDailyCost()
        {


            IEnumerable<Order> orders = _orderReadRepository.Table.Include(o => o.Carrier);


            var groupOrder = orders.GroupBy(o => new { o.Carrier, o.OrderDate }).Select(g => new
            {
                CarrierId = g.Key.Carrier.Id,
                ReportDate = DateTime.Now,
                CarrierCost = g.Sum(o => o.OrderCarrierCost)

            });

            foreach (var order in groupOrder)
            {
                _carrierReportWriteRepository.Add(new CarrierReport
                {
                    CarrierId = order.CarrierId,
                    CarrierReportDate = order.ReportDate,
                    CarrierCost = order.CarrierCost
                });
            }

           await _carrierReportWriteRepository.SaveAsync();

            



        }
    }
}

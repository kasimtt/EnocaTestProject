using EnocaTestProject.Domain.Entities;
using EnocaTextProject.Application.Abstracts;
using EnocaTextProject.Application.Repositories.CarrierRepositories;
using EnocaTextProject.Application.Repositories.OrderRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaTestProject.Persistence.Services
{
    public class OrderManager : IOrderService
    {
        private readonly ICarrierReadRepository _carrierReadRepository;
        private readonly ICarrierWriteRepository _carrierWriteRepository;
        private readonly IOrderWriteRepository _orderWriteRepository;

        public OrderManager(ICarrierReadRepository carrierReadRepository,
            ICarrierWriteRepository carrierWriteRepository,
            IOrderWriteRepository orderWriteRepository)
        {
            _carrierReadRepository = carrierReadRepository;
            _carrierWriteRepository = carrierWriteRepository;
            _orderWriteRepository = orderWriteRepository;
        }

        public async Task<Order> CreateOrderAsync(int OrderDesi, DateTime OrderDate)
        {   
            
            List<Carrier> suitableCarrierList = new List<Carrier>();
            List<Carrier> carrierList = _carrierReadRepository.Table.Include(c=>c.CarrierConfiguration).ToList();
            foreach (var carrier in carrierList)
            {
                if(carrier.CarrierConfiguration!= null &&  OrderDesi< carrier.CarrierConfiguration.CarrierMaxDesi && OrderDesi>carrier.CarrierConfiguration.CarrierMinDesi)
                {
                    suitableCarrierList.Add(carrier);
                }
                
            }
            if (suitableCarrierList.Count > 0)
            {
                Carrier? smallestCostCarrier = suitableCarrierList.OrderBy(c => c.CarrierConfiguration.CarrierCost).FirstOrDefault();
                Order order = new Order
                {
                   CarrierId = smallestCostCarrier.Id,
                   OrderCarrierCost = smallestCostCarrier.CarrierConfiguration.CarrierCost,
                   OrderDate = OrderDate,
                   OrderDesi = OrderDesi,
                };
                await _orderWriteRepository.AddAsync(order);
                await _orderWriteRepository.SaveAsync();
                return order;

            }
            else
            {

                Carrier? smallestCostCarrier = carrierList.Where(c=>c.CarrierConfiguration !=null)
                    .OrderBy(c=>(OrderDesi-c.CarrierConfiguration.CarrierMaxDesi))
                    .FirstOrDefault();
               

                int diff = OrderDesi - smallestCostCarrier.CarrierConfiguration.CarrierMaxDesi;
                decimal cost = (smallestCostCarrier.CarrierConfiguration.CarrierCost) + (diff * smallestCostCarrier.CarrierPlusDesiCost);
                Order order = new Order
                {
                    CarrierId = smallestCostCarrier.Id,
                    OrderCarrierCost = cost,
                    OrderDate = OrderDate,
                    OrderDesi = OrderDesi,
                };
                await _orderWriteRepository.AddAsync(order);
                await _orderWriteRepository.SaveAsync();
                return order;


            }
         

            

            
        }
    }
}

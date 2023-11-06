using O = EnocaTestProject.Domain.Entities;
using EnocaTextProject.Application.Abstracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using EnocaTextProject.Application.Dtos.OrderDtos;

namespace EnocaTextProject.Application.Feature.Commands.Order.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            O.Order order =await _orderService.CreateOrderAsync(request.OrderDesi, request.OrderDate);
            GetOrderDto getOrderDto = _mapper.Map<GetOrderDto>(order);  
            
            return new CreateOrderCommandResponse
            {
                Success = true,
                Order = getOrderDto,
                Message = $"{order.Id} id'li urun {order.Carrier.CarrierName} isimli kargo ile gönderilecek",
    
            };
        }
    }
}

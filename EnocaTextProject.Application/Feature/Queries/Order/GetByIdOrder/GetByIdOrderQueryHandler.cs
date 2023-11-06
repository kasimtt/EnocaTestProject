using O = EnocaTestProject.Domain.Entities;
using EnocaTextProject.Application.Repositories.OrderRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using EnocaTextProject.Application.Dtos.OrderDtos;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace EnocaTextProject.Application.Feature.Queries.Order.GetByIdOrder
{
    public class GetByIdOrderQueryHandler : IRequestHandler<GetByIdOrderQueryRequest, GetByIdOrderQueryResponse>
    {
        private readonly IOrderReadRepository _orderReadRepository;
        private readonly IMapper _mapper;

        public GetByIdOrderQueryHandler(IOrderReadRepository orderReadRepository, IMapper mapper)
        {
            _orderReadRepository = orderReadRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdOrderQueryResponse> Handle(GetByIdOrderQueryRequest request, CancellationToken cancellationToken)
        {
            O.Order? order =await _orderReadRepository.Table.Include(o=>o.Carrier).FirstOrDefaultAsync(o=>o.Id == request.Id);
            GetOrderDto getOrderDto = _mapper.Map<GetOrderDto>(order);
            return new GetByIdOrderQueryResponse
            {
                Order = getOrderDto,
            };
        }
    }
}

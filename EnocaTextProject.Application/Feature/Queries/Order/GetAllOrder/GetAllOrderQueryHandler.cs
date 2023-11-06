using AutoMapper;
using EnocaTestProject.Domain.Entities;
using EnocaTextProject.Application.Dtos.OrderDtos;
using EnocaTextProject.Application.Repositories.OrderRepositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using O = EnocaTestProject.Domain.Entities;

namespace EnocaTextProject.Application.Feature.Queries.Order.GetAllOrder
{
    public class GetAllOrderQueryHandler : IRequestHandler<GetAllOrderQueryRequest, GetAllOrderQueryResponse>
    {
        private readonly IOrderReadRepository _orderReadRepository;
        private readonly IMapper _mapper;

        public GetAllOrderQueryHandler(IOrderReadRepository orderReadRepository, IMapper mapper)
        {
            _orderReadRepository = orderReadRepository;
            _mapper = mapper;
        }

        public async Task<GetAllOrderQueryResponse> Handle(GetAllOrderQueryRequest request, CancellationToken cancellationToken)
        {
            int totalCount = _orderReadRepository.GetAll().Count();
            var result = _orderReadRepository.Table.Include(o=>o.Carrier).Skip(request.Pagination.Page * request.Pagination.Size).Take(request.Pagination.Size).ToList();
            IEnumerable<GetOrderDto> entityDto = _mapper.Map<IEnumerable<O.Order>, IEnumerable<GetOrderDto>>(result).ToList();


            return new GetAllOrderQueryResponse
            {
                TotalCount = totalCount,
                Orders = entityDto

            };
        }
    }
}

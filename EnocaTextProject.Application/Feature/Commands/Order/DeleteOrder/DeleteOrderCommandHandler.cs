using o = EnocaTestProject.Domain.Entities;
using EnocaTextProject.Application.Repositories.OrderRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaTextProject.Application.Feature.Commands.Order.DeleteOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommandRequest, DeleteOrderCommandResponse>
    {
        private readonly IOrderReadRepository _orderReadRepository;
        private readonly IOrderWriteRepository _orderWriteRepository;

        public DeleteOrderCommandHandler(IOrderReadRepository orderReadRepository, IOrderWriteRepository orderWriteRepository)
        {
            _orderReadRepository = orderReadRepository;
            _orderWriteRepository = orderWriteRepository;
        }

        public async Task<DeleteOrderCommandResponse> Handle(DeleteOrderCommandRequest request, CancellationToken cancellationToken)
        {
            o.Order order = await _orderReadRepository.GetByIdAsync(request.Id);
            order.DataState = EnocaTestProject.Domain.Enums.DataState.Deleted;
            await _orderWriteRepository.SaveAsync();
            return new DeleteOrderCommandResponse
            {
                Success = true,
            };

         
        }
    }
}

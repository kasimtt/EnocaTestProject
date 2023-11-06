using c = EnocaTestProject.Domain.Entities;
using EnocaTextProject.Application.Repositories.CarrierRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EnocaTextProject.Application.Feature.Commands.Carrier.DeleteCarrier
{
    public class DeleteCarrierCommandHandler : IRequestHandler<DeleteCarrierCommandRequest, DeleteCarrierCommandResponse>
    {
        private readonly ICarrierReadRepository _carrierReadRepository;
        private readonly ICarrierWriteRepository _carrierWriteRepository;

        public DeleteCarrierCommandHandler(ICarrierReadRepository carrierReadRepository, ICarrierWriteRepository carrierWriteRepository)
        {
            _carrierReadRepository = carrierReadRepository;
            _carrierWriteRepository = carrierWriteRepository;
        }

        public async Task<DeleteCarrierCommandResponse> Handle(DeleteCarrierCommandRequest request, CancellationToken cancellationToken)
        {


            c.Carrier? carrier = await _carrierReadRepository.Table.Include(c => c.CarrierConfiguration).FirstOrDefaultAsync(c=>c.Id == request.Id);
            if (carrier != null && carrier.DataState != EnocaTestProject.Domain.Enums.DataState.Deleted)
            {
                carrier.DataState = EnocaTestProject.Domain.Enums.DataState.Deleted;
                carrier.CarrierConfiguration.DataState = EnocaTestProject.Domain.Enums.DataState.Deleted;
                await _carrierWriteRepository.SaveAsync();
                return new DeleteCarrierCommandResponse
                {
                    Success = true,
                    Message = $"{request.Id} Idli kargo silinmiştir",
                };
            }
            else 
            {
                return new DeleteCarrierCommandResponse
                {
                    Success = false,
                    Message = $"{request.Id} Idli kargo bulunamamıştır"

                };
            
            
            }


        }
    }
}

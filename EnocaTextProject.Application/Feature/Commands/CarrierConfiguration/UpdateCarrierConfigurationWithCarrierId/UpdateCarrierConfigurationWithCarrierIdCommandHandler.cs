using c= EnocaTestProject.Domain.Entities;
using EnocaTextProject.Application.Repositories.CarrierConfigurationRepositories;
using EnocaTextProject.Application.Repositories.CarrierRepositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaTextProject.Application.Feature.Commands.CarrierConfiguration.UpdateCarrierConfigurationWithCarrierId
{
    public class UpdateCarrierConfigurationWithCarrierIdCommandHandler : IRequestHandler<UpdateCarrierConfigurationWithCarrierIdCommandRequest, UpdateCarrierConfigurationWithCarrierIdCommandResponse>
    {
        private readonly ICarrierConfigurationReadRepository _carrierConfigurationReadRepository;
        private readonly ICarrierConfigurationWriteRepository _carrierConfigurationWriteRepository;
        private readonly ICarrierReadRepository _carrierReadRepository;

        public UpdateCarrierConfigurationWithCarrierIdCommandHandler(ICarrierConfigurationReadRepository carrierConfigurationReadRepository, 
            ICarrierConfigurationWriteRepository carrierConfigurationWriteRepository, 
            ICarrierReadRepository carrierReadRepository)
        {
            _carrierConfigurationReadRepository = carrierConfigurationReadRepository;
            _carrierConfigurationWriteRepository = carrierConfigurationWriteRepository;
            _carrierReadRepository = carrierReadRepository;
        }

        public async Task<UpdateCarrierConfigurationWithCarrierIdCommandResponse> Handle(UpdateCarrierConfigurationWithCarrierIdCommandRequest request, CancellationToken cancellationToken)
        {
           c.Carrier? carrier  =   await  _carrierReadRepository.Table.Include(c=>c.CarrierConfiguration).FirstOrDefaultAsync(c=>c.Id == request.Id);

            if (carrier == null) {

                new UpdateCarrierConfigurationWithCarrierIdCommandResponse
                {
                    Message = $"{request.Id} li kargo bulunamamıştır",
                    Success = false,
                };
            
            }
            
            carrier.CarrierConfiguration.CarrierMaxDesi = request.carrierConfiguration.CarrierMaxDesi;
            carrier.CarrierConfiguration.CarrierMinDesi = request.carrierConfiguration.CarrierMinDesi;
            carrier.CarrierConfiguration.CarrierCost = request.carrierConfiguration.CarrierCost;
           await  _carrierConfigurationWriteRepository.SaveAsync();

            return new UpdateCarrierConfigurationWithCarrierIdCommandResponse
            {
                Message = $"{carrier.CarrierName} isimli kargo şirketinin bilgileri güncellendi",
                Success = true,
            };

        }
    }
}

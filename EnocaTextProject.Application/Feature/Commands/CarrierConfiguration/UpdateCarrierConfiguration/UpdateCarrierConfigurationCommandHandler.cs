using c= EnocaTestProject.Domain.Entities;
using EnocaTextProject.Application.Repositories.CarrierConfigurationRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EnocaTextProject.Application.Feature.Commands.CarrierConfiguration.UpdateCarrierConfiguration
{
    public class UpdateCarrierConfigurationCommandHandler : IRequestHandler<UpdateCarrierConfigurationCommandRequest, UpdateCarrierConfigurationCommandResponse>
    {
        private readonly ICarrierConfigurationReadRepository _carrierConfigurationReadRepository;
        private readonly ICarrierConfigurationWriteRepository _carrierConfigurationWriteRepository;

        public UpdateCarrierConfigurationCommandHandler(ICarrierConfigurationReadRepository carrierConfigurationReadRepository, ICarrierConfigurationWriteRepository carrierConfigurationWriteRepository)
        {
            _carrierConfigurationReadRepository = carrierConfigurationReadRepository;
            _carrierConfigurationWriteRepository = carrierConfigurationWriteRepository;
        }

        public async Task<UpdateCarrierConfigurationCommandResponse> Handle(UpdateCarrierConfigurationCommandRequest request, CancellationToken cancellationToken)
        {
            c.CarrierConfiguration? carrierConfiguration = await _carrierConfigurationReadRepository.Table.Include(c=>c.Carrier).FirstOrDefaultAsync(c=>c.Id == request.CarrierConfigurationDto.Id);

            if (carrierConfiguration == null)
            {
                return new UpdateCarrierConfigurationCommandResponse
                {
                    Success = true,
                    Message = $"{request.CarrierConfigurationDto.Id} idli konfigurasyon bulunamadı"
                };
            }


            carrierConfiguration.CarrierCost = request.CarrierConfigurationDto.CarrierCost;
            carrierConfiguration.CarrierMaxDesi = request.CarrierConfigurationDto.CarrierMaxDesi;
            carrierConfiguration.CarrierMinDesi = request.CarrierConfigurationDto.CarrierMinDesi;
           await _carrierConfigurationWriteRepository.SaveAsync();
            return new UpdateCarrierConfigurationCommandResponse
            {
                Message = $"{carrierConfiguration.Carrier.CarrierName} isimli kargonun konfigurasyonları güncellendi",
                Success = true,
            };
        }
    }
}

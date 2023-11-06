using c = EnocaTestProject.Domain.Entities;
using EnocaTextProject.Application.Repositories.CarrierConfigurationRepositories;
using EnocaTextProject.Application.Repositories.CarrierRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnocaTestProject.Domain.Entities;
using AutoMapper;

namespace EnocaTextProject.Application.Feature.Commands.CarrierConfiguration.CreateCarrierConfiguration
{
    public class CreateCarrierConfigurationCommandHandler : IRequestHandler<CreateCarrierConfigurationCommandRequest, CreateCarrierConfigurationCommandResponse>
    {
        private readonly ICarrierConfigurationReadRepository _carrierConfigurationReadRepository;
        private readonly ICarrierConfigurationWriteRepository _carrierConfigurationWriteRepository;
        private readonly ICarrierReadRepository _carrierReadRepository;
        private readonly IMapper _mapper;

        public CreateCarrierConfigurationCommandHandler(ICarrierConfigurationReadRepository carrierConfigurationReadRepository,
            ICarrierConfigurationWriteRepository carrierConfigurationWriteRepository,
            ICarrierReadRepository carrierReadRepository,
            IMapper mapper)
        {
            _carrierConfigurationReadRepository = carrierConfigurationReadRepository;
            _carrierConfigurationWriteRepository = carrierConfigurationWriteRepository;
            _carrierReadRepository = carrierReadRepository;
            _mapper = mapper;
        }

        public async Task<CreateCarrierConfigurationCommandResponse> Handle(CreateCarrierConfigurationCommandRequest request, CancellationToken cancellationToken)
        {
         

            c.CarrierConfiguration carrierConfiguration = _mapper.Map<c.CarrierConfiguration>(request.CreateCarrierConfigurationDto);
            c.CarrierConfiguration carrierConfiguration2 =await _carrierConfigurationReadRepository.GetSingleAsync(c => c.CarrierId == request.Id);
            c.Carrier carrier = await _carrierReadRepository.GetByIdAsync(request.Id);
            if(carrierConfiguration2 == null && carrier != null)
            {
                carrierConfiguration.CarrierId = request.Id;

                await _carrierConfigurationWriteRepository.AddAsync(carrierConfiguration);
                await _carrierConfigurationWriteRepository.SaveAsync();
                return new CreateCarrierConfigurationCommandResponse
                {
                    Success = true,
                    Message = $"{carrierConfiguration.CarrierId} id'li kargocunun ozellikleri başarıyla güncellenmiştir başarıyla eklenmiştir"
                };
            }
            else if(carrier == null)
            {
                return new CreateCarrierConfigurationCommandResponse
                {
                    Message = $"{request.Id} id' li kargo şirketi bulunamadı",
                    Success = false
                };
            }


            return new CreateCarrierConfigurationCommandResponse
            {
                Success = false,
                Message = $"{request.Id} id'li kargocunun configurasyonu daha önceden eklenmişti lütfen başka bir kargo şirketini seçiniz",
            };
    }
}
}

using c =  EnocaTestProject.Domain.Entities;
using EnocaTextProject.Application.Repositories.CarrierRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace EnocaTextProject.Application.Feature.Commands.Carrier.CreateCarrier
{
    public class CreateCarrierCommandHandler : IRequestHandler<CreateCarrierCommandRequest, CreateCarrierCommandResponse>
    {
        private readonly ICarrierWriteRepository _carrierWriteRepository;
        private readonly IMapper _mapper;

        public CreateCarrierCommandHandler(ICarrierWriteRepository carrierWriteRepository, IMapper mapper)
        {
            _carrierWriteRepository = carrierWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateCarrierCommandResponse> Handle(CreateCarrierCommandRequest request, CancellationToken cancellationToken)
        {
            c.Carrier carrier = _mapper.Map<c.Carrier>(request);
            await _carrierWriteRepository.AddAsync(carrier);
            await _carrierWriteRepository.SaveAsync();

            return new CreateCarrierCommandResponse
            {
                Success = true,
                Message = $"{request.CarrierName} isimli kargo şirketi eklenmiştir" 
            };
        }
    }
}

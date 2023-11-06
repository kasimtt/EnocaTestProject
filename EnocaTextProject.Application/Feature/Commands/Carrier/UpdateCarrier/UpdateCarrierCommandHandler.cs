using a =  EnocaTestProject.Domain.Entities;
using EnocaTextProject.Application.Repositories.CarrierRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace EnocaTextProject.Application.Feature.Commands.Carrier.UpdateCarrier
{
    public class UpdateCarrierCommandHandler : IRequestHandler<UpdateCarrierCommandRequest, UpdateCarrierCommandResponse>
    {
        private readonly ICarrierWriteRepository _carrierWriteRepository;
        private readonly ICarrierReadRepository _carrierReadRepository;
        private readonly IMapper _mapper;

        public UpdateCarrierCommandHandler(ICarrierWriteRepository carrierWriteRepository, IMapper mapper, ICarrierReadRepository carrierReadRepository)
        {
            _carrierWriteRepository = carrierWriteRepository;
            _mapper = mapper;
            _carrierReadRepository = carrierReadRepository;
        }

        public async Task<UpdateCarrierCommandResponse> Handle(UpdateCarrierCommandRequest request, CancellationToken cancellationToken)
        {

           a.Carrier? carrier =  await _carrierReadRepository.GetByIdAsync(request.Id);
            
            if(carrier != null)
            {
                carrier.CarrierName = request.CarrierName;
                carrier.CarrierPlusDesiCost = request.CarrierPlusDesiCost;
                carrier.CarrierIsActive = request.CarrierIsActive;
                await _carrierWriteRepository.SaveAsync();

                return new UpdateCarrierCommandResponse
                {
                    Success = true,
                    Message = $"{request.Id} idli kargo güncellenmiştir"
                };
            }
            return new UpdateCarrierCommandResponse
            {
                Success = true,
                Message = $"{request.Id} idli kargo bulunamamıştır"
            };

           
            
           


            //a.Carrier carrier = _mapper.Map<a.Carrier>(request);  --> Todo: güncelleme yapıyor ama her seferinde update date'yi sıfırlıyor.bakilacak 
            //_carrierWriteRepository.Update(carrier);
            //await _carrierWriteRepository.SaveAsync();
            //return new UpdateCarrierCommandResponse
            //{
            //    Success = true,
            //};


        }
    }
}

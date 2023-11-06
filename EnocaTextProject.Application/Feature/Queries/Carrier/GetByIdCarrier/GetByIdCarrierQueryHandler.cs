using C = EnocaTestProject.Domain.Entities;
using EnocaTextProject.Application.Repositories.CarrierRepositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnocaTextProject.Application.Dtos.CarrierDtos;
using AutoMapper;

namespace EnocaTextProject.Application.Feature.Queries.Carrier.GetByIdCarrier
{
    public class GetByIdCarrierQueryHandler : IRequestHandler<GetByIdCarrierQueryRequest, GetByIdCarrierQueryResponse>
    {
        private readonly ICarrierReadRepository _carrierReadRepository;
        private readonly IMapper _mapper;

        public GetByIdCarrierQueryHandler(ICarrierReadRepository carrierReadRepository, IMapper mapper)
        {
            _carrierReadRepository = carrierReadRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdCarrierQueryResponse> Handle(GetByIdCarrierQueryRequest request, CancellationToken cancellationToken)
        {
            C.Carrier? carrier =await _carrierReadRepository.Table.Include(c => c.CarrierConfiguration).FirstOrDefaultAsync(r => r.Id == request.Id);
            GetCarrierDto carrierDto = _mapper.Map<GetCarrierDto>(carrier);

            return new GetByIdCarrierQueryResponse
            {
                Carrier = carrierDto,
            };
        }
    }
}

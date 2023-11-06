using c = EnocaTestProject.Domain.Entities;
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

namespace EnocaTextProject.Application.Feature.Queries.Carrier.GetAllCarrier
{
    public class GetAllCarrierQueryHandler : IRequestHandler<GetAllCarrierQueryRequest, GetAllCarrierQueryResponse>
    {
        private readonly ICarrierReadRepository _carrierReadRepository;
        private readonly IMapper _mapper;

        public GetAllCarrierQueryHandler(ICarrierReadRepository carrierReadRepository, IMapper mapper)
        {
            _carrierReadRepository = carrierReadRepository;
            _mapper = mapper;
        }

        public async Task<GetAllCarrierQueryResponse> Handle(GetAllCarrierQueryRequest request, CancellationToken cancellationToken)
        {

           IEnumerable<c.Carrier> carriers =  _carrierReadRepository.Table.Include(c => c.CarrierConfiguration).Skip(request.Pagination.Page * request.Pagination.Size).Take(request.Pagination.Size).ToList();
            int total = carriers.Count();
           IEnumerable<GetCarrierDto> carrierDtos = _mapper.Map<IEnumerable<c.Carrier>, IEnumerable<GetCarrierDto>>(carriers).ToList();

            return new GetAllCarrierQueryResponse
            {
                Carriers = carrierDtos,
                TotalCount = total,

            };

        }
    }
}

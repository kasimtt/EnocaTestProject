using AutoMapper;
using C =  EnocaTestProject.Domain.Entities;
using EnocaTextProject.Application.Repositories.CarrierConfigurationRepositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EnocaTextProject.Application.Dtos.CarrierConfigurationDto;

namespace EnocaTextProject.Application.Feature.Queries.CarrierConfiguration
{
    public class GetAllCarrierConfigurationQueryHandler : IRequestHandler<GetAllCarrierConfigurationQueryRequest, GetAllCarrierConfigurationQueryResponse>
    {
        private readonly ICarrierConfigurationReadRepository _carrierConfigurationReadRepository;
        private IMapper _mapper;

        public GetAllCarrierConfigurationQueryHandler(ICarrierConfigurationReadRepository carrierConfigurationReadRepository, IMapper mapper)
        {
            _carrierConfigurationReadRepository = carrierConfigurationReadRepository;
            _mapper = mapper;
        }

        public async Task<GetAllCarrierConfigurationQueryResponse> Handle(GetAllCarrierConfigurationQueryRequest request, CancellationToken cancellationToken)
        {
            IEnumerable<C.CarrierConfiguration> carrierConfiguration = _carrierConfigurationReadRepository.Table.Include(c=>c.Carrier).Skip(request.Pagination.Page * request.Pagination.Size).Take(request.Pagination.Size).ToList();
            IEnumerable<GetCarrierConfigurationDto> carrierConfigurationDtos = _mapper.Map<IEnumerable<C.CarrierConfiguration>, IEnumerable<GetCarrierConfigurationDto>>(carrierConfiguration);

            return new GetAllCarrierConfigurationQueryResponse
            {
                CarrierConfigurations = carrierConfigurationDtos,
                TotalCount = carrierConfigurationDtos.Count()
            };

        }
    }
}

using C = EnocaTestProject.Domain.Entities;
using EnocaTextProject.Application.Repositories.CarrierReportRepositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using EnocaTextProject.Application.Dtos.CarrierDtos;
using AutoMapper;
using EnocaTextProject.Application.Dtos.OrderDtos;
using EnocaTextProject.Application.Dtos.CarrierReportDtos;

namespace EnocaTextProject.Application.Feature.Queries.CarrierReport.GetAllCarrierReport
{
    public class GetAllCarrierReportQueryHandler : IRequestHandler<GetAllCarrierReportQueryRequest, GetAllCarrierReportQueryResponse>
    {
        private readonly ICarrierReportReadRepository _carrierReportReadRepository;
        private readonly IMapper _mapper;

        public GetAllCarrierReportQueryHandler(ICarrierReportReadRepository carrierReportReadRepository, IMapper mapper)
        {
            _carrierReportReadRepository = carrierReportReadRepository;
            _mapper = mapper;
        }

        public async Task<GetAllCarrierReportQueryResponse> Handle(GetAllCarrierReportQueryRequest request, CancellationToken cancellationToken)
        {
           IEnumerable<C.CarrierReport> carrierReport =  _carrierReportReadRepository.Table.Include(c => c.Carrier).Skip(request.Pagination.Page * request.Pagination.Size).Take(request.Pagination.Size).ToList();

            IEnumerable<GetCarrierReportDto> getCarrierDtos = _mapper.Map<IEnumerable<C.CarrierReport>, IEnumerable<GetCarrierReportDto>>(carrierReport).ToList();

            return new GetAllCarrierReportQueryResponse
            {
                Carriers = getCarrierDtos,
                TotalCount = getCarrierDtos.Count()
            };
        }
    }
}

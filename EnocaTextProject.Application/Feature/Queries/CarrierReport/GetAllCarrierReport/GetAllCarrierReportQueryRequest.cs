using EnocaTextProject.Application.RequestParameters;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaTextProject.Application.Feature.Queries.CarrierReport.GetAllCarrierReport
{
    public class GetAllCarrierReportQueryRequest: IRequest<GetAllCarrierReportQueryResponse>
    {
        public Pagination Pagination { get; set; }
    }
}

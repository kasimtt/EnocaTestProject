using EnocaTextProject.Application.Dtos.CarrierDtos;
using EnocaTextProject.Application.Dtos.CarrierReportDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaTextProject.Application.Feature.Queries.CarrierReport.GetAllCarrierReport
{
    public class GetAllCarrierReportQueryResponse
    {
        public int TotalCount { get; set; }
        public IEnumerable<GetCarrierReportDto> Carriers { get; set;}
       
    }
}

using EnocaTextProject.Application.Dtos.CarrierConfigurationDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaTextProject.Application.Feature.Commands.CarrierConfiguration.UpdateCarrierConfiguration
{
    public class UpdateCarrierConfigurationCommandRequest: IRequest<UpdateCarrierConfigurationCommandResponse>
    {
      
        public UpdateCarrierConfigurationDto CarrierConfigurationDto { get; set; }
    }
}

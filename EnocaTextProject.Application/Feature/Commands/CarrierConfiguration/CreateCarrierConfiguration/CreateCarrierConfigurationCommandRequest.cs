using EnocaTextProject.Application.Dtos.CarrierConfigurationDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaTextProject.Application.Feature.Commands.CarrierConfiguration.CreateCarrierConfiguration
{
    public class CreateCarrierConfigurationCommandRequest: IRequest<CreateCarrierConfigurationCommandResponse>
    {
        public int Id { get; set; }
        public CreateCarrierConfigurationDto CreateCarrierConfigurationDto { get; set; }

    }
}

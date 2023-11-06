using EnocaTextProject.Application.Dtos.CarrierConfigurationDto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnocaTextProject.Application.Feature.Commands.CarrierConfiguration.UpdateCarrierConfigurationWithCarrierId
{
    public class UpdateCarrierConfigurationWithCarrierIdCommandRequest: IRequest<UpdateCarrierConfigurationWithCarrierIdCommandResponse>
    {
        public int Id { get; set; }
        public UpdateCarrierConfigurationWithCarrierIdDto carrierConfiguration { get; set; }
    }
}

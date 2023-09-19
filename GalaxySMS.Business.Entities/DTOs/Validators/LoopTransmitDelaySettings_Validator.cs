using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Business.Entities
{
    using FluentValidation;
    public partial class LoopTransmitDelaySettings
    {
        class LoopTransmitDelaySettingsValidator : AbstractValidator<LoopTransmitDelaySettings>
        {
            public LoopTransmitDelaySettingsValidator()
            {
                RuleFor(obj => (int)obj.Delay).InclusiveBetween(0, 255);
            }
        }

        protected override IValidator GetValidator()
        {
            return new LoopTransmitDelaySettingsValidator();
        }
    }
}

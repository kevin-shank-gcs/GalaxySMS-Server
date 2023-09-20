using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Business.Entities
{
    using FluentValidation;
    public partial class GalaxyPanelResetCommand
    {
        class GalaxyPanelResetCommandValidator : AbstractValidator<GalaxyPanelResetCommand>
        {
            public GalaxyPanelResetCommandValidator()
            {

            }
        }

        protected override IValidator GetValidator()
        {
            return new GalaxyPanelResetCommandValidator();
        }
    }
}

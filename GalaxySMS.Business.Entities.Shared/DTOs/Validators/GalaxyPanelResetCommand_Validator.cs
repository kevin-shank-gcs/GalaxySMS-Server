using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
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

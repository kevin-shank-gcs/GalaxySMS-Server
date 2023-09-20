using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using GalaxySMS.Common.Constants;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
    public partial class GalaxyOutputDevice_InputSource_InputOutputGroupMode_PanelLoadData
    {
        class GalaxyOutputDevice_InputSource_InputOutputGroupMode_PanelLoadDataValidator : AbstractValidator<GalaxyOutputDevice_InputSource_InputOutputGroupMode_PanelLoadData>
        {
            public GalaxyOutputDevice_InputSource_InputOutputGroupMode_PanelLoadDataValidator()
            {
                RuleFor(obj => (int)obj.IOGroupNumber).InclusiveBetween(InputOutputGroupLimits.None, InputOutputGroupLimits.HighestNumber);
            }
        }

        protected override IValidator GetValidator()
        {
            return new GalaxyOutputDevice_InputSource_InputOutputGroupMode_PanelLoadDataValidator();
        }
    }
}

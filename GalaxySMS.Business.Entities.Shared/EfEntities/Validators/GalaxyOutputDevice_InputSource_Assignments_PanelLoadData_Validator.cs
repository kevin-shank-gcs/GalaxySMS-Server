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
    public partial class GalaxyOutputDevice_InputSource_Assignments_PanelLoadData
    {
        class GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataValidator : AbstractValidator<GalaxyOutputDevice_InputSource_Assignments_PanelLoadData>
        {
            public GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataValidator()
            {
                RuleFor(obj => (int)obj.OffsetIndex).InclusiveBetween(GalaxySMS.Common.Constants.InputOutputGroupOffsetLimits.None, InputOutputGroupOffsetLimits.Maximum);
            }
        }

        protected override IValidator GetValidator()
        {
            return new GalaxyOutputDevice_InputSource_Assignments_PanelLoadDataValidator();
        }
    }
}

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
    public partial class GalaxyTimePeriod_GetPanelLoadData
    {
        class GalaxyTimePeriod_GetPanelLoadDataValidator : AbstractValidator<GalaxyTimePeriod_GetPanelLoadData>
        {
            public GalaxyTimePeriod_GetPanelLoadDataValidator()
            {
                RuleFor(obj => obj.PanelTimePeriodNumber).InclusiveBetween(GalaxyTimePeriodLimits.Never, GalaxyTimePeriodLimits.Always);
            }
        }

        protected override IValidator GetValidator()
        {
            return new GalaxyTimePeriod_GetPanelLoadDataValidator();
        }
    }
}

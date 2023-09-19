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
    public partial class TimeScheduleOneMinuteFormat_GetPanelLoadData
    {
        class TimeScheduleOneMinuteFormat_GetPanelLoadDataValidator : AbstractValidator<TimeScheduleOneMinuteFormat_GetPanelLoadData>
        {
            public TimeScheduleOneMinuteFormat_GetPanelLoadDataValidator()
            {
                RuleFor(obj => obj.PanelScheduleNumber).InclusiveBetween(TimeScheduleLimits.Never, TimeScheduleLimits.Always);
                RuleFor(obj => obj.PanelTimePeriodNumber).InclusiveBetween(GalaxyTimePeriodLimits.Never, GalaxyTimePeriodLimits.Always);
            }
        }

        protected override IValidator GetValidator()
        {
            return new TimeScheduleOneMinuteFormat_GetPanelLoadDataValidator();
        }
    }
}

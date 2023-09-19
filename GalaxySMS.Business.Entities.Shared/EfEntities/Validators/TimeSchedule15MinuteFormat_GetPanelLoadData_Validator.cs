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
    public partial class TimeSchedule15MinuteFormat_GetPanelLoadData
    {
        class TimeSchedule15MinuteFormat_GetPanelLoadDataValidator : AbstractValidator<TimeSchedule15MinuteFormat_GetPanelLoadData>
        {
            public TimeSchedule15MinuteFormat_GetPanelLoadDataValidator()
            {
                RuleFor(obj => obj.PanelScheduleNumber).InclusiveBetween(TimeScheduleLimits.Never, TimeScheduleLimits.Always);

            }
        }

        protected override IValidator GetValidator()
        {
            return new TimeSchedule15MinuteFormat_GetPanelLoadDataValidator();
        }
    }
}

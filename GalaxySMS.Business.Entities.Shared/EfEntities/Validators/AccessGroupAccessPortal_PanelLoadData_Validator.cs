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
    public partial class AccessGroupAccessPortal_PanelLoadData
    {
        class AccessGroupAccessPortal_PanelLoadDataValidator : AbstractValidator<AccessGroupAccessPortal_PanelLoadData>
        {
            public AccessGroupAccessPortal_PanelLoadDataValidator()
            {
                RuleFor(obj => obj.AccessGroupNumber).InclusiveBetween(GalaxySMS.Common.Constants.AccessGroupLimits.None, GalaxySMS.Common.Constants.AccessGroupLimits.MaximumNumber);
                RuleFor(obj => obj.ScheduleNumber).InclusiveBetween(GalaxySMS.Common.Constants.TimeScheduleNumber.TimeSchedule_Never, GalaxySMS.Common.Constants.TimeScheduleNumber.TimeSchedule_Always);
            }
        }

        protected override IValidator GetValidator()
        {
            return new AccessGroupAccessPortal_PanelLoadDataValidator();
        }
    }
}

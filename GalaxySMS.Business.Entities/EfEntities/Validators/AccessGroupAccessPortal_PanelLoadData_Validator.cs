using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace GalaxySMS.Business.Entities
{
    public partial class AccessGroupAccessPortal_PanelLoadData
    {
        class AccessGroupAccessPortal_PanelLoadDataValidator : AbstractValidator<AccessGroupAccessPortal_PanelLoadData>
        {
            public AccessGroupAccessPortal_PanelLoadDataValidator()
            {
                RuleFor(obj => obj.AccessGroupNumber).InclusiveBetween(GalaxySMS.Common.Constants.AccessGroupLimits.None, GalaxySMS.Common.Constants.AccessGroupLimits.MaximumNumber);
                RuleFor(obj => obj.PanelScheduleNumber).InclusiveBetween(GalaxySMS.Common.Constants.TimeScheduleNumber.TimeSchedule_Never, GalaxySMS.Common.Constants.TimeScheduleNumber.TimeSchedule_Always);
            }
        }

        protected override IValidator GetValidator()
        {
            return new AccessGroupAccessPortal_PanelLoadDataValidator();
        }
    }
}

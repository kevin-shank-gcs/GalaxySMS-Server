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
    public partial class DateTypeDefaultBehavior_PanelLoadData
    {
        class DateTypeDefaultBehavior_PanelLoadDataValidator : AbstractValidator<DateTypeDefaultBehavior_PanelLoadData>
        {
            public DateTypeDefaultBehavior_PanelLoadDataValidator()
            {
                //RuleFor(obj => obj.FridayDayCode).NotEmpty().Length(1, 65);

            }
        }

        protected override IValidator GetValidator()
        {
            return new DateTypeDefaultBehavior_PanelLoadDataValidator();
        }
    }
}

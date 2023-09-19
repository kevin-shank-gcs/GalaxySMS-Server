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
    public partial class ReaderLockoutSettings
    {
        class ReaderLockoutSettingsValidator : AbstractValidator<ReaderLockoutSettings>
        {
            public ReaderLockoutSettingsValidator()
            {
                RuleFor(obj => (int)obj.LockoutTimeInHundredthsOfSeconds).InclusiveBetween(0, 65535);
                RuleFor(obj => (int)obj.MaximumInvalidAttempts).InclusiveBetween(0, 255);
            }
        }

        protected override IValidator GetValidator()
        {
            return new ReaderLockoutSettingsValidator();
        }
    }
}

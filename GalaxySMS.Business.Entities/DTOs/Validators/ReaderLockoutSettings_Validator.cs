using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Business.Entities
{
    using FluentValidation;
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

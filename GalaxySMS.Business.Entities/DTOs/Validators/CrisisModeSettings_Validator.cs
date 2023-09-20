using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Business.Entities
{
    using FluentValidation;
    public partial class CrisisModeSettings
    {
        class CrisisModeSettingsValidator : AbstractValidator<CrisisModeSettings>
        {
            public CrisisModeSettingsValidator()
            {
                RuleFor(obj => (int)obj.ActivateInputOutputGroupNumber.GroupNumber).InclusiveBetween(0, 255);
                RuleFor(obj => (int)obj.ResetInputOutputGroupNumber.GroupNumber).InclusiveBetween(0, 255);
            }
        }

        protected override IValidator GetValidator()
        {
            return new CrisisModeSettingsValidator();
        }
    }
}

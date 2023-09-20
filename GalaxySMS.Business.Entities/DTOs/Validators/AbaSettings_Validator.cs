using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Business.Entities
{
    using FluentValidation;
    public partial class AbaSettings
    {
        class AbaSettingsValidator : AbstractValidator<AbaSettings>
        {
            public AbaSettingsValidator()
            {
                RuleFor(obj => (int)obj.Start).InclusiveBetween(1, 59);
                RuleFor(obj => (int)obj.End).InclusiveBetween(2, 60);
                RuleFor(obj => (int)obj.Start).LessThan(obj => obj.End);
            }
        }

        protected override IValidator GetValidator()
        {
            return new AbaSettingsValidator();
        }
    }
}

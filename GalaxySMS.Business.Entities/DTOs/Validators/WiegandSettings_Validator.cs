using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Business.Entities
{
    using FluentValidation;
    public partial class WiegandSettings
    {
        class WiegandSettingsValidator : AbstractValidator<WiegandSettings>
        {
            public WiegandSettingsValidator()
            {
                RuleFor(obj => (int)obj.Start).InclusiveBetween(0, 254);
                RuleFor(obj => (int)obj.End).InclusiveBetween(1, 255);
                RuleFor(obj => (int)obj.Start).LessThan(obj => obj.End);
            }
        }

        protected override IValidator GetValidator()
        {
            return new WiegandSettingsValidator();
        }
    }
}

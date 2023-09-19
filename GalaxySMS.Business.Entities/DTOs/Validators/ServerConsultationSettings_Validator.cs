using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Business.Entities
{
    using FluentValidation;
    public partial class ServerConsultationSettings
    {
        class ServerConsultationSettingsValidator : AbstractValidator<ServerConsultationSettings>
        {
            public ServerConsultationSettingsValidator()
            {
                RuleFor(obj => (int)obj.AccessDecisionTimeout).InclusiveBetween(0, 65535);
                RuleFor(obj => (int)obj.UnknownCredentialLookupTimeout).InclusiveBetween(0, 65535);
            }
        }

        protected override IValidator GetValidator()
        {
            return new ServerConsultationSettingsValidator();
        }
    }
}

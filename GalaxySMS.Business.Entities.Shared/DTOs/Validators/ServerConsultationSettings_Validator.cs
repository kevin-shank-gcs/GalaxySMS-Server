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

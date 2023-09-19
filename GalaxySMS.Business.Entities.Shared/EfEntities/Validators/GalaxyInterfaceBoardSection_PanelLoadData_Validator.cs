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
    public partial class GalaxyInterfaceBoardSection_PanelLoadData
    {
        class GalaxyInterfaceBoardSection_PanelLoadDataValidator : AbstractValidator<GalaxyInterfaceBoardSection_PanelLoadData>
        {
            public GalaxyInterfaceBoardSection_PanelLoadDataValidator()
            {
                //RuleFor(obj => obj.PortalName).NotEmpty().Length(1, 65);
                //RuleFor(obj => obj.ClusterGroupId).Length(0, 16);
                //RuleFor(obj => (int)obj.ClusterNumber).InclusiveBetween(1, 254);
                //RuleFor(obj => (int)obj.AbaStartDigit).InclusiveBetween(1, 59);
                //RuleFor(obj => (int)obj.AbaStopDigit).InclusiveBetween(2, 60);
                //RuleFor(obj => (int)obj.AbaStartDigit).LessThan(obj => obj.AbaStopDigit);

                //RuleFor(obj => (int)obj.WiegandStartBit).InclusiveBetween(0, 254);
                //RuleFor(obj => (int)obj.WiegandStopBit).InclusiveBetween(1, 255);
                //RuleFor(obj => (int)obj.WiegandStartBit).LessThan(obj => obj.WiegandStopBit);

                //RuleFor(obj => (int)obj.CardaxStartBit).InclusiveBetween(0, 254);
                //RuleFor(obj => (int)obj.CardaxStopBit).InclusiveBetween(1, 255);
                //RuleFor(obj => (int)obj.CardaxStartBit).LessThan(obj => obj.CardaxStopBit);

                //RuleFor(obj => (int)obj.LockoutAfterInvalidAttempts).InclusiveBetween(0, 255);
                //RuleFor(obj => (int)obj.LockoutDurationSeconds).InclusiveBetween(0, 65535);
                //RuleFor(obj => (int)obj.AccessRuleOverrideTimeout).InclusiveBetween(0, 65535);
                //RuleFor(obj => (int)obj.UnlimitedCredentialTimeout).InclusiveBetween(0, 65535);
                //RuleFor(obj => obj.TimeZoneId).Length(0, 65);

                //RuleFor(obj => obj.ActivateCrisisIOGroupNumber).InclusiveBetween(0, 255);
                //RuleFor(obj => obj.ResetCrisisIOGroupNumber).InclusiveBetween(0, 255);

            }
        }

        protected override IValidator GetValidator()
        {
            return new GalaxyInterfaceBoardSection_PanelLoadDataValidator();
        }
    }
}

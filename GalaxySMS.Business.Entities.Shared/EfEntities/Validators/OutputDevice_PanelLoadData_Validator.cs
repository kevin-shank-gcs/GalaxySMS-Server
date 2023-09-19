using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using GalaxySMS.Common.Constants;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
    public partial class OutputDevice_PanelLoadData
    {
        class OutputDevice_PanelLoadDataValidator : AbstractValidator<OutputDevice_PanelLoadData>
        {
            public OutputDevice_PanelLoadDataValidator()
            {
                //RuleFor(obj => obj.InputName).NotEmpty().Length(1, 65);
                //RuleFor(obj => obj.ClusterGroupId).Length(0, 16);
                //RuleFor(obj => (int)obj.ModuleNumber).InclusiveBetween(GalaxyRemoteRelayModuleLimits., GalaxyRemoteRelayModuleLimits.HighestDefinableModuleNumber);
                RuleFor(obj => (int)obj.NodeNumber).InclusiveBetween(GalaxyRemoteRelayModuleLimits.LowestDefinableRelayNumber, GalaxyRemoteRelayModuleLimits.HighestDefinableRelayNumber);
                RuleFor(obj => (int)obj.TimeoutDuration).InclusiveBetween(0, ushort.MaxValue);
                RuleFor(obj => (int)obj.Limit).InclusiveBetween(0, ushort.MaxValue);
                //RuleFor(obj => (int)obj.MainIOGroupNumber).InclusiveBetween(InputOutputGroupLimits.None, InputOutputGroupLimits.HighestNumber);
                //RuleFor(obj => (int)obj.MainIOGroupOffset).InclusiveBetween(InputOutputGroupOffsetLimits.None, InputOutputGroupOffsetLimits.Maximum);
                //RuleFor(obj => (int)obj.ArmingIOGroupNumber1).InclusiveBetween(InputOutputGroupLimits.None, InputOutputGroupLimits.HighestNumber);
                //RuleFor(obj => (int)obj.ArmingIOGroupNumber2).InclusiveBetween(InputOutputGroupLimits.None, InputOutputGroupLimits.HighestNumber);
                //RuleFor(obj => (int)obj.ArmingIOGroupNumber3).InclusiveBetween(InputOutputGroupLimits.None, InputOutputGroupLimits.HighestNumber);
                //RuleFor(obj => (int)obj.ArmingIOGroupNumber4).InclusiveBetween(InputOutputGroupLimits.None, InputOutputGroupLimits.HighestNumber);
                //RuleFor(obj => (int)obj.NormalChangeThreshold).InclusiveBetween(byte.MinValue, byte.MaxValue);
                //RuleFor(obj => (int)obj.TroubleShortThreshold).InclusiveBetween(byte.MinValue, byte.MaxValue);
                //RuleFor(obj => (int)obj.TroubleOpenThreshold).InclusiveBetween(byte.MinValue, byte.MaxValue);

                //RuleFor(obj => (int)obj.AlternateNormalChangeThreshold).InclusiveBetween(byte.MinValue, byte.MaxValue);
                //RuleFor(obj => (int)obj.AlternateTroubleOpenThreshold).InclusiveBetween(byte.MinValue, byte.MaxValue);
                //RuleFor(obj => (int)obj.AlternateTroubleShortThreshold).InclusiveBetween(byte.MinValue, byte.MaxValue);

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
            return new OutputDevice_PanelLoadDataValidator();
        }
    }
}

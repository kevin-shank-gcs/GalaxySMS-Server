using GalaxySMS.Api.Models.RequestModels;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using ApiEntities = GalaxySMS.Business.Entities.Api.NetCore;

namespace GalaxySMS.Api.Support
{
    public class SaveClusterExamples : IExamplesProvider<SaveParams<ClusterReq>>
    {
        SaveParams<ClusterReq> IExamplesProvider<SaveParams<ClusterReq>>.GetExamples()
        {
            return new SaveParams<ClusterReq>()
            {
                Data = new ClusterReq()
                {
                    ClusterUid = Guid.Empty,
                    //ClusterTypeUid = GalaxySMS.Common.Constants.GalaxyClusterTypeIds.GalaxyClusterType_Only635,
                    ClusterType = Common.Enums.ClusterType.Only635,
                    ClusterNumber = 0,
                    ClusterName = "Sample Cluster",
                    SiteUid = Guid.Empty,
                    //CredentialDataLengthUid = GalaxySMS.Common.Constants.CredentialDataLengthIds.Standard48Bits,
                    CredentialDataLength = Common.Enums.CredentialDataSize.Standard48Bits,
                    //TimeScheduleTypeUid = GalaxySMS.Common.Constants.TimeScheduleTypeIds.TimeScheduleType_GalaxyMinuteInterval,
                    TimeScheduleType = Common.Enums.TimeScheduleType.GalaxyOneMinuteInterval,
                    IsActive = true,
                    AbaStartDigit = 1,
                    AbaStopDigit = 60,
                    AbaFoldOption = true,
                    WiegandStartBit = 0,
                    WiegandStopBit = 255,
                    CardaxStartBit = 34,
                    CardaxStopBit = 59,
                    TimeZoneId = TimeZoneInfo.Local.Id,
                    //AccessPortalLockedLedBehaviorModeUid =GalaxySMS.Common.Constants.ClusterLedBehaviorIds.SteadyLow,
                    //AccessPortalUnlockedLedBehaviorModeUid = GalaxySMS.Common.Constants.ClusterLedBehaviorIds.Strobe,
                    AccessPortalLockedLedBehaviorMode = GalaxySMS.Common.Enums.ClusterLedBehavior.SteadyLow,
                    AccessPortalUnlockedLedBehaviorMode = GalaxySMS.Common.Enums.ClusterLedBehavior.Strobe,
                    AccessPortalTypeUid = GalaxySMS.Common.Constants.AccessPortalTypeIds.AccessPortalType_StandardEntryPoint_StandardDataClock,
                    //EntityIds = new List<Guid>(),
                    RoleIds = new List<Guid>(),
                    //MappedEntitiesPermissionLevels = new List<EntityIdEntityMapPermissionLevelReq>(),
                }
            };
        }
    }

    public class SaveApiEntitiesClusterExamples : IExamplesProvider<SaveParams<ClusterPutReq>>
    {
        SaveParams<ClusterPutReq> IExamplesProvider<SaveParams<ClusterPutReq>>.GetExamples()
        {
            return new SaveParams<ClusterPutReq>()
            {
                Data = new ClusterPutReq()
                {
                    ClusterUid = Guid.Empty,
                    ClusterTypeUid = GalaxySMS.Common.Constants.GalaxyClusterTypeIds.GalaxyClusterType_Only635,
                    ClusterNumber = 0,
                    ClusterName = "Sample Cluster",
                    SiteUid = Guid.Empty,
                    CredentialDataLengthUid = GalaxySMS.Common.Constants.CredentialDataLengthIds.Standard48Bits,
                    TimeScheduleTypeUid = GalaxySMS.Common.Constants.TimeScheduleTypeIds.TimeScheduleType_GalaxyMinuteInterval,
                    IsActive = true,
                    AbaStartDigit = 1,
                    AbaStopDigit = 60,
                    AbaFoldOption = true,
                    WiegandStartBit = 0,
                    WiegandStopBit = 255,
                    CardaxStartBit = 34,
                    CardaxStopBit = 59,
                    TimeZoneId = TimeZoneInfo.Local.Id,
                    AccessPortalLockedLedBehaviorModeUid = GalaxySMS.Common.Constants.ClusterLedBehaviorIds.SteadyLow,
                    AccessPortalUnlockedLedBehaviorModeUid = GalaxySMS.Common.Constants.ClusterLedBehaviorIds.Strobe,
                    //EntityIds = new List<Guid>(),
                    RoleIds = new List<Guid>(),
                    //MappedEntitiesPermissionLevels = new List<ApiEntities.EntityIdEntityMapPermissionLevel>(),
                }

            };
        }
    }

    public class ClusterCommandExamples : IExamplesProvider<CommandParams<GalaxyCpuCommandActionReq>>
    {
        CommandParams<GalaxyCpuCommandActionReq> IExamplesProvider<CommandParams<GalaxyCpuCommandActionReq>>.GetExamples()
        {
            var p = new CommandParams<GalaxyCpuCommandActionReq>()
            {
                Data = new GalaxyCpuCommandActionReq()
                {
                    CommandAction = Common.Enums.GalaxyCpuCommandActionCode.RequestControllerInformation,
                }
            };
            return p;
        }
    }

}
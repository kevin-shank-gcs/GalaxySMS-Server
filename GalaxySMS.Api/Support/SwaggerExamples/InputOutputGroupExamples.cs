using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Api.Models.RequestModels;
using Swashbuckle.AspNetCore.Filters;
using ApiEntities = GalaxySMS.Business.Entities.Api.NetCore;

namespace GalaxySMS.Api.Support
{
    public class SaveInputOutputGroupExamples : IExamplesProvider<SaveParams<InputOutputGroupReq>>
    {
        SaveParams<InputOutputGroupReq> IExamplesProvider<SaveParams<InputOutputGroupReq>>.GetExamples()
        {
            return new SaveParams<InputOutputGroupReq>()
            {
                Data = new InputOutputGroupReq()
                {
                    InputOutputGroupUid = Guid.Empty,
                    ClusterUid = Globals.Instance.ClusterUid,
                    TimeScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Always,
                    Display = $"Sample Input-Output Group X",
                    Description = "Sample Description",
                    LocalIOGroup = false,
                    IOGroupNumber = (int)GalaxySMS.Common.Enums.InputOutputGroupNumber.None,
                    EntityIds = new List<Guid>(),
                    MappedEntitiesPermissionLevels = new List<EntityIdEntityMapPermissionLevelReq>(),
                }
            };
        }
    }

    public class SaveApiEntitiesInputOutputGroupExamples : IExamplesProvider<SaveParams<InputOutputGroupPutReq>>
    {
        SaveParams<InputOutputGroupPutReq> IExamplesProvider<SaveParams<InputOutputGroupPutReq>>.GetExamples()
        {
            return new SaveParams<InputOutputGroupPutReq>()
            {
                Data = new InputOutputGroupPutReq()
                {
                    InputOutputGroupUid = Guid.Empty,
                    ClusterUid = Guid.Empty,
                    TimeScheduleUid = GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Always,
                    Display = $"Sample Input-Output Group X",
                    Description = "Sample Description",
                    LocalIOGroup = false,
                    IOGroupNumber = 0,
                    EntityIds = new List<Guid>(),
                    MappedEntitiesPermissionLevels = new List<EntityIdEntityMapPermissionLevelReq>(),
                    ConcurrencyValue = 0,
                }

            };
        }
    }

    public class InputOutputGroupCommandExamples : IExamplesProvider<CommandParams<InputOutputGroupCommandActionReq>>
    {
        CommandParams<InputOutputGroupCommandActionReq> IExamplesProvider<CommandParams<InputOutputGroupCommandActionReq>>.GetExamples()
        {
            var p = new CommandParams<InputOutputGroupCommandActionReq>()
            {
                Data = new InputOutputGroupCommandActionReq()
                {
                    CommandAction = Common.Enums.InputOutputGroupCommandActionCode.Arm,
                    InputOutputGroupUid = Guid.Empty
                }
            };
            return p;
        }
    }

}
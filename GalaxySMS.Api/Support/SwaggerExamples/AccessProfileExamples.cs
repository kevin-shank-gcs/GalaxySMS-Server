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
    public class SaveAccessProfileExamples : IExamplesProvider<SaveParams<AccessProfileReq>>
    {
        SaveParams<AccessProfileReq> IExamplesProvider<SaveParams<AccessProfileReq>>.GetExamples()
        {
            var saveParams = new SaveParams<AccessProfileReq>()
            {
                Data = new AccessProfileReq()
                {
                    AccessProfileUid = Guid.Empty,
                    AccessProfileName = "Sample Access Profile X",
                    Comments = "Sample comments",
                    AccessProfileClusters = new List<AccessProfileClusterReq>(),
                    //EntityIds = new List<Guid>(),
                    //MappedEntitiesPermissionLevels = new List<EntityIdEntityMapPermissionLevelReq>(),
                }
            };
            var apcluster = new AccessProfileClusterReq()
            {
                ClusterUid = Guid.Empty,
                AccessProfileAccessGroups = new List<AccessProfileAccessGroupReq>(),
                AccessProfileInputOutputGroups = new List<AccessProfileInputOutputGroupReq>(),
            };

            for (short orderNumber = 1; orderNumber <= 4; orderNumber++)
            {
                apcluster.AccessProfileAccessGroups.Add(new AccessProfileAccessGroupReq()
                {
                    AccessGroupUid = Guid.Empty,
                    OrderNumber = orderNumber,
                });

                apcluster.AccessProfileInputOutputGroups.Add(new AccessProfileInputOutputGroupReq()
                {
                    InputOutputGroupUid = Guid.Empty,
                    OrderNumber = orderNumber,
                });

            }
            saveParams.Data.AccessProfileClusters.Add(apcluster);

            return saveParams;
        }
    }

    public class SaveApiEntitiesAccessProfileExamples : IExamplesProvider<SaveParams<AccessProfilePutReq>>
    {
        SaveParams<AccessProfilePutReq> IExamplesProvider<SaveParams<AccessProfilePutReq>>.GetExamples()
        {
            var saveParams = new SaveParams<AccessProfilePutReq>()
            {
                Data = new AccessProfilePutReq()
                {
                    AccessProfileUid = Guid.Empty,
                    AccessProfileName = "Sample Access Profile X",
                    Comments = "Sample comments",
                    AccessProfileClusters = new List<AccessProfileClusterPutReq>(),
                    //EntityIds = new List<Guid>(),
                    //MappedEntitiesPermissionLevels = new List<EntityIdEntityMapPermissionLevelReq>(),
                    ConcurrencyValue = 0,
                }
            };

            var apcluster = new AccessProfileClusterPutReq()
            {
                ClusterUid = Guid.Empty,
                AccessProfileAccessGroups = new List<AccessProfileAccessGroupPutReq>(),
                AccessProfileInputOutputGroups = new List<AccessProfileInputOutputGroupPutReq>(),
                ConcurrencyValue = 0,
            };

            for (short orderNumber = 1; orderNumber <= 4; orderNumber++)
            {
                apcluster.AccessProfileAccessGroups.Add(new AccessProfileAccessGroupPutReq()
                {
                    AccessGroupUid = Guid.Empty,
                    OrderNumber = orderNumber,
                    ConcurrencyValue = 0,
                });

                apcluster.AccessProfileInputOutputGroups.Add(new AccessProfileInputOutputGroupPutReq()
                {
                    InputOutputGroupUid = Guid.Empty,
                    OrderNumber = orderNumber,
                    ConcurrencyValue = 0,
                });

            }
            saveParams.Data.AccessProfileClusters.Add(apcluster);
            return saveParams;
        }
    }

}
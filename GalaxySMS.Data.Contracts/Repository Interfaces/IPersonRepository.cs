using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IPersonRepository : IDataRepository<Person>, IHasGetEntityId
    {
        IEnumerable<Person> GetAllPersonsForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<PersonSummary> SearchForPersonSummary(IApplicationUserSessionDataHeader sessionData, PersonSummarySearchParameters getParameters);
        ArrayResponse<PersonSummary> SearchForPersonSummaryPaged(IApplicationUserSessionDataHeader sessionData, PersonSummarySearchParameters getParameters);

        ArrayResponse<PersonSummary> SearchForPersonSummaryPagedEx(IApplicationUserSessionDataHeader sessionData, PersonSummarySearchParameters getParameters);
        IEnumerable<Credential_PanelLoadData> GetCredentialPanelLoadDataForPerson(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto<Credential_PanelLoadData> parameters);
        IEnumerable<Credential_PanelLoadData> GetCredentialPanelLoadDataForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto<Credential_PanelLoadData> parameters);
        IEnumerable<Credential_PanelLoadData> GetCredentialPanelLoadData(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<PersonalAccessGroup_PanelLoadData> GetPersonalAccessGroupPanelLoadData(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto<PersonalAccessGroup_PanelLoadData> parameters);
        IEnumerable<Credential_PanelLoadData> GetModifiedCredentialPanelLoadDataForCpu(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        Person SyncPersonWithAccessProfile(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        string GetPersonIdForPerson(Guid personUid);
        string GenerateUniquePersonId(Guid entityId, IApplicationUserSessionDataHeader sessionData);
        IEnumerable<PersonInfoWithMissingPhotoUrl> GetAllPersonsWithMissingPhotoUrl(Guid entityId);
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Business.Entities;
using GalaxySMS.Data.Contracts;
using GCS.Core.Common.Contracts;

namespace GalaxySMS.Data.NetCore.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IGalaxySMSDbContext _dbContext;

        public PersonRepository(IGalaxySMSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Person Add(Person entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            throw new NotImplementedException();
        }

        public Person Update(Person entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams)
        {
            throw new NotImplementedException();
        }

        public int Remove(Person entity, IApplicationUserSessionDataHeader sessionData)
        {
            throw new NotImplementedException();
        }

        public int Remove(int id, IApplicationUserSessionDataHeader sessionData)
        {
            throw new NotImplementedException();
        }

        public int Remove(Guid id, IApplicationUserSessionDataHeader sessionData)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Person> Get(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Person> GetAll(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            throw new NotImplementedException();
        }

        public Person Get(int id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            throw new NotImplementedException();
        }

        public Person Get(Guid id, IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters)
        {
            throw new NotImplementedException();
        }

        public bool IsReferenced(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool IsReferenced(int id)
        {
            throw new NotImplementedException();
        }

        public bool CanDelete(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool CanDelete(int id)
        {
            throw new NotImplementedException();
        }

        public bool IsUnique(Person entity)
        {
            throw new NotImplementedException();
        }

        public bool DoesExist(Guid id)
        {
            throw new NotImplementedException();
        }

        public bool DoesExist(int id)
        {
            throw new NotImplementedException();
        }

        public Guid GetEntityId(Guid uid)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Person> GetAllPersonsForEntity(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PersonSummary> SearchForPersonSummary(IApplicationUserSessionDataHeader sessionData,
            PersonSummarySearchParameters getParameters)
        {
            throw new NotImplementedException();
        }

        public ArrayResponse<PersonSummary> SearchForPersonSummaryPaged(IApplicationUserSessionDataHeader sessionData,
            PersonSummarySearchParameters getParameters)
        {
            throw new NotImplementedException();
        }

        public ArrayResponse<PersonSummary> AdvancedSearchForPersonSummaryPaged(IApplicationUserSessionDataHeader sessionData,
            PersonSummarySearchParameters getParameters)
        {
            throw new NotImplementedException();
        }

        public ArrayResponse<PersonSummary> SearchForPersonSummaryPagedEx(IApplicationUserSessionDataHeader sessionData,
            PersonSummarySearchParameters getParameters)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Credential_PanelLoadData> GetCredentialPanelLoadDataForPerson(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto<Credential_PanelLoadData> parameters)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Credential_PanelLoadData> GetCredentialPanelLoadDataForCluster(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto<Credential_PanelLoadData> parameters)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Credential_PanelLoadData> GetCredentialPanelLoadData(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto parameters)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PersonalAccessGroup_PanelLoadData> GetPersonalAccessGroupPanelLoadData(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto<PersonalAccessGroup_PanelLoadData> parameters)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Credential_PanelLoadData> GetModifiedCredentialPanelLoadDataForCpu(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto parameters)
        {
            throw new NotImplementedException();
        }

        public Person SyncPersonWithAccessProfile(IApplicationUserSessionDataHeader sessionData,
            IGetParametersWithPhoto getParameters)
        {
            throw new NotImplementedException();
        }

        public string GetPersonIdForPerson(Guid personUid)
        {
            throw new NotImplementedException();
        }

        public string GenerateUniquePersonId(Guid entityId, IApplicationUserSessionDataHeader sessionData)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PersonInfoWithMissingPhotoUrl> GetAllPersonsWithMissingPhotoUrl(Guid entityId)
        {
            throw new NotImplementedException();
        }
    }
}

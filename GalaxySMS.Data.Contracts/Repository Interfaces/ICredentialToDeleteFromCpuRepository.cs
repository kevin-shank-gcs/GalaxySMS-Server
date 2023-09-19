using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface ICredentialToDeleteFromCpuRepository : IDataRepository<CredentialToDeleteFromCpu>
    {
        void InsertEntity(CredentialToDeleteFromCpu entity);
        void SaveDeletedFromCpuDate(CredentialToDeleteFromCpu entity);
        IEnumerable<CredentialToDeleteFromCpu> GetAllThatNeedDeleted(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<CredentialToDeleteFromCpu> GetAllThatNeedDeletedForCpu(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);

    }
}

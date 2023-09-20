using System;
using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;

namespace GalaxySMS.Data.Contracts
{
    public interface ICredentialToLoadToCpuRepository : IDataInsertRepository<CredentialToLoadToCpu>
    {
        void SaveLastCredentialLoadedDate(CredentialToLoadToCpu entity);
        void SaveLastCredentialLoadedDate(Guid cpuUid, byte[] credentialData, DateTimeOffset lastLoadedDate);
        void SaveLastPersonalAccessGroupLoadedDate(CredentialToLoadToCpu entity);
    }
}

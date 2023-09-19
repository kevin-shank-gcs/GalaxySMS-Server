using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;

namespace GalaxySMS.Data.Contracts
{
    public interface IGcsApplicationAuditRepository : IDataRepository<gcsApplicationAudit>
    {
        gcsApplicationAudit CreateApplicationAuditInstance(IApplicationUserSessionDataHeader sessionData);
        void InsertEntity(gcsApplicationAudit entity, IApplicationUserSessionDataHeader sessionData);
    }
}

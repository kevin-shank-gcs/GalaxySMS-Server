using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using PDSA.DataLayer.DataClasses;

namespace GalaxySMS.Data.Contracts
{
    public interface IGcsBinaryResourceRepository : IDataRepository<gcsBinaryResource>
    {
        IHasBinaryResource SaveBinaryResource(IHasBinaryResource entity, IApplicationUserSessionDataHeader sessionData,
            PDSATransaction transaction, ISaveParameters saveParams);

        gcsBinaryResource SaveBinaryResource(gcsBinaryResource resource, IApplicationUserSessionDataHeader sessionData, PDSATransaction transaction, ISaveParameters saveParams);
    }
}

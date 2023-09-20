using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;

namespace GalaxySMS.Data.Contracts
{
    public interface IGcsBinaryResourceRepository : IDataRepository<gcsBinaryResource>
    {
        IHasBinaryResource SaveBinaryResource(IHasBinaryResource entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams);

        gcsBinaryResource SaveBinaryResource(gcsBinaryResource resource, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams);
    }
}

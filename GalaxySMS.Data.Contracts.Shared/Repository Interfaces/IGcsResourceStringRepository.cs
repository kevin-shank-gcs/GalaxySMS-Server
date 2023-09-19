using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;

namespace GalaxySMS.Data.Contracts
{
    public interface IGcsResourceStringRepository : IDataRepository<gcsResourceString>
    {
        gcsResourceString GetByResourceName(string resourceName, IApplicationUserSessionDataHeader sessionData);

        IHasDisplayResourceKey SaveDisplayResource(IHasDisplayResourceKey entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams);

        IHasDescriptionResourceKey SaveDescriptionResource(IHasDescriptionResourceKey entity, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams);

        gcsResourceString SaveResourceString(gcsResourceString resource, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams);
    }
}

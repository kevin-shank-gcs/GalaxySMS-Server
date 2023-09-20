using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IAccessPortalCommandChoiceRepository : IDataRepository<AccessPortalCommandChoice>
    {
        IEnumerable<AccessPortalCommandChoice> GetAllForCommand(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);

    }
}


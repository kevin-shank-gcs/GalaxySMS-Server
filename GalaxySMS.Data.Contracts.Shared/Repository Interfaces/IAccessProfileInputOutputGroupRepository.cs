using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IAccessProfileInputOutputGroupRepository : IDataRepository<AccessProfileInputOutputGroup>
    {
        IEnumerable<AccessProfileInputOutputGroup> GetAllForAccessProfile(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<AccessProfileInputOutputGroup> GetAllForAccessProfileCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<AccessProfileInputOutputGroup> GetAllForCluster(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        IEnumerable<AccessProfileInputOutputGroup> GetAllForInputOutputGroup(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}


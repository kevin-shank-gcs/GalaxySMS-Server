using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IAssaAccessPointRepository : IDataRepository<AssaAccessPoint>, IHasGetEntityId
    {
        IEnumerable<AssaAccessPoint> GetAllAssaAccessPointsForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<AssaAccessPoint> GetAllAssaAccessPointsForSite(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<AssaAccessPoint> GetAllAssaAccessPointsForDsr(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        AssaAccessPoint GetAssaAccessPointsByAssaUniqueId(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        AssaAccessPoint GetAssaAccessPointsBySerialNumber(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
    }
}


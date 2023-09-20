using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface ITimeZoneRepository : IDataRepository<Business.Entities.TimeZone>
    {
        //IEnumerable<Business.Entities.TimeZone> ImportTimeZones(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        Business.Entities.TimeZone GetById(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        bool DoesTimeZoneIdExist(string id);
    }
}


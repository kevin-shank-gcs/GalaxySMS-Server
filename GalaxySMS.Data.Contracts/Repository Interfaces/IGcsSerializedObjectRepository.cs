using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IGcsSerializedObjectRepository : IDataRepository<gcsSerializedObject>
    {
        gcsSerializedObject GetForApplicationAndKey(Guid applicationId, string key, IApplicationUserSessionDataHeader sessionData);
    }
}

using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IGcsUserOldPasswordRepository : IDataRepository<gcsUserOldPassword>
    {
        IEnumerable<gcsUserOldPassword> GetByUserId(Guid userId, int howMany);
    }
}

using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IGcsSystemRepository : IDataRepository<gcsSystem>
    {
        gcsSystem EnsureTrialLicenseExists(gcsSystem entity);
    }
}

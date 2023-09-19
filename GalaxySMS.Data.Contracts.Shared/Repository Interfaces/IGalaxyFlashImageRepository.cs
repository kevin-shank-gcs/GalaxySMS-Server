using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IGalaxyFlashImageRepository : IDataRepository<GalaxyFlashImage>
    {
        IEnumerable<GalaxyFlashImage> GetFlashImagesByGalaxyCpuModelUid(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<GalaxyFlashImage> GetFlashImagesByGalaxyCpuModelTypeCode(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
    }
}


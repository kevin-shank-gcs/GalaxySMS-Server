using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IPersonPhotoScaledRepository : IDataRepository<PersonPhotoScaled>
    {
        IEnumerable<PersonPhotoScaled> GetAllForPersonPhoto(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        PersonPhotoScaled UpdatePublicUrl(IApplicationUserSessionDataHeader sessionData, PersonPhotoScaled photo);

    }
}


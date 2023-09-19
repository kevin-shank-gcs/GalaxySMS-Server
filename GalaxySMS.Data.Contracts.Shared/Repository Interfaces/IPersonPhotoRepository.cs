using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IPersonPhotoRepository : IDataRepository<PersonPhoto>, IHasGetEntityId
    {
        IEnumerable<PersonPhoto> GetAllPersonPhotosForPerson(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<PersonPhoto> GetAllPersonPhotosForTag(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<PersonPhoto> GetAllPersonPhotosForPersonAndTag(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        PersonPhoto GetMostRecentPersonPhotoForPerson(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        PersonPhoto GetDefaultPersonPhotoForPerson(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<PersonPhoto> GetAllPersonPhotoTagsForPerson(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        PersonPhoto UpdatePublicUrl(IApplicationUserSessionDataHeader sessionData, PersonPhoto photo);
        PersonPhoto UpdateIsDefault(IApplicationUserSessionDataHeader sessionData, PersonPhoto photo);

    }
}


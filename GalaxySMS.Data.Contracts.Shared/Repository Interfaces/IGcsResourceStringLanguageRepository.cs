using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IGcsResourceStringLanguageRepository : IDataRepository<gcsResourceStringLanguage>
    {
        IEnumerable<gcsResourceStringLanguage> GetAllForLanguageId(Guid languageId, IApplicationUserSessionDataHeader sessionData);
        IEnumerable<gcsResourceStringLanguage> GetByResourceIdLanguageId(Guid resourceId, Guid languageId, IApplicationUserSessionDataHeader sessionData);
        IEnumerable<gcsResourceStringLanguage> GetAllForCultureName(string cultureName, IApplicationUserSessionDataHeader sessionData);
        gcsResourceStringLanguage SaveResourceStringLanguage(gcsResourceStringLanguage resource, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams);

    }
}

using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IGcsApplicationSettingRepository : IDataRepository<gcsApplicationSetting>
    {
        int DeleteByUniqueKey(Guid applicationId, string category, string settingKey);
        gcsApplicationSetting GetByUniqueKey(Guid applicationId, string category, string settingKey);
        IEnumerable<gcsApplicationSetting> GetAllForApplication(Guid applicationId);
        IEnumerable<gcsApplicationSetting> GetAllForApplicationCategory(Guid applicationId, string category);
    }
}

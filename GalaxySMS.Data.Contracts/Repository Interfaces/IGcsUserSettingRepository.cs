using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using PDSA.DataLayer.DataClasses;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IGcsUserSettingRepository : IDataRepository<gcsUserSetting>
    {
        int DeleteByUniqueKey(Guid userId, Guid? applicationId, string category, string settingKey, IApplicationUserSessionDataHeader sessionData, PDSATransaction transaction);
        gcsUserSetting GetByUniqueKey(Guid userId, Guid? applicationId, string category, string settingKey);
        IEnumerable<gcsUserSetting> GetAllForUser(Guid userId);
        IEnumerable<gcsUserSetting> GetAllForUserApplication(Guid userId, Guid? applicationId);
        IEnumerable<gcsUserSetting> GetAllForUserApplicationCategory(Guid userId, Guid? applicationId, string category);
        IEnumerable<gcsUserSetting> GetAllForApplication(Guid? applicationId);
    }
}

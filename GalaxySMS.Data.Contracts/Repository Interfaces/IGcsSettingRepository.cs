using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using PDSA.DataLayer.DataClasses;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IGcsSettingRepository : IDataRepository<gcsSetting>
    {
        int DeleteByUniqueKey(Guid entityId, string settingGroup, string settingSubGroup, string settingKey, IApplicationUserSessionDataHeader sessionData, PDSATransaction transaction);
        gcsSetting GetByUniqueKey(Guid entityId, string settingGroup, string settingSubGroup, string settingKey);
        int GetByUniqueKey(Guid entityId, string settingGroup, string settingSubGroup, string settingKey, int defaultValue, bool bCreateIfNotFound, IApplicationUserSessionDataHeader sessionData);
        string GetByUniqueKey(Guid entityId, string settingGroup, string settingSubGroup, string settingKey, string defaultValue, bool bCreateIfNotFound, IApplicationUserSessionDataHeader sessionData);
        bool GetByUniqueKey(Guid entityId, string settingGroup, string settingSubGroup, string settingKey, bool defaultValue, bool bCreateIfNotFound, IApplicationUserSessionDataHeader sessionData);
        Guid GetByUniqueKey(Guid entityId, string settingGroup, string settingSubGroup, string settingKey, Guid defaultValue, bool bCreateIfNotFound, IApplicationUserSessionDataHeader sessionData);
        IEnumerable<gcsSetting> GetAllForEntity(Guid entityId);
        IEnumerable<gcsSetting> GetSettingsForEntityAndGroup(Guid entityId, string group);
        IEnumerable<gcsSetting> GetSettingsForEntityGroupAndSubGroup(Guid entityId, string group, string subGroup);

        gcsSetting Save(Guid entityId, string settingGroup, string settingSubGroup, string settingKey, string value, IApplicationUserSessionDataHeader sessionData, ISaveParameters saveParams);

    }
}

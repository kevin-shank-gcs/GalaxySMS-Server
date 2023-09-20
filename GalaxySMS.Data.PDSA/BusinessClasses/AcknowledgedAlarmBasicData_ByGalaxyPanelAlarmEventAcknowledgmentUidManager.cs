using System;
using System.Data;
using GalaxySMS.Business.Entities;
using GalaxySMS.Common.Enums;
using PDSA;
using PDSA.Common;
using PDSA.DataLayer;
using PDSA.DataLayer.DataClasses;

using GalaxySMS.EntityLayer;
using GalaxySMS.ValidationLayer;
using GalaxySMS.DataLayer;

namespace GalaxySMS.BusinessLayer
{
    /// <summary>
    /// This class is used to call the stored procedure AcknowledgedAlarmBasicData_ByGalaxyPanelAlarmEventAcknowledgmentUidPDSA
    /// This class is generated using the Haystack Code Generator for .NET Utility.
    /// You may add additional methods to this class.
    /// </summary>
    public partial class AcknowledgedAlarmBasicData_ByGalaxyPanelAlarmEventAcknowledgmentUidPDSAManager
    {
        #region Your Custom Properties and Methods
        public AcknowledgedAlarmBasicData ConvertPDSAEntity(AcknowledgedAlarmBasicData_ByGalaxyPanelAlarmEventAcknowledgmentUidPDSA pdsaEntity)
        {
            var convertedEntity = new AcknowledgedAlarmBasicData
            {
                //SimpleMapper.PropertyMap(pdsaEntity, convertedEntity);
                ActivityEventUid = pdsaEntity.ActivityEventUid,
                DeviceEntityId = pdsaEntity.DeviceEntityId,
                DeviceUid = pdsaEntity.DeviceUid,
                AckedDateTime = pdsaEntity.AckedDateTime,
                //AccessPortalAlarmEventAcknowledgmentUid = pdsaEntity.AccessPortalAlarmEventAcknowledgmentUid,
                //GalaxyPanelAlarmEventAcknowledgmentUid = pdsaEntity.GalaxyPanelAlarmEventAcknowledgmentUid,
                //InputDeviceAlarmEventAcknowledgmentUid = pdsaEntity.InputDeviceAlarmEventAcknowledgmentUid,
                AckedByUserDisplayName = pdsaEntity.AckedByUserDisplayName,
                AckedByUserId = pdsaEntity.AckedByUserId,
                AckedUpdatedDateTime = pdsaEntity.AckedUpdatedDateTime,
                Response = pdsaEntity.Response
            };


            if (pdsaEntity.AccessPortalAlarmEventAcknowledgmentUid != Guid.Empty)
            {
                convertedEntity.AlarmEventAcknowledgmentUid = pdsaEntity.AccessPortalAlarmEventAcknowledgmentUid;
                convertedEntity.ActivityEventCategory = PanelActivityEventCategory.Door;
            }
            else if (pdsaEntity.GalaxyPanelAlarmEventAcknowledgmentUid != Guid.Empty)
            {
                convertedEntity.AlarmEventAcknowledgmentUid = pdsaEntity.GalaxyPanelAlarmEventAcknowledgmentUid;
                convertedEntity.ActivityEventCategory = PanelActivityEventCategory.Panel;
            }
            else if (pdsaEntity.InputDeviceAlarmEventAcknowledgmentUid != Guid.Empty)
            {
                convertedEntity.AlarmEventAcknowledgmentUid = pdsaEntity.InputDeviceAlarmEventAcknowledgmentUid;
                convertedEntity.ActivityEventCategory = PanelActivityEventCategory.Input;
            }

            return convertedEntity;
        }
        #endregion
    }
}

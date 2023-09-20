using System;
using System.Data;

using PDSA;
using PDSA.Common;
using PDSA.DataLayer;
using PDSA.DataLayer.DataClasses;

using GalaxySMS.EntityLayer;
using GalaxySMS.ValidationLayer;
using GalaxySMS.DataLayer;
using GalaxySMS.Business.Entities;

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
                AccessPortalAlarmEventAcknowledgmentUid = pdsaEntity.AccessPortalAlarmEventAcknowledgmentUid,
                GalaxyPanelAlarmEventAcknowledgmentUid = pdsaEntity.GalaxyPanelAlarmEventAcknowledgmentUid,
                InputDeviceAlarmEventAcknowledgmentUid = pdsaEntity.InputDeviceAlarmEventAcknowledgmentUid,
                AckedByUserDisplayName = pdsaEntity.AckedByUserDisplayName,
                AckedByUserId = pdsaEntity.AckedByUserId,
                AckedUpdatedDateTime = pdsaEntity.AckedUpdatedDateTime,
                Response = pdsaEntity.Response
            };

            return convertedEntity;
        }
        #endregion
    }
}

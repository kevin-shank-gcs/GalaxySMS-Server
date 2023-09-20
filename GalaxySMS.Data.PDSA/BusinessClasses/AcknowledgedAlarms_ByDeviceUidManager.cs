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
using GCS.Core.Common.Extensions;

namespace GalaxySMS.BusinessLayer
{
  /// <summary>
  /// This class is used to call the stored procedure AcknowledgedAlarms_ByDeviceUidPDSA
  /// This class is generated using the Haystack Code Generator for .NET Utility.
  /// You may add additional methods to this class.
  /// </summary>
  public partial class AcknowledgedAlarms_ByDeviceUidPDSAManager
  {
    #region Your Custom Properties and Methods
           public AcknowledgedAlarm ConvertPDSAEntity(AcknowledgedAlarms_ByDeviceUidPDSA pdsaEntity)
        {
            var convertedEntity = new AcknowledgedAlarm
            {
                //SimpleMapper.PropertyMap(pdsaEntity, convertedEntity);
                ActivityEventUid = pdsaEntity.ActivityEventUid,
                ClusterGroupId = pdsaEntity.ClusterGroupId,
                ClusterNumber = pdsaEntity.ClusterNumber,
                PanelNumber = pdsaEntity.PanelNumber,
                CpuId = pdsaEntity.CpuId,
                BoardNumber = pdsaEntity.BoardNumber,
                SectionNumber = pdsaEntity.SectionNumber,
                ModuleNumber = pdsaEntity.ModuleNumber,
                NodeNumber = pdsaEntity.NodeNumber,
                CpuModel = pdsaEntity.CpuModel,
                DateTimeOffset = pdsaEntity.DateTime_x,
                BufferIndex = pdsaEntity.BufferIndex,
                PanelActivityType = EnumExtensions.GetOne<PanelActivityEventCode>(pdsaEntity.PanelActivityType),
                InputOutputGroupNumber = pdsaEntity.InputOutputGroupNumber,
                MultiFactorMode = AccessPortalMultiFactorModeCode.SingleFactor,
                DeviceDescription = pdsaEntity.DeviceDescription,
                EventDescription = pdsaEntity.EventDescription,
                DeviceEntityId = pdsaEntity.DeviceEntityId,
                DeviceUid = pdsaEntity.DeviceUid,
                CpuUid = pdsaEntity.CpuUid,
                ClusterName = pdsaEntity.ClusterName,
                IsAlarmEvent = pdsaEntity.IsAlarmEvent,
                AlarmPriority = pdsaEntity.AlarmPriority,
                Instructions = pdsaEntity.Instructions,
                InstructionsNoteUid = pdsaEntity.InstructionsNoteUid,
                AudioBinaryResourceUid = pdsaEntity.AudioBinaryResourceUid,
                RawData = null,
                Color = pdsaEntity.Color,
                PersonUid = pdsaEntity.PersonUid,
                CredentialUid = pdsaEntity.CredentialUid,
                PersonDescription = pdsaEntity.PersonDescription,
                CredentialDescription = pdsaEntity.CredentialDescription,
                Trace = pdsaEntity.Trace,
            };
            return convertedEntity;
        }
 
    #endregion
  }
}

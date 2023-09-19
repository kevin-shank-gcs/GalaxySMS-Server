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
using GCS.Core.Common.Utils;
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.BusinessLayer
{
  /// <summary>
  /// This class is used to call the stored procedure UnacknowledgedAlarms_ByDeviceEntityIdPDSA
  /// This class is generated using the Haystack Code Generator for .NET Utility.
  /// You may add additional methods to this class.
  /// </summary>
  public partial class UnacknowledgedAlarms_ByDeviceEntityIdPDSAManager
  {
    #region Your Custom Properties and Methods
    public PanelActivityLogMessage ConvertPDSAEntity(UnacknowledgedAlarms_ByDeviceEntityIdPDSA pdsaEntity)
    {
        var convertedEntity = new PanelActivityLogMessage
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
            CpuModel = CpuModel.Unknown,//EnumExtensions.GetOne<CpuModel>(pdsaEntity.CpuModel);
            DateTimeOffset = pdsaEntity.DateTime_x,
            BufferIndex = (uint)pdsaEntity.BufferIndex,
            PanelActivityType = EnumExtensions.GetOne<PanelActivityEventCode>(pdsaEntity.PanelActivityType),
            InputOutputGroupNumber = 0,
            InputOutputGroupName = string.Empty,
            InputOutputGroupUid = Guid.Empty,
            MultiFactorMode = AccessPortalMultiFactorModeCode.SingleFactor,
            DeviceDescription = pdsaEntity.DeviceDescription,
            EventDescription = pdsaEntity.EventDescription,
            DeviceEntityId = pdsaEntity.DeviceEntityId,
            DeviceUid = pdsaEntity.DeviceUid,
            CpuUid = pdsaEntity.CpuUid,
            ClusterName = pdsaEntity.ClusterName,
            IsAlarmEvent = true,
            AlarmPriority = pdsaEntity.AlarmPriority,
            Instructions = pdsaEntity.Instructions,
            InstructionsNoteUid = pdsaEntity.InstructionsNoteUid,
            AudioBinaryResourceUid = pdsaEntity.AudioBinaryResourceUid,
            RawData = null,
            Color = pdsaEntity.Color
        };

        return convertedEntity;
    }    
    #endregion
  }
}

using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the PanelDataPacketLog_InsertPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class PanelDataPacketLog_InsertPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private PanelDataPacketLog_InsertPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new PanelDataPacketLog_InsertPDSA Entity
    {
      get { return _Entity; }
      set
      {
        _Entity = value;
        base.Entity = value;
      }
    }
    #endregion
    
    #region Clone Entity Class
    /// <summary>
    /// Clones the current PanelDataPacketLog_InsertPDSA
    /// </summary>
    /// <returns>A cloned PanelDataPacketLog_InsertPDSA object</returns>
    public PanelDataPacketLog_InsertPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in PanelDataPacketLog_InsertPDSA
    /// </summary>
    /// <param name="entityToClone">The PanelDataPacketLog_InsertPDSA entity to clone</param>
    /// <returns>A cloned PanelDataPacketLog_InsertPDSA object</returns>
    public PanelDataPacketLog_InsertPDSA CloneEntity(PanelDataPacketLog_InsertPDSA entityToClone)
    {
      PanelDataPacketLog_InsertPDSA newEntity = new PanelDataPacketLog_InsertPDSA();


      return newEntity;
    }
    #endregion

    #region CreateProperties Method
    /// <summary>
    /// Creates the collection of PDSAProperty objects. These are used to control validation and null handling.
    /// </summary>
    /// <returns>A collection of PDSAProperty objects</returns>
    public override PDSAProperties CreateProperties()
    {
      PDSAProperties props = new PDSAProperties();
      
      props.Add(PDSAProperty.Create(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.Id, GetResourceMessage("GCS_PanelDataPacketLog_InsertPDSA_Id_Header", "Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_PanelDataPacketLog_InsertPDSA_Id_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.InsertDate, GetResourceMessage("GCS_PanelDataPacketLog_InsertPDSA_InsertDate_Header", "Insert Date"), false, typeof(DateTimeOffset), 0, GetResourceMessage("GCS_PanelDataPacketLog_InsertPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, null, @"", ""));
      props.Add(PDSAProperty.Create(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.UpdateDate, GetResourceMessage("GCS_PanelDataPacketLog_InsertPDSA_UpdateDate_Header", "Update Date"), false, typeof(DateTimeOffset), 0, GetResourceMessage("GCS_PanelDataPacketLog_InsertPDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, null, @"", ""));
      props.Add(PDSAProperty.Create(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.Length, GetResourceMessage("GCS_PanelDataPacketLog_InsertPDSA_Length_Header", "Length"), false, typeof(short), 0, GetResourceMessage("GCS_PanelDataPacketLog_InsertPDSA_Length_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.Distribute, GetResourceMessage("GCS_PanelDataPacketLog_InsertPDSA_Distribute_Header", "Distribute"), false, typeof(short), 0, GetResourceMessage("GCS_PanelDataPacketLog_InsertPDSA_Distribute_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.ClusterGroupId, GetResourceMessage("GCS_PanelDataPacketLog_InsertPDSA_ClusterGroupId_Header", "Cluster Group Id"), false, typeof(int), 0, GetResourceMessage("GCS_PanelDataPacketLog_InsertPDSA_ClusterGroupId_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.ClusterId, GetResourceMessage("GCS_PanelDataPacketLog_InsertPDSA_ClusterId_Header", "Cluster Id"), false, typeof(int), 0, GetResourceMessage("GCS_PanelDataPacketLog_InsertPDSA_ClusterId_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.PanelId, GetResourceMessage("GCS_PanelDataPacketLog_InsertPDSA_PanelId_Header", "Panel Id"), false, typeof(int), 0, GetResourceMessage("GCS_PanelDataPacketLog_InsertPDSA_PanelId_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.CpuId, GetResourceMessage("GCS_PanelDataPacketLog_InsertPDSA_CpuId_Header", "Cpu Id"), false, typeof(short), 0, GetResourceMessage("GCS_PanelDataPacketLog_InsertPDSA_CpuId_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.BoardNumber, GetResourceMessage("GCS_PanelDataPacketLog_InsertPDSA_BoardNumber_Header", "Board Number"), false, typeof(int), 0, GetResourceMessage("GCS_PanelDataPacketLog_InsertPDSA_BoardNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.SectionNumber, GetResourceMessage("GCS_PanelDataPacketLog_InsertPDSA_SectionNumber_Header", "Section Number"), false, typeof(short), 0, GetResourceMessage("GCS_PanelDataPacketLog_InsertPDSA_SectionNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.SecondsFromWeekStart, GetResourceMessage("GCS_PanelDataPacketLog_InsertPDSA_SecondsFromWeekStart_Header", "Seconds From Week Start"), false, typeof(int), 0, GetResourceMessage("GCS_PanelDataPacketLog_InsertPDSA_SecondsFromWeekStart_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.Sequence, GetResourceMessage("GCS_PanelDataPacketLog_InsertPDSA_Sequence_Header", "Sequence"), false, typeof(int), 0, GetResourceMessage("GCS_PanelDataPacketLog_InsertPDSA_Sequence_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.RawData, GetResourceMessage("GCS_PanelDataPacketLog_InsertPDSA_RawData_Header", "Raw Data"), false, typeof(byte[]), -1, GetResourceMessage("GCS_PanelDataPacketLog_InsertPDSA_RawData_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, new byte[0], @"", ""));
      props.Add(PDSAProperty.Create(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.Direction, GetResourceMessage("GCS_PanelDataPacketLog_InsertPDSA_Direction_Header", "Direction"), false, typeof(bool), 0, GetResourceMessage("GCS_PanelDataPacketLog_InsertPDSA_Direction_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_PanelDataPacketLog_InsertPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_PanelDataPacketLog_InsertPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
      return props;
    }
    #endregion
    
    #region InitProperties Method
    /// <summary>
    /// Called by the constructor to create the PDSAProperties collection of all properties that will be validated.
    /// </summary>
    protected override void InitProperties()
    {
      // Set the Properties collection to the collection of Entity Properties
      Properties = CreateProperties();
    }
    #endregion

    #region EntityDataToProperties Method
    /// <summary>
    /// Moves the Entity class data into the Properties collection.
    /// </summary>
    protected override void EntityDataToProperties()
    {
      if (Properties == null)
      {
        InitProperties();
      }
      
      Properties.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.Id).Value = Entity.Id;
      Properties.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.InsertDate).Value = Entity.InsertDate;
      Properties.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.UpdateDate).Value = Entity.UpdateDate;
      Properties.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.Length).Value = Entity.Length;
      Properties.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.Distribute).Value = Entity.Distribute;
      Properties.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.ClusterGroupId).Value = Entity.ClusterGroupId;
      Properties.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.ClusterId).Value = Entity.ClusterId;
      Properties.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.PanelId).Value = Entity.PanelId;
      Properties.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.CpuId).Value = Entity.CpuId;
      Properties.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.BoardNumber).Value = Entity.BoardNumber;
      Properties.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.SectionNumber).Value = Entity.SectionNumber;
      Properties.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.SecondsFromWeekStart).Value = Entity.SecondsFromWeekStart;
      Properties.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.Sequence).Value = Entity.Sequence;
      Properties.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.RawData).Value = Entity.RawData;
      Properties.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.Direction).Value = Entity.Direction;
      Properties.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
      {
        InitProperties();
      }

      if(Properties.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.Id).IsNull == false)
        Entity.Id = Properties.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.Id).GetAsGuid();
      if(Properties.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.Length).IsNull == false)
        Entity.Length = Properties.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.Length).GetAsShort();
      if(Properties.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.Distribute).IsNull == false)
        Entity.Distribute = Properties.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.Distribute).GetAsShort();
      if(Properties.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.ClusterGroupId).IsNull == false)
        Entity.ClusterGroupId = Properties.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.ClusterGroupId).GetAsInteger();
      if(Properties.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.ClusterId).IsNull == false)
        Entity.ClusterId = Properties.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.ClusterId).GetAsInteger();
      if(Properties.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.PanelId).IsNull == false)
        Entity.PanelId = Properties.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.PanelId).GetAsInteger();
      if(Properties.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.CpuId).IsNull == false)
        Entity.CpuId = Properties.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.CpuId).GetAsShort();
      if(Properties.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.BoardNumber).IsNull == false)
        Entity.BoardNumber = Properties.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.BoardNumber).GetAsInteger();
      if(Properties.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.SectionNumber).IsNull == false)
        Entity.SectionNumber = Properties.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.SectionNumber).GetAsShort();
      if(Properties.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.SecondsFromWeekStart).IsNull == false)
        Entity.SecondsFromWeekStart = Properties.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.SecondsFromWeekStart).GetAsInteger();
      if(Properties.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.Sequence).IsNull == false)
        Entity.Sequence = Properties.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.Sequence).GetAsInteger();
      if(Properties.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.RawData).IsNull == false)
        Entity.RawData = Properties.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.RawData).GetAsByteArray();
      if(Properties.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.Direction).IsNull == false)
        Entity.Direction = Properties.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.Direction).GetAsBool();
      if(Properties.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = Properties.GetByName(PanelDataPacketLog_InsertPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the PanelDataPacketLog_InsertPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@Id'
    /// </summary>
    public static string Id = "@Id";
    /// <summary>
    /// Returns '@InsertDate'
    /// </summary>
    public static string InsertDate = "@InsertDate";
    /// <summary>
    /// Returns '@UpdateDate'
    /// </summary>
    public static string UpdateDate = "@UpdateDate";
    /// <summary>
    /// Returns '@Length'
    /// </summary>
    public static string Length = "@Length";
    /// <summary>
    /// Returns '@Distribute'
    /// </summary>
    public static string Distribute = "@Distribute";
    /// <summary>
    /// Returns '@ClusterGroupId'
    /// </summary>
    public static string ClusterGroupId = "@ClusterGroupId";
    /// <summary>
    /// Returns '@ClusterId'
    /// </summary>
    public static string ClusterId = "@ClusterId";
    /// <summary>
    /// Returns '@PanelId'
    /// </summary>
    public static string PanelId = "@PanelId";
    /// <summary>
    /// Returns '@CpuId'
    /// </summary>
    public static string CpuId = "@CpuId";
    /// <summary>
    /// Returns '@BoardNumber'
    /// </summary>
    public static string BoardNumber = "@BoardNumber";
    /// <summary>
    /// Returns '@SectionNumber'
    /// </summary>
    public static string SectionNumber = "@SectionNumber";
    /// <summary>
    /// Returns '@SecondsFromWeekStart'
    /// </summary>
    public static string SecondsFromWeekStart = "@SecondsFromWeekStart";
    /// <summary>
    /// Returns '@Sequence'
    /// </summary>
    public static string Sequence = "@Sequence";
    /// <summary>
    /// Returns '@RawData'
    /// </summary>
    public static string RawData = "@RawData";
    /// <summary>
    /// Returns '@Direction'
    /// </summary>
    public static string Direction = "@Direction";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}

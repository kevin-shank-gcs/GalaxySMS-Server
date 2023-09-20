using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the insert_GalaxyRawActivityEventPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class insert_GalaxyRawActivityEventPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private insert_GalaxyRawActivityEventPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new insert_GalaxyRawActivityEventPDSA Entity
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
    /// Clones the current insert_GalaxyRawActivityEventPDSA
    /// </summary>
    /// <returns>A cloned insert_GalaxyRawActivityEventPDSA object</returns>
    public insert_GalaxyRawActivityEventPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in insert_GalaxyRawActivityEventPDSA
    /// </summary>
    /// <param name="entityToClone">The insert_GalaxyRawActivityEventPDSA entity to clone</param>
    /// <returns>A cloned insert_GalaxyRawActivityEventPDSA object</returns>
    public insert_GalaxyRawActivityEventPDSA CloneEntity(insert_GalaxyRawActivityEventPDSA entityToClone)
    {
      insert_GalaxyRawActivityEventPDSA newEntity = new insert_GalaxyRawActivityEventPDSA();


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
      
      props.Add(PDSAProperty.Create(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.GalaxyRawActivityEventUid, GetResourceMessage("GCS_insert_GalaxyRawActivityEventPDSA_GalaxyRawActivityEventUid_Header", "Galaxy Raw Activity Event Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_insert_GalaxyRawActivityEventPDSA_GalaxyRawActivityEventUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.CpuUid, GetResourceMessage("GCS_insert_GalaxyRawActivityEventPDSA_CpuUid_Header", "Cpu Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_insert_GalaxyRawActivityEventPDSA_CpuUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.InsertDate, GetResourceMessage("GCS_insert_GalaxyRawActivityEventPDSA_InsertDate_Header", "Insert Date"), false, typeof(DateTimeOffset), 0, GetResourceMessage("GCS_insert_GalaxyRawActivityEventPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Convert.ToDateTime("00001-1-1", System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat), @"", ""));
      props.Add(PDSAProperty.Create(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.ClusterGroupId, GetResourceMessage("GCS_insert_GalaxyRawActivityEventPDSA_ClusterGroupId_Header", "Cluster Group Id"), false, typeof(int), 0, GetResourceMessage("GCS_insert_GalaxyRawActivityEventPDSA_ClusterGroupId_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.ClusterNumber, GetResourceMessage("GCS_insert_GalaxyRawActivityEventPDSA_ClusterNumber_Header", "Cluster Number"), false, typeof(int), 0, GetResourceMessage("GCS_insert_GalaxyRawActivityEventPDSA_ClusterNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.PanelNumber, GetResourceMessage("GCS_insert_GalaxyRawActivityEventPDSA_PanelNumber_Header", "Panel Number"), false, typeof(int), 0, GetResourceMessage("GCS_insert_GalaxyRawActivityEventPDSA_PanelNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.CpuNumber, GetResourceMessage("GCS_insert_GalaxyRawActivityEventPDSA_CpuNumber_Header", "Cpu Number"), false, typeof(short), 0, GetResourceMessage("GCS_insert_GalaxyRawActivityEventPDSA_CpuNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.EventDateTime, GetResourceMessage("GCS_insert_GalaxyRawActivityEventPDSA_EventDateTime_Header", "Event Date Time"), false, typeof(DateTimeOffset), 0, GetResourceMessage("GCS_insert_GalaxyRawActivityEventPDSA_EventDateTime_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Convert.ToDateTime("00001-1-1", System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat), @"", ""));
      props.Add(PDSAProperty.Create(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.EventType, GetResourceMessage("GCS_insert_GalaxyRawActivityEventPDSA_EventType_Header", "Event Type"), false, typeof(string), 8000, GetResourceMessage("GCS_insert_GalaxyRawActivityEventPDSA_EventType_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.BufferIndex, GetResourceMessage("GCS_insert_GalaxyRawActivityEventPDSA_BufferIndex_Header", "Buffer Index"), false, typeof(int), 0, GetResourceMessage("GCS_insert_GalaxyRawActivityEventPDSA_BufferIndex_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.CredentialBytes, GetResourceMessage("GCS_insert_GalaxyRawActivityEventPDSA_CredentialBytes_Header", "Credential Bytes"), false, typeof(byte[]), 32, GetResourceMessage("GCS_insert_GalaxyRawActivityEventPDSA_CredentialBytes_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, new byte[0], @"", ""));
      props.Add(PDSAProperty.Create(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.Pin, GetResourceMessage("GCS_insert_GalaxyRawActivityEventPDSA_Pin_Header", "Pin"), false, typeof(int), 0, GetResourceMessage("GCS_insert_GalaxyRawActivityEventPDSA_Pin_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.BitCount, GetResourceMessage("GCS_insert_GalaxyRawActivityEventPDSA_BitCount_Header", "Bit Count"), false, typeof(short), 0, GetResourceMessage("GCS_insert_GalaxyRawActivityEventPDSA_BitCount_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.InputOutputGroupNumber, GetResourceMessage("GCS_insert_GalaxyRawActivityEventPDSA_InputOutputGroupNumber_Header", "Input Output Group Number"), false, typeof(short), 0, GetResourceMessage("GCS_insert_GalaxyRawActivityEventPDSA_InputOutputGroupNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.BoardNumber, GetResourceMessage("GCS_insert_GalaxyRawActivityEventPDSA_BoardNumber_Header", "Board Number"), false, typeof(short), 0, GetResourceMessage("GCS_insert_GalaxyRawActivityEventPDSA_BoardNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.SectionNumber, GetResourceMessage("GCS_insert_GalaxyRawActivityEventPDSA_SectionNumber_Header", "Section Number"), false, typeof(short), 0, GetResourceMessage("GCS_insert_GalaxyRawActivityEventPDSA_SectionNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.ModuleNumber, GetResourceMessage("GCS_insert_GalaxyRawActivityEventPDSA_ModuleNumber_Header", "Module Number"), false, typeof(short), 0, GetResourceMessage("GCS_insert_GalaxyRawActivityEventPDSA_ModuleNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.NodeNumber, GetResourceMessage("GCS_insert_GalaxyRawActivityEventPDSA_NodeNumber_Header", "Node Number"), false, typeof(short), 0, GetResourceMessage("GCS_insert_GalaxyRawActivityEventPDSA_NodeNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.RawData, GetResourceMessage("GCS_insert_GalaxyRawActivityEventPDSA_RawData_Header", "Raw Data"), false, typeof(byte[]), 1024, GetResourceMessage("GCS_insert_GalaxyRawActivityEventPDSA_RawData_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, new byte[0], @"", ""));
      props.Add(PDSAProperty.Create(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_insert_GalaxyRawActivityEventPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_insert_GalaxyRawActivityEventPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      Properties.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.GalaxyRawActivityEventUid).Value = Entity.GalaxyRawActivityEventUid;
      Properties.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.CpuUid).Value = Entity.CpuUid;
      Properties.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.InsertDate).Value = Entity.InsertDate;
      Properties.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.ClusterGroupId).Value = Entity.ClusterGroupId;
      Properties.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.ClusterNumber).Value = Entity.ClusterNumber;
      Properties.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.PanelNumber).Value = Entity.PanelNumber;
      Properties.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.CpuNumber).Value = Entity.CpuNumber;
      Properties.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.EventDateTime).Value = Entity.EventDateTime;
      Properties.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.EventType).Value = Entity.EventType;
      Properties.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.BufferIndex).Value = Entity.BufferIndex;
      Properties.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.CredentialBytes).Value = Entity.CredentialBytes;
      Properties.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.Pin).Value = Entity.Pin;
      Properties.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.BitCount).Value = Entity.BitCount;
      Properties.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.InputOutputGroupNumber).Value = Entity.InputOutputGroupNumber;
      Properties.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.BoardNumber).Value = Entity.BoardNumber;
      Properties.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.SectionNumber).Value = Entity.SectionNumber;
      Properties.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.ModuleNumber).Value = Entity.ModuleNumber;
      Properties.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.NodeNumber).Value = Entity.NodeNumber;
      Properties.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.RawData).Value = Entity.RawData;
      Properties.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(Properties.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.GalaxyRawActivityEventUid).IsNull == false)
        Entity.GalaxyRawActivityEventUid = Properties.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.GalaxyRawActivityEventUid).GetAsGuid();
      if(Properties.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.CpuUid).IsNull == false)
        Entity.CpuUid = Properties.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.CpuUid).GetAsGuid();
      if(Properties.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.ClusterGroupId).IsNull == false)
        Entity.ClusterGroupId = Properties.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.ClusterGroupId).GetAsInteger();
      if(Properties.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.ClusterNumber).IsNull == false)
        Entity.ClusterNumber = Properties.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.ClusterNumber).GetAsInteger();
      if(Properties.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.PanelNumber).IsNull == false)
        Entity.PanelNumber = Properties.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.PanelNumber).GetAsInteger();
      if(Properties.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.CpuNumber).IsNull == false)
        Entity.CpuNumber = Properties.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.CpuNumber).GetAsShort();
      if(Properties.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.EventDateTime).IsNull == false)
        Entity.EventDateTime = Properties.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.EventDateTime).GetAsDateTimeOffset();
      if(Properties.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.EventType).IsNull == false)
        Entity.EventType = Properties.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.EventType).GetAsString();
      if(Properties.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.BufferIndex).IsNull == false)
        Entity.BufferIndex = Properties.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.BufferIndex).GetAsInteger();
      if(Properties.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.CredentialBytes).IsNull == false)
        Entity.CredentialBytes = Properties.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.CredentialBytes).GetAsByteArray();
      if(Properties.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.Pin).IsNull == false)
        Entity.Pin = Properties.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.Pin).GetAsInteger();
      if(Properties.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.BitCount).IsNull == false)
        Entity.BitCount = Properties.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.BitCount).GetAsShort();
      if(Properties.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.InputOutputGroupNumber).IsNull == false)
        Entity.InputOutputGroupNumber = Properties.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.InputOutputGroupNumber).GetAsShort();
      if(Properties.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.BoardNumber).IsNull == false)
        Entity.BoardNumber = Properties.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.BoardNumber).GetAsShort();
      if(Properties.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.SectionNumber).IsNull == false)
        Entity.SectionNumber = Properties.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.SectionNumber).GetAsShort();
      if(Properties.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.ModuleNumber).IsNull == false)
        Entity.ModuleNumber = Properties.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.ModuleNumber).GetAsShort();
      if(Properties.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.NodeNumber).IsNull == false)
        Entity.NodeNumber = Properties.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.NodeNumber).GetAsShort();
      if(Properties.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.RawData).IsNull == false)
        Entity.RawData = Properties.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.RawData).GetAsByteArray();
      if(Properties.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = Properties.GetByName(insert_GalaxyRawActivityEventPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the insert_GalaxyRawActivityEventPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@GalaxyRawActivityEventUid'
    /// </summary>
    public static string GalaxyRawActivityEventUid = "@GalaxyRawActivityEventUid";
    /// <summary>
    /// Returns '@CpuUid'
    /// </summary>
    public static string CpuUid = "@CpuUid";
    /// <summary>
    /// Returns '@InsertDate'
    /// </summary>
    public static string InsertDate = "@InsertDate";
    /// <summary>
    /// Returns '@ClusterGroupId'
    /// </summary>
    public static string ClusterGroupId = "@ClusterGroupId";
    /// <summary>
    /// Returns '@ClusterNumber'
    /// </summary>
    public static string ClusterNumber = "@ClusterNumber";
    /// <summary>
    /// Returns '@PanelNumber'
    /// </summary>
    public static string PanelNumber = "@PanelNumber";
    /// <summary>
    /// Returns '@CpuNumber'
    /// </summary>
    public static string CpuNumber = "@CpuNumber";
    /// <summary>
    /// Returns '@EventDateTime'
    /// </summary>
    public static string EventDateTime = "@EventDateTime";
    /// <summary>
    /// Returns '@EventType'
    /// </summary>
    public static string EventType = "@EventType";
    /// <summary>
    /// Returns '@BufferIndex'
    /// </summary>
    public static string BufferIndex = "@BufferIndex";
    /// <summary>
    /// Returns '@CredentialBytes'
    /// </summary>
    public static string CredentialBytes = "@CredentialBytes";
    /// <summary>
    /// Returns '@Pin'
    /// </summary>
    public static string Pin = "@Pin";
    /// <summary>
    /// Returns '@BitCount'
    /// </summary>
    public static string BitCount = "@BitCount";
    /// <summary>
    /// Returns '@InputOutputGroupNumber'
    /// </summary>
    public static string InputOutputGroupNumber = "@InputOutputGroupNumber";
    /// <summary>
    /// Returns '@BoardNumber'
    /// </summary>
    public static string BoardNumber = "@BoardNumber";
    /// <summary>
    /// Returns '@SectionNumber'
    /// </summary>
    public static string SectionNumber = "@SectionNumber";
    /// <summary>
    /// Returns '@ModuleNumber'
    /// </summary>
    public static string ModuleNumber = "@ModuleNumber";
    /// <summary>
    /// Returns '@NodeNumber'
    /// </summary>
    public static string NodeNumber = "@NodeNumber";
    /// <summary>
    /// Returns '@RawData'
    /// </summary>
    public static string RawData = "@RawData";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}

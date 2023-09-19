using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the insert_OutputDeviceActivityEventPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class insert_OutputDeviceActivityEventPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private insert_OutputDeviceActivityEventPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new insert_OutputDeviceActivityEventPDSA Entity
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
    /// Clones the current insert_OutputDeviceActivityEventPDSA
    /// </summary>
    /// <returns>A cloned insert_OutputDeviceActivityEventPDSA object</returns>
    public insert_OutputDeviceActivityEventPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in insert_OutputDeviceActivityEventPDSA
    /// </summary>
    /// <param name="entityToClone">The insert_OutputDeviceActivityEventPDSA entity to clone</param>
    /// <returns>A cloned insert_OutputDeviceActivityEventPDSA object</returns>
    public insert_OutputDeviceActivityEventPDSA CloneEntity(insert_OutputDeviceActivityEventPDSA entityToClone)
    {
      insert_OutputDeviceActivityEventPDSA newEntity = new insert_OutputDeviceActivityEventPDSA();


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
      
      props.Add(PDSAProperty.Create(insert_OutputDeviceActivityEventPDSAValidator.ParameterNames.OutputDeviceActivityEventUid, GetResourceMessage("GCS_insert_OutputDeviceActivityEventPDSA_OutputDeviceActivityEventUid_Header", "Output Device Activity Event Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_insert_OutputDeviceActivityEventPDSA_OutputDeviceActivityEventUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(insert_OutputDeviceActivityEventPDSAValidator.ParameterNames.GalaxyActivityEventTypeUid, GetResourceMessage("GCS_insert_OutputDeviceActivityEventPDSA_GalaxyActivityEventTypeUid_Header", "Galaxy Activity Event Type Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_insert_OutputDeviceActivityEventPDSA_GalaxyActivityEventTypeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(insert_OutputDeviceActivityEventPDSAValidator.ParameterNames.OutputDeviceUid, GetResourceMessage("GCS_insert_OutputDeviceActivityEventPDSA_OutputDeviceUid_Header", "Output Device Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_insert_OutputDeviceActivityEventPDSA_OutputDeviceUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(insert_OutputDeviceActivityEventPDSAValidator.ParameterNames.CpuUid, GetResourceMessage("GCS_insert_OutputDeviceActivityEventPDSA_CpuUid_Header", "Cpu Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_insert_OutputDeviceActivityEventPDSA_CpuUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(insert_OutputDeviceActivityEventPDSAValidator.ParameterNames.CpuNumber, GetResourceMessage("GCS_insert_OutputDeviceActivityEventPDSA_CpuNumber_Header", "Cpu Number"), false, typeof(short), 0, GetResourceMessage("GCS_insert_OutputDeviceActivityEventPDSA_CpuNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(insert_OutputDeviceActivityEventPDSAValidator.ParameterNames.ActivityDateTime, GetResourceMessage("GCS_insert_OutputDeviceActivityEventPDSA_ActivityDateTime_Header", "Activity Date Time"), false, typeof(DateTimeOffset), 0, GetResourceMessage("GCS_insert_OutputDeviceActivityEventPDSA_ActivityDateTime_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, Convert.ToDateTime("1753-1-1", System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat), @"", ""));
      props.Add(PDSAProperty.Create(insert_OutputDeviceActivityEventPDSAValidator.ParameterNames.BufferIndex, GetResourceMessage("GCS_insert_OutputDeviceActivityEventPDSA_BufferIndex_Header", "Buffer Index"), false, typeof(int), 0, GetResourceMessage("GCS_insert_OutputDeviceActivityEventPDSA_BufferIndex_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(insert_OutputDeviceActivityEventPDSAValidator.ParameterNames.InsertDate, GetResourceMessage("GCS_insert_OutputDeviceActivityEventPDSA_InsertDate_Header", "Insert Date"), false, typeof(DateTimeOffset), 0, GetResourceMessage("GCS_insert_OutputDeviceActivityEventPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, Convert.ToDateTime("1753-1-1", System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat), @"", ""));
      props.Add(PDSAProperty.Create(insert_OutputDeviceActivityEventPDSAValidator.ParameterNames.eventType, GetResourceMessage("GCS_insert_OutputDeviceActivityEventPDSA_eventType_Header", "event Type"), false, typeof(string), 8000, GetResourceMessage("GCS_insert_OutputDeviceActivityEventPDSA_eventType_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(insert_OutputDeviceActivityEventPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_insert_OutputDeviceActivityEventPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_insert_OutputDeviceActivityEventPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      Properties.GetByName(insert_OutputDeviceActivityEventPDSAValidator.ParameterNames.OutputDeviceActivityEventUid).Value = Entity.OutputDeviceActivityEventUid;
      Properties.GetByName(insert_OutputDeviceActivityEventPDSAValidator.ParameterNames.GalaxyActivityEventTypeUid).Value = Entity.GalaxyActivityEventTypeUid;
      Properties.GetByName(insert_OutputDeviceActivityEventPDSAValidator.ParameterNames.OutputDeviceUid).Value = Entity.OutputDeviceUid;
      Properties.GetByName(insert_OutputDeviceActivityEventPDSAValidator.ParameterNames.CpuUid).Value = Entity.CpuUid;
      Properties.GetByName(insert_OutputDeviceActivityEventPDSAValidator.ParameterNames.CpuNumber).Value = Entity.CpuNumber;
      Properties.GetByName(insert_OutputDeviceActivityEventPDSAValidator.ParameterNames.ActivityDateTime).Value = Entity.ActivityDateTime;
      Properties.GetByName(insert_OutputDeviceActivityEventPDSAValidator.ParameterNames.BufferIndex).Value = Entity.BufferIndex;
      Properties.GetByName(insert_OutputDeviceActivityEventPDSAValidator.ParameterNames.InsertDate).Value = Entity.InsertDate;
      Properties.GetByName(insert_OutputDeviceActivityEventPDSAValidator.ParameterNames.eventType).Value = Entity.eventType;
      Properties.GetByName(insert_OutputDeviceActivityEventPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(Properties.GetByName(insert_OutputDeviceActivityEventPDSAValidator.ParameterNames.OutputDeviceActivityEventUid).IsNull == false)
        Entity.OutputDeviceActivityEventUid = Properties.GetByName(insert_OutputDeviceActivityEventPDSAValidator.ParameterNames.OutputDeviceActivityEventUid).GetAsGuid();
      if(Properties.GetByName(insert_OutputDeviceActivityEventPDSAValidator.ParameterNames.GalaxyActivityEventTypeUid).IsNull == false)
        Entity.GalaxyActivityEventTypeUid = Properties.GetByName(insert_OutputDeviceActivityEventPDSAValidator.ParameterNames.GalaxyActivityEventTypeUid).GetAsGuid();
      if(Properties.GetByName(insert_OutputDeviceActivityEventPDSAValidator.ParameterNames.OutputDeviceUid).IsNull == false)
        Entity.OutputDeviceUid = Properties.GetByName(insert_OutputDeviceActivityEventPDSAValidator.ParameterNames.OutputDeviceUid).GetAsGuid();
      if(Properties.GetByName(insert_OutputDeviceActivityEventPDSAValidator.ParameterNames.CpuUid).IsNull == false)
        Entity.CpuUid = Properties.GetByName(insert_OutputDeviceActivityEventPDSAValidator.ParameterNames.CpuUid).GetAsGuid();
      if(Properties.GetByName(insert_OutputDeviceActivityEventPDSAValidator.ParameterNames.CpuNumber).IsNull == false)
        Entity.CpuNumber = Properties.GetByName(insert_OutputDeviceActivityEventPDSAValidator.ParameterNames.CpuNumber).GetAsShort();
      if(Properties.GetByName(insert_OutputDeviceActivityEventPDSAValidator.ParameterNames.ActivityDateTime).IsNull == false)
        Entity.ActivityDateTime = Properties.GetByName(insert_OutputDeviceActivityEventPDSAValidator.ParameterNames.ActivityDateTime).GetAsDateTimeOffset();
      if(Properties.GetByName(insert_OutputDeviceActivityEventPDSAValidator.ParameterNames.BufferIndex).IsNull == false)
        Entity.BufferIndex = Properties.GetByName(insert_OutputDeviceActivityEventPDSAValidator.ParameterNames.BufferIndex).GetAsInteger();
      if(Properties.GetByName(insert_OutputDeviceActivityEventPDSAValidator.ParameterNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(insert_OutputDeviceActivityEventPDSAValidator.ParameterNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(insert_OutputDeviceActivityEventPDSAValidator.ParameterNames.eventType).IsNull == false)
        Entity.eventType = Properties.GetByName(insert_OutputDeviceActivityEventPDSAValidator.ParameterNames.eventType).GetAsString();
      if(Properties.GetByName(insert_OutputDeviceActivityEventPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = Properties.GetByName(insert_OutputDeviceActivityEventPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the insert_OutputDeviceActivityEventPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@OutputDeviceActivityEventUid'
    /// </summary>
    public static string OutputDeviceActivityEventUid = "@OutputDeviceActivityEventUid";
    /// <summary>
    /// Returns '@GalaxyActivityEventTypeUid'
    /// </summary>
    public static string GalaxyActivityEventTypeUid = "@GalaxyActivityEventTypeUid";
    /// <summary>
    /// Returns '@OutputDeviceUid'
    /// </summary>
    public static string OutputDeviceUid = "@OutputDeviceUid";
    /// <summary>
    /// Returns '@CpuUid'
    /// </summary>
    public static string CpuUid = "@CpuUid";
    /// <summary>
    /// Returns '@CpuNumber'
    /// </summary>
    public static string CpuNumber = "@CpuNumber";
    /// <summary>
    /// Returns '@ActivityDateTime'
    /// </summary>
    public static string ActivityDateTime = "@ActivityDateTime";
    /// <summary>
    /// Returns '@BufferIndex'
    /// </summary>
    public static string BufferIndex = "@BufferIndex";
    /// <summary>
    /// Returns '@InsertDate'
    /// </summary>
    public static string InsertDate = "@InsertDate";
    /// <summary>
    /// Returns '@eventType'
    /// </summary>
    public static string eventType = "@eventType";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}

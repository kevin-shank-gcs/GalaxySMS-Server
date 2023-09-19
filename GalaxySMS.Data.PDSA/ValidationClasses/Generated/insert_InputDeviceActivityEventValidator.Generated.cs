using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the insert_InputDeviceActivityEventPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class insert_InputDeviceActivityEventPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private insert_InputDeviceActivityEventPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new insert_InputDeviceActivityEventPDSA Entity
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
    /// Clones the current insert_InputDeviceActivityEventPDSA
    /// </summary>
    /// <returns>A cloned insert_InputDeviceActivityEventPDSA object</returns>
    public insert_InputDeviceActivityEventPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in insert_InputDeviceActivityEventPDSA
    /// </summary>
    /// <param name="entityToClone">The insert_InputDeviceActivityEventPDSA entity to clone</param>
    /// <returns>A cloned insert_InputDeviceActivityEventPDSA object</returns>
    public insert_InputDeviceActivityEventPDSA CloneEntity(insert_InputDeviceActivityEventPDSA entityToClone)
    {
      insert_InputDeviceActivityEventPDSA newEntity = new insert_InputDeviceActivityEventPDSA();


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
      
      props.Add(PDSAProperty.Create(insert_InputDeviceActivityEventPDSAValidator.ParameterNames.InputDeviceActivityEventUid, GetResourceMessage("GCS_insert_InputDeviceActivityEventPDSA_InputDeviceActivityEventUid_Header", "Input Device Activity Event Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_insert_InputDeviceActivityEventPDSA_InputDeviceActivityEventUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(insert_InputDeviceActivityEventPDSAValidator.ParameterNames.GalaxyActivityEventTypeUid, GetResourceMessage("GCS_insert_InputDeviceActivityEventPDSA_GalaxyActivityEventTypeUid_Header", "Galaxy Activity Event Type Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_insert_InputDeviceActivityEventPDSA_GalaxyActivityEventTypeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(insert_InputDeviceActivityEventPDSAValidator.ParameterNames.InputDeviceUid, GetResourceMessage("GCS_insert_InputDeviceActivityEventPDSA_InputDeviceUid_Header", "Input Device Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_insert_InputDeviceActivityEventPDSA_InputDeviceUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(insert_InputDeviceActivityEventPDSAValidator.ParameterNames.CpuUid, GetResourceMessage("GCS_insert_InputDeviceActivityEventPDSA_CpuUid_Header", "Cpu Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_insert_InputDeviceActivityEventPDSA_CpuUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(insert_InputDeviceActivityEventPDSAValidator.ParameterNames.CpuNumber, GetResourceMessage("GCS_insert_InputDeviceActivityEventPDSA_CpuNumber_Header", "Cpu Number"), false, typeof(short), 0, GetResourceMessage("GCS_insert_InputDeviceActivityEventPDSA_CpuNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(insert_InputDeviceActivityEventPDSAValidator.ParameterNames.ActivityDateTime, GetResourceMessage("GCS_insert_InputDeviceActivityEventPDSA_ActivityDateTime_Header", "Activity Date Time"), false, typeof(DateTimeOffset), 0, GetResourceMessage("GCS_insert_InputDeviceActivityEventPDSA_ActivityDateTime_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Convert.ToDateTime("00001-1-1", System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat), @"", ""));
      props.Add(PDSAProperty.Create(insert_InputDeviceActivityEventPDSAValidator.ParameterNames.BufferIndex, GetResourceMessage("GCS_insert_InputDeviceActivityEventPDSA_BufferIndex_Header", "Buffer Index"), false, typeof(int), 0, GetResourceMessage("GCS_insert_InputDeviceActivityEventPDSA_BufferIndex_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(insert_InputDeviceActivityEventPDSAValidator.ParameterNames.InsertDate, GetResourceMessage("GCS_insert_InputDeviceActivityEventPDSA_InsertDate_Header", "Insert Date"), false, typeof(DateTimeOffset), 0, GetResourceMessage("GCS_insert_InputDeviceActivityEventPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Convert.ToDateTime("00001-1-1", System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat), @"", ""));
      props.Add(PDSAProperty.Create(insert_InputDeviceActivityEventPDSAValidator.ParameterNames.eventType, GetResourceMessage("GCS_insert_InputDeviceActivityEventPDSA_eventType_Header", "event Type"), false, typeof(string), 8000, GetResourceMessage("GCS_insert_InputDeviceActivityEventPDSA_eventType_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(insert_InputDeviceActivityEventPDSAValidator.ParameterNames.IsAlarmEvent, GetResourceMessage("GCS_insert_InputDeviceActivityEventPDSA_IsAlarmEvent_Header", "Is Alarm Event"), false, typeof(bool), 0, GetResourceMessage("GCS_insert_InputDeviceActivityEventPDSA_IsAlarmEvent_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(insert_InputDeviceActivityEventPDSAValidator.ParameterNames.AlarmPriority, GetResourceMessage("GCS_insert_InputDeviceActivityEventPDSA_AlarmPriority_Header", "Alarm Priority"), false, typeof(int), 0, GetResourceMessage("GCS_insert_InputDeviceActivityEventPDSA_AlarmPriority_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(insert_InputDeviceActivityEventPDSAValidator.ParameterNames.ResponseRequired, GetResourceMessage("GCS_insert_InputDeviceActivityEventPDSA_ResponseRequired_Header", "Response Required"), false, typeof(bool), 0, GetResourceMessage("GCS_insert_InputDeviceActivityEventPDSA_ResponseRequired_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(insert_InputDeviceActivityEventPDSAValidator.ParameterNames.NoteUid, GetResourceMessage("GCS_insert_InputDeviceActivityEventPDSA_NoteUid_Header", "Note Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_insert_InputDeviceActivityEventPDSA_NoteUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(insert_InputDeviceActivityEventPDSAValidator.ParameterNames.BinaryResourceUid, GetResourceMessage("GCS_insert_InputDeviceActivityEventPDSA_BinaryResourceUid_Header", "Binary Resource Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_insert_InputDeviceActivityEventPDSA_BinaryResourceUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(insert_InputDeviceActivityEventPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_insert_InputDeviceActivityEventPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_insert_InputDeviceActivityEventPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      Properties.GetByName(insert_InputDeviceActivityEventPDSAValidator.ParameterNames.InputDeviceActivityEventUid).Value = Entity.InputDeviceActivityEventUid;
      Properties.GetByName(insert_InputDeviceActivityEventPDSAValidator.ParameterNames.GalaxyActivityEventTypeUid).Value = Entity.GalaxyActivityEventTypeUid;
      Properties.GetByName(insert_InputDeviceActivityEventPDSAValidator.ParameterNames.InputDeviceUid).Value = Entity.InputDeviceUid;
      Properties.GetByName(insert_InputDeviceActivityEventPDSAValidator.ParameterNames.CpuUid).Value = Entity.CpuUid;
      Properties.GetByName(insert_InputDeviceActivityEventPDSAValidator.ParameterNames.CpuNumber).Value = Entity.CpuNumber;
      Properties.GetByName(insert_InputDeviceActivityEventPDSAValidator.ParameterNames.ActivityDateTime).Value = Entity.ActivityDateTime;
      Properties.GetByName(insert_InputDeviceActivityEventPDSAValidator.ParameterNames.BufferIndex).Value = Entity.BufferIndex;
      Properties.GetByName(insert_InputDeviceActivityEventPDSAValidator.ParameterNames.InsertDate).Value = Entity.InsertDate;
      Properties.GetByName(insert_InputDeviceActivityEventPDSAValidator.ParameterNames.eventType).Value = Entity.eventType;
      Properties.GetByName(insert_InputDeviceActivityEventPDSAValidator.ParameterNames.IsAlarmEvent).Value = Entity.IsAlarmEvent;
      Properties.GetByName(insert_InputDeviceActivityEventPDSAValidator.ParameterNames.AlarmPriority).Value = Entity.AlarmPriority;
      Properties.GetByName(insert_InputDeviceActivityEventPDSAValidator.ParameterNames.ResponseRequired).Value = Entity.ResponseRequired;
      Properties.GetByName(insert_InputDeviceActivityEventPDSAValidator.ParameterNames.NoteUid).Value = Entity.NoteUid;
      Properties.GetByName(insert_InputDeviceActivityEventPDSAValidator.ParameterNames.BinaryResourceUid).Value = Entity.BinaryResourceUid;
      Properties.GetByName(insert_InputDeviceActivityEventPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(Properties.GetByName(insert_InputDeviceActivityEventPDSAValidator.ParameterNames.InputDeviceActivityEventUid).IsNull == false)
        Entity.InputDeviceActivityEventUid = Properties.GetByName(insert_InputDeviceActivityEventPDSAValidator.ParameterNames.InputDeviceActivityEventUid).GetAsGuid();
      if(Properties.GetByName(insert_InputDeviceActivityEventPDSAValidator.ParameterNames.GalaxyActivityEventTypeUid).IsNull == false)
        Entity.GalaxyActivityEventTypeUid = Properties.GetByName(insert_InputDeviceActivityEventPDSAValidator.ParameterNames.GalaxyActivityEventTypeUid).GetAsGuid();
      if(Properties.GetByName(insert_InputDeviceActivityEventPDSAValidator.ParameterNames.InputDeviceUid).IsNull == false)
        Entity.InputDeviceUid = Properties.GetByName(insert_InputDeviceActivityEventPDSAValidator.ParameterNames.InputDeviceUid).GetAsGuid();
      if(Properties.GetByName(insert_InputDeviceActivityEventPDSAValidator.ParameterNames.CpuUid).IsNull == false)
        Entity.CpuUid = Properties.GetByName(insert_InputDeviceActivityEventPDSAValidator.ParameterNames.CpuUid).GetAsGuid();
      if(Properties.GetByName(insert_InputDeviceActivityEventPDSAValidator.ParameterNames.CpuNumber).IsNull == false)
        Entity.CpuNumber = Properties.GetByName(insert_InputDeviceActivityEventPDSAValidator.ParameterNames.CpuNumber).GetAsShort();
      if(Properties.GetByName(insert_InputDeviceActivityEventPDSAValidator.ParameterNames.ActivityDateTime).IsNull == false)
        Entity.ActivityDateTime = Properties.GetByName(insert_InputDeviceActivityEventPDSAValidator.ParameterNames.ActivityDateTime).GetAsDateTimeOffset();
      if(Properties.GetByName(insert_InputDeviceActivityEventPDSAValidator.ParameterNames.BufferIndex).IsNull == false)
        Entity.BufferIndex = Properties.GetByName(insert_InputDeviceActivityEventPDSAValidator.ParameterNames.BufferIndex).GetAsInteger();
      if(Properties.GetByName(insert_InputDeviceActivityEventPDSAValidator.ParameterNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(insert_InputDeviceActivityEventPDSAValidator.ParameterNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(insert_InputDeviceActivityEventPDSAValidator.ParameterNames.eventType).IsNull == false)
        Entity.eventType = Properties.GetByName(insert_InputDeviceActivityEventPDSAValidator.ParameterNames.eventType).GetAsString();
      if(Properties.GetByName(insert_InputDeviceActivityEventPDSAValidator.ParameterNames.IsAlarmEvent).IsNull == false)
        Entity.IsAlarmEvent = Properties.GetByName(insert_InputDeviceActivityEventPDSAValidator.ParameterNames.IsAlarmEvent).GetAsBool();
      if(Properties.GetByName(insert_InputDeviceActivityEventPDSAValidator.ParameterNames.AlarmPriority).IsNull == false)
        Entity.AlarmPriority = Properties.GetByName(insert_InputDeviceActivityEventPDSAValidator.ParameterNames.AlarmPriority).GetAsInteger();
      if(Properties.GetByName(insert_InputDeviceActivityEventPDSAValidator.ParameterNames.ResponseRequired).IsNull == false)
        Entity.ResponseRequired = Properties.GetByName(insert_InputDeviceActivityEventPDSAValidator.ParameterNames.ResponseRequired).GetAsBool();
      if(Properties.GetByName(insert_InputDeviceActivityEventPDSAValidator.ParameterNames.NoteUid).IsNull == false)
        Entity.NoteUid = Properties.GetByName(insert_InputDeviceActivityEventPDSAValidator.ParameterNames.NoteUid).GetAsGuid();
      if(Properties.GetByName(insert_InputDeviceActivityEventPDSAValidator.ParameterNames.BinaryResourceUid).IsNull == false)
        Entity.BinaryResourceUid = Properties.GetByName(insert_InputDeviceActivityEventPDSAValidator.ParameterNames.BinaryResourceUid).GetAsGuid();
      if(Properties.GetByName(insert_InputDeviceActivityEventPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = Properties.GetByName(insert_InputDeviceActivityEventPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the insert_InputDeviceActivityEventPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@InputDeviceActivityEventUid'
    /// </summary>
    public static string InputDeviceActivityEventUid = "@InputDeviceActivityEventUid";
    /// <summary>
    /// Returns '@GalaxyActivityEventTypeUid'
    /// </summary>
    public static string GalaxyActivityEventTypeUid = "@GalaxyActivityEventTypeUid";
    /// <summary>
    /// Returns '@InputDeviceUid'
    /// </summary>
    public static string InputDeviceUid = "@InputDeviceUid";
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
    /// Returns '@IsAlarmEvent'
    /// </summary>
    public static string IsAlarmEvent = "@IsAlarmEvent";
    /// <summary>
    /// Returns '@AlarmPriority'
    /// </summary>
    public static string AlarmPriority = "@AlarmPriority";
    /// <summary>
    /// Returns '@ResponseRequired'
    /// </summary>
    public static string ResponseRequired = "@ResponseRequired";
    /// <summary>
    /// Returns '@NoteUid'
    /// </summary>
    public static string NoteUid = "@NoteUid";
    /// <summary>
    /// Returns '@BinaryResourceUid'
    /// </summary>
    public static string BinaryResourceUid = "@BinaryResourceUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}

using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the insert_AccessPortalActivityEventPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class insert_AccessPortalActivityEventPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private insert_AccessPortalActivityEventPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new insert_AccessPortalActivityEventPDSA Entity
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
    /// Clones the current insert_AccessPortalActivityEventPDSA
    /// </summary>
    /// <returns>A cloned insert_AccessPortalActivityEventPDSA object</returns>
    public insert_AccessPortalActivityEventPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in insert_AccessPortalActivityEventPDSA
    /// </summary>
    /// <param name="entityToClone">The insert_AccessPortalActivityEventPDSA entity to clone</param>
    /// <returns>A cloned insert_AccessPortalActivityEventPDSA object</returns>
    public insert_AccessPortalActivityEventPDSA CloneEntity(insert_AccessPortalActivityEventPDSA entityToClone)
    {
      insert_AccessPortalActivityEventPDSA newEntity = new insert_AccessPortalActivityEventPDSA();


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
      
      props.Add(PDSAProperty.Create(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.AccessPortalActivityEventUid, GetResourceMessage("GCS_insert_AccessPortalActivityEventPDSA_AccessPortalActivityEventUid_Header", "Access Portal Activity Event Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_insert_AccessPortalActivityEventPDSA_AccessPortalActivityEventUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.GalaxyActivityEventTypeUid, GetResourceMessage("GCS_insert_AccessPortalActivityEventPDSA_GalaxyActivityEventTypeUid_Header", "Galaxy Activity Event Type Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_insert_AccessPortalActivityEventPDSA_GalaxyActivityEventTypeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.AccessPortalUid, GetResourceMessage("GCS_insert_AccessPortalActivityEventPDSA_AccessPortalUid_Header", "Access Portal Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_insert_AccessPortalActivityEventPDSA_AccessPortalUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.CredentialUid, GetResourceMessage("GCS_insert_AccessPortalActivityEventPDSA_CredentialUid_Header", "Credential Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_insert_AccessPortalActivityEventPDSA_CredentialUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.PersonUid, GetResourceMessage("GCS_insert_AccessPortalActivityEventPDSA_PersonUid_Header", "Person Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_insert_AccessPortalActivityEventPDSA_PersonUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.CpuUid, GetResourceMessage("GCS_insert_AccessPortalActivityEventPDSA_CpuUid_Header", "Cpu Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_insert_AccessPortalActivityEventPDSA_CpuUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.CpuNumber, GetResourceMessage("GCS_insert_AccessPortalActivityEventPDSA_CpuNumber_Header", "Cpu Number"), false, typeof(short), 0, GetResourceMessage("GCS_insert_AccessPortalActivityEventPDSA_CpuNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.ActivityDateTime, GetResourceMessage("GCS_insert_AccessPortalActivityEventPDSA_ActivityDateTime_Header", "Activity Date Time"), false, typeof(DateTimeOffset), 0, GetResourceMessage("GCS_insert_AccessPortalActivityEventPDSA_ActivityDateTime_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Convert.ToDateTime("00001-1-1", System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat), @"", ""));
      props.Add(PDSAProperty.Create(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.BufferIndex, GetResourceMessage("GCS_insert_AccessPortalActivityEventPDSA_BufferIndex_Header", "Buffer Index"), false, typeof(int), 0, GetResourceMessage("GCS_insert_AccessPortalActivityEventPDSA_BufferIndex_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.InsertDate, GetResourceMessage("GCS_insert_AccessPortalActivityEventPDSA_InsertDate_Header", "Insert Date"), false, typeof(DateTimeOffset), 0, GetResourceMessage("GCS_insert_AccessPortalActivityEventPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Convert.ToDateTime("00001-1-1", System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat), @"", ""));
      props.Add(PDSAProperty.Create(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.eventType, GetResourceMessage("GCS_insert_AccessPortalActivityEventPDSA_eventType_Header", "event Type"), false, typeof(string), 8000, GetResourceMessage("GCS_insert_AccessPortalActivityEventPDSA_eventType_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.CredentialBytes, GetResourceMessage("GCS_insert_AccessPortalActivityEventPDSA_CredentialBytes_Header", "Credential Bytes"), false, typeof(byte[]), 32, GetResourceMessage("GCS_insert_AccessPortalActivityEventPDSA_CredentialBytes_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, new byte[0], @"", ""));
      props.Add(PDSAProperty.Create(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.IsAlarmEvent, GetResourceMessage("GCS_insert_AccessPortalActivityEventPDSA_IsAlarmEvent_Header", "Is Alarm Event"), false, typeof(bool), 0, GetResourceMessage("GCS_insert_AccessPortalActivityEventPDSA_IsAlarmEvent_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.AlarmPriority, GetResourceMessage("GCS_insert_AccessPortalActivityEventPDSA_AlarmPriority_Header", "Alarm Priority"), false, typeof(int), 0, GetResourceMessage("GCS_insert_AccessPortalActivityEventPDSA_AlarmPriority_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.ResponseRequired, GetResourceMessage("GCS_insert_AccessPortalActivityEventPDSA_ResponseRequired_Header", "Response Required"), false, typeof(bool), 0, GetResourceMessage("GCS_insert_AccessPortalActivityEventPDSA_ResponseRequired_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.NoteUid, GetResourceMessage("GCS_insert_AccessPortalActivityEventPDSA_NoteUid_Header", "Note Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_insert_AccessPortalActivityEventPDSA_NoteUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.BinaryResourceUid, GetResourceMessage("GCS_insert_AccessPortalActivityEventPDSA_BinaryResourceUid_Header", "Binary Resource Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_insert_AccessPortalActivityEventPDSA_BinaryResourceUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.IsAccessGrantedEvent, GetResourceMessage("GCS_insert_AccessPortalActivityEventPDSA_IsAccessGrantedEvent_Header", "Is Access Granted Event"), false, typeof(bool), 0, GetResourceMessage("GCS_insert_AccessPortalActivityEventPDSA_IsAccessGrantedEvent_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_insert_AccessPortalActivityEventPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_insert_AccessPortalActivityEventPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      Properties.GetByName(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.AccessPortalActivityEventUid).Value = Entity.AccessPortalActivityEventUid;
      Properties.GetByName(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.GalaxyActivityEventTypeUid).Value = Entity.GalaxyActivityEventTypeUid;
      Properties.GetByName(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.AccessPortalUid).Value = Entity.AccessPortalUid;
      Properties.GetByName(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.CredentialUid).Value = Entity.CredentialUid;
      Properties.GetByName(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.PersonUid).Value = Entity.PersonUid;
      Properties.GetByName(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.CpuUid).Value = Entity.CpuUid;
      Properties.GetByName(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.CpuNumber).Value = Entity.CpuNumber;
      Properties.GetByName(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.ActivityDateTime).Value = Entity.ActivityDateTime;
      Properties.GetByName(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.BufferIndex).Value = Entity.BufferIndex;
      Properties.GetByName(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.InsertDate).Value = Entity.InsertDate;
      Properties.GetByName(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.eventType).Value = Entity.eventType;
      Properties.GetByName(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.CredentialBytes).Value = Entity.CredentialBytes;
      Properties.GetByName(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.IsAlarmEvent).Value = Entity.IsAlarmEvent;
      Properties.GetByName(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.AlarmPriority).Value = Entity.AlarmPriority;
      Properties.GetByName(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.ResponseRequired).Value = Entity.ResponseRequired;
      Properties.GetByName(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.NoteUid).Value = Entity.NoteUid;
      Properties.GetByName(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.BinaryResourceUid).Value = Entity.BinaryResourceUid;
      Properties.GetByName(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.IsAccessGrantedEvent).Value = Entity.IsAccessGrantedEvent;
      Properties.GetByName(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(Properties.GetByName(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.AccessPortalActivityEventUid).IsNull == false)
        Entity.AccessPortalActivityEventUid = Properties.GetByName(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.AccessPortalActivityEventUid).GetAsGuid();
      if(Properties.GetByName(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.GalaxyActivityEventTypeUid).IsNull == false)
        Entity.GalaxyActivityEventTypeUid = Properties.GetByName(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.GalaxyActivityEventTypeUid).GetAsGuid();
      if(Properties.GetByName(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.AccessPortalUid).IsNull == false)
        Entity.AccessPortalUid = Properties.GetByName(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.AccessPortalUid).GetAsGuid();
      if(Properties.GetByName(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.CredentialUid).IsNull == false)
        Entity.CredentialUid = Properties.GetByName(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.CredentialUid).GetAsGuid();
      if(Properties.GetByName(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.PersonUid).IsNull == false)
        Entity.PersonUid = Properties.GetByName(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.PersonUid).GetAsGuid();
      if(Properties.GetByName(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.CpuUid).IsNull == false)
        Entity.CpuUid = Properties.GetByName(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.CpuUid).GetAsGuid();
      if(Properties.GetByName(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.CpuNumber).IsNull == false)
        Entity.CpuNumber = Properties.GetByName(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.CpuNumber).GetAsShort();
      if(Properties.GetByName(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.ActivityDateTime).IsNull == false)
        Entity.ActivityDateTime = Properties.GetByName(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.ActivityDateTime).GetAsDateTimeOffset();
      if(Properties.GetByName(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.BufferIndex).IsNull == false)
        Entity.BufferIndex = Properties.GetByName(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.BufferIndex).GetAsInteger();
      if(Properties.GetByName(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.eventType).IsNull == false)
        Entity.eventType = Properties.GetByName(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.eventType).GetAsString();
      if(Properties.GetByName(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.CredentialBytes).IsNull == false)
        Entity.CredentialBytes = Properties.GetByName(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.CredentialBytes).GetAsByteArray();
      if(Properties.GetByName(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.IsAlarmEvent).IsNull == false)
        Entity.IsAlarmEvent = Properties.GetByName(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.IsAlarmEvent).GetAsBool();
      if(Properties.GetByName(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.AlarmPriority).IsNull == false)
        Entity.AlarmPriority = Properties.GetByName(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.AlarmPriority).GetAsInteger();
      if(Properties.GetByName(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.ResponseRequired).IsNull == false)
        Entity.ResponseRequired = Properties.GetByName(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.ResponseRequired).GetAsBool();
      if(Properties.GetByName(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.NoteUid).IsNull == false)
        Entity.NoteUid = Properties.GetByName(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.NoteUid).GetAsGuid();
      if(Properties.GetByName(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.BinaryResourceUid).IsNull == false)
        Entity.BinaryResourceUid = Properties.GetByName(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.BinaryResourceUid).GetAsGuid();
      if(Properties.GetByName(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.IsAccessGrantedEvent).IsNull == false)
        Entity.IsAccessGrantedEvent = Properties.GetByName(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.IsAccessGrantedEvent).GetAsBool();
      if(Properties.GetByName(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = Properties.GetByName(insert_AccessPortalActivityEventPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the insert_AccessPortalActivityEventPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@AccessPortalActivityEventUid'
    /// </summary>
    public static string AccessPortalActivityEventUid = "@AccessPortalActivityEventUid";
    /// <summary>
    /// Returns '@GalaxyActivityEventTypeUid'
    /// </summary>
    public static string GalaxyActivityEventTypeUid = "@GalaxyActivityEventTypeUid";
    /// <summary>
    /// Returns '@AccessPortalUid'
    /// </summary>
    public static string AccessPortalUid = "@AccessPortalUid";
    /// <summary>
    /// Returns '@CredentialUid'
    /// </summary>
    public static string CredentialUid = "@CredentialUid";
    /// <summary>
    /// Returns '@PersonUid'
    /// </summary>
    public static string PersonUid = "@PersonUid";
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
    /// Returns '@CredentialBytes'
    /// </summary>
    public static string CredentialBytes = "@CredentialBytes";
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
    /// Returns '@IsAccessGrantedEvent'
    /// </summary>
    public static string IsAccessGrantedEvent = "@IsAccessGrantedEvent";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}

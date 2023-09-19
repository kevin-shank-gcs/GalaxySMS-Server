using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the AccessPortalActivityEventPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class AccessPortalActivityEventPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private AccessPortalActivityEventPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new AccessPortalActivityEventPDSA Entity
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
    /// Clones the current AccessPortalActivityEventPDSA
    /// </summary>
    /// <returns>A cloned AccessPortalActivityEventPDSA object</returns>
    public AccessPortalActivityEventPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in AccessPortalActivityEventPDSA
    /// </summary>
    /// <param name="entityToClone">The AccessPortalActivityEventPDSA entity to clone</param>
    /// <returns>A cloned AccessPortalActivityEventPDSA object</returns>
    public AccessPortalActivityEventPDSA CloneEntity(AccessPortalActivityEventPDSA entityToClone)
    {
      AccessPortalActivityEventPDSA newEntity = new AccessPortalActivityEventPDSA();

      newEntity.AccessPortalActivityEventUid = entityToClone.AccessPortalActivityEventUid;
      newEntity.GalaxyActivityEventTypeUid = entityToClone.GalaxyActivityEventTypeUid;
      newEntity.AccessPortalUid = entityToClone.AccessPortalUid;
      newEntity.CredentialUid = entityToClone.CredentialUid;
      newEntity.PersonUid = entityToClone.PersonUid;
      newEntity.CpuUid = entityToClone.CpuUid;
      newEntity.CpuNumber = entityToClone.CpuNumber;
      newEntity.ActivityDateTime = entityToClone.ActivityDateTime;
      newEntity.BufferIndex = entityToClone.BufferIndex;
      newEntity.CredentialBytes = entityToClone.CredentialBytes;
      newEntity.InsertDate = entityToClone.InsertDate;

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
      
      props.Add(PDSAProperty.Create(AccessPortalActivityEventPDSAValidator.ColumnNames.AccessPortalActivityEventUid, GetResourceMessage("GCS_AccessPortalActivityEventPDSA_AccessPortalActivityEventUid_Header", "Access Portal Activity Event Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_AccessPortalActivityEventPDSA_AccessPortalActivityEventUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalActivityEventPDSAValidator.ColumnNames.GalaxyActivityEventTypeUid, GetResourceMessage("GCS_AccessPortalActivityEventPDSA_GalaxyActivityEventTypeUid_Header", "Galaxy Activity Event Type Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_AccessPortalActivityEventPDSA_GalaxyActivityEventTypeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalActivityEventPDSAValidator.ColumnNames.AccessPortalUid, GetResourceMessage("GCS_AccessPortalActivityEventPDSA_AccessPortalUid_Header", "Access Portal Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_AccessPortalActivityEventPDSA_AccessPortalUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalActivityEventPDSAValidator.ColumnNames.CredentialUid, GetResourceMessage("GCS_AccessPortalActivityEventPDSA_CredentialUid_Header", "Credential Uid"), false, typeof(Guid), -1, GetResourceMessage("GCS_AccessPortalActivityEventPDSA_CredentialUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalActivityEventPDSAValidator.ColumnNames.PersonUid, GetResourceMessage("GCS_AccessPortalActivityEventPDSA_PersonUid_Header", "Person Uid"), false, typeof(Guid), -1, GetResourceMessage("GCS_AccessPortalActivityEventPDSA_PersonUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalActivityEventPDSAValidator.ColumnNames.CpuUid, GetResourceMessage("GCS_AccessPortalActivityEventPDSA_CpuUid_Header", "Cpu Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_AccessPortalActivityEventPDSA_CpuUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalActivityEventPDSAValidator.ColumnNames.CpuNumber, GetResourceMessage("GCS_AccessPortalActivityEventPDSA_CpuNumber_Header", "Cpu Number"), true, typeof(short), 5, GetResourceMessage("GCS_AccessPortalActivityEventPDSA_CpuNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalActivityEventPDSAValidator.ColumnNames.ActivityDateTime, GetResourceMessage("GCS_AccessPortalActivityEventPDSA_ActivityDateTime_Header", "Activity Date Time"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_AccessPortalActivityEventPDSA_ActivityDateTime_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalActivityEventPDSAValidator.ColumnNames.BufferIndex, GetResourceMessage("GCS_AccessPortalActivityEventPDSA_BufferIndex_Header", "Buffer Index"), true, typeof(int), 10, GetResourceMessage("GCS_AccessPortalActivityEventPDSA_BufferIndex_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalActivityEventPDSAValidator.ColumnNames.CredentialBytes, GetResourceMessage("GCS_AccessPortalActivityEventPDSA_CredentialBytes_Header", "Credential Bytes"), false, typeof(byte[]), 32, GetResourceMessage("GCS_AccessPortalActivityEventPDSA_CredentialBytes_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, null, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalActivityEventPDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_AccessPortalActivityEventPDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_AccessPortalActivityEventPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, DateTimeOffset.Now, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.AccessPortalActivityEventUid = Guid.Empty;
      Entity.GalaxyActivityEventTypeUid = Guid.Empty;
      Entity.AccessPortalUid = Guid.Empty;
      Entity.CredentialUid = Guid.Empty;
      Entity.PersonUid = Guid.Empty;
      Entity.CpuUid = Guid.Empty;
      Entity.CpuNumber = 0;
      Entity.ActivityDateTime = DateTimeOffset.Now;
      Entity.BufferIndex = 0;
      Entity.CredentialBytes = null;
      Entity.InsertDate = DateTimeOffset.Now;

      Entity.ResetAllIsDirtyProperties();
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
        InitProperties();
      
      if(!Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.AccessPortalActivityEventUid).SetAsNull)
        Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.AccessPortalActivityEventUid).Value = Entity.AccessPortalActivityEventUid;
      if(!Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.GalaxyActivityEventTypeUid).SetAsNull)
        Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.GalaxyActivityEventTypeUid).Value = Entity.GalaxyActivityEventTypeUid;
      if(!Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.AccessPortalUid).SetAsNull)
        Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.AccessPortalUid).Value = Entity.AccessPortalUid;
      if(!Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.CredentialUid).SetAsNull)
        Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.CredentialUid).Value = Entity.CredentialUid;
      if(!Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.PersonUid).SetAsNull)
        Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.PersonUid).Value = Entity.PersonUid;
      if(!Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.CpuUid).SetAsNull)
        Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.CpuUid).Value = Entity.CpuUid;
      if(!Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.CpuNumber).SetAsNull)
        Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.CpuNumber).Value = Entity.CpuNumber;
      if(!Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.ActivityDateTime).SetAsNull)
        Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.ActivityDateTime).Value = Entity.ActivityDateTime;
      if(!Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.BufferIndex).SetAsNull)
        Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.BufferIndex).Value = Entity.BufferIndex;
      if(!Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.CredentialBytes).SetAsNull)
        Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.CredentialBytes).Value = Entity.CredentialBytes;
      if(!Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.AccessPortalActivityEventUid).IsNull == false)
        Entity.AccessPortalActivityEventUid = Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.AccessPortalActivityEventUid).GetAsGuid();
      if(Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.GalaxyActivityEventTypeUid).IsNull == false)
        Entity.GalaxyActivityEventTypeUid = Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.GalaxyActivityEventTypeUid).GetAsGuid();
      if(Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.AccessPortalUid).IsNull == false)
        Entity.AccessPortalUid = Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.AccessPortalUid).GetAsGuid();
      if(Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.CredentialUid).IsNull == false)
        Entity.CredentialUid = Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.CredentialUid).GetAsGuid();
      if(Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.PersonUid).IsNull == false)
        Entity.PersonUid = Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.PersonUid).GetAsGuid();
      if(Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.CpuUid).IsNull == false)
        Entity.CpuUid = Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.CpuUid).GetAsGuid();
      if(Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.CpuNumber).IsNull == false)
        Entity.CpuNumber = Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.CpuNumber).GetAsShort();
      if(Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.ActivityDateTime).IsNull == false)
        Entity.ActivityDateTime = Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.ActivityDateTime).GetAsDateTimeOffset();
      if(Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.BufferIndex).IsNull == false)
        Entity.BufferIndex = Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.BufferIndex).GetAsInteger();
      if(Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.CredentialBytes).IsNull == false)
        Entity.CredentialBytes = Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.CredentialBytes).GetAsByteArray();
      if(Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(AccessPortalActivityEventPDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the AccessPortalActivityEventPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'AccessPortalActivityEventUid'
    /// </summary>
    public static string AccessPortalActivityEventUid = "AccessPortalActivityEventUid";
    /// <summary>
    /// Returns 'GalaxyActivityEventTypeUid'
    /// </summary>
    public static string GalaxyActivityEventTypeUid = "GalaxyActivityEventTypeUid";
    /// <summary>
    /// Returns 'AccessPortalUid'
    /// </summary>
    public static string AccessPortalUid = "AccessPortalUid";
    /// <summary>
    /// Returns 'CredentialUid'
    /// </summary>
    public static string CredentialUid = "CredentialUid";
    /// <summary>
    /// Returns 'PersonUid'
    /// </summary>
    public static string PersonUid = "PersonUid";
    /// <summary>
    /// Returns 'CpuUid'
    /// </summary>
    public static string CpuUid = "CpuUid";
    /// <summary>
    /// Returns 'CpuNumber'
    /// </summary>
    public static string CpuNumber = "CpuNumber";
    /// <summary>
    /// Returns 'ActivityDateTime'
    /// </summary>
    public static string ActivityDateTime = "ActivityDateTime";
    /// <summary>
    /// Returns 'BufferIndex'
    /// </summary>
    public static string BufferIndex = "BufferIndex";
    /// <summary>
    /// Returns 'CredentialBytes'
    /// </summary>
    public static string CredentialBytes = "CredentialBytes";
    /// <summary>
    /// Returns 'InsertDate'
    /// </summary>
    public static string InsertDate = "InsertDate";
    }
    #endregion
  }
}

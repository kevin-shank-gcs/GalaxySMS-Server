using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the AccessPortalActivityAlarmEventPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class AccessPortalActivityAlarmEventPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private AccessPortalActivityAlarmEventPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new AccessPortalActivityAlarmEventPDSA Entity
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
    /// Clones the current AccessPortalActivityAlarmEventPDSA
    /// </summary>
    /// <returns>A cloned AccessPortalActivityAlarmEventPDSA object</returns>
    public AccessPortalActivityAlarmEventPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in AccessPortalActivityAlarmEventPDSA
    /// </summary>
    /// <param name="entityToClone">The AccessPortalActivityAlarmEventPDSA entity to clone</param>
    /// <returns>A cloned AccessPortalActivityAlarmEventPDSA object</returns>
    public AccessPortalActivityAlarmEventPDSA CloneEntity(AccessPortalActivityAlarmEventPDSA entityToClone)
    {
      AccessPortalActivityAlarmEventPDSA newEntity = new AccessPortalActivityAlarmEventPDSA();

      newEntity.AccessPortalActivityEventUid = entityToClone.AccessPortalActivityEventUid;
      newEntity.NoteUid = entityToClone.NoteUid;
      newEntity.BinaryResourceUid = entityToClone.BinaryResourceUid;
      newEntity.AlarmPriority = entityToClone.AlarmPriority;
      newEntity.AccessPortalUid = entityToClone.AccessPortalUid;

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
      
      props.Add(PDSAProperty.Create(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.AccessPortalActivityEventUid, GetResourceMessage("GCS_AccessPortalActivityAlarmEventPDSA_AccessPortalActivityEventUid_Header", "Access Portal Activity Event Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_AccessPortalActivityAlarmEventPDSA_AccessPortalActivityEventUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.NoteUid, GetResourceMessage("GCS_AccessPortalActivityAlarmEventPDSA_NoteUid_Header", "Note Uid"), false, typeof(Guid), -1, GetResourceMessage("GCS_AccessPortalActivityAlarmEventPDSA_NoteUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.BinaryResourceUid, GetResourceMessage("GCS_AccessPortalActivityAlarmEventPDSA_BinaryResourceUid_Header", "Binary Resource Uid"), false, typeof(Guid), -1, GetResourceMessage("GCS_AccessPortalActivityAlarmEventPDSA_BinaryResourceUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.AlarmPriority, GetResourceMessage("GCS_AccessPortalActivityAlarmEventPDSA_AlarmPriority_Header", "Alarm Priority"), true, typeof(int), 10, GetResourceMessage("GCS_AccessPortalActivityAlarmEventPDSA_AlarmPriority_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.AccessPortalUid, GetResourceMessage("GCS_AccessPortalActivityAlarmEventPDSA_AccessPortalUid_Header", "Access Portal Uid"), false, typeof(Guid), 2147483647, GetResourceMessage("GCS_AccessPortalActivityAlarmEventPDSA_AccessPortalUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      
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
      Entity.NoteUid = Guid.Empty;
      Entity.BinaryResourceUid = Guid.Empty;
      Entity.AlarmPriority = 0;
      Entity.AccessPortalUid = Guid.Empty;

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
      
      if(!Properties.GetByName(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.AccessPortalActivityEventUid).SetAsNull)
        Properties.GetByName(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.AccessPortalActivityEventUid).Value = Entity.AccessPortalActivityEventUid;
      if(!Properties.GetByName(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.NoteUid).SetAsNull)
        Properties.GetByName(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.NoteUid).Value = Entity.NoteUid;
      if(!Properties.GetByName(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.BinaryResourceUid).SetAsNull)
        Properties.GetByName(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.BinaryResourceUid).Value = Entity.BinaryResourceUid;
      if(!Properties.GetByName(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.AlarmPriority).SetAsNull)
        Properties.GetByName(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.AlarmPriority).Value = Entity.AlarmPriority;
      if(!Properties.GetByName(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.AccessPortalUid).SetAsNull)
        Properties.GetByName(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.AccessPortalUid).Value = Entity.AccessPortalUid;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.AccessPortalActivityEventUid).IsNull == false)
        Entity.AccessPortalActivityEventUid = Properties.GetByName(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.AccessPortalActivityEventUid).GetAsGuid();
      if(Properties.GetByName(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.NoteUid).IsNull == false)
        Entity.NoteUid = Properties.GetByName(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.NoteUid).GetAsGuid();
      if(Properties.GetByName(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.BinaryResourceUid).IsNull == false)
        Entity.BinaryResourceUid = Properties.GetByName(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.BinaryResourceUid).GetAsGuid();
      if(Properties.GetByName(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.AlarmPriority).IsNull == false)
        Entity.AlarmPriority = Properties.GetByName(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.AlarmPriority).GetAsInteger();
      if(Properties.GetByName(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.AccessPortalUid).IsNull == false)
        Entity.AccessPortalUid = Properties.GetByName(AccessPortalActivityAlarmEventPDSAValidator.ColumnNames.AccessPortalUid).GetAsGuid();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the AccessPortalActivityAlarmEventPDSA class.
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
    /// Returns 'NoteUid'
    /// </summary>
    public static string NoteUid = "NoteUid";
    /// <summary>
    /// Returns 'BinaryResourceUid'
    /// </summary>
    public static string BinaryResourceUid = "BinaryResourceUid";
    /// <summary>
    /// Returns 'AlarmPriority'
    /// </summary>
    public static string AlarmPriority = "AlarmPriority";
    /// <summary>
    /// Returns 'AccessPortalUid'
    /// </summary>
    public static string AccessPortalUid = "AccessPortalUid";
    }
    #endregion
  }
}

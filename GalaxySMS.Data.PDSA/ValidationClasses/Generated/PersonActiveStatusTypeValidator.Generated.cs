using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the PersonActiveStatusTypePDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class PersonActiveStatusTypePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private PersonActiveStatusTypePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new PersonActiveStatusTypePDSA Entity
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
    /// Clones the current PersonActiveStatusTypePDSA
    /// </summary>
    /// <returns>A cloned PersonActiveStatusTypePDSA object</returns>
    public PersonActiveStatusTypePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in PersonActiveStatusTypePDSA
    /// </summary>
    /// <param name="entityToClone">The PersonActiveStatusTypePDSA entity to clone</param>
    /// <returns>A cloned PersonActiveStatusTypePDSA object</returns>
    public PersonActiveStatusTypePDSA CloneEntity(PersonActiveStatusTypePDSA entityToClone)
    {
      PersonActiveStatusTypePDSA newEntity = new PersonActiveStatusTypePDSA();

      newEntity.PersonActiveStatusTypeUid = entityToClone.PersonActiveStatusTypeUid;
      newEntity.EntityId = entityToClone.EntityId;
      newEntity.DisplayResourceKey = entityToClone.DisplayResourceKey;
      newEntity.DescriptionResourceKey = entityToClone.DescriptionResourceKey;
      newEntity.Display = entityToClone.Display;
      newEntity.Description = entityToClone.Description;
      newEntity.PersonInactiveState = entityToClone.PersonInactiveState;
      newEntity.InsertName = entityToClone.InsertName;
      newEntity.InsertDate = entityToClone.InsertDate;
      newEntity.UpdateName = entityToClone.UpdateName;
      newEntity.UpdateDate = entityToClone.UpdateDate;
      newEntity.ConcurrencyValue = entityToClone.ConcurrencyValue;
      newEntity.CultureName = entityToClone.CultureName;

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
      
      props.Add(PDSAProperty.Create(PersonActiveStatusTypePDSAValidator.ColumnNames.PersonActiveStatusTypeUid, GetResourceMessage("GCS_PersonActiveStatusTypePDSA_PersonActiveStatusTypeUid_Header", "Person Active Status Type Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_PersonActiveStatusTypePDSA_PersonActiveStatusTypeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonActiveStatusTypePDSAValidator.ColumnNames.EntityId, GetResourceMessage("GCS_PersonActiveStatusTypePDSA_EntityId_Header", "Entity Id"), true, typeof(Guid), -1, GetResourceMessage("GCS_PersonActiveStatusTypePDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonActiveStatusTypePDSAValidator.ColumnNames.DisplayResourceKey, GetResourceMessage("GCS_PersonActiveStatusTypePDSA_DisplayResourceKey_Header", "Display Resource Key"), false, typeof(Guid), -1, GetResourceMessage("GCS_PersonActiveStatusTypePDSA_DisplayResourceKey_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonActiveStatusTypePDSAValidator.ColumnNames.DescriptionResourceKey, GetResourceMessage("GCS_PersonActiveStatusTypePDSA_DescriptionResourceKey_Header", "Description Resource Key"), false, typeof(Guid), -1, GetResourceMessage("GCS_PersonActiveStatusTypePDSA_DescriptionResourceKey_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonActiveStatusTypePDSAValidator.ColumnNames.Display, GetResourceMessage("GCS_PersonActiveStatusTypePDSA_Display_Header", "Display"), true, typeof(string), 65, GetResourceMessage("GCS_PersonActiveStatusTypePDSA_Display_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonActiveStatusTypePDSAValidator.ColumnNames.Description, GetResourceMessage("GCS_PersonActiveStatusTypePDSA_Description_Header", "Description"), true, typeof(string), 1000, GetResourceMessage("GCS_PersonActiveStatusTypePDSA_Description_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonActiveStatusTypePDSAValidator.ColumnNames.PersonInactiveState, GetResourceMessage("GCS_PersonActiveStatusTypePDSA_PersonInactiveState_Header", "Person Inactive State"), true, typeof(bool?), -1, GetResourceMessage("GCS_PersonActiveStatusTypePDSA_PersonInactiveState_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(PersonActiveStatusTypePDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_PersonActiveStatusTypePDSA_InsertName_Header", "Insert Name"), true, typeof(string), 100, GetResourceMessage("GCS_PersonActiveStatusTypePDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonActiveStatusTypePDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_PersonActiveStatusTypePDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_PersonActiveStatusTypePDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(PersonActiveStatusTypePDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_PersonActiveStatusTypePDSA_UpdateName_Header", "Update Name"), true, typeof(string), 100, GetResourceMessage("GCS_PersonActiveStatusTypePDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonActiveStatusTypePDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_PersonActiveStatusTypePDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_PersonActiveStatusTypePDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(PersonActiveStatusTypePDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_PersonActiveStatusTypePDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_PersonActiveStatusTypePDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(PersonActiveStatusTypePDSAValidator.ColumnNames.CultureName, GetResourceMessage("GCS_PersonActiveStatusTypePDSA_CultureName_Header", "Culture Name"), false, typeof(string), 2147483647, GetResourceMessage("GCS_PersonActiveStatusTypePDSA_CultureName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.PersonActiveStatusTypeUid = Guid.Empty;
      Entity.EntityId = Guid.Empty;
      Entity.DisplayResourceKey = Guid.Empty;
      Entity.DescriptionResourceKey = Guid.Empty;
      Entity.Display = string.Empty;
      Entity.Description = string.Empty;
      Entity.PersonInactiveState = false;
      Entity.InsertName = string.Empty;
      Entity.InsertDate = DateTimeOffset.Now;
      Entity.UpdateName = string.Empty;
      Entity.UpdateDate = DateTimeOffset.Now;
      Entity.ConcurrencyValue = 0;
      Entity.CultureName = string.Empty;

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
      
      if(!Properties.GetByName(PersonActiveStatusTypePDSAValidator.ColumnNames.PersonActiveStatusTypeUid).SetAsNull)
        Properties.GetByName(PersonActiveStatusTypePDSAValidator.ColumnNames.PersonActiveStatusTypeUid).Value = Entity.PersonActiveStatusTypeUid;
      if(!Properties.GetByName(PersonActiveStatusTypePDSAValidator.ColumnNames.EntityId).SetAsNull)
        Properties.GetByName(PersonActiveStatusTypePDSAValidator.ColumnNames.EntityId).Value = Entity.EntityId;
      if(!Properties.GetByName(PersonActiveStatusTypePDSAValidator.ColumnNames.DisplayResourceKey).SetAsNull)
        Properties.GetByName(PersonActiveStatusTypePDSAValidator.ColumnNames.DisplayResourceKey).Value = Entity.DisplayResourceKey;
      if(!Properties.GetByName(PersonActiveStatusTypePDSAValidator.ColumnNames.DescriptionResourceKey).SetAsNull)
        Properties.GetByName(PersonActiveStatusTypePDSAValidator.ColumnNames.DescriptionResourceKey).Value = Entity.DescriptionResourceKey;
      if(!Properties.GetByName(PersonActiveStatusTypePDSAValidator.ColumnNames.Display).SetAsNull)
        Properties.GetByName(PersonActiveStatusTypePDSAValidator.ColumnNames.Display).Value = Entity.Display;
      if(!Properties.GetByName(PersonActiveStatusTypePDSAValidator.ColumnNames.Description).SetAsNull)
        Properties.GetByName(PersonActiveStatusTypePDSAValidator.ColumnNames.Description).Value = Entity.Description;
      if(!Properties.GetByName(PersonActiveStatusTypePDSAValidator.ColumnNames.PersonInactiveState).SetAsNull)
        Properties.GetByName(PersonActiveStatusTypePDSAValidator.ColumnNames.PersonInactiveState).Value = Entity.PersonInactiveState;
      if(!Properties.GetByName(PersonActiveStatusTypePDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(PersonActiveStatusTypePDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(PersonActiveStatusTypePDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(PersonActiveStatusTypePDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(PersonActiveStatusTypePDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(PersonActiveStatusTypePDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(PersonActiveStatusTypePDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(PersonActiveStatusTypePDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(PersonActiveStatusTypePDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(PersonActiveStatusTypePDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
      if(!Properties.GetByName(PersonActiveStatusTypePDSAValidator.ColumnNames.CultureName).SetAsNull)
        Properties.GetByName(PersonActiveStatusTypePDSAValidator.ColumnNames.CultureName).Value = Entity.CultureName;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(PersonActiveStatusTypePDSAValidator.ColumnNames.PersonActiveStatusTypeUid).IsNull == false)
        Entity.PersonActiveStatusTypeUid = Properties.GetByName(PersonActiveStatusTypePDSAValidator.ColumnNames.PersonActiveStatusTypeUid).GetAsGuid();
      if(Properties.GetByName(PersonActiveStatusTypePDSAValidator.ColumnNames.EntityId).IsNull == false)
        Entity.EntityId = Properties.GetByName(PersonActiveStatusTypePDSAValidator.ColumnNames.EntityId).GetAsGuid();
      if(Properties.GetByName(PersonActiveStatusTypePDSAValidator.ColumnNames.DisplayResourceKey).IsNull == false)
        Entity.DisplayResourceKey = Properties.GetByName(PersonActiveStatusTypePDSAValidator.ColumnNames.DisplayResourceKey).GetAsGuid();
      if(Properties.GetByName(PersonActiveStatusTypePDSAValidator.ColumnNames.DescriptionResourceKey).IsNull == false)
        Entity.DescriptionResourceKey = Properties.GetByName(PersonActiveStatusTypePDSAValidator.ColumnNames.DescriptionResourceKey).GetAsGuid();
      if(Properties.GetByName(PersonActiveStatusTypePDSAValidator.ColumnNames.Display).IsNull == false)
        Entity.Display = Properties.GetByName(PersonActiveStatusTypePDSAValidator.ColumnNames.Display).GetAsString();
      if(Properties.GetByName(PersonActiveStatusTypePDSAValidator.ColumnNames.Description).IsNull == false)
        Entity.Description = Properties.GetByName(PersonActiveStatusTypePDSAValidator.ColumnNames.Description).GetAsString();
      if(Properties.GetByName(PersonActiveStatusTypePDSAValidator.ColumnNames.PersonInactiveState).IsNull == false)
        Entity.PersonInactiveState = Properties.GetByName(PersonActiveStatusTypePDSAValidator.ColumnNames.PersonInactiveState).GetValueAsBoolean();
      if(Properties.GetByName(PersonActiveStatusTypePDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(PersonActiveStatusTypePDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(PersonActiveStatusTypePDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(PersonActiveStatusTypePDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(PersonActiveStatusTypePDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(PersonActiveStatusTypePDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(PersonActiveStatusTypePDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(PersonActiveStatusTypePDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(PersonActiveStatusTypePDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(PersonActiveStatusTypePDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
      if(Properties.GetByName(PersonActiveStatusTypePDSAValidator.ColumnNames.CultureName).IsNull == false)
        Entity.CultureName = Properties.GetByName(PersonActiveStatusTypePDSAValidator.ColumnNames.CultureName).GetAsString();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the PersonActiveStatusTypePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'PersonActiveStatusTypeUid'
    /// </summary>
    public static string PersonActiveStatusTypeUid = "PersonActiveStatusTypeUid";
    /// <summary>
    /// Returns 'EntityId'
    /// </summary>
    public static string EntityId = "EntityId";
    /// <summary>
    /// Returns 'DisplayResourceKey'
    /// </summary>
    public static string DisplayResourceKey = "DisplayResourceKey";
    /// <summary>
    /// Returns 'DescriptionResourceKey'
    /// </summary>
    public static string DescriptionResourceKey = "DescriptionResourceKey";
    /// <summary>
    /// Returns 'Display'
    /// </summary>
    public static string Display = "Display";
    /// <summary>
    /// Returns 'Description'
    /// </summary>
    public static string Description = "Description";
    /// <summary>
    /// Returns 'PersonInactiveState'
    /// </summary>
    public static string PersonInactiveState = "PersonInactiveState";
    /// <summary>
    /// Returns 'InsertName'
    /// </summary>
    public static string InsertName = "InsertName";
    /// <summary>
    /// Returns 'InsertDate'
    /// </summary>
    public static string InsertDate = "InsertDate";
    /// <summary>
    /// Returns 'UpdateName'
    /// </summary>
    public static string UpdateName = "UpdateName";
    /// <summary>
    /// Returns 'UpdateDate'
    /// </summary>
    public static string UpdateDate = "UpdateDate";
    /// <summary>
    /// Returns 'ConcurrencyValue'
    /// </summary>
    public static string ConcurrencyValue = "ConcurrencyValue";
    /// <summary>
    /// Returns 'CultureName'
    /// </summary>
    public static string CultureName = "CultureName";
    }
    #endregion
  }
}

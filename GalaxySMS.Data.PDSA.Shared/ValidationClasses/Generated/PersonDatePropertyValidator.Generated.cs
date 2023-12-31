using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the PersonDatePropertyPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class PersonDatePropertyPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private PersonDatePropertyPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new PersonDatePropertyPDSA Entity
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
    /// Clones the current PersonDatePropertyPDSA
    /// </summary>
    /// <returns>A cloned PersonDatePropertyPDSA object</returns>
    public PersonDatePropertyPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in PersonDatePropertyPDSA
    /// </summary>
    /// <param name="entityToClone">The PersonDatePropertyPDSA entity to clone</param>
    /// <returns>A cloned PersonDatePropertyPDSA object</returns>
    public PersonDatePropertyPDSA CloneEntity(PersonDatePropertyPDSA entityToClone)
    {
      PersonDatePropertyPDSA newEntity = new PersonDatePropertyPDSA();

      newEntity.PersonDatePropertyUid = entityToClone.PersonDatePropertyUid;
      newEntity.PersonUid = entityToClone.PersonUid;
      newEntity.UserDefinedPropertyUid = entityToClone.UserDefinedPropertyUid;
      newEntity.Value = entityToClone.Value;
      newEntity.InsertName = entityToClone.InsertName;
      newEntity.InsertDate = entityToClone.InsertDate;
      newEntity.UpdateName = entityToClone.UpdateName;
      newEntity.UpdateDate = entityToClone.UpdateDate;
      newEntity.ConcurrencyValue = entityToClone.ConcurrencyValue;

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
      
      props.Add(PDSAProperty.Create(PersonDatePropertyPDSAValidator.ColumnNames.PersonDatePropertyUid, GetResourceMessage("GCS_PersonDatePropertyPDSA_PersonDatePropertyUid_Header", "Person Date Property Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_PersonDatePropertyPDSA_PersonDatePropertyUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonDatePropertyPDSAValidator.ColumnNames.PersonUid, GetResourceMessage("GCS_PersonDatePropertyPDSA_PersonUid_Header", "Person Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_PersonDatePropertyPDSA_PersonUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonDatePropertyPDSAValidator.ColumnNames.UserDefinedPropertyUid, GetResourceMessage("GCS_PersonDatePropertyPDSA_UserDefinedPropertyUid_Header", "User Defined Property Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_PersonDatePropertyPDSA_UserDefinedPropertyUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonDatePropertyPDSAValidator.ColumnNames.Value, GetResourceMessage("GCS_PersonDatePropertyPDSA_Value_Header", "Value"), false, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_PersonDatePropertyPDSA_Value_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(PersonDatePropertyPDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_PersonDatePropertyPDSA_InsertName_Header", "Insert Name"), true, typeof(string), 50, GetResourceMessage("GCS_PersonDatePropertyPDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonDatePropertyPDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_PersonDatePropertyPDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_PersonDatePropertyPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(PersonDatePropertyPDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_PersonDatePropertyPDSA_UpdateName_Header", "Update Name"), true, typeof(string), 50, GetResourceMessage("GCS_PersonDatePropertyPDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonDatePropertyPDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_PersonDatePropertyPDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_PersonDatePropertyPDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(PersonDatePropertyPDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_PersonDatePropertyPDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_PersonDatePropertyPDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.PersonDatePropertyUid = Guid.Empty;
      Entity.PersonUid = Guid.Empty;
      Entity.UserDefinedPropertyUid = Guid.Empty;
      Entity.Value = DateTimeOffset.Now;
      Entity.InsertName = string.Empty;
      Entity.InsertDate = DateTimeOffset.Now;
      Entity.UpdateName = string.Empty;
      Entity.UpdateDate = DateTimeOffset.Now;
      Entity.ConcurrencyValue = 0;

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
      
      if(!Properties.GetByName(PersonDatePropertyPDSAValidator.ColumnNames.PersonDatePropertyUid).SetAsNull)
        Properties.GetByName(PersonDatePropertyPDSAValidator.ColumnNames.PersonDatePropertyUid).Value = Entity.PersonDatePropertyUid;
      if(!Properties.GetByName(PersonDatePropertyPDSAValidator.ColumnNames.PersonUid).SetAsNull)
        Properties.GetByName(PersonDatePropertyPDSAValidator.ColumnNames.PersonUid).Value = Entity.PersonUid;
      if(!Properties.GetByName(PersonDatePropertyPDSAValidator.ColumnNames.UserDefinedPropertyUid).SetAsNull)
        Properties.GetByName(PersonDatePropertyPDSAValidator.ColumnNames.UserDefinedPropertyUid).Value = Entity.UserDefinedPropertyUid;
      if(!Properties.GetByName(PersonDatePropertyPDSAValidator.ColumnNames.Value).SetAsNull)
        Properties.GetByName(PersonDatePropertyPDSAValidator.ColumnNames.Value).Value = Entity.Value;
      if(!Properties.GetByName(PersonDatePropertyPDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(PersonDatePropertyPDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(PersonDatePropertyPDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(PersonDatePropertyPDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(PersonDatePropertyPDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(PersonDatePropertyPDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(PersonDatePropertyPDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(PersonDatePropertyPDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(PersonDatePropertyPDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(PersonDatePropertyPDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(PersonDatePropertyPDSAValidator.ColumnNames.PersonDatePropertyUid).IsNull == false)
        Entity.PersonDatePropertyUid = Properties.GetByName(PersonDatePropertyPDSAValidator.ColumnNames.PersonDatePropertyUid).GetAsGuid();
      if(Properties.GetByName(PersonDatePropertyPDSAValidator.ColumnNames.PersonUid).IsNull == false)
        Entity.PersonUid = Properties.GetByName(PersonDatePropertyPDSAValidator.ColumnNames.PersonUid).GetAsGuid();
      if(Properties.GetByName(PersonDatePropertyPDSAValidator.ColumnNames.UserDefinedPropertyUid).IsNull == false)
        Entity.UserDefinedPropertyUid = Properties.GetByName(PersonDatePropertyPDSAValidator.ColumnNames.UserDefinedPropertyUid).GetAsGuid();
      if(Properties.GetByName(PersonDatePropertyPDSAValidator.ColumnNames.Value).IsNull == false)
        Entity.Value = Properties.GetByName(PersonDatePropertyPDSAValidator.ColumnNames.Value).GetAsDateTimeOffset();
      if(Properties.GetByName(PersonDatePropertyPDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(PersonDatePropertyPDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(PersonDatePropertyPDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(PersonDatePropertyPDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(PersonDatePropertyPDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(PersonDatePropertyPDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(PersonDatePropertyPDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(PersonDatePropertyPDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(PersonDatePropertyPDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(PersonDatePropertyPDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the PersonDatePropertyPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'PersonDatePropertyUid'
    /// </summary>
    public static string PersonDatePropertyUid = "PersonDatePropertyUid";
    /// <summary>
    /// Returns 'PersonUid'
    /// </summary>
    public static string PersonUid = "PersonUid";
    /// <summary>
    /// Returns 'UserDefinedPropertyUid'
    /// </summary>
    public static string UserDefinedPropertyUid = "UserDefinedPropertyUid";
    /// <summary>
    /// Returns 'Value'
    /// </summary>
    public static string Value = "Value";
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
    }
    #endregion
  }
}

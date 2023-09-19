using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the PersonNumberPropertyPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class PersonNumberPropertyPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private PersonNumberPropertyPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new PersonNumberPropertyPDSA Entity
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
    /// Clones the current PersonNumberPropertyPDSA
    /// </summary>
    /// <returns>A cloned PersonNumberPropertyPDSA object</returns>
    public PersonNumberPropertyPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in PersonNumberPropertyPDSA
    /// </summary>
    /// <param name="entityToClone">The PersonNumberPropertyPDSA entity to clone</param>
    /// <returns>A cloned PersonNumberPropertyPDSA object</returns>
    public PersonNumberPropertyPDSA CloneEntity(PersonNumberPropertyPDSA entityToClone)
    {
      PersonNumberPropertyPDSA newEntity = new PersonNumberPropertyPDSA();

      newEntity.PersonNumberPropertyUid = entityToClone.PersonNumberPropertyUid;
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
      
      props.Add(PDSAProperty.Create(PersonNumberPropertyPDSAValidator.ColumnNames.PersonNumberPropertyUid, GetResourceMessage("GCS_PersonNumberPropertyPDSA_PersonNumberPropertyUid_Header", "Person Number Property Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_PersonNumberPropertyPDSA_PersonNumberPropertyUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonNumberPropertyPDSAValidator.ColumnNames.PersonUid, GetResourceMessage("GCS_PersonNumberPropertyPDSA_PersonUid_Header", "Person Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_PersonNumberPropertyPDSA_PersonUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonNumberPropertyPDSAValidator.ColumnNames.UserDefinedPropertyUid, GetResourceMessage("GCS_PersonNumberPropertyPDSA_UserDefinedPropertyUid_Header", "User Defined Property Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_PersonNumberPropertyPDSA_UserDefinedPropertyUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonNumberPropertyPDSAValidator.ColumnNames.Value, GetResourceMessage("GCS_PersonNumberPropertyPDSA_Value_Header", "Value"), false, typeof(int), 10, GetResourceMessage("GCS_PersonNumberPropertyPDSA_Value_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(PersonNumberPropertyPDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_PersonNumberPropertyPDSA_InsertName_Header", "Insert Name"), true, typeof(string), 50, GetResourceMessage("GCS_PersonNumberPropertyPDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonNumberPropertyPDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_PersonNumberPropertyPDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_PersonNumberPropertyPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(PersonNumberPropertyPDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_PersonNumberPropertyPDSA_UpdateName_Header", "Update Name"), true, typeof(string), 50, GetResourceMessage("GCS_PersonNumberPropertyPDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonNumberPropertyPDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_PersonNumberPropertyPDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_PersonNumberPropertyPDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(PersonNumberPropertyPDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_PersonNumberPropertyPDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_PersonNumberPropertyPDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.PersonNumberPropertyUid = Guid.Empty;
      Entity.PersonUid = Guid.Empty;
      Entity.UserDefinedPropertyUid = Guid.Empty;
      Entity.Value = 0;
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
      
      if(!Properties.GetByName(PersonNumberPropertyPDSAValidator.ColumnNames.PersonNumberPropertyUid).SetAsNull)
        Properties.GetByName(PersonNumberPropertyPDSAValidator.ColumnNames.PersonNumberPropertyUid).Value = Entity.PersonNumberPropertyUid;
      if(!Properties.GetByName(PersonNumberPropertyPDSAValidator.ColumnNames.PersonUid).SetAsNull)
        Properties.GetByName(PersonNumberPropertyPDSAValidator.ColumnNames.PersonUid).Value = Entity.PersonUid;
      if(!Properties.GetByName(PersonNumberPropertyPDSAValidator.ColumnNames.UserDefinedPropertyUid).SetAsNull)
        Properties.GetByName(PersonNumberPropertyPDSAValidator.ColumnNames.UserDefinedPropertyUid).Value = Entity.UserDefinedPropertyUid;
      if(!Properties.GetByName(PersonNumberPropertyPDSAValidator.ColumnNames.Value).SetAsNull)
        Properties.GetByName(PersonNumberPropertyPDSAValidator.ColumnNames.Value).Value = Entity.Value;
      if(!Properties.GetByName(PersonNumberPropertyPDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(PersonNumberPropertyPDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(PersonNumberPropertyPDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(PersonNumberPropertyPDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(PersonNumberPropertyPDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(PersonNumberPropertyPDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(PersonNumberPropertyPDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(PersonNumberPropertyPDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(PersonNumberPropertyPDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(PersonNumberPropertyPDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(PersonNumberPropertyPDSAValidator.ColumnNames.PersonNumberPropertyUid).IsNull == false)
        Entity.PersonNumberPropertyUid = Properties.GetByName(PersonNumberPropertyPDSAValidator.ColumnNames.PersonNumberPropertyUid).GetAsGuid();
      if(Properties.GetByName(PersonNumberPropertyPDSAValidator.ColumnNames.PersonUid).IsNull == false)
        Entity.PersonUid = Properties.GetByName(PersonNumberPropertyPDSAValidator.ColumnNames.PersonUid).GetAsGuid();
      if(Properties.GetByName(PersonNumberPropertyPDSAValidator.ColumnNames.UserDefinedPropertyUid).IsNull == false)
        Entity.UserDefinedPropertyUid = Properties.GetByName(PersonNumberPropertyPDSAValidator.ColumnNames.UserDefinedPropertyUid).GetAsGuid();
      if(Properties.GetByName(PersonNumberPropertyPDSAValidator.ColumnNames.Value).IsNull == false)
        Entity.Value = Properties.GetByName(PersonNumberPropertyPDSAValidator.ColumnNames.Value).GetAsInteger();
      if(Properties.GetByName(PersonNumberPropertyPDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(PersonNumberPropertyPDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(PersonNumberPropertyPDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(PersonNumberPropertyPDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(PersonNumberPropertyPDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(PersonNumberPropertyPDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(PersonNumberPropertyPDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(PersonNumberPropertyPDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(PersonNumberPropertyPDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(PersonNumberPropertyPDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the PersonNumberPropertyPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'PersonNumberPropertyUid'
    /// </summary>
    public static string PersonNumberPropertyUid = "PersonNumberPropertyUid";
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

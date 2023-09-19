using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the PersonAddressPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class PersonAddressPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private PersonAddressPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new PersonAddressPDSA Entity
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
    /// Clones the current PersonAddressPDSA
    /// </summary>
    /// <returns>A cloned PersonAddressPDSA object</returns>
    public PersonAddressPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in PersonAddressPDSA
    /// </summary>
    /// <param name="entityToClone">The PersonAddressPDSA entity to clone</param>
    /// <returns>A cloned PersonAddressPDSA object</returns>
    public PersonAddressPDSA CloneEntity(PersonAddressPDSA entityToClone)
    {
      PersonAddressPDSA newEntity = new PersonAddressPDSA();

      newEntity.PersonAddressUid = entityToClone.PersonAddressUid;
      newEntity.PersonUid = entityToClone.PersonUid;
      newEntity.AddressUid = entityToClone.AddressUid;
      newEntity.Label = entityToClone.Label;
      newEntity.IsCurrent = entityToClone.IsCurrent;
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
      
      props.Add(PDSAProperty.Create(PersonAddressPDSAValidator.ColumnNames.PersonAddressUid, GetResourceMessage("GCS_PersonAddressPDSA_PersonAddressUid_Header", "Person Address Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_PersonAddressPDSA_PersonAddressUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonAddressPDSAValidator.ColumnNames.PersonUid, GetResourceMessage("GCS_PersonAddressPDSA_PersonUid_Header", "Person Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_PersonAddressPDSA_PersonUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonAddressPDSAValidator.ColumnNames.AddressUid, GetResourceMessage("GCS_PersonAddressPDSA_AddressUid_Header", "Address Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_PersonAddressPDSA_AddressUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonAddressPDSAValidator.ColumnNames.Label, GetResourceMessage("GCS_PersonAddressPDSA_Label_Header", "Label"), true, typeof(string), 65, GetResourceMessage("GCS_PersonAddressPDSA_Label_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonAddressPDSAValidator.ColumnNames.IsCurrent, GetResourceMessage("GCS_PersonAddressPDSA_IsCurrent_Header", "Is Current"), true, typeof(bool), -1, GetResourceMessage("GCS_PersonAddressPDSA_IsCurrent_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(PersonAddressPDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_PersonAddressPDSA_InsertName_Header", "Insert Name"), true, typeof(string), 100, GetResourceMessage("GCS_PersonAddressPDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonAddressPDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_PersonAddressPDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_PersonAddressPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(PersonAddressPDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_PersonAddressPDSA_UpdateName_Header", "Update Name"), true, typeof(string), 100, GetResourceMessage("GCS_PersonAddressPDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonAddressPDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_PersonAddressPDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_PersonAddressPDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(PersonAddressPDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_PersonAddressPDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_PersonAddressPDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.PersonAddressUid = Guid.Empty;
      Entity.PersonUid = Guid.Empty;
      Entity.AddressUid = Guid.Empty;
      Entity.Label = string.Empty;
      Entity.IsCurrent = false;
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
      
      if(!Properties.GetByName(PersonAddressPDSAValidator.ColumnNames.PersonAddressUid).SetAsNull)
        Properties.GetByName(PersonAddressPDSAValidator.ColumnNames.PersonAddressUid).Value = Entity.PersonAddressUid;
      if(!Properties.GetByName(PersonAddressPDSAValidator.ColumnNames.PersonUid).SetAsNull)
        Properties.GetByName(PersonAddressPDSAValidator.ColumnNames.PersonUid).Value = Entity.PersonUid;
      if(!Properties.GetByName(PersonAddressPDSAValidator.ColumnNames.AddressUid).SetAsNull)
        Properties.GetByName(PersonAddressPDSAValidator.ColumnNames.AddressUid).Value = Entity.AddressUid;
      if(!Properties.GetByName(PersonAddressPDSAValidator.ColumnNames.Label).SetAsNull)
        Properties.GetByName(PersonAddressPDSAValidator.ColumnNames.Label).Value = Entity.Label;
      if(!Properties.GetByName(PersonAddressPDSAValidator.ColumnNames.IsCurrent).SetAsNull)
        Properties.GetByName(PersonAddressPDSAValidator.ColumnNames.IsCurrent).Value = Entity.IsCurrent;
      if(!Properties.GetByName(PersonAddressPDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(PersonAddressPDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(PersonAddressPDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(PersonAddressPDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(PersonAddressPDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(PersonAddressPDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(PersonAddressPDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(PersonAddressPDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(PersonAddressPDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(PersonAddressPDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(PersonAddressPDSAValidator.ColumnNames.PersonAddressUid).IsNull == false)
        Entity.PersonAddressUid = Properties.GetByName(PersonAddressPDSAValidator.ColumnNames.PersonAddressUid).GetAsGuid();
      if(Properties.GetByName(PersonAddressPDSAValidator.ColumnNames.PersonUid).IsNull == false)
        Entity.PersonUid = Properties.GetByName(PersonAddressPDSAValidator.ColumnNames.PersonUid).GetAsGuid();
      if(Properties.GetByName(PersonAddressPDSAValidator.ColumnNames.AddressUid).IsNull == false)
        Entity.AddressUid = Properties.GetByName(PersonAddressPDSAValidator.ColumnNames.AddressUid).GetAsGuid();
      if(Properties.GetByName(PersonAddressPDSAValidator.ColumnNames.Label).IsNull == false)
        Entity.Label = Properties.GetByName(PersonAddressPDSAValidator.ColumnNames.Label).GetAsString();
      if(Properties.GetByName(PersonAddressPDSAValidator.ColumnNames.IsCurrent).IsNull == false)
        Entity.IsCurrent = Properties.GetByName(PersonAddressPDSAValidator.ColumnNames.IsCurrent).GetAsBool();
      if(Properties.GetByName(PersonAddressPDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(PersonAddressPDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(PersonAddressPDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(PersonAddressPDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(PersonAddressPDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(PersonAddressPDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(PersonAddressPDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(PersonAddressPDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(PersonAddressPDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(PersonAddressPDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the PersonAddressPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'PersonAddressUid'
    /// </summary>
    public static string PersonAddressUid = "PersonAddressUid";
    /// <summary>
    /// Returns 'PersonUid'
    /// </summary>
    public static string PersonUid = "PersonUid";
    /// <summary>
    /// Returns 'AddressUid'
    /// </summary>
    public static string AddressUid = "AddressUid";
    /// <summary>
    /// Returns 'Label'
    /// </summary>
    public static string Label = "Label";
    /// <summary>
    /// Returns 'IsCurrent'
    /// </summary>
    public static string IsCurrent = "IsCurrent";
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

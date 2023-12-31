using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the UserDefinedTextPropertyRulesPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class UserDefinedTextPropertyRulesPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private UserDefinedTextPropertyRulesPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new UserDefinedTextPropertyRulesPDSA Entity
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
    /// Clones the current UserDefinedTextPropertyRulesPDSA
    /// </summary>
    /// <returns>A cloned UserDefinedTextPropertyRulesPDSA object</returns>
    public UserDefinedTextPropertyRulesPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in UserDefinedTextPropertyRulesPDSA
    /// </summary>
    /// <param name="entityToClone">The UserDefinedTextPropertyRulesPDSA entity to clone</param>
    /// <returns>A cloned UserDefinedTextPropertyRulesPDSA object</returns>
    public UserDefinedTextPropertyRulesPDSA CloneEntity(UserDefinedTextPropertyRulesPDSA entityToClone)
    {
      UserDefinedTextPropertyRulesPDSA newEntity = new UserDefinedTextPropertyRulesPDSA();

      newEntity.UserDefinedPropertyUid = entityToClone.UserDefinedPropertyUid;
      newEntity.MinimumLength = entityToClone.MinimumLength;
      newEntity.MaximumLength = entityToClone.MaximumLength;
      newEntity.DefaultValue = entityToClone.DefaultValue;
      newEntity.Mask = entityToClone.Mask;
      newEntity.ValidationRegEx = entityToClone.ValidationRegEx;
      newEntity.AllUpperCase = entityToClone.AllUpperCase;
      newEntity.FirstCharacterUpperCase = entityToClone.FirstCharacterUpperCase;
      newEntity.IsRequired = entityToClone.IsRequired;
      newEntity.EmptyContent = entityToClone.EmptyContent;
      newEntity.ValidationErrorMessage = entityToClone.ValidationErrorMessage;
      newEntity.InsertName = entityToClone.InsertName;
      newEntity.InsertDate = entityToClone.InsertDate;
      newEntity.UpdateName = entityToClone.UpdateName;
      newEntity.UpdateDate = entityToClone.UpdateDate;
      newEntity.ConcurrencyValue = entityToClone.ConcurrencyValue;
      newEntity.MaximumLengthLimit = entityToClone.MaximumLengthLimit;

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
      
      props.Add(PDSAProperty.Create(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.UserDefinedPropertyUid, GetResourceMessage("GCS_UserDefinedTextPropertyRulesPDSA_UserDefinedPropertyUid_Header", "User Defined Property Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_UserDefinedTextPropertyRulesPDSA_UserDefinedPropertyUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.MinimumLength, GetResourceMessage("GCS_UserDefinedTextPropertyRulesPDSA_MinimumLength_Header", "Minimum Length"), true, typeof(short), 5, GetResourceMessage("GCS_UserDefinedTextPropertyRulesPDSA_MinimumLength_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.MaximumLength, GetResourceMessage("GCS_UserDefinedTextPropertyRulesPDSA_MaximumLength_Header", "Maximum Length"), true, typeof(short), 5, GetResourceMessage("GCS_UserDefinedTextPropertyRulesPDSA_MaximumLength_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.DefaultValue, GetResourceMessage("GCS_UserDefinedTextPropertyRulesPDSA_DefaultValue_Header", "Default Value"), false, typeof(string), 255, GetResourceMessage("GCS_UserDefinedTextPropertyRulesPDSA_DefaultValue_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.Mask, GetResourceMessage("GCS_UserDefinedTextPropertyRulesPDSA_Mask_Header", "Mask"), false, typeof(string), 255, GetResourceMessage("GCS_UserDefinedTextPropertyRulesPDSA_Mask_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.ValidationRegEx, GetResourceMessage("GCS_UserDefinedTextPropertyRulesPDSA_ValidationRegEx_Header", "Validation Reg Ex"), false, typeof(string), 255, GetResourceMessage("GCS_UserDefinedTextPropertyRulesPDSA_ValidationRegEx_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.AllUpperCase, GetResourceMessage("GCS_UserDefinedTextPropertyRulesPDSA_AllUpperCase_Header", "All Upper Case"), true, typeof(bool), -1, GetResourceMessage("GCS_UserDefinedTextPropertyRulesPDSA_AllUpperCase_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.FirstCharacterUpperCase, GetResourceMessage("GCS_UserDefinedTextPropertyRulesPDSA_FirstCharacterUpperCase_Header", "First Character Upper Case"), true, typeof(bool), -1, GetResourceMessage("GCS_UserDefinedTextPropertyRulesPDSA_FirstCharacterUpperCase_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.IsRequired, GetResourceMessage("GCS_UserDefinedTextPropertyRulesPDSA_IsRequired_Header", "Is Required"), true, typeof(bool), -1, GetResourceMessage("GCS_UserDefinedTextPropertyRulesPDSA_IsRequired_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.EmptyContent, GetResourceMessage("GCS_UserDefinedTextPropertyRulesPDSA_EmptyContent_Header", "Empty Content"), false, typeof(string), 255, GetResourceMessage("GCS_UserDefinedTextPropertyRulesPDSA_EmptyContent_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.ValidationErrorMessage, GetResourceMessage("GCS_UserDefinedTextPropertyRulesPDSA_ValidationErrorMessage_Header", "Validation Error Message"), false, typeof(string), 1000, GetResourceMessage("GCS_UserDefinedTextPropertyRulesPDSA_ValidationErrorMessage_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_UserDefinedTextPropertyRulesPDSA_InsertName_Header", "Insert Name"), true, typeof(string), 50, GetResourceMessage("GCS_UserDefinedTextPropertyRulesPDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_UserDefinedTextPropertyRulesPDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_UserDefinedTextPropertyRulesPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_UserDefinedTextPropertyRulesPDSA_UpdateName_Header", "Update Name"), true, typeof(string), 50, GetResourceMessage("GCS_UserDefinedTextPropertyRulesPDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_UserDefinedTextPropertyRulesPDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_UserDefinedTextPropertyRulesPDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_UserDefinedTextPropertyRulesPDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_UserDefinedTextPropertyRulesPDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.MaximumLengthLimit, GetResourceMessage("GCS_UserDefinedTextPropertyRulesPDSA_MaximumLengthLimit_Header", "Maximum Length Limit"), true, typeof(short), 5, GetResourceMessage("GCS_UserDefinedTextPropertyRulesPDSA_MaximumLengthLimit_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.UserDefinedPropertyUid = Guid.Empty;
      Entity.MinimumLength = 0;
      Entity.MaximumLength = 0;
      Entity.DefaultValue = string.Empty;
      Entity.Mask = string.Empty;
      Entity.ValidationRegEx = string.Empty;
      Entity.AllUpperCase = false;
      Entity.FirstCharacterUpperCase = false;
      Entity.IsRequired = false;
      Entity.EmptyContent = string.Empty;
      Entity.ValidationErrorMessage = string.Empty;
      Entity.InsertName = string.Empty;
      Entity.InsertDate = DateTimeOffset.Now;
      Entity.UpdateName = string.Empty;
      Entity.UpdateDate = DateTimeOffset.Now;
      Entity.ConcurrencyValue = 0;
      Entity.MaximumLengthLimit = 0;

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
      
      if(!Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.UserDefinedPropertyUid).SetAsNull)
        Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.UserDefinedPropertyUid).Value = Entity.UserDefinedPropertyUid;
      if(!Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.MinimumLength).SetAsNull)
        Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.MinimumLength).Value = Entity.MinimumLength;
      if(!Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.MaximumLength).SetAsNull)
        Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.MaximumLength).Value = Entity.MaximumLength;
      if(!Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.DefaultValue).SetAsNull)
        Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.DefaultValue).Value = Entity.DefaultValue;
      if(!Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.Mask).SetAsNull)
        Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.Mask).Value = Entity.Mask;
      if(!Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.ValidationRegEx).SetAsNull)
        Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.ValidationRegEx).Value = Entity.ValidationRegEx;
      if(!Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.AllUpperCase).SetAsNull)
        Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.AllUpperCase).Value = Entity.AllUpperCase;
      if(!Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.FirstCharacterUpperCase).SetAsNull)
        Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.FirstCharacterUpperCase).Value = Entity.FirstCharacterUpperCase;
      if(!Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.IsRequired).SetAsNull)
        Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.IsRequired).Value = Entity.IsRequired;
      if(!Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.EmptyContent).SetAsNull)
        Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.EmptyContent).Value = Entity.EmptyContent;
      if(!Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.ValidationErrorMessage).SetAsNull)
        Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.ValidationErrorMessage).Value = Entity.ValidationErrorMessage;
      if(!Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
      if(!Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.MaximumLengthLimit).SetAsNull)
        Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.MaximumLengthLimit).Value = Entity.MaximumLengthLimit;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.UserDefinedPropertyUid).IsNull == false)
        Entity.UserDefinedPropertyUid = Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.UserDefinedPropertyUid).GetAsGuid();
      if(Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.MinimumLength).IsNull == false)
        Entity.MinimumLength = Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.MinimumLength).GetAsShort();
      if(Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.MaximumLength).IsNull == false)
        Entity.MaximumLength = Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.MaximumLength).GetAsShort();
      if(Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.DefaultValue).IsNull == false)
        Entity.DefaultValue = Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.DefaultValue).GetAsString();
      if(Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.Mask).IsNull == false)
        Entity.Mask = Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.Mask).GetAsString();
      if(Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.ValidationRegEx).IsNull == false)
        Entity.ValidationRegEx = Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.ValidationRegEx).GetAsString();
      if(Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.AllUpperCase).IsNull == false)
        Entity.AllUpperCase = Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.AllUpperCase).GetAsBool();
      if(Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.FirstCharacterUpperCase).IsNull == false)
        Entity.FirstCharacterUpperCase = Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.FirstCharacterUpperCase).GetAsBool();
      if(Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.IsRequired).IsNull == false)
        Entity.IsRequired = Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.IsRequired).GetAsBool();
      if(Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.EmptyContent).IsNull == false)
        Entity.EmptyContent = Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.EmptyContent).GetAsString();
      if(Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.ValidationErrorMessage).IsNull == false)
        Entity.ValidationErrorMessage = Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.ValidationErrorMessage).GetAsString();
      if(Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
      if(Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.MaximumLengthLimit).IsNull == false)
        Entity.MaximumLengthLimit = Properties.GetByName(UserDefinedTextPropertyRulesPDSAValidator.ColumnNames.MaximumLengthLimit).GetAsShort();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the UserDefinedTextPropertyRulesPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'UserDefinedPropertyUid'
    /// </summary>
    public static string UserDefinedPropertyUid = "UserDefinedPropertyUid";
    /// <summary>
    /// Returns 'MinimumLength'
    /// </summary>
    public static string MinimumLength = "MinimumLength";
    /// <summary>
    /// Returns 'MaximumLength'
    /// </summary>
    public static string MaximumLength = "MaximumLength";
    /// <summary>
    /// Returns 'DefaultValue'
    /// </summary>
    public static string DefaultValue = "DefaultValue";
    /// <summary>
    /// Returns 'Mask'
    /// </summary>
    public static string Mask = "Mask";
    /// <summary>
    /// Returns 'ValidationRegEx'
    /// </summary>
    public static string ValidationRegEx = "ValidationRegEx";
    /// <summary>
    /// Returns 'AllUpperCase'
    /// </summary>
    public static string AllUpperCase = "AllUpperCase";
    /// <summary>
    /// Returns 'FirstCharacterUpperCase'
    /// </summary>
    public static string FirstCharacterUpperCase = "FirstCharacterUpperCase";
    /// <summary>
    /// Returns 'IsRequired'
    /// </summary>
    public static string IsRequired = "IsRequired";
    /// <summary>
    /// Returns 'EmptyContent'
    /// </summary>
    public static string EmptyContent = "EmptyContent";
    /// <summary>
    /// Returns 'ValidationErrorMessage'
    /// </summary>
    public static string ValidationErrorMessage = "ValidationErrorMessage";
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
    /// Returns 'MaximumLengthLimit'
    /// </summary>
    public static string MaximumLengthLimit = "MaximumLengthLimit";
    }
    #endregion
  }
}

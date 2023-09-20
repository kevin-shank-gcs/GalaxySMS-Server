using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the AccessPortalCommandChoicePDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class AccessPortalCommandChoicePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private AccessPortalCommandChoicePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new AccessPortalCommandChoicePDSA Entity
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
    /// Clones the current AccessPortalCommandChoicePDSA
    /// </summary>
    /// <returns>A cloned AccessPortalCommandChoicePDSA object</returns>
    public AccessPortalCommandChoicePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in AccessPortalCommandChoicePDSA
    /// </summary>
    /// <param name="entityToClone">The AccessPortalCommandChoicePDSA entity to clone</param>
    /// <returns>A cloned AccessPortalCommandChoicePDSA object</returns>
    public AccessPortalCommandChoicePDSA CloneEntity(AccessPortalCommandChoicePDSA entityToClone)
    {
      AccessPortalCommandChoicePDSA newEntity = new AccessPortalCommandChoicePDSA();

      newEntity.AccessPortalCommandChoiceUid = entityToClone.AccessPortalCommandChoiceUid;
      newEntity.AccessPortalCommandUid = entityToClone.AccessPortalCommandUid;
      newEntity.Display = entityToClone.Display;
      newEntity.DisplayResourceKey = entityToClone.DisplayResourceKey;
      newEntity.Description = entityToClone.Description;
      newEntity.DescriptionResourceKey = entityToClone.DescriptionResourceKey;
      newEntity.ChoiceTypeCode = entityToClone.ChoiceTypeCode;
      newEntity.ApproxWaitTime = entityToClone.ApproxWaitTime;
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
      
      props.Add(PDSAProperty.Create(AccessPortalCommandChoicePDSAValidator.ColumnNames.AccessPortalCommandChoiceUid, GetResourceMessage("GCS_AccessPortalCommandChoicePDSA_AccessPortalCommandChoiceUid_Header", "Access Portal Command Choice Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_AccessPortalCommandChoicePDSA_AccessPortalCommandChoiceUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalCommandChoicePDSAValidator.ColumnNames.AccessPortalCommandUid, GetResourceMessage("GCS_AccessPortalCommandChoicePDSA_AccessPortalCommandUid_Header", "Access Portal Command Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_AccessPortalCommandChoicePDSA_AccessPortalCommandUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalCommandChoicePDSAValidator.ColumnNames.Display, GetResourceMessage("GCS_AccessPortalCommandChoicePDSA_Display_Header", "Display"), true, typeof(string), 65, GetResourceMessage("GCS_AccessPortalCommandChoicePDSA_Display_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalCommandChoicePDSAValidator.ColumnNames.DisplayResourceKey, GetResourceMessage("GCS_AccessPortalCommandChoicePDSA_DisplayResourceKey_Header", "Display Resource Key"), false, typeof(Guid), -1, GetResourceMessage("GCS_AccessPortalCommandChoicePDSA_DisplayResourceKey_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalCommandChoicePDSAValidator.ColumnNames.Description, GetResourceMessage("GCS_AccessPortalCommandChoicePDSA_Description_Header", "Description"), true, typeof(string), 1000, GetResourceMessage("GCS_AccessPortalCommandChoicePDSA_Description_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalCommandChoicePDSAValidator.ColumnNames.DescriptionResourceKey, GetResourceMessage("GCS_AccessPortalCommandChoicePDSA_DescriptionResourceKey_Header", "Description Resource Key"), false, typeof(Guid), -1, GetResourceMessage("GCS_AccessPortalCommandChoicePDSA_DescriptionResourceKey_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalCommandChoicePDSAValidator.ColumnNames.ChoiceTypeCode, GetResourceMessage("GCS_AccessPortalCommandChoicePDSA_ChoiceTypeCode_Header", "Choice Type Code"), true, typeof(int), 10, GetResourceMessage("GCS_AccessPortalCommandChoicePDSA_ChoiceTypeCode_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalCommandChoicePDSAValidator.ColumnNames.ApproxWaitTime, GetResourceMessage("GCS_AccessPortalCommandChoicePDSA_ApproxWaitTime_Header", "Approx Wait Time"), true, typeof(int), 10, GetResourceMessage("GCS_AccessPortalCommandChoicePDSA_ApproxWaitTime_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalCommandChoicePDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_AccessPortalCommandChoicePDSA_InsertName_Header", "Insert Name"), true, typeof(string), 100, GetResourceMessage("GCS_AccessPortalCommandChoicePDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalCommandChoicePDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_AccessPortalCommandChoicePDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_AccessPortalCommandChoicePDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalCommandChoicePDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_AccessPortalCommandChoicePDSA_UpdateName_Header", "Update Name"), true, typeof(string), 100, GetResourceMessage("GCS_AccessPortalCommandChoicePDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalCommandChoicePDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_AccessPortalCommandChoicePDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_AccessPortalCommandChoicePDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(AccessPortalCommandChoicePDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_AccessPortalCommandChoicePDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_AccessPortalCommandChoicePDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.AccessPortalCommandChoiceUid = Guid.Empty;
      Entity.AccessPortalCommandUid = Guid.Empty;
      Entity.Display = string.Empty;
      Entity.DisplayResourceKey = Guid.Empty;
      Entity.Description = string.Empty;
      Entity.DescriptionResourceKey = Guid.Empty;
      Entity.ChoiceTypeCode = 0;
      Entity.ApproxWaitTime = 0;
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
      
      if(!Properties.GetByName(AccessPortalCommandChoicePDSAValidator.ColumnNames.AccessPortalCommandChoiceUid).SetAsNull)
        Properties.GetByName(AccessPortalCommandChoicePDSAValidator.ColumnNames.AccessPortalCommandChoiceUid).Value = Entity.AccessPortalCommandChoiceUid;
      if(!Properties.GetByName(AccessPortalCommandChoicePDSAValidator.ColumnNames.AccessPortalCommandUid).SetAsNull)
        Properties.GetByName(AccessPortalCommandChoicePDSAValidator.ColumnNames.AccessPortalCommandUid).Value = Entity.AccessPortalCommandUid;
      if(!Properties.GetByName(AccessPortalCommandChoicePDSAValidator.ColumnNames.Display).SetAsNull)
        Properties.GetByName(AccessPortalCommandChoicePDSAValidator.ColumnNames.Display).Value = Entity.Display;
      if(!Properties.GetByName(AccessPortalCommandChoicePDSAValidator.ColumnNames.DisplayResourceKey).SetAsNull)
        Properties.GetByName(AccessPortalCommandChoicePDSAValidator.ColumnNames.DisplayResourceKey).Value = Entity.DisplayResourceKey;
      if(!Properties.GetByName(AccessPortalCommandChoicePDSAValidator.ColumnNames.Description).SetAsNull)
        Properties.GetByName(AccessPortalCommandChoicePDSAValidator.ColumnNames.Description).Value = Entity.Description;
      if(!Properties.GetByName(AccessPortalCommandChoicePDSAValidator.ColumnNames.DescriptionResourceKey).SetAsNull)
        Properties.GetByName(AccessPortalCommandChoicePDSAValidator.ColumnNames.DescriptionResourceKey).Value = Entity.DescriptionResourceKey;
      if(!Properties.GetByName(AccessPortalCommandChoicePDSAValidator.ColumnNames.ChoiceTypeCode).SetAsNull)
        Properties.GetByName(AccessPortalCommandChoicePDSAValidator.ColumnNames.ChoiceTypeCode).Value = Entity.ChoiceTypeCode;
      if(!Properties.GetByName(AccessPortalCommandChoicePDSAValidator.ColumnNames.ApproxWaitTime).SetAsNull)
        Properties.GetByName(AccessPortalCommandChoicePDSAValidator.ColumnNames.ApproxWaitTime).Value = Entity.ApproxWaitTime;
      if(!Properties.GetByName(AccessPortalCommandChoicePDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(AccessPortalCommandChoicePDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(AccessPortalCommandChoicePDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(AccessPortalCommandChoicePDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(AccessPortalCommandChoicePDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(AccessPortalCommandChoicePDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(AccessPortalCommandChoicePDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(AccessPortalCommandChoicePDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(AccessPortalCommandChoicePDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(AccessPortalCommandChoicePDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(AccessPortalCommandChoicePDSAValidator.ColumnNames.AccessPortalCommandChoiceUid).IsNull == false)
        Entity.AccessPortalCommandChoiceUid = Properties.GetByName(AccessPortalCommandChoicePDSAValidator.ColumnNames.AccessPortalCommandChoiceUid).GetAsGuid();
      if(Properties.GetByName(AccessPortalCommandChoicePDSAValidator.ColumnNames.AccessPortalCommandUid).IsNull == false)
        Entity.AccessPortalCommandUid = Properties.GetByName(AccessPortalCommandChoicePDSAValidator.ColumnNames.AccessPortalCommandUid).GetAsGuid();
      if(Properties.GetByName(AccessPortalCommandChoicePDSAValidator.ColumnNames.Display).IsNull == false)
        Entity.Display = Properties.GetByName(AccessPortalCommandChoicePDSAValidator.ColumnNames.Display).GetAsString();
      if(Properties.GetByName(AccessPortalCommandChoicePDSAValidator.ColumnNames.DisplayResourceKey).IsNull == false)
        Entity.DisplayResourceKey = Properties.GetByName(AccessPortalCommandChoicePDSAValidator.ColumnNames.DisplayResourceKey).GetAsGuid();
      if(Properties.GetByName(AccessPortalCommandChoicePDSAValidator.ColumnNames.Description).IsNull == false)
        Entity.Description = Properties.GetByName(AccessPortalCommandChoicePDSAValidator.ColumnNames.Description).GetAsString();
      if(Properties.GetByName(AccessPortalCommandChoicePDSAValidator.ColumnNames.DescriptionResourceKey).IsNull == false)
        Entity.DescriptionResourceKey = Properties.GetByName(AccessPortalCommandChoicePDSAValidator.ColumnNames.DescriptionResourceKey).GetAsGuid();
      if(Properties.GetByName(AccessPortalCommandChoicePDSAValidator.ColumnNames.ChoiceTypeCode).IsNull == false)
        Entity.ChoiceTypeCode = Properties.GetByName(AccessPortalCommandChoicePDSAValidator.ColumnNames.ChoiceTypeCode).GetAsInteger();
      if(Properties.GetByName(AccessPortalCommandChoicePDSAValidator.ColumnNames.ApproxWaitTime).IsNull == false)
        Entity.ApproxWaitTime = Properties.GetByName(AccessPortalCommandChoicePDSAValidator.ColumnNames.ApproxWaitTime).GetAsInteger();
      if(Properties.GetByName(AccessPortalCommandChoicePDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(AccessPortalCommandChoicePDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(AccessPortalCommandChoicePDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(AccessPortalCommandChoicePDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(AccessPortalCommandChoicePDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(AccessPortalCommandChoicePDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(AccessPortalCommandChoicePDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(AccessPortalCommandChoicePDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(AccessPortalCommandChoicePDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(AccessPortalCommandChoicePDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the AccessPortalCommandChoicePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'AccessPortalCommandChoiceUid'
    /// </summary>
    public static string AccessPortalCommandChoiceUid = "AccessPortalCommandChoiceUid";
    /// <summary>
    /// Returns 'AccessPortalCommandUid'
    /// </summary>
    public static string AccessPortalCommandUid = "AccessPortalCommandUid";
    /// <summary>
    /// Returns 'Display'
    /// </summary>
    public static string Display = "Display";
    /// <summary>
    /// Returns 'DisplayResourceKey'
    /// </summary>
    public static string DisplayResourceKey = "DisplayResourceKey";
    /// <summary>
    /// Returns 'Description'
    /// </summary>
    public static string Description = "Description";
    /// <summary>
    /// Returns 'DescriptionResourceKey'
    /// </summary>
    public static string DescriptionResourceKey = "DescriptionResourceKey";
    /// <summary>
    /// Returns 'ChoiceTypeCode'
    /// </summary>
    public static string ChoiceTypeCode = "ChoiceTypeCode";
    /// <summary>
    /// Returns 'ApproxWaitTime'
    /// </summary>
    public static string ApproxWaitTime = "ApproxWaitTime";
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

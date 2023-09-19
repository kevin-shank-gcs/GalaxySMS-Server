using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the usp_SaveApplicationAuditTypePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class usp_SaveApplicationAuditTypePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private usp_SaveApplicationAuditTypePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new usp_SaveApplicationAuditTypePDSA Entity
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
    /// Clones the current usp_SaveApplicationAuditTypePDSA
    /// </summary>
    /// <returns>A cloned usp_SaveApplicationAuditTypePDSA object</returns>
    public usp_SaveApplicationAuditTypePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in usp_SaveApplicationAuditTypePDSA
    /// </summary>
    /// <param name="entityToClone">The usp_SaveApplicationAuditTypePDSA entity to clone</param>
    /// <returns>A cloned usp_SaveApplicationAuditTypePDSA object</returns>
    public usp_SaveApplicationAuditTypePDSA CloneEntity(usp_SaveApplicationAuditTypePDSA entityToClone)
    {
      usp_SaveApplicationAuditTypePDSA newEntity = new usp_SaveApplicationAuditTypePDSA();


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
      
      props.Add(PDSAProperty.Create(usp_SaveApplicationAuditTypePDSAValidator.ParameterNames.ApplicationAuditTypeId, GetResourceMessage("GCS_usp_SaveApplicationAuditTypePDSA_ApplicationAuditTypeId_Header", "Application Audit Type Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_usp_SaveApplicationAuditTypePDSA_ApplicationAuditTypeId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(usp_SaveApplicationAuditTypePDSAValidator.ParameterNames.Display, GetResourceMessage("GCS_usp_SaveApplicationAuditTypePDSA_Display_Header", "Display"), false, typeof(string), 8000, GetResourceMessage("GCS_usp_SaveApplicationAuditTypePDSA_Display_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(usp_SaveApplicationAuditTypePDSAValidator.ParameterNames.DisplayResourceKey, GetResourceMessage("GCS_usp_SaveApplicationAuditTypePDSA_DisplayResourceKey_Header", "Display Resource Key"), false, typeof(Guid), 0, GetResourceMessage("GCS_usp_SaveApplicationAuditTypePDSA_DisplayResourceKey_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(usp_SaveApplicationAuditTypePDSAValidator.ParameterNames.Description, GetResourceMessage("GCS_usp_SaveApplicationAuditTypePDSA_Description_Header", "Description"), false, typeof(string), 8000, GetResourceMessage("GCS_usp_SaveApplicationAuditTypePDSA_Description_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(usp_SaveApplicationAuditTypePDSAValidator.ParameterNames.DescriptionResourceKey, GetResourceMessage("GCS_usp_SaveApplicationAuditTypePDSA_DescriptionResourceKey_Header", "Description Resource Key"), false, typeof(Guid), 0, GetResourceMessage("GCS_usp_SaveApplicationAuditTypePDSA_DescriptionResourceKey_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(usp_SaveApplicationAuditTypePDSAValidator.ParameterNames.TypeCode, GetResourceMessage("GCS_usp_SaveApplicationAuditTypePDSA_TypeCode_Header", "Type Code"), false, typeof(string), 8000, GetResourceMessage("GCS_usp_SaveApplicationAuditTypePDSA_TypeCode_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(usp_SaveApplicationAuditTypePDSAValidator.ParameterNames.InsertName, GetResourceMessage("GCS_usp_SaveApplicationAuditTypePDSA_InsertName_Header", "Insert Name"), false, typeof(string), 8000, GetResourceMessage("GCS_usp_SaveApplicationAuditTypePDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(usp_SaveApplicationAuditTypePDSAValidator.ParameterNames.InsertDate, GetResourceMessage("GCS_usp_SaveApplicationAuditTypePDSA_InsertDate_Header", "Insert Date"), false, typeof(DateTimeOffset), 0, GetResourceMessage("GCS_usp_SaveApplicationAuditTypePDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.MinValue, @"", ""));
      props.Add(PDSAProperty.Create(usp_SaveApplicationAuditTypePDSAValidator.ParameterNames.UpdateName, GetResourceMessage("GCS_usp_SaveApplicationAuditTypePDSA_UpdateName_Header", "Update Name"), false, typeof(string), 8000, GetResourceMessage("GCS_usp_SaveApplicationAuditTypePDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(usp_SaveApplicationAuditTypePDSAValidator.ParameterNames.UpdateDate, GetResourceMessage("GCS_usp_SaveApplicationAuditTypePDSA_UpdateDate_Header", "Update Date"), false, typeof(DateTimeOffset), 0, GetResourceMessage("GCS_usp_SaveApplicationAuditTypePDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.MinValue, @"", ""));
      props.Add(PDSAProperty.Create(usp_SaveApplicationAuditTypePDSAValidator.ParameterNames.ConcurrencyValue, GetResourceMessage("GCS_usp_SaveApplicationAuditTypePDSA_ConcurrencyValue_Header", "Concurrency Value"), false, typeof(short), 0, GetResourceMessage("GCS_usp_SaveApplicationAuditTypePDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(usp_SaveApplicationAuditTypePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_usp_SaveApplicationAuditTypePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_usp_SaveApplicationAuditTypePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      Properties.GetByName(usp_SaveApplicationAuditTypePDSAValidator.ParameterNames.ApplicationAuditTypeId).Value = Entity.ApplicationAuditTypeId;
      Properties.GetByName(usp_SaveApplicationAuditTypePDSAValidator.ParameterNames.Display).Value = Entity.Display;
      Properties.GetByName(usp_SaveApplicationAuditTypePDSAValidator.ParameterNames.DisplayResourceKey).Value = Entity.DisplayResourceKey;
      Properties.GetByName(usp_SaveApplicationAuditTypePDSAValidator.ParameterNames.Description).Value = Entity.Description;
      Properties.GetByName(usp_SaveApplicationAuditTypePDSAValidator.ParameterNames.DescriptionResourceKey).Value = Entity.DescriptionResourceKey;
      Properties.GetByName(usp_SaveApplicationAuditTypePDSAValidator.ParameterNames.TypeCode).Value = Entity.TypeCode;
      Properties.GetByName(usp_SaveApplicationAuditTypePDSAValidator.ParameterNames.InsertName).Value = Entity.InsertName;
      Properties.GetByName(usp_SaveApplicationAuditTypePDSAValidator.ParameterNames.InsertDate).Value = Entity.InsertDate;
      Properties.GetByName(usp_SaveApplicationAuditTypePDSAValidator.ParameterNames.UpdateName).Value = Entity.UpdateName;
      Properties.GetByName(usp_SaveApplicationAuditTypePDSAValidator.ParameterNames.UpdateDate).Value = Entity.UpdateDate;
      Properties.GetByName(usp_SaveApplicationAuditTypePDSAValidator.ParameterNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
      Properties.GetByName(usp_SaveApplicationAuditTypePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(Properties.GetByName(usp_SaveApplicationAuditTypePDSAValidator.ParameterNames.ApplicationAuditTypeId).IsNull == false)
        Entity.ApplicationAuditTypeId = Properties.GetByName(usp_SaveApplicationAuditTypePDSAValidator.ParameterNames.ApplicationAuditTypeId).GetAsGuid();
      if(Properties.GetByName(usp_SaveApplicationAuditTypePDSAValidator.ParameterNames.Display).IsNull == false)
        Entity.Display = Properties.GetByName(usp_SaveApplicationAuditTypePDSAValidator.ParameterNames.Display).GetAsString();
      if(Properties.GetByName(usp_SaveApplicationAuditTypePDSAValidator.ParameterNames.DisplayResourceKey).IsNull == false)
        Entity.DisplayResourceKey = Properties.GetByName(usp_SaveApplicationAuditTypePDSAValidator.ParameterNames.DisplayResourceKey).GetAsGuid();
      if(Properties.GetByName(usp_SaveApplicationAuditTypePDSAValidator.ParameterNames.Description).IsNull == false)
        Entity.Description = Properties.GetByName(usp_SaveApplicationAuditTypePDSAValidator.ParameterNames.Description).GetAsString();
      if(Properties.GetByName(usp_SaveApplicationAuditTypePDSAValidator.ParameterNames.DescriptionResourceKey).IsNull == false)
        Entity.DescriptionResourceKey = Properties.GetByName(usp_SaveApplicationAuditTypePDSAValidator.ParameterNames.DescriptionResourceKey).GetAsGuid();
      if(Properties.GetByName(usp_SaveApplicationAuditTypePDSAValidator.ParameterNames.TypeCode).IsNull == false)
        Entity.TypeCode = Properties.GetByName(usp_SaveApplicationAuditTypePDSAValidator.ParameterNames.TypeCode).GetAsString();
      if(Properties.GetByName(usp_SaveApplicationAuditTypePDSAValidator.ParameterNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(usp_SaveApplicationAuditTypePDSAValidator.ParameterNames.InsertName).GetAsString();
      if(Properties.GetByName(usp_SaveApplicationAuditTypePDSAValidator.ParameterNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(usp_SaveApplicationAuditTypePDSAValidator.ParameterNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(usp_SaveApplicationAuditTypePDSAValidator.ParameterNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(usp_SaveApplicationAuditTypePDSAValidator.ParameterNames.UpdateName).GetAsString();
      if(Properties.GetByName(usp_SaveApplicationAuditTypePDSAValidator.ParameterNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(usp_SaveApplicationAuditTypePDSAValidator.ParameterNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(usp_SaveApplicationAuditTypePDSAValidator.ParameterNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(usp_SaveApplicationAuditTypePDSAValidator.ParameterNames.ConcurrencyValue).GetAsShort();
      if(Properties.GetByName(usp_SaveApplicationAuditTypePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = Properties.GetByName(usp_SaveApplicationAuditTypePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the usp_SaveApplicationAuditTypePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@ApplicationAuditTypeId'
    /// </summary>
    public static string ApplicationAuditTypeId = "@ApplicationAuditTypeId";
    /// <summary>
    /// Returns '@Display'
    /// </summary>
    public static string Display = "@Display";
    /// <summary>
    /// Returns '@DisplayResourceKey'
    /// </summary>
    public static string DisplayResourceKey = "@DisplayResourceKey";
    /// <summary>
    /// Returns '@Description'
    /// </summary>
    public static string Description = "@Description";
    /// <summary>
    /// Returns '@DescriptionResourceKey'
    /// </summary>
    public static string DescriptionResourceKey = "@DescriptionResourceKey";
    /// <summary>
    /// Returns '@TypeCode'
    /// </summary>
    public static string TypeCode = "@TypeCode";
    /// <summary>
    /// Returns '@InsertName'
    /// </summary>
    public static string InsertName = "@InsertName";
    /// <summary>
    /// Returns '@InsertDate'
    /// </summary>
    public static string InsertDate = "@InsertDate";
    /// <summary>
    /// Returns '@UpdateName'
    /// </summary>
    public static string UpdateName = "@UpdateName";
    /// <summary>
    /// Returns '@UpdateDate'
    /// </summary>
    public static string UpdateDate = "@UpdateDate";
    /// <summary>
    /// Returns '@ConcurrencyValue'
    /// </summary>
    public static string ConcurrencyValue = "@ConcurrencyValue";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}

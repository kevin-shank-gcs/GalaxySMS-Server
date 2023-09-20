using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the gcsSetting_GetValuePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class gcsSetting_GetValuePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private gcsSetting_GetValuePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new gcsSetting_GetValuePDSA Entity
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
    /// Clones the current gcsSetting_GetValuePDSA
    /// </summary>
    /// <returns>A cloned gcsSetting_GetValuePDSA object</returns>
    public gcsSetting_GetValuePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in gcsSetting_GetValuePDSA
    /// </summary>
    /// <param name="entityToClone">The gcsSetting_GetValuePDSA entity to clone</param>
    /// <returns>A cloned gcsSetting_GetValuePDSA object</returns>
    public gcsSetting_GetValuePDSA CloneEntity(gcsSetting_GetValuePDSA entityToClone)
    {
      gcsSetting_GetValuePDSA newEntity = new gcsSetting_GetValuePDSA();

      newEntity.Value = entityToClone.Value;

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
      
      props.Add(PDSAProperty.Create(gcsSetting_GetValuePDSAValidator.ParameterNames.EntityId, GetResourceMessage("GCS_gcsSetting_GetValuePDSA_EntityId_Header", "Entity Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_gcsSetting_GetValuePDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsSetting_GetValuePDSAValidator.ParameterNames.SettingGroup, GetResourceMessage("GCS_gcsSetting_GetValuePDSA_SettingGroup_Header", "Setting Group"), false, typeof(string), 8000, GetResourceMessage("GCS_gcsSetting_GetValuePDSA_SettingGroup_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsSetting_GetValuePDSAValidator.ParameterNames.SettingSubGroup, GetResourceMessage("GCS_gcsSetting_GetValuePDSA_SettingSubGroup_Header", "Setting Sub Group"), false, typeof(string), 8000, GetResourceMessage("GCS_gcsSetting_GetValuePDSA_SettingSubGroup_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsSetting_GetValuePDSAValidator.ParameterNames.SettingKey, GetResourceMessage("GCS_gcsSetting_GetValuePDSA_SettingKey_Header", "Setting Key"), false, typeof(string), 8000, GetResourceMessage("GCS_gcsSetting_GetValuePDSA_SettingKey_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsSetting_GetValuePDSAValidator.ParameterNames.Value, GetResourceMessage("GCS_gcsSetting_GetValuePDSA_Value_Header", "Value"), false, typeof(string), 8000, GetResourceMessage("GCS_gcsSetting_GetValuePDSA_Value_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsSetting_GetValuePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_gcsSetting_GetValuePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_gcsSetting_GetValuePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      if (this.Properties == null)
      {
        this.InitProperties();
      }
      
      this.Properties.GetByName(gcsSetting_GetValuePDSAValidator.ParameterNames.EntityId).Value = Entity.EntityId;
      this.Properties.GetByName(gcsSetting_GetValuePDSAValidator.ParameterNames.SettingGroup).Value = Entity.SettingGroup;
      this.Properties.GetByName(gcsSetting_GetValuePDSAValidator.ParameterNames.SettingSubGroup).Value = Entity.SettingSubGroup;
      this.Properties.GetByName(gcsSetting_GetValuePDSAValidator.ParameterNames.SettingKey).Value = Entity.SettingKey;
      this.Properties.GetByName(gcsSetting_GetValuePDSAValidator.ParameterNames.Value).Value = Entity.Value;
      this.Properties.GetByName(gcsSetting_GetValuePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (this.Properties == null)
      {
        this.InitProperties();
      }

      if(this.Properties.GetByName(gcsSetting_GetValuePDSAValidator.ParameterNames.EntityId).IsNull == false)
        Entity.EntityId = this.Properties.GetByName(gcsSetting_GetValuePDSAValidator.ParameterNames.EntityId).GetAsGuid();
      if(this.Properties.GetByName(gcsSetting_GetValuePDSAValidator.ParameterNames.SettingGroup).IsNull == false)
        Entity.SettingGroup = this.Properties.GetByName(gcsSetting_GetValuePDSAValidator.ParameterNames.SettingGroup).GetAsString();
      if(this.Properties.GetByName(gcsSetting_GetValuePDSAValidator.ParameterNames.SettingSubGroup).IsNull == false)
        Entity.SettingSubGroup = this.Properties.GetByName(gcsSetting_GetValuePDSAValidator.ParameterNames.SettingSubGroup).GetAsString();
      if(this.Properties.GetByName(gcsSetting_GetValuePDSAValidator.ParameterNames.SettingKey).IsNull == false)
        Entity.SettingKey = this.Properties.GetByName(gcsSetting_GetValuePDSAValidator.ParameterNames.SettingKey).GetAsString();
      if(this.Properties.GetByName(gcsSetting_GetValuePDSAValidator.ParameterNames.Value).IsNull == false)
        Entity.Value = this.Properties.GetByName(gcsSetting_GetValuePDSAValidator.ParameterNames.Value).GetAsString();
      if(this.Properties.GetByName(gcsSetting_GetValuePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(gcsSetting_GetValuePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the gcsSetting_GetValuePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns '[Value]'
    /// </summary>
    public static string Value = "Value";
    /// <summary>
    /// Returns '@EntityId'
    /// </summary>
    public static string EntityId = "@EntityId";
    /// <summary>
    /// Returns '@SettingGroup'
    /// </summary>
    public static string SettingGroup = "@SettingGroup";
    /// <summary>
    /// Returns '@SettingSubGroup'
    /// </summary>
    public static string SettingSubGroup = "@SettingSubGroup";
    /// <summary>
    /// Returns '@SettingKey'
    /// </summary>
    public static string SettingKey = "@SettingKey";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the gcsSetting_GetValuePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@EntityId'
    /// </summary>
    public static string EntityId = "@EntityId";
    /// <summary>
    /// Returns '@SettingGroup'
    /// </summary>
    public static string SettingGroup = "@SettingGroup";
    /// <summary>
    /// Returns '@SettingSubGroup'
    /// </summary>
    public static string SettingSubGroup = "@SettingSubGroup";
    /// <summary>
    /// Returns '@SettingKey'
    /// </summary>
    public static string SettingKey = "@SettingKey";
    /// <summary>
    /// Returns '@Value'
    /// </summary>
    public static string Value = "@Value";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}

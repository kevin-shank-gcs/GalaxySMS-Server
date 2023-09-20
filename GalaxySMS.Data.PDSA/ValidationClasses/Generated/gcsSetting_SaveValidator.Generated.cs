using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the gcsSetting_SavePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class gcsSetting_SavePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private gcsSetting_SavePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new gcsSetting_SavePDSA Entity
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
    /// Clones the current gcsSetting_SavePDSA
    /// </summary>
    /// <returns>A cloned gcsSetting_SavePDSA object</returns>
    public gcsSetting_SavePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in gcsSetting_SavePDSA
    /// </summary>
    /// <param name="entityToClone">The gcsSetting_SavePDSA entity to clone</param>
    /// <returns>A cloned gcsSetting_SavePDSA object</returns>
    public gcsSetting_SavePDSA CloneEntity(gcsSetting_SavePDSA entityToClone)
    {
      gcsSetting_SavePDSA newEntity = new gcsSetting_SavePDSA();


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
      
      props.Add(PDSAProperty.Create(gcsSetting_SavePDSAValidator.ParameterNames.EntityId, GetResourceMessage("GCS_gcsSetting_SavePDSA_EntityId_Header", "Entity Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_gcsSetting_SavePDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsSetting_SavePDSAValidator.ParameterNames.SettingGroup, GetResourceMessage("GCS_gcsSetting_SavePDSA_SettingGroup_Header", "Setting Group"), false, typeof(string), 8000, GetResourceMessage("GCS_gcsSetting_SavePDSA_SettingGroup_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsSetting_SavePDSAValidator.ParameterNames.SettingSubGroup, GetResourceMessage("GCS_gcsSetting_SavePDSA_SettingSubGroup_Header", "Setting Sub Group"), false, typeof(string), 8000, GetResourceMessage("GCS_gcsSetting_SavePDSA_SettingSubGroup_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsSetting_SavePDSAValidator.ParameterNames.SettingKey, GetResourceMessage("GCS_gcsSetting_SavePDSA_SettingKey_Header", "Setting Key"), false, typeof(string), 8000, GetResourceMessage("GCS_gcsSetting_SavePDSA_SettingKey_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsSetting_SavePDSAValidator.ParameterNames.Value, GetResourceMessage("GCS_gcsSetting_SavePDSA_Value_Header", "Value"), false, typeof(string), 8000, GetResourceMessage("GCS_gcsSetting_SavePDSA_Value_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsSetting_SavePDSAValidator.ParameterNames.UserName, GetResourceMessage("GCS_gcsSetting_SavePDSA_UserName_Header", "User Name"), false, typeof(string), 8000, GetResourceMessage("GCS_gcsSetting_SavePDSA_UserName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsSetting_SavePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_gcsSetting_SavePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_gcsSetting_SavePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      Properties.GetByName(gcsSetting_SavePDSAValidator.ParameterNames.EntityId).Value = Entity.EntityId;
      Properties.GetByName(gcsSetting_SavePDSAValidator.ParameterNames.SettingGroup).Value = Entity.SettingGroup;
      Properties.GetByName(gcsSetting_SavePDSAValidator.ParameterNames.SettingSubGroup).Value = Entity.SettingSubGroup;
      Properties.GetByName(gcsSetting_SavePDSAValidator.ParameterNames.SettingKey).Value = Entity.SettingKey;
      Properties.GetByName(gcsSetting_SavePDSAValidator.ParameterNames.Value).Value = Entity.Value;
      Properties.GetByName(gcsSetting_SavePDSAValidator.ParameterNames.UserName).Value = Entity.UserName;
      Properties.GetByName(gcsSetting_SavePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(Properties.GetByName(gcsSetting_SavePDSAValidator.ParameterNames.EntityId).IsNull == false)
        Entity.EntityId = Properties.GetByName(gcsSetting_SavePDSAValidator.ParameterNames.EntityId).GetAsGuid();
      if(Properties.GetByName(gcsSetting_SavePDSAValidator.ParameterNames.SettingGroup).IsNull == false)
        Entity.SettingGroup = Properties.GetByName(gcsSetting_SavePDSAValidator.ParameterNames.SettingGroup).GetAsString();
      if(Properties.GetByName(gcsSetting_SavePDSAValidator.ParameterNames.SettingSubGroup).IsNull == false)
        Entity.SettingSubGroup = Properties.GetByName(gcsSetting_SavePDSAValidator.ParameterNames.SettingSubGroup).GetAsString();
      if(Properties.GetByName(gcsSetting_SavePDSAValidator.ParameterNames.SettingKey).IsNull == false)
        Entity.SettingKey = Properties.GetByName(gcsSetting_SavePDSAValidator.ParameterNames.SettingKey).GetAsString();
      if(Properties.GetByName(gcsSetting_SavePDSAValidator.ParameterNames.Value).IsNull == false)
        Entity.Value = Properties.GetByName(gcsSetting_SavePDSAValidator.ParameterNames.Value).GetAsString();
      if(Properties.GetByName(gcsSetting_SavePDSAValidator.ParameterNames.UserName).IsNull == false)
        Entity.UserName = Properties.GetByName(gcsSetting_SavePDSAValidator.ParameterNames.UserName).GetAsString();
      if(Properties.GetByName(gcsSetting_SavePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = Properties.GetByName(gcsSetting_SavePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the gcsSetting_SavePDSA class.
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
    /// Returns '@UserName'
    /// </summary>
    public static string UserName = "@UserName";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}

using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the gcs_IsSettingUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class gcs_IsSettingUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private gcs_IsSettingUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new gcs_IsSettingUniquePDSA Entity
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
    /// Clones the current gcs_IsSettingUniquePDSA
    /// </summary>
    /// <returns>A cloned gcs_IsSettingUniquePDSA object</returns>
    public gcs_IsSettingUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in gcs_IsSettingUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The gcs_IsSettingUniquePDSA entity to clone</param>
    /// <returns>A cloned gcs_IsSettingUniquePDSA object</returns>
    public gcs_IsSettingUniquePDSA CloneEntity(gcs_IsSettingUniquePDSA entityToClone)
    {
      gcs_IsSettingUniquePDSA newEntity = new gcs_IsSettingUniquePDSA();

      newEntity.Result = entityToClone.Result;

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
      
      props.Add(PDSAProperty.Create(gcs_IsSettingUniquePDSAValidator.ParameterNames.SettingId, GetResourceMessage("GCS_gcs_IsSettingUniquePDSA_SettingId_Header", "Setting Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_gcs_IsSettingUniquePDSA_SettingId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcs_IsSettingUniquePDSAValidator.ParameterNames.EntityId, GetResourceMessage("GCS_gcs_IsSettingUniquePDSA_EntityId_Header", "Entity Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_gcs_IsSettingUniquePDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcs_IsSettingUniquePDSAValidator.ParameterNames.SettingGroup, GetResourceMessage("GCS_gcs_IsSettingUniquePDSA_SettingGroup_Header", "Setting Group"), false, typeof(string), 8000, GetResourceMessage("GCS_gcs_IsSettingUniquePDSA_SettingGroup_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcs_IsSettingUniquePDSAValidator.ParameterNames.SettingSubGroup, GetResourceMessage("GCS_gcs_IsSettingUniquePDSA_SettingSubGroup_Header", "Setting Sub Group"), false, typeof(string), 8000, GetResourceMessage("GCS_gcs_IsSettingUniquePDSA_SettingSubGroup_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcs_IsSettingUniquePDSAValidator.ParameterNames.SettingKey, GetResourceMessage("GCS_gcs_IsSettingUniquePDSA_SettingKey_Header", "Setting Key"), false, typeof(string), 8000, GetResourceMessage("GCS_gcs_IsSettingUniquePDSA_SettingKey_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcs_IsSettingUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_gcs_IsSettingUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_gcs_IsSettingUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(gcs_IsSettingUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_gcs_IsSettingUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_gcs_IsSettingUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(gcs_IsSettingUniquePDSAValidator.ParameterNames.SettingId).Value = Entity.SettingId;
      this.Properties.GetByName(gcs_IsSettingUniquePDSAValidator.ParameterNames.EntityId).Value = Entity.EntityId;
      this.Properties.GetByName(gcs_IsSettingUniquePDSAValidator.ParameterNames.SettingGroup).Value = Entity.SettingGroup;
      this.Properties.GetByName(gcs_IsSettingUniquePDSAValidator.ParameterNames.SettingSubGroup).Value = Entity.SettingSubGroup;
      this.Properties.GetByName(gcs_IsSettingUniquePDSAValidator.ParameterNames.SettingKey).Value = Entity.SettingKey;
      this.Properties.GetByName(gcs_IsSettingUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(gcs_IsSettingUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(gcs_IsSettingUniquePDSAValidator.ParameterNames.SettingId).IsNull == false)
        Entity.SettingId = this.Properties.GetByName(gcs_IsSettingUniquePDSAValidator.ParameterNames.SettingId).GetAsGuid();
      if(this.Properties.GetByName(gcs_IsSettingUniquePDSAValidator.ParameterNames.EntityId).IsNull == false)
        Entity.EntityId = this.Properties.GetByName(gcs_IsSettingUniquePDSAValidator.ParameterNames.EntityId).GetAsGuid();
      if(this.Properties.GetByName(gcs_IsSettingUniquePDSAValidator.ParameterNames.SettingGroup).IsNull == false)
        Entity.SettingGroup = this.Properties.GetByName(gcs_IsSettingUniquePDSAValidator.ParameterNames.SettingGroup).GetAsString();
      if(this.Properties.GetByName(gcs_IsSettingUniquePDSAValidator.ParameterNames.SettingSubGroup).IsNull == false)
        Entity.SettingSubGroup = this.Properties.GetByName(gcs_IsSettingUniquePDSAValidator.ParameterNames.SettingSubGroup).GetAsString();
      if(this.Properties.GetByName(gcs_IsSettingUniquePDSAValidator.ParameterNames.SettingKey).IsNull == false)
        Entity.SettingKey = this.Properties.GetByName(gcs_IsSettingUniquePDSAValidator.ParameterNames.SettingKey).GetAsString();
      if(this.Properties.GetByName(gcs_IsSettingUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(gcs_IsSettingUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(gcs_IsSettingUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(gcs_IsSettingUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the gcs_IsSettingUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'Result'
    /// </summary>
    public static string Result = "Result";
    /// <summary>
    /// Returns '@SettingId'
    /// </summary>
    public static string SettingId = "@SettingId";
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
    /// Contains static string properties that represent the name of each property in the gcs_IsSettingUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@SettingId'
    /// </summary>
    public static string SettingId = "@SettingId";
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
    /// Returns '@Result'
    /// </summary>
    public static string Result = "@Result";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}

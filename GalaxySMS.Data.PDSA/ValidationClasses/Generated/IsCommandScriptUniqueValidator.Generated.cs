using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsCommandScriptUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsCommandScriptUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsCommandScriptUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsCommandScriptUniquePDSA Entity
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
    /// Clones the current IsCommandScriptUniquePDSA
    /// </summary>
    /// <returns>A cloned IsCommandScriptUniquePDSA object</returns>
    public IsCommandScriptUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsCommandScriptUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsCommandScriptUniquePDSA entity to clone</param>
    /// <returns>A cloned IsCommandScriptUniquePDSA object</returns>
    public IsCommandScriptUniquePDSA CloneEntity(IsCommandScriptUniquePDSA entityToClone)
    {
      IsCommandScriptUniquePDSA newEntity = new IsCommandScriptUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsCommandScriptUniquePDSAValidator.ParameterNames.CommandScriptUid, GetResourceMessage("GCS_IsCommandScriptUniquePDSA_CommandScriptUid_Header", "Command Script Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsCommandScriptUniquePDSA_CommandScriptUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsCommandScriptUniquePDSAValidator.ParameterNames.EntityId, GetResourceMessage("GCS_IsCommandScriptUniquePDSA_EntityId_Header", "Entity Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsCommandScriptUniquePDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsCommandScriptUniquePDSAValidator.ParameterNames.CommandScriptName, GetResourceMessage("GCS_IsCommandScriptUniquePDSA_CommandScriptName_Header", "Command Script Name"), false, typeof(string), 8000, GetResourceMessage("GCS_IsCommandScriptUniquePDSA_CommandScriptName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsCommandScriptUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsCommandScriptUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsCommandScriptUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsCommandScriptUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsCommandScriptUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsCommandScriptUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsCommandScriptUniquePDSAValidator.ParameterNames.CommandScriptUid).Value = Entity.CommandScriptUid;
      this.Properties.GetByName(IsCommandScriptUniquePDSAValidator.ParameterNames.EntityId).Value = Entity.EntityId;
      this.Properties.GetByName(IsCommandScriptUniquePDSAValidator.ParameterNames.CommandScriptName).Value = Entity.CommandScriptName;
      this.Properties.GetByName(IsCommandScriptUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsCommandScriptUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsCommandScriptUniquePDSAValidator.ParameterNames.CommandScriptUid).IsNull == false)
        Entity.CommandScriptUid = this.Properties.GetByName(IsCommandScriptUniquePDSAValidator.ParameterNames.CommandScriptUid).GetAsGuid();
      if(this.Properties.GetByName(IsCommandScriptUniquePDSAValidator.ParameterNames.EntityId).IsNull == false)
        Entity.EntityId = this.Properties.GetByName(IsCommandScriptUniquePDSAValidator.ParameterNames.EntityId).GetAsGuid();
      if(this.Properties.GetByName(IsCommandScriptUniquePDSAValidator.ParameterNames.CommandScriptName).IsNull == false)
        Entity.CommandScriptName = this.Properties.GetByName(IsCommandScriptUniquePDSAValidator.ParameterNames.CommandScriptName).GetAsString();
      if(this.Properties.GetByName(IsCommandScriptUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsCommandScriptUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsCommandScriptUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsCommandScriptUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsCommandScriptUniquePDSA class.
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
    /// Returns '@CommandScriptUid'
    /// </summary>
    public static string CommandScriptUid = "@CommandScriptUid";
    /// <summary>
    /// Returns '@EntityId'
    /// </summary>
    public static string EntityId = "@EntityId";
    /// <summary>
    /// Returns '@CommandScriptName'
    /// </summary>
    public static string CommandScriptName = "@CommandScriptName";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsCommandScriptUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@CommandScriptUid'
    /// </summary>
    public static string CommandScriptUid = "@CommandScriptUid";
    /// <summary>
    /// Returns '@EntityId'
    /// </summary>
    public static string EntityId = "@EntityId";
    /// <summary>
    /// Returns '@CommandScriptName'
    /// </summary>
    public static string CommandScriptName = "@CommandScriptName";
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

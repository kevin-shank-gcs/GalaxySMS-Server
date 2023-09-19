using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsUserDefinedPropertyEntityMapUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsUserDefinedPropertyEntityMapUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsUserDefinedPropertyEntityMapUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsUserDefinedPropertyEntityMapUniquePDSA Entity
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
    /// Clones the current IsUserDefinedPropertyEntityMapUniquePDSA
    /// </summary>
    /// <returns>A cloned IsUserDefinedPropertyEntityMapUniquePDSA object</returns>
    public IsUserDefinedPropertyEntityMapUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsUserDefinedPropertyEntityMapUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsUserDefinedPropertyEntityMapUniquePDSA entity to clone</param>
    /// <returns>A cloned IsUserDefinedPropertyEntityMapUniquePDSA object</returns>
    public IsUserDefinedPropertyEntityMapUniquePDSA CloneEntity(IsUserDefinedPropertyEntityMapUniquePDSA entityToClone)
    {
      IsUserDefinedPropertyEntityMapUniquePDSA newEntity = new IsUserDefinedPropertyEntityMapUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsUserDefinedPropertyEntityMapUniquePDSAValidator.ParameterNames.UserDefinedPropertyEntityMapUid, GetResourceMessage("GCS_IsUserDefinedPropertyEntityMapUniquePDSA_UserDefinedPropertyEntityMapUid_Header", "User Defined Property Entity Map Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsUserDefinedPropertyEntityMapUniquePDSA_UserDefinedPropertyEntityMapUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsUserDefinedPropertyEntityMapUniquePDSAValidator.ParameterNames.EntityId, GetResourceMessage("GCS_IsUserDefinedPropertyEntityMapUniquePDSA_EntityId_Header", "Entity Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsUserDefinedPropertyEntityMapUniquePDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsUserDefinedPropertyEntityMapUniquePDSAValidator.ParameterNames.UserDefinedPropertyUid, GetResourceMessage("GCS_IsUserDefinedPropertyEntityMapUniquePDSA_UserDefinedPropertyUid_Header", "User Defined Property Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsUserDefinedPropertyEntityMapUniquePDSA_UserDefinedPropertyUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsUserDefinedPropertyEntityMapUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsUserDefinedPropertyEntityMapUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsUserDefinedPropertyEntityMapUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsUserDefinedPropertyEntityMapUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsUserDefinedPropertyEntityMapUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsUserDefinedPropertyEntityMapUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsUserDefinedPropertyEntityMapUniquePDSAValidator.ParameterNames.UserDefinedPropertyEntityMapUid).Value = Entity.UserDefinedPropertyEntityMapUid;
      this.Properties.GetByName(IsUserDefinedPropertyEntityMapUniquePDSAValidator.ParameterNames.EntityId).Value = Entity.EntityId;
      this.Properties.GetByName(IsUserDefinedPropertyEntityMapUniquePDSAValidator.ParameterNames.UserDefinedPropertyUid).Value = Entity.UserDefinedPropertyUid;
      this.Properties.GetByName(IsUserDefinedPropertyEntityMapUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsUserDefinedPropertyEntityMapUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsUserDefinedPropertyEntityMapUniquePDSAValidator.ParameterNames.UserDefinedPropertyEntityMapUid).IsNull == false)
        Entity.UserDefinedPropertyEntityMapUid = this.Properties.GetByName(IsUserDefinedPropertyEntityMapUniquePDSAValidator.ParameterNames.UserDefinedPropertyEntityMapUid).GetAsGuid();
      if(this.Properties.GetByName(IsUserDefinedPropertyEntityMapUniquePDSAValidator.ParameterNames.EntityId).IsNull == false)
        Entity.EntityId = this.Properties.GetByName(IsUserDefinedPropertyEntityMapUniquePDSAValidator.ParameterNames.EntityId).GetAsGuid();
      if(this.Properties.GetByName(IsUserDefinedPropertyEntityMapUniquePDSAValidator.ParameterNames.UserDefinedPropertyUid).IsNull == false)
        Entity.UserDefinedPropertyUid = this.Properties.GetByName(IsUserDefinedPropertyEntityMapUniquePDSAValidator.ParameterNames.UserDefinedPropertyUid).GetAsGuid();
      if(this.Properties.GetByName(IsUserDefinedPropertyEntityMapUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsUserDefinedPropertyEntityMapUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsUserDefinedPropertyEntityMapUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsUserDefinedPropertyEntityMapUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsUserDefinedPropertyEntityMapUniquePDSA class.
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
    /// Returns '@UserDefinedPropertyEntityMapUid'
    /// </summary>
    public static string UserDefinedPropertyEntityMapUid = "@UserDefinedPropertyEntityMapUid";
    /// <summary>
    /// Returns '@EntityId'
    /// </summary>
    public static string EntityId = "@EntityId";
    /// <summary>
    /// Returns '@UserDefinedPropertyUid'
    /// </summary>
    public static string UserDefinedPropertyUid = "@UserDefinedPropertyUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsUserDefinedPropertyEntityMapUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@UserDefinedPropertyEntityMapUid'
    /// </summary>
    public static string UserDefinedPropertyEntityMapUid = "@UserDefinedPropertyEntityMapUid";
    /// <summary>
    /// Returns '@EntityId'
    /// </summary>
    public static string EntityId = "@EntityId";
    /// <summary>
    /// Returns '@UserDefinedPropertyUid'
    /// </summary>
    public static string UserDefinedPropertyUid = "@UserDefinedPropertyUid";
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

using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsAccessPortalTypeFeatureMapUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsAccessPortalTypeFeatureMapUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsAccessPortalTypeFeatureMapUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsAccessPortalTypeFeatureMapUniquePDSA Entity
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
    /// Clones the current IsAccessPortalTypeFeatureMapUniquePDSA
    /// </summary>
    /// <returns>A cloned IsAccessPortalTypeFeatureMapUniquePDSA object</returns>
    public IsAccessPortalTypeFeatureMapUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsAccessPortalTypeFeatureMapUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsAccessPortalTypeFeatureMapUniquePDSA entity to clone</param>
    /// <returns>A cloned IsAccessPortalTypeFeatureMapUniquePDSA object</returns>
    public IsAccessPortalTypeFeatureMapUniquePDSA CloneEntity(IsAccessPortalTypeFeatureMapUniquePDSA entityToClone)
    {
      IsAccessPortalTypeFeatureMapUniquePDSA newEntity = new IsAccessPortalTypeFeatureMapUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsAccessPortalTypeFeatureMapUniquePDSAValidator.ParameterNames.AccessPortalTypeFeatureMapUid, GetResourceMessage("GCS_IsAccessPortalTypeFeatureMapUniquePDSA_AccessPortalTypeFeatureMapUid_Header", "Access Portal Type Feature Map Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsAccessPortalTypeFeatureMapUniquePDSA_AccessPortalTypeFeatureMapUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAccessPortalTypeFeatureMapUniquePDSAValidator.ParameterNames.AccessPortalTypeUid, GetResourceMessage("GCS_IsAccessPortalTypeFeatureMapUniquePDSA_AccessPortalTypeUid_Header", "Access Portal Type Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsAccessPortalTypeFeatureMapUniquePDSA_AccessPortalTypeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAccessPortalTypeFeatureMapUniquePDSAValidator.ParameterNames.FeatureUid, GetResourceMessage("GCS_IsAccessPortalTypeFeatureMapUniquePDSA_FeatureUid_Header", "Feature Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsAccessPortalTypeFeatureMapUniquePDSA_FeatureUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAccessPortalTypeFeatureMapUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsAccessPortalTypeFeatureMapUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsAccessPortalTypeFeatureMapUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsAccessPortalTypeFeatureMapUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsAccessPortalTypeFeatureMapUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsAccessPortalTypeFeatureMapUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsAccessPortalTypeFeatureMapUniquePDSAValidator.ParameterNames.AccessPortalTypeFeatureMapUid).Value = Entity.AccessPortalTypeFeatureMapUid;
      this.Properties.GetByName(IsAccessPortalTypeFeatureMapUniquePDSAValidator.ParameterNames.AccessPortalTypeUid).Value = Entity.AccessPortalTypeUid;
      this.Properties.GetByName(IsAccessPortalTypeFeatureMapUniquePDSAValidator.ParameterNames.FeatureUid).Value = Entity.FeatureUid;
      this.Properties.GetByName(IsAccessPortalTypeFeatureMapUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsAccessPortalTypeFeatureMapUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsAccessPortalTypeFeatureMapUniquePDSAValidator.ParameterNames.AccessPortalTypeFeatureMapUid).IsNull == false)
        Entity.AccessPortalTypeFeatureMapUid = this.Properties.GetByName(IsAccessPortalTypeFeatureMapUniquePDSAValidator.ParameterNames.AccessPortalTypeFeatureMapUid).GetAsGuid();
      if(this.Properties.GetByName(IsAccessPortalTypeFeatureMapUniquePDSAValidator.ParameterNames.AccessPortalTypeUid).IsNull == false)
        Entity.AccessPortalTypeUid = this.Properties.GetByName(IsAccessPortalTypeFeatureMapUniquePDSAValidator.ParameterNames.AccessPortalTypeUid).GetAsGuid();
      if(this.Properties.GetByName(IsAccessPortalTypeFeatureMapUniquePDSAValidator.ParameterNames.FeatureUid).IsNull == false)
        Entity.FeatureUid = this.Properties.GetByName(IsAccessPortalTypeFeatureMapUniquePDSAValidator.ParameterNames.FeatureUid).GetAsGuid();
      if(this.Properties.GetByName(IsAccessPortalTypeFeatureMapUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsAccessPortalTypeFeatureMapUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsAccessPortalTypeFeatureMapUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsAccessPortalTypeFeatureMapUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsAccessPortalTypeFeatureMapUniquePDSA class.
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
    /// Returns '@AccessPortalTypeFeatureMapUid'
    /// </summary>
    public static string AccessPortalTypeFeatureMapUid = "@AccessPortalTypeFeatureMapUid";
    /// <summary>
    /// Returns '@AccessPortalTypeUid'
    /// </summary>
    public static string AccessPortalTypeUid = "@AccessPortalTypeUid";
    /// <summary>
    /// Returns '@FeatureUid'
    /// </summary>
    public static string FeatureUid = "@FeatureUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsAccessPortalTypeFeatureMapUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@AccessPortalTypeFeatureMapUid'
    /// </summary>
    public static string AccessPortalTypeFeatureMapUid = "@AccessPortalTypeFeatureMapUid";
    /// <summary>
    /// Returns '@AccessPortalTypeUid'
    /// </summary>
    public static string AccessPortalTypeUid = "@AccessPortalTypeUid";
    /// <summary>
    /// Returns '@FeatureUid'
    /// </summary>
    public static string FeatureUid = "@FeatureUid";
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

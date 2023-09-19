using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsAccessPortalAreaUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsAccessPortalAreaUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsAccessPortalAreaUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsAccessPortalAreaUniquePDSA Entity
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
    /// Clones the current IsAccessPortalAreaUniquePDSA
    /// </summary>
    /// <returns>A cloned IsAccessPortalAreaUniquePDSA object</returns>
    public IsAccessPortalAreaUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsAccessPortalAreaUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsAccessPortalAreaUniquePDSA entity to clone</param>
    /// <returns>A cloned IsAccessPortalAreaUniquePDSA object</returns>
    public IsAccessPortalAreaUniquePDSA CloneEntity(IsAccessPortalAreaUniquePDSA entityToClone)
    {
      IsAccessPortalAreaUniquePDSA newEntity = new IsAccessPortalAreaUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsAccessPortalAreaUniquePDSAValidator.ParameterNames.AccessPortalAreaUid, GetResourceMessage("GCS_IsAccessPortalAreaUniquePDSA_AccessPortalAreaUid_Header", "Access Portal Area Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsAccessPortalAreaUniquePDSA_AccessPortalAreaUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAccessPortalAreaUniquePDSAValidator.ParameterNames.AccessPortalUid, GetResourceMessage("GCS_IsAccessPortalAreaUniquePDSA_AccessPortalUid_Header", "Access Portal Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsAccessPortalAreaUniquePDSA_AccessPortalUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAccessPortalAreaUniquePDSAValidator.ParameterNames.AccessPortalAreaTypeUid, GetResourceMessage("GCS_IsAccessPortalAreaUniquePDSA_AccessPortalAreaTypeUid_Header", "Access Portal Area Type Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsAccessPortalAreaUniquePDSA_AccessPortalAreaTypeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAccessPortalAreaUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsAccessPortalAreaUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsAccessPortalAreaUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsAccessPortalAreaUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsAccessPortalAreaUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsAccessPortalAreaUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsAccessPortalAreaUniquePDSAValidator.ParameterNames.AccessPortalAreaUid).Value = Entity.AccessPortalAreaUid;
      this.Properties.GetByName(IsAccessPortalAreaUniquePDSAValidator.ParameterNames.AccessPortalUid).Value = Entity.AccessPortalUid;
      this.Properties.GetByName(IsAccessPortalAreaUniquePDSAValidator.ParameterNames.AccessPortalAreaTypeUid).Value = Entity.AccessPortalAreaTypeUid;
      this.Properties.GetByName(IsAccessPortalAreaUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsAccessPortalAreaUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsAccessPortalAreaUniquePDSAValidator.ParameterNames.AccessPortalAreaUid).IsNull == false)
        Entity.AccessPortalAreaUid = this.Properties.GetByName(IsAccessPortalAreaUniquePDSAValidator.ParameterNames.AccessPortalAreaUid).GetAsGuid();
      if(this.Properties.GetByName(IsAccessPortalAreaUniquePDSAValidator.ParameterNames.AccessPortalUid).IsNull == false)
        Entity.AccessPortalUid = this.Properties.GetByName(IsAccessPortalAreaUniquePDSAValidator.ParameterNames.AccessPortalUid).GetAsGuid();
      if(this.Properties.GetByName(IsAccessPortalAreaUniquePDSAValidator.ParameterNames.AccessPortalAreaTypeUid).IsNull == false)
        Entity.AccessPortalAreaTypeUid = this.Properties.GetByName(IsAccessPortalAreaUniquePDSAValidator.ParameterNames.AccessPortalAreaTypeUid).GetAsGuid();
      if(this.Properties.GetByName(IsAccessPortalAreaUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsAccessPortalAreaUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsAccessPortalAreaUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsAccessPortalAreaUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsAccessPortalAreaUniquePDSA class.
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
    /// Returns '@AccessPortalAreaUid'
    /// </summary>
    public static string AccessPortalAreaUid = "@AccessPortalAreaUid";
    /// <summary>
    /// Returns '@AccessPortalUid'
    /// </summary>
    public static string AccessPortalUid = "@AccessPortalUid";
    /// <summary>
    /// Returns '@AccessPortalAreaTypeUid'
    /// </summary>
    public static string AccessPortalAreaTypeUid = "@AccessPortalAreaTypeUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsAccessPortalAreaUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@AccessPortalAreaUid'
    /// </summary>
    public static string AccessPortalAreaUid = "@AccessPortalAreaUid";
    /// <summary>
    /// Returns '@AccessPortalUid'
    /// </summary>
    public static string AccessPortalUid = "@AccessPortalUid";
    /// <summary>
    /// Returns '@AccessPortalAreaTypeUid'
    /// </summary>
    public static string AccessPortalAreaTypeUid = "@AccessPortalAreaTypeUid";
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

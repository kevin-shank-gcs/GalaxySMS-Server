using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsAccessPortalTypeAccessPortalCommandUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsAccessPortalTypeAccessPortalCommandUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsAccessPortalTypeAccessPortalCommandUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsAccessPortalTypeAccessPortalCommandUniquePDSA Entity
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
    /// Clones the current IsAccessPortalTypeAccessPortalCommandUniquePDSA
    /// </summary>
    /// <returns>A cloned IsAccessPortalTypeAccessPortalCommandUniquePDSA object</returns>
    public IsAccessPortalTypeAccessPortalCommandUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsAccessPortalTypeAccessPortalCommandUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsAccessPortalTypeAccessPortalCommandUniquePDSA entity to clone</param>
    /// <returns>A cloned IsAccessPortalTypeAccessPortalCommandUniquePDSA object</returns>
    public IsAccessPortalTypeAccessPortalCommandUniquePDSA CloneEntity(IsAccessPortalTypeAccessPortalCommandUniquePDSA entityToClone)
    {
      IsAccessPortalTypeAccessPortalCommandUniquePDSA newEntity = new IsAccessPortalTypeAccessPortalCommandUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsAccessPortalTypeAccessPortalCommandUniquePDSAValidator.ParameterNames.AccessPortalTypeAccessPortalCommandUid, GetResourceMessage("GCS_IsAccessPortalTypeAccessPortalCommandUniquePDSA_AccessPortalTypeAccessPortalCommandUid_Header", "Access Portal Type Access Portal Command Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsAccessPortalTypeAccessPortalCommandUniquePDSA_AccessPortalTypeAccessPortalCommandUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAccessPortalTypeAccessPortalCommandUniquePDSAValidator.ParameterNames.AccessPortalTypeUid, GetResourceMessage("GCS_IsAccessPortalTypeAccessPortalCommandUniquePDSA_AccessPortalTypeUid_Header", "Access Portal Type Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsAccessPortalTypeAccessPortalCommandUniquePDSA_AccessPortalTypeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAccessPortalTypeAccessPortalCommandUniquePDSAValidator.ParameterNames.AccessPortalCommandUid, GetResourceMessage("GCS_IsAccessPortalTypeAccessPortalCommandUniquePDSA_AccessPortalCommandUid_Header", "Access Portal Command Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsAccessPortalTypeAccessPortalCommandUniquePDSA_AccessPortalCommandUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAccessPortalTypeAccessPortalCommandUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsAccessPortalTypeAccessPortalCommandUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsAccessPortalTypeAccessPortalCommandUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsAccessPortalTypeAccessPortalCommandUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsAccessPortalTypeAccessPortalCommandUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsAccessPortalTypeAccessPortalCommandUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsAccessPortalTypeAccessPortalCommandUniquePDSAValidator.ParameterNames.AccessPortalTypeAccessPortalCommandUid).Value = Entity.AccessPortalTypeAccessPortalCommandUid;
      this.Properties.GetByName(IsAccessPortalTypeAccessPortalCommandUniquePDSAValidator.ParameterNames.AccessPortalTypeUid).Value = Entity.AccessPortalTypeUid;
      this.Properties.GetByName(IsAccessPortalTypeAccessPortalCommandUniquePDSAValidator.ParameterNames.AccessPortalCommandUid).Value = Entity.AccessPortalCommandUid;
      this.Properties.GetByName(IsAccessPortalTypeAccessPortalCommandUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsAccessPortalTypeAccessPortalCommandUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsAccessPortalTypeAccessPortalCommandUniquePDSAValidator.ParameterNames.AccessPortalTypeAccessPortalCommandUid).IsNull == false)
        Entity.AccessPortalTypeAccessPortalCommandUid = this.Properties.GetByName(IsAccessPortalTypeAccessPortalCommandUniquePDSAValidator.ParameterNames.AccessPortalTypeAccessPortalCommandUid).GetAsGuid();
      if(this.Properties.GetByName(IsAccessPortalTypeAccessPortalCommandUniquePDSAValidator.ParameterNames.AccessPortalTypeUid).IsNull == false)
        Entity.AccessPortalTypeUid = this.Properties.GetByName(IsAccessPortalTypeAccessPortalCommandUniquePDSAValidator.ParameterNames.AccessPortalTypeUid).GetAsGuid();
      if(this.Properties.GetByName(IsAccessPortalTypeAccessPortalCommandUniquePDSAValidator.ParameterNames.AccessPortalCommandUid).IsNull == false)
        Entity.AccessPortalCommandUid = this.Properties.GetByName(IsAccessPortalTypeAccessPortalCommandUniquePDSAValidator.ParameterNames.AccessPortalCommandUid).GetAsGuid();
      if(this.Properties.GetByName(IsAccessPortalTypeAccessPortalCommandUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsAccessPortalTypeAccessPortalCommandUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsAccessPortalTypeAccessPortalCommandUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsAccessPortalTypeAccessPortalCommandUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsAccessPortalTypeAccessPortalCommandUniquePDSA class.
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
    /// Returns '@AccessPortalTypeAccessPortalCommandUid'
    /// </summary>
    public static string AccessPortalTypeAccessPortalCommandUid = "@AccessPortalTypeAccessPortalCommandUid";
    /// <summary>
    /// Returns '@AccessPortalTypeUid'
    /// </summary>
    public static string AccessPortalTypeUid = "@AccessPortalTypeUid";
    /// <summary>
    /// Returns '@AccessPortalCommandUid'
    /// </summary>
    public static string AccessPortalCommandUid = "@AccessPortalCommandUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsAccessPortalTypeAccessPortalCommandUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@AccessPortalTypeAccessPortalCommandUid'
    /// </summary>
    public static string AccessPortalTypeAccessPortalCommandUid = "@AccessPortalTypeAccessPortalCommandUid";
    /// <summary>
    /// Returns '@AccessPortalTypeUid'
    /// </summary>
    public static string AccessPortalTypeUid = "@AccessPortalTypeUid";
    /// <summary>
    /// Returns '@AccessPortalCommandUid'
    /// </summary>
    public static string AccessPortalCommandUid = "@AccessPortalCommandUid";
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

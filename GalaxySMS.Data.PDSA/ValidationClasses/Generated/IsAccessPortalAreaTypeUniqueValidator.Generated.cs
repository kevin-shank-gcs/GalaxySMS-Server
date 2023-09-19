using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsAccessPortalAreaTypeUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsAccessPortalAreaTypeUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsAccessPortalAreaTypeUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsAccessPortalAreaTypeUniquePDSA Entity
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
    /// Clones the current IsAccessPortalAreaTypeUniquePDSA
    /// </summary>
    /// <returns>A cloned IsAccessPortalAreaTypeUniquePDSA object</returns>
    public IsAccessPortalAreaTypeUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsAccessPortalAreaTypeUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsAccessPortalAreaTypeUniquePDSA entity to clone</param>
    /// <returns>A cloned IsAccessPortalAreaTypeUniquePDSA object</returns>
    public IsAccessPortalAreaTypeUniquePDSA CloneEntity(IsAccessPortalAreaTypeUniquePDSA entityToClone)
    {
      IsAccessPortalAreaTypeUniquePDSA newEntity = new IsAccessPortalAreaTypeUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsAccessPortalAreaTypeUniquePDSAValidator.ParameterNames.AccessPortalAreaTypeUid, GetResourceMessage("GCS_IsAccessPortalAreaTypeUniquePDSA_AccessPortalAreaTypeUid_Header", "Access Portal Area Type Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsAccessPortalAreaTypeUniquePDSA_AccessPortalAreaTypeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAccessPortalAreaTypeUniquePDSAValidator.ParameterNames.Tag, GetResourceMessage("GCS_IsAccessPortalAreaTypeUniquePDSA_Tag_Header", "Tag"), false, typeof(string), 8000, GetResourceMessage("GCS_IsAccessPortalAreaTypeUniquePDSA_Tag_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAccessPortalAreaTypeUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsAccessPortalAreaTypeUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsAccessPortalAreaTypeUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsAccessPortalAreaTypeUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsAccessPortalAreaTypeUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsAccessPortalAreaTypeUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsAccessPortalAreaTypeUniquePDSAValidator.ParameterNames.AccessPortalAreaTypeUid).Value = Entity.AccessPortalAreaTypeUid;
      this.Properties.GetByName(IsAccessPortalAreaTypeUniquePDSAValidator.ParameterNames.Tag).Value = Entity.Tag;
      this.Properties.GetByName(IsAccessPortalAreaTypeUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsAccessPortalAreaTypeUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsAccessPortalAreaTypeUniquePDSAValidator.ParameterNames.AccessPortalAreaTypeUid).IsNull == false)
        Entity.AccessPortalAreaTypeUid = this.Properties.GetByName(IsAccessPortalAreaTypeUniquePDSAValidator.ParameterNames.AccessPortalAreaTypeUid).GetAsGuid();
      if(this.Properties.GetByName(IsAccessPortalAreaTypeUniquePDSAValidator.ParameterNames.Tag).IsNull == false)
        Entity.Tag = this.Properties.GetByName(IsAccessPortalAreaTypeUniquePDSAValidator.ParameterNames.Tag).GetAsString();
      if(this.Properties.GetByName(IsAccessPortalAreaTypeUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsAccessPortalAreaTypeUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsAccessPortalAreaTypeUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsAccessPortalAreaTypeUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsAccessPortalAreaTypeUniquePDSA class.
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
    /// Returns '@AccessPortalAreaTypeUid'
    /// </summary>
    public static string AccessPortalAreaTypeUid = "@AccessPortalAreaTypeUid";
    /// <summary>
    /// Returns '@Tag'
    /// </summary>
    public static string Tag = "@Tag";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsAccessPortalAreaTypeUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@AccessPortalAreaTypeUid'
    /// </summary>
    public static string AccessPortalAreaTypeUid = "@AccessPortalAreaTypeUid";
    /// <summary>
    /// Returns '@Tag'
    /// </summary>
    public static string Tag = "@Tag";
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

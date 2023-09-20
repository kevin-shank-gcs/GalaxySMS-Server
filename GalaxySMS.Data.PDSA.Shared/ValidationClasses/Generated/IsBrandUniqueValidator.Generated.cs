using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsBrandUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsBrandUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsBrandUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsBrandUniquePDSA Entity
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
    /// Clones the current IsBrandUniquePDSA
    /// </summary>
    /// <returns>A cloned IsBrandUniquePDSA object</returns>
    public IsBrandUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsBrandUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsBrandUniquePDSA entity to clone</param>
    /// <returns>A cloned IsBrandUniquePDSA object</returns>
    public IsBrandUniquePDSA CloneEntity(IsBrandUniquePDSA entityToClone)
    {
      IsBrandUniquePDSA newEntity = new IsBrandUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsBrandUniquePDSAValidator.ParameterNames.BrandUid, GetResourceMessage("GCS_IsBrandUniquePDSA_BrandUid_Header", "Brand Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsBrandUniquePDSA_BrandUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsBrandUniquePDSAValidator.ParameterNames.BrandName, GetResourceMessage("GCS_IsBrandUniquePDSA_BrandName_Header", "Brand Name"), false, typeof(string), 8000, GetResourceMessage("GCS_IsBrandUniquePDSA_BrandName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsBrandUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsBrandUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsBrandUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsBrandUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsBrandUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsBrandUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsBrandUniquePDSAValidator.ParameterNames.BrandUid).Value = Entity.BrandUid;
      this.Properties.GetByName(IsBrandUniquePDSAValidator.ParameterNames.BrandName).Value = Entity.BrandName;
      this.Properties.GetByName(IsBrandUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsBrandUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsBrandUniquePDSAValidator.ParameterNames.BrandUid).IsNull == false)
        Entity.BrandUid = this.Properties.GetByName(IsBrandUniquePDSAValidator.ParameterNames.BrandUid).GetAsGuid();
      if(this.Properties.GetByName(IsBrandUniquePDSAValidator.ParameterNames.BrandName).IsNull == false)
        Entity.BrandName = this.Properties.GetByName(IsBrandUniquePDSAValidator.ParameterNames.BrandName).GetAsString();
      if(this.Properties.GetByName(IsBrandUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsBrandUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsBrandUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsBrandUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsBrandUniquePDSA class.
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
    /// Returns '@BrandUid'
    /// </summary>
    public static string BrandUid = "@BrandUid";
    /// <summary>
    /// Returns '@BrandName'
    /// </summary>
    public static string BrandName = "@BrandName";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsBrandUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@BrandUid'
    /// </summary>
    public static string BrandUid = "@BrandUid";
    /// <summary>
    /// Returns '@BrandName'
    /// </summary>
    public static string BrandName = "@BrandName";
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

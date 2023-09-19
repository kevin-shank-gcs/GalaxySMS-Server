using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsLiquidCrystalDisplayUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsLiquidCrystalDisplayUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsLiquidCrystalDisplayUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsLiquidCrystalDisplayUniquePDSA Entity
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
    /// Clones the current IsLiquidCrystalDisplayUniquePDSA
    /// </summary>
    /// <returns>A cloned IsLiquidCrystalDisplayUniquePDSA object</returns>
    public IsLiquidCrystalDisplayUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsLiquidCrystalDisplayUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsLiquidCrystalDisplayUniquePDSA entity to clone</param>
    /// <returns>A cloned IsLiquidCrystalDisplayUniquePDSA object</returns>
    public IsLiquidCrystalDisplayUniquePDSA CloneEntity(IsLiquidCrystalDisplayUniquePDSA entityToClone)
    {
      IsLiquidCrystalDisplayUniquePDSA newEntity = new IsLiquidCrystalDisplayUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsLiquidCrystalDisplayUniquePDSAValidator.ParameterNames.LiquidCrystalDisplayUid, GetResourceMessage("GCS_IsLiquidCrystalDisplayUniquePDSA_LiquidCrystalDisplayUid_Header", "Liquid Crystal Display Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsLiquidCrystalDisplayUniquePDSA_LiquidCrystalDisplayUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsLiquidCrystalDisplayUniquePDSAValidator.ParameterNames.SiteUid, GetResourceMessage("GCS_IsLiquidCrystalDisplayUniquePDSA_SiteUid_Header", "Site Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsLiquidCrystalDisplayUniquePDSA_SiteUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsLiquidCrystalDisplayUniquePDSAValidator.ParameterNames.LcdName, GetResourceMessage("GCS_IsLiquidCrystalDisplayUniquePDSA_LcdName_Header", "Lcd Name"), false, typeof(string), 8000, GetResourceMessage("GCS_IsLiquidCrystalDisplayUniquePDSA_LcdName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsLiquidCrystalDisplayUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsLiquidCrystalDisplayUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsLiquidCrystalDisplayUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsLiquidCrystalDisplayUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsLiquidCrystalDisplayUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsLiquidCrystalDisplayUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsLiquidCrystalDisplayUniquePDSAValidator.ParameterNames.LiquidCrystalDisplayUid).Value = Entity.LiquidCrystalDisplayUid;
      this.Properties.GetByName(IsLiquidCrystalDisplayUniquePDSAValidator.ParameterNames.SiteUid).Value = Entity.SiteUid;
      this.Properties.GetByName(IsLiquidCrystalDisplayUniquePDSAValidator.ParameterNames.LcdName).Value = Entity.LcdName;
      this.Properties.GetByName(IsLiquidCrystalDisplayUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsLiquidCrystalDisplayUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsLiquidCrystalDisplayUniquePDSAValidator.ParameterNames.LiquidCrystalDisplayUid).IsNull == false)
        Entity.LiquidCrystalDisplayUid = this.Properties.GetByName(IsLiquidCrystalDisplayUniquePDSAValidator.ParameterNames.LiquidCrystalDisplayUid).GetAsGuid();
      if(this.Properties.GetByName(IsLiquidCrystalDisplayUniquePDSAValidator.ParameterNames.SiteUid).IsNull == false)
        Entity.SiteUid = this.Properties.GetByName(IsLiquidCrystalDisplayUniquePDSAValidator.ParameterNames.SiteUid).GetAsGuid();
      if(this.Properties.GetByName(IsLiquidCrystalDisplayUniquePDSAValidator.ParameterNames.LcdName).IsNull == false)
        Entity.LcdName = this.Properties.GetByName(IsLiquidCrystalDisplayUniquePDSAValidator.ParameterNames.LcdName).GetAsString();
      if(this.Properties.GetByName(IsLiquidCrystalDisplayUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsLiquidCrystalDisplayUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsLiquidCrystalDisplayUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsLiquidCrystalDisplayUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsLiquidCrystalDisplayUniquePDSA class.
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
    /// Returns '@LiquidCrystalDisplayUid'
    /// </summary>
    public static string LiquidCrystalDisplayUid = "@LiquidCrystalDisplayUid";
    /// <summary>
    /// Returns '@SiteUid'
    /// </summary>
    public static string SiteUid = "@SiteUid";
    /// <summary>
    /// Returns '@LcdName'
    /// </summary>
    public static string LcdName = "@LcdName";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsLiquidCrystalDisplayUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@LiquidCrystalDisplayUid'
    /// </summary>
    public static string LiquidCrystalDisplayUid = "@LiquidCrystalDisplayUid";
    /// <summary>
    /// Returns '@SiteUid'
    /// </summary>
    public static string SiteUid = "@SiteUid";
    /// <summary>
    /// Returns '@LcdName'
    /// </summary>
    public static string LcdName = "@LcdName";
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

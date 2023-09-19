using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsOutputDeviceUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsOutputDeviceUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsOutputDeviceUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsOutputDeviceUniquePDSA Entity
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
    /// Clones the current IsOutputDeviceUniquePDSA
    /// </summary>
    /// <returns>A cloned IsOutputDeviceUniquePDSA object</returns>
    public IsOutputDeviceUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsOutputDeviceUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsOutputDeviceUniquePDSA entity to clone</param>
    /// <returns>A cloned IsOutputDeviceUniquePDSA object</returns>
    public IsOutputDeviceUniquePDSA CloneEntity(IsOutputDeviceUniquePDSA entityToClone)
    {
      IsOutputDeviceUniquePDSA newEntity = new IsOutputDeviceUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsOutputDeviceUniquePDSAValidator.ParameterNames.OutputDeviceUid, GetResourceMessage("GCS_IsOutputDeviceUniquePDSA_OutputDeviceUid_Header", "Output Device Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsOutputDeviceUniquePDSA_OutputDeviceUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsOutputDeviceUniquePDSAValidator.ParameterNames.SiteUid, GetResourceMessage("GCS_IsOutputDeviceUniquePDSA_SiteUid_Header", "Site Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsOutputDeviceUniquePDSA_SiteUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsOutputDeviceUniquePDSAValidator.ParameterNames.OutputName, GetResourceMessage("GCS_IsOutputDeviceUniquePDSA_OutputName_Header", "Output Name"), false, typeof(string), 8000, GetResourceMessage("GCS_IsOutputDeviceUniquePDSA_OutputName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsOutputDeviceUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsOutputDeviceUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsOutputDeviceUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsOutputDeviceUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsOutputDeviceUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsOutputDeviceUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsOutputDeviceUniquePDSAValidator.ParameterNames.OutputDeviceUid).Value = Entity.OutputDeviceUid;
      this.Properties.GetByName(IsOutputDeviceUniquePDSAValidator.ParameterNames.SiteUid).Value = Entity.SiteUid;
      this.Properties.GetByName(IsOutputDeviceUniquePDSAValidator.ParameterNames.OutputName).Value = Entity.OutputName;
      this.Properties.GetByName(IsOutputDeviceUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsOutputDeviceUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsOutputDeviceUniquePDSAValidator.ParameterNames.OutputDeviceUid).IsNull == false)
        Entity.OutputDeviceUid = this.Properties.GetByName(IsOutputDeviceUniquePDSAValidator.ParameterNames.OutputDeviceUid).GetAsGuid();
      if(this.Properties.GetByName(IsOutputDeviceUniquePDSAValidator.ParameterNames.SiteUid).IsNull == false)
        Entity.SiteUid = this.Properties.GetByName(IsOutputDeviceUniquePDSAValidator.ParameterNames.SiteUid).GetAsGuid();
      if(this.Properties.GetByName(IsOutputDeviceUniquePDSAValidator.ParameterNames.OutputName).IsNull == false)
        Entity.OutputName = this.Properties.GetByName(IsOutputDeviceUniquePDSAValidator.ParameterNames.OutputName).GetAsString();
      if(this.Properties.GetByName(IsOutputDeviceUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsOutputDeviceUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsOutputDeviceUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsOutputDeviceUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsOutputDeviceUniquePDSA class.
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
    /// Returns '@OutputDeviceUid'
    /// </summary>
    public static string OutputDeviceUid = "@OutputDeviceUid";
    /// <summary>
    /// Returns '@SiteUid'
    /// </summary>
    public static string SiteUid = "@SiteUid";
    /// <summary>
    /// Returns '@OutputName'
    /// </summary>
    public static string OutputName = "@OutputName";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsOutputDeviceUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@OutputDeviceUid'
    /// </summary>
    public static string OutputDeviceUid = "@OutputDeviceUid";
    /// <summary>
    /// Returns '@SiteUid'
    /// </summary>
    public static string SiteUid = "@SiteUid";
    /// <summary>
    /// Returns '@OutputName'
    /// </summary>
    public static string OutputName = "@OutputName";
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

using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsAccessPortalAuxiliaryOutputModeUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsAccessPortalAuxiliaryOutputModeUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsAccessPortalAuxiliaryOutputModeUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsAccessPortalAuxiliaryOutputModeUniquePDSA Entity
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
    /// Clones the current IsAccessPortalAuxiliaryOutputModeUniquePDSA
    /// </summary>
    /// <returns>A cloned IsAccessPortalAuxiliaryOutputModeUniquePDSA object</returns>
    public IsAccessPortalAuxiliaryOutputModeUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsAccessPortalAuxiliaryOutputModeUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsAccessPortalAuxiliaryOutputModeUniquePDSA entity to clone</param>
    /// <returns>A cloned IsAccessPortalAuxiliaryOutputModeUniquePDSA object</returns>
    public IsAccessPortalAuxiliaryOutputModeUniquePDSA CloneEntity(IsAccessPortalAuxiliaryOutputModeUniquePDSA entityToClone)
    {
      IsAccessPortalAuxiliaryOutputModeUniquePDSA newEntity = new IsAccessPortalAuxiliaryOutputModeUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsAccessPortalAuxiliaryOutputModeUniquePDSAValidator.ParameterNames.AccessPortalAuxiliaryOutputModeUid, GetResourceMessage("GCS_IsAccessPortalAuxiliaryOutputModeUniquePDSA_AccessPortalAuxiliaryOutputModeUid_Header", "Access Portal Auxiliary Output Mode Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsAccessPortalAuxiliaryOutputModeUniquePDSA_AccessPortalAuxiliaryOutputModeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAccessPortalAuxiliaryOutputModeUniquePDSAValidator.ParameterNames.Display, GetResourceMessage("GCS_IsAccessPortalAuxiliaryOutputModeUniquePDSA_Display_Header", "Display"), false, typeof(string), 8000, GetResourceMessage("GCS_IsAccessPortalAuxiliaryOutputModeUniquePDSA_Display_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAccessPortalAuxiliaryOutputModeUniquePDSAValidator.ParameterNames.Code, GetResourceMessage("GCS_IsAccessPortalAuxiliaryOutputModeUniquePDSA_Code_Header", "Code"), false, typeof(short), 0, GetResourceMessage("GCS_IsAccessPortalAuxiliaryOutputModeUniquePDSA_Code_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsAccessPortalAuxiliaryOutputModeUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsAccessPortalAuxiliaryOutputModeUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsAccessPortalAuxiliaryOutputModeUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsAccessPortalAuxiliaryOutputModeUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsAccessPortalAuxiliaryOutputModeUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsAccessPortalAuxiliaryOutputModeUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsAccessPortalAuxiliaryOutputModeUniquePDSAValidator.ParameterNames.AccessPortalAuxiliaryOutputModeUid).Value = Entity.AccessPortalAuxiliaryOutputModeUid;
      this.Properties.GetByName(IsAccessPortalAuxiliaryOutputModeUniquePDSAValidator.ParameterNames.Display).Value = Entity.Display;
      this.Properties.GetByName(IsAccessPortalAuxiliaryOutputModeUniquePDSAValidator.ParameterNames.Code).Value = Entity.Code;
      this.Properties.GetByName(IsAccessPortalAuxiliaryOutputModeUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsAccessPortalAuxiliaryOutputModeUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsAccessPortalAuxiliaryOutputModeUniquePDSAValidator.ParameterNames.AccessPortalAuxiliaryOutputModeUid).IsNull == false)
        Entity.AccessPortalAuxiliaryOutputModeUid = this.Properties.GetByName(IsAccessPortalAuxiliaryOutputModeUniquePDSAValidator.ParameterNames.AccessPortalAuxiliaryOutputModeUid).GetAsGuid();
      if(this.Properties.GetByName(IsAccessPortalAuxiliaryOutputModeUniquePDSAValidator.ParameterNames.Display).IsNull == false)
        Entity.Display = this.Properties.GetByName(IsAccessPortalAuxiliaryOutputModeUniquePDSAValidator.ParameterNames.Display).GetAsString();
      if(this.Properties.GetByName(IsAccessPortalAuxiliaryOutputModeUniquePDSAValidator.ParameterNames.Code).IsNull == false)
        Entity.Code = this.Properties.GetByName(IsAccessPortalAuxiliaryOutputModeUniquePDSAValidator.ParameterNames.Code).GetAsShort();
      if(this.Properties.GetByName(IsAccessPortalAuxiliaryOutputModeUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsAccessPortalAuxiliaryOutputModeUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsAccessPortalAuxiliaryOutputModeUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsAccessPortalAuxiliaryOutputModeUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsAccessPortalAuxiliaryOutputModeUniquePDSA class.
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
    /// Returns '@AccessPortalAuxiliaryOutputModeUid'
    /// </summary>
    public static string AccessPortalAuxiliaryOutputModeUid = "@AccessPortalAuxiliaryOutputModeUid";
    /// <summary>
    /// Returns '@Display'
    /// </summary>
    public static string Display = "@Display";
    /// <summary>
    /// Returns '@Code'
    /// </summary>
    public static string Code = "@Code";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsAccessPortalAuxiliaryOutputModeUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@AccessPortalAuxiliaryOutputModeUid'
    /// </summary>
    public static string AccessPortalAuxiliaryOutputModeUid = "@AccessPortalAuxiliaryOutputModeUid";
    /// <summary>
    /// Returns '@Display'
    /// </summary>
    public static string Display = "@Display";
    /// <summary>
    /// Returns '@Code'
    /// </summary>
    public static string Code = "@Code";
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

using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsAccessPortalAlertEventUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsAccessPortalAlertEventUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsAccessPortalAlertEventUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsAccessPortalAlertEventUniquePDSA Entity
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
    /// Clones the current IsAccessPortalAlertEventUniquePDSA
    /// </summary>
    /// <returns>A cloned IsAccessPortalAlertEventUniquePDSA object</returns>
    public IsAccessPortalAlertEventUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsAccessPortalAlertEventUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsAccessPortalAlertEventUniquePDSA entity to clone</param>
    /// <returns>A cloned IsAccessPortalAlertEventUniquePDSA object</returns>
    public IsAccessPortalAlertEventUniquePDSA CloneEntity(IsAccessPortalAlertEventUniquePDSA entityToClone)
    {
      IsAccessPortalAlertEventUniquePDSA newEntity = new IsAccessPortalAlertEventUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsAccessPortalAlertEventUniquePDSAValidator.ParameterNames.AccessPortalAlertEventUid, GetResourceMessage("GCS_IsAccessPortalAlertEventUniquePDSA_AccessPortalAlertEventUid_Header", "Access Portal Alert Event Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsAccessPortalAlertEventUniquePDSA_AccessPortalAlertEventUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAccessPortalAlertEventUniquePDSAValidator.ParameterNames.AccessPortalUid, GetResourceMessage("GCS_IsAccessPortalAlertEventUniquePDSA_AccessPortalUid_Header", "Access Portal Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsAccessPortalAlertEventUniquePDSA_AccessPortalUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAccessPortalAlertEventUniquePDSAValidator.ParameterNames.AccessPortalAlertEventTypeUid, GetResourceMessage("GCS_IsAccessPortalAlertEventUniquePDSA_AccessPortalAlertEventTypeUid_Header", "Access Portal Alert Event Type Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsAccessPortalAlertEventUniquePDSA_AccessPortalAlertEventTypeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAccessPortalAlertEventUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsAccessPortalAlertEventUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsAccessPortalAlertEventUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsAccessPortalAlertEventUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsAccessPortalAlertEventUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsAccessPortalAlertEventUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsAccessPortalAlertEventUniquePDSAValidator.ParameterNames.AccessPortalAlertEventUid).Value = Entity.AccessPortalAlertEventUid;
      this.Properties.GetByName(IsAccessPortalAlertEventUniquePDSAValidator.ParameterNames.AccessPortalUid).Value = Entity.AccessPortalUid;
      this.Properties.GetByName(IsAccessPortalAlertEventUniquePDSAValidator.ParameterNames.AccessPortalAlertEventTypeUid).Value = Entity.AccessPortalAlertEventTypeUid;
      this.Properties.GetByName(IsAccessPortalAlertEventUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsAccessPortalAlertEventUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsAccessPortalAlertEventUniquePDSAValidator.ParameterNames.AccessPortalAlertEventUid).IsNull == false)
        Entity.AccessPortalAlertEventUid = this.Properties.GetByName(IsAccessPortalAlertEventUniquePDSAValidator.ParameterNames.AccessPortalAlertEventUid).GetAsGuid();
      if(this.Properties.GetByName(IsAccessPortalAlertEventUniquePDSAValidator.ParameterNames.AccessPortalUid).IsNull == false)
        Entity.AccessPortalUid = this.Properties.GetByName(IsAccessPortalAlertEventUniquePDSAValidator.ParameterNames.AccessPortalUid).GetAsGuid();
      if(this.Properties.GetByName(IsAccessPortalAlertEventUniquePDSAValidator.ParameterNames.AccessPortalAlertEventTypeUid).IsNull == false)
        Entity.AccessPortalAlertEventTypeUid = this.Properties.GetByName(IsAccessPortalAlertEventUniquePDSAValidator.ParameterNames.AccessPortalAlertEventTypeUid).GetAsGuid();
      if(this.Properties.GetByName(IsAccessPortalAlertEventUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsAccessPortalAlertEventUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsAccessPortalAlertEventUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsAccessPortalAlertEventUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsAccessPortalAlertEventUniquePDSA class.
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
    /// Returns '@AccessPortalAlertEventUid'
    /// </summary>
    public static string AccessPortalAlertEventUid = "@AccessPortalAlertEventUid";
    /// <summary>
    /// Returns '@AccessPortalUid'
    /// </summary>
    public static string AccessPortalUid = "@AccessPortalUid";
    /// <summary>
    /// Returns '@AccessPortalAlertEventTypeUid'
    /// </summary>
    public static string AccessPortalAlertEventTypeUid = "@AccessPortalAlertEventTypeUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsAccessPortalAlertEventUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@AccessPortalAlertEventUid'
    /// </summary>
    public static string AccessPortalAlertEventUid = "@AccessPortalAlertEventUid";
    /// <summary>
    /// Returns '@AccessPortalUid'
    /// </summary>
    public static string AccessPortalUid = "@AccessPortalUid";
    /// <summary>
    /// Returns '@AccessPortalAlertEventTypeUid'
    /// </summary>
    public static string AccessPortalAlertEventTypeUid = "@AccessPortalAlertEventTypeUid";
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

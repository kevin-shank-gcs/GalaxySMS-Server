using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsAccessPortalElevatorControlTypePanelModelUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsAccessPortalElevatorControlTypePanelModelUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsAccessPortalElevatorControlTypePanelModelUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsAccessPortalElevatorControlTypePanelModelUniquePDSA Entity
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
    /// Clones the current IsAccessPortalElevatorControlTypePanelModelUniquePDSA
    /// </summary>
    /// <returns>A cloned IsAccessPortalElevatorControlTypePanelModelUniquePDSA object</returns>
    public IsAccessPortalElevatorControlTypePanelModelUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsAccessPortalElevatorControlTypePanelModelUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsAccessPortalElevatorControlTypePanelModelUniquePDSA entity to clone</param>
    /// <returns>A cloned IsAccessPortalElevatorControlTypePanelModelUniquePDSA object</returns>
    public IsAccessPortalElevatorControlTypePanelModelUniquePDSA CloneEntity(IsAccessPortalElevatorControlTypePanelModelUniquePDSA entityToClone)
    {
      IsAccessPortalElevatorControlTypePanelModelUniquePDSA newEntity = new IsAccessPortalElevatorControlTypePanelModelUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsAccessPortalElevatorControlTypePanelModelUniquePDSAValidator.ParameterNames.AccessPortalElevatorControlTypePanelModelUid, GetResourceMessage("GCS_IsAccessPortalElevatorControlTypePanelModelUniquePDSA_AccessPortalElevatorControlTypePanelModelUid_Header", "Access Portal Elevator Control Type Panel Model Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsAccessPortalElevatorControlTypePanelModelUniquePDSA_AccessPortalElevatorControlTypePanelModelUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAccessPortalElevatorControlTypePanelModelUniquePDSAValidator.ParameterNames.AccessPortalElevatorControlTypeUid, GetResourceMessage("GCS_IsAccessPortalElevatorControlTypePanelModelUniquePDSA_AccessPortalElevatorControlTypeUid_Header", "Access Portal Elevator Control Type Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsAccessPortalElevatorControlTypePanelModelUniquePDSA_AccessPortalElevatorControlTypeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAccessPortalElevatorControlTypePanelModelUniquePDSAValidator.ParameterNames.GalaxyPanelModelUid, GetResourceMessage("GCS_IsAccessPortalElevatorControlTypePanelModelUniquePDSA_GalaxyPanelModelUid_Header", "Galaxy Panel Model Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsAccessPortalElevatorControlTypePanelModelUniquePDSA_GalaxyPanelModelUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAccessPortalElevatorControlTypePanelModelUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsAccessPortalElevatorControlTypePanelModelUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsAccessPortalElevatorControlTypePanelModelUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsAccessPortalElevatorControlTypePanelModelUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsAccessPortalElevatorControlTypePanelModelUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsAccessPortalElevatorControlTypePanelModelUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsAccessPortalElevatorControlTypePanelModelUniquePDSAValidator.ParameterNames.AccessPortalElevatorControlTypePanelModelUid).Value = Entity.AccessPortalElevatorControlTypePanelModelUid;
      this.Properties.GetByName(IsAccessPortalElevatorControlTypePanelModelUniquePDSAValidator.ParameterNames.AccessPortalElevatorControlTypeUid).Value = Entity.AccessPortalElevatorControlTypeUid;
      this.Properties.GetByName(IsAccessPortalElevatorControlTypePanelModelUniquePDSAValidator.ParameterNames.GalaxyPanelModelUid).Value = Entity.GalaxyPanelModelUid;
      this.Properties.GetByName(IsAccessPortalElevatorControlTypePanelModelUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsAccessPortalElevatorControlTypePanelModelUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsAccessPortalElevatorControlTypePanelModelUniquePDSAValidator.ParameterNames.AccessPortalElevatorControlTypePanelModelUid).IsNull == false)
        Entity.AccessPortalElevatorControlTypePanelModelUid = this.Properties.GetByName(IsAccessPortalElevatorControlTypePanelModelUniquePDSAValidator.ParameterNames.AccessPortalElevatorControlTypePanelModelUid).GetAsGuid();
      if(this.Properties.GetByName(IsAccessPortalElevatorControlTypePanelModelUniquePDSAValidator.ParameterNames.AccessPortalElevatorControlTypeUid).IsNull == false)
        Entity.AccessPortalElevatorControlTypeUid = this.Properties.GetByName(IsAccessPortalElevatorControlTypePanelModelUniquePDSAValidator.ParameterNames.AccessPortalElevatorControlTypeUid).GetAsGuid();
      if(this.Properties.GetByName(IsAccessPortalElevatorControlTypePanelModelUniquePDSAValidator.ParameterNames.GalaxyPanelModelUid).IsNull == false)
        Entity.GalaxyPanelModelUid = this.Properties.GetByName(IsAccessPortalElevatorControlTypePanelModelUniquePDSAValidator.ParameterNames.GalaxyPanelModelUid).GetAsGuid();
      if(this.Properties.GetByName(IsAccessPortalElevatorControlTypePanelModelUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsAccessPortalElevatorControlTypePanelModelUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsAccessPortalElevatorControlTypePanelModelUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsAccessPortalElevatorControlTypePanelModelUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsAccessPortalElevatorControlTypePanelModelUniquePDSA class.
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
    /// Returns '@AccessPortalElevatorControlTypePanelModelUid'
    /// </summary>
    public static string AccessPortalElevatorControlTypePanelModelUid = "@AccessPortalElevatorControlTypePanelModelUid";
    /// <summary>
    /// Returns '@AccessPortalElevatorControlTypeUid'
    /// </summary>
    public static string AccessPortalElevatorControlTypeUid = "@AccessPortalElevatorControlTypeUid";
    /// <summary>
    /// Returns '@GalaxyPanelModelUid'
    /// </summary>
    public static string GalaxyPanelModelUid = "@GalaxyPanelModelUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsAccessPortalElevatorControlTypePanelModelUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@AccessPortalElevatorControlTypePanelModelUid'
    /// </summary>
    public static string AccessPortalElevatorControlTypePanelModelUid = "@AccessPortalElevatorControlTypePanelModelUid";
    /// <summary>
    /// Returns '@AccessPortalElevatorControlTypeUid'
    /// </summary>
    public static string AccessPortalElevatorControlTypeUid = "@AccessPortalElevatorControlTypeUid";
    /// <summary>
    /// Returns '@GalaxyPanelModelUid'
    /// </summary>
    public static string GalaxyPanelModelUid = "@GalaxyPanelModelUid";
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

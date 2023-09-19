using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsGalaxyPanelModelInterfaceBoardTypeUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsGalaxyPanelModelInterfaceBoardTypeUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsGalaxyPanelModelInterfaceBoardTypeUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsGalaxyPanelModelInterfaceBoardTypeUniquePDSA Entity
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
    /// Clones the current IsGalaxyPanelModelInterfaceBoardTypeUniquePDSA
    /// </summary>
    /// <returns>A cloned IsGalaxyPanelModelInterfaceBoardTypeUniquePDSA object</returns>
    public IsGalaxyPanelModelInterfaceBoardTypeUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsGalaxyPanelModelInterfaceBoardTypeUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsGalaxyPanelModelInterfaceBoardTypeUniquePDSA entity to clone</param>
    /// <returns>A cloned IsGalaxyPanelModelInterfaceBoardTypeUniquePDSA object</returns>
    public IsGalaxyPanelModelInterfaceBoardTypeUniquePDSA CloneEntity(IsGalaxyPanelModelInterfaceBoardTypeUniquePDSA entityToClone)
    {
      IsGalaxyPanelModelInterfaceBoardTypeUniquePDSA newEntity = new IsGalaxyPanelModelInterfaceBoardTypeUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsGalaxyPanelModelInterfaceBoardTypeUniquePDSAValidator.ParameterNames.GalaxyPanelModelInterfaceBoardTypeUid, GetResourceMessage("GCS_IsGalaxyPanelModelInterfaceBoardTypeUniquePDSA_GalaxyPanelModelInterfaceBoardTypeUid_Header", "Galaxy Panel Model Interface Board Type Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsGalaxyPanelModelInterfaceBoardTypeUniquePDSA_GalaxyPanelModelInterfaceBoardTypeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyPanelModelInterfaceBoardTypeUniquePDSAValidator.ParameterNames.GalaxyPanelModelUid, GetResourceMessage("GCS_IsGalaxyPanelModelInterfaceBoardTypeUniquePDSA_GalaxyPanelModelUid_Header", "Galaxy Panel Model Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsGalaxyPanelModelInterfaceBoardTypeUniquePDSA_GalaxyPanelModelUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyPanelModelInterfaceBoardTypeUniquePDSAValidator.ParameterNames.InterfaceBoardTypeUid, GetResourceMessage("GCS_IsGalaxyPanelModelInterfaceBoardTypeUniquePDSA_InterfaceBoardTypeUid_Header", "Interface Board Type Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsGalaxyPanelModelInterfaceBoardTypeUniquePDSA_InterfaceBoardTypeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyPanelModelInterfaceBoardTypeUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsGalaxyPanelModelInterfaceBoardTypeUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsGalaxyPanelModelInterfaceBoardTypeUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyPanelModelInterfaceBoardTypeUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsGalaxyPanelModelInterfaceBoardTypeUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsGalaxyPanelModelInterfaceBoardTypeUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsGalaxyPanelModelInterfaceBoardTypeUniquePDSAValidator.ParameterNames.GalaxyPanelModelInterfaceBoardTypeUid).Value = Entity.GalaxyPanelModelInterfaceBoardTypeUid;
      this.Properties.GetByName(IsGalaxyPanelModelInterfaceBoardTypeUniquePDSAValidator.ParameterNames.GalaxyPanelModelUid).Value = Entity.GalaxyPanelModelUid;
      this.Properties.GetByName(IsGalaxyPanelModelInterfaceBoardTypeUniquePDSAValidator.ParameterNames.InterfaceBoardTypeUid).Value = Entity.InterfaceBoardTypeUid;
      this.Properties.GetByName(IsGalaxyPanelModelInterfaceBoardTypeUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsGalaxyPanelModelInterfaceBoardTypeUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsGalaxyPanelModelInterfaceBoardTypeUniquePDSAValidator.ParameterNames.GalaxyPanelModelInterfaceBoardTypeUid).IsNull == false)
        Entity.GalaxyPanelModelInterfaceBoardTypeUid = this.Properties.GetByName(IsGalaxyPanelModelInterfaceBoardTypeUniquePDSAValidator.ParameterNames.GalaxyPanelModelInterfaceBoardTypeUid).GetAsGuid();
      if(this.Properties.GetByName(IsGalaxyPanelModelInterfaceBoardTypeUniquePDSAValidator.ParameterNames.GalaxyPanelModelUid).IsNull == false)
        Entity.GalaxyPanelModelUid = this.Properties.GetByName(IsGalaxyPanelModelInterfaceBoardTypeUniquePDSAValidator.ParameterNames.GalaxyPanelModelUid).GetAsGuid();
      if(this.Properties.GetByName(IsGalaxyPanelModelInterfaceBoardTypeUniquePDSAValidator.ParameterNames.InterfaceBoardTypeUid).IsNull == false)
        Entity.InterfaceBoardTypeUid = this.Properties.GetByName(IsGalaxyPanelModelInterfaceBoardTypeUniquePDSAValidator.ParameterNames.InterfaceBoardTypeUid).GetAsGuid();
      if(this.Properties.GetByName(IsGalaxyPanelModelInterfaceBoardTypeUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsGalaxyPanelModelInterfaceBoardTypeUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsGalaxyPanelModelInterfaceBoardTypeUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsGalaxyPanelModelInterfaceBoardTypeUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsGalaxyPanelModelInterfaceBoardTypeUniquePDSA class.
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
    /// Returns '@GalaxyPanelModelInterfaceBoardTypeUid'
    /// </summary>
    public static string GalaxyPanelModelInterfaceBoardTypeUid = "@GalaxyPanelModelInterfaceBoardTypeUid";
    /// <summary>
    /// Returns '@GalaxyPanelModelUid'
    /// </summary>
    public static string GalaxyPanelModelUid = "@GalaxyPanelModelUid";
    /// <summary>
    /// Returns '@InterfaceBoardTypeUid'
    /// </summary>
    public static string InterfaceBoardTypeUid = "@InterfaceBoardTypeUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsGalaxyPanelModelInterfaceBoardTypeUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@GalaxyPanelModelInterfaceBoardTypeUid'
    /// </summary>
    public static string GalaxyPanelModelInterfaceBoardTypeUid = "@GalaxyPanelModelInterfaceBoardTypeUid";
    /// <summary>
    /// Returns '@GalaxyPanelModelUid'
    /// </summary>
    public static string GalaxyPanelModelUid = "@GalaxyPanelModelUid";
    /// <summary>
    /// Returns '@InterfaceBoardTypeUid'
    /// </summary>
    public static string InterfaceBoardTypeUid = "@InterfaceBoardTypeUid";
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

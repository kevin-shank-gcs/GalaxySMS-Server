using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsGalaxyPanelModelInterfaceBoardSectionModeUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsGalaxyPanelModelInterfaceBoardSectionModeUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsGalaxyPanelModelInterfaceBoardSectionModeUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsGalaxyPanelModelInterfaceBoardSectionModeUniquePDSA Entity
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
    /// Clones the current IsGalaxyPanelModelInterfaceBoardSectionModeUniquePDSA
    /// </summary>
    /// <returns>A cloned IsGalaxyPanelModelInterfaceBoardSectionModeUniquePDSA object</returns>
    public IsGalaxyPanelModelInterfaceBoardSectionModeUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsGalaxyPanelModelInterfaceBoardSectionModeUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsGalaxyPanelModelInterfaceBoardSectionModeUniquePDSA entity to clone</param>
    /// <returns>A cloned IsGalaxyPanelModelInterfaceBoardSectionModeUniquePDSA object</returns>
    public IsGalaxyPanelModelInterfaceBoardSectionModeUniquePDSA CloneEntity(IsGalaxyPanelModelInterfaceBoardSectionModeUniquePDSA entityToClone)
    {
      IsGalaxyPanelModelInterfaceBoardSectionModeUniquePDSA newEntity = new IsGalaxyPanelModelInterfaceBoardSectionModeUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsGalaxyPanelModelInterfaceBoardSectionModeUniquePDSAValidator.ParameterNames.GalaxyPanelModelInterfaceBoardSectionModeUid, GetResourceMessage("GCS_IsGalaxyPanelModelInterfaceBoardSectionModeUniquePDSA_GalaxyPanelModelInterfaceBoardSectionModeUid_Header", "Galaxy Panel Model Interface Board Section Mode Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsGalaxyPanelModelInterfaceBoardSectionModeUniquePDSA_GalaxyPanelModelInterfaceBoardSectionModeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyPanelModelInterfaceBoardSectionModeUniquePDSAValidator.ParameterNames.GalaxyPanelModelUid, GetResourceMessage("GCS_IsGalaxyPanelModelInterfaceBoardSectionModeUniquePDSA_GalaxyPanelModelUid_Header", "Galaxy Panel Model Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsGalaxyPanelModelInterfaceBoardSectionModeUniquePDSA_GalaxyPanelModelUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyPanelModelInterfaceBoardSectionModeUniquePDSAValidator.ParameterNames.InterfaceBoardSectionModeUid, GetResourceMessage("GCS_IsGalaxyPanelModelInterfaceBoardSectionModeUniquePDSA_InterfaceBoardSectionModeUid_Header", "Interface Board Section Mode Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsGalaxyPanelModelInterfaceBoardSectionModeUniquePDSA_InterfaceBoardSectionModeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyPanelModelInterfaceBoardSectionModeUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsGalaxyPanelModelInterfaceBoardSectionModeUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsGalaxyPanelModelInterfaceBoardSectionModeUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyPanelModelInterfaceBoardSectionModeUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsGalaxyPanelModelInterfaceBoardSectionModeUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsGalaxyPanelModelInterfaceBoardSectionModeUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsGalaxyPanelModelInterfaceBoardSectionModeUniquePDSAValidator.ParameterNames.GalaxyPanelModelInterfaceBoardSectionModeUid).Value = Entity.GalaxyPanelModelInterfaceBoardSectionModeUid;
      this.Properties.GetByName(IsGalaxyPanelModelInterfaceBoardSectionModeUniquePDSAValidator.ParameterNames.GalaxyPanelModelUid).Value = Entity.GalaxyPanelModelUid;
      this.Properties.GetByName(IsGalaxyPanelModelInterfaceBoardSectionModeUniquePDSAValidator.ParameterNames.InterfaceBoardSectionModeUid).Value = Entity.InterfaceBoardSectionModeUid;
      this.Properties.GetByName(IsGalaxyPanelModelInterfaceBoardSectionModeUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsGalaxyPanelModelInterfaceBoardSectionModeUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsGalaxyPanelModelInterfaceBoardSectionModeUniquePDSAValidator.ParameterNames.GalaxyPanelModelInterfaceBoardSectionModeUid).IsNull == false)
        Entity.GalaxyPanelModelInterfaceBoardSectionModeUid = this.Properties.GetByName(IsGalaxyPanelModelInterfaceBoardSectionModeUniquePDSAValidator.ParameterNames.GalaxyPanelModelInterfaceBoardSectionModeUid).GetAsGuid();
      if(this.Properties.GetByName(IsGalaxyPanelModelInterfaceBoardSectionModeUniquePDSAValidator.ParameterNames.GalaxyPanelModelUid).IsNull == false)
        Entity.GalaxyPanelModelUid = this.Properties.GetByName(IsGalaxyPanelModelInterfaceBoardSectionModeUniquePDSAValidator.ParameterNames.GalaxyPanelModelUid).GetAsGuid();
      if(this.Properties.GetByName(IsGalaxyPanelModelInterfaceBoardSectionModeUniquePDSAValidator.ParameterNames.InterfaceBoardSectionModeUid).IsNull == false)
        Entity.InterfaceBoardSectionModeUid = this.Properties.GetByName(IsGalaxyPanelModelInterfaceBoardSectionModeUniquePDSAValidator.ParameterNames.InterfaceBoardSectionModeUid).GetAsGuid();
      if(this.Properties.GetByName(IsGalaxyPanelModelInterfaceBoardSectionModeUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsGalaxyPanelModelInterfaceBoardSectionModeUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsGalaxyPanelModelInterfaceBoardSectionModeUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsGalaxyPanelModelInterfaceBoardSectionModeUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsGalaxyPanelModelInterfaceBoardSectionModeUniquePDSA class.
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
    /// Returns '@GalaxyPanelModelInterfaceBoardSectionModeUid'
    /// </summary>
    public static string GalaxyPanelModelInterfaceBoardSectionModeUid = "@GalaxyPanelModelInterfaceBoardSectionModeUid";
    /// <summary>
    /// Returns '@GalaxyPanelModelUid'
    /// </summary>
    public static string GalaxyPanelModelUid = "@GalaxyPanelModelUid";
    /// <summary>
    /// Returns '@InterfaceBoardSectionModeUid'
    /// </summary>
    public static string InterfaceBoardSectionModeUid = "@InterfaceBoardSectionModeUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsGalaxyPanelModelInterfaceBoardSectionModeUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@GalaxyPanelModelInterfaceBoardSectionModeUid'
    /// </summary>
    public static string GalaxyPanelModelInterfaceBoardSectionModeUid = "@GalaxyPanelModelInterfaceBoardSectionModeUid";
    /// <summary>
    /// Returns '@GalaxyPanelModelUid'
    /// </summary>
    public static string GalaxyPanelModelUid = "@GalaxyPanelModelUid";
    /// <summary>
    /// Returns '@InterfaceBoardSectionModeUid'
    /// </summary>
    public static string InterfaceBoardSectionModeUid = "@InterfaceBoardSectionModeUid";
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

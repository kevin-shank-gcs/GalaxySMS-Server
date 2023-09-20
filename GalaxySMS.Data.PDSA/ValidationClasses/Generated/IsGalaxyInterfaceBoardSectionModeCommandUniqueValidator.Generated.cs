using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsGalaxyInterfaceBoardSectionModeCommandUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsGalaxyInterfaceBoardSectionModeCommandUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsGalaxyInterfaceBoardSectionModeCommandUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsGalaxyInterfaceBoardSectionModeCommandUniquePDSA Entity
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
    /// Clones the current IsGalaxyInterfaceBoardSectionModeCommandUniquePDSA
    /// </summary>
    /// <returns>A cloned IsGalaxyInterfaceBoardSectionModeCommandUniquePDSA object</returns>
    public IsGalaxyInterfaceBoardSectionModeCommandUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsGalaxyInterfaceBoardSectionModeCommandUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsGalaxyInterfaceBoardSectionModeCommandUniquePDSA entity to clone</param>
    /// <returns>A cloned IsGalaxyInterfaceBoardSectionModeCommandUniquePDSA object</returns>
    public IsGalaxyInterfaceBoardSectionModeCommandUniquePDSA CloneEntity(IsGalaxyInterfaceBoardSectionModeCommandUniquePDSA entityToClone)
    {
      IsGalaxyInterfaceBoardSectionModeCommandUniquePDSA newEntity = new IsGalaxyInterfaceBoardSectionModeCommandUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsGalaxyInterfaceBoardSectionModeCommandUniquePDSAValidator.ParameterNames.GalaxyInterfaceBoardSectionModeCommandUid, GetResourceMessage("GCS_IsGalaxyInterfaceBoardSectionModeCommandUniquePDSA_GalaxyInterfaceBoardSectionModeCommandUid_Header", "Galaxy Interface Board Section Mode Command Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsGalaxyInterfaceBoardSectionModeCommandUniquePDSA_GalaxyInterfaceBoardSectionModeCommandUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyInterfaceBoardSectionModeCommandUniquePDSAValidator.ParameterNames.InterfaceBoardSectionModeUid, GetResourceMessage("GCS_IsGalaxyInterfaceBoardSectionModeCommandUniquePDSA_InterfaceBoardSectionModeUid_Header", "Interface Board Section Mode Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsGalaxyInterfaceBoardSectionModeCommandUniquePDSA_InterfaceBoardSectionModeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyInterfaceBoardSectionModeCommandUniquePDSAValidator.ParameterNames.GalaxyInterfaceBoardSectionCommandUid, GetResourceMessage("GCS_IsGalaxyInterfaceBoardSectionModeCommandUniquePDSA_GalaxyInterfaceBoardSectionCommandUid_Header", "Galaxy Interface Board Section Command Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsGalaxyInterfaceBoardSectionModeCommandUniquePDSA_GalaxyInterfaceBoardSectionCommandUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyInterfaceBoardSectionModeCommandUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsGalaxyInterfaceBoardSectionModeCommandUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsGalaxyInterfaceBoardSectionModeCommandUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyInterfaceBoardSectionModeCommandUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsGalaxyInterfaceBoardSectionModeCommandUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsGalaxyInterfaceBoardSectionModeCommandUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsGalaxyInterfaceBoardSectionModeCommandUniquePDSAValidator.ParameterNames.GalaxyInterfaceBoardSectionModeCommandUid).Value = Entity.GalaxyInterfaceBoardSectionModeCommandUid;
      this.Properties.GetByName(IsGalaxyInterfaceBoardSectionModeCommandUniquePDSAValidator.ParameterNames.InterfaceBoardSectionModeUid).Value = Entity.InterfaceBoardSectionModeUid;
      this.Properties.GetByName(IsGalaxyInterfaceBoardSectionModeCommandUniquePDSAValidator.ParameterNames.GalaxyInterfaceBoardSectionCommandUid).Value = Entity.GalaxyInterfaceBoardSectionCommandUid;
      this.Properties.GetByName(IsGalaxyInterfaceBoardSectionModeCommandUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsGalaxyInterfaceBoardSectionModeCommandUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsGalaxyInterfaceBoardSectionModeCommandUniquePDSAValidator.ParameterNames.GalaxyInterfaceBoardSectionModeCommandUid).IsNull == false)
        Entity.GalaxyInterfaceBoardSectionModeCommandUid = this.Properties.GetByName(IsGalaxyInterfaceBoardSectionModeCommandUniquePDSAValidator.ParameterNames.GalaxyInterfaceBoardSectionModeCommandUid).GetAsGuid();
      if(this.Properties.GetByName(IsGalaxyInterfaceBoardSectionModeCommandUniquePDSAValidator.ParameterNames.InterfaceBoardSectionModeUid).IsNull == false)
        Entity.InterfaceBoardSectionModeUid = this.Properties.GetByName(IsGalaxyInterfaceBoardSectionModeCommandUniquePDSAValidator.ParameterNames.InterfaceBoardSectionModeUid).GetAsGuid();
      if(this.Properties.GetByName(IsGalaxyInterfaceBoardSectionModeCommandUniquePDSAValidator.ParameterNames.GalaxyInterfaceBoardSectionCommandUid).IsNull == false)
        Entity.GalaxyInterfaceBoardSectionCommandUid = this.Properties.GetByName(IsGalaxyInterfaceBoardSectionModeCommandUniquePDSAValidator.ParameterNames.GalaxyInterfaceBoardSectionCommandUid).GetAsGuid();
      if(this.Properties.GetByName(IsGalaxyInterfaceBoardSectionModeCommandUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsGalaxyInterfaceBoardSectionModeCommandUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsGalaxyInterfaceBoardSectionModeCommandUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsGalaxyInterfaceBoardSectionModeCommandUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsGalaxyInterfaceBoardSectionModeCommandUniquePDSA class.
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
    /// Returns '@GalaxyInterfaceBoardSectionModeCommandUid'
    /// </summary>
    public static string GalaxyInterfaceBoardSectionModeCommandUid = "@GalaxyInterfaceBoardSectionModeCommandUid";
    /// <summary>
    /// Returns '@InterfaceBoardSectionModeUid'
    /// </summary>
    public static string InterfaceBoardSectionModeUid = "@InterfaceBoardSectionModeUid";
    /// <summary>
    /// Returns '@GalaxyInterfaceBoardSectionCommandUid'
    /// </summary>
    public static string GalaxyInterfaceBoardSectionCommandUid = "@GalaxyInterfaceBoardSectionCommandUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsGalaxyInterfaceBoardSectionModeCommandUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@GalaxyInterfaceBoardSectionModeCommandUid'
    /// </summary>
    public static string GalaxyInterfaceBoardSectionModeCommandUid = "@GalaxyInterfaceBoardSectionModeCommandUid";
    /// <summary>
    /// Returns '@InterfaceBoardSectionModeUid'
    /// </summary>
    public static string InterfaceBoardSectionModeUid = "@InterfaceBoardSectionModeUid";
    /// <summary>
    /// Returns '@GalaxyInterfaceBoardSectionCommandUid'
    /// </summary>
    public static string GalaxyInterfaceBoardSectionCommandUid = "@GalaxyInterfaceBoardSectionCommandUid";
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

using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsGalaxyHardwareModuleUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsGalaxyHardwareModuleUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsGalaxyHardwareModuleUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsGalaxyHardwareModuleUniquePDSA Entity
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
    /// Clones the current IsGalaxyHardwareModuleUniquePDSA
    /// </summary>
    /// <returns>A cloned IsGalaxyHardwareModuleUniquePDSA object</returns>
    public IsGalaxyHardwareModuleUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsGalaxyHardwareModuleUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsGalaxyHardwareModuleUniquePDSA entity to clone</param>
    /// <returns>A cloned IsGalaxyHardwareModuleUniquePDSA object</returns>
    public IsGalaxyHardwareModuleUniquePDSA CloneEntity(IsGalaxyHardwareModuleUniquePDSA entityToClone)
    {
      IsGalaxyHardwareModuleUniquePDSA newEntity = new IsGalaxyHardwareModuleUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsGalaxyHardwareModuleUniquePDSAValidator.ParameterNames.GalaxyHardwareModuleUid, GetResourceMessage("GCS_IsGalaxyHardwareModuleUniquePDSA_GalaxyHardwareModuleUid_Header", "Galaxy Hardware Module Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsGalaxyHardwareModuleUniquePDSA_GalaxyHardwareModuleUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyHardwareModuleUniquePDSAValidator.ParameterNames.GalaxyInterfaceBoardSectionUid, GetResourceMessage("GCS_IsGalaxyHardwareModuleUniquePDSA_GalaxyInterfaceBoardSectionUid_Header", "Galaxy Interface Board Section Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsGalaxyHardwareModuleUniquePDSA_GalaxyInterfaceBoardSectionUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyHardwareModuleUniquePDSAValidator.ParameterNames.ModuleNumber, GetResourceMessage("GCS_IsGalaxyHardwareModuleUniquePDSA_ModuleNumber_Header", "Module Number"), false, typeof(short), 0, GetResourceMessage("GCS_IsGalaxyHardwareModuleUniquePDSA_ModuleNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyHardwareModuleUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsGalaxyHardwareModuleUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsGalaxyHardwareModuleUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyHardwareModuleUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsGalaxyHardwareModuleUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsGalaxyHardwareModuleUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsGalaxyHardwareModuleUniquePDSAValidator.ParameterNames.GalaxyHardwareModuleUid).Value = Entity.GalaxyHardwareModuleUid;
      this.Properties.GetByName(IsGalaxyHardwareModuleUniquePDSAValidator.ParameterNames.GalaxyInterfaceBoardSectionUid).Value = Entity.GalaxyInterfaceBoardSectionUid;
      this.Properties.GetByName(IsGalaxyHardwareModuleUniquePDSAValidator.ParameterNames.ModuleNumber).Value = Entity.ModuleNumber;
      this.Properties.GetByName(IsGalaxyHardwareModuleUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsGalaxyHardwareModuleUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsGalaxyHardwareModuleUniquePDSAValidator.ParameterNames.GalaxyHardwareModuleUid).IsNull == false)
        Entity.GalaxyHardwareModuleUid = this.Properties.GetByName(IsGalaxyHardwareModuleUniquePDSAValidator.ParameterNames.GalaxyHardwareModuleUid).GetAsGuid();
      if(this.Properties.GetByName(IsGalaxyHardwareModuleUniquePDSAValidator.ParameterNames.GalaxyInterfaceBoardSectionUid).IsNull == false)
        Entity.GalaxyInterfaceBoardSectionUid = this.Properties.GetByName(IsGalaxyHardwareModuleUniquePDSAValidator.ParameterNames.GalaxyInterfaceBoardSectionUid).GetAsGuid();
      if(this.Properties.GetByName(IsGalaxyHardwareModuleUniquePDSAValidator.ParameterNames.ModuleNumber).IsNull == false)
        Entity.ModuleNumber = this.Properties.GetByName(IsGalaxyHardwareModuleUniquePDSAValidator.ParameterNames.ModuleNumber).GetAsShort();
      if(this.Properties.GetByName(IsGalaxyHardwareModuleUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsGalaxyHardwareModuleUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsGalaxyHardwareModuleUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsGalaxyHardwareModuleUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsGalaxyHardwareModuleUniquePDSA class.
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
    /// Returns '@GalaxyHardwareModuleUid'
    /// </summary>
    public static string GalaxyHardwareModuleUid = "@GalaxyHardwareModuleUid";
    /// <summary>
    /// Returns '@GalaxyInterfaceBoardSectionUid'
    /// </summary>
    public static string GalaxyInterfaceBoardSectionUid = "@GalaxyInterfaceBoardSectionUid";
    /// <summary>
    /// Returns '@ModuleNumber'
    /// </summary>
    public static string ModuleNumber = "@ModuleNumber";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsGalaxyHardwareModuleUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@GalaxyHardwareModuleUid'
    /// </summary>
    public static string GalaxyHardwareModuleUid = "@GalaxyHardwareModuleUid";
    /// <summary>
    /// Returns '@GalaxyInterfaceBoardSectionUid'
    /// </summary>
    public static string GalaxyInterfaceBoardSectionUid = "@GalaxyInterfaceBoardSectionUid";
    /// <summary>
    /// Returns '@ModuleNumber'
    /// </summary>
    public static string ModuleNumber = "@ModuleNumber";
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

using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsGalaxyInterfaceBoardSectionNodeUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsGalaxyInterfaceBoardSectionNodeUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsGalaxyInterfaceBoardSectionNodeUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsGalaxyInterfaceBoardSectionNodeUniquePDSA Entity
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
    /// Clones the current IsGalaxyInterfaceBoardSectionNodeUniquePDSA
    /// </summary>
    /// <returns>A cloned IsGalaxyInterfaceBoardSectionNodeUniquePDSA object</returns>
    public IsGalaxyInterfaceBoardSectionNodeUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsGalaxyInterfaceBoardSectionNodeUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsGalaxyInterfaceBoardSectionNodeUniquePDSA entity to clone</param>
    /// <returns>A cloned IsGalaxyInterfaceBoardSectionNodeUniquePDSA object</returns>
    public IsGalaxyInterfaceBoardSectionNodeUniquePDSA CloneEntity(IsGalaxyInterfaceBoardSectionNodeUniquePDSA entityToClone)
    {
      IsGalaxyInterfaceBoardSectionNodeUniquePDSA newEntity = new IsGalaxyInterfaceBoardSectionNodeUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsGalaxyInterfaceBoardSectionNodeUniquePDSAValidator.ParameterNames.GalaxyInterfaceBoardSectionNodeUid, GetResourceMessage("GCS_IsGalaxyInterfaceBoardSectionNodeUniquePDSA_GalaxyInterfaceBoardSectionNodeUid_Header", "Galaxy Interface Board Section Node Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsGalaxyInterfaceBoardSectionNodeUniquePDSA_GalaxyInterfaceBoardSectionNodeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyInterfaceBoardSectionNodeUniquePDSAValidator.ParameterNames.GalaxyHardwareModuleUid, GetResourceMessage("GCS_IsGalaxyInterfaceBoardSectionNodeUniquePDSA_GalaxyHardwareModuleUid_Header", "Galaxy Hardware Module Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsGalaxyInterfaceBoardSectionNodeUniquePDSA_GalaxyHardwareModuleUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyInterfaceBoardSectionNodeUniquePDSAValidator.ParameterNames.NodeNumber, GetResourceMessage("GCS_IsGalaxyInterfaceBoardSectionNodeUniquePDSA_NodeNumber_Header", "Node Number"), false, typeof(short), 0, GetResourceMessage("GCS_IsGalaxyInterfaceBoardSectionNodeUniquePDSA_NodeNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyInterfaceBoardSectionNodeUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsGalaxyInterfaceBoardSectionNodeUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsGalaxyInterfaceBoardSectionNodeUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyInterfaceBoardSectionNodeUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsGalaxyInterfaceBoardSectionNodeUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsGalaxyInterfaceBoardSectionNodeUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsGalaxyInterfaceBoardSectionNodeUniquePDSAValidator.ParameterNames.GalaxyInterfaceBoardSectionNodeUid).Value = Entity.GalaxyInterfaceBoardSectionNodeUid;
      this.Properties.GetByName(IsGalaxyInterfaceBoardSectionNodeUniquePDSAValidator.ParameterNames.GalaxyHardwareModuleUid).Value = Entity.GalaxyHardwareModuleUid;
      this.Properties.GetByName(IsGalaxyInterfaceBoardSectionNodeUniquePDSAValidator.ParameterNames.NodeNumber).Value = Entity.NodeNumber;
      this.Properties.GetByName(IsGalaxyInterfaceBoardSectionNodeUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsGalaxyInterfaceBoardSectionNodeUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsGalaxyInterfaceBoardSectionNodeUniquePDSAValidator.ParameterNames.GalaxyInterfaceBoardSectionNodeUid).IsNull == false)
        Entity.GalaxyInterfaceBoardSectionNodeUid = this.Properties.GetByName(IsGalaxyInterfaceBoardSectionNodeUniquePDSAValidator.ParameterNames.GalaxyInterfaceBoardSectionNodeUid).GetAsGuid();
      if(this.Properties.GetByName(IsGalaxyInterfaceBoardSectionNodeUniquePDSAValidator.ParameterNames.GalaxyHardwareModuleUid).IsNull == false)
        Entity.GalaxyHardwareModuleUid = this.Properties.GetByName(IsGalaxyInterfaceBoardSectionNodeUniquePDSAValidator.ParameterNames.GalaxyHardwareModuleUid).GetAsGuid();
      if(this.Properties.GetByName(IsGalaxyInterfaceBoardSectionNodeUniquePDSAValidator.ParameterNames.NodeNumber).IsNull == false)
        Entity.NodeNumber = this.Properties.GetByName(IsGalaxyInterfaceBoardSectionNodeUniquePDSAValidator.ParameterNames.NodeNumber).GetAsShort();
      if(this.Properties.GetByName(IsGalaxyInterfaceBoardSectionNodeUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsGalaxyInterfaceBoardSectionNodeUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsGalaxyInterfaceBoardSectionNodeUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsGalaxyInterfaceBoardSectionNodeUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsGalaxyInterfaceBoardSectionNodeUniquePDSA class.
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
    /// Returns '@GalaxyInterfaceBoardSectionNodeUid'
    /// </summary>
    public static string GalaxyInterfaceBoardSectionNodeUid = "@GalaxyInterfaceBoardSectionNodeUid";
    /// <summary>
    /// Returns '@GalaxyHardwareModuleUid'
    /// </summary>
    public static string GalaxyHardwareModuleUid = "@GalaxyHardwareModuleUid";
    /// <summary>
    /// Returns '@NodeNumber'
    /// </summary>
    public static string NodeNumber = "@NodeNumber";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsGalaxyInterfaceBoardSectionNodeUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@GalaxyInterfaceBoardSectionNodeUid'
    /// </summary>
    public static string GalaxyInterfaceBoardSectionNodeUid = "@GalaxyInterfaceBoardSectionNodeUid";
    /// <summary>
    /// Returns '@GalaxyHardwareModuleUid'
    /// </summary>
    public static string GalaxyHardwareModuleUid = "@GalaxyHardwareModuleUid";
    /// <summary>
    /// Returns '@NodeNumber'
    /// </summary>
    public static string NodeNumber = "@NodeNumber";
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

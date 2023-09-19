using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsLiquidCrystalDisplayGalaxyHardwareAddressUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsLiquidCrystalDisplayGalaxyHardwareAddressUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsLiquidCrystalDisplayGalaxyHardwareAddressUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsLiquidCrystalDisplayGalaxyHardwareAddressUniquePDSA Entity
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
    /// Clones the current IsLiquidCrystalDisplayGalaxyHardwareAddressUniquePDSA
    /// </summary>
    /// <returns>A cloned IsLiquidCrystalDisplayGalaxyHardwareAddressUniquePDSA object</returns>
    public IsLiquidCrystalDisplayGalaxyHardwareAddressUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsLiquidCrystalDisplayGalaxyHardwareAddressUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsLiquidCrystalDisplayGalaxyHardwareAddressUniquePDSA entity to clone</param>
    /// <returns>A cloned IsLiquidCrystalDisplayGalaxyHardwareAddressUniquePDSA object</returns>
    public IsLiquidCrystalDisplayGalaxyHardwareAddressUniquePDSA CloneEntity(IsLiquidCrystalDisplayGalaxyHardwareAddressUniquePDSA entityToClone)
    {
      IsLiquidCrystalDisplayGalaxyHardwareAddressUniquePDSA newEntity = new IsLiquidCrystalDisplayGalaxyHardwareAddressUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsLiquidCrystalDisplayGalaxyHardwareAddressUniquePDSAValidator.ParameterNames.LiquidCrystalDisplayGalaxyHardwareAddressUid, GetResourceMessage("GCS_IsLiquidCrystalDisplayGalaxyHardwareAddressUniquePDSA_LiquidCrystalDisplayGalaxyHardwareAddressUid_Header", "Liquid Crystal Display Galaxy Hardware Address Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsLiquidCrystalDisplayGalaxyHardwareAddressUniquePDSA_LiquidCrystalDisplayGalaxyHardwareAddressUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsLiquidCrystalDisplayGalaxyHardwareAddressUniquePDSAValidator.ParameterNames.LiquidCrystalDisplayUid, GetResourceMessage("GCS_IsLiquidCrystalDisplayGalaxyHardwareAddressUniquePDSA_LiquidCrystalDisplayUid_Header", "Liquid Crystal Display Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsLiquidCrystalDisplayGalaxyHardwareAddressUniquePDSA_LiquidCrystalDisplayUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsLiquidCrystalDisplayGalaxyHardwareAddressUniquePDSAValidator.ParameterNames.GalaxyInterfaceBoardSectionNodeUid, GetResourceMessage("GCS_IsLiquidCrystalDisplayGalaxyHardwareAddressUniquePDSA_GalaxyInterfaceBoardSectionNodeUid_Header", "Galaxy Interface Board Section Node Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsLiquidCrystalDisplayGalaxyHardwareAddressUniquePDSA_GalaxyInterfaceBoardSectionNodeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsLiquidCrystalDisplayGalaxyHardwareAddressUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsLiquidCrystalDisplayGalaxyHardwareAddressUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsLiquidCrystalDisplayGalaxyHardwareAddressUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsLiquidCrystalDisplayGalaxyHardwareAddressUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsLiquidCrystalDisplayGalaxyHardwareAddressUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsLiquidCrystalDisplayGalaxyHardwareAddressUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsLiquidCrystalDisplayGalaxyHardwareAddressUniquePDSAValidator.ParameterNames.LiquidCrystalDisplayGalaxyHardwareAddressUid).Value = Entity.LiquidCrystalDisplayGalaxyHardwareAddressUid;
      this.Properties.GetByName(IsLiquidCrystalDisplayGalaxyHardwareAddressUniquePDSAValidator.ParameterNames.LiquidCrystalDisplayUid).Value = Entity.LiquidCrystalDisplayUid;
      this.Properties.GetByName(IsLiquidCrystalDisplayGalaxyHardwareAddressUniquePDSAValidator.ParameterNames.GalaxyInterfaceBoardSectionNodeUid).Value = Entity.GalaxyInterfaceBoardSectionNodeUid;
      this.Properties.GetByName(IsLiquidCrystalDisplayGalaxyHardwareAddressUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsLiquidCrystalDisplayGalaxyHardwareAddressUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsLiquidCrystalDisplayGalaxyHardwareAddressUniquePDSAValidator.ParameterNames.LiquidCrystalDisplayGalaxyHardwareAddressUid).IsNull == false)
        Entity.LiquidCrystalDisplayGalaxyHardwareAddressUid = this.Properties.GetByName(IsLiquidCrystalDisplayGalaxyHardwareAddressUniquePDSAValidator.ParameterNames.LiquidCrystalDisplayGalaxyHardwareAddressUid).GetAsGuid();
      if(this.Properties.GetByName(IsLiquidCrystalDisplayGalaxyHardwareAddressUniquePDSAValidator.ParameterNames.LiquidCrystalDisplayUid).IsNull == false)
        Entity.LiquidCrystalDisplayUid = this.Properties.GetByName(IsLiquidCrystalDisplayGalaxyHardwareAddressUniquePDSAValidator.ParameterNames.LiquidCrystalDisplayUid).GetAsGuid();
      if(this.Properties.GetByName(IsLiquidCrystalDisplayGalaxyHardwareAddressUniquePDSAValidator.ParameterNames.GalaxyInterfaceBoardSectionNodeUid).IsNull == false)
        Entity.GalaxyInterfaceBoardSectionNodeUid = this.Properties.GetByName(IsLiquidCrystalDisplayGalaxyHardwareAddressUniquePDSAValidator.ParameterNames.GalaxyInterfaceBoardSectionNodeUid).GetAsGuid();
      if(this.Properties.GetByName(IsLiquidCrystalDisplayGalaxyHardwareAddressUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsLiquidCrystalDisplayGalaxyHardwareAddressUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsLiquidCrystalDisplayGalaxyHardwareAddressUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsLiquidCrystalDisplayGalaxyHardwareAddressUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsLiquidCrystalDisplayGalaxyHardwareAddressUniquePDSA class.
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
    /// Returns '@LiquidCrystalDisplayGalaxyHardwareAddressUid'
    /// </summary>
    public static string LiquidCrystalDisplayGalaxyHardwareAddressUid = "@LiquidCrystalDisplayGalaxyHardwareAddressUid";
    /// <summary>
    /// Returns '@LiquidCrystalDisplayUid'
    /// </summary>
    public static string LiquidCrystalDisplayUid = "@LiquidCrystalDisplayUid";
    /// <summary>
    /// Returns '@GalaxyInterfaceBoardSectionNodeUid'
    /// </summary>
    public static string GalaxyInterfaceBoardSectionNodeUid = "@GalaxyInterfaceBoardSectionNodeUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsLiquidCrystalDisplayGalaxyHardwareAddressUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@LiquidCrystalDisplayGalaxyHardwareAddressUid'
    /// </summary>
    public static string LiquidCrystalDisplayGalaxyHardwareAddressUid = "@LiquidCrystalDisplayGalaxyHardwareAddressUid";
    /// <summary>
    /// Returns '@LiquidCrystalDisplayUid'
    /// </summary>
    public static string LiquidCrystalDisplayUid = "@LiquidCrystalDisplayUid";
    /// <summary>
    /// Returns '@GalaxyInterfaceBoardSectionNodeUid'
    /// </summary>
    public static string GalaxyInterfaceBoardSectionNodeUid = "@GalaxyInterfaceBoardSectionNodeUid";
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

using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsOutputDeviceGalaxyHardwareAddressUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsOutputDeviceGalaxyHardwareAddressUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsOutputDeviceGalaxyHardwareAddressUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsOutputDeviceGalaxyHardwareAddressUniquePDSA Entity
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
    /// Clones the current IsOutputDeviceGalaxyHardwareAddressUniquePDSA
    /// </summary>
    /// <returns>A cloned IsOutputDeviceGalaxyHardwareAddressUniquePDSA object</returns>
    public IsOutputDeviceGalaxyHardwareAddressUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsOutputDeviceGalaxyHardwareAddressUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsOutputDeviceGalaxyHardwareAddressUniquePDSA entity to clone</param>
    /// <returns>A cloned IsOutputDeviceGalaxyHardwareAddressUniquePDSA object</returns>
    public IsOutputDeviceGalaxyHardwareAddressUniquePDSA CloneEntity(IsOutputDeviceGalaxyHardwareAddressUniquePDSA entityToClone)
    {
      IsOutputDeviceGalaxyHardwareAddressUniquePDSA newEntity = new IsOutputDeviceGalaxyHardwareAddressUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsOutputDeviceGalaxyHardwareAddressUniquePDSAValidator.ParameterNames.OutputDeviceGalaxyHardwareAddressUid, GetResourceMessage("GCS_IsOutputDeviceGalaxyHardwareAddressUniquePDSA_OutputDeviceGalaxyHardwareAddressUid_Header", "Output Device Galaxy Hardware Address Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsOutputDeviceGalaxyHardwareAddressUniquePDSA_OutputDeviceGalaxyHardwareAddressUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsOutputDeviceGalaxyHardwareAddressUniquePDSAValidator.ParameterNames.OutputDeviceUid, GetResourceMessage("GCS_IsOutputDeviceGalaxyHardwareAddressUniquePDSA_OutputDeviceUid_Header", "Output Device Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsOutputDeviceGalaxyHardwareAddressUniquePDSA_OutputDeviceUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsOutputDeviceGalaxyHardwareAddressUniquePDSAValidator.ParameterNames.GalaxyInterfaceBoardSectionNodeUid, GetResourceMessage("GCS_IsOutputDeviceGalaxyHardwareAddressUniquePDSA_GalaxyInterfaceBoardSectionNodeUid_Header", "Galaxy Interface Board Section Node Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsOutputDeviceGalaxyHardwareAddressUniquePDSA_GalaxyInterfaceBoardSectionNodeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsOutputDeviceGalaxyHardwareAddressUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsOutputDeviceGalaxyHardwareAddressUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsOutputDeviceGalaxyHardwareAddressUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsOutputDeviceGalaxyHardwareAddressUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsOutputDeviceGalaxyHardwareAddressUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsOutputDeviceGalaxyHardwareAddressUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsOutputDeviceGalaxyHardwareAddressUniquePDSAValidator.ParameterNames.OutputDeviceGalaxyHardwareAddressUid).Value = Entity.OutputDeviceGalaxyHardwareAddressUid;
      this.Properties.GetByName(IsOutputDeviceGalaxyHardwareAddressUniquePDSAValidator.ParameterNames.OutputDeviceUid).Value = Entity.OutputDeviceUid;
      this.Properties.GetByName(IsOutputDeviceGalaxyHardwareAddressUniquePDSAValidator.ParameterNames.GalaxyInterfaceBoardSectionNodeUid).Value = Entity.GalaxyInterfaceBoardSectionNodeUid;
      this.Properties.GetByName(IsOutputDeviceGalaxyHardwareAddressUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsOutputDeviceGalaxyHardwareAddressUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsOutputDeviceGalaxyHardwareAddressUniquePDSAValidator.ParameterNames.OutputDeviceGalaxyHardwareAddressUid).IsNull == false)
        Entity.OutputDeviceGalaxyHardwareAddressUid = this.Properties.GetByName(IsOutputDeviceGalaxyHardwareAddressUniquePDSAValidator.ParameterNames.OutputDeviceGalaxyHardwareAddressUid).GetAsGuid();
      if(this.Properties.GetByName(IsOutputDeviceGalaxyHardwareAddressUniquePDSAValidator.ParameterNames.OutputDeviceUid).IsNull == false)
        Entity.OutputDeviceUid = this.Properties.GetByName(IsOutputDeviceGalaxyHardwareAddressUniquePDSAValidator.ParameterNames.OutputDeviceUid).GetAsGuid();
      if(this.Properties.GetByName(IsOutputDeviceGalaxyHardwareAddressUniquePDSAValidator.ParameterNames.GalaxyInterfaceBoardSectionNodeUid).IsNull == false)
        Entity.GalaxyInterfaceBoardSectionNodeUid = this.Properties.GetByName(IsOutputDeviceGalaxyHardwareAddressUniquePDSAValidator.ParameterNames.GalaxyInterfaceBoardSectionNodeUid).GetAsGuid();
      if(this.Properties.GetByName(IsOutputDeviceGalaxyHardwareAddressUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsOutputDeviceGalaxyHardwareAddressUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsOutputDeviceGalaxyHardwareAddressUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsOutputDeviceGalaxyHardwareAddressUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsOutputDeviceGalaxyHardwareAddressUniquePDSA class.
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
    /// Returns '@OutputDeviceGalaxyHardwareAddressUid'
    /// </summary>
    public static string OutputDeviceGalaxyHardwareAddressUid = "@OutputDeviceGalaxyHardwareAddressUid";
    /// <summary>
    /// Returns '@OutputDeviceUid'
    /// </summary>
    public static string OutputDeviceUid = "@OutputDeviceUid";
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
    /// Contains static string properties that represent the name of each property in the IsOutputDeviceGalaxyHardwareAddressUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@OutputDeviceGalaxyHardwareAddressUid'
    /// </summary>
    public static string OutputDeviceGalaxyHardwareAddressUid = "@OutputDeviceGalaxyHardwareAddressUid";
    /// <summary>
    /// Returns '@OutputDeviceUid'
    /// </summary>
    public static string OutputDeviceUid = "@OutputDeviceUid";
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

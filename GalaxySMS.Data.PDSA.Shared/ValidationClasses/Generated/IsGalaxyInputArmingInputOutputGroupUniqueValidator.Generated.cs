using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsGalaxyInputArmingInputOutputGroupUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsGalaxyInputArmingInputOutputGroupUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsGalaxyInputArmingInputOutputGroupUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsGalaxyInputArmingInputOutputGroupUniquePDSA Entity
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
    /// Clones the current IsGalaxyInputArmingInputOutputGroupUniquePDSA
    /// </summary>
    /// <returns>A cloned IsGalaxyInputArmingInputOutputGroupUniquePDSA object</returns>
    public IsGalaxyInputArmingInputOutputGroupUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsGalaxyInputArmingInputOutputGroupUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsGalaxyInputArmingInputOutputGroupUniquePDSA entity to clone</param>
    /// <returns>A cloned IsGalaxyInputArmingInputOutputGroupUniquePDSA object</returns>
    public IsGalaxyInputArmingInputOutputGroupUniquePDSA CloneEntity(IsGalaxyInputArmingInputOutputGroupUniquePDSA entityToClone)
    {
      IsGalaxyInputArmingInputOutputGroupUniquePDSA newEntity = new IsGalaxyInputArmingInputOutputGroupUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsGalaxyInputArmingInputOutputGroupUniquePDSAValidator.ParameterNames.GalaxyInputArmingInputOutputGroupUid, GetResourceMessage("GCS_IsGalaxyInputArmingInputOutputGroupUniquePDSA_GalaxyInputArmingInputOutputGroupUid_Header", "Galaxy Input Arming Input Output Group Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsGalaxyInputArmingInputOutputGroupUniquePDSA_GalaxyInputArmingInputOutputGroupUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyInputArmingInputOutputGroupUniquePDSAValidator.ParameterNames.InputDeviceUid, GetResourceMessage("GCS_IsGalaxyInputArmingInputOutputGroupUniquePDSA_InputDeviceUid_Header", "Input Device Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsGalaxyInputArmingInputOutputGroupUniquePDSA_InputDeviceUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyInputArmingInputOutputGroupUniquePDSAValidator.ParameterNames.OrderNumber, GetResourceMessage("GCS_IsGalaxyInputArmingInputOutputGroupUniquePDSA_OrderNumber_Header", "Order Number"), false, typeof(short), 0, GetResourceMessage("GCS_IsGalaxyInputArmingInputOutputGroupUniquePDSA_OrderNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyInputArmingInputOutputGroupUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsGalaxyInputArmingInputOutputGroupUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsGalaxyInputArmingInputOutputGroupUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyInputArmingInputOutputGroupUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsGalaxyInputArmingInputOutputGroupUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsGalaxyInputArmingInputOutputGroupUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsGalaxyInputArmingInputOutputGroupUniquePDSAValidator.ParameterNames.GalaxyInputArmingInputOutputGroupUid).Value = Entity.GalaxyInputArmingInputOutputGroupUid;
      this.Properties.GetByName(IsGalaxyInputArmingInputOutputGroupUniquePDSAValidator.ParameterNames.InputDeviceUid).Value = Entity.InputDeviceUid;
      this.Properties.GetByName(IsGalaxyInputArmingInputOutputGroupUniquePDSAValidator.ParameterNames.OrderNumber).Value = Entity.OrderNumber;
      this.Properties.GetByName(IsGalaxyInputArmingInputOutputGroupUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsGalaxyInputArmingInputOutputGroupUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsGalaxyInputArmingInputOutputGroupUniquePDSAValidator.ParameterNames.GalaxyInputArmingInputOutputGroupUid).IsNull == false)
        Entity.GalaxyInputArmingInputOutputGroupUid = this.Properties.GetByName(IsGalaxyInputArmingInputOutputGroupUniquePDSAValidator.ParameterNames.GalaxyInputArmingInputOutputGroupUid).GetAsGuid();
      if(this.Properties.GetByName(IsGalaxyInputArmingInputOutputGroupUniquePDSAValidator.ParameterNames.InputDeviceUid).IsNull == false)
        Entity.InputDeviceUid = this.Properties.GetByName(IsGalaxyInputArmingInputOutputGroupUniquePDSAValidator.ParameterNames.InputDeviceUid).GetAsGuid();
      if(this.Properties.GetByName(IsGalaxyInputArmingInputOutputGroupUniquePDSAValidator.ParameterNames.OrderNumber).IsNull == false)
        Entity.OrderNumber = this.Properties.GetByName(IsGalaxyInputArmingInputOutputGroupUniquePDSAValidator.ParameterNames.OrderNumber).GetAsShort();
      if(this.Properties.GetByName(IsGalaxyInputArmingInputOutputGroupUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsGalaxyInputArmingInputOutputGroupUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsGalaxyInputArmingInputOutputGroupUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsGalaxyInputArmingInputOutputGroupUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsGalaxyInputArmingInputOutputGroupUniquePDSA class.
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
    /// Returns '@GalaxyInputArmingInputOutputGroupUid'
    /// </summary>
    public static string GalaxyInputArmingInputOutputGroupUid = "@GalaxyInputArmingInputOutputGroupUid";
    /// <summary>
    /// Returns '@InputDeviceUid'
    /// </summary>
    public static string InputDeviceUid = "@InputDeviceUid";
    /// <summary>
    /// Returns '@OrderNumber'
    /// </summary>
    public static string OrderNumber = "@OrderNumber";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsGalaxyInputArmingInputOutputGroupUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@GalaxyInputArmingInputOutputGroupUid'
    /// </summary>
    public static string GalaxyInputArmingInputOutputGroupUid = "@GalaxyInputArmingInputOutputGroupUid";
    /// <summary>
    /// Returns '@InputDeviceUid'
    /// </summary>
    public static string InputDeviceUid = "@InputDeviceUid";
    /// <summary>
    /// Returns '@OrderNumber'
    /// </summary>
    public static string OrderNumber = "@OrderNumber";
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

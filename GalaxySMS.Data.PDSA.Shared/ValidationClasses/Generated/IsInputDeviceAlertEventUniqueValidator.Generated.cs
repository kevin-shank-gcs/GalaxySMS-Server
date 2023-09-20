using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsInputDeviceAlertEventUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsInputDeviceAlertEventUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsInputDeviceAlertEventUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsInputDeviceAlertEventUniquePDSA Entity
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
    /// Clones the current IsInputDeviceAlertEventUniquePDSA
    /// </summary>
    /// <returns>A cloned IsInputDeviceAlertEventUniquePDSA object</returns>
    public IsInputDeviceAlertEventUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsInputDeviceAlertEventUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsInputDeviceAlertEventUniquePDSA entity to clone</param>
    /// <returns>A cloned IsInputDeviceAlertEventUniquePDSA object</returns>
    public IsInputDeviceAlertEventUniquePDSA CloneEntity(IsInputDeviceAlertEventUniquePDSA entityToClone)
    {
      IsInputDeviceAlertEventUniquePDSA newEntity = new IsInputDeviceAlertEventUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsInputDeviceAlertEventUniquePDSAValidator.ParameterNames.InputDeviceAlertEventUid, GetResourceMessage("GCS_IsInputDeviceAlertEventUniquePDSA_InputDeviceAlertEventUid_Header", "Input Device Alert Event Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsInputDeviceAlertEventUniquePDSA_InputDeviceAlertEventUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsInputDeviceAlertEventUniquePDSAValidator.ParameterNames.InputDeviceUid, GetResourceMessage("GCS_IsInputDeviceAlertEventUniquePDSA_InputDeviceUid_Header", "Input Device Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsInputDeviceAlertEventUniquePDSA_InputDeviceUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsInputDeviceAlertEventUniquePDSAValidator.ParameterNames.InputDeviceAlertEventTypeUid, GetResourceMessage("GCS_IsInputDeviceAlertEventUniquePDSA_InputDeviceAlertEventTypeUid_Header", "Input Device Alert Event Type Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsInputDeviceAlertEventUniquePDSA_InputDeviceAlertEventTypeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsInputDeviceAlertEventUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsInputDeviceAlertEventUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsInputDeviceAlertEventUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsInputDeviceAlertEventUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsInputDeviceAlertEventUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsInputDeviceAlertEventUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsInputDeviceAlertEventUniquePDSAValidator.ParameterNames.InputDeviceAlertEventUid).Value = Entity.InputDeviceAlertEventUid;
      this.Properties.GetByName(IsInputDeviceAlertEventUniquePDSAValidator.ParameterNames.InputDeviceUid).Value = Entity.InputDeviceUid;
      this.Properties.GetByName(IsInputDeviceAlertEventUniquePDSAValidator.ParameterNames.InputDeviceAlertEventTypeUid).Value = Entity.InputDeviceAlertEventTypeUid;
      this.Properties.GetByName(IsInputDeviceAlertEventUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsInputDeviceAlertEventUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsInputDeviceAlertEventUniquePDSAValidator.ParameterNames.InputDeviceAlertEventUid).IsNull == false)
        Entity.InputDeviceAlertEventUid = this.Properties.GetByName(IsInputDeviceAlertEventUniquePDSAValidator.ParameterNames.InputDeviceAlertEventUid).GetAsGuid();
      if(this.Properties.GetByName(IsInputDeviceAlertEventUniquePDSAValidator.ParameterNames.InputDeviceUid).IsNull == false)
        Entity.InputDeviceUid = this.Properties.GetByName(IsInputDeviceAlertEventUniquePDSAValidator.ParameterNames.InputDeviceUid).GetAsGuid();
      if(this.Properties.GetByName(IsInputDeviceAlertEventUniquePDSAValidator.ParameterNames.InputDeviceAlertEventTypeUid).IsNull == false)
        Entity.InputDeviceAlertEventTypeUid = this.Properties.GetByName(IsInputDeviceAlertEventUniquePDSAValidator.ParameterNames.InputDeviceAlertEventTypeUid).GetAsGuid();
      if(this.Properties.GetByName(IsInputDeviceAlertEventUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsInputDeviceAlertEventUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsInputDeviceAlertEventUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsInputDeviceAlertEventUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsInputDeviceAlertEventUniquePDSA class.
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
    /// Returns '@InputDeviceAlertEventUid'
    /// </summary>
    public static string InputDeviceAlertEventUid = "@InputDeviceAlertEventUid";
    /// <summary>
    /// Returns '@InputDeviceUid'
    /// </summary>
    public static string InputDeviceUid = "@InputDeviceUid";
    /// <summary>
    /// Returns '@InputDeviceAlertEventTypeUid'
    /// </summary>
    public static string InputDeviceAlertEventTypeUid = "@InputDeviceAlertEventTypeUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsInputDeviceAlertEventUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@InputDeviceAlertEventUid'
    /// </summary>
    public static string InputDeviceAlertEventUid = "@InputDeviceAlertEventUid";
    /// <summary>
    /// Returns '@InputDeviceUid'
    /// </summary>
    public static string InputDeviceUid = "@InputDeviceUid";
    /// <summary>
    /// Returns '@InputDeviceAlertEventTypeUid'
    /// </summary>
    public static string InputDeviceAlertEventTypeUid = "@InputDeviceAlertEventTypeUid";
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

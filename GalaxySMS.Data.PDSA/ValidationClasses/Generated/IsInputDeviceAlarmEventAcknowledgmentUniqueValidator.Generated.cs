using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsInputDeviceAlarmEventAcknowledgmentUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsInputDeviceAlarmEventAcknowledgmentUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsInputDeviceAlarmEventAcknowledgmentUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsInputDeviceAlarmEventAcknowledgmentUniquePDSA Entity
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
    /// Clones the current IsInputDeviceAlarmEventAcknowledgmentUniquePDSA
    /// </summary>
    /// <returns>A cloned IsInputDeviceAlarmEventAcknowledgmentUniquePDSA object</returns>
    public IsInputDeviceAlarmEventAcknowledgmentUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsInputDeviceAlarmEventAcknowledgmentUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsInputDeviceAlarmEventAcknowledgmentUniquePDSA entity to clone</param>
    /// <returns>A cloned IsInputDeviceAlarmEventAcknowledgmentUniquePDSA object</returns>
    public IsInputDeviceAlarmEventAcknowledgmentUniquePDSA CloneEntity(IsInputDeviceAlarmEventAcknowledgmentUniquePDSA entityToClone)
    {
      IsInputDeviceAlarmEventAcknowledgmentUniquePDSA newEntity = new IsInputDeviceAlarmEventAcknowledgmentUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsInputDeviceAlarmEventAcknowledgmentUniquePDSAValidator.ParameterNames.InputDeviceAlarmEventAcknowledgmentUid, GetResourceMessage("GCS_IsInputDeviceAlarmEventAcknowledgmentUniquePDSA_InputDeviceAlarmEventAcknowledgmentUid_Header", "Input Device Alarm Event Acknowledgment Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsInputDeviceAlarmEventAcknowledgmentUniquePDSA_InputDeviceAlarmEventAcknowledgmentUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsInputDeviceAlarmEventAcknowledgmentUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsInputDeviceAlarmEventAcknowledgmentUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsInputDeviceAlarmEventAcknowledgmentUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsInputDeviceAlarmEventAcknowledgmentUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsInputDeviceAlarmEventAcknowledgmentUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsInputDeviceAlarmEventAcknowledgmentUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsInputDeviceAlarmEventAcknowledgmentUniquePDSAValidator.ParameterNames.InputDeviceAlarmEventAcknowledgmentUid).Value = Entity.InputDeviceAlarmEventAcknowledgmentUid;
      this.Properties.GetByName(IsInputDeviceAlarmEventAcknowledgmentUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsInputDeviceAlarmEventAcknowledgmentUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsInputDeviceAlarmEventAcknowledgmentUniquePDSAValidator.ParameterNames.InputDeviceAlarmEventAcknowledgmentUid).IsNull == false)
        Entity.InputDeviceAlarmEventAcknowledgmentUid = this.Properties.GetByName(IsInputDeviceAlarmEventAcknowledgmentUniquePDSAValidator.ParameterNames.InputDeviceAlarmEventAcknowledgmentUid).GetAsGuid();
      if(this.Properties.GetByName(IsInputDeviceAlarmEventAcknowledgmentUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsInputDeviceAlarmEventAcknowledgmentUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsInputDeviceAlarmEventAcknowledgmentUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsInputDeviceAlarmEventAcknowledgmentUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsInputDeviceAlarmEventAcknowledgmentUniquePDSA class.
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
    /// Returns '@InputDeviceAlarmEventAcknowledgmentUid'
    /// </summary>
    public static string InputDeviceAlarmEventAcknowledgmentUid = "@InputDeviceAlarmEventAcknowledgmentUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsInputDeviceAlarmEventAcknowledgmentUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@InputDeviceAlarmEventAcknowledgmentUid'
    /// </summary>
    public static string InputDeviceAlarmEventAcknowledgmentUid = "@InputDeviceAlarmEventAcknowledgmentUid";
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

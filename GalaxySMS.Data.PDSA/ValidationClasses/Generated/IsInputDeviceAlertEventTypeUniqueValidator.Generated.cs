using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsInputDeviceAlertEventTypeUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsInputDeviceAlertEventTypeUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsInputDeviceAlertEventTypeUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsInputDeviceAlertEventTypeUniquePDSA Entity
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
    /// Clones the current IsInputDeviceAlertEventTypeUniquePDSA
    /// </summary>
    /// <returns>A cloned IsInputDeviceAlertEventTypeUniquePDSA object</returns>
    public IsInputDeviceAlertEventTypeUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsInputDeviceAlertEventTypeUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsInputDeviceAlertEventTypeUniquePDSA entity to clone</param>
    /// <returns>A cloned IsInputDeviceAlertEventTypeUniquePDSA object</returns>
    public IsInputDeviceAlertEventTypeUniquePDSA CloneEntity(IsInputDeviceAlertEventTypeUniquePDSA entityToClone)
    {
      IsInputDeviceAlertEventTypeUniquePDSA newEntity = new IsInputDeviceAlertEventTypeUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsInputDeviceAlertEventTypeUniquePDSAValidator.ParameterNames.InputDeviceAlertEventTypeUid, GetResourceMessage("GCS_IsInputDeviceAlertEventTypeUniquePDSA_InputDeviceAlertEventTypeUid_Header", "Input Device Alert Event Type Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsInputDeviceAlertEventTypeUniquePDSA_InputDeviceAlertEventTypeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsInputDeviceAlertEventTypeUniquePDSAValidator.ParameterNames.Tag, GetResourceMessage("GCS_IsInputDeviceAlertEventTypeUniquePDSA_Tag_Header", "Tag"), false, typeof(string), 8000, GetResourceMessage("GCS_IsInputDeviceAlertEventTypeUniquePDSA_Tag_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsInputDeviceAlertEventTypeUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsInputDeviceAlertEventTypeUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsInputDeviceAlertEventTypeUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsInputDeviceAlertEventTypeUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsInputDeviceAlertEventTypeUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsInputDeviceAlertEventTypeUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsInputDeviceAlertEventTypeUniquePDSAValidator.ParameterNames.InputDeviceAlertEventTypeUid).Value = Entity.InputDeviceAlertEventTypeUid;
      this.Properties.GetByName(IsInputDeviceAlertEventTypeUniquePDSAValidator.ParameterNames.Tag).Value = Entity.Tag;
      this.Properties.GetByName(IsInputDeviceAlertEventTypeUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsInputDeviceAlertEventTypeUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsInputDeviceAlertEventTypeUniquePDSAValidator.ParameterNames.InputDeviceAlertEventTypeUid).IsNull == false)
        Entity.InputDeviceAlertEventTypeUid = this.Properties.GetByName(IsInputDeviceAlertEventTypeUniquePDSAValidator.ParameterNames.InputDeviceAlertEventTypeUid).GetAsGuid();
      if(this.Properties.GetByName(IsInputDeviceAlertEventTypeUniquePDSAValidator.ParameterNames.Tag).IsNull == false)
        Entity.Tag = this.Properties.GetByName(IsInputDeviceAlertEventTypeUniquePDSAValidator.ParameterNames.Tag).GetAsString();
      if(this.Properties.GetByName(IsInputDeviceAlertEventTypeUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsInputDeviceAlertEventTypeUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsInputDeviceAlertEventTypeUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsInputDeviceAlertEventTypeUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsInputDeviceAlertEventTypeUniquePDSA class.
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
    /// Returns '@InputDeviceAlertEventTypeUid'
    /// </summary>
    public static string InputDeviceAlertEventTypeUid = "@InputDeviceAlertEventTypeUid";
    /// <summary>
    /// Returns '@Tag'
    /// </summary>
    public static string Tag = "@Tag";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsInputDeviceAlertEventTypeUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@InputDeviceAlertEventTypeUid'
    /// </summary>
    public static string InputDeviceAlertEventTypeUid = "@InputDeviceAlertEventTypeUid";
    /// <summary>
    /// Returns '@Tag'
    /// </summary>
    public static string Tag = "@Tag";
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

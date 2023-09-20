using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSA Entity
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
    /// Clones the current InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSA
    /// </summary>
    /// <returns>A cloned InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSA object</returns>
    public InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSA
    /// </summary>
    /// <param name="entityToClone">The InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSA entity to clone</param>
    /// <returns>A cloned InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSA object</returns>
    public InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSA CloneEntity(InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSA entityToClone)
    {
      InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSA newEntity = new InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSA();

      newEntity.InputOutputGroupUid = entityToClone.InputOutputGroupUid;

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
      
      props.Add(PDSAProperty.Create(InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSAValidator.ParameterNames.inputDeviceUid, GetResourceMessage("GCS_InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSA_inputDeviceUid_Header", "input Device Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSA_inputDeviceUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSAValidator.ParameterNames.ioGroupNumber, GetResourceMessage("GCS_InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSA_ioGroupNumber_Header", "io Group Number"), false, typeof(int), 0, GetResourceMessage("GCS_InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSA_ioGroupNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSAValidator.ParameterNames.inputDeviceUid).Value = Entity.inputDeviceUid;
      this.Properties.GetByName(InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSAValidator.ParameterNames.ioGroupNumber).Value = Entity.ioGroupNumber;
      this.Properties.GetByName(InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSAValidator.ParameterNames.inputDeviceUid).IsNull == false)
        Entity.inputDeviceUid = this.Properties.GetByName(InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSAValidator.ParameterNames.inputDeviceUid).GetAsGuid();
      if(this.Properties.GetByName(InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSAValidator.ParameterNames.ioGroupNumber).IsNull == false)
        Entity.ioGroupNumber = this.Properties.GetByName(InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSAValidator.ParameterNames.ioGroupNumber).GetAsInteger();
      if(this.Properties.GetByName(InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'InputOutputGroupUid'
    /// </summary>
    public static string InputOutputGroupUid = "InputOutputGroupUid";
    /// <summary>
    /// Returns '@inputDeviceUid'
    /// </summary>
    public static string inputDeviceUid = "@inputDeviceUid";
    /// <summary>
    /// Returns '@ioGroupNumber'
    /// </summary>
    public static string ioGroupNumber = "@ioGroupNumber";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the InputOutputGroupUid_GetByInputDeviceUidAndIOGroupNumberPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@inputDeviceUid'
    /// </summary>
    public static string inputDeviceUid = "@inputDeviceUid";
    /// <summary>
    /// Returns '@ioGroupNumber'
    /// </summary>
    public static string ioGroupNumber = "@ioGroupNumber";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}

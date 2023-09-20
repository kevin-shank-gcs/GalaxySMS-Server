using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsOutputDeviceActivityEventUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsOutputDeviceActivityEventUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsOutputDeviceActivityEventUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsOutputDeviceActivityEventUniquePDSA Entity
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
    /// Clones the current IsOutputDeviceActivityEventUniquePDSA
    /// </summary>
    /// <returns>A cloned IsOutputDeviceActivityEventUniquePDSA object</returns>
    public IsOutputDeviceActivityEventUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsOutputDeviceActivityEventUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsOutputDeviceActivityEventUniquePDSA entity to clone</param>
    /// <returns>A cloned IsOutputDeviceActivityEventUniquePDSA object</returns>
    public IsOutputDeviceActivityEventUniquePDSA CloneEntity(IsOutputDeviceActivityEventUniquePDSA entityToClone)
    {
      IsOutputDeviceActivityEventUniquePDSA newEntity = new IsOutputDeviceActivityEventUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsOutputDeviceActivityEventUniquePDSAValidator.ParameterNames.CpuNumber, GetResourceMessage("GCS_IsOutputDeviceActivityEventUniquePDSA_CpuNumber_Header", "Cpu Number"), false, typeof(short), 0, GetResourceMessage("GCS_IsOutputDeviceActivityEventUniquePDSA_CpuNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsOutputDeviceActivityEventUniquePDSAValidator.ParameterNames.ActivityDateTime, GetResourceMessage("GCS_IsOutputDeviceActivityEventUniquePDSA_ActivityDateTime_Header", "Activity Date Time"), false, typeof(DateTimeOffset), 0, GetResourceMessage("GCS_IsOutputDeviceActivityEventUniquePDSA_ActivityDateTime_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, Convert.ToDateTime("1753-1-1", System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat), @"", ""));
      props.Add(PDSAProperty.Create(IsOutputDeviceActivityEventUniquePDSAValidator.ParameterNames.BufferIndex, GetResourceMessage("GCS_IsOutputDeviceActivityEventUniquePDSA_BufferIndex_Header", "Buffer Index"), false, typeof(int), 0, GetResourceMessage("GCS_IsOutputDeviceActivityEventUniquePDSA_BufferIndex_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsOutputDeviceActivityEventUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsOutputDeviceActivityEventUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsOutputDeviceActivityEventUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsOutputDeviceActivityEventUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsOutputDeviceActivityEventUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsOutputDeviceActivityEventUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsOutputDeviceActivityEventUniquePDSAValidator.ParameterNames.CpuNumber).Value = Entity.CpuNumber;
      this.Properties.GetByName(IsOutputDeviceActivityEventUniquePDSAValidator.ParameterNames.ActivityDateTime).Value = Entity.ActivityDateTime;
      this.Properties.GetByName(IsOutputDeviceActivityEventUniquePDSAValidator.ParameterNames.BufferIndex).Value = Entity.BufferIndex;
      this.Properties.GetByName(IsOutputDeviceActivityEventUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsOutputDeviceActivityEventUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsOutputDeviceActivityEventUniquePDSAValidator.ParameterNames.CpuNumber).IsNull == false)
        Entity.CpuNumber = this.Properties.GetByName(IsOutputDeviceActivityEventUniquePDSAValidator.ParameterNames.CpuNumber).GetAsShort();
      if(this.Properties.GetByName(IsOutputDeviceActivityEventUniquePDSAValidator.ParameterNames.ActivityDateTime).IsNull == false)
        Entity.ActivityDateTime = this.Properties.GetByName(IsOutputDeviceActivityEventUniquePDSAValidator.ParameterNames.ActivityDateTime).GetAsDateTimeOffset();
      if(this.Properties.GetByName(IsOutputDeviceActivityEventUniquePDSAValidator.ParameterNames.BufferIndex).IsNull == false)
        Entity.BufferIndex = this.Properties.GetByName(IsOutputDeviceActivityEventUniquePDSAValidator.ParameterNames.BufferIndex).GetAsInteger();
      if(this.Properties.GetByName(IsOutputDeviceActivityEventUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsOutputDeviceActivityEventUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsOutputDeviceActivityEventUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsOutputDeviceActivityEventUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsOutputDeviceActivityEventUniquePDSA class.
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
    /// Returns '@CpuNumber'
    /// </summary>
    public static string CpuNumber = "@CpuNumber";
    /// <summary>
    /// Returns '@ActivityDateTime'
    /// </summary>
    public static string ActivityDateTime = "@ActivityDateTime";
    /// <summary>
    /// Returns '@BufferIndex'
    /// </summary>
    public static string BufferIndex = "@BufferIndex";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsOutputDeviceActivityEventUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@CpuNumber'
    /// </summary>
    public static string CpuNumber = "@CpuNumber";
    /// <summary>
    /// Returns '@ActivityDateTime'
    /// </summary>
    public static string ActivityDateTime = "@ActivityDateTime";
    /// <summary>
    /// Returns '@BufferIndex'
    /// </summary>
    public static string BufferIndex = "@BufferIndex";
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

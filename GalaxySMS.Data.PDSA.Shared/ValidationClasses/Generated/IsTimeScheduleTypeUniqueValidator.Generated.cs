using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsTimeScheduleTypeUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsTimeScheduleTypeUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsTimeScheduleTypeUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsTimeScheduleTypeUniquePDSA Entity
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
    /// Clones the current IsTimeScheduleTypeUniquePDSA
    /// </summary>
    /// <returns>A cloned IsTimeScheduleTypeUniquePDSA object</returns>
    public IsTimeScheduleTypeUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsTimeScheduleTypeUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsTimeScheduleTypeUniquePDSA entity to clone</param>
    /// <returns>A cloned IsTimeScheduleTypeUniquePDSA object</returns>
    public IsTimeScheduleTypeUniquePDSA CloneEntity(IsTimeScheduleTypeUniquePDSA entityToClone)
    {
      IsTimeScheduleTypeUniquePDSA newEntity = new IsTimeScheduleTypeUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsTimeScheduleTypeUniquePDSAValidator.ParameterNames.TimeScheduleTypeUid, GetResourceMessage("GCS_IsTimeScheduleTypeUniquePDSA_TimeScheduleTypeUid_Header", "Time Schedule Type Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsTimeScheduleTypeUniquePDSA_TimeScheduleTypeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsTimeScheduleTypeUniquePDSAValidator.ParameterNames.ScheduleTypeCode, GetResourceMessage("GCS_IsTimeScheduleTypeUniquePDSA_ScheduleTypeCode_Header", "Schedule Type Code"), false, typeof(short), 0, GetResourceMessage("GCS_IsTimeScheduleTypeUniquePDSA_ScheduleTypeCode_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsTimeScheduleTypeUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsTimeScheduleTypeUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsTimeScheduleTypeUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsTimeScheduleTypeUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsTimeScheduleTypeUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsTimeScheduleTypeUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsTimeScheduleTypeUniquePDSAValidator.ParameterNames.TimeScheduleTypeUid).Value = Entity.TimeScheduleTypeUid;
      this.Properties.GetByName(IsTimeScheduleTypeUniquePDSAValidator.ParameterNames.ScheduleTypeCode).Value = Entity.ScheduleTypeCode;
      this.Properties.GetByName(IsTimeScheduleTypeUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsTimeScheduleTypeUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsTimeScheduleTypeUniquePDSAValidator.ParameterNames.TimeScheduleTypeUid).IsNull == false)
        Entity.TimeScheduleTypeUid = this.Properties.GetByName(IsTimeScheduleTypeUniquePDSAValidator.ParameterNames.TimeScheduleTypeUid).GetAsGuid();
      if(this.Properties.GetByName(IsTimeScheduleTypeUniquePDSAValidator.ParameterNames.ScheduleTypeCode).IsNull == false)
        Entity.ScheduleTypeCode = this.Properties.GetByName(IsTimeScheduleTypeUniquePDSAValidator.ParameterNames.ScheduleTypeCode).GetAsShort();
      if(this.Properties.GetByName(IsTimeScheduleTypeUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsTimeScheduleTypeUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsTimeScheduleTypeUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsTimeScheduleTypeUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsTimeScheduleTypeUniquePDSA class.
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
    /// Returns '@TimeScheduleTypeUid'
    /// </summary>
    public static string TimeScheduleTypeUid = "@TimeScheduleTypeUid";
    /// <summary>
    /// Returns '@ScheduleTypeCode'
    /// </summary>
    public static string ScheduleTypeCode = "@ScheduleTypeCode";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsTimeScheduleTypeUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@TimeScheduleTypeUid'
    /// </summary>
    public static string TimeScheduleTypeUid = "@TimeScheduleTypeUid";
    /// <summary>
    /// Returns '@ScheduleTypeCode'
    /// </summary>
    public static string ScheduleTypeCode = "@ScheduleTypeCode";
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

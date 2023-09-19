using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsAssaDsrTimeScheduleMapUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsAssaDsrTimeScheduleMapUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsAssaDsrTimeScheduleMapUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsAssaDsrTimeScheduleMapUniquePDSA Entity
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
    /// Clones the current IsAssaDsrTimeScheduleMapUniquePDSA
    /// </summary>
    /// <returns>A cloned IsAssaDsrTimeScheduleMapUniquePDSA object</returns>
    public IsAssaDsrTimeScheduleMapUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsAssaDsrTimeScheduleMapUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsAssaDsrTimeScheduleMapUniquePDSA entity to clone</param>
    /// <returns>A cloned IsAssaDsrTimeScheduleMapUniquePDSA object</returns>
    public IsAssaDsrTimeScheduleMapUniquePDSA CloneEntity(IsAssaDsrTimeScheduleMapUniquePDSA entityToClone)
    {
      IsAssaDsrTimeScheduleMapUniquePDSA newEntity = new IsAssaDsrTimeScheduleMapUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsAssaDsrTimeScheduleMapUniquePDSAValidator.ParameterNames.AssaDsrTimeScheduleMapUid, GetResourceMessage("GCS_IsAssaDsrTimeScheduleMapUniquePDSA_AssaDsrTimeScheduleMapUid_Header", "Assa Dsr Time Schedule Map Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsAssaDsrTimeScheduleMapUniquePDSA_AssaDsrTimeScheduleMapUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAssaDsrTimeScheduleMapUniquePDSAValidator.ParameterNames.TimeScheduleUid, GetResourceMessage("GCS_IsAssaDsrTimeScheduleMapUniquePDSA_TimeScheduleUid_Header", "Time Schedule Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsAssaDsrTimeScheduleMapUniquePDSA_TimeScheduleUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAssaDsrTimeScheduleMapUniquePDSAValidator.ParameterNames.AssaDsrUid, GetResourceMessage("GCS_IsAssaDsrTimeScheduleMapUniquePDSA_AssaDsrUid_Header", "Assa Dsr Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsAssaDsrTimeScheduleMapUniquePDSA_AssaDsrUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAssaDsrTimeScheduleMapUniquePDSAValidator.ParameterNames.AssaDsrScheduleId, GetResourceMessage("GCS_IsAssaDsrTimeScheduleMapUniquePDSA_AssaDsrScheduleId_Header", "Assa Dsr Schedule Id"), false, typeof(string), 8000, GetResourceMessage("GCS_IsAssaDsrTimeScheduleMapUniquePDSA_AssaDsrScheduleId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAssaDsrTimeScheduleMapUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsAssaDsrTimeScheduleMapUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsAssaDsrTimeScheduleMapUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsAssaDsrTimeScheduleMapUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsAssaDsrTimeScheduleMapUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsAssaDsrTimeScheduleMapUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsAssaDsrTimeScheduleMapUniquePDSAValidator.ParameterNames.AssaDsrTimeScheduleMapUid).Value = Entity.AssaDsrTimeScheduleMapUid;
      this.Properties.GetByName(IsAssaDsrTimeScheduleMapUniquePDSAValidator.ParameterNames.TimeScheduleUid).Value = Entity.TimeScheduleUid;
      this.Properties.GetByName(IsAssaDsrTimeScheduleMapUniquePDSAValidator.ParameterNames.AssaDsrUid).Value = Entity.AssaDsrUid;
      this.Properties.GetByName(IsAssaDsrTimeScheduleMapUniquePDSAValidator.ParameterNames.AssaDsrScheduleId).Value = Entity.AssaDsrScheduleId;
      this.Properties.GetByName(IsAssaDsrTimeScheduleMapUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsAssaDsrTimeScheduleMapUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsAssaDsrTimeScheduleMapUniquePDSAValidator.ParameterNames.AssaDsrTimeScheduleMapUid).IsNull == false)
        Entity.AssaDsrTimeScheduleMapUid = this.Properties.GetByName(IsAssaDsrTimeScheduleMapUniquePDSAValidator.ParameterNames.AssaDsrTimeScheduleMapUid).GetAsGuid();
      if(this.Properties.GetByName(IsAssaDsrTimeScheduleMapUniquePDSAValidator.ParameterNames.TimeScheduleUid).IsNull == false)
        Entity.TimeScheduleUid = this.Properties.GetByName(IsAssaDsrTimeScheduleMapUniquePDSAValidator.ParameterNames.TimeScheduleUid).GetAsGuid();
      if(this.Properties.GetByName(IsAssaDsrTimeScheduleMapUniquePDSAValidator.ParameterNames.AssaDsrUid).IsNull == false)
        Entity.AssaDsrUid = this.Properties.GetByName(IsAssaDsrTimeScheduleMapUniquePDSAValidator.ParameterNames.AssaDsrUid).GetAsGuid();
      if(this.Properties.GetByName(IsAssaDsrTimeScheduleMapUniquePDSAValidator.ParameterNames.AssaDsrScheduleId).IsNull == false)
        Entity.AssaDsrScheduleId = this.Properties.GetByName(IsAssaDsrTimeScheduleMapUniquePDSAValidator.ParameterNames.AssaDsrScheduleId).GetAsString();
      if(this.Properties.GetByName(IsAssaDsrTimeScheduleMapUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsAssaDsrTimeScheduleMapUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsAssaDsrTimeScheduleMapUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsAssaDsrTimeScheduleMapUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsAssaDsrTimeScheduleMapUniquePDSA class.
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
    /// Returns '@AssaDsrTimeScheduleMapUid'
    /// </summary>
    public static string AssaDsrTimeScheduleMapUid = "@AssaDsrTimeScheduleMapUid";
    /// <summary>
    /// Returns '@TimeScheduleUid'
    /// </summary>
    public static string TimeScheduleUid = "@TimeScheduleUid";
    /// <summary>
    /// Returns '@AssaDsrUid'
    /// </summary>
    public static string AssaDsrUid = "@AssaDsrUid";
    /// <summary>
    /// Returns '@AssaDsrScheduleId'
    /// </summary>
    public static string AssaDsrScheduleId = "@AssaDsrScheduleId";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsAssaDsrTimeScheduleMapUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@AssaDsrTimeScheduleMapUid'
    /// </summary>
    public static string AssaDsrTimeScheduleMapUid = "@AssaDsrTimeScheduleMapUid";
    /// <summary>
    /// Returns '@TimeScheduleUid'
    /// </summary>
    public static string TimeScheduleUid = "@TimeScheduleUid";
    /// <summary>
    /// Returns '@AssaDsrUid'
    /// </summary>
    public static string AssaDsrUid = "@AssaDsrUid";
    /// <summary>
    /// Returns '@AssaDsrScheduleId'
    /// </summary>
    public static string AssaDsrScheduleId = "@AssaDsrScheduleId";
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

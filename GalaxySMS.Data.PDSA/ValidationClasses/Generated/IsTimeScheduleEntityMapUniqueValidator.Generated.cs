using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsTimeScheduleEntityMapUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsTimeScheduleEntityMapUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsTimeScheduleEntityMapUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsTimeScheduleEntityMapUniquePDSA Entity
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
    /// Clones the current IsTimeScheduleEntityMapUniquePDSA
    /// </summary>
    /// <returns>A cloned IsTimeScheduleEntityMapUniquePDSA object</returns>
    public IsTimeScheduleEntityMapUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsTimeScheduleEntityMapUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsTimeScheduleEntityMapUniquePDSA entity to clone</param>
    /// <returns>A cloned IsTimeScheduleEntityMapUniquePDSA object</returns>
    public IsTimeScheduleEntityMapUniquePDSA CloneEntity(IsTimeScheduleEntityMapUniquePDSA entityToClone)
    {
      IsTimeScheduleEntityMapUniquePDSA newEntity = new IsTimeScheduleEntityMapUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsTimeScheduleEntityMapUniquePDSAValidator.ParameterNames.TimeScheduleEntityMapUid, GetResourceMessage("GCS_IsTimeScheduleEntityMapUniquePDSA_TimeScheduleEntityMapUid_Header", "Time Schedule Entity Map Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsTimeScheduleEntityMapUniquePDSA_TimeScheduleEntityMapUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsTimeScheduleEntityMapUniquePDSAValidator.ParameterNames.TimeScheduleUid, GetResourceMessage("GCS_IsTimeScheduleEntityMapUniquePDSA_TimeScheduleUid_Header", "Time Schedule Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsTimeScheduleEntityMapUniquePDSA_TimeScheduleUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsTimeScheduleEntityMapUniquePDSAValidator.ParameterNames.EntityId, GetResourceMessage("GCS_IsTimeScheduleEntityMapUniquePDSA_EntityId_Header", "Entity Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsTimeScheduleEntityMapUniquePDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsTimeScheduleEntityMapUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsTimeScheduleEntityMapUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsTimeScheduleEntityMapUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsTimeScheduleEntityMapUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsTimeScheduleEntityMapUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsTimeScheduleEntityMapUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsTimeScheduleEntityMapUniquePDSAValidator.ParameterNames.TimeScheduleEntityMapUid).Value = Entity.TimeScheduleEntityMapUid;
      this.Properties.GetByName(IsTimeScheduleEntityMapUniquePDSAValidator.ParameterNames.TimeScheduleUid).Value = Entity.TimeScheduleUid;
      this.Properties.GetByName(IsTimeScheduleEntityMapUniquePDSAValidator.ParameterNames.EntityId).Value = Entity.EntityId;
      this.Properties.GetByName(IsTimeScheduleEntityMapUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsTimeScheduleEntityMapUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsTimeScheduleEntityMapUniquePDSAValidator.ParameterNames.TimeScheduleEntityMapUid).IsNull == false)
        Entity.TimeScheduleEntityMapUid = this.Properties.GetByName(IsTimeScheduleEntityMapUniquePDSAValidator.ParameterNames.TimeScheduleEntityMapUid).GetAsGuid();
      if(this.Properties.GetByName(IsTimeScheduleEntityMapUniquePDSAValidator.ParameterNames.TimeScheduleUid).IsNull == false)
        Entity.TimeScheduleUid = this.Properties.GetByName(IsTimeScheduleEntityMapUniquePDSAValidator.ParameterNames.TimeScheduleUid).GetAsGuid();
      if(this.Properties.GetByName(IsTimeScheduleEntityMapUniquePDSAValidator.ParameterNames.EntityId).IsNull == false)
        Entity.EntityId = this.Properties.GetByName(IsTimeScheduleEntityMapUniquePDSAValidator.ParameterNames.EntityId).GetAsGuid();
      if(this.Properties.GetByName(IsTimeScheduleEntityMapUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsTimeScheduleEntityMapUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsTimeScheduleEntityMapUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsTimeScheduleEntityMapUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsTimeScheduleEntityMapUniquePDSA class.
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
    /// Returns '@TimeScheduleEntityMapUid'
    /// </summary>
    public static string TimeScheduleEntityMapUid = "@TimeScheduleEntityMapUid";
    /// <summary>
    /// Returns '@TimeScheduleUid'
    /// </summary>
    public static string TimeScheduleUid = "@TimeScheduleUid";
    /// <summary>
    /// Returns '@EntityId'
    /// </summary>
    public static string EntityId = "@EntityId";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsTimeScheduleEntityMapUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@TimeScheduleEntityMapUid'
    /// </summary>
    public static string TimeScheduleEntityMapUid = "@TimeScheduleEntityMapUid";
    /// <summary>
    /// Returns '@TimeScheduleUid'
    /// </summary>
    public static string TimeScheduleUid = "@TimeScheduleUid";
    /// <summary>
    /// Returns '@EntityId'
    /// </summary>
    public static string EntityId = "@EntityId";
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

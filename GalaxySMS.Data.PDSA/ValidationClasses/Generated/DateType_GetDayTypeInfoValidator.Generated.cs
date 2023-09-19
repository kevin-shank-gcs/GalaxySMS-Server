using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the DateType_GetDayTypeInfoPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class DateType_GetDayTypeInfoPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private DateType_GetDayTypeInfoPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new DateType_GetDayTypeInfoPDSA Entity
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
    /// Clones the current DateType_GetDayTypeInfoPDSA
    /// </summary>
    /// <returns>A cloned DateType_GetDayTypeInfoPDSA object</returns>
    public DateType_GetDayTypeInfoPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in DateType_GetDayTypeInfoPDSA
    /// </summary>
    /// <param name="entityToClone">The DateType_GetDayTypeInfoPDSA entity to clone</param>
    /// <returns>A cloned DateType_GetDayTypeInfoPDSA object</returns>
    public DateType_GetDayTypeInfoPDSA CloneEntity(DateType_GetDayTypeInfoPDSA entityToClone)
    {
      DateType_GetDayTypeInfoPDSA newEntity = new DateType_GetDayTypeInfoPDSA();

      newEntity.DayTypeUid = entityToClone.DayTypeUid;
      newEntity.Name = entityToClone.Name;

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
      
      props.Add(PDSAProperty.Create(DateType_GetDayTypeInfoPDSAValidator.ParameterNames.EntityId, GetResourceMessage("GCS_DateType_GetDayTypeInfoPDSA_EntityId_Header", "Entity Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_DateType_GetDayTypeInfoPDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(DateType_GetDayTypeInfoPDSAValidator.ParameterNames.Date, GetResourceMessage("GCS_DateType_GetDayTypeInfoPDSA_Date_Header", "Date"), false, typeof(DateTimeOffset), 0, GetResourceMessage("GCS_DateType_GetDayTypeInfoPDSA_Date_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.MinValue, @"", ""));
      props.Add(PDSAProperty.Create(DateType_GetDayTypeInfoPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_DateType_GetDayTypeInfoPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_DateType_GetDayTypeInfoPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(DateType_GetDayTypeInfoPDSAValidator.ParameterNames.EntityId).Value = Entity.EntityId;
      this.Properties.GetByName(DateType_GetDayTypeInfoPDSAValidator.ParameterNames.Date).Value = Entity.Date;
      this.Properties.GetByName(DateType_GetDayTypeInfoPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(DateType_GetDayTypeInfoPDSAValidator.ParameterNames.EntityId).IsNull == false)
        Entity.EntityId = this.Properties.GetByName(DateType_GetDayTypeInfoPDSAValidator.ParameterNames.EntityId).GetAsGuid();
      if(this.Properties.GetByName(DateType_GetDayTypeInfoPDSAValidator.ParameterNames.Date).IsNull == false)
        Entity.Date = this.Properties.GetByName(DateType_GetDayTypeInfoPDSAValidator.ParameterNames.Date).GetAsDateTimeOffset();
      if(this.Properties.GetByName(DateType_GetDayTypeInfoPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(DateType_GetDayTypeInfoPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the DateType_GetDayTypeInfoPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'DayTypeUid'
    /// </summary>
    public static string DayTypeUid = "DayTypeUid";
    /// <summary>
    /// Returns 'Name'
    /// </summary>
    public static string Name = "Name";
    /// <summary>
    /// Returns '@EntityId'
    /// </summary>
    public static string EntityId = "@EntityId";
    /// <summary>
    /// Returns '@Date'
    /// </summary>
    public static string Date = "@Date";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the DateType_GetDayTypeInfoPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@EntityId'
    /// </summary>
    public static string EntityId = "@EntityId";
    /// <summary>
    /// Returns '@Date'
    /// </summary>
    public static string Date = "@Date";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}

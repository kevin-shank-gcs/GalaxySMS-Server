using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the DateType_GetClustersThatUseDateTypePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class DateType_GetClustersThatUseDateTypePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private DateType_GetClustersThatUseDateTypePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new DateType_GetClustersThatUseDateTypePDSA Entity
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
    /// Clones the current DateType_GetClustersThatUseDateTypePDSA
    /// </summary>
    /// <returns>A cloned DateType_GetClustersThatUseDateTypePDSA object</returns>
    public DateType_GetClustersThatUseDateTypePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in DateType_GetClustersThatUseDateTypePDSA
    /// </summary>
    /// <param name="entityToClone">The DateType_GetClustersThatUseDateTypePDSA entity to clone</param>
    /// <returns>A cloned DateType_GetClustersThatUseDateTypePDSA object</returns>
    public DateType_GetClustersThatUseDateTypePDSA CloneEntity(DateType_GetClustersThatUseDateTypePDSA entityToClone)
    {
      DateType_GetClustersThatUseDateTypePDSA newEntity = new DateType_GetClustersThatUseDateTypePDSA();

      newEntity.DateTypeUid = entityToClone.DateTypeUid;
      newEntity.Date_x = entityToClone.Date_x;
      newEntity.EntityName = entityToClone.EntityName;
      newEntity.ClusterUid = entityToClone.ClusterUid;
      newEntity.ClusterGroupId = entityToClone.ClusterGroupId;
      newEntity.ClusterNumber = entityToClone.ClusterNumber;
      newEntity.ClusterName = entityToClone.ClusterName;
      newEntity.ScheduleTypeCode = entityToClone.ScheduleTypeCode;
      newEntity.ScheduleTypeDisplay = entityToClone.ScheduleTypeDisplay;

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
      
      props.Add(PDSAProperty.Create(DateType_GetClustersThatUseDateTypePDSAValidator.ParameterNames.DateTypeUid, GetResourceMessage("GCS_DateType_GetClustersThatUseDateTypePDSA_DateTypeUid_Header", "Date Type Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_DateType_GetClustersThatUseDateTypePDSA_DateTypeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(DateType_GetClustersThatUseDateTypePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_DateType_GetClustersThatUseDateTypePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_DateType_GetClustersThatUseDateTypePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(DateType_GetClustersThatUseDateTypePDSAValidator.ParameterNames.DateTypeUid).Value = Entity.DateTypeUid;
      this.Properties.GetByName(DateType_GetClustersThatUseDateTypePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(DateType_GetClustersThatUseDateTypePDSAValidator.ParameterNames.DateTypeUid).IsNull == false)
        Entity.DateTypeUid = this.Properties.GetByName(DateType_GetClustersThatUseDateTypePDSAValidator.ParameterNames.DateTypeUid).GetAsGuid();
      if(this.Properties.GetByName(DateType_GetClustersThatUseDateTypePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(DateType_GetClustersThatUseDateTypePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the DateType_GetClustersThatUseDateTypePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'DateTypeUid'
    /// </summary>
    public static string DateTypeUid = "DateTypeUid";
    /// <summary>
    /// Returns '[Date]'
    /// </summary>
    public static string Date_x = "Date";
    /// <summary>
    /// Returns 'EntityName'
    /// </summary>
    public static string EntityName = "EntityName";
    /// <summary>
    /// Returns 'ClusterUid'
    /// </summary>
    public static string ClusterUid = "ClusterUid";
    /// <summary>
    /// Returns 'ClusterGroupId'
    /// </summary>
    public static string ClusterGroupId = "ClusterGroupId";
    /// <summary>
    /// Returns 'ClusterNumber'
    /// </summary>
    public static string ClusterNumber = "ClusterNumber";
    /// <summary>
    /// Returns 'ClusterName'
    /// </summary>
    public static string ClusterName = "ClusterName";
    /// <summary>
    /// Returns 'ScheduleTypeCode'
    /// </summary>
    public static string ScheduleTypeCode = "ScheduleTypeCode";
    /// <summary>
    /// Returns 'ScheduleTypeDisplay'
    /// </summary>
    public static string ScheduleTypeDisplay = "ScheduleTypeDisplay";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the DateType_GetClustersThatUseDateTypePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@DateTypeUid'
    /// </summary>
    public static string DateTypeUid = "@DateTypeUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}

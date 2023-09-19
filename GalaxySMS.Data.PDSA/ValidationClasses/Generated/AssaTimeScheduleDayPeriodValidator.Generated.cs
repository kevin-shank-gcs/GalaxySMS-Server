using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the AssaTimeScheduleDayPeriodPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class AssaTimeScheduleDayPeriodPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private AssaTimeScheduleDayPeriodPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new AssaTimeScheduleDayPeriodPDSA Entity
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
    /// Clones the current AssaTimeScheduleDayPeriodPDSA
    /// </summary>
    /// <returns>A cloned AssaTimeScheduleDayPeriodPDSA object</returns>
    public AssaTimeScheduleDayPeriodPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in AssaTimeScheduleDayPeriodPDSA
    /// </summary>
    /// <param name="entityToClone">The AssaTimeScheduleDayPeriodPDSA entity to clone</param>
    /// <returns>A cloned AssaTimeScheduleDayPeriodPDSA object</returns>
    public AssaTimeScheduleDayPeriodPDSA CloneEntity(AssaTimeScheduleDayPeriodPDSA entityToClone)
    {
      AssaTimeScheduleDayPeriodPDSA newEntity = new AssaTimeScheduleDayPeriodPDSA();

      newEntity.AssaTimeScheduleDayPeriodUid = entityToClone.AssaTimeScheduleDayPeriodUid;
      newEntity.TimeScheduleUid = entityToClone.TimeScheduleUid;
      newEntity.AssaDayPeriodUid = entityToClone.AssaDayPeriodUid;
      newEntity.InsertName = entityToClone.InsertName;
      newEntity.InsertDate = entityToClone.InsertDate;
      newEntity.UpdateName = entityToClone.UpdateName;
      newEntity.UpdateDate = entityToClone.UpdateDate;
      newEntity.ConcurrencyValue = entityToClone.ConcurrencyValue;

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
      
      props.Add(PDSAProperty.Create(AssaTimeScheduleDayPeriodPDSAValidator.ColumnNames.AssaTimeScheduleDayPeriodUid, GetResourceMessage("GCS_AssaTimeScheduleDayPeriodPDSA_AssaTimeScheduleDayPeriodUid_Header", "Assa Time Schedule Day Period Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_AssaTimeScheduleDayPeriodPDSA_AssaTimeScheduleDayPeriodUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(AssaTimeScheduleDayPeriodPDSAValidator.ColumnNames.TimeScheduleUid, GetResourceMessage("GCS_AssaTimeScheduleDayPeriodPDSA_TimeScheduleUid_Header", "Time Schedule Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_AssaTimeScheduleDayPeriodPDSA_TimeScheduleUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(AssaTimeScheduleDayPeriodPDSAValidator.ColumnNames.AssaDayPeriodUid, GetResourceMessage("GCS_AssaTimeScheduleDayPeriodPDSA_AssaDayPeriodUid_Header", "Assa Day Period Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_AssaTimeScheduleDayPeriodPDSA_AssaDayPeriodUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(AssaTimeScheduleDayPeriodPDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_AssaTimeScheduleDayPeriodPDSA_InsertName_Header", "Insert Name"), true, typeof(string), 100, GetResourceMessage("GCS_AssaTimeScheduleDayPeriodPDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AssaTimeScheduleDayPeriodPDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_AssaTimeScheduleDayPeriodPDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_AssaTimeScheduleDayPeriodPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(AssaTimeScheduleDayPeriodPDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_AssaTimeScheduleDayPeriodPDSA_UpdateName_Header", "Update Name"), true, typeof(string), 100, GetResourceMessage("GCS_AssaTimeScheduleDayPeriodPDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AssaTimeScheduleDayPeriodPDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_AssaTimeScheduleDayPeriodPDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_AssaTimeScheduleDayPeriodPDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(AssaTimeScheduleDayPeriodPDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_AssaTimeScheduleDayPeriodPDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_AssaTimeScheduleDayPeriodPDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.AssaTimeScheduleDayPeriodUid = Guid.NewGuid();
      Entity.TimeScheduleUid = Guid.NewGuid();
      Entity.AssaDayPeriodUid = Guid.NewGuid();
      Entity.InsertName = string.Empty;
      Entity.InsertDate = DateTimeOffset.Now;
      Entity.UpdateName = string.Empty;
      Entity.UpdateDate = DateTimeOffset.Now;
      Entity.ConcurrencyValue = 0;

      Entity.ResetAllIsDirtyProperties();
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
      if (Properties == null)
        InitProperties();
      
      if(!Properties.GetByName(AssaTimeScheduleDayPeriodPDSAValidator.ColumnNames.AssaTimeScheduleDayPeriodUid).SetAsNull)
        Properties.GetByName(AssaTimeScheduleDayPeriodPDSAValidator.ColumnNames.AssaTimeScheduleDayPeriodUid).Value = Entity.AssaTimeScheduleDayPeriodUid;
      if(!Properties.GetByName(AssaTimeScheduleDayPeriodPDSAValidator.ColumnNames.TimeScheduleUid).SetAsNull)
        Properties.GetByName(AssaTimeScheduleDayPeriodPDSAValidator.ColumnNames.TimeScheduleUid).Value = Entity.TimeScheduleUid;
      if(!Properties.GetByName(AssaTimeScheduleDayPeriodPDSAValidator.ColumnNames.AssaDayPeriodUid).SetAsNull)
        Properties.GetByName(AssaTimeScheduleDayPeriodPDSAValidator.ColumnNames.AssaDayPeriodUid).Value = Entity.AssaDayPeriodUid;
      if(!Properties.GetByName(AssaTimeScheduleDayPeriodPDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(AssaTimeScheduleDayPeriodPDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(AssaTimeScheduleDayPeriodPDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(AssaTimeScheduleDayPeriodPDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(AssaTimeScheduleDayPeriodPDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(AssaTimeScheduleDayPeriodPDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(AssaTimeScheduleDayPeriodPDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(AssaTimeScheduleDayPeriodPDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(AssaTimeScheduleDayPeriodPDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(AssaTimeScheduleDayPeriodPDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(AssaTimeScheduleDayPeriodPDSAValidator.ColumnNames.AssaTimeScheduleDayPeriodUid).IsNull == false)
        Entity.AssaTimeScheduleDayPeriodUid = Properties.GetByName(AssaTimeScheduleDayPeriodPDSAValidator.ColumnNames.AssaTimeScheduleDayPeriodUid).GetAsGuid();
      if(Properties.GetByName(AssaTimeScheduleDayPeriodPDSAValidator.ColumnNames.TimeScheduleUid).IsNull == false)
        Entity.TimeScheduleUid = Properties.GetByName(AssaTimeScheduleDayPeriodPDSAValidator.ColumnNames.TimeScheduleUid).GetAsGuid();
      if(Properties.GetByName(AssaTimeScheduleDayPeriodPDSAValidator.ColumnNames.AssaDayPeriodUid).IsNull == false)
        Entity.AssaDayPeriodUid = Properties.GetByName(AssaTimeScheduleDayPeriodPDSAValidator.ColumnNames.AssaDayPeriodUid).GetAsGuid();
      if(Properties.GetByName(AssaTimeScheduleDayPeriodPDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(AssaTimeScheduleDayPeriodPDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(AssaTimeScheduleDayPeriodPDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(AssaTimeScheduleDayPeriodPDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(AssaTimeScheduleDayPeriodPDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(AssaTimeScheduleDayPeriodPDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(AssaTimeScheduleDayPeriodPDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(AssaTimeScheduleDayPeriodPDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(AssaTimeScheduleDayPeriodPDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(AssaTimeScheduleDayPeriodPDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the AssaTimeScheduleDayPeriodPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'AssaTimeScheduleDayPeriodUid'
    /// </summary>
    public static string AssaTimeScheduleDayPeriodUid = "AssaTimeScheduleDayPeriodUid";
    /// <summary>
    /// Returns 'TimeScheduleUid'
    /// </summary>
    public static string TimeScheduleUid = "TimeScheduleUid";
    /// <summary>
    /// Returns 'AssaDayPeriodUid'
    /// </summary>
    public static string AssaDayPeriodUid = "AssaDayPeriodUid";
    /// <summary>
    /// Returns 'InsertName'
    /// </summary>
    public static string InsertName = "InsertName";
    /// <summary>
    /// Returns 'InsertDate'
    /// </summary>
    public static string InsertDate = "InsertDate";
    /// <summary>
    /// Returns 'UpdateName'
    /// </summary>
    public static string UpdateName = "UpdateName";
    /// <summary>
    /// Returns 'UpdateDate'
    /// </summary>
    public static string UpdateDate = "UpdateDate";
    /// <summary>
    /// Returns 'ConcurrencyValue'
    /// </summary>
    public static string ConcurrencyValue = "ConcurrencyValue";
    }
    #endregion
  }
}

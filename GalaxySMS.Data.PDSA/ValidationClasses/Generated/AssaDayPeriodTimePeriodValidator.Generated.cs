using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the AssaDayPeriodTimePeriodPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class AssaDayPeriodTimePeriodPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private AssaDayPeriodTimePeriodPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new AssaDayPeriodTimePeriodPDSA Entity
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
    /// Clones the current AssaDayPeriodTimePeriodPDSA
    /// </summary>
    /// <returns>A cloned AssaDayPeriodTimePeriodPDSA object</returns>
    public AssaDayPeriodTimePeriodPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in AssaDayPeriodTimePeriodPDSA
    /// </summary>
    /// <param name="entityToClone">The AssaDayPeriodTimePeriodPDSA entity to clone</param>
    /// <returns>A cloned AssaDayPeriodTimePeriodPDSA object</returns>
    public AssaDayPeriodTimePeriodPDSA CloneEntity(AssaDayPeriodTimePeriodPDSA entityToClone)
    {
      AssaDayPeriodTimePeriodPDSA newEntity = new AssaDayPeriodTimePeriodPDSA();

      newEntity.AssaDayPeriodTimePeriodUid = entityToClone.AssaDayPeriodTimePeriodUid;
      newEntity.AssaDayPeriodUid = entityToClone.AssaDayPeriodUid;
      newEntity.TimePeriodUid = entityToClone.TimePeriodUid;
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
      
      props.Add(PDSAProperty.Create(AssaDayPeriodTimePeriodPDSAValidator.ColumnNames.AssaDayPeriodTimePeriodUid, GetResourceMessage("GCS_AssaDayPeriodTimePeriodPDSA_AssaDayPeriodTimePeriodUid_Header", "Assa Day Period Time Period Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_AssaDayPeriodTimePeriodPDSA_AssaDayPeriodTimePeriodUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(AssaDayPeriodTimePeriodPDSAValidator.ColumnNames.AssaDayPeriodUid, GetResourceMessage("GCS_AssaDayPeriodTimePeriodPDSA_AssaDayPeriodUid_Header", "Assa Day Period Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_AssaDayPeriodTimePeriodPDSA_AssaDayPeriodUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(AssaDayPeriodTimePeriodPDSAValidator.ColumnNames.TimePeriodUid, GetResourceMessage("GCS_AssaDayPeriodTimePeriodPDSA_TimePeriodUid_Header", "Time Period Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_AssaDayPeriodTimePeriodPDSA_TimePeriodUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(AssaDayPeriodTimePeriodPDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_AssaDayPeriodTimePeriodPDSA_InsertName_Header", "Insert Name"), true, typeof(string), 100, GetResourceMessage("GCS_AssaDayPeriodTimePeriodPDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AssaDayPeriodTimePeriodPDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_AssaDayPeriodTimePeriodPDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_AssaDayPeriodTimePeriodPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(AssaDayPeriodTimePeriodPDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_AssaDayPeriodTimePeriodPDSA_UpdateName_Header", "Update Name"), true, typeof(string), 100, GetResourceMessage("GCS_AssaDayPeriodTimePeriodPDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AssaDayPeriodTimePeriodPDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_AssaDayPeriodTimePeriodPDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_AssaDayPeriodTimePeriodPDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(AssaDayPeriodTimePeriodPDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_AssaDayPeriodTimePeriodPDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_AssaDayPeriodTimePeriodPDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.AssaDayPeriodTimePeriodUid = Guid.NewGuid();
      Entity.AssaDayPeriodUid = Guid.NewGuid();
      Entity.TimePeriodUid = Guid.NewGuid();
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
      
      if(!Properties.GetByName(AssaDayPeriodTimePeriodPDSAValidator.ColumnNames.AssaDayPeriodTimePeriodUid).SetAsNull)
        Properties.GetByName(AssaDayPeriodTimePeriodPDSAValidator.ColumnNames.AssaDayPeriodTimePeriodUid).Value = Entity.AssaDayPeriodTimePeriodUid;
      if(!Properties.GetByName(AssaDayPeriodTimePeriodPDSAValidator.ColumnNames.AssaDayPeriodUid).SetAsNull)
        Properties.GetByName(AssaDayPeriodTimePeriodPDSAValidator.ColumnNames.AssaDayPeriodUid).Value = Entity.AssaDayPeriodUid;
      if(!Properties.GetByName(AssaDayPeriodTimePeriodPDSAValidator.ColumnNames.TimePeriodUid).SetAsNull)
        Properties.GetByName(AssaDayPeriodTimePeriodPDSAValidator.ColumnNames.TimePeriodUid).Value = Entity.TimePeriodUid;
      if(!Properties.GetByName(AssaDayPeriodTimePeriodPDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(AssaDayPeriodTimePeriodPDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(AssaDayPeriodTimePeriodPDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(AssaDayPeriodTimePeriodPDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(AssaDayPeriodTimePeriodPDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(AssaDayPeriodTimePeriodPDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(AssaDayPeriodTimePeriodPDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(AssaDayPeriodTimePeriodPDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(AssaDayPeriodTimePeriodPDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(AssaDayPeriodTimePeriodPDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(AssaDayPeriodTimePeriodPDSAValidator.ColumnNames.AssaDayPeriodTimePeriodUid).IsNull == false)
        Entity.AssaDayPeriodTimePeriodUid = Properties.GetByName(AssaDayPeriodTimePeriodPDSAValidator.ColumnNames.AssaDayPeriodTimePeriodUid).GetAsGuid();
      if(Properties.GetByName(AssaDayPeriodTimePeriodPDSAValidator.ColumnNames.AssaDayPeriodUid).IsNull == false)
        Entity.AssaDayPeriodUid = Properties.GetByName(AssaDayPeriodTimePeriodPDSAValidator.ColumnNames.AssaDayPeriodUid).GetAsGuid();
      if(Properties.GetByName(AssaDayPeriodTimePeriodPDSAValidator.ColumnNames.TimePeriodUid).IsNull == false)
        Entity.TimePeriodUid = Properties.GetByName(AssaDayPeriodTimePeriodPDSAValidator.ColumnNames.TimePeriodUid).GetAsGuid();
      if(Properties.GetByName(AssaDayPeriodTimePeriodPDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(AssaDayPeriodTimePeriodPDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(AssaDayPeriodTimePeriodPDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(AssaDayPeriodTimePeriodPDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(AssaDayPeriodTimePeriodPDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(AssaDayPeriodTimePeriodPDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(AssaDayPeriodTimePeriodPDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(AssaDayPeriodTimePeriodPDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(AssaDayPeriodTimePeriodPDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(AssaDayPeriodTimePeriodPDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the AssaDayPeriodTimePeriodPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'AssaDayPeriodTimePeriodUid'
    /// </summary>
    public static string AssaDayPeriodTimePeriodUid = "AssaDayPeriodTimePeriodUid";
    /// <summary>
    /// Returns 'AssaDayPeriodUid'
    /// </summary>
    public static string AssaDayPeriodUid = "AssaDayPeriodUid";
    /// <summary>
    /// Returns 'TimePeriodUid'
    /// </summary>
    public static string TimePeriodUid = "TimePeriodUid";
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

using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the AssaAccessPointTypePDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class AssaAccessPointTypePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private AssaAccessPointTypePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new AssaAccessPointTypePDSA Entity
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
    /// Clones the current AssaAccessPointTypePDSA
    /// </summary>
    /// <returns>A cloned AssaAccessPointTypePDSA object</returns>
    public AssaAccessPointTypePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in AssaAccessPointTypePDSA
    /// </summary>
    /// <param name="entityToClone">The AssaAccessPointTypePDSA entity to clone</param>
    /// <returns>A cloned AssaAccessPointTypePDSA object</returns>
    public AssaAccessPointTypePDSA CloneEntity(AssaAccessPointTypePDSA entityToClone)
    {
      AssaAccessPointTypePDSA newEntity = new AssaAccessPointTypePDSA();

      newEntity.AssaAccessPointTypeUid = entityToClone.AssaAccessPointTypeUid;
      newEntity.Id = entityToClone.Id;
      newEntity.DisplayName = entityToClone.DisplayName;
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
      
      props.Add(PDSAProperty.Create(AssaAccessPointTypePDSAValidator.ColumnNames.AssaAccessPointTypeUid, GetResourceMessage("GCS_AssaAccessPointTypePDSA_AssaAccessPointTypeUid_Header", "Assa Access Point Type Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_AssaAccessPointTypePDSA_AssaAccessPointTypeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(AssaAccessPointTypePDSAValidator.ColumnNames.Id, GetResourceMessage("GCS_AssaAccessPointTypePDSA_Id_Header", "Id"), true, typeof(string), 255, GetResourceMessage("GCS_AssaAccessPointTypePDSA_Id_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AssaAccessPointTypePDSAValidator.ColumnNames.DisplayName, GetResourceMessage("GCS_AssaAccessPointTypePDSA_DisplayName_Header", "Display Name"), true, typeof(string), 255, GetResourceMessage("GCS_AssaAccessPointTypePDSA_DisplayName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AssaAccessPointTypePDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_AssaAccessPointTypePDSA_InsertName_Header", "Insert Name"), true, typeof(string), 50, GetResourceMessage("GCS_AssaAccessPointTypePDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AssaAccessPointTypePDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_AssaAccessPointTypePDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_AssaAccessPointTypePDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(AssaAccessPointTypePDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_AssaAccessPointTypePDSA_UpdateName_Header", "Update Name"), true, typeof(string), 50, GetResourceMessage("GCS_AssaAccessPointTypePDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AssaAccessPointTypePDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_AssaAccessPointTypePDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_AssaAccessPointTypePDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(AssaAccessPointTypePDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_AssaAccessPointTypePDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_AssaAccessPointTypePDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.AssaAccessPointTypeUid = Guid.NewGuid();
      Entity.Id = string.Empty;
      Entity.DisplayName = string.Empty;
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
      
      if(!Properties.GetByName(AssaAccessPointTypePDSAValidator.ColumnNames.AssaAccessPointTypeUid).SetAsNull)
        Properties.GetByName(AssaAccessPointTypePDSAValidator.ColumnNames.AssaAccessPointTypeUid).Value = Entity.AssaAccessPointTypeUid;
      if(!Properties.GetByName(AssaAccessPointTypePDSAValidator.ColumnNames.Id).SetAsNull)
        Properties.GetByName(AssaAccessPointTypePDSAValidator.ColumnNames.Id).Value = Entity.Id;
      if(!Properties.GetByName(AssaAccessPointTypePDSAValidator.ColumnNames.DisplayName).SetAsNull)
        Properties.GetByName(AssaAccessPointTypePDSAValidator.ColumnNames.DisplayName).Value = Entity.DisplayName;
      if(!Properties.GetByName(AssaAccessPointTypePDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(AssaAccessPointTypePDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(AssaAccessPointTypePDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(AssaAccessPointTypePDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(AssaAccessPointTypePDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(AssaAccessPointTypePDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(AssaAccessPointTypePDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(AssaAccessPointTypePDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(AssaAccessPointTypePDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(AssaAccessPointTypePDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(AssaAccessPointTypePDSAValidator.ColumnNames.AssaAccessPointTypeUid).IsNull == false)
        Entity.AssaAccessPointTypeUid = Properties.GetByName(AssaAccessPointTypePDSAValidator.ColumnNames.AssaAccessPointTypeUid).GetAsGuid();
      if(Properties.GetByName(AssaAccessPointTypePDSAValidator.ColumnNames.Id).IsNull == false)
        Entity.Id = Properties.GetByName(AssaAccessPointTypePDSAValidator.ColumnNames.Id).GetAsString();
      if(Properties.GetByName(AssaAccessPointTypePDSAValidator.ColumnNames.DisplayName).IsNull == false)
        Entity.DisplayName = Properties.GetByName(AssaAccessPointTypePDSAValidator.ColumnNames.DisplayName).GetAsString();
      if(Properties.GetByName(AssaAccessPointTypePDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(AssaAccessPointTypePDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(AssaAccessPointTypePDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(AssaAccessPointTypePDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(AssaAccessPointTypePDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(AssaAccessPointTypePDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(AssaAccessPointTypePDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(AssaAccessPointTypePDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(AssaAccessPointTypePDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(AssaAccessPointTypePDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the AssaAccessPointTypePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'AssaAccessPointTypeUid'
    /// </summary>
    public static string AssaAccessPointTypeUid = "AssaAccessPointTypeUid";
    /// <summary>
    /// Returns 'Id'
    /// </summary>
    public static string Id = "Id";
    /// <summary>
    /// Returns 'DisplayName'
    /// </summary>
    public static string DisplayName = "DisplayName";
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

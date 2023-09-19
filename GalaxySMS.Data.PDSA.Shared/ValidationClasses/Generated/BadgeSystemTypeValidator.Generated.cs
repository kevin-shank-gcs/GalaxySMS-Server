using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the BadgeSystemTypePDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class BadgeSystemTypePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private BadgeSystemTypePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new BadgeSystemTypePDSA Entity
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
    /// Clones the current BadgeSystemTypePDSA
    /// </summary>
    /// <returns>A cloned BadgeSystemTypePDSA object</returns>
    public BadgeSystemTypePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in BadgeSystemTypePDSA
    /// </summary>
    /// <param name="entityToClone">The BadgeSystemTypePDSA entity to clone</param>
    /// <returns>A cloned BadgeSystemTypePDSA object</returns>
    public BadgeSystemTypePDSA CloneEntity(BadgeSystemTypePDSA entityToClone)
    {
      BadgeSystemTypePDSA newEntity = new BadgeSystemTypePDSA();

      newEntity.BadgeSystemTypeUid = entityToClone.BadgeSystemTypeUid;
      newEntity.Name = entityToClone.Name;
      newEntity.TypeCode = entityToClone.TypeCode;
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
      
      props.Add(PDSAProperty.Create(BadgeSystemTypePDSAValidator.ColumnNames.BadgeSystemTypeUid, GetResourceMessage("GCS_BadgeSystemTypePDSA_BadgeSystemTypeUid_Header", "Badge System Type Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_BadgeSystemTypePDSA_BadgeSystemTypeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(BadgeSystemTypePDSAValidator.ColumnNames.Name, GetResourceMessage("GCS_BadgeSystemTypePDSA_Name_Header", "Name"), true, typeof(string), 65, GetResourceMessage("GCS_BadgeSystemTypePDSA_Name_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(BadgeSystemTypePDSAValidator.ColumnNames.TypeCode, GetResourceMessage("GCS_BadgeSystemTypePDSA_TypeCode_Header", "Type Code"), true, typeof(string), 65, GetResourceMessage("GCS_BadgeSystemTypePDSA_TypeCode_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(BadgeSystemTypePDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_BadgeSystemTypePDSA_InsertName_Header", "Insert Name"), true, typeof(string), 50, GetResourceMessage("GCS_BadgeSystemTypePDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(BadgeSystemTypePDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_BadgeSystemTypePDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_BadgeSystemTypePDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(BadgeSystemTypePDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_BadgeSystemTypePDSA_UpdateName_Header", "Update Name"), true, typeof(string), 50, GetResourceMessage("GCS_BadgeSystemTypePDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(BadgeSystemTypePDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_BadgeSystemTypePDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_BadgeSystemTypePDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(BadgeSystemTypePDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_BadgeSystemTypePDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_BadgeSystemTypePDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.BadgeSystemTypeUid = Guid.Empty;
      Entity.Name = string.Empty;
      Entity.TypeCode = string.Empty;
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
      
      if(!Properties.GetByName(BadgeSystemTypePDSAValidator.ColumnNames.BadgeSystemTypeUid).SetAsNull)
        Properties.GetByName(BadgeSystemTypePDSAValidator.ColumnNames.BadgeSystemTypeUid).Value = Entity.BadgeSystemTypeUid;
      if(!Properties.GetByName(BadgeSystemTypePDSAValidator.ColumnNames.Name).SetAsNull)
        Properties.GetByName(BadgeSystemTypePDSAValidator.ColumnNames.Name).Value = Entity.Name;
      if(!Properties.GetByName(BadgeSystemTypePDSAValidator.ColumnNames.TypeCode).SetAsNull)
        Properties.GetByName(BadgeSystemTypePDSAValidator.ColumnNames.TypeCode).Value = Entity.TypeCode;
      if(!Properties.GetByName(BadgeSystemTypePDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(BadgeSystemTypePDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(BadgeSystemTypePDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(BadgeSystemTypePDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(BadgeSystemTypePDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(BadgeSystemTypePDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(BadgeSystemTypePDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(BadgeSystemTypePDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(BadgeSystemTypePDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(BadgeSystemTypePDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(BadgeSystemTypePDSAValidator.ColumnNames.BadgeSystemTypeUid).IsNull == false)
        Entity.BadgeSystemTypeUid = Properties.GetByName(BadgeSystemTypePDSAValidator.ColumnNames.BadgeSystemTypeUid).GetAsGuid();
      if(Properties.GetByName(BadgeSystemTypePDSAValidator.ColumnNames.Name).IsNull == false)
        Entity.Name = Properties.GetByName(BadgeSystemTypePDSAValidator.ColumnNames.Name).GetAsString();
      if(Properties.GetByName(BadgeSystemTypePDSAValidator.ColumnNames.TypeCode).IsNull == false)
        Entity.TypeCode = Properties.GetByName(BadgeSystemTypePDSAValidator.ColumnNames.TypeCode).GetAsString();
      if(Properties.GetByName(BadgeSystemTypePDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(BadgeSystemTypePDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(BadgeSystemTypePDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(BadgeSystemTypePDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(BadgeSystemTypePDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(BadgeSystemTypePDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(BadgeSystemTypePDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(BadgeSystemTypePDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(BadgeSystemTypePDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(BadgeSystemTypePDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the BadgeSystemTypePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'BadgeSystemTypeUid'
    /// </summary>
    public static string BadgeSystemTypeUid = "BadgeSystemTypeUid";
    /// <summary>
    /// Returns 'Name'
    /// </summary>
    public static string Name = "Name";
    /// <summary>
    /// Returns 'TypeCode'
    /// </summary>
    public static string TypeCode = "TypeCode";
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

using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the gcsEnumValuePDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class gcsEnumValuePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private gcsEnumValuePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new gcsEnumValuePDSA Entity
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
    /// Clones the current gcsEnumValuePDSA
    /// </summary>
    /// <returns>A cloned gcsEnumValuePDSA object</returns>
    public gcsEnumValuePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in gcsEnumValuePDSA
    /// </summary>
    /// <param name="entityToClone">The gcsEnumValuePDSA entity to clone</param>
    /// <returns>A cloned gcsEnumValuePDSA object</returns>
    public gcsEnumValuePDSA CloneEntity(gcsEnumValuePDSA entityToClone)
    {
      gcsEnumValuePDSA newEntity = new gcsEnumValuePDSA();

      newEntity.EnumValueId = entityToClone.EnumValueId;
      newEntity.EnumNamespaceId = entityToClone.EnumNamespaceId;
      newEntity.Value = entityToClone.Value;
      newEntity.Description = entityToClone.Description;
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
      
      props.Add(PDSAProperty.Create(gcsEnumValuePDSAValidator.ColumnNames.EnumValueId, GetResourceMessage("GCS_gcsEnumValuePDSA_EnumValueId_Header", "Enum Value Id"), true, typeof(Guid), -1, GetResourceMessage("GCS_gcsEnumValuePDSA_EnumValueId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(gcsEnumValuePDSAValidator.ColumnNames.EnumNamespaceId, GetResourceMessage("GCS_gcsEnumValuePDSA_EnumNamespaceId_Header", "Enum Namespace Id"), true, typeof(Guid), -1, GetResourceMessage("GCS_gcsEnumValuePDSA_EnumNamespaceId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(gcsEnumValuePDSAValidator.ColumnNames.Value, GetResourceMessage("GCS_gcsEnumValuePDSA_Value_Header", "Value"), true, typeof(int), 10, GetResourceMessage("GCS_gcsEnumValuePDSA_Value_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(gcsEnumValuePDSAValidator.ColumnNames.Description, GetResourceMessage("GCS_gcsEnumValuePDSA_Description_Header", "Description"), true, typeof(string), 100, GetResourceMessage("GCS_gcsEnumValuePDSA_Description_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsEnumValuePDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_gcsEnumValuePDSA_InsertName_Header", "Insert Name"), true, typeof(string), 50, GetResourceMessage("GCS_gcsEnumValuePDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsEnumValuePDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_gcsEnumValuePDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_gcsEnumValuePDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(gcsEnumValuePDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_gcsEnumValuePDSA_UpdateName_Header", "Update Name"), true, typeof(string), 50, GetResourceMessage("GCS_gcsEnumValuePDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsEnumValuePDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_gcsEnumValuePDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_gcsEnumValuePDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(gcsEnumValuePDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_gcsEnumValuePDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_gcsEnumValuePDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.EnumValueId = Guid.NewGuid();
      Entity.EnumNamespaceId = Guid.NewGuid();
      Entity.Value = 0;
      Entity.Description = string.Empty;
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
      
      if(!Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.EnumValueId).SetAsNull)
        Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.EnumValueId).Value = Entity.EnumValueId;
      if(!Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.EnumNamespaceId).SetAsNull)
        Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.EnumNamespaceId).Value = Entity.EnumNamespaceId;
      if(!Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.Value).SetAsNull)
        Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.Value).Value = Entity.Value;
      if(!Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.Description).SetAsNull)
        Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.Description).Value = Entity.Description;
      if(!Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.EnumValueId).IsNull == false)
        Entity.EnumValueId = Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.EnumValueId).GetAsGuid();
      if(Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.EnumNamespaceId).IsNull == false)
        Entity.EnumNamespaceId = Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.EnumNamespaceId).GetAsGuid();
      if(Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.Value).IsNull == false)
        Entity.Value = Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.Value).GetAsInteger();
      if(Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.Description).IsNull == false)
        Entity.Description = Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.Description).GetAsString();
      if(Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(gcsEnumValuePDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the gcsEnumValuePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'EnumValueId'
    /// </summary>
    public static string EnumValueId = "EnumValueId";
    /// <summary>
    /// Returns 'EnumNamespaceId'
    /// </summary>
    public static string EnumNamespaceId = "EnumNamespaceId";
    /// <summary>
    /// Returns 'Value'
    /// </summary>
    public static string Value = "Value";
    /// <summary>
    /// Returns 'Description'
    /// </summary>
    public static string Description = "Description";
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

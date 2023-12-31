using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the ClusterInputOutputGroupPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class ClusterInputOutputGroupPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private ClusterInputOutputGroupPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new ClusterInputOutputGroupPDSA Entity
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
    /// Clones the current ClusterInputOutputGroupPDSA
    /// </summary>
    /// <returns>A cloned ClusterInputOutputGroupPDSA object</returns>
    public ClusterInputOutputGroupPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in ClusterInputOutputGroupPDSA
    /// </summary>
    /// <param name="entityToClone">The ClusterInputOutputGroupPDSA entity to clone</param>
    /// <returns>A cloned ClusterInputOutputGroupPDSA object</returns>
    public ClusterInputOutputGroupPDSA CloneEntity(ClusterInputOutputGroupPDSA entityToClone)
    {
      ClusterInputOutputGroupPDSA newEntity = new ClusterInputOutputGroupPDSA();

      newEntity.ClusterInputOutputGroupUid = entityToClone.ClusterInputOutputGroupUid;
      newEntity.ClusterUid = entityToClone.ClusterUid;
      newEntity.InputOutputGroupUid = entityToClone.InputOutputGroupUid;
      newEntity.Tag = entityToClone.Tag;
      newEntity.InsertName = entityToClone.InsertName;
      newEntity.InsertDate = entityToClone.InsertDate;
      newEntity.UpdateName = entityToClone.UpdateName;
      newEntity.UpdateDate = entityToClone.UpdateDate;
      newEntity.ConcurrencyValue = entityToClone.ConcurrencyValue;
      newEntity.DisplayResourceKey = entityToClone.DisplayResourceKey;
      newEntity.DescriptionResourceKey = entityToClone.DescriptionResourceKey;
      newEntity.Display = entityToClone.Display;
      newEntity.Description = entityToClone.Description;
      newEntity.CultureName = entityToClone.CultureName;

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
      
      props.Add(PDSAProperty.Create(ClusterInputOutputGroupPDSAValidator.ColumnNames.ClusterInputOutputGroupUid, GetResourceMessage("GCS_ClusterInputOutputGroupPDSA_ClusterInputOutputGroupUid_Header", "Cluster Input Output Group Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_ClusterInputOutputGroupPDSA_ClusterInputOutputGroupUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(ClusterInputOutputGroupPDSAValidator.ColumnNames.ClusterUid, GetResourceMessage("GCS_ClusterInputOutputGroupPDSA_ClusterUid_Header", "Cluster Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_ClusterInputOutputGroupPDSA_ClusterUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(ClusterInputOutputGroupPDSAValidator.ColumnNames.InputOutputGroupUid, GetResourceMessage("GCS_ClusterInputOutputGroupPDSA_InputOutputGroupUid_Header", "Input Output Group Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_ClusterInputOutputGroupPDSA_InputOutputGroupUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(ClusterInputOutputGroupPDSAValidator.ColumnNames.Tag, GetResourceMessage("GCS_ClusterInputOutputGroupPDSA_Tag_Header", "Tag"), true, typeof(string), 65, GetResourceMessage("GCS_ClusterInputOutputGroupPDSA_Tag_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(ClusterInputOutputGroupPDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_ClusterInputOutputGroupPDSA_InsertName_Header", "Insert Name"), true, typeof(string), 100, GetResourceMessage("GCS_ClusterInputOutputGroupPDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(ClusterInputOutputGroupPDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_ClusterInputOutputGroupPDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_ClusterInputOutputGroupPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(ClusterInputOutputGroupPDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_ClusterInputOutputGroupPDSA_UpdateName_Header", "Update Name"), true, typeof(string), 100, GetResourceMessage("GCS_ClusterInputOutputGroupPDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(ClusterInputOutputGroupPDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_ClusterInputOutputGroupPDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_ClusterInputOutputGroupPDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(ClusterInputOutputGroupPDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_ClusterInputOutputGroupPDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_ClusterInputOutputGroupPDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(ClusterInputOutputGroupPDSAValidator.ColumnNames.DisplayResourceKey, GetResourceMessage("GCS_ClusterInputOutputGroupPDSA_DisplayResourceKey_Header", "Display Resource Key"), false, typeof(Guid), -1, GetResourceMessage("GCS_ClusterInputOutputGroupPDSA_DisplayResourceKey_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(ClusterInputOutputGroupPDSAValidator.ColumnNames.DescriptionResourceKey, GetResourceMessage("GCS_ClusterInputOutputGroupPDSA_DescriptionResourceKey_Header", "Description Resource Key"), false, typeof(Guid), -1, GetResourceMessage("GCS_ClusterInputOutputGroupPDSA_DescriptionResourceKey_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(ClusterInputOutputGroupPDSAValidator.ColumnNames.Display, GetResourceMessage("GCS_ClusterInputOutputGroupPDSA_Display_Header", "Display"), true, typeof(string), 65, GetResourceMessage("GCS_ClusterInputOutputGroupPDSA_Display_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(ClusterInputOutputGroupPDSAValidator.ColumnNames.Description, GetResourceMessage("GCS_ClusterInputOutputGroupPDSA_Description_Header", "Description"), true, typeof(string), 1000, GetResourceMessage("GCS_ClusterInputOutputGroupPDSA_Description_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(ClusterInputOutputGroupPDSAValidator.ColumnNames.CultureName, GetResourceMessage("GCS_ClusterInputOutputGroupPDSA_CultureName_Header", "Culture Name"), false, typeof(string), 2147483647, GetResourceMessage("GCS_ClusterInputOutputGroupPDSA_CultureName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.ClusterInputOutputGroupUid = Guid.NewGuid();
      Entity.ClusterUid = Guid.NewGuid();
      Entity.InputOutputGroupUid = Guid.NewGuid();
      Entity.Tag = string.Empty;
      Entity.InsertName = string.Empty;
      Entity.InsertDate = DateTimeOffset.Now;
      Entity.UpdateName = string.Empty;
      Entity.UpdateDate = DateTimeOffset.Now;
      Entity.ConcurrencyValue = 0;
      Entity.DisplayResourceKey = Guid.NewGuid();
      Entity.DescriptionResourceKey = Guid.NewGuid();
      Entity.Display = string.Empty;
      Entity.Description = string.Empty;
      Entity.CultureName = string.Empty;

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
      
      if(!Properties.GetByName(ClusterInputOutputGroupPDSAValidator.ColumnNames.ClusterInputOutputGroupUid).SetAsNull)
        Properties.GetByName(ClusterInputOutputGroupPDSAValidator.ColumnNames.ClusterInputOutputGroupUid).Value = Entity.ClusterInputOutputGroupUid;
      if(!Properties.GetByName(ClusterInputOutputGroupPDSAValidator.ColumnNames.ClusterUid).SetAsNull)
        Properties.GetByName(ClusterInputOutputGroupPDSAValidator.ColumnNames.ClusterUid).Value = Entity.ClusterUid;
      if(!Properties.GetByName(ClusterInputOutputGroupPDSAValidator.ColumnNames.InputOutputGroupUid).SetAsNull)
        Properties.GetByName(ClusterInputOutputGroupPDSAValidator.ColumnNames.InputOutputGroupUid).Value = Entity.InputOutputGroupUid;
      if(!Properties.GetByName(ClusterInputOutputGroupPDSAValidator.ColumnNames.Tag).SetAsNull)
        Properties.GetByName(ClusterInputOutputGroupPDSAValidator.ColumnNames.Tag).Value = Entity.Tag;
      if(!Properties.GetByName(ClusterInputOutputGroupPDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(ClusterInputOutputGroupPDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(ClusterInputOutputGroupPDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(ClusterInputOutputGroupPDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(ClusterInputOutputGroupPDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(ClusterInputOutputGroupPDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(ClusterInputOutputGroupPDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(ClusterInputOutputGroupPDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(ClusterInputOutputGroupPDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(ClusterInputOutputGroupPDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
      if(!Properties.GetByName(ClusterInputOutputGroupPDSAValidator.ColumnNames.DisplayResourceKey).SetAsNull)
        Properties.GetByName(ClusterInputOutputGroupPDSAValidator.ColumnNames.DisplayResourceKey).Value = Entity.DisplayResourceKey;
      if(!Properties.GetByName(ClusterInputOutputGroupPDSAValidator.ColumnNames.DescriptionResourceKey).SetAsNull)
        Properties.GetByName(ClusterInputOutputGroupPDSAValidator.ColumnNames.DescriptionResourceKey).Value = Entity.DescriptionResourceKey;
      if(!Properties.GetByName(ClusterInputOutputGroupPDSAValidator.ColumnNames.Display).SetAsNull)
        Properties.GetByName(ClusterInputOutputGroupPDSAValidator.ColumnNames.Display).Value = Entity.Display;
      if(!Properties.GetByName(ClusterInputOutputGroupPDSAValidator.ColumnNames.Description).SetAsNull)
        Properties.GetByName(ClusterInputOutputGroupPDSAValidator.ColumnNames.Description).Value = Entity.Description;
      if(!Properties.GetByName(ClusterInputOutputGroupPDSAValidator.ColumnNames.CultureName).SetAsNull)
        Properties.GetByName(ClusterInputOutputGroupPDSAValidator.ColumnNames.CultureName).Value = Entity.CultureName;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(ClusterInputOutputGroupPDSAValidator.ColumnNames.ClusterInputOutputGroupUid).IsNull == false)
        Entity.ClusterInputOutputGroupUid = Properties.GetByName(ClusterInputOutputGroupPDSAValidator.ColumnNames.ClusterInputOutputGroupUid).GetAsGuid();
      if(Properties.GetByName(ClusterInputOutputGroupPDSAValidator.ColumnNames.ClusterUid).IsNull == false)
        Entity.ClusterUid = Properties.GetByName(ClusterInputOutputGroupPDSAValidator.ColumnNames.ClusterUid).GetAsGuid();
      if(Properties.GetByName(ClusterInputOutputGroupPDSAValidator.ColumnNames.InputOutputGroupUid).IsNull == false)
        Entity.InputOutputGroupUid = Properties.GetByName(ClusterInputOutputGroupPDSAValidator.ColumnNames.InputOutputGroupUid).GetAsGuid();
      if(Properties.GetByName(ClusterInputOutputGroupPDSAValidator.ColumnNames.Tag).IsNull == false)
        Entity.Tag = Properties.GetByName(ClusterInputOutputGroupPDSAValidator.ColumnNames.Tag).GetAsString();
      if(Properties.GetByName(ClusterInputOutputGroupPDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(ClusterInputOutputGroupPDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(ClusterInputOutputGroupPDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(ClusterInputOutputGroupPDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(ClusterInputOutputGroupPDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(ClusterInputOutputGroupPDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(ClusterInputOutputGroupPDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(ClusterInputOutputGroupPDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(ClusterInputOutputGroupPDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(ClusterInputOutputGroupPDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
      if(Properties.GetByName(ClusterInputOutputGroupPDSAValidator.ColumnNames.DisplayResourceKey).IsNull == false)
        Entity.DisplayResourceKey = Properties.GetByName(ClusterInputOutputGroupPDSAValidator.ColumnNames.DisplayResourceKey).GetAsGuid();
      if(Properties.GetByName(ClusterInputOutputGroupPDSAValidator.ColumnNames.DescriptionResourceKey).IsNull == false)
        Entity.DescriptionResourceKey = Properties.GetByName(ClusterInputOutputGroupPDSAValidator.ColumnNames.DescriptionResourceKey).GetAsGuid();
      if(Properties.GetByName(ClusterInputOutputGroupPDSAValidator.ColumnNames.Display).IsNull == false)
        Entity.Display = Properties.GetByName(ClusterInputOutputGroupPDSAValidator.ColumnNames.Display).GetAsString();
      if(Properties.GetByName(ClusterInputOutputGroupPDSAValidator.ColumnNames.Description).IsNull == false)
        Entity.Description = Properties.GetByName(ClusterInputOutputGroupPDSAValidator.ColumnNames.Description).GetAsString();
      if(Properties.GetByName(ClusterInputOutputGroupPDSAValidator.ColumnNames.CultureName).IsNull == false)
        Entity.CultureName = Properties.GetByName(ClusterInputOutputGroupPDSAValidator.ColumnNames.CultureName).GetAsString();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the ClusterInputOutputGroupPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'ClusterInputOutputGroupUid'
    /// </summary>
    public static string ClusterInputOutputGroupUid = "ClusterInputOutputGroupUid";
    /// <summary>
    /// Returns 'ClusterUid'
    /// </summary>
    public static string ClusterUid = "ClusterUid";
    /// <summary>
    /// Returns 'InputOutputGroupUid'
    /// </summary>
    public static string InputOutputGroupUid = "InputOutputGroupUid";
    /// <summary>
    /// Returns 'Tag'
    /// </summary>
    public static string Tag = "Tag";
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
    /// <summary>
    /// Returns 'DisplayResourceKey'
    /// </summary>
    public static string DisplayResourceKey = "DisplayResourceKey";
    /// <summary>
    /// Returns 'DescriptionResourceKey'
    /// </summary>
    public static string DescriptionResourceKey = "DescriptionResourceKey";
    /// <summary>
    /// Returns 'Display'
    /// </summary>
    public static string Display = "Display";
    /// <summary>
    /// Returns 'Description'
    /// </summary>
    public static string Description = "Description";
    /// <summary>
    /// Returns 'CultureName'
    /// </summary>
    public static string CultureName = "CultureName";
    }
    #endregion
  }
}

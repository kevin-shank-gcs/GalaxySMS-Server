using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the GalaxyOutputDeviceInputSourceInputOutputGroupPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class GalaxyOutputDeviceInputSourceInputOutputGroupPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private GalaxyOutputDeviceInputSourceInputOutputGroupPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new GalaxyOutputDeviceInputSourceInputOutputGroupPDSA Entity
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
    /// Clones the current GalaxyOutputDeviceInputSourceInputOutputGroupPDSA
    /// </summary>
    /// <returns>A cloned GalaxyOutputDeviceInputSourceInputOutputGroupPDSA object</returns>
    public GalaxyOutputDeviceInputSourceInputOutputGroupPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in GalaxyOutputDeviceInputSourceInputOutputGroupPDSA
    /// </summary>
    /// <param name="entityToClone">The GalaxyOutputDeviceInputSourceInputOutputGroupPDSA entity to clone</param>
    /// <returns>A cloned GalaxyOutputDeviceInputSourceInputOutputGroupPDSA object</returns>
    public GalaxyOutputDeviceInputSourceInputOutputGroupPDSA CloneEntity(GalaxyOutputDeviceInputSourceInputOutputGroupPDSA entityToClone)
    {
      GalaxyOutputDeviceInputSourceInputOutputGroupPDSA newEntity = new GalaxyOutputDeviceInputSourceInputOutputGroupPDSA();

      newEntity.GalaxyOutputDeviceInputSourceInputOutputGroupUid = entityToClone.GalaxyOutputDeviceInputSourceInputOutputGroupUid;
      newEntity.GalaxyOutputDeviceInputSourceUid = entityToClone.GalaxyOutputDeviceInputSourceUid;
      newEntity.InputOutputGroupUid = entityToClone.InputOutputGroupUid;
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
      
      props.Add(PDSAProperty.Create(GalaxyOutputDeviceInputSourceInputOutputGroupPDSAValidator.ColumnNames.GalaxyOutputDeviceInputSourceInputOutputGroupUid, GetResourceMessage("GCS_GalaxyOutputDeviceInputSourceInputOutputGroupPDSA_GalaxyOutputDeviceInputSourceInputOutputGroupUid_Header", "Galaxy Output Device Input Source Input Output Group Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_GalaxyOutputDeviceInputSourceInputOutputGroupPDSA_GalaxyOutputDeviceInputSourceInputOutputGroupUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyOutputDeviceInputSourceInputOutputGroupPDSAValidator.ColumnNames.GalaxyOutputDeviceInputSourceUid, GetResourceMessage("GCS_GalaxyOutputDeviceInputSourceInputOutputGroupPDSA_GalaxyOutputDeviceInputSourceUid_Header", "Galaxy Output Device Input Source Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_GalaxyOutputDeviceInputSourceInputOutputGroupPDSA_GalaxyOutputDeviceInputSourceUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyOutputDeviceInputSourceInputOutputGroupPDSAValidator.ColumnNames.InputOutputGroupUid, GetResourceMessage("GCS_GalaxyOutputDeviceInputSourceInputOutputGroupPDSA_InputOutputGroupUid_Header", "Input Output Group Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_GalaxyOutputDeviceInputSourceInputOutputGroupPDSA_InputOutputGroupUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyOutputDeviceInputSourceInputOutputGroupPDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_GalaxyOutputDeviceInputSourceInputOutputGroupPDSA_InsertName_Header", "Insert Name"), true, typeof(string), 100, GetResourceMessage("GCS_GalaxyOutputDeviceInputSourceInputOutputGroupPDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyOutputDeviceInputSourceInputOutputGroupPDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_GalaxyOutputDeviceInputSourceInputOutputGroupPDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_GalaxyOutputDeviceInputSourceInputOutputGroupPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyOutputDeviceInputSourceInputOutputGroupPDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_GalaxyOutputDeviceInputSourceInputOutputGroupPDSA_UpdateName_Header", "Update Name"), true, typeof(string), 100, GetResourceMessage("GCS_GalaxyOutputDeviceInputSourceInputOutputGroupPDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyOutputDeviceInputSourceInputOutputGroupPDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_GalaxyOutputDeviceInputSourceInputOutputGroupPDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_GalaxyOutputDeviceInputSourceInputOutputGroupPDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyOutputDeviceInputSourceInputOutputGroupPDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_GalaxyOutputDeviceInputSourceInputOutputGroupPDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_GalaxyOutputDeviceInputSourceInputOutputGroupPDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.GalaxyOutputDeviceInputSourceInputOutputGroupUid = Guid.Empty;
      Entity.GalaxyOutputDeviceInputSourceUid = Guid.Empty;
      Entity.InputOutputGroupUid = Guid.Empty;
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
      
      if(!Properties.GetByName(GalaxyOutputDeviceInputSourceInputOutputGroupPDSAValidator.ColumnNames.GalaxyOutputDeviceInputSourceInputOutputGroupUid).SetAsNull)
        Properties.GetByName(GalaxyOutputDeviceInputSourceInputOutputGroupPDSAValidator.ColumnNames.GalaxyOutputDeviceInputSourceInputOutputGroupUid).Value = Entity.GalaxyOutputDeviceInputSourceInputOutputGroupUid;
      if(!Properties.GetByName(GalaxyOutputDeviceInputSourceInputOutputGroupPDSAValidator.ColumnNames.GalaxyOutputDeviceInputSourceUid).SetAsNull)
        Properties.GetByName(GalaxyOutputDeviceInputSourceInputOutputGroupPDSAValidator.ColumnNames.GalaxyOutputDeviceInputSourceUid).Value = Entity.GalaxyOutputDeviceInputSourceUid;
      if(!Properties.GetByName(GalaxyOutputDeviceInputSourceInputOutputGroupPDSAValidator.ColumnNames.InputOutputGroupUid).SetAsNull)
        Properties.GetByName(GalaxyOutputDeviceInputSourceInputOutputGroupPDSAValidator.ColumnNames.InputOutputGroupUid).Value = Entity.InputOutputGroupUid;
      if(!Properties.GetByName(GalaxyOutputDeviceInputSourceInputOutputGroupPDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(GalaxyOutputDeviceInputSourceInputOutputGroupPDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(GalaxyOutputDeviceInputSourceInputOutputGroupPDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(GalaxyOutputDeviceInputSourceInputOutputGroupPDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(GalaxyOutputDeviceInputSourceInputOutputGroupPDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(GalaxyOutputDeviceInputSourceInputOutputGroupPDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(GalaxyOutputDeviceInputSourceInputOutputGroupPDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(GalaxyOutputDeviceInputSourceInputOutputGroupPDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(GalaxyOutputDeviceInputSourceInputOutputGroupPDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(GalaxyOutputDeviceInputSourceInputOutputGroupPDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(GalaxyOutputDeviceInputSourceInputOutputGroupPDSAValidator.ColumnNames.GalaxyOutputDeviceInputSourceInputOutputGroupUid).IsNull == false)
        Entity.GalaxyOutputDeviceInputSourceInputOutputGroupUid = Properties.GetByName(GalaxyOutputDeviceInputSourceInputOutputGroupPDSAValidator.ColumnNames.GalaxyOutputDeviceInputSourceInputOutputGroupUid).GetAsGuid();
      if(Properties.GetByName(GalaxyOutputDeviceInputSourceInputOutputGroupPDSAValidator.ColumnNames.GalaxyOutputDeviceInputSourceUid).IsNull == false)
        Entity.GalaxyOutputDeviceInputSourceUid = Properties.GetByName(GalaxyOutputDeviceInputSourceInputOutputGroupPDSAValidator.ColumnNames.GalaxyOutputDeviceInputSourceUid).GetAsGuid();
      if(Properties.GetByName(GalaxyOutputDeviceInputSourceInputOutputGroupPDSAValidator.ColumnNames.InputOutputGroupUid).IsNull == false)
        Entity.InputOutputGroupUid = Properties.GetByName(GalaxyOutputDeviceInputSourceInputOutputGroupPDSAValidator.ColumnNames.InputOutputGroupUid).GetAsGuid();
      if(Properties.GetByName(GalaxyOutputDeviceInputSourceInputOutputGroupPDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(GalaxyOutputDeviceInputSourceInputOutputGroupPDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(GalaxyOutputDeviceInputSourceInputOutputGroupPDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(GalaxyOutputDeviceInputSourceInputOutputGroupPDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(GalaxyOutputDeviceInputSourceInputOutputGroupPDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(GalaxyOutputDeviceInputSourceInputOutputGroupPDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(GalaxyOutputDeviceInputSourceInputOutputGroupPDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(GalaxyOutputDeviceInputSourceInputOutputGroupPDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(GalaxyOutputDeviceInputSourceInputOutputGroupPDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(GalaxyOutputDeviceInputSourceInputOutputGroupPDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the GalaxyOutputDeviceInputSourceInputOutputGroupPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'GalaxyOutputDeviceInputSourceInputOutputGroupUid'
    /// </summary>
    public static string GalaxyOutputDeviceInputSourceInputOutputGroupUid = "GalaxyOutputDeviceInputSourceInputOutputGroupUid";
    /// <summary>
    /// Returns 'GalaxyOutputDeviceInputSourceUid'
    /// </summary>
    public static string GalaxyOutputDeviceInputSourceUid = "GalaxyOutputDeviceInputSourceUid";
    /// <summary>
    /// Returns 'InputOutputGroupUid'
    /// </summary>
    public static string InputOutputGroupUid = "InputOutputGroupUid";
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

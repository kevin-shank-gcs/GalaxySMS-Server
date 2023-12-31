using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the GalaxyPanelModelInterfaceBoardTypePDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class GalaxyPanelModelInterfaceBoardTypePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private GalaxyPanelModelInterfaceBoardTypePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new GalaxyPanelModelInterfaceBoardTypePDSA Entity
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
    /// Clones the current GalaxyPanelModelInterfaceBoardTypePDSA
    /// </summary>
    /// <returns>A cloned GalaxyPanelModelInterfaceBoardTypePDSA object</returns>
    public GalaxyPanelModelInterfaceBoardTypePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in GalaxyPanelModelInterfaceBoardTypePDSA
    /// </summary>
    /// <param name="entityToClone">The GalaxyPanelModelInterfaceBoardTypePDSA entity to clone</param>
    /// <returns>A cloned GalaxyPanelModelInterfaceBoardTypePDSA object</returns>
    public GalaxyPanelModelInterfaceBoardTypePDSA CloneEntity(GalaxyPanelModelInterfaceBoardTypePDSA entityToClone)
    {
      GalaxyPanelModelInterfaceBoardTypePDSA newEntity = new GalaxyPanelModelInterfaceBoardTypePDSA();

      newEntity.GalaxyPanelModelInterfaceBoardTypeUid = entityToClone.GalaxyPanelModelInterfaceBoardTypeUid;
      newEntity.GalaxyPanelModelUid = entityToClone.GalaxyPanelModelUid;
      newEntity.InterfaceBoardTypeUid = entityToClone.InterfaceBoardTypeUid;
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
      
      props.Add(PDSAProperty.Create(GalaxyPanelModelInterfaceBoardTypePDSAValidator.ColumnNames.GalaxyPanelModelInterfaceBoardTypeUid, GetResourceMessage("GCS_GalaxyPanelModelInterfaceBoardTypePDSA_GalaxyPanelModelInterfaceBoardTypeUid_Header", "Galaxy Panel Model Interface Board Type Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_GalaxyPanelModelInterfaceBoardTypePDSA_GalaxyPanelModelInterfaceBoardTypeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelModelInterfaceBoardTypePDSAValidator.ColumnNames.GalaxyPanelModelUid, GetResourceMessage("GCS_GalaxyPanelModelInterfaceBoardTypePDSA_GalaxyPanelModelUid_Header", "Galaxy Panel Model Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_GalaxyPanelModelInterfaceBoardTypePDSA_GalaxyPanelModelUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelModelInterfaceBoardTypePDSAValidator.ColumnNames.InterfaceBoardTypeUid, GetResourceMessage("GCS_GalaxyPanelModelInterfaceBoardTypePDSA_InterfaceBoardTypeUid_Header", "Interface Board Type Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_GalaxyPanelModelInterfaceBoardTypePDSA_InterfaceBoardTypeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.NewGuid(), @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelModelInterfaceBoardTypePDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_GalaxyPanelModelInterfaceBoardTypePDSA_InsertName_Header", "Insert Name"), true, typeof(string), 50, GetResourceMessage("GCS_GalaxyPanelModelInterfaceBoardTypePDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelModelInterfaceBoardTypePDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_GalaxyPanelModelInterfaceBoardTypePDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_GalaxyPanelModelInterfaceBoardTypePDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelModelInterfaceBoardTypePDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_GalaxyPanelModelInterfaceBoardTypePDSA_UpdateName_Header", "Update Name"), true, typeof(string), 50, GetResourceMessage("GCS_GalaxyPanelModelInterfaceBoardTypePDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelModelInterfaceBoardTypePDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_GalaxyPanelModelInterfaceBoardTypePDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_GalaxyPanelModelInterfaceBoardTypePDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelModelInterfaceBoardTypePDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_GalaxyPanelModelInterfaceBoardTypePDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_GalaxyPanelModelInterfaceBoardTypePDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.GalaxyPanelModelInterfaceBoardTypeUid = Guid.NewGuid();
      Entity.GalaxyPanelModelUid = Guid.NewGuid();
      Entity.InterfaceBoardTypeUid = Guid.NewGuid();
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
      
      if(!Properties.GetByName(GalaxyPanelModelInterfaceBoardTypePDSAValidator.ColumnNames.GalaxyPanelModelInterfaceBoardTypeUid).SetAsNull)
        Properties.GetByName(GalaxyPanelModelInterfaceBoardTypePDSAValidator.ColumnNames.GalaxyPanelModelInterfaceBoardTypeUid).Value = Entity.GalaxyPanelModelInterfaceBoardTypeUid;
      if(!Properties.GetByName(GalaxyPanelModelInterfaceBoardTypePDSAValidator.ColumnNames.GalaxyPanelModelUid).SetAsNull)
        Properties.GetByName(GalaxyPanelModelInterfaceBoardTypePDSAValidator.ColumnNames.GalaxyPanelModelUid).Value = Entity.GalaxyPanelModelUid;
      if(!Properties.GetByName(GalaxyPanelModelInterfaceBoardTypePDSAValidator.ColumnNames.InterfaceBoardTypeUid).SetAsNull)
        Properties.GetByName(GalaxyPanelModelInterfaceBoardTypePDSAValidator.ColumnNames.InterfaceBoardTypeUid).Value = Entity.InterfaceBoardTypeUid;
      if(!Properties.GetByName(GalaxyPanelModelInterfaceBoardTypePDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(GalaxyPanelModelInterfaceBoardTypePDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(GalaxyPanelModelInterfaceBoardTypePDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(GalaxyPanelModelInterfaceBoardTypePDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(GalaxyPanelModelInterfaceBoardTypePDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(GalaxyPanelModelInterfaceBoardTypePDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(GalaxyPanelModelInterfaceBoardTypePDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(GalaxyPanelModelInterfaceBoardTypePDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(GalaxyPanelModelInterfaceBoardTypePDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(GalaxyPanelModelInterfaceBoardTypePDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(GalaxyPanelModelInterfaceBoardTypePDSAValidator.ColumnNames.GalaxyPanelModelInterfaceBoardTypeUid).IsNull == false)
        Entity.GalaxyPanelModelInterfaceBoardTypeUid = Properties.GetByName(GalaxyPanelModelInterfaceBoardTypePDSAValidator.ColumnNames.GalaxyPanelModelInterfaceBoardTypeUid).GetAsGuid();
      if(Properties.GetByName(GalaxyPanelModelInterfaceBoardTypePDSAValidator.ColumnNames.GalaxyPanelModelUid).IsNull == false)
        Entity.GalaxyPanelModelUid = Properties.GetByName(GalaxyPanelModelInterfaceBoardTypePDSAValidator.ColumnNames.GalaxyPanelModelUid).GetAsGuid();
      if(Properties.GetByName(GalaxyPanelModelInterfaceBoardTypePDSAValidator.ColumnNames.InterfaceBoardTypeUid).IsNull == false)
        Entity.InterfaceBoardTypeUid = Properties.GetByName(GalaxyPanelModelInterfaceBoardTypePDSAValidator.ColumnNames.InterfaceBoardTypeUid).GetAsGuid();
      if(Properties.GetByName(GalaxyPanelModelInterfaceBoardTypePDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(GalaxyPanelModelInterfaceBoardTypePDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(GalaxyPanelModelInterfaceBoardTypePDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(GalaxyPanelModelInterfaceBoardTypePDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(GalaxyPanelModelInterfaceBoardTypePDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(GalaxyPanelModelInterfaceBoardTypePDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(GalaxyPanelModelInterfaceBoardTypePDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(GalaxyPanelModelInterfaceBoardTypePDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(GalaxyPanelModelInterfaceBoardTypePDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(GalaxyPanelModelInterfaceBoardTypePDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the GalaxyPanelModelInterfaceBoardTypePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'GalaxyPanelModelInterfaceBoardTypeUid'
    /// </summary>
    public static string GalaxyPanelModelInterfaceBoardTypeUid = "GalaxyPanelModelInterfaceBoardTypeUid";
    /// <summary>
    /// Returns 'GalaxyPanelModelUid'
    /// </summary>
    public static string GalaxyPanelModelUid = "GalaxyPanelModelUid";
    /// <summary>
    /// Returns 'InterfaceBoardTypeUid'
    /// </summary>
    public static string InterfaceBoardTypeUid = "InterfaceBoardTypeUid";
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

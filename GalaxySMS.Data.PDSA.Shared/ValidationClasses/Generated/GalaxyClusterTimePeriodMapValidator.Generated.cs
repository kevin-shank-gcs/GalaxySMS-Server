using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the GalaxyClusterTimePeriodMapPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class GalaxyClusterTimePeriodMapPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private GalaxyClusterTimePeriodMapPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new GalaxyClusterTimePeriodMapPDSA Entity
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
    /// Clones the current GalaxyClusterTimePeriodMapPDSA
    /// </summary>
    /// <returns>A cloned GalaxyClusterTimePeriodMapPDSA object</returns>
    public GalaxyClusterTimePeriodMapPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in GalaxyClusterTimePeriodMapPDSA
    /// </summary>
    /// <param name="entityToClone">The GalaxyClusterTimePeriodMapPDSA entity to clone</param>
    /// <returns>A cloned GalaxyClusterTimePeriodMapPDSA object</returns>
    public GalaxyClusterTimePeriodMapPDSA CloneEntity(GalaxyClusterTimePeriodMapPDSA entityToClone)
    {
      GalaxyClusterTimePeriodMapPDSA newEntity = new GalaxyClusterTimePeriodMapPDSA();

      newEntity.GalaxyClusterTimePeriodMapUid = entityToClone.GalaxyClusterTimePeriodMapUid;
      newEntity.TimePeriodUid = entityToClone.TimePeriodUid;
      newEntity.ClusterUid = entityToClone.ClusterUid;
      newEntity.PanelPeriodNumber = entityToClone.PanelPeriodNumber;
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
      
      props.Add(PDSAProperty.Create(GalaxyClusterTimePeriodMapPDSAValidator.ColumnNames.GalaxyClusterTimePeriodMapUid, GetResourceMessage("GCS_GalaxyClusterTimePeriodMapPDSA_GalaxyClusterTimePeriodMapUid_Header", "Galaxy Cluster Time Period Map Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_GalaxyClusterTimePeriodMapPDSA_GalaxyClusterTimePeriodMapUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyClusterTimePeriodMapPDSAValidator.ColumnNames.TimePeriodUid, GetResourceMessage("GCS_GalaxyClusterTimePeriodMapPDSA_TimePeriodUid_Header", "Time Period Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_GalaxyClusterTimePeriodMapPDSA_TimePeriodUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyClusterTimePeriodMapPDSAValidator.ColumnNames.ClusterUid, GetResourceMessage("GCS_GalaxyClusterTimePeriodMapPDSA_ClusterUid_Header", "Cluster Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_GalaxyClusterTimePeriodMapPDSA_ClusterUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyClusterTimePeriodMapPDSAValidator.ColumnNames.PanelPeriodNumber, GetResourceMessage("GCS_GalaxyClusterTimePeriodMapPDSA_PanelPeriodNumber_Header", "Panel Period Number"), true, typeof(int), 10, GetResourceMessage("GCS_GalaxyClusterTimePeriodMapPDSA_PanelPeriodNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyClusterTimePeriodMapPDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_GalaxyClusterTimePeriodMapPDSA_InsertName_Header", "Insert Name"), true, typeof(string), 50, GetResourceMessage("GCS_GalaxyClusterTimePeriodMapPDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyClusterTimePeriodMapPDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_GalaxyClusterTimePeriodMapPDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_GalaxyClusterTimePeriodMapPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyClusterTimePeriodMapPDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_GalaxyClusterTimePeriodMapPDSA_UpdateName_Header", "Update Name"), true, typeof(string), 50, GetResourceMessage("GCS_GalaxyClusterTimePeriodMapPDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyClusterTimePeriodMapPDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_GalaxyClusterTimePeriodMapPDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_GalaxyClusterTimePeriodMapPDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyClusterTimePeriodMapPDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_GalaxyClusterTimePeriodMapPDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_GalaxyClusterTimePeriodMapPDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.GalaxyClusterTimePeriodMapUid = Guid.Empty;
      Entity.TimePeriodUid = Guid.Empty;
      Entity.ClusterUid = Guid.Empty;
      Entity.PanelPeriodNumber = 0;
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
      
      if(!Properties.GetByName(GalaxyClusterTimePeriodMapPDSAValidator.ColumnNames.GalaxyClusterTimePeriodMapUid).SetAsNull)
        Properties.GetByName(GalaxyClusterTimePeriodMapPDSAValidator.ColumnNames.GalaxyClusterTimePeriodMapUid).Value = Entity.GalaxyClusterTimePeriodMapUid;
      if(!Properties.GetByName(GalaxyClusterTimePeriodMapPDSAValidator.ColumnNames.TimePeriodUid).SetAsNull)
        Properties.GetByName(GalaxyClusterTimePeriodMapPDSAValidator.ColumnNames.TimePeriodUid).Value = Entity.TimePeriodUid;
      if(!Properties.GetByName(GalaxyClusterTimePeriodMapPDSAValidator.ColumnNames.ClusterUid).SetAsNull)
        Properties.GetByName(GalaxyClusterTimePeriodMapPDSAValidator.ColumnNames.ClusterUid).Value = Entity.ClusterUid;
      if(!Properties.GetByName(GalaxyClusterTimePeriodMapPDSAValidator.ColumnNames.PanelPeriodNumber).SetAsNull)
        Properties.GetByName(GalaxyClusterTimePeriodMapPDSAValidator.ColumnNames.PanelPeriodNumber).Value = Entity.PanelPeriodNumber;
      if(!Properties.GetByName(GalaxyClusterTimePeriodMapPDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(GalaxyClusterTimePeriodMapPDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(GalaxyClusterTimePeriodMapPDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(GalaxyClusterTimePeriodMapPDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(GalaxyClusterTimePeriodMapPDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(GalaxyClusterTimePeriodMapPDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(GalaxyClusterTimePeriodMapPDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(GalaxyClusterTimePeriodMapPDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(GalaxyClusterTimePeriodMapPDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(GalaxyClusterTimePeriodMapPDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(GalaxyClusterTimePeriodMapPDSAValidator.ColumnNames.GalaxyClusterTimePeriodMapUid).IsNull == false)
        Entity.GalaxyClusterTimePeriodMapUid = Properties.GetByName(GalaxyClusterTimePeriodMapPDSAValidator.ColumnNames.GalaxyClusterTimePeriodMapUid).GetAsGuid();
      if(Properties.GetByName(GalaxyClusterTimePeriodMapPDSAValidator.ColumnNames.TimePeriodUid).IsNull == false)
        Entity.TimePeriodUid = Properties.GetByName(GalaxyClusterTimePeriodMapPDSAValidator.ColumnNames.TimePeriodUid).GetAsGuid();
      if(Properties.GetByName(GalaxyClusterTimePeriodMapPDSAValidator.ColumnNames.ClusterUid).IsNull == false)
        Entity.ClusterUid = Properties.GetByName(GalaxyClusterTimePeriodMapPDSAValidator.ColumnNames.ClusterUid).GetAsGuid();
      if(Properties.GetByName(GalaxyClusterTimePeriodMapPDSAValidator.ColumnNames.PanelPeriodNumber).IsNull == false)
        Entity.PanelPeriodNumber = Properties.GetByName(GalaxyClusterTimePeriodMapPDSAValidator.ColumnNames.PanelPeriodNumber).GetAsInteger();
      if(Properties.GetByName(GalaxyClusterTimePeriodMapPDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(GalaxyClusterTimePeriodMapPDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(GalaxyClusterTimePeriodMapPDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(GalaxyClusterTimePeriodMapPDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(GalaxyClusterTimePeriodMapPDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(GalaxyClusterTimePeriodMapPDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(GalaxyClusterTimePeriodMapPDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(GalaxyClusterTimePeriodMapPDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(GalaxyClusterTimePeriodMapPDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(GalaxyClusterTimePeriodMapPDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the GalaxyClusterTimePeriodMapPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'GalaxyClusterTimePeriodMapUid'
    /// </summary>
    public static string GalaxyClusterTimePeriodMapUid = "GalaxyClusterTimePeriodMapUid";
    /// <summary>
    /// Returns 'TimePeriodUid'
    /// </summary>
    public static string TimePeriodUid = "TimePeriodUid";
    /// <summary>
    /// Returns 'ClusterUid'
    /// </summary>
    public static string ClusterUid = "ClusterUid";
    /// <summary>
    /// Returns 'PanelPeriodNumber'
    /// </summary>
    public static string PanelPeriodNumber = "PanelPeriodNumber";
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

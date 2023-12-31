using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the GalaxyPanelPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class GalaxyPanelPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private GalaxyPanelPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new GalaxyPanelPDSA Entity
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
    /// Clones the current GalaxyPanelPDSA
    /// </summary>
    /// <returns>A cloned GalaxyPanelPDSA object</returns>
    public GalaxyPanelPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in GalaxyPanelPDSA
    /// </summary>
    /// <param name="entityToClone">The GalaxyPanelPDSA entity to clone</param>
    /// <returns>A cloned GalaxyPanelPDSA object</returns>
    public GalaxyPanelPDSA CloneEntity(GalaxyPanelPDSA entityToClone)
    {
      GalaxyPanelPDSA newEntity = new GalaxyPanelPDSA();

      newEntity.GalaxyPanelUid = entityToClone.GalaxyPanelUid;
      newEntity.ClusterUid = entityToClone.ClusterUid;
      newEntity.GalaxyPanelModelUid = entityToClone.GalaxyPanelModelUid;
      newEntity.PanelNumber = entityToClone.PanelNumber;
      newEntity.PanelName = entityToClone.PanelName;
      newEntity.Location = entityToClone.Location;
      newEntity.InsertName = entityToClone.InsertName;
      newEntity.InsertDate = entityToClone.InsertDate;
      newEntity.UpdateName = entityToClone.UpdateName;
      newEntity.UpdateDate = entityToClone.UpdateDate;
      newEntity.ConcurrencyValue = entityToClone.ConcurrencyValue;
      newEntity.SiteUid = entityToClone.SiteUid;
      newEntity.RegionUid = entityToClone.RegionUid;
      newEntity.EntityId = entityToClone.EntityId;
      newEntity.ClusterNumber = entityToClone.ClusterNumber;
      newEntity.ClusterGroupId = entityToClone.ClusterGroupId;
      newEntity.PageNumber = entityToClone.PageNumber;
      newEntity.PageSize = entityToClone.PageSize;
      newEntity.TotalRowCount = entityToClone.TotalRowCount;
      newEntity.SortColumn = entityToClone.SortColumn;
      newEntity.DescendingOrder = entityToClone.DescendingOrder;
      newEntity.InterfaceBoardCount = entityToClone.InterfaceBoardCount;
      newEntity.ActiveCpuCount = entityToClone.ActiveCpuCount;
      newEntity.AccessPortalCount = entityToClone.AccessPortalCount;
      newEntity.InputDeviceCount = entityToClone.InputDeviceCount;
      newEntity.OutputDeviceCount = entityToClone.OutputDeviceCount;
      newEntity.ElevatorOutputCount = entityToClone.ElevatorOutputCount;
      newEntity.ClusterName = entityToClone.ClusterName;

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
      
      props.Add(PDSAProperty.Create(GalaxyPanelPDSAValidator.ColumnNames.GalaxyPanelUid, GetResourceMessage("GCS_GalaxyPanelPDSA_GalaxyPanelUid_Header", "Galaxy Panel Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_GalaxyPanelPDSA_GalaxyPanelUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelPDSAValidator.ColumnNames.ClusterUid, GetResourceMessage("GCS_GalaxyPanelPDSA_ClusterUid_Header", "Cluster Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_GalaxyPanelPDSA_ClusterUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelPDSAValidator.ColumnNames.GalaxyPanelModelUid, GetResourceMessage("GCS_GalaxyPanelPDSA_GalaxyPanelModelUid_Header", "Galaxy Panel Model Uid"), false, typeof(Guid), -1, GetResourceMessage("GCS_GalaxyPanelPDSA_GalaxyPanelModelUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelPDSAValidator.ColumnNames.PanelNumber, GetResourceMessage("GCS_GalaxyPanelPDSA_PanelNumber_Header", "Panel Number"), true, typeof(int), 10, GetResourceMessage("GCS_GalaxyPanelPDSA_PanelNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("0"), Convert.ToInt32("65565"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelPDSAValidator.ColumnNames.PanelName, GetResourceMessage("GCS_GalaxyPanelPDSA_PanelName_Header", "Panel Name"), true, typeof(string), 65, GetResourceMessage("GCS_GalaxyPanelPDSA_PanelName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelPDSAValidator.ColumnNames.Location, GetResourceMessage("GCS_GalaxyPanelPDSA_Location_Header", "Location"), true, typeof(string), 65, GetResourceMessage("GCS_GalaxyPanelPDSA_Location_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelPDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_GalaxyPanelPDSA_InsertName_Header", "Insert Name"), true, typeof(string), 100, GetResourceMessage("GCS_GalaxyPanelPDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelPDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_GalaxyPanelPDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_GalaxyPanelPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelPDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_GalaxyPanelPDSA_UpdateName_Header", "Update Name"), true, typeof(string), 100, GetResourceMessage("GCS_GalaxyPanelPDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelPDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_GalaxyPanelPDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_GalaxyPanelPDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelPDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_GalaxyPanelPDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_GalaxyPanelPDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelPDSAValidator.ColumnNames.SiteUid, GetResourceMessage("GCS_GalaxyPanelPDSA_SiteUid_Header", "Site Uid"), false, typeof(Guid), 2147483647, GetResourceMessage("GCS_GalaxyPanelPDSA_SiteUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelPDSAValidator.ColumnNames.RegionUid, GetResourceMessage("GCS_GalaxyPanelPDSA_RegionUid_Header", "Region Uid"), false, typeof(Guid), 2147483647, GetResourceMessage("GCS_GalaxyPanelPDSA_RegionUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelPDSAValidator.ColumnNames.EntityId, GetResourceMessage("GCS_GalaxyPanelPDSA_EntityId_Header", "Entity Id"), false, typeof(Guid), 2147483647, GetResourceMessage("GCS_GalaxyPanelPDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelPDSAValidator.ColumnNames.ClusterNumber, GetResourceMessage("GCS_GalaxyPanelPDSA_ClusterNumber_Header", "Cluster Number"), false, typeof(int), 2147483647, GetResourceMessage("GCS_GalaxyPanelPDSA_ClusterNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("0"), Convert.ToInt32("65565"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelPDSAValidator.ColumnNames.ClusterGroupId, GetResourceMessage("GCS_GalaxyPanelPDSA_ClusterGroupId_Header", "Cluster Group Id"), false, typeof(int), 2147483647, GetResourceMessage("GCS_GalaxyPanelPDSA_ClusterGroupId_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelPDSAValidator.ColumnNames.PageNumber, GetResourceMessage("GCS_GalaxyPanelPDSA_PageNumber_Header", "Page Number"), false, typeof(int), 2147483647, GetResourceMessage("GCS_GalaxyPanelPDSA_PageNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("0"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelPDSAValidator.ColumnNames.PageSize, GetResourceMessage("GCS_GalaxyPanelPDSA_PageSize_Header", "Page Size"), false, typeof(int), 2147483647, GetResourceMessage("GCS_GalaxyPanelPDSA_PageSize_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("0"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelPDSAValidator.ColumnNames.TotalRowCount, GetResourceMessage("GCS_GalaxyPanelPDSA_TotalRowCount_Header", "Total Row Count"), false, typeof(int), 2147483647, GetResourceMessage("GCS_GalaxyPanelPDSA_TotalRowCount_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("0"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelPDSAValidator.ColumnNames.SortColumn, GetResourceMessage("GCS_GalaxyPanelPDSA_SortColumn_Header", "Sort Column"), false, typeof(string), 2147483647, GetResourceMessage("GCS_GalaxyPanelPDSA_SortColumn_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelPDSAValidator.ColumnNames.DescendingOrder, GetResourceMessage("GCS_GalaxyPanelPDSA_DescendingOrder_Header", "Descending Order"), false, typeof(bool), 2147483647, GetResourceMessage("GCS_GalaxyPanelPDSA_DescendingOrder_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelPDSAValidator.ColumnNames.InterfaceBoardCount, GetResourceMessage("GCS_GalaxyPanelPDSA_InterfaceBoardCount_Header", "Interface Board Count"), false, typeof(int), 2147483647, GetResourceMessage("GCS_GalaxyPanelPDSA_InterfaceBoardCount_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("0"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelPDSAValidator.ColumnNames.ActiveCpuCount, GetResourceMessage("GCS_GalaxyPanelPDSA_ActiveCpuCount_Header", "Active Cpu Count"), false, typeof(int), 2147483647, GetResourceMessage("GCS_GalaxyPanelPDSA_ActiveCpuCount_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("0"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelPDSAValidator.ColumnNames.AccessPortalCount, GetResourceMessage("GCS_GalaxyPanelPDSA_AccessPortalCount_Header", "Access Portal Count"), false, typeof(int), 2147483647, GetResourceMessage("GCS_GalaxyPanelPDSA_AccessPortalCount_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("0"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelPDSAValidator.ColumnNames.InputDeviceCount, GetResourceMessage("GCS_GalaxyPanelPDSA_InputDeviceCount_Header", "Input Device Count"), false, typeof(int), 2147483647, GetResourceMessage("GCS_GalaxyPanelPDSA_InputDeviceCount_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("0"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelPDSAValidator.ColumnNames.OutputDeviceCount, GetResourceMessage("GCS_GalaxyPanelPDSA_OutputDeviceCount_Header", "Output Device Count"), false, typeof(int), 2147483647, GetResourceMessage("GCS_GalaxyPanelPDSA_OutputDeviceCount_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("0"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelPDSAValidator.ColumnNames.ElevatorOutputCount, GetResourceMessage("GCS_GalaxyPanelPDSA_ElevatorOutputCount_Header", "Elevator Output Count"), false, typeof(int), 2147483647, GetResourceMessage("GCS_GalaxyPanelPDSA_ElevatorOutputCount_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("0"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelPDSAValidator.ColumnNames.ClusterName, GetResourceMessage("GCS_GalaxyPanelPDSA_ClusterName_Header", "Cluster Name"), false, typeof(string), 2147483647, GetResourceMessage("GCS_GalaxyPanelPDSA_ClusterName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.GalaxyPanelUid = Guid.Empty;
      Entity.ClusterUid = Guid.Empty;
      Entity.GalaxyPanelModelUid = Guid.Empty;
      Entity.PanelNumber = 0;
      Entity.PanelName = string.Empty;
      Entity.Location = string.Empty;
      Entity.InsertName = string.Empty;
      Entity.InsertDate = DateTimeOffset.Now;
      Entity.UpdateName = string.Empty;
      Entity.UpdateDate = DateTimeOffset.Now;
      Entity.ConcurrencyValue = 0;
      Entity.SiteUid = Guid.Empty;
      Entity.RegionUid = Guid.Empty;
      Entity.EntityId = Guid.Empty;
      Entity.ClusterNumber = 0;
      Entity.ClusterGroupId = 0;
      Entity.PageNumber = 0;
      Entity.PageSize = 0;
      Entity.TotalRowCount = 0;
      Entity.SortColumn = string.Empty;
      Entity.DescendingOrder = false;
      Entity.InterfaceBoardCount = 0;
      Entity.ActiveCpuCount = 0;
      Entity.AccessPortalCount = 0;
      Entity.InputDeviceCount = 0;
      Entity.OutputDeviceCount = 0;
      Entity.ElevatorOutputCount = 0;
      Entity.ClusterName = string.Empty;

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
      
      if(!Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.GalaxyPanelUid).SetAsNull)
        Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.GalaxyPanelUid).Value = Entity.GalaxyPanelUid;
      if(!Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.ClusterUid).SetAsNull)
        Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.ClusterUid).Value = Entity.ClusterUid;
      if(!Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.GalaxyPanelModelUid).SetAsNull)
        Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.GalaxyPanelModelUid).Value = Entity.GalaxyPanelModelUid;
      if(!Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.PanelNumber).SetAsNull)
        Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.PanelNumber).Value = Entity.PanelNumber;
      if(!Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.PanelName).SetAsNull)
        Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.PanelName).Value = Entity.PanelName;
      if(!Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.Location).SetAsNull)
        Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.Location).Value = Entity.Location;
      if(!Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
      if(!Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.SiteUid).SetAsNull)
        Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.SiteUid).Value = Entity.SiteUid;
      if(!Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.RegionUid).SetAsNull)
        Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.RegionUid).Value = Entity.RegionUid;
      if(!Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.EntityId).SetAsNull)
        Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.EntityId).Value = Entity.EntityId;
      if(!Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.ClusterNumber).SetAsNull)
        Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.ClusterNumber).Value = Entity.ClusterNumber;
      if(!Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.ClusterGroupId).SetAsNull)
        Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.ClusterGroupId).Value = Entity.ClusterGroupId;
      if(!Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.PageNumber).SetAsNull)
        Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.PageNumber).Value = Entity.PageNumber;
      if(!Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.PageSize).SetAsNull)
        Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.PageSize).Value = Entity.PageSize;
      if(!Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.TotalRowCount).SetAsNull)
        Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.TotalRowCount).Value = Entity.TotalRowCount;
      if(!Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.SortColumn).SetAsNull)
        Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.SortColumn).Value = Entity.SortColumn;
      if(!Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.DescendingOrder).SetAsNull)
        Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.DescendingOrder).Value = Entity.DescendingOrder;
      if(!Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.InterfaceBoardCount).SetAsNull)
        Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.InterfaceBoardCount).Value = Entity.InterfaceBoardCount;
      if(!Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.ActiveCpuCount).SetAsNull)
        Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.ActiveCpuCount).Value = Entity.ActiveCpuCount;
      if(!Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.AccessPortalCount).SetAsNull)
        Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.AccessPortalCount).Value = Entity.AccessPortalCount;
      if(!Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.InputDeviceCount).SetAsNull)
        Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.InputDeviceCount).Value = Entity.InputDeviceCount;
      if(!Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.OutputDeviceCount).SetAsNull)
        Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.OutputDeviceCount).Value = Entity.OutputDeviceCount;
      if(!Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.ElevatorOutputCount).SetAsNull)
        Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.ElevatorOutputCount).Value = Entity.ElevatorOutputCount;
      if(!Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.ClusterName).SetAsNull)
        Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.ClusterName).Value = Entity.ClusterName;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.GalaxyPanelUid).IsNull == false)
        Entity.GalaxyPanelUid = Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.GalaxyPanelUid).GetAsGuid();
      if(Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.ClusterUid).IsNull == false)
        Entity.ClusterUid = Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.ClusterUid).GetAsGuid();
      if(Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.GalaxyPanelModelUid).IsNull == false)
        Entity.GalaxyPanelModelUid = Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.GalaxyPanelModelUid).GetAsGuid();
      if(Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.PanelNumber).IsNull == false)
        Entity.PanelNumber = Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.PanelNumber).GetAsInteger();
      if(Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.PanelName).IsNull == false)
        Entity.PanelName = Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.PanelName).GetAsString();
      if(Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.Location).IsNull == false)
        Entity.Location = Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.Location).GetAsString();
      if(Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
      if(Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.SiteUid).IsNull == false)
        Entity.SiteUid = Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.SiteUid).GetAsGuid();
      if(Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.RegionUid).IsNull == false)
        Entity.RegionUid = Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.RegionUid).GetAsGuid();
      if(Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.EntityId).IsNull == false)
        Entity.EntityId = Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.EntityId).GetAsGuid();
      if(Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.ClusterNumber).IsNull == false)
        Entity.ClusterNumber = Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.ClusterNumber).GetAsInteger();
      if(Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.ClusterGroupId).IsNull == false)
        Entity.ClusterGroupId = Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.ClusterGroupId).GetAsInteger();
      if(Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.PageNumber).IsNull == false)
        Entity.PageNumber = Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.PageNumber).GetAsInteger();
      if(Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.PageSize).IsNull == false)
        Entity.PageSize = Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.PageSize).GetAsInteger();
      if(Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.TotalRowCount).IsNull == false)
        Entity.TotalRowCount = Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.TotalRowCount).GetAsInteger();
      if(Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.SortColumn).IsNull == false)
        Entity.SortColumn = Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.SortColumn).GetAsString();
      if(Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.DescendingOrder).IsNull == false)
        Entity.DescendingOrder = Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.DescendingOrder).GetAsBool();
      if(Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.InterfaceBoardCount).IsNull == false)
        Entity.InterfaceBoardCount = Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.InterfaceBoardCount).GetAsInteger();
      if(Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.ActiveCpuCount).IsNull == false)
        Entity.ActiveCpuCount = Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.ActiveCpuCount).GetAsInteger();
      if(Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.AccessPortalCount).IsNull == false)
        Entity.AccessPortalCount = Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.AccessPortalCount).GetAsInteger();
      if(Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.InputDeviceCount).IsNull == false)
        Entity.InputDeviceCount = Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.InputDeviceCount).GetAsInteger();
      if(Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.OutputDeviceCount).IsNull == false)
        Entity.OutputDeviceCount = Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.OutputDeviceCount).GetAsInteger();
      if(Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.ElevatorOutputCount).IsNull == false)
        Entity.ElevatorOutputCount = Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.ElevatorOutputCount).GetAsInteger();
      if(Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.ClusterName).IsNull == false)
        Entity.ClusterName = Properties.GetByName(GalaxyPanelPDSAValidator.ColumnNames.ClusterName).GetAsString();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the GalaxyPanelPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'GalaxyPanelUid'
    /// </summary>
    public static string GalaxyPanelUid = "GalaxyPanelUid";
    /// <summary>
    /// Returns 'ClusterUid'
    /// </summary>
    public static string ClusterUid = "ClusterUid";
    /// <summary>
    /// Returns 'GalaxyPanelModelUid'
    /// </summary>
    public static string GalaxyPanelModelUid = "GalaxyPanelModelUid";
    /// <summary>
    /// Returns 'PanelNumber'
    /// </summary>
    public static string PanelNumber = "PanelNumber";
    /// <summary>
    /// Returns 'PanelName'
    /// </summary>
    public static string PanelName = "PanelName";
    /// <summary>
    /// Returns 'Location'
    /// </summary>
    public static string Location = "Location";
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
    /// Returns 'SiteUid'
    /// </summary>
    public static string SiteUid = "SiteUid";
    /// <summary>
    /// Returns 'RegionUid'
    /// </summary>
    public static string RegionUid = "RegionUid";
    /// <summary>
    /// Returns 'EntityId'
    /// </summary>
    public static string EntityId = "EntityId";
    /// <summary>
    /// Returns 'ClusterNumber'
    /// </summary>
    public static string ClusterNumber = "ClusterNumber";
    /// <summary>
    /// Returns 'ClusterGroupId'
    /// </summary>
    public static string ClusterGroupId = "ClusterGroupId";
    /// <summary>
    /// Returns 'PageNumber'
    /// </summary>
    public static string PageNumber = "PageNumber";
    /// <summary>
    /// Returns 'PageSize'
    /// </summary>
    public static string PageSize = "PageSize";
    /// <summary>
    /// Returns 'TotalRowCount'
    /// </summary>
    public static string TotalRowCount = "TotalRowCount";
    /// <summary>
    /// Returns 'SortColumn'
    /// </summary>
    public static string SortColumn = "SortColumn";
    /// <summary>
    /// Returns 'DescendingOrder'
    /// </summary>
    public static string DescendingOrder = "DescendingOrder";
    /// <summary>
    /// Returns 'InterfaceBoardCount'
    /// </summary>
    public static string InterfaceBoardCount = "InterfaceBoardCount";
    /// <summary>
    /// Returns 'ActiveCpuCount'
    /// </summary>
    public static string ActiveCpuCount = "ActiveCpuCount";
    /// <summary>
    /// Returns 'AccessPortalCount'
    /// </summary>
    public static string AccessPortalCount = "AccessPortalCount";
    /// <summary>
    /// Returns 'InputDeviceCount'
    /// </summary>
    public static string InputDeviceCount = "InputDeviceCount";
    /// <summary>
    /// Returns 'OutputDeviceCount'
    /// </summary>
    public static string OutputDeviceCount = "OutputDeviceCount";
    /// <summary>
    /// Returns 'ElevatorOutputCount'
    /// </summary>
    public static string ElevatorOutputCount = "ElevatorOutputCount";
    /// <summary>
    /// Returns 'ClusterName'
    /// </summary>
    public static string ClusterName = "ClusterName";
    }
    #endregion
  }
}

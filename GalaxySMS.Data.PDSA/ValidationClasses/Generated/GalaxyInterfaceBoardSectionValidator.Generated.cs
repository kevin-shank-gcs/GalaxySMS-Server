using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the GalaxyInterfaceBoardSectionPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class GalaxyInterfaceBoardSectionPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private GalaxyInterfaceBoardSectionPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new GalaxyInterfaceBoardSectionPDSA Entity
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
    /// Clones the current GalaxyInterfaceBoardSectionPDSA
    /// </summary>
    /// <returns>A cloned GalaxyInterfaceBoardSectionPDSA object</returns>
    public GalaxyInterfaceBoardSectionPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in GalaxyInterfaceBoardSectionPDSA
    /// </summary>
    /// <param name="entityToClone">The GalaxyInterfaceBoardSectionPDSA entity to clone</param>
    /// <returns>A cloned GalaxyInterfaceBoardSectionPDSA object</returns>
    public GalaxyInterfaceBoardSectionPDSA CloneEntity(GalaxyInterfaceBoardSectionPDSA entityToClone)
    {
      GalaxyInterfaceBoardSectionPDSA newEntity = new GalaxyInterfaceBoardSectionPDSA();

      newEntity.GalaxyInterfaceBoardSectionUid = entityToClone.GalaxyInterfaceBoardSectionUid;
      newEntity.GalaxyInterfaceBoardUid = entityToClone.GalaxyInterfaceBoardUid;
      newEntity.InterfaceBoardSectionModeUid = entityToClone.InterfaceBoardSectionModeUid;
      newEntity.SectionNumber = entityToClone.SectionNumber;
      newEntity.IsSectionActive = entityToClone.IsSectionActive;
      newEntity.InsertName = entityToClone.InsertName;
      newEntity.InsertDate = entityToClone.InsertDate;
      newEntity.UpdateName = entityToClone.UpdateName;
      newEntity.UpdateDate = entityToClone.UpdateDate;
      newEntity.ConcurrencyValue = entityToClone.ConcurrencyValue;
      newEntity.GalaxyPanelUid = entityToClone.GalaxyPanelUid;
      newEntity.ClusterUid = entityToClone.ClusterUid;
      newEntity.PanelNumber = entityToClone.PanelNumber;
      newEntity.BoardNumber = entityToClone.BoardNumber;
      newEntity.ModeCode = entityToClone.ModeCode;
      newEntity.AccessPointUid = entityToClone.AccessPointUid;
      newEntity.AccessPortalUid = entityToClone.AccessPortalUid;
      newEntity.ClusterNumber = entityToClone.ClusterNumber;
      newEntity.ClusterGroupId = entityToClone.ClusterGroupId;

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
      
      props.Add(PDSAProperty.Create(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.GalaxyInterfaceBoardSectionUid, GetResourceMessage("GCS_GalaxyInterfaceBoardSectionPDSA_GalaxyInterfaceBoardSectionUid_Header", "Galaxy Interface Board Section Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_GalaxyInterfaceBoardSectionPDSA_GalaxyInterfaceBoardSectionUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.GalaxyInterfaceBoardUid, GetResourceMessage("GCS_GalaxyInterfaceBoardSectionPDSA_GalaxyInterfaceBoardUid_Header", "Galaxy Interface Board Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_GalaxyInterfaceBoardSectionPDSA_GalaxyInterfaceBoardUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.InterfaceBoardSectionModeUid, GetResourceMessage("GCS_GalaxyInterfaceBoardSectionPDSA_InterfaceBoardSectionModeUid_Header", "Interface Board Section Mode Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_GalaxyInterfaceBoardSectionPDSA_InterfaceBoardSectionModeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.SectionNumber, GetResourceMessage("GCS_GalaxyInterfaceBoardSectionPDSA_SectionNumber_Header", "Section Number"), true, typeof(short), 5, GetResourceMessage("GCS_GalaxyInterfaceBoardSectionPDSA_SectionNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.IsSectionActive, GetResourceMessage("GCS_GalaxyInterfaceBoardSectionPDSA_IsSectionActive_Header", "Is Section Active"), true, typeof(bool), -1, GetResourceMessage("GCS_GalaxyInterfaceBoardSectionPDSA_IsSectionActive_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.InsertName, GetResourceMessage("GCS_GalaxyInterfaceBoardSectionPDSA_InsertName_Header", "Insert Name"), true, typeof(string), 100, GetResourceMessage("GCS_GalaxyInterfaceBoardSectionPDSA_InsertName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.InsertDate, GetResourceMessage("GCS_GalaxyInterfaceBoardSectionPDSA_InsertDate_Header", "Insert Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_GalaxyInterfaceBoardSectionPDSA_InsertDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.UpdateName, GetResourceMessage("GCS_GalaxyInterfaceBoardSectionPDSA_UpdateName_Header", "Update Name"), true, typeof(string), 100, GetResourceMessage("GCS_GalaxyInterfaceBoardSectionPDSA_UpdateName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.UpdateDate, GetResourceMessage("GCS_GalaxyInterfaceBoardSectionPDSA_UpdateDate_Header", "Update Date"), true, typeof(DateTimeOffset), -1, GetResourceMessage("GCS_GalaxyInterfaceBoardSectionPDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, DateTimeOffset.Now, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.ConcurrencyValue, GetResourceMessage("GCS_GalaxyInterfaceBoardSectionPDSA_ConcurrencyValue_Header", "Concurrency Value"), true, typeof(short), 5, GetResourceMessage("GCS_GalaxyInterfaceBoardSectionPDSA_ConcurrencyValue_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.GalaxyPanelUid, GetResourceMessage("GCS_GalaxyInterfaceBoardSectionPDSA_GalaxyPanelUid_Header", "Galaxy Panel Uid"), false, typeof(Guid), 2147483647, GetResourceMessage("GCS_GalaxyInterfaceBoardSectionPDSA_GalaxyPanelUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.ClusterUid, GetResourceMessage("GCS_GalaxyInterfaceBoardSectionPDSA_ClusterUid_Header", "Cluster Uid"), false, typeof(Guid), 2147483647, GetResourceMessage("GCS_GalaxyInterfaceBoardSectionPDSA_ClusterUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.PanelNumber, GetResourceMessage("GCS_GalaxyInterfaceBoardSectionPDSA_PanelNumber_Header", "Panel Number"), false, typeof(int), 2147483647, GetResourceMessage("GCS_GalaxyInterfaceBoardSectionPDSA_PanelNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("0"), Convert.ToInt32("65535"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.BoardNumber, GetResourceMessage("GCS_GalaxyInterfaceBoardSectionPDSA_BoardNumber_Header", "Board Number"), false, typeof(short), 2147483647, GetResourceMessage("GCS_GalaxyInterfaceBoardSectionPDSA_BoardNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.ModeCode, GetResourceMessage("GCS_GalaxyInterfaceBoardSectionPDSA_ModeCode_Header", "Mode Code"), false, typeof(short), 2147483647, GetResourceMessage("GCS_GalaxyInterfaceBoardSectionPDSA_ModeCode_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.AccessPointUid, GetResourceMessage("GCS_GalaxyInterfaceBoardSectionPDSA_AccessPointUid_Header", "Access Point Uid"), false, typeof(Guid), 2147483647, GetResourceMessage("GCS_GalaxyInterfaceBoardSectionPDSA_AccessPointUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.AccessPortalUid, GetResourceMessage("GCS_GalaxyInterfaceBoardSectionPDSA_AccessPortalUid_Header", "Access Portal Uid"), false, typeof(Guid), 2147483647, GetResourceMessage("GCS_GalaxyInterfaceBoardSectionPDSA_AccessPortalUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.ClusterNumber, GetResourceMessage("GCS_GalaxyInterfaceBoardSectionPDSA_ClusterNumber_Header", "Cluster Number"), false, typeof(int), 2147483647, GetResourceMessage("GCS_GalaxyInterfaceBoardSectionPDSA_ClusterNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("0"), Convert.ToInt32("65535"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.ClusterGroupId, GetResourceMessage("GCS_GalaxyInterfaceBoardSectionPDSA_ClusterGroupId_Header", "Cluster Group Id"), false, typeof(int), 2147483647, GetResourceMessage("GCS_GalaxyInterfaceBoardSectionPDSA_ClusterGroupId_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("0"), Convert.ToInt32("65535"), 0, 0, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.GalaxyInterfaceBoardSectionUid = Guid.Empty;
      Entity.GalaxyInterfaceBoardUid = Guid.Empty;
      Entity.InterfaceBoardSectionModeUid = Guid.Empty;
      Entity.SectionNumber = 0;
      Entity.IsSectionActive = false;
      Entity.InsertName = string.Empty;
      Entity.InsertDate = DateTimeOffset.Now;
      Entity.UpdateName = string.Empty;
      Entity.UpdateDate = DateTimeOffset.Now;
      Entity.ConcurrencyValue = 0;
      Entity.GalaxyPanelUid = Guid.Empty;
      Entity.ClusterUid = Guid.Empty;
      Entity.PanelNumber = 0;
      Entity.BoardNumber = 0;
      Entity.ModeCode = 0;
      Entity.AccessPointUid = Guid.Empty;
      Entity.AccessPortalUid = Guid.Empty;
      Entity.ClusterNumber = 0;
      Entity.ClusterGroupId = 0;

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
      
      if(!Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.GalaxyInterfaceBoardSectionUid).SetAsNull)
        Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.GalaxyInterfaceBoardSectionUid).Value = Entity.GalaxyInterfaceBoardSectionUid;
      if(!Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.GalaxyInterfaceBoardUid).SetAsNull)
        Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.GalaxyInterfaceBoardUid).Value = Entity.GalaxyInterfaceBoardUid;
      if(!Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.InterfaceBoardSectionModeUid).SetAsNull)
        Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.InterfaceBoardSectionModeUid).Value = Entity.InterfaceBoardSectionModeUid;
      if(!Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.SectionNumber).SetAsNull)
        Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.SectionNumber).Value = Entity.SectionNumber;
      if(!Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.IsSectionActive).SetAsNull)
        Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.IsSectionActive).Value = Entity.IsSectionActive;
      if(!Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.InsertName).SetAsNull)
        Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.InsertName).Value = Entity.InsertName;
      if(!Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.InsertDate).SetAsNull)
        Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.InsertDate).Value = Entity.InsertDate;
      if(!Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.UpdateName).SetAsNull)
        Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.UpdateName).Value = Entity.UpdateName;
      if(!Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.UpdateDate).SetAsNull)
        Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.UpdateDate).Value = Entity.UpdateDate;
      if(!Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.ConcurrencyValue).SetAsNull)
        Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.ConcurrencyValue).Value = Entity.ConcurrencyValue;
      if(!Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.GalaxyPanelUid).SetAsNull)
        Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.GalaxyPanelUid).Value = Entity.GalaxyPanelUid;
      if(!Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.ClusterUid).SetAsNull)
        Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.ClusterUid).Value = Entity.ClusterUid;
      if(!Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.PanelNumber).SetAsNull)
        Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.PanelNumber).Value = Entity.PanelNumber;
      if(!Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.BoardNumber).SetAsNull)
        Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.BoardNumber).Value = Entity.BoardNumber;
      if(!Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.ModeCode).SetAsNull)
        Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.ModeCode).Value = Entity.ModeCode;
      if(!Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.AccessPointUid).SetAsNull)
        Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.AccessPointUid).Value = Entity.AccessPointUid;
      if(!Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.AccessPortalUid).SetAsNull)
        Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.AccessPortalUid).Value = Entity.AccessPortalUid;
      if(!Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.ClusterNumber).SetAsNull)
        Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.ClusterNumber).Value = Entity.ClusterNumber;
      if(!Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.ClusterGroupId).SetAsNull)
        Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.ClusterGroupId).Value = Entity.ClusterGroupId;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.GalaxyInterfaceBoardSectionUid).IsNull == false)
        Entity.GalaxyInterfaceBoardSectionUid = Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.GalaxyInterfaceBoardSectionUid).GetAsGuid();
      if(Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.GalaxyInterfaceBoardUid).IsNull == false)
        Entity.GalaxyInterfaceBoardUid = Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.GalaxyInterfaceBoardUid).GetAsGuid();
      if(Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.InterfaceBoardSectionModeUid).IsNull == false)
        Entity.InterfaceBoardSectionModeUid = Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.InterfaceBoardSectionModeUid).GetAsGuid();
      if(Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.SectionNumber).IsNull == false)
        Entity.SectionNumber = Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.SectionNumber).GetAsShort();
      if(Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.IsSectionActive).IsNull == false)
        Entity.IsSectionActive = Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.IsSectionActive).GetAsBool();
      if(Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.InsertName).IsNull == false)
        Entity.InsertName = Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.InsertName).GetAsString();
      if(Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.InsertDate).IsNull == false)
        Entity.InsertDate = Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.InsertDate).GetAsDateTimeOffset();
      if(Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.UpdateName).IsNull == false)
        Entity.UpdateName = Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.UpdateName).GetAsString();
      if(Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.ConcurrencyValue).IsNull == false)
        Entity.ConcurrencyValue = Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.ConcurrencyValue).GetAsShort();
      if(Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.GalaxyPanelUid).IsNull == false)
        Entity.GalaxyPanelUid = Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.GalaxyPanelUid).GetAsGuid();
      if(Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.ClusterUid).IsNull == false)
        Entity.ClusterUid = Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.ClusterUid).GetAsGuid();
      if(Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.PanelNumber).IsNull == false)
        Entity.PanelNumber = Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.PanelNumber).GetAsInteger();
      if(Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.BoardNumber).IsNull == false)
        Entity.BoardNumber = Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.BoardNumber).GetAsShort();
      if(Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.ModeCode).IsNull == false)
        Entity.ModeCode = Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.ModeCode).GetAsShort();
      if(Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.AccessPointUid).IsNull == false)
        Entity.AccessPointUid = Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.AccessPointUid).GetAsGuid();
      if(Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.AccessPortalUid).IsNull == false)
        Entity.AccessPortalUid = Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.AccessPortalUid).GetAsGuid();
      if(Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.ClusterNumber).IsNull == false)
        Entity.ClusterNumber = Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.ClusterNumber).GetAsInteger();
      if(Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.ClusterGroupId).IsNull == false)
        Entity.ClusterGroupId = Properties.GetByName(GalaxyInterfaceBoardSectionPDSAValidator.ColumnNames.ClusterGroupId).GetAsInteger();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the GalaxyInterfaceBoardSectionPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'GalaxyInterfaceBoardSectionUid'
    /// </summary>
    public static string GalaxyInterfaceBoardSectionUid = "GalaxyInterfaceBoardSectionUid";
    /// <summary>
    /// Returns 'GalaxyInterfaceBoardUid'
    /// </summary>
    public static string GalaxyInterfaceBoardUid = "GalaxyInterfaceBoardUid";
    /// <summary>
    /// Returns 'InterfaceBoardSectionModeUid'
    /// </summary>
    public static string InterfaceBoardSectionModeUid = "InterfaceBoardSectionModeUid";
    /// <summary>
    /// Returns 'SectionNumber'
    /// </summary>
    public static string SectionNumber = "SectionNumber";
    /// <summary>
    /// Returns 'IsSectionActive'
    /// </summary>
    public static string IsSectionActive = "IsSectionActive";
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
    /// Returns 'GalaxyPanelUid'
    /// </summary>
    public static string GalaxyPanelUid = "GalaxyPanelUid";
    /// <summary>
    /// Returns 'ClusterUid'
    /// </summary>
    public static string ClusterUid = "ClusterUid";
    /// <summary>
    /// Returns 'PanelNumber'
    /// </summary>
    public static string PanelNumber = "PanelNumber";
    /// <summary>
    /// Returns 'BoardNumber'
    /// </summary>
    public static string BoardNumber = "BoardNumber";
    /// <summary>
    /// Returns 'ModeCode'
    /// </summary>
    public static string ModeCode = "ModeCode";
    /// <summary>
    /// Returns 'AccessPointUid'
    /// </summary>
    public static string AccessPointUid = "AccessPointUid";
    /// <summary>
    /// Returns 'AccessPortalUid'
    /// </summary>
    public static string AccessPortalUid = "AccessPortalUid";
    /// <summary>
    /// Returns 'ClusterNumber'
    /// </summary>
    public static string ClusterNumber = "ClusterNumber";
    /// <summary>
    /// Returns 'ClusterGroupId'
    /// </summary>
    public static string ClusterGroupId = "ClusterGroupId";
    }
    #endregion
  }
}

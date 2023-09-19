using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the Site_SelectionListForEntityAndRegionPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class Site_SelectionListForEntityAndRegionPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private Site_SelectionListForEntityAndRegionPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new Site_SelectionListForEntityAndRegionPDSA Entity
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
    /// Clones the current Site_SelectionListForEntityAndRegionPDSA
    /// </summary>
    /// <returns>A cloned Site_SelectionListForEntityAndRegionPDSA object</returns>
    public Site_SelectionListForEntityAndRegionPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in Site_SelectionListForEntityAndRegionPDSA
    /// </summary>
    /// <param name="entityToClone">The Site_SelectionListForEntityAndRegionPDSA entity to clone</param>
    /// <returns>A cloned Site_SelectionListForEntityAndRegionPDSA object</returns>
    public Site_SelectionListForEntityAndRegionPDSA CloneEntity(Site_SelectionListForEntityAndRegionPDSA entityToClone)
    {
      Site_SelectionListForEntityAndRegionPDSA newEntity = new Site_SelectionListForEntityAndRegionPDSA();

      newEntity.SiteUid = entityToClone.SiteUid;
      newEntity.RegionUid = entityToClone.RegionUid;
      newEntity.SiteName = entityToClone.SiteName;
      newEntity.SiteId = entityToClone.SiteId;
      newEntity.EntityId = entityToClone.EntityId;
      newEntity.BinaryResource = entityToClone.BinaryResource;

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
      
      props.Add(PDSAProperty.Create(Site_SelectionListForEntityAndRegionPDSAValidator.ParameterNames.EntityId, GetResourceMessage("GCS_Site_SelectionListForEntityAndRegionPDSA_EntityId_Header", "Entity Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_Site_SelectionListForEntityAndRegionPDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(Site_SelectionListForEntityAndRegionPDSAValidator.ParameterNames.RegionUid, GetResourceMessage("GCS_Site_SelectionListForEntityAndRegionPDSA_RegionUid_Header", "Region Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_Site_SelectionListForEntityAndRegionPDSA_RegionUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(Site_SelectionListForEntityAndRegionPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_Site_SelectionListForEntityAndRegionPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_Site_SelectionListForEntityAndRegionPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
      return props;
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
      if (this.Properties == null)
      {
        this.InitProperties();
      }
      
      this.Properties.GetByName(Site_SelectionListForEntityAndRegionPDSAValidator.ParameterNames.EntityId).Value = Entity.EntityId;
      this.Properties.GetByName(Site_SelectionListForEntityAndRegionPDSAValidator.ParameterNames.RegionUid).Value = Entity.RegionUid;
      this.Properties.GetByName(Site_SelectionListForEntityAndRegionPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (this.Properties == null)
      {
        this.InitProperties();
      }

      if(this.Properties.GetByName(Site_SelectionListForEntityAndRegionPDSAValidator.ParameterNames.EntityId).IsNull == false)
        Entity.EntityId = this.Properties.GetByName(Site_SelectionListForEntityAndRegionPDSAValidator.ParameterNames.EntityId).GetAsGuid();
      if(this.Properties.GetByName(Site_SelectionListForEntityAndRegionPDSAValidator.ParameterNames.RegionUid).IsNull == false)
        Entity.RegionUid = this.Properties.GetByName(Site_SelectionListForEntityAndRegionPDSAValidator.ParameterNames.RegionUid).GetAsGuid();
      if(this.Properties.GetByName(Site_SelectionListForEntityAndRegionPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(Site_SelectionListForEntityAndRegionPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the Site_SelectionListForEntityAndRegionPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'SiteUid'
    /// </summary>
    public static string SiteUid = "SiteUid";
    /// <summary>
    /// Returns 'RegionUid'
    /// </summary>
    public static string RegionUid = "RegionUid";
    /// <summary>
    /// Returns 'SiteName'
    /// </summary>
    public static string SiteName = "SiteName";
    /// <summary>
    /// Returns 'SiteId'
    /// </summary>
    public static string SiteId = "SiteId";
    /// <summary>
    /// Returns 'EntityId'
    /// </summary>
    public static string EntityId = "EntityId";
    /// <summary>
    /// Returns 'BinaryResource'
    /// </summary>
    public static string BinaryResource = "BinaryResource";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the Site_SelectionListForEntityAndRegionPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@EntityId'
    /// </summary>
    public static string EntityId = "@EntityId";
    /// <summary>
    /// Returns '@RegionUid'
    /// </summary>
    public static string RegionUid = "@RegionUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}

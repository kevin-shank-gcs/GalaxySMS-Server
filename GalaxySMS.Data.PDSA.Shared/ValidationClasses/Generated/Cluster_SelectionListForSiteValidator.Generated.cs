using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the Cluster_SelectionListForSitePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class Cluster_SelectionListForSitePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private Cluster_SelectionListForSitePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new Cluster_SelectionListForSitePDSA Entity
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
    /// Clones the current Cluster_SelectionListForSitePDSA
    /// </summary>
    /// <returns>A cloned Cluster_SelectionListForSitePDSA object</returns>
    public Cluster_SelectionListForSitePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in Cluster_SelectionListForSitePDSA
    /// </summary>
    /// <param name="entityToClone">The Cluster_SelectionListForSitePDSA entity to clone</param>
    /// <returns>A cloned Cluster_SelectionListForSitePDSA object</returns>
    public Cluster_SelectionListForSitePDSA CloneEntity(Cluster_SelectionListForSitePDSA entityToClone)
    {
      Cluster_SelectionListForSitePDSA newEntity = new Cluster_SelectionListForSitePDSA();

      newEntity.ClusterUid = entityToClone.ClusterUid;
      newEntity.SiteUid = entityToClone.SiteUid;
      newEntity.ClusterName = entityToClone.ClusterName;
      newEntity.ClusterNumber = entityToClone.ClusterNumber;
      newEntity.ClusterGroupId = entityToClone.ClusterGroupId;
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
      
      props.Add(PDSAProperty.Create(Cluster_SelectionListForSitePDSAValidator.ParameterNames.SiteUid, GetResourceMessage("GCS_Cluster_SelectionListForSitePDSA_SiteUid_Header", "Site Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_Cluster_SelectionListForSitePDSA_SiteUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(Cluster_SelectionListForSitePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_Cluster_SelectionListForSitePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_Cluster_SelectionListForSitePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(Cluster_SelectionListForSitePDSAValidator.ParameterNames.SiteUid).Value = Entity.SiteUid;
      this.Properties.GetByName(Cluster_SelectionListForSitePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(Cluster_SelectionListForSitePDSAValidator.ParameterNames.SiteUid).IsNull == false)
        Entity.SiteUid = this.Properties.GetByName(Cluster_SelectionListForSitePDSAValidator.ParameterNames.SiteUid).GetAsGuid();
      if(this.Properties.GetByName(Cluster_SelectionListForSitePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(Cluster_SelectionListForSitePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the Cluster_SelectionListForSitePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'ClusterUid'
    /// </summary>
    public static string ClusterUid = "ClusterUid";
    /// <summary>
    /// Returns 'SiteUid'
    /// </summary>
    public static string SiteUid = "SiteUid";
    /// <summary>
    /// Returns 'ClusterName'
    /// </summary>
    public static string ClusterName = "ClusterName";
    /// <summary>
    /// Returns 'ClusterNumber'
    /// </summary>
    public static string ClusterNumber = "ClusterNumber";
    /// <summary>
    /// Returns 'ClusterGroupId'
    /// </summary>
    public static string ClusterGroupId = "ClusterGroupId";
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
    /// Contains static string properties that represent the name of each property in the Cluster_SelectionListForSitePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@SiteUid'
    /// </summary>
    public static string SiteUid = "@SiteUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}

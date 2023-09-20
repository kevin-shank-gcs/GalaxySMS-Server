using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the PersonalAccessGroup_PanelLoadDataByClusterUidPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class PersonalAccessGroup_PanelLoadDataByClusterUidPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private PersonalAccessGroup_PanelLoadDataByClusterUidPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new PersonalAccessGroup_PanelLoadDataByClusterUidPDSA Entity
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
    /// Clones the current PersonalAccessGroup_PanelLoadDataByClusterUidPDSA
    /// </summary>
    /// <returns>A cloned PersonalAccessGroup_PanelLoadDataByClusterUidPDSA object</returns>
    public PersonalAccessGroup_PanelLoadDataByClusterUidPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in PersonalAccessGroup_PanelLoadDataByClusterUidPDSA
    /// </summary>
    /// <param name="entityToClone">The PersonalAccessGroup_PanelLoadDataByClusterUidPDSA entity to clone</param>
    /// <returns>A cloned PersonalAccessGroup_PanelLoadDataByClusterUidPDSA object</returns>
    public PersonalAccessGroup_PanelLoadDataByClusterUidPDSA CloneEntity(PersonalAccessGroup_PanelLoadDataByClusterUidPDSA entityToClone)
    {
      PersonalAccessGroup_PanelLoadDataByClusterUidPDSA newEntity = new PersonalAccessGroup_PanelLoadDataByClusterUidPDSA();

      newEntity.PersonUid = entityToClone.PersonUid;
      newEntity.ClusterUid = entityToClone.ClusterUid;
      newEntity.GalaxyPanelUid = entityToClone.GalaxyPanelUid;
      newEntity.PersonalAccessGroupNumber = entityToClone.PersonalAccessGroupNumber;
      newEntity.ClusterNumber = entityToClone.ClusterNumber;
      newEntity.ClusterGroupId = entityToClone.ClusterGroupId;
      newEntity.PanelScheduleNumber = entityToClone.PanelScheduleNumber;
      newEntity.DoorNumber = entityToClone.DoorNumber;
      newEntity.PanelNumber = entityToClone.PanelNumber;
      newEntity.AccessGroupDisplay = entityToClone.AccessGroupDisplay;

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
      
      props.Add(PDSAProperty.Create(PersonalAccessGroup_PanelLoadDataByClusterUidPDSAValidator.ParameterNames.ClusterUid, GetResourceMessage("GCS_PersonalAccessGroup_PanelLoadDataByClusterUidPDSA_ClusterUid_Header", "Cluster Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_PersonalAccessGroup_PanelLoadDataByClusterUidPDSA_ClusterUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonalAccessGroup_PanelLoadDataByClusterUidPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_PersonalAccessGroup_PanelLoadDataByClusterUidPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_PersonalAccessGroup_PanelLoadDataByClusterUidPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(PersonalAccessGroup_PanelLoadDataByClusterUidPDSAValidator.ParameterNames.ClusterUid).Value = Entity.ClusterUid;
      this.Properties.GetByName(PersonalAccessGroup_PanelLoadDataByClusterUidPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(PersonalAccessGroup_PanelLoadDataByClusterUidPDSAValidator.ParameterNames.ClusterUid).IsNull == false)
        Entity.ClusterUid = this.Properties.GetByName(PersonalAccessGroup_PanelLoadDataByClusterUidPDSAValidator.ParameterNames.ClusterUid).GetAsGuid();
      if(this.Properties.GetByName(PersonalAccessGroup_PanelLoadDataByClusterUidPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(PersonalAccessGroup_PanelLoadDataByClusterUidPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the PersonalAccessGroup_PanelLoadDataByClusterUidPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'PersonUid'
    /// </summary>
    public static string PersonUid = "PersonUid";
    /// <summary>
    /// Returns 'ClusterUid'
    /// </summary>
    public static string ClusterUid = "ClusterUid";
    /// <summary>
    /// Returns 'GalaxyPanelUid'
    /// </summary>
    public static string GalaxyPanelUid = "GalaxyPanelUid";
    /// <summary>
    /// Returns 'PersonalAccessGroupNumber'
    /// </summary>
    public static string PersonalAccessGroupNumber = "PersonalAccessGroupNumber";
    /// <summary>
    /// Returns 'ClusterNumber'
    /// </summary>
    public static string ClusterNumber = "ClusterNumber";
    /// <summary>
    /// Returns 'ClusterGroupId'
    /// </summary>
    public static string ClusterGroupId = "ClusterGroupId";
    /// <summary>
    /// Returns 'PanelScheduleNumber'
    /// </summary>
    public static string PanelScheduleNumber = "PanelScheduleNumber";
    /// <summary>
    /// Returns 'DoorNumber'
    /// </summary>
    public static string DoorNumber = "DoorNumber";
    /// <summary>
    /// Returns 'PanelNumber'
    /// </summary>
    public static string PanelNumber = "PanelNumber";
    /// <summary>
    /// Returns 'AccessGroupDisplay'
    /// </summary>
    public static string AccessGroupDisplay = "AccessGroupDisplay";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the PersonalAccessGroup_PanelLoadDataByClusterUidPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@ClusterUid'
    /// </summary>
    public static string ClusterUid = "@ClusterUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}

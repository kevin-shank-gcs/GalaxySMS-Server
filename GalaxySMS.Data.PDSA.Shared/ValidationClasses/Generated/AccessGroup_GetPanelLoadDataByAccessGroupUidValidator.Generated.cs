using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the AccessGroup_GetPanelLoadDataByAccessGroupUidPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class AccessGroup_GetPanelLoadDataByAccessGroupUidPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private AccessGroup_GetPanelLoadDataByAccessGroupUidPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new AccessGroup_GetPanelLoadDataByAccessGroupUidPDSA Entity
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
    /// Clones the current AccessGroup_GetPanelLoadDataByAccessGroupUidPDSA
    /// </summary>
    /// <returns>A cloned AccessGroup_GetPanelLoadDataByAccessGroupUidPDSA object</returns>
    public AccessGroup_GetPanelLoadDataByAccessGroupUidPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in AccessGroup_GetPanelLoadDataByAccessGroupUidPDSA
    /// </summary>
    /// <param name="entityToClone">The AccessGroup_GetPanelLoadDataByAccessGroupUidPDSA entity to clone</param>
    /// <returns>A cloned AccessGroup_GetPanelLoadDataByAccessGroupUidPDSA object</returns>
    public AccessGroup_GetPanelLoadDataByAccessGroupUidPDSA CloneEntity(AccessGroup_GetPanelLoadDataByAccessGroupUidPDSA entityToClone)
    {
      AccessGroup_GetPanelLoadDataByAccessGroupUidPDSA newEntity = new AccessGroup_GetPanelLoadDataByAccessGroupUidPDSA();

      newEntity.AccessGroupUid = entityToClone.AccessGroupUid;
      newEntity.ClusterUid = entityToClone.ClusterUid;
      newEntity.AccessGroupName = entityToClone.AccessGroupName;
      newEntity.ClusterGroupId = entityToClone.ClusterGroupId;
      newEntity.ClusterNumber = entityToClone.ClusterNumber;
      newEntity.AccessGroupNumber = entityToClone.AccessGroupNumber;
      newEntity.ActivationDate = entityToClone.ActivationDate;
      newEntity.ExpirationDate = entityToClone.ExpirationDate;
      newEntity.IsEnabled = entityToClone.IsEnabled;
      newEntity.CrisisModeAccessGroupUid = entityToClone.CrisisModeAccessGroupUid;
      newEntity.CrisisModeAccessGroupName = entityToClone.CrisisModeAccessGroupName;
      newEntity.CrisisModeAccessGroupNumber = entityToClone.CrisisModeAccessGroupNumber;
      newEntity.CurrentTimeForCluster = entityToClone.CurrentTimeForCluster;

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
      
      props.Add(PDSAProperty.Create(AccessGroup_GetPanelLoadDataByAccessGroupUidPDSAValidator.ParameterNames.AccessGroupUid, GetResourceMessage("GCS_AccessGroup_GetPanelLoadDataByAccessGroupUidPDSA_AccessGroupUid_Header", "Access Group Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_AccessGroup_GetPanelLoadDataByAccessGroupUidPDSA_AccessGroupUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessGroup_GetPanelLoadDataByAccessGroupUidPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_AccessGroup_GetPanelLoadDataByAccessGroupUidPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_AccessGroup_GetPanelLoadDataByAccessGroupUidPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(AccessGroup_GetPanelLoadDataByAccessGroupUidPDSAValidator.ParameterNames.AccessGroupUid).Value = Entity.AccessGroupUid;
      this.Properties.GetByName(AccessGroup_GetPanelLoadDataByAccessGroupUidPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(AccessGroup_GetPanelLoadDataByAccessGroupUidPDSAValidator.ParameterNames.AccessGroupUid).IsNull == false)
        Entity.AccessGroupUid = this.Properties.GetByName(AccessGroup_GetPanelLoadDataByAccessGroupUidPDSAValidator.ParameterNames.AccessGroupUid).GetAsGuid();
      if(this.Properties.GetByName(AccessGroup_GetPanelLoadDataByAccessGroupUidPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(AccessGroup_GetPanelLoadDataByAccessGroupUidPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the AccessGroup_GetPanelLoadDataByAccessGroupUidPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'AccessGroupUid'
    /// </summary>
    public static string AccessGroupUid = "AccessGroupUid";
    /// <summary>
    /// Returns 'ClusterUid'
    /// </summary>
    public static string ClusterUid = "ClusterUid";
    /// <summary>
    /// Returns 'AccessGroupName'
    /// </summary>
    public static string AccessGroupName = "AccessGroupName";
    /// <summary>
    /// Returns 'ClusterGroupId'
    /// </summary>
    public static string ClusterGroupId = "ClusterGroupId";
    /// <summary>
    /// Returns 'ClusterNumber'
    /// </summary>
    public static string ClusterNumber = "ClusterNumber";
    /// <summary>
    /// Returns 'AccessGroupNumber'
    /// </summary>
    public static string AccessGroupNumber = "AccessGroupNumber";
    /// <summary>
    /// Returns 'ActivationDate'
    /// </summary>
    public static string ActivationDate = "ActivationDate";
    /// <summary>
    /// Returns 'ExpirationDate'
    /// </summary>
    public static string ExpirationDate = "ExpirationDate";
    /// <summary>
    /// Returns 'IsEnabled'
    /// </summary>
    public static string IsEnabled = "IsEnabled";
    /// <summary>
    /// Returns 'CrisisModeAccessGroupUid'
    /// </summary>
    public static string CrisisModeAccessGroupUid = "CrisisModeAccessGroupUid";
    /// <summary>
    /// Returns 'CrisisModeAccessGroupName'
    /// </summary>
    public static string CrisisModeAccessGroupName = "CrisisModeAccessGroupName";
    /// <summary>
    /// Returns 'CrisisModeAccessGroupNumber'
    /// </summary>
    public static string CrisisModeAccessGroupNumber = "CrisisModeAccessGroupNumber";
    /// <summary>
    /// Returns 'CurrentTimeForCluster'
    /// </summary>
    public static string CurrentTimeForCluster = "CurrentTimeForCluster";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the AccessGroup_GetPanelLoadDataByAccessGroupUidPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@AccessGroupUid'
    /// </summary>
    public static string AccessGroupUid = "@AccessGroupUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}

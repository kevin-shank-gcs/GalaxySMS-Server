using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the AccessGroup_GetPanelLoadDataChangesPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class AccessGroup_GetPanelLoadDataChangesPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private AccessGroup_GetPanelLoadDataChangesPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new AccessGroup_GetPanelLoadDataChangesPDSA Entity
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
    /// Clones the current AccessGroup_GetPanelLoadDataChangesPDSA
    /// </summary>
    /// <returns>A cloned AccessGroup_GetPanelLoadDataChangesPDSA object</returns>
    public AccessGroup_GetPanelLoadDataChangesPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in AccessGroup_GetPanelLoadDataChangesPDSA
    /// </summary>
    /// <param name="entityToClone">The AccessGroup_GetPanelLoadDataChangesPDSA entity to clone</param>
    /// <returns>A cloned AccessGroup_GetPanelLoadDataChangesPDSA object</returns>
    public AccessGroup_GetPanelLoadDataChangesPDSA CloneEntity(AccessGroup_GetPanelLoadDataChangesPDSA entityToClone)
    {
      AccessGroup_GetPanelLoadDataChangesPDSA newEntity = new AccessGroup_GetPanelLoadDataChangesPDSA();

      newEntity.AccessGroupUid = entityToClone.AccessGroupUid;
      newEntity.ClusterUid = entityToClone.ClusterUid;
      newEntity.AccessGroupName = entityToClone.AccessGroupName;
      newEntity.AccessGroupNumber = entityToClone.AccessGroupNumber;
      newEntity.ActivationDate = entityToClone.ActivationDate;
      newEntity.ExpirationDate = entityToClone.ExpirationDate;
      newEntity.IsEnabled = entityToClone.IsEnabled;
      newEntity.CrisisModeAccessGroupUid = entityToClone.CrisisModeAccessGroupUid;
      newEntity.CrisisModeAccessGroupName = entityToClone.CrisisModeAccessGroupName;
      newEntity.CrisisModeAccessGroupNumber = entityToClone.CrisisModeAccessGroupNumber;
      newEntity.CurrentTimeForCluster = entityToClone.CurrentTimeForCluster;
      newEntity.ClusterGroupId = entityToClone.ClusterGroupId;
      newEntity.ClusterNumber = entityToClone.ClusterNumber;
      newEntity.PanelNumber = entityToClone.PanelNumber;
      newEntity.GalaxyPanelUid = entityToClone.GalaxyPanelUid;
      newEntity.CpuNumber = entityToClone.CpuNumber;
      newEntity.CpuUid = entityToClone.CpuUid;
      newEntity.AccessGroupLoadToCpuUid = entityToClone.AccessGroupLoadToCpuUid;
      newEntity.ServerAddress = entityToClone.ServerAddress;
      newEntity.IsConnected = entityToClone.IsConnected;

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
      
      props.Add(PDSAProperty.Create(AccessGroup_GetPanelLoadDataChangesPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_AccessGroup_GetPanelLoadDataChangesPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_AccessGroup_GetPanelLoadDataChangesPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(AccessGroup_GetPanelLoadDataChangesPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(AccessGroup_GetPanelLoadDataChangesPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(AccessGroup_GetPanelLoadDataChangesPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the AccessGroup_GetPanelLoadDataChangesPDSA class.
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
    /// Returns 'ClusterGroupId'
    /// </summary>
    public static string ClusterGroupId = "ClusterGroupId";
    /// <summary>
    /// Returns 'ClusterNumber'
    /// </summary>
    public static string ClusterNumber = "ClusterNumber";
    /// <summary>
    /// Returns 'PanelNumber'
    /// </summary>
    public static string PanelNumber = "PanelNumber";
    /// <summary>
    /// Returns 'GalaxyPanelUid'
    /// </summary>
    public static string GalaxyPanelUid = "GalaxyPanelUid";
    /// <summary>
    /// Returns 'CpuNumber'
    /// </summary>
    public static string CpuNumber = "CpuNumber";
    /// <summary>
    /// Returns 'CpuUid'
    /// </summary>
    public static string CpuUid = "CpuUid";
    /// <summary>
    /// Returns 'AccessGroupLoadToCpuUid'
    /// </summary>
    public static string AccessGroupLoadToCpuUid = "AccessGroupLoadToCpuUid";
    /// <summary>
    /// Returns 'ServerAddress'
    /// </summary>
    public static string ServerAddress = "ServerAddress";
    /// <summary>
    /// Returns 'IsConnected'
    /// </summary>
    public static string IsConnected = "IsConnected";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the AccessGroup_GetPanelLoadDataChangesPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}

using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the GetEntityIdForGalaxyPanel_ByHardwareAddressPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class GetEntityIdForGalaxyPanel_ByHardwareAddressPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private GetEntityIdForGalaxyPanel_ByHardwareAddressPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new GetEntityIdForGalaxyPanel_ByHardwareAddressPDSA Entity
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
    /// Clones the current GetEntityIdForGalaxyPanel_ByHardwareAddressPDSA
    /// </summary>
    /// <returns>A cloned GetEntityIdForGalaxyPanel_ByHardwareAddressPDSA object</returns>
    public GetEntityIdForGalaxyPanel_ByHardwareAddressPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in GetEntityIdForGalaxyPanel_ByHardwareAddressPDSA
    /// </summary>
    /// <param name="entityToClone">The GetEntityIdForGalaxyPanel_ByHardwareAddressPDSA entity to clone</param>
    /// <returns>A cloned GetEntityIdForGalaxyPanel_ByHardwareAddressPDSA object</returns>
    public GetEntityIdForGalaxyPanel_ByHardwareAddressPDSA CloneEntity(GetEntityIdForGalaxyPanel_ByHardwareAddressPDSA entityToClone)
    {
      GetEntityIdForGalaxyPanel_ByHardwareAddressPDSA newEntity = new GetEntityIdForGalaxyPanel_ByHardwareAddressPDSA();

      newEntity.EntityId = entityToClone.EntityId;

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
      
      props.Add(PDSAProperty.Create(GetEntityIdForGalaxyPanel_ByHardwareAddressPDSAValidator.ParameterNames.clusterGroupId, GetResourceMessage("GCS_GetEntityIdForGalaxyPanel_ByHardwareAddressPDSA_clusterGroupId_Header", "cluster Group Id"), false, typeof(int), 0, GetResourceMessage("GCS_GetEntityIdForGalaxyPanel_ByHardwareAddressPDSA_clusterGroupId_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GetEntityIdForGalaxyPanel_ByHardwareAddressPDSAValidator.ParameterNames.clusterNumber, GetResourceMessage("GCS_GetEntityIdForGalaxyPanel_ByHardwareAddressPDSA_clusterNumber_Header", "cluster Number"), false, typeof(int), 0, GetResourceMessage("GCS_GetEntityIdForGalaxyPanel_ByHardwareAddressPDSA_clusterNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GetEntityIdForGalaxyPanel_ByHardwareAddressPDSAValidator.ParameterNames.panelNumber, GetResourceMessage("GCS_GetEntityIdForGalaxyPanel_ByHardwareAddressPDSA_panelNumber_Header", "panel Number"), false, typeof(int), 0, GetResourceMessage("GCS_GetEntityIdForGalaxyPanel_ByHardwareAddressPDSA_panelNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GetEntityIdForGalaxyPanel_ByHardwareAddressPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_GetEntityIdForGalaxyPanel_ByHardwareAddressPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_GetEntityIdForGalaxyPanel_ByHardwareAddressPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(GetEntityIdForGalaxyPanel_ByHardwareAddressPDSAValidator.ParameterNames.clusterGroupId).Value = Entity.clusterGroupId;
      this.Properties.GetByName(GetEntityIdForGalaxyPanel_ByHardwareAddressPDSAValidator.ParameterNames.clusterNumber).Value = Entity.clusterNumber;
      this.Properties.GetByName(GetEntityIdForGalaxyPanel_ByHardwareAddressPDSAValidator.ParameterNames.panelNumber).Value = Entity.panelNumber;
      this.Properties.GetByName(GetEntityIdForGalaxyPanel_ByHardwareAddressPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(GetEntityIdForGalaxyPanel_ByHardwareAddressPDSAValidator.ParameterNames.clusterGroupId).IsNull == false)
        Entity.clusterGroupId = this.Properties.GetByName(GetEntityIdForGalaxyPanel_ByHardwareAddressPDSAValidator.ParameterNames.clusterGroupId).GetAsInteger();
      if(this.Properties.GetByName(GetEntityIdForGalaxyPanel_ByHardwareAddressPDSAValidator.ParameterNames.clusterNumber).IsNull == false)
        Entity.clusterNumber = this.Properties.GetByName(GetEntityIdForGalaxyPanel_ByHardwareAddressPDSAValidator.ParameterNames.clusterNumber).GetAsInteger();
      if(this.Properties.GetByName(GetEntityIdForGalaxyPanel_ByHardwareAddressPDSAValidator.ParameterNames.panelNumber).IsNull == false)
        Entity.panelNumber = this.Properties.GetByName(GetEntityIdForGalaxyPanel_ByHardwareAddressPDSAValidator.ParameterNames.panelNumber).GetAsInteger();
      if(this.Properties.GetByName(GetEntityIdForGalaxyPanel_ByHardwareAddressPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(GetEntityIdForGalaxyPanel_ByHardwareAddressPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the GetEntityIdForGalaxyPanel_ByHardwareAddressPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'EntityId'
    /// </summary>
    public static string EntityId = "EntityId";
    /// <summary>
    /// Returns '@clusterGroupId'
    /// </summary>
    public static string clusterGroupId = "@clusterGroupId";
    /// <summary>
    /// Returns '@clusterNumber'
    /// </summary>
    public static string clusterNumber = "@clusterNumber";
    /// <summary>
    /// Returns '@panelNumber'
    /// </summary>
    public static string panelNumber = "@panelNumber";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the GetEntityIdForGalaxyPanel_ByHardwareAddressPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@clusterGroupId'
    /// </summary>
    public static string clusterGroupId = "@clusterGroupId";
    /// <summary>
    /// Returns '@clusterNumber'
    /// </summary>
    public static string clusterNumber = "@clusterNumber";
    /// <summary>
    /// Returns '@panelNumber'
    /// </summary>
    public static string panelNumber = "@panelNumber";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}

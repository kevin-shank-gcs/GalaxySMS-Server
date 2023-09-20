using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the GalaxyPanelUid_GetByAccessPortalUidPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class GalaxyPanelUid_GetByAccessPortalUidPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private GalaxyPanelUid_GetByAccessPortalUidPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new GalaxyPanelUid_GetByAccessPortalUidPDSA Entity
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
    /// Clones the current GalaxyPanelUid_GetByAccessPortalUidPDSA
    /// </summary>
    /// <returns>A cloned GalaxyPanelUid_GetByAccessPortalUidPDSA object</returns>
    public GalaxyPanelUid_GetByAccessPortalUidPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in GalaxyPanelUid_GetByAccessPortalUidPDSA
    /// </summary>
    /// <param name="entityToClone">The GalaxyPanelUid_GetByAccessPortalUidPDSA entity to clone</param>
    /// <returns>A cloned GalaxyPanelUid_GetByAccessPortalUidPDSA object</returns>
    public GalaxyPanelUid_GetByAccessPortalUidPDSA CloneEntity(GalaxyPanelUid_GetByAccessPortalUidPDSA entityToClone)
    {
      GalaxyPanelUid_GetByAccessPortalUidPDSA newEntity = new GalaxyPanelUid_GetByAccessPortalUidPDSA();

      newEntity.GalaxyPanelUid = entityToClone.GalaxyPanelUid;

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
      
      props.Add(PDSAProperty.Create(GalaxyPanelUid_GetByAccessPortalUidPDSAValidator.ParameterNames.accessPortalUid, GetResourceMessage("GCS_GalaxyPanelUid_GetByAccessPortalUidPDSA_accessPortalUid_Header", "access Portal Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_GalaxyPanelUid_GetByAccessPortalUidPDSA_accessPortalUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyPanelUid_GetByAccessPortalUidPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_GalaxyPanelUid_GetByAccessPortalUidPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_GalaxyPanelUid_GetByAccessPortalUidPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(GalaxyPanelUid_GetByAccessPortalUidPDSAValidator.ParameterNames.accessPortalUid).Value = Entity.accessPortalUid;
      this.Properties.GetByName(GalaxyPanelUid_GetByAccessPortalUidPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(GalaxyPanelUid_GetByAccessPortalUidPDSAValidator.ParameterNames.accessPortalUid).IsNull == false)
        Entity.accessPortalUid = this.Properties.GetByName(GalaxyPanelUid_GetByAccessPortalUidPDSAValidator.ParameterNames.accessPortalUid).GetAsGuid();
      if(this.Properties.GetByName(GalaxyPanelUid_GetByAccessPortalUidPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(GalaxyPanelUid_GetByAccessPortalUidPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the GalaxyPanelUid_GetByAccessPortalUidPDSA class.
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
    /// Returns '@accessPortalUid'
    /// </summary>
    public static string accessPortalUid = "@accessPortalUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the GalaxyPanelUid_GetByAccessPortalUidPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@accessPortalUid'
    /// </summary>
    public static string accessPortalUid = "@accessPortalUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}

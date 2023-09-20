using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the MercScpGroup_GetAllUidsFromRoleIdAndSiteUidPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class MercScpGroup_GetAllUidsFromRoleIdAndSiteUidPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private MercScpGroup_GetAllUidsFromRoleIdAndSiteUidPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new MercScpGroup_GetAllUidsFromRoleIdAndSiteUidPDSA Entity
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
    /// Clones the current MercScpGroup_GetAllUidsFromRoleIdAndSiteUidPDSA
    /// </summary>
    /// <returns>A cloned MercScpGroup_GetAllUidsFromRoleIdAndSiteUidPDSA object</returns>
    public MercScpGroup_GetAllUidsFromRoleIdAndSiteUidPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in MercScpGroup_GetAllUidsFromRoleIdAndSiteUidPDSA
    /// </summary>
    /// <param name="entityToClone">The MercScpGroup_GetAllUidsFromRoleIdAndSiteUidPDSA entity to clone</param>
    /// <returns>A cloned MercScpGroup_GetAllUidsFromRoleIdAndSiteUidPDSA object</returns>
    public MercScpGroup_GetAllUidsFromRoleIdAndSiteUidPDSA CloneEntity(MercScpGroup_GetAllUidsFromRoleIdAndSiteUidPDSA entityToClone)
    {
      MercScpGroup_GetAllUidsFromRoleIdAndSiteUidPDSA newEntity = new MercScpGroup_GetAllUidsFromRoleIdAndSiteUidPDSA();

      newEntity.MercScpGroupUid = entityToClone.MercScpGroupUid;

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
      
      props.Add(PDSAProperty.Create(MercScpGroup_GetAllUidsFromRoleIdAndSiteUidPDSAValidator.ParameterNames.RoleId, GetResourceMessage("GCS_MercScpGroup_GetAllUidsFromRoleIdAndSiteUidPDSA_RoleId_Header", "Role Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_MercScpGroup_GetAllUidsFromRoleIdAndSiteUidPDSA_RoleId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(MercScpGroup_GetAllUidsFromRoleIdAndSiteUidPDSAValidator.ParameterNames.SiteUid, GetResourceMessage("GCS_MercScpGroup_GetAllUidsFromRoleIdAndSiteUidPDSA_SiteUid_Header", "Site Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_MercScpGroup_GetAllUidsFromRoleIdAndSiteUidPDSA_SiteUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(MercScpGroup_GetAllUidsFromRoleIdAndSiteUidPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_MercScpGroup_GetAllUidsFromRoleIdAndSiteUidPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_MercScpGroup_GetAllUidsFromRoleIdAndSiteUidPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(MercScpGroup_GetAllUidsFromRoleIdAndSiteUidPDSAValidator.ParameterNames.RoleId).Value = Entity.RoleId;
      this.Properties.GetByName(MercScpGroup_GetAllUidsFromRoleIdAndSiteUidPDSAValidator.ParameterNames.SiteUid).Value = Entity.SiteUid;
      this.Properties.GetByName(MercScpGroup_GetAllUidsFromRoleIdAndSiteUidPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(MercScpGroup_GetAllUidsFromRoleIdAndSiteUidPDSAValidator.ParameterNames.RoleId).IsNull == false)
        Entity.RoleId = this.Properties.GetByName(MercScpGroup_GetAllUidsFromRoleIdAndSiteUidPDSAValidator.ParameterNames.RoleId).GetAsGuid();
      if(this.Properties.GetByName(MercScpGroup_GetAllUidsFromRoleIdAndSiteUidPDSAValidator.ParameterNames.SiteUid).IsNull == false)
        Entity.SiteUid = this.Properties.GetByName(MercScpGroup_GetAllUidsFromRoleIdAndSiteUidPDSAValidator.ParameterNames.SiteUid).GetAsGuid();
      if(this.Properties.GetByName(MercScpGroup_GetAllUidsFromRoleIdAndSiteUidPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(MercScpGroup_GetAllUidsFromRoleIdAndSiteUidPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the MercScpGroup_GetAllUidsFromRoleIdAndSiteUidPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'MercScpGroupUid'
    /// </summary>
    public static string MercScpGroupUid = "MercScpGroupUid";
    /// <summary>
    /// Returns '@RoleId'
    /// </summary>
    public static string RoleId = "@RoleId";
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

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the MercScpGroup_GetAllUidsFromRoleIdAndSiteUidPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@RoleId'
    /// </summary>
    public static string RoleId = "@RoleId";
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

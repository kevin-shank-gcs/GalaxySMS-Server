using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsSiteUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsSiteUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsSiteUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsSiteUniquePDSA Entity
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
    /// Clones the current IsSiteUniquePDSA
    /// </summary>
    /// <returns>A cloned IsSiteUniquePDSA object</returns>
    public IsSiteUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsSiteUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsSiteUniquePDSA entity to clone</param>
    /// <returns>A cloned IsSiteUniquePDSA object</returns>
    public IsSiteUniquePDSA CloneEntity(IsSiteUniquePDSA entityToClone)
    {
      IsSiteUniquePDSA newEntity = new IsSiteUniquePDSA();

      newEntity.Result = entityToClone.Result;

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
      
      props.Add(PDSAProperty.Create(IsSiteUniquePDSAValidator.ParameterNames.SiteUid, GetResourceMessage("GCS_IsSiteUniquePDSA_SiteUid_Header", "Site Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsSiteUniquePDSA_SiteUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsSiteUniquePDSAValidator.ParameterNames.SiteId, GetResourceMessage("GCS_IsSiteUniquePDSA_SiteId_Header", "Site Id"), false, typeof(string), 8000, GetResourceMessage("GCS_IsSiteUniquePDSA_SiteId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsSiteUniquePDSAValidator.ParameterNames.SiteName, GetResourceMessage("GCS_IsSiteUniquePDSA_SiteName_Header", "Site Name"), false, typeof(string), 8000, GetResourceMessage("GCS_IsSiteUniquePDSA_SiteName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsSiteUniquePDSAValidator.ParameterNames.RegionUid, GetResourceMessage("GCS_IsSiteUniquePDSA_RegionUid_Header", "Region Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsSiteUniquePDSA_RegionUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsSiteUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsSiteUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsSiteUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsSiteUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsSiteUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsSiteUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsSiteUniquePDSAValidator.ParameterNames.SiteUid).Value = Entity.SiteUid;
      this.Properties.GetByName(IsSiteUniquePDSAValidator.ParameterNames.SiteId).Value = Entity.SiteId;
      this.Properties.GetByName(IsSiteUniquePDSAValidator.ParameterNames.SiteName).Value = Entity.SiteName;
      this.Properties.GetByName(IsSiteUniquePDSAValidator.ParameterNames.RegionUid).Value = Entity.RegionUid;
      this.Properties.GetByName(IsSiteUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsSiteUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsSiteUniquePDSAValidator.ParameterNames.SiteUid).IsNull == false)
        Entity.SiteUid = this.Properties.GetByName(IsSiteUniquePDSAValidator.ParameterNames.SiteUid).GetAsGuid();
      if(this.Properties.GetByName(IsSiteUniquePDSAValidator.ParameterNames.SiteId).IsNull == false)
        Entity.SiteId = this.Properties.GetByName(IsSiteUniquePDSAValidator.ParameterNames.SiteId).GetAsString();
      if(this.Properties.GetByName(IsSiteUniquePDSAValidator.ParameterNames.SiteName).IsNull == false)
        Entity.SiteName = this.Properties.GetByName(IsSiteUniquePDSAValidator.ParameterNames.SiteName).GetAsString();
      if(this.Properties.GetByName(IsSiteUniquePDSAValidator.ParameterNames.RegionUid).IsNull == false)
        Entity.RegionUid = this.Properties.GetByName(IsSiteUniquePDSAValidator.ParameterNames.RegionUid).GetAsGuid();
      if(this.Properties.GetByName(IsSiteUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsSiteUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsSiteUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsSiteUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsSiteUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'Result'
    /// </summary>
    public static string Result = "Result";
    /// <summary>
    /// Returns '@SiteUid'
    /// </summary>
    public static string SiteUid = "@SiteUid";
    /// <summary>
    /// Returns '@SiteId'
    /// </summary>
    public static string SiteId = "@SiteId";
    /// <summary>
    /// Returns '@SiteName'
    /// </summary>
    public static string SiteName = "@SiteName";
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

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsSiteUniquePDSA class.
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
    /// Returns '@SiteId'
    /// </summary>
    public static string SiteId = "@SiteId";
    /// <summary>
    /// Returns '@SiteName'
    /// </summary>
    public static string SiteName = "@SiteName";
    /// <summary>
    /// Returns '@RegionUid'
    /// </summary>
    public static string RegionUid = "@RegionUid";
    /// <summary>
    /// Returns '@Result'
    /// </summary>
    public static string Result = "@Result";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}

using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsSiteEntityMapUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsSiteEntityMapUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsSiteEntityMapUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsSiteEntityMapUniquePDSA Entity
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
    /// Clones the current IsSiteEntityMapUniquePDSA
    /// </summary>
    /// <returns>A cloned IsSiteEntityMapUniquePDSA object</returns>
    public IsSiteEntityMapUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsSiteEntityMapUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsSiteEntityMapUniquePDSA entity to clone</param>
    /// <returns>A cloned IsSiteEntityMapUniquePDSA object</returns>
    public IsSiteEntityMapUniquePDSA CloneEntity(IsSiteEntityMapUniquePDSA entityToClone)
    {
      IsSiteEntityMapUniquePDSA newEntity = new IsSiteEntityMapUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsSiteEntityMapUniquePDSAValidator.ParameterNames.SiteEntityMapUid, GetResourceMessage("GCS_IsSiteEntityMapUniquePDSA_SiteEntityMapUid_Header", "Site Entity Map Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsSiteEntityMapUniquePDSA_SiteEntityMapUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsSiteEntityMapUniquePDSAValidator.ParameterNames.SiteUid, GetResourceMessage("GCS_IsSiteEntityMapUniquePDSA_SiteUid_Header", "Site Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsSiteEntityMapUniquePDSA_SiteUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsSiteEntityMapUniquePDSAValidator.ParameterNames.EntityId, GetResourceMessage("GCS_IsSiteEntityMapUniquePDSA_EntityId_Header", "Entity Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsSiteEntityMapUniquePDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsSiteEntityMapUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsSiteEntityMapUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsSiteEntityMapUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsSiteEntityMapUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsSiteEntityMapUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsSiteEntityMapUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsSiteEntityMapUniquePDSAValidator.ParameterNames.SiteEntityMapUid).Value = Entity.SiteEntityMapUid;
      this.Properties.GetByName(IsSiteEntityMapUniquePDSAValidator.ParameterNames.SiteUid).Value = Entity.SiteUid;
      this.Properties.GetByName(IsSiteEntityMapUniquePDSAValidator.ParameterNames.EntityId).Value = Entity.EntityId;
      this.Properties.GetByName(IsSiteEntityMapUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsSiteEntityMapUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsSiteEntityMapUniquePDSAValidator.ParameterNames.SiteEntityMapUid).IsNull == false)
        Entity.SiteEntityMapUid = this.Properties.GetByName(IsSiteEntityMapUniquePDSAValidator.ParameterNames.SiteEntityMapUid).GetAsGuid();
      if(this.Properties.GetByName(IsSiteEntityMapUniquePDSAValidator.ParameterNames.SiteUid).IsNull == false)
        Entity.SiteUid = this.Properties.GetByName(IsSiteEntityMapUniquePDSAValidator.ParameterNames.SiteUid).GetAsGuid();
      if(this.Properties.GetByName(IsSiteEntityMapUniquePDSAValidator.ParameterNames.EntityId).IsNull == false)
        Entity.EntityId = this.Properties.GetByName(IsSiteEntityMapUniquePDSAValidator.ParameterNames.EntityId).GetAsGuid();
      if(this.Properties.GetByName(IsSiteEntityMapUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsSiteEntityMapUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsSiteEntityMapUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsSiteEntityMapUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsSiteEntityMapUniquePDSA class.
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
    /// Returns '@SiteEntityMapUid'
    /// </summary>
    public static string SiteEntityMapUid = "@SiteEntityMapUid";
    /// <summary>
    /// Returns '@SiteUid'
    /// </summary>
    public static string SiteUid = "@SiteUid";
    /// <summary>
    /// Returns '@EntityId'
    /// </summary>
    public static string EntityId = "@EntityId";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsSiteEntityMapUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@SiteEntityMapUid'
    /// </summary>
    public static string SiteEntityMapUid = "@SiteEntityMapUid";
    /// <summary>
    /// Returns '@SiteUid'
    /// </summary>
    public static string SiteUid = "@SiteUid";
    /// <summary>
    /// Returns '@EntityId'
    /// </summary>
    public static string EntityId = "@EntityId";
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

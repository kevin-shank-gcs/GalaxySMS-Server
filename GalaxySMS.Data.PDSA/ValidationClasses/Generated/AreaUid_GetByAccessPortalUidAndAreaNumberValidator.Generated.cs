using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the AreaUid_GetByAccessPortalUidAndAreaNumberPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class AreaUid_GetByAccessPortalUidAndAreaNumberPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private AreaUid_GetByAccessPortalUidAndAreaNumberPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new AreaUid_GetByAccessPortalUidAndAreaNumberPDSA Entity
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
    /// Clones the current AreaUid_GetByAccessPortalUidAndAreaNumberPDSA
    /// </summary>
    /// <returns>A cloned AreaUid_GetByAccessPortalUidAndAreaNumberPDSA object</returns>
    public AreaUid_GetByAccessPortalUidAndAreaNumberPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in AreaUid_GetByAccessPortalUidAndAreaNumberPDSA
    /// </summary>
    /// <param name="entityToClone">The AreaUid_GetByAccessPortalUidAndAreaNumberPDSA entity to clone</param>
    /// <returns>A cloned AreaUid_GetByAccessPortalUidAndAreaNumberPDSA object</returns>
    public AreaUid_GetByAccessPortalUidAndAreaNumberPDSA CloneEntity(AreaUid_GetByAccessPortalUidAndAreaNumberPDSA entityToClone)
    {
      AreaUid_GetByAccessPortalUidAndAreaNumberPDSA newEntity = new AreaUid_GetByAccessPortalUidAndAreaNumberPDSA();

      newEntity.AreaUid = entityToClone.AreaUid;

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
      
      props.Add(PDSAProperty.Create(AreaUid_GetByAccessPortalUidAndAreaNumberPDSAValidator.ParameterNames.accessPortalUid, GetResourceMessage("GCS_AreaUid_GetByAccessPortalUidAndAreaNumberPDSA_accessPortalUid_Header", "access Portal Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_AreaUid_GetByAccessPortalUidAndAreaNumberPDSA_accessPortalUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AreaUid_GetByAccessPortalUidAndAreaNumberPDSAValidator.ParameterNames.areaNumber, GetResourceMessage("GCS_AreaUid_GetByAccessPortalUidAndAreaNumberPDSA_areaNumber_Header", "area Number"), false, typeof(int), 0, GetResourceMessage("GCS_AreaUid_GetByAccessPortalUidAndAreaNumberPDSA_areaNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(AreaUid_GetByAccessPortalUidAndAreaNumberPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_AreaUid_GetByAccessPortalUidAndAreaNumberPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_AreaUid_GetByAccessPortalUidAndAreaNumberPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(AreaUid_GetByAccessPortalUidAndAreaNumberPDSAValidator.ParameterNames.accessPortalUid).Value = Entity.accessPortalUid;
      this.Properties.GetByName(AreaUid_GetByAccessPortalUidAndAreaNumberPDSAValidator.ParameterNames.areaNumber).Value = Entity.areaNumber;
      this.Properties.GetByName(AreaUid_GetByAccessPortalUidAndAreaNumberPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(AreaUid_GetByAccessPortalUidAndAreaNumberPDSAValidator.ParameterNames.accessPortalUid).IsNull == false)
        Entity.accessPortalUid = this.Properties.GetByName(AreaUid_GetByAccessPortalUidAndAreaNumberPDSAValidator.ParameterNames.accessPortalUid).GetAsGuid();
      if(this.Properties.GetByName(AreaUid_GetByAccessPortalUidAndAreaNumberPDSAValidator.ParameterNames.areaNumber).IsNull == false)
        Entity.areaNumber = this.Properties.GetByName(AreaUid_GetByAccessPortalUidAndAreaNumberPDSAValidator.ParameterNames.areaNumber).GetAsInteger();
      if(this.Properties.GetByName(AreaUid_GetByAccessPortalUidAndAreaNumberPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(AreaUid_GetByAccessPortalUidAndAreaNumberPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the AreaUid_GetByAccessPortalUidAndAreaNumberPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'AreaUid'
    /// </summary>
    public static string AreaUid = "AreaUid";
    /// <summary>
    /// Returns '@accessPortalUid'
    /// </summary>
    public static string accessPortalUid = "@accessPortalUid";
    /// <summary>
    /// Returns '@areaNumber'
    /// </summary>
    public static string areaNumber = "@areaNumber";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the AreaUid_GetByAccessPortalUidAndAreaNumberPDSA class.
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
    /// Returns '@areaNumber'
    /// </summary>
    public static string areaNumber = "@areaNumber";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}

using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the AccessGroup_GetPersonInfoPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class AccessGroup_GetPersonInfoPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private AccessGroup_GetPersonInfoPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new AccessGroup_GetPersonInfoPDSA Entity
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
    /// Clones the current AccessGroup_GetPersonInfoPDSA
    /// </summary>
    /// <returns>A cloned AccessGroup_GetPersonInfoPDSA object</returns>
    public AccessGroup_GetPersonInfoPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in AccessGroup_GetPersonInfoPDSA
    /// </summary>
    /// <param name="entityToClone">The AccessGroup_GetPersonInfoPDSA entity to clone</param>
    /// <returns>A cloned AccessGroup_GetPersonInfoPDSA object</returns>
    public AccessGroup_GetPersonInfoPDSA CloneEntity(AccessGroup_GetPersonInfoPDSA entityToClone)
    {
      AccessGroup_GetPersonInfoPDSA newEntity = new AccessGroup_GetPersonInfoPDSA();

      newEntity.Id = entityToClone.Id;
      newEntity.FirstName = entityToClone.FirstName;
      newEntity.LastName = entityToClone.LastName;
      newEntity.DepartmentUid = entityToClone.DepartmentUid;
      newEntity.DepartmentName = entityToClone.DepartmentName;
      newEntity.SmallPhotoURL = entityToClone.SmallPhotoURL;
      newEntity.ActiveStatusCode = entityToClone.ActiveStatusCode;
      newEntity.LastUsageActivityDateTime = entityToClone.LastUsageActivityDateTime;
      newEntity.LastUsageAccessPortal = entityToClone.LastUsageAccessPortal;
      newEntity.LastUsageClusterName = entityToClone.LastUsageClusterName;
      newEntity.LastUsageSiteName = entityToClone.LastUsageSiteName;
      newEntity.LastUsageEntityName = entityToClone.LastUsageEntityName;
      newEntity.LastCredentialName = entityToClone.LastCredentialName;
      newEntity.TotalRowCount = entityToClone.TotalRowCount;

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
      
      props.Add(PDSAProperty.Create(AccessGroup_GetPersonInfoPDSAValidator.ParameterNames.AccessGroupUid, GetResourceMessage("GCS_AccessGroup_GetPersonInfoPDSA_AccessGroupUid_Header", "Access Group Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_AccessGroup_GetPersonInfoPDSA_AccessGroupUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessGroup_GetPersonInfoPDSAValidator.ParameterNames.PageNumber, GetResourceMessage("GCS_AccessGroup_GetPersonInfoPDSA_PageNumber_Header", "Page Number"), false, typeof(int), 0, GetResourceMessage("GCS_AccessGroup_GetPersonInfoPDSA_PageNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(AccessGroup_GetPersonInfoPDSAValidator.ParameterNames.PageSize, GetResourceMessage("GCS_AccessGroup_GetPersonInfoPDSA_PageSize_Header", "Page Size"), false, typeof(int), 0, GetResourceMessage("GCS_AccessGroup_GetPersonInfoPDSA_PageSize_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(AccessGroup_GetPersonInfoPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_AccessGroup_GetPersonInfoPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_AccessGroup_GetPersonInfoPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(AccessGroup_GetPersonInfoPDSAValidator.ParameterNames.AccessGroupUid).Value = Entity.AccessGroupUid;
      this.Properties.GetByName(AccessGroup_GetPersonInfoPDSAValidator.ParameterNames.PageNumber).Value = Entity.PageNumber;
      this.Properties.GetByName(AccessGroup_GetPersonInfoPDSAValidator.ParameterNames.PageSize).Value = Entity.PageSize;
      this.Properties.GetByName(AccessGroup_GetPersonInfoPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(AccessGroup_GetPersonInfoPDSAValidator.ParameterNames.AccessGroupUid).IsNull == false)
        Entity.AccessGroupUid = this.Properties.GetByName(AccessGroup_GetPersonInfoPDSAValidator.ParameterNames.AccessGroupUid).GetAsGuid();
      if(this.Properties.GetByName(AccessGroup_GetPersonInfoPDSAValidator.ParameterNames.PageNumber).IsNull == false)
        Entity.PageNumber = this.Properties.GetByName(AccessGroup_GetPersonInfoPDSAValidator.ParameterNames.PageNumber).GetAsInteger();
      if(this.Properties.GetByName(AccessGroup_GetPersonInfoPDSAValidator.ParameterNames.PageSize).IsNull == false)
        Entity.PageSize = this.Properties.GetByName(AccessGroup_GetPersonInfoPDSAValidator.ParameterNames.PageSize).GetAsInteger();
      if(this.Properties.GetByName(AccessGroup_GetPersonInfoPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(AccessGroup_GetPersonInfoPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the AccessGroup_GetPersonInfoPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'Id'
    /// </summary>
    public static string Id = "Id";
    /// <summary>
    /// Returns 'FirstName'
    /// </summary>
    public static string FirstName = "FirstName";
    /// <summary>
    /// Returns 'LastName'
    /// </summary>
    public static string LastName = "LastName";
    /// <summary>
    /// Returns 'DepartmentUid'
    /// </summary>
    public static string DepartmentUid = "DepartmentUid";
    /// <summary>
    /// Returns 'DepartmentName'
    /// </summary>
    public static string DepartmentName = "DepartmentName";
    /// <summary>
    /// Returns 'SmallPhotoURL'
    /// </summary>
    public static string SmallPhotoURL = "SmallPhotoURL";
    /// <summary>
    /// Returns 'ActiveStatusCode'
    /// </summary>
    public static string ActiveStatusCode = "ActiveStatusCode";
    /// <summary>
    /// Returns 'LastUsageActivityDateTime'
    /// </summary>
    public static string LastUsageActivityDateTime = "LastUsageActivityDateTime";
    /// <summary>
    /// Returns 'LastUsageAccessPortal'
    /// </summary>
    public static string LastUsageAccessPortal = "LastUsageAccessPortal";
    /// <summary>
    /// Returns 'LastUsageClusterName'
    /// </summary>
    public static string LastUsageClusterName = "LastUsageClusterName";
    /// <summary>
    /// Returns 'LastUsageSiteName'
    /// </summary>
    public static string LastUsageSiteName = "LastUsageSiteName";
    /// <summary>
    /// Returns 'LastUsageEntityName'
    /// </summary>
    public static string LastUsageEntityName = "LastUsageEntityName";
    /// <summary>
    /// Returns 'LastCredentialName'
    /// </summary>
    public static string LastCredentialName = "LastCredentialName";
    /// <summary>
    /// Returns 'TotalRowCount'
    /// </summary>
    public static string TotalRowCount = "TotalRowCount";
    /// <summary>
    /// Returns '@AccessGroupUid'
    /// </summary>
    public static string AccessGroupUid = "@AccessGroupUid";
    /// <summary>
    /// Returns '@PageNumber'
    /// </summary>
    public static string PageNumber = "@PageNumber";
    /// <summary>
    /// Returns '@PageSize'
    /// </summary>
    public static string PageSize = "@PageSize";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the AccessGroup_GetPersonInfoPDSA class.
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
    /// Returns '@PageNumber'
    /// </summary>
    public static string PageNumber = "@PageNumber";
    /// <summary>
    /// Returns '@PageSize'
    /// </summary>
    public static string PageSize = "@PageSize";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}

using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the PersonSummary_SearchWithParamsExPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class PersonSummary_SearchWithParamsExPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private PersonSummary_SearchWithParamsExPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new PersonSummary_SearchWithParamsExPDSA Entity
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
    /// Clones the current PersonSummary_SearchWithParamsExPDSA
    /// </summary>
    /// <returns>A cloned PersonSummary_SearchWithParamsExPDSA object</returns>
    public PersonSummary_SearchWithParamsExPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in PersonSummary_SearchWithParamsExPDSA
    /// </summary>
    /// <param name="entityToClone">The PersonSummary_SearchWithParamsExPDSA entity to clone</param>
    /// <returns>A cloned PersonSummary_SearchWithParamsExPDSA object</returns>
    public PersonSummary_SearchWithParamsExPDSA CloneEntity(PersonSummary_SearchWithParamsExPDSA entityToClone)
    {
      PersonSummary_SearchWithParamsExPDSA newEntity = new PersonSummary_SearchWithParamsExPDSA();

      newEntity.PersonUid = entityToClone.PersonUid;
      newEntity.PersonId = entityToClone.PersonId;
      newEntity.FirstName = entityToClone.FirstName;
      newEntity.MiddleName = entityToClone.MiddleName;
      newEntity.LastName = entityToClone.LastName;
      newEntity.NickName = entityToClone.NickName;
      newEntity.LegalName = entityToClone.LegalName;
      newEntity.FullName = entityToClone.FullName;
      newEntity.PreferredName = entityToClone.PreferredName;
      newEntity.Company = entityToClone.Company;
      newEntity.Trace = entityToClone.Trace;
      newEntity.VeryImportantPerson = entityToClone.VeryImportantPerson;
      newEntity.HasPhysicalDisability = entityToClone.HasPhysicalDisability;
      newEntity.EntityName = entityToClone.EntityName;
      newEntity.DepartmentName = entityToClone.DepartmentName;
      newEntity.EntityId = entityToClone.EntityId;
      newEntity.ActivationDateTime = entityToClone.ActivationDateTime;
      newEntity.ExpirationDateTime = entityToClone.ExpirationDateTime;
      newEntity.InsertName = entityToClone.InsertName;
      newEntity.InsertDate = entityToClone.InsertDate;
      newEntity.UpdateName = entityToClone.UpdateName;
      newEntity.UpdateDate = entityToClone.UpdateDate;
      newEntity.SysGalEmployeeId = entityToClone.SysGalEmployeeId;
      newEntity.ActiveStatusCode = entityToClone.ActiveStatusCode;
      newEntity.LastUsageActivityDateTime = entityToClone.LastUsageActivityDateTime;
      newEntity.LastUsageAccessPortal = entityToClone.LastUsageAccessPortal;
      newEntity.LastUsageClusterName = entityToClone.LastUsageClusterName;
      newEntity.LastUsageSiteName = entityToClone.LastUsageSiteName;
      newEntity.LastUsageEntityName = entityToClone.LastUsageEntityName;
      newEntity.LastCredentialName = entityToClone.LastCredentialName;
      newEntity.ActiveStatus = entityToClone.ActiveStatus;
      newEntity.RecordType = entityToClone.RecordType;
      newEntity.SearchField = entityToClone.SearchField;
      newEntity.TotalCardCount = entityToClone.TotalCardCount;
      newEntity.TotalPersonCount = entityToClone.TotalPersonCount;

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
      
      props.Add(PDSAProperty.Create(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.EntityId, GetResourceMessage("GCS_PersonSummary_SearchWithParamsExPDSA_EntityId_Header", "Entity Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_PersonSummary_SearchWithParamsExPDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.QueryText, GetResourceMessage("GCS_PersonSummary_SearchWithParamsExPDSA_QueryText_Header", "Query Text"), false, typeof(string), 8000, GetResourceMessage("GCS_PersonSummary_SearchWithParamsExPDSA_QueryText_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.DepartmentUids, GetResourceMessage("GCS_PersonSummary_SearchWithParamsExPDSA_DepartmentUids_Header", "Department Uids"), false, typeof(string), 8000, GetResourceMessage("GCS_PersonSummary_SearchWithParamsExPDSA_DepartmentUids_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.AccessProfileUids, GetResourceMessage("GCS_PersonSummary_SearchWithParamsExPDSA_AccessProfileUids_Header", "Access Profile Uids"), false, typeof(string), 8000, GetResourceMessage("GCS_PersonSummary_SearchWithParamsExPDSA_AccessProfileUids_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.ClusterUids, GetResourceMessage("GCS_PersonSummary_SearchWithParamsExPDSA_ClusterUids_Header", "Cluster Uids"), false, typeof(string), 8000, GetResourceMessage("GCS_PersonSummary_SearchWithParamsExPDSA_ClusterUids_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.PersonRecordTypeUids, GetResourceMessage("GCS_PersonSummary_SearchWithParamsExPDSA_PersonRecordTypeUids_Header", "Person Record Type Uids"), false, typeof(string), 8000, GetResourceMessage("GCS_PersonSummary_SearchWithParamsExPDSA_PersonRecordTypeUids_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.PersonIds, GetResourceMessage("GCS_PersonSummary_SearchWithParamsExPDSA_PersonIds_Header", "Person Ids"), false, typeof(string), 8000, GetResourceMessage("GCS_PersonSummary_SearchWithParamsExPDSA_PersonIds_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.Gender, GetResourceMessage("GCS_PersonSummary_SearchWithParamsExPDSA_Gender_Header", "Gender"), false, typeof(string), 8000, GetResourceMessage("GCS_PersonSummary_SearchWithParamsExPDSA_Gender_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.DateOfBirth, GetResourceMessage("GCS_PersonSummary_SearchWithParamsExPDSA_DateOfBirth_Header", "Date Of Birth"), false, typeof(DateTime), 0, GetResourceMessage("GCS_PersonSummary_SearchWithParamsExPDSA_DateOfBirth_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToDateTime("1753-01-01 00:00:00", System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat), Convert.ToDateTime("9999-12-31 23:59:59", System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat), 0, Convert.ToDateTime("1753-1-1", System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat), @"", ""));
      props.Add(PDSAProperty.Create(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.IsActive, GetResourceMessage("GCS_PersonSummary_SearchWithParamsExPDSA_IsActive_Header", "Is Active"), false, typeof(bool), 0, GetResourceMessage("GCS_PersonSummary_SearchWithParamsExPDSA_IsActive_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.ActivationStart, GetResourceMessage("GCS_PersonSummary_SearchWithParamsExPDSA_ActivationStart_Header", "Activation Start"), false, typeof(DateTime), 0, GetResourceMessage("GCS_PersonSummary_SearchWithParamsExPDSA_ActivationStart_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToDateTime("1753-01-01 00:00:00", System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat), Convert.ToDateTime("9999-12-31 23:59:59", System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat), 0, Convert.ToDateTime("1753-1-1", System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat), @"", ""));
      props.Add(PDSAProperty.Create(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.ActivationEnd, GetResourceMessage("GCS_PersonSummary_SearchWithParamsExPDSA_ActivationEnd_Header", "Activation End"), false, typeof(DateTime), 0, GetResourceMessage("GCS_PersonSummary_SearchWithParamsExPDSA_ActivationEnd_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToDateTime("1753-01-01 00:00:00", System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat), Convert.ToDateTime("9999-12-31 23:59:59", System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat), 0, Convert.ToDateTime("1753-1-1", System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat), @"", ""));
      props.Add(PDSAProperty.Create(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.ExpirationStart, GetResourceMessage("GCS_PersonSummary_SearchWithParamsExPDSA_ExpirationStart_Header", "Expiration Start"), false, typeof(DateTime), 0, GetResourceMessage("GCS_PersonSummary_SearchWithParamsExPDSA_ExpirationStart_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToDateTime("1753-01-01 00:00:00", System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat), Convert.ToDateTime("9999-12-31 23:59:59", System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat), 0, Convert.ToDateTime("1753-1-1", System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat), @"", ""));
      props.Add(PDSAProperty.Create(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.ExpirationEnd, GetResourceMessage("GCS_PersonSummary_SearchWithParamsExPDSA_ExpirationEnd_Header", "Expiration End"), false, typeof(DateTime), 0, GetResourceMessage("GCS_PersonSummary_SearchWithParamsExPDSA_ExpirationEnd_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToDateTime("1753-01-01 00:00:00", System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat), Convert.ToDateTime("9999-12-31 23:59:59", System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat), 0, Convert.ToDateTime("1753-1-1", System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat), @"", ""));
      props.Add(PDSAProperty.Create(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.WithCredentials, GetResourceMessage("GCS_PersonSummary_SearchWithParamsExPDSA_WithCredentials_Header", "With Credentials"), false, typeof(bool), 0, GetResourceMessage("GCS_PersonSummary_SearchWithParamsExPDSA_WithCredentials_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.CanToggleLock, GetResourceMessage("GCS_PersonSummary_SearchWithParamsExPDSA_CanToggleLock_Header", "Can Toggle Lock"), false, typeof(bool), 0, GetResourceMessage("GCS_PersonSummary_SearchWithParamsExPDSA_CanToggleLock_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.CredentialNumbers, GetResourceMessage("GCS_PersonSummary_SearchWithParamsExPDSA_CredentialNumbers_Header", "Credential Numbers"), false, typeof(string), 8000, GetResourceMessage("GCS_PersonSummary_SearchWithParamsExPDSA_CredentialNumbers_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.OrderBy, GetResourceMessage("GCS_PersonSummary_SearchWithParamsExPDSA_OrderBy_Header", "Order By"), false, typeof(string), 8000, GetResourceMessage("GCS_PersonSummary_SearchWithParamsExPDSA_OrderBy_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.MaximumResults, GetResourceMessage("GCS_PersonSummary_SearchWithParamsExPDSA_MaximumResults_Header", "Maximum Results"), false, typeof(int), 0, GetResourceMessage("GCS_PersonSummary_SearchWithParamsExPDSA_MaximumResults_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.PageNumber, GetResourceMessage("GCS_PersonSummary_SearchWithParamsExPDSA_PageNumber_Header", "Page Number"), false, typeof(int), 0, GetResourceMessage("GCS_PersonSummary_SearchWithParamsExPDSA_PageNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.PageSize, GetResourceMessage("GCS_PersonSummary_SearchWithParamsExPDSA_PageSize_Header", "Page Size"), false, typeof(int), 0, GetResourceMessage("GCS_PersonSummary_SearchWithParamsExPDSA_PageSize_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.DateComparisonType, GetResourceMessage("GCS_PersonSummary_SearchWithParamsExPDSA_DateComparisonType_Header", "Date Comparison Type"), false, typeof(string), 8000, GetResourceMessage("GCS_PersonSummary_SearchWithParamsExPDSA_DateComparisonType_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.CultureName, GetResourceMessage("GCS_PersonSummary_SearchWithParamsExPDSA_CultureName_Header", "Culture Name"), false, typeof(string), 8000, GetResourceMessage("GCS_PersonSummary_SearchWithParamsExPDSA_CultureName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.IncludeLastUsageData, GetResourceMessage("GCS_PersonSummary_SearchWithParamsExPDSA_IncludeLastUsageData_Header", "Include Last Usage Data"), false, typeof(bool), 0, GetResourceMessage("GCS_PersonSummary_SearchWithParamsExPDSA_IncludeLastUsageData_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_PersonSummary_SearchWithParamsExPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_PersonSummary_SearchWithParamsExPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.EntityId).Value = Entity.EntityId;
      this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.QueryText).Value = Entity.QueryText;
      this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.DepartmentUids).Value = Entity.DepartmentUids;
      this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.AccessProfileUids).Value = Entity.AccessProfileUids;
      this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.ClusterUids).Value = Entity.ClusterUids;
      this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.PersonRecordTypeUids).Value = Entity.PersonRecordTypeUids;
      this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.PersonIds).Value = Entity.PersonIds;
      this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.Gender).Value = Entity.Gender;
      this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.DateOfBirth).Value = Entity.DateOfBirth;
      this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.IsActive).Value = Entity.IsActive;
      this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.ActivationStart).Value = Entity.ActivationStart;
      this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.ActivationEnd).Value = Entity.ActivationEnd;
      this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.ExpirationStart).Value = Entity.ExpirationStart;
      this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.ExpirationEnd).Value = Entity.ExpirationEnd;
      this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.WithCredentials).Value = Entity.WithCredentials;
      this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.CanToggleLock).Value = Entity.CanToggleLock;
      this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.CredentialNumbers).Value = Entity.CredentialNumbers;
      this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.OrderBy).Value = Entity.OrderBy;
      this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.MaximumResults).Value = Entity.MaximumResults;
      this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.PageNumber).Value = Entity.PageNumber;
      this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.PageSize).Value = Entity.PageSize;
      this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.DateComparisonType).Value = Entity.DateComparisonType;
      this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.CultureName).Value = Entity.CultureName;
      this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.IncludeLastUsageData).Value = Entity.IncludeLastUsageData;
      this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.EntityId).IsNull == false)
        Entity.EntityId = this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.EntityId).GetAsGuid();
      if(this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.QueryText).IsNull == false)
        Entity.QueryText = this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.QueryText).GetAsString();
      if(this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.DepartmentUids).IsNull == false)
        Entity.DepartmentUids = this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.DepartmentUids).GetAsString();
      if(this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.AccessProfileUids).IsNull == false)
        Entity.AccessProfileUids = this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.AccessProfileUids).GetAsString();
      if(this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.ClusterUids).IsNull == false)
        Entity.ClusterUids = this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.ClusterUids).GetAsString();
      if(this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.PersonRecordTypeUids).IsNull == false)
        Entity.PersonRecordTypeUids = this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.PersonRecordTypeUids).GetAsString();
      if(this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.PersonIds).IsNull == false)
        Entity.PersonIds = this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.PersonIds).GetAsString();
      if(this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.Gender).IsNull == false)
        Entity.Gender = this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.Gender).GetAsString();
      if(this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.DateOfBirth).IsNull == false)
        Entity.DateOfBirth = this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.DateOfBirth).GetAsDate();
      if(this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.IsActive).IsNull == false)
        Entity.IsActive = this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.IsActive).GetAsBool();
      if(this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.ActivationStart).IsNull == false)
        Entity.ActivationStart = this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.ActivationStart).GetAsDate();
      if(this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.ActivationEnd).IsNull == false)
        Entity.ActivationEnd = this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.ActivationEnd).GetAsDate();
      if(this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.ExpirationStart).IsNull == false)
        Entity.ExpirationStart = this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.ExpirationStart).GetAsDate();
      if(this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.ExpirationEnd).IsNull == false)
        Entity.ExpirationEnd = this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.ExpirationEnd).GetAsDate();
      if(this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.WithCredentials).IsNull == false)
        Entity.WithCredentials = this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.WithCredentials).GetAsBool();
      if(this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.CanToggleLock).IsNull == false)
        Entity.CanToggleLock = this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.CanToggleLock).GetAsBool();
      if(this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.CredentialNumbers).IsNull == false)
        Entity.CredentialNumbers = this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.CredentialNumbers).GetAsString();
      if(this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.OrderBy).IsNull == false)
        Entity.OrderBy = this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.OrderBy).GetAsString();
      if(this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.MaximumResults).IsNull == false)
        Entity.MaximumResults = this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.MaximumResults).GetAsInteger();
      if(this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.PageNumber).IsNull == false)
        Entity.PageNumber = this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.PageNumber).GetAsInteger();
      if(this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.PageSize).IsNull == false)
        Entity.PageSize = this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.PageSize).GetAsInteger();
      if(this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.DateComparisonType).IsNull == false)
        Entity.DateComparisonType = this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.DateComparisonType).GetAsString();
      if(this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.CultureName).IsNull == false)
        Entity.CultureName = this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.CultureName).GetAsString();
      if(this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.IncludeLastUsageData).IsNull == false)
        Entity.IncludeLastUsageData = this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.IncludeLastUsageData).GetAsBool();
      if(this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(PersonSummary_SearchWithParamsExPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the PersonSummary_SearchWithParamsExPDSA class.
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
    /// Returns 'PersonId'
    /// </summary>
    public static string PersonId = "PersonId";
    /// <summary>
    /// Returns 'FirstName'
    /// </summary>
    public static string FirstName = "FirstName";
    /// <summary>
    /// Returns 'MiddleName'
    /// </summary>
    public static string MiddleName = "MiddleName";
    /// <summary>
    /// Returns 'LastName'
    /// </summary>
    public static string LastName = "LastName";
    /// <summary>
    /// Returns 'NickName'
    /// </summary>
    public static string NickName = "NickName";
    /// <summary>
    /// Returns 'LegalName'
    /// </summary>
    public static string LegalName = "LegalName";
    /// <summary>
    /// Returns 'FullName'
    /// </summary>
    public static string FullName = "FullName";
    /// <summary>
    /// Returns 'PreferredName'
    /// </summary>
    public static string PreferredName = "PreferredName";
    /// <summary>
    /// Returns 'Company'
    /// </summary>
    public static string Company = "Company";
    /// <summary>
    /// Returns 'Trace'
    /// </summary>
    public static string Trace = "Trace";
    /// <summary>
    /// Returns 'VeryImportantPerson'
    /// </summary>
    public static string VeryImportantPerson = "VeryImportantPerson";
    /// <summary>
    /// Returns 'HasPhysicalDisability'
    /// </summary>
    public static string HasPhysicalDisability = "HasPhysicalDisability";
    /// <summary>
    /// Returns 'EntityName'
    /// </summary>
    public static string EntityName = "EntityName";
    /// <summary>
    /// Returns 'DepartmentName'
    /// </summary>
    public static string DepartmentName = "DepartmentName";
    /// <summary>
    /// Returns 'EntityId'
    /// </summary>
    public static string EntityId = "EntityId";
    /// <summary>
    /// Returns 'ActivationDateTime'
    /// </summary>
    public static string ActivationDateTime = "ActivationDateTime";
    /// <summary>
    /// Returns 'ExpirationDateTime'
    /// </summary>
    public static string ExpirationDateTime = "ExpirationDateTime";
    /// <summary>
    /// Returns 'InsertName'
    /// </summary>
    public static string InsertName = "InsertName";
    /// <summary>
    /// Returns 'InsertDate'
    /// </summary>
    public static string InsertDate = "InsertDate";
    /// <summary>
    /// Returns 'UpdateName'
    /// </summary>
    public static string UpdateName = "UpdateName";
    /// <summary>
    /// Returns 'UpdateDate'
    /// </summary>
    public static string UpdateDate = "UpdateDate";
    /// <summary>
    /// Returns 'SysGalEmployeeId'
    /// </summary>
    public static string SysGalEmployeeId = "SysGalEmployeeId";
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
    /// Returns 'ActiveStatus'
    /// </summary>
    public static string ActiveStatus = "ActiveStatus";
    /// <summary>
    /// Returns 'RecordType'
    /// </summary>
    public static string RecordType = "RecordType";
    /// <summary>
    /// Returns 'SearchField'
    /// </summary>
    public static string SearchField = "SearchField";
    /// <summary>
    /// Returns 'TotalCardCount'
    /// </summary>
    public static string TotalCardCount = "TotalCardCount";
    /// <summary>
    /// Returns 'TotalPersonCount'
    /// </summary>
    public static string TotalPersonCount = "TotalPersonCount";
    /// <summary>
    /// Returns '@QueryText'
    /// </summary>
    public static string QueryText = "@QueryText";
    /// <summary>
    /// Returns '@DepartmentUids'
    /// </summary>
    public static string DepartmentUids = "@DepartmentUids";
    /// <summary>
    /// Returns '@AccessProfileUids'
    /// </summary>
    public static string AccessProfileUids = "@AccessProfileUids";
    /// <summary>
    /// Returns '@ClusterUids'
    /// </summary>
    public static string ClusterUids = "@ClusterUids";
    /// <summary>
    /// Returns '@PersonRecordTypeUids'
    /// </summary>
    public static string PersonRecordTypeUids = "@PersonRecordTypeUids";
    /// <summary>
    /// Returns '@PersonIds'
    /// </summary>
    public static string PersonIds = "@PersonIds";
    /// <summary>
    /// Returns '@Gender'
    /// </summary>
    public static string Gender = "@Gender";
    /// <summary>
    /// Returns '@DateOfBirth'
    /// </summary>
    public static string DateOfBirth = "@DateOfBirth";
    /// <summary>
    /// Returns '@IsActive'
    /// </summary>
    public static string IsActive = "@IsActive";
    /// <summary>
    /// Returns '@ActivationStart'
    /// </summary>
    public static string ActivationStart = "@ActivationStart";
    /// <summary>
    /// Returns '@ActivationEnd'
    /// </summary>
    public static string ActivationEnd = "@ActivationEnd";
    /// <summary>
    /// Returns '@ExpirationStart'
    /// </summary>
    public static string ExpirationStart = "@ExpirationStart";
    /// <summary>
    /// Returns '@ExpirationEnd'
    /// </summary>
    public static string ExpirationEnd = "@ExpirationEnd";
    /// <summary>
    /// Returns '@WithCredentials'
    /// </summary>
    public static string WithCredentials = "@WithCredentials";
    /// <summary>
    /// Returns '@CanToggleLock'
    /// </summary>
    public static string CanToggleLock = "@CanToggleLock";
    /// <summary>
    /// Returns '@CredentialNumbers'
    /// </summary>
    public static string CredentialNumbers = "@CredentialNumbers";
    /// <summary>
    /// Returns '@OrderBy'
    /// </summary>
    public static string OrderBy = "@OrderBy";
    /// <summary>
    /// Returns '@MaximumResults'
    /// </summary>
    public static string MaximumResults = "@MaximumResults";
    /// <summary>
    /// Returns '@PageNumber'
    /// </summary>
    public static string PageNumber = "@PageNumber";
    /// <summary>
    /// Returns '@PageSize'
    /// </summary>
    public static string PageSize = "@PageSize";
    /// <summary>
    /// Returns '@DateComparisonType'
    /// </summary>
    public static string DateComparisonType = "@DateComparisonType";
    /// <summary>
    /// Returns '@CultureName'
    /// </summary>
    public static string CultureName = "@CultureName";
    /// <summary>
    /// Returns '@IncludeLastUsageData'
    /// </summary>
    public static string IncludeLastUsageData = "@IncludeLastUsageData";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the PersonSummary_SearchWithParamsExPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@EntityId'
    /// </summary>
    public static string EntityId = "@EntityId";
    /// <summary>
    /// Returns '@QueryText'
    /// </summary>
    public static string QueryText = "@QueryText";
    /// <summary>
    /// Returns '@DepartmentUids'
    /// </summary>
    public static string DepartmentUids = "@DepartmentUids";
    /// <summary>
    /// Returns '@AccessProfileUids'
    /// </summary>
    public static string AccessProfileUids = "@AccessProfileUids";
    /// <summary>
    /// Returns '@ClusterUids'
    /// </summary>
    public static string ClusterUids = "@ClusterUids";
    /// <summary>
    /// Returns '@PersonRecordTypeUids'
    /// </summary>
    public static string PersonRecordTypeUids = "@PersonRecordTypeUids";
    /// <summary>
    /// Returns '@PersonIds'
    /// </summary>
    public static string PersonIds = "@PersonIds";
    /// <summary>
    /// Returns '@Gender'
    /// </summary>
    public static string Gender = "@Gender";
    /// <summary>
    /// Returns '@DateOfBirth'
    /// </summary>
    public static string DateOfBirth = "@DateOfBirth";
    /// <summary>
    /// Returns '@IsActive'
    /// </summary>
    public static string IsActive = "@IsActive";
    /// <summary>
    /// Returns '@ActivationStart'
    /// </summary>
    public static string ActivationStart = "@ActivationStart";
    /// <summary>
    /// Returns '@ActivationEnd'
    /// </summary>
    public static string ActivationEnd = "@ActivationEnd";
    /// <summary>
    /// Returns '@ExpirationStart'
    /// </summary>
    public static string ExpirationStart = "@ExpirationStart";
    /// <summary>
    /// Returns '@ExpirationEnd'
    /// </summary>
    public static string ExpirationEnd = "@ExpirationEnd";
    /// <summary>
    /// Returns '@WithCredentials'
    /// </summary>
    public static string WithCredentials = "@WithCredentials";
    /// <summary>
    /// Returns '@CanToggleLock'
    /// </summary>
    public static string CanToggleLock = "@CanToggleLock";
    /// <summary>
    /// Returns '@CredentialNumbers'
    /// </summary>
    public static string CredentialNumbers = "@CredentialNumbers";
    /// <summary>
    /// Returns '@OrderBy'
    /// </summary>
    public static string OrderBy = "@OrderBy";
    /// <summary>
    /// Returns '@MaximumResults'
    /// </summary>
    public static string MaximumResults = "@MaximumResults";
    /// <summary>
    /// Returns '@PageNumber'
    /// </summary>
    public static string PageNumber = "@PageNumber";
    /// <summary>
    /// Returns '@PageSize'
    /// </summary>
    public static string PageSize = "@PageSize";
    /// <summary>
    /// Returns '@DateComparisonType'
    /// </summary>
    public static string DateComparisonType = "@DateComparisonType";
    /// <summary>
    /// Returns '@CultureName'
    /// </summary>
    public static string CultureName = "@CultureName";
    /// <summary>
    /// Returns '@IncludeLastUsageData'
    /// </summary>
    public static string IncludeLastUsageData = "@IncludeLastUsageData";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}

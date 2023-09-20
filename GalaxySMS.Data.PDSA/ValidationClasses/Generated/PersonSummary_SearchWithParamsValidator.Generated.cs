using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the PersonSummary_SearchWithParamsPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class PersonSummary_SearchWithParamsPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private PersonSummary_SearchWithParamsPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new PersonSummary_SearchWithParamsPDSA Entity
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
    /// Clones the current PersonSummary_SearchWithParamsPDSA
    /// </summary>
    /// <returns>A cloned PersonSummary_SearchWithParamsPDSA object</returns>
    public PersonSummary_SearchWithParamsPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in PersonSummary_SearchWithParamsPDSA
    /// </summary>
    /// <param name="entityToClone">The PersonSummary_SearchWithParamsPDSA entity to clone</param>
    /// <returns>A cloned PersonSummary_SearchWithParamsPDSA object</returns>
    public PersonSummary_SearchWithParamsPDSA CloneEntity(PersonSummary_SearchWithParamsPDSA entityToClone)
    {
      PersonSummary_SearchWithParamsPDSA newEntity = new PersonSummary_SearchWithParamsPDSA();

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
      
      props.Add(PDSAProperty.Create(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.EntityId, GetResourceMessage("GCS_PersonSummary_SearchWithParamsPDSA_EntityId_Header", "Entity Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_PersonSummary_SearchWithParamsPDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.SearchByColumnName1, GetResourceMessage("GCS_PersonSummary_SearchWithParamsPDSA_SearchByColumnName1_Header", "Search By Column Name 1"), false, typeof(string), 8000, GetResourceMessage("GCS_PersonSummary_SearchWithParamsPDSA_SearchByColumnName1_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.SearchData1, GetResourceMessage("GCS_PersonSummary_SearchWithParamsPDSA_SearchData1_Header", "Search Data 1"), false, typeof(string), 8000, GetResourceMessage("GCS_PersonSummary_SearchWithParamsPDSA_SearchData1_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.SearchByColumnName2, GetResourceMessage("GCS_PersonSummary_SearchWithParamsPDSA_SearchByColumnName2_Header", "Search By Column Name 2"), false, typeof(string), 8000, GetResourceMessage("GCS_PersonSummary_SearchWithParamsPDSA_SearchByColumnName2_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.SearchData2, GetResourceMessage("GCS_PersonSummary_SearchWithParamsPDSA_SearchData2_Header", "Search Data 2"), false, typeof(string), 8000, GetResourceMessage("GCS_PersonSummary_SearchWithParamsPDSA_SearchData2_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.SearchByColumnName3, GetResourceMessage("GCS_PersonSummary_SearchWithParamsPDSA_SearchByColumnName3_Header", "Search By Column Name 3"), false, typeof(string), 8000, GetResourceMessage("GCS_PersonSummary_SearchWithParamsPDSA_SearchByColumnName3_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.SearchData3, GetResourceMessage("GCS_PersonSummary_SearchWithParamsPDSA_SearchData3_Header", "Search Data 3"), false, typeof(string), 8000, GetResourceMessage("GCS_PersonSummary_SearchWithParamsPDSA_SearchData3_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.SearchByColumnName4, GetResourceMessage("GCS_PersonSummary_SearchWithParamsPDSA_SearchByColumnName4_Header", "Search By Column Name 4"), false, typeof(string), 8000, GetResourceMessage("GCS_PersonSummary_SearchWithParamsPDSA_SearchByColumnName4_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.SearchData4, GetResourceMessage("GCS_PersonSummary_SearchWithParamsPDSA_SearchData4_Header", "Search Data 4"), false, typeof(string), 8000, GetResourceMessage("GCS_PersonSummary_SearchWithParamsPDSA_SearchData4_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.SearchByColumnName5, GetResourceMessage("GCS_PersonSummary_SearchWithParamsPDSA_SearchByColumnName5_Header", "Search By Column Name 5"), false, typeof(string), 8000, GetResourceMessage("GCS_PersonSummary_SearchWithParamsPDSA_SearchByColumnName5_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.SearchData5, GetResourceMessage("GCS_PersonSummary_SearchWithParamsPDSA_SearchData5_Header", "Search Data 5"), false, typeof(string), 8000, GetResourceMessage("GCS_PersonSummary_SearchWithParamsPDSA_SearchData5_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.SearchByColumnName6, GetResourceMessage("GCS_PersonSummary_SearchWithParamsPDSA_SearchByColumnName6_Header", "Search By Column Name 6"), false, typeof(string), 8000, GetResourceMessage("GCS_PersonSummary_SearchWithParamsPDSA_SearchByColumnName6_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.SearchData6, GetResourceMessage("GCS_PersonSummary_SearchWithParamsPDSA_SearchData6_Header", "Search Data 6"), false, typeof(string), 8000, GetResourceMessage("GCS_PersonSummary_SearchWithParamsPDSA_SearchData6_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.SearchByColumnName7, GetResourceMessage("GCS_PersonSummary_SearchWithParamsPDSA_SearchByColumnName7_Header", "Search By Column Name 7"), false, typeof(string), 8000, GetResourceMessage("GCS_PersonSummary_SearchWithParamsPDSA_SearchByColumnName7_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.SearchData7, GetResourceMessage("GCS_PersonSummary_SearchWithParamsPDSA_SearchData7_Header", "Search Data 7"), false, typeof(string), 8000, GetResourceMessage("GCS_PersonSummary_SearchWithParamsPDSA_SearchData7_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.SearchByColumnName8, GetResourceMessage("GCS_PersonSummary_SearchWithParamsPDSA_SearchByColumnName8_Header", "Search By Column Name 8"), false, typeof(string), 8000, GetResourceMessage("GCS_PersonSummary_SearchWithParamsPDSA_SearchByColumnName8_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.SearchData8, GetResourceMessage("GCS_PersonSummary_SearchWithParamsPDSA_SearchData8_Header", "Search Data 8"), false, typeof(string), 8000, GetResourceMessage("GCS_PersonSummary_SearchWithParamsPDSA_SearchData8_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.CredentialPartNumber, GetResourceMessage("GCS_PersonSummary_SearchWithParamsPDSA_CredentialPartNumber_Header", "Credential Part Number"), false, typeof(long), 0, GetResourceMessage("GCS_PersonSummary_SearchWithParamsPDSA_CredentialPartNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt64("-9223372036854775808"), Convert.ToInt64("9223372036854775807"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.UidValue, GetResourceMessage("GCS_PersonSummary_SearchWithParamsPDSA_UidValue_Header", "Uid Value"), false, typeof(Guid), 0, GetResourceMessage("GCS_PersonSummary_SearchWithParamsPDSA_UidValue_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.ExactMatch, GetResourceMessage("GCS_PersonSummary_SearchWithParamsPDSA_ExactMatch_Header", "Exact Match"), false, typeof(short), 0, GetResourceMessage("GCS_PersonSummary_SearchWithParamsPDSA_ExactMatch_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.AnywhereWithin, GetResourceMessage("GCS_PersonSummary_SearchWithParamsPDSA_AnywhereWithin_Header", "Anywhere Within"), false, typeof(short), 0, GetResourceMessage("GCS_PersonSummary_SearchWithParamsPDSA_AnywhereWithin_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.OrNotAnd, GetResourceMessage("GCS_PersonSummary_SearchWithParamsPDSA_OrNotAnd_Header", "Or Not And"), false, typeof(short), 0, GetResourceMessage("GCS_PersonSummary_SearchWithParamsPDSA_OrNotAnd_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.OrderBy, GetResourceMessage("GCS_PersonSummary_SearchWithParamsPDSA_OrderBy_Header", "Order By"), false, typeof(string), 8000, GetResourceMessage("GCS_PersonSummary_SearchWithParamsPDSA_OrderBy_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.MaximumResults, GetResourceMessage("GCS_PersonSummary_SearchWithParamsPDSA_MaximumResults_Header", "Maximum Results"), false, typeof(int), 0, GetResourceMessage("GCS_PersonSummary_SearchWithParamsPDSA_MaximumResults_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.PageNumber, GetResourceMessage("GCS_PersonSummary_SearchWithParamsPDSA_PageNumber_Header", "Page Number"), false, typeof(int), 0, GetResourceMessage("GCS_PersonSummary_SearchWithParamsPDSA_PageNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.PageSize, GetResourceMessage("GCS_PersonSummary_SearchWithParamsPDSA_PageSize_Header", "Page Size"), false, typeof(int), 0, GetResourceMessage("GCS_PersonSummary_SearchWithParamsPDSA_PageSize_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.DateComparisonType, GetResourceMessage("GCS_PersonSummary_SearchWithParamsPDSA_DateComparisonType_Header", "Date Comparison Type"), false, typeof(string), 8000, GetResourceMessage("GCS_PersonSummary_SearchWithParamsPDSA_DateComparisonType_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.CultureName, GetResourceMessage("GCS_PersonSummary_SearchWithParamsPDSA_CultureName_Header", "Culture Name"), false, typeof(string), 8000, GetResourceMessage("GCS_PersonSummary_SearchWithParamsPDSA_CultureName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.IncludeLastUsageData, GetResourceMessage("GCS_PersonSummary_SearchWithParamsPDSA_IncludeLastUsageData_Header", "Include Last Usage Data"), false, typeof(bool), 0, GetResourceMessage("GCS_PersonSummary_SearchWithParamsPDSA_IncludeLastUsageData_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_PersonSummary_SearchWithParamsPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_PersonSummary_SearchWithParamsPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.EntityId).Value = Entity.EntityId;
      this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.SearchByColumnName1).Value = Entity.SearchByColumnName1;
      this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.SearchData1).Value = Entity.SearchData1;
      this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.SearchByColumnName2).Value = Entity.SearchByColumnName2;
      this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.SearchData2).Value = Entity.SearchData2;
      this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.SearchByColumnName3).Value = Entity.SearchByColumnName3;
      this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.SearchData3).Value = Entity.SearchData3;
      this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.SearchByColumnName4).Value = Entity.SearchByColumnName4;
      this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.SearchData4).Value = Entity.SearchData4;
      this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.SearchByColumnName5).Value = Entity.SearchByColumnName5;
      this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.SearchData5).Value = Entity.SearchData5;
      this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.SearchByColumnName6).Value = Entity.SearchByColumnName6;
      this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.SearchData6).Value = Entity.SearchData6;
      this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.SearchByColumnName7).Value = Entity.SearchByColumnName7;
      this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.SearchData7).Value = Entity.SearchData7;
      this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.SearchByColumnName8).Value = Entity.SearchByColumnName8;
      this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.SearchData8).Value = Entity.SearchData8;
      this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.CredentialPartNumber).Value = Entity.CredentialPartNumber;
      this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.UidValue).Value = Entity.UidValue;
      this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.ExactMatch).Value = Entity.ExactMatch;
      this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.AnywhereWithin).Value = Entity.AnywhereWithin;
      this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.OrNotAnd).Value = Entity.OrNotAnd;
      this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.OrderBy).Value = Entity.OrderBy;
      this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.MaximumResults).Value = Entity.MaximumResults;
      this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.PageNumber).Value = Entity.PageNumber;
      this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.PageSize).Value = Entity.PageSize;
      this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.DateComparisonType).Value = Entity.DateComparisonType;
      this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.CultureName).Value = Entity.CultureName;
      this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.IncludeLastUsageData).Value = Entity.IncludeLastUsageData;
      this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.EntityId).IsNull == false)
        Entity.EntityId = this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.EntityId).GetAsGuid();
      if(this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.SearchByColumnName1).IsNull == false)
        Entity.SearchByColumnName1 = this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.SearchByColumnName1).GetAsString();
      if(this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.SearchData1).IsNull == false)
        Entity.SearchData1 = this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.SearchData1).GetAsString();
      if(this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.SearchByColumnName2).IsNull == false)
        Entity.SearchByColumnName2 = this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.SearchByColumnName2).GetAsString();
      if(this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.SearchData2).IsNull == false)
        Entity.SearchData2 = this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.SearchData2).GetAsString();
      if(this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.SearchByColumnName3).IsNull == false)
        Entity.SearchByColumnName3 = this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.SearchByColumnName3).GetAsString();
      if(this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.SearchData3).IsNull == false)
        Entity.SearchData3 = this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.SearchData3).GetAsString();
      if(this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.SearchByColumnName4).IsNull == false)
        Entity.SearchByColumnName4 = this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.SearchByColumnName4).GetAsString();
      if(this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.SearchData4).IsNull == false)
        Entity.SearchData4 = this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.SearchData4).GetAsString();
      if(this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.SearchByColumnName5).IsNull == false)
        Entity.SearchByColumnName5 = this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.SearchByColumnName5).GetAsString();
      if(this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.SearchData5).IsNull == false)
        Entity.SearchData5 = this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.SearchData5).GetAsString();
      if(this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.SearchByColumnName6).IsNull == false)
        Entity.SearchByColumnName6 = this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.SearchByColumnName6).GetAsString();
      if(this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.SearchData6).IsNull == false)
        Entity.SearchData6 = this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.SearchData6).GetAsString();
      if(this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.SearchByColumnName7).IsNull == false)
        Entity.SearchByColumnName7 = this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.SearchByColumnName7).GetAsString();
      if(this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.SearchData7).IsNull == false)
        Entity.SearchData7 = this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.SearchData7).GetAsString();
      if(this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.SearchByColumnName8).IsNull == false)
        Entity.SearchByColumnName8 = this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.SearchByColumnName8).GetAsString();
      if(this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.SearchData8).IsNull == false)
        Entity.SearchData8 = this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.SearchData8).GetAsString();
      if(this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.CredentialPartNumber).IsNull == false)
        Entity.CredentialPartNumber = this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.CredentialPartNumber).GetAsLong();
      if(this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.UidValue).IsNull == false)
        Entity.UidValue = this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.UidValue).GetAsGuid();
      if(this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.ExactMatch).IsNull == false)
        Entity.ExactMatch = this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.ExactMatch).GetAsShort();
      if(this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.AnywhereWithin).IsNull == false)
        Entity.AnywhereWithin = this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.AnywhereWithin).GetAsShort();
      if(this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.OrNotAnd).IsNull == false)
        Entity.OrNotAnd = this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.OrNotAnd).GetAsShort();
      if(this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.OrderBy).IsNull == false)
        Entity.OrderBy = this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.OrderBy).GetAsString();
      if(this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.MaximumResults).IsNull == false)
        Entity.MaximumResults = this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.MaximumResults).GetAsInteger();
      if(this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.PageNumber).IsNull == false)
        Entity.PageNumber = this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.PageNumber).GetAsInteger();
      if(this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.PageSize).IsNull == false)
        Entity.PageSize = this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.PageSize).GetAsInteger();
      if(this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.DateComparisonType).IsNull == false)
        Entity.DateComparisonType = this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.DateComparisonType).GetAsString();
      if(this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.CultureName).IsNull == false)
        Entity.CultureName = this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.CultureName).GetAsString();
      if(this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.IncludeLastUsageData).IsNull == false)
        Entity.IncludeLastUsageData = this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.IncludeLastUsageData).GetAsBool();
      if(this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(PersonSummary_SearchWithParamsPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the PersonSummary_SearchWithParamsPDSA class.
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
    /// Returns '@SearchByColumnName1'
    /// </summary>
    public static string SearchByColumnName1 = "@SearchByColumnName1";
    /// <summary>
    /// Returns '@SearchData1'
    /// </summary>
    public static string SearchData1 = "@SearchData1";
    /// <summary>
    /// Returns '@SearchByColumnName2'
    /// </summary>
    public static string SearchByColumnName2 = "@SearchByColumnName2";
    /// <summary>
    /// Returns '@SearchData2'
    /// </summary>
    public static string SearchData2 = "@SearchData2";
    /// <summary>
    /// Returns '@SearchByColumnName3'
    /// </summary>
    public static string SearchByColumnName3 = "@SearchByColumnName3";
    /// <summary>
    /// Returns '@SearchData3'
    /// </summary>
    public static string SearchData3 = "@SearchData3";
    /// <summary>
    /// Returns '@SearchByColumnName4'
    /// </summary>
    public static string SearchByColumnName4 = "@SearchByColumnName4";
    /// <summary>
    /// Returns '@SearchData4'
    /// </summary>
    public static string SearchData4 = "@SearchData4";
    /// <summary>
    /// Returns '@SearchByColumnName5'
    /// </summary>
    public static string SearchByColumnName5 = "@SearchByColumnName5";
    /// <summary>
    /// Returns '@SearchData5'
    /// </summary>
    public static string SearchData5 = "@SearchData5";
    /// <summary>
    /// Returns '@SearchByColumnName6'
    /// </summary>
    public static string SearchByColumnName6 = "@SearchByColumnName6";
    /// <summary>
    /// Returns '@SearchData6'
    /// </summary>
    public static string SearchData6 = "@SearchData6";
    /// <summary>
    /// Returns '@SearchByColumnName7'
    /// </summary>
    public static string SearchByColumnName7 = "@SearchByColumnName7";
    /// <summary>
    /// Returns '@SearchData7'
    /// </summary>
    public static string SearchData7 = "@SearchData7";
    /// <summary>
    /// Returns '@SearchByColumnName8'
    /// </summary>
    public static string SearchByColumnName8 = "@SearchByColumnName8";
    /// <summary>
    /// Returns '@SearchData8'
    /// </summary>
    public static string SearchData8 = "@SearchData8";
    /// <summary>
    /// Returns '@CredentialPartNumber'
    /// </summary>
    public static string CredentialPartNumber = "@CredentialPartNumber";
    /// <summary>
    /// Returns '@UidValue'
    /// </summary>
    public static string UidValue = "@UidValue";
    /// <summary>
    /// Returns '@ExactMatch'
    /// </summary>
    public static string ExactMatch = "@ExactMatch";
    /// <summary>
    /// Returns '@AnywhereWithin'
    /// </summary>
    public static string AnywhereWithin = "@AnywhereWithin";
    /// <summary>
    /// Returns '@OrNotAnd'
    /// </summary>
    public static string OrNotAnd = "@OrNotAnd";
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
    /// Contains static string properties that represent the name of each property in the PersonSummary_SearchWithParamsPDSA class.
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
    /// Returns '@SearchByColumnName1'
    /// </summary>
    public static string SearchByColumnName1 = "@SearchByColumnName1";
    /// <summary>
    /// Returns '@SearchData1'
    /// </summary>
    public static string SearchData1 = "@SearchData1";
    /// <summary>
    /// Returns '@SearchByColumnName2'
    /// </summary>
    public static string SearchByColumnName2 = "@SearchByColumnName2";
    /// <summary>
    /// Returns '@SearchData2'
    /// </summary>
    public static string SearchData2 = "@SearchData2";
    /// <summary>
    /// Returns '@SearchByColumnName3'
    /// </summary>
    public static string SearchByColumnName3 = "@SearchByColumnName3";
    /// <summary>
    /// Returns '@SearchData3'
    /// </summary>
    public static string SearchData3 = "@SearchData3";
    /// <summary>
    /// Returns '@SearchByColumnName4'
    /// </summary>
    public static string SearchByColumnName4 = "@SearchByColumnName4";
    /// <summary>
    /// Returns '@SearchData4'
    /// </summary>
    public static string SearchData4 = "@SearchData4";
    /// <summary>
    /// Returns '@SearchByColumnName5'
    /// </summary>
    public static string SearchByColumnName5 = "@SearchByColumnName5";
    /// <summary>
    /// Returns '@SearchData5'
    /// </summary>
    public static string SearchData5 = "@SearchData5";
    /// <summary>
    /// Returns '@SearchByColumnName6'
    /// </summary>
    public static string SearchByColumnName6 = "@SearchByColumnName6";
    /// <summary>
    /// Returns '@SearchData6'
    /// </summary>
    public static string SearchData6 = "@SearchData6";
    /// <summary>
    /// Returns '@SearchByColumnName7'
    /// </summary>
    public static string SearchByColumnName7 = "@SearchByColumnName7";
    /// <summary>
    /// Returns '@SearchData7'
    /// </summary>
    public static string SearchData7 = "@SearchData7";
    /// <summary>
    /// Returns '@SearchByColumnName8'
    /// </summary>
    public static string SearchByColumnName8 = "@SearchByColumnName8";
    /// <summary>
    /// Returns '@SearchData8'
    /// </summary>
    public static string SearchData8 = "@SearchData8";
    /// <summary>
    /// Returns '@CredentialPartNumber'
    /// </summary>
    public static string CredentialPartNumber = "@CredentialPartNumber";
    /// <summary>
    /// Returns '@UidValue'
    /// </summary>
    public static string UidValue = "@UidValue";
    /// <summary>
    /// Returns '@ExactMatch'
    /// </summary>
    public static string ExactMatch = "@ExactMatch";
    /// <summary>
    /// Returns '@AnywhereWithin'
    /// </summary>
    public static string AnywhereWithin = "@AnywhereWithin";
    /// <summary>
    /// Returns '@OrNotAnd'
    /// </summary>
    public static string OrNotAnd = "@OrNotAnd";
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

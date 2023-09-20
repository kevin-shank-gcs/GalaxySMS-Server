using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the PersonCredentialBadgeDataView_ByPersonCredentialUidPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class PersonCredentialBadgeDataView_ByPersonCredentialUidPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private PersonCredentialBadgeDataView_ByPersonCredentialUidPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new PersonCredentialBadgeDataView_ByPersonCredentialUidPDSA Entity
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
    /// Clones the current PersonCredentialBadgeDataView_ByPersonCredentialUidPDSA
    /// </summary>
    /// <returns>A cloned PersonCredentialBadgeDataView_ByPersonCredentialUidPDSA object</returns>
    public PersonCredentialBadgeDataView_ByPersonCredentialUidPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in PersonCredentialBadgeDataView_ByPersonCredentialUidPDSA
    /// </summary>
    /// <param name="entityToClone">The PersonCredentialBadgeDataView_ByPersonCredentialUidPDSA entity to clone</param>
    /// <returns>A cloned PersonCredentialBadgeDataView_ByPersonCredentialUidPDSA object</returns>
    public PersonCredentialBadgeDataView_ByPersonCredentialUidPDSA CloneEntity(PersonCredentialBadgeDataView_ByPersonCredentialUidPDSA entityToClone)
    {
      PersonCredentialBadgeDataView_ByPersonCredentialUidPDSA newEntity = new PersonCredentialBadgeDataView_ByPersonCredentialUidPDSA();

      newEntity.PersonUid = entityToClone.PersonUid;
      newEntity.PersonCredentialUid = entityToClone.PersonCredentialUid;
      newEntity.ActivationDateTime = entityToClone.ActivationDateTime;
      newEntity.Company = entityToClone.Company;
      newEntity.ConcurrencyValue = entityToClone.ConcurrencyValue;
      newEntity.CountryOfBirthUid = entityToClone.CountryOfBirthUid;
      newEntity.DateOfBirth = entityToClone.DateOfBirth;
      newEntity.DepartmentUid = entityToClone.DepartmentUid;
      newEntity.EmploymentDate = entityToClone.EmploymentDate;
      newEntity.EntityId = entityToClone.EntityId;
      newEntity.Ethnicity = entityToClone.Ethnicity;
      newEntity.ExpirationDateTime = entityToClone.ExpirationDateTime;
      newEntity.FirstName = entityToClone.FirstName;
      newEntity.FullName = entityToClone.FullName;
      newEntity.GenderUid = entityToClone.GenderUid;
      newEntity.HasPhysicalDisability = entityToClone.HasPhysicalDisability;
      newEntity.HasVertigo = entityToClone.HasVertigo;
      newEntity.HomeOfficeLocation = entityToClone.HomeOfficeLocation;
      newEntity.Initials = entityToClone.Initials;
      newEntity.InsertDate = entityToClone.InsertDate;
      newEntity.InsertName = entityToClone.InsertName;
      newEntity.JobTitle = entityToClone.JobTitle;
      newEntity.LastName = entityToClone.LastName;
      newEntity.LegalName = entityToClone.LegalName;
      newEntity.MiddleName = entityToClone.MiddleName;
      newEntity.NationalIdentificationNumber = entityToClone.NationalIdentificationNumber;
      newEntity.Nationality = entityToClone.Nationality;
      newEntity.NickName = entityToClone.NickName;
      newEntity.OriginId = entityToClone.OriginId;
      newEntity.PersonActiveStatusTypeUid = entityToClone.PersonActiveStatusTypeUid;
      newEntity.PersonId = entityToClone.PersonId;
      newEntity.PersonRecordTypeUid = entityToClone.PersonRecordTypeUid;
      newEntity.PreferredName = entityToClone.PreferredName;
      newEntity.PrimaryLanguage = entityToClone.PrimaryLanguage;
      newEntity.Race = entityToClone.Race;
      newEntity.RowOrigin = entityToClone.RowOrigin;
      newEntity.SecondaryLanguage = entityToClone.SecondaryLanguage;
      newEntity.SysGalEmployeeId = entityToClone.SysGalEmployeeId;
      newEntity.TerminationDate = entityToClone.TerminationDate;
      newEntity.TextData1 = entityToClone.TextData1;
      newEntity.TextData2 = entityToClone.TextData2;
      newEntity.TextData3 = entityToClone.TextData3;
      newEntity.TextData4 = entityToClone.TextData4;
      newEntity.TextData5 = entityToClone.TextData5;
      newEntity.TextData6 = entityToClone.TextData6;
      newEntity.TextData7 = entityToClone.TextData7;
      newEntity.TextData8 = entityToClone.TextData8;
      newEntity.TextData9 = entityToClone.TextData9;
      newEntity.TextData10 = entityToClone.TextData10;
      newEntity.TextData11 = entityToClone.TextData11;
      newEntity.TextData12 = entityToClone.TextData12;
      newEntity.TextData13 = entityToClone.TextData13;
      newEntity.TextData14 = entityToClone.TextData14;
      newEntity.TextData15 = entityToClone.TextData15;
      newEntity.TextData16 = entityToClone.TextData16;
      newEntity.TextData17 = entityToClone.TextData17;
      newEntity.TextData18 = entityToClone.TextData18;
      newEntity.TextData19 = entityToClone.TextData19;
      newEntity.TextData20 = entityToClone.TextData20;
      newEntity.TextData21 = entityToClone.TextData21;
      newEntity.TextData22 = entityToClone.TextData22;
      newEntity.TextData23 = entityToClone.TextData23;
      newEntity.TextData24 = entityToClone.TextData24;
      newEntity.TextData25 = entityToClone.TextData25;
      newEntity.TextData26 = entityToClone.TextData26;
      newEntity.TextData27 = entityToClone.TextData27;
      newEntity.TextData28 = entityToClone.TextData28;
      newEntity.TextData29 = entityToClone.TextData29;
      newEntity.TextData30 = entityToClone.TextData30;
      newEntity.TextData31 = entityToClone.TextData31;
      newEntity.TextData32 = entityToClone.TextData32;
      newEntity.TextData33 = entityToClone.TextData33;
      newEntity.TextData34 = entityToClone.TextData34;
      newEntity.TextData35 = entityToClone.TextData35;
      newEntity.TextData36 = entityToClone.TextData36;
      newEntity.TextData37 = entityToClone.TextData37;
      newEntity.TextData38 = entityToClone.TextData38;
      newEntity.TextData39 = entityToClone.TextData39;
      newEntity.TextData40 = entityToClone.TextData40;
      newEntity.TextData41 = entityToClone.TextData41;
      newEntity.TextData42 = entityToClone.TextData42;
      newEntity.TextData43 = entityToClone.TextData43;
      newEntity.TextData44 = entityToClone.TextData44;
      newEntity.TextData45 = entityToClone.TextData45;
      newEntity.TextData46 = entityToClone.TextData46;
      newEntity.TextData47 = entityToClone.TextData47;
      newEntity.TextData48 = entityToClone.TextData48;
      newEntity.TextData49 = entityToClone.TextData49;
      newEntity.TextData50 = entityToClone.TextData50;
      newEntity.Trace = entityToClone.Trace;
      newEntity.UpdateDate = entityToClone.UpdateDate;
      newEntity.UpdateName = entityToClone.UpdateName;
      newEntity.VeryImportantPerson = entityToClone.VeryImportantPerson;
      newEntity.PersonPhotoMainPhoto = entityToClone.PersonPhotoMainPhoto;
      newEntity.PersonPhotoAlternatePhoto = entityToClone.PersonPhotoAlternatePhoto;
      newEntity.AccessProfileUid = entityToClone.AccessProfileUid;
      newEntity.AccessProfileName = entityToClone.AccessProfileName;
      newEntity.CredentialActivationDate = entityToClone.CredentialActivationDate;
      newEntity.CredentialDescription = entityToClone.CredentialDescription;
      newEntity.CredentialExpirationDateTime = entityToClone.CredentialExpirationDateTime;
      newEntity.CredentialCardNumber = entityToClone.CredentialCardNumber;
      newEntity.Credential26BitStandardFacilityCode = entityToClone.Credential26BitStandardFacilityCode;
      newEntity.Credential26BitStandardIdCode = entityToClone.Credential26BitStandardIdCode;
      newEntity.CredentialCorporate1K35BitCompanyCode = entityToClone.CredentialCorporate1K35BitCompanyCode;
      newEntity.CredentialCorporate1K35BitIdCode = entityToClone.CredentialCorporate1K35BitIdCode;
      newEntity.CredentialCorporate1K48BitCompanyCode = entityToClone.CredentialCorporate1K48BitCompanyCode;
      newEntity.CredentialCorporate1K48BitIdCode = entityToClone.CredentialCorporate1K48BitIdCode;
      newEntity.CredentialCypress37BitFacilityCode = entityToClone.CredentialCypress37BitFacilityCode;
      newEntity.CredentialCypress37BitIdCode = entityToClone.CredentialCypress37BitIdCode;
      newEntity.CredentialH1030237BitIdCode = entityToClone.CredentialH1030237BitIdCode;
      newEntity.CredentialH1030437BitFacilityCode = entityToClone.CredentialH1030437BitFacilityCode;
      newEntity.CredentialH1030437BitIdCode = entityToClone.CredentialH1030437BitIdCode;
      newEntity.CredentialSoftwareHouse37BitFacilityCode = entityToClone.CredentialSoftwareHouse37BitFacilityCode;
      newEntity.CredentialSoftwareHouse37BitSiteCode = entityToClone.CredentialSoftwareHouse37BitSiteCode;
      newEntity.CredentialSoftwareHouse37BitIdCode = entityToClone.CredentialSoftwareHouse37BitIdCode;
      newEntity.CredentialXceedId40BitSiteCode = entityToClone.CredentialXceedId40BitSiteCode;
      newEntity.CredentialXceedId40BitIdCode = entityToClone.CredentialXceedId40BitIdCode;
      newEntity.CountryName = entityToClone.CountryName;
      newEntity.DepartmentName = entityToClone.DepartmentName;
      newEntity.EntityName = entityToClone.EntityName;
      newEntity.Gender = entityToClone.Gender;
      newEntity.PersonActiveStatusType = entityToClone.PersonActiveStatusType;
      newEntity.PersonRecordType = entityToClone.PersonRecordType;
      newEntity.Date1 = entityToClone.Date1;
      newEntity.Date2 = entityToClone.Date2;
      newEntity.SelectItem1 = entityToClone.SelectItem1;
      newEntity.SelectItem2 = entityToClone.SelectItem2;
      newEntity.SelectItem3 = entityToClone.SelectItem3;
      newEntity.SelectItem4 = entityToClone.SelectItem4;
      newEntity.SelectItem5 = entityToClone.SelectItem5;
      newEntity.SelectItem6 = entityToClone.SelectItem6;
      newEntity.SelectItem7 = entityToClone.SelectItem7;
      newEntity.SelectItem8 = entityToClone.SelectItem8;
      newEntity.SelectItem9 = entityToClone.SelectItem9;
      newEntity.SelectItem10 = entityToClone.SelectItem10;
      newEntity.CurrentDate = entityToClone.CurrentDate;
      newEntity.CurrentDateTime = entityToClone.CurrentDateTime;
      newEntity.BadgeTemplateName = entityToClone.BadgeTemplateName;
      newEntity.DossierTemplateName = entityToClone.DossierTemplateName;

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
      
      props.Add(PDSAProperty.Create(PersonCredentialBadgeDataView_ByPersonCredentialUidPDSAValidator.ParameterNames.PersonCredentialUid, GetResourceMessage("GCS_PersonCredentialBadgeDataView_ByPersonCredentialUidPDSA_PersonCredentialUid_Header", "Person Credential Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_PersonCredentialBadgeDataView_ByPersonCredentialUidPDSA_PersonCredentialUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(PersonCredentialBadgeDataView_ByPersonCredentialUidPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_PersonCredentialBadgeDataView_ByPersonCredentialUidPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_PersonCredentialBadgeDataView_ByPersonCredentialUidPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(PersonCredentialBadgeDataView_ByPersonCredentialUidPDSAValidator.ParameterNames.PersonCredentialUid).Value = Entity.PersonCredentialUid;
      this.Properties.GetByName(PersonCredentialBadgeDataView_ByPersonCredentialUidPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(PersonCredentialBadgeDataView_ByPersonCredentialUidPDSAValidator.ParameterNames.PersonCredentialUid).IsNull == false)
        Entity.PersonCredentialUid = this.Properties.GetByName(PersonCredentialBadgeDataView_ByPersonCredentialUidPDSAValidator.ParameterNames.PersonCredentialUid).GetAsGuid();
      if(this.Properties.GetByName(PersonCredentialBadgeDataView_ByPersonCredentialUidPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(PersonCredentialBadgeDataView_ByPersonCredentialUidPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the PersonCredentialBadgeDataView_ByPersonCredentialUidPDSA class.
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
    /// Returns 'PersonCredentialUid'
    /// </summary>
    public static string PersonCredentialUid = "PersonCredentialUid";
    /// <summary>
    /// Returns 'ActivationDateTime'
    /// </summary>
    public static string ActivationDateTime = "ActivationDateTime";
    /// <summary>
    /// Returns 'Company'
    /// </summary>
    public static string Company = "Company";
    /// <summary>
    /// Returns 'ConcurrencyValue'
    /// </summary>
    public static string ConcurrencyValue = "ConcurrencyValue";
    /// <summary>
    /// Returns 'CountryOfBirthUid'
    /// </summary>
    public static string CountryOfBirthUid = "CountryOfBirthUid";
    /// <summary>
    /// Returns 'DateOfBirth'
    /// </summary>
    public static string DateOfBirth = "DateOfBirth";
    /// <summary>
    /// Returns 'DepartmentUid'
    /// </summary>
    public static string DepartmentUid = "DepartmentUid";
    /// <summary>
    /// Returns 'EmploymentDate'
    /// </summary>
    public static string EmploymentDate = "EmploymentDate";
    /// <summary>
    /// Returns 'EntityId'
    /// </summary>
    public static string EntityId = "EntityId";
    /// <summary>
    /// Returns 'Ethnicity'
    /// </summary>
    public static string Ethnicity = "Ethnicity";
    /// <summary>
    /// Returns 'ExpirationDateTime'
    /// </summary>
    public static string ExpirationDateTime = "ExpirationDateTime";
    /// <summary>
    /// Returns 'FirstName'
    /// </summary>
    public static string FirstName = "FirstName";
    /// <summary>
    /// Returns 'FullName'
    /// </summary>
    public static string FullName = "FullName";
    /// <summary>
    /// Returns 'GenderUid'
    /// </summary>
    public static string GenderUid = "GenderUid";
    /// <summary>
    /// Returns 'HasPhysicalDisability'
    /// </summary>
    public static string HasPhysicalDisability = "HasPhysicalDisability";
    /// <summary>
    /// Returns 'HasVertigo'
    /// </summary>
    public static string HasVertigo = "HasVertigo";
    /// <summary>
    /// Returns 'HomeOfficeLocation'
    /// </summary>
    public static string HomeOfficeLocation = "HomeOfficeLocation";
    /// <summary>
    /// Returns 'Initials'
    /// </summary>
    public static string Initials = "Initials";
    /// <summary>
    /// Returns 'InsertDate'
    /// </summary>
    public static string InsertDate = "InsertDate";
    /// <summary>
    /// Returns 'InsertName'
    /// </summary>
    public static string InsertName = "InsertName";
    /// <summary>
    /// Returns 'JobTitle'
    /// </summary>
    public static string JobTitle = "JobTitle";
    /// <summary>
    /// Returns 'LastName'
    /// </summary>
    public static string LastName = "LastName";
    /// <summary>
    /// Returns 'LegalName'
    /// </summary>
    public static string LegalName = "LegalName";
    /// <summary>
    /// Returns 'MiddleName'
    /// </summary>
    public static string MiddleName = "MiddleName";
    /// <summary>
    /// Returns 'NationalIdentificationNumber'
    /// </summary>
    public static string NationalIdentificationNumber = "NationalIdentificationNumber";
    /// <summary>
    /// Returns 'Nationality'
    /// </summary>
    public static string Nationality = "Nationality";
    /// <summary>
    /// Returns 'NickName'
    /// </summary>
    public static string NickName = "NickName";
    /// <summary>
    /// Returns 'OriginId'
    /// </summary>
    public static string OriginId = "OriginId";
    /// <summary>
    /// Returns 'PersonActiveStatusTypeUid'
    /// </summary>
    public static string PersonActiveStatusTypeUid = "PersonActiveStatusTypeUid";
    /// <summary>
    /// Returns 'PersonId'
    /// </summary>
    public static string PersonId = "PersonId";
    /// <summary>
    /// Returns 'PersonRecordTypeUid'
    /// </summary>
    public static string PersonRecordTypeUid = "PersonRecordTypeUid";
    /// <summary>
    /// Returns 'PreferredName'
    /// </summary>
    public static string PreferredName = "PreferredName";
    /// <summary>
    /// Returns 'PrimaryLanguage'
    /// </summary>
    public static string PrimaryLanguage = "PrimaryLanguage";
    /// <summary>
    /// Returns 'Race'
    /// </summary>
    public static string Race = "Race";
    /// <summary>
    /// Returns 'RowOrigin'
    /// </summary>
    public static string RowOrigin = "RowOrigin";
    /// <summary>
    /// Returns 'SecondaryLanguage'
    /// </summary>
    public static string SecondaryLanguage = "SecondaryLanguage";
    /// <summary>
    /// Returns 'SysGalEmployeeId'
    /// </summary>
    public static string SysGalEmployeeId = "SysGalEmployeeId";
    /// <summary>
    /// Returns 'TerminationDate'
    /// </summary>
    public static string TerminationDate = "TerminationDate";
    /// <summary>
    /// Returns 'TextData1'
    /// </summary>
    public static string TextData1 = "TextData1";
    /// <summary>
    /// Returns 'TextData2'
    /// </summary>
    public static string TextData2 = "TextData2";
    /// <summary>
    /// Returns 'TextData3'
    /// </summary>
    public static string TextData3 = "TextData3";
    /// <summary>
    /// Returns 'TextData4'
    /// </summary>
    public static string TextData4 = "TextData4";
    /// <summary>
    /// Returns 'TextData5'
    /// </summary>
    public static string TextData5 = "TextData5";
    /// <summary>
    /// Returns 'TextData6'
    /// </summary>
    public static string TextData6 = "TextData6";
    /// <summary>
    /// Returns 'TextData7'
    /// </summary>
    public static string TextData7 = "TextData7";
    /// <summary>
    /// Returns 'TextData8'
    /// </summary>
    public static string TextData8 = "TextData8";
    /// <summary>
    /// Returns 'TextData9'
    /// </summary>
    public static string TextData9 = "TextData9";
    /// <summary>
    /// Returns 'TextData10'
    /// </summary>
    public static string TextData10 = "TextData10";
    /// <summary>
    /// Returns 'TextData11'
    /// </summary>
    public static string TextData11 = "TextData11";
    /// <summary>
    /// Returns 'TextData12'
    /// </summary>
    public static string TextData12 = "TextData12";
    /// <summary>
    /// Returns 'TextData13'
    /// </summary>
    public static string TextData13 = "TextData13";
    /// <summary>
    /// Returns 'TextData14'
    /// </summary>
    public static string TextData14 = "TextData14";
    /// <summary>
    /// Returns 'TextData15'
    /// </summary>
    public static string TextData15 = "TextData15";
    /// <summary>
    /// Returns 'TextData16'
    /// </summary>
    public static string TextData16 = "TextData16";
    /// <summary>
    /// Returns 'TextData17'
    /// </summary>
    public static string TextData17 = "TextData17";
    /// <summary>
    /// Returns 'TextData18'
    /// </summary>
    public static string TextData18 = "TextData18";
    /// <summary>
    /// Returns 'TextData19'
    /// </summary>
    public static string TextData19 = "TextData19";
    /// <summary>
    /// Returns 'TextData20'
    /// </summary>
    public static string TextData20 = "TextData20";
    /// <summary>
    /// Returns 'TextData21'
    /// </summary>
    public static string TextData21 = "TextData21";
    /// <summary>
    /// Returns 'TextData22'
    /// </summary>
    public static string TextData22 = "TextData22";
    /// <summary>
    /// Returns 'TextData23'
    /// </summary>
    public static string TextData23 = "TextData23";
    /// <summary>
    /// Returns 'TextData24'
    /// </summary>
    public static string TextData24 = "TextData24";
    /// <summary>
    /// Returns 'TextData25'
    /// </summary>
    public static string TextData25 = "TextData25";
    /// <summary>
    /// Returns 'TextData26'
    /// </summary>
    public static string TextData26 = "TextData26";
    /// <summary>
    /// Returns 'TextData27'
    /// </summary>
    public static string TextData27 = "TextData27";
    /// <summary>
    /// Returns 'TextData28'
    /// </summary>
    public static string TextData28 = "TextData28";
    /// <summary>
    /// Returns 'TextData29'
    /// </summary>
    public static string TextData29 = "TextData29";
    /// <summary>
    /// Returns 'TextData30'
    /// </summary>
    public static string TextData30 = "TextData30";
    /// <summary>
    /// Returns 'TextData31'
    /// </summary>
    public static string TextData31 = "TextData31";
    /// <summary>
    /// Returns 'TextData32'
    /// </summary>
    public static string TextData32 = "TextData32";
    /// <summary>
    /// Returns 'TextData33'
    /// </summary>
    public static string TextData33 = "TextData33";
    /// <summary>
    /// Returns 'TextData34'
    /// </summary>
    public static string TextData34 = "TextData34";
    /// <summary>
    /// Returns 'TextData35'
    /// </summary>
    public static string TextData35 = "TextData35";
    /// <summary>
    /// Returns 'TextData36'
    /// </summary>
    public static string TextData36 = "TextData36";
    /// <summary>
    /// Returns 'TextData37'
    /// </summary>
    public static string TextData37 = "TextData37";
    /// <summary>
    /// Returns 'TextData38'
    /// </summary>
    public static string TextData38 = "TextData38";
    /// <summary>
    /// Returns 'TextData39'
    /// </summary>
    public static string TextData39 = "TextData39";
    /// <summary>
    /// Returns 'TextData40'
    /// </summary>
    public static string TextData40 = "TextData40";
    /// <summary>
    /// Returns 'TextData41'
    /// </summary>
    public static string TextData41 = "TextData41";
    /// <summary>
    /// Returns 'TextData42'
    /// </summary>
    public static string TextData42 = "TextData42";
    /// <summary>
    /// Returns 'TextData43'
    /// </summary>
    public static string TextData43 = "TextData43";
    /// <summary>
    /// Returns 'TextData44'
    /// </summary>
    public static string TextData44 = "TextData44";
    /// <summary>
    /// Returns 'TextData45'
    /// </summary>
    public static string TextData45 = "TextData45";
    /// <summary>
    /// Returns 'TextData46'
    /// </summary>
    public static string TextData46 = "TextData46";
    /// <summary>
    /// Returns 'TextData47'
    /// </summary>
    public static string TextData47 = "TextData47";
    /// <summary>
    /// Returns 'TextData48'
    /// </summary>
    public static string TextData48 = "TextData48";
    /// <summary>
    /// Returns 'TextData49'
    /// </summary>
    public static string TextData49 = "TextData49";
    /// <summary>
    /// Returns 'TextData50'
    /// </summary>
    public static string TextData50 = "TextData50";
    /// <summary>
    /// Returns 'Trace'
    /// </summary>
    public static string Trace = "Trace";
    /// <summary>
    /// Returns 'UpdateDate'
    /// </summary>
    public static string UpdateDate = "UpdateDate";
    /// <summary>
    /// Returns 'UpdateName'
    /// </summary>
    public static string UpdateName = "UpdateName";
    /// <summary>
    /// Returns 'VeryImportantPerson'
    /// </summary>
    public static string VeryImportantPerson = "VeryImportantPerson";
    /// <summary>
    /// Returns 'PersonPhotoMainPhoto'
    /// </summary>
    public static string PersonPhotoMainPhoto = "PersonPhotoMainPhoto";
    /// <summary>
    /// Returns 'PersonPhotoAlternatePhoto'
    /// </summary>
    public static string PersonPhotoAlternatePhoto = "PersonPhotoAlternatePhoto";
    /// <summary>
    /// Returns 'AccessProfileUid'
    /// </summary>
    public static string AccessProfileUid = "AccessProfileUid";
    /// <summary>
    /// Returns 'AccessProfileName'
    /// </summary>
    public static string AccessProfileName = "AccessProfileName";
    /// <summary>
    /// Returns 'CredentialActivationDate'
    /// </summary>
    public static string CredentialActivationDate = "CredentialActivationDate";
    /// <summary>
    /// Returns 'CredentialDescription'
    /// </summary>
    public static string CredentialDescription = "CredentialDescription";
    /// <summary>
    /// Returns 'CredentialExpirationDateTime'
    /// </summary>
    public static string CredentialExpirationDateTime = "CredentialExpirationDateTime";
    /// <summary>
    /// Returns 'CredentialCardNumber'
    /// </summary>
    public static string CredentialCardNumber = "CredentialCardNumber";
    /// <summary>
    /// Returns 'Credential26BitStandardFacilityCode'
    /// </summary>
    public static string Credential26BitStandardFacilityCode = "Credential26BitStandardFacilityCode";
    /// <summary>
    /// Returns 'Credential26BitStandardIdCode'
    /// </summary>
    public static string Credential26BitStandardIdCode = "Credential26BitStandardIdCode";
    /// <summary>
    /// Returns 'CredentialCorporate1K35BitCompanyCode'
    /// </summary>
    public static string CredentialCorporate1K35BitCompanyCode = "CredentialCorporate1K35BitCompanyCode";
    /// <summary>
    /// Returns 'CredentialCorporate1K35BitIdCode'
    /// </summary>
    public static string CredentialCorporate1K35BitIdCode = "CredentialCorporate1K35BitIdCode";
    /// <summary>
    /// Returns 'CredentialCorporate1K48BitCompanyCode'
    /// </summary>
    public static string CredentialCorporate1K48BitCompanyCode = "CredentialCorporate1K48BitCompanyCode";
    /// <summary>
    /// Returns 'CredentialCorporate1K48BitIdCode'
    /// </summary>
    public static string CredentialCorporate1K48BitIdCode = "CredentialCorporate1K48BitIdCode";
    /// <summary>
    /// Returns 'CredentialCypress37BitFacilityCode'
    /// </summary>
    public static string CredentialCypress37BitFacilityCode = "CredentialCypress37BitFacilityCode";
    /// <summary>
    /// Returns 'CredentialCypress37BitIdCode'
    /// </summary>
    public static string CredentialCypress37BitIdCode = "CredentialCypress37BitIdCode";
    /// <summary>
    /// Returns 'CredentialH1030237BitIdCode'
    /// </summary>
    public static string CredentialH1030237BitIdCode = "CredentialH1030237BitIdCode";
    /// <summary>
    /// Returns 'CredentialH1030437BitFacilityCode'
    /// </summary>
    public static string CredentialH1030437BitFacilityCode = "CredentialH1030437BitFacilityCode";
    /// <summary>
    /// Returns 'CredentialH1030437BitIdCode'
    /// </summary>
    public static string CredentialH1030437BitIdCode = "CredentialH1030437BitIdCode";
    /// <summary>
    /// Returns 'CredentialSoftwareHouse37BitFacilityCode'
    /// </summary>
    public static string CredentialSoftwareHouse37BitFacilityCode = "CredentialSoftwareHouse37BitFacilityCode";
    /// <summary>
    /// Returns 'CredentialSoftwareHouse37BitSiteCode'
    /// </summary>
    public static string CredentialSoftwareHouse37BitSiteCode = "CredentialSoftwareHouse37BitSiteCode";
    /// <summary>
    /// Returns 'CredentialSoftwareHouse37BitIdCode'
    /// </summary>
    public static string CredentialSoftwareHouse37BitIdCode = "CredentialSoftwareHouse37BitIdCode";
    /// <summary>
    /// Returns 'CredentialXceedId40BitSiteCode'
    /// </summary>
    public static string CredentialXceedId40BitSiteCode = "CredentialXceedId40BitSiteCode";
    /// <summary>
    /// Returns 'CredentialXceedId40BitIdCode'
    /// </summary>
    public static string CredentialXceedId40BitIdCode = "CredentialXceedId40BitIdCode";
    /// <summary>
    /// Returns 'CountryName'
    /// </summary>
    public static string CountryName = "CountryName";
    /// <summary>
    /// Returns 'DepartmentName'
    /// </summary>
    public static string DepartmentName = "DepartmentName";
    /// <summary>
    /// Returns 'EntityName'
    /// </summary>
    public static string EntityName = "EntityName";
    /// <summary>
    /// Returns 'Gender'
    /// </summary>
    public static string Gender = "Gender";
    /// <summary>
    /// Returns 'PersonActiveStatusType'
    /// </summary>
    public static string PersonActiveStatusType = "PersonActiveStatusType";
    /// <summary>
    /// Returns 'PersonRecordType'
    /// </summary>
    public static string PersonRecordType = "PersonRecordType";
    /// <summary>
    /// Returns 'Date1'
    /// </summary>
    public static string Date1 = "Date1";
    /// <summary>
    /// Returns 'Date2'
    /// </summary>
    public static string Date2 = "Date2";
    /// <summary>
    /// Returns 'SelectItem1'
    /// </summary>
    public static string SelectItem1 = "SelectItem1";
    /// <summary>
    /// Returns 'SelectItem2'
    /// </summary>
    public static string SelectItem2 = "SelectItem2";
    /// <summary>
    /// Returns 'SelectItem3'
    /// </summary>
    public static string SelectItem3 = "SelectItem3";
    /// <summary>
    /// Returns 'SelectItem4'
    /// </summary>
    public static string SelectItem4 = "SelectItem4";
    /// <summary>
    /// Returns 'SelectItem5'
    /// </summary>
    public static string SelectItem5 = "SelectItem5";
    /// <summary>
    /// Returns 'SelectItem6'
    /// </summary>
    public static string SelectItem6 = "SelectItem6";
    /// <summary>
    /// Returns 'SelectItem7'
    /// </summary>
    public static string SelectItem7 = "SelectItem7";
    /// <summary>
    /// Returns 'SelectItem8'
    /// </summary>
    public static string SelectItem8 = "SelectItem8";
    /// <summary>
    /// Returns 'SelectItem9'
    /// </summary>
    public static string SelectItem9 = "SelectItem9";
    /// <summary>
    /// Returns 'SelectItem10'
    /// </summary>
    public static string SelectItem10 = "SelectItem10";
    /// <summary>
    /// Returns 'CurrentDate'
    /// </summary>
    public static string CurrentDate = "CurrentDate";
    /// <summary>
    /// Returns 'CurrentDateTime'
    /// </summary>
    public static string CurrentDateTime = "CurrentDateTime";
    /// <summary>
    /// Returns 'BadgeTemplateName'
    /// </summary>
    public static string BadgeTemplateName = "BadgeTemplateName";
    /// <summary>
    /// Returns 'DossierTemplateName'
    /// </summary>
    public static string DossierTemplateName = "DossierTemplateName";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the PersonCredentialBadgeDataView_ByPersonCredentialUidPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@PersonCredentialUid'
    /// </summary>
    public static string PersonCredentialUid = "@PersonCredentialUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}

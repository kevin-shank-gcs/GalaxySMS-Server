using System;
using System.Collections.Generic;
using System.Data;

using PDSA;
using PDSA.Common;
using PDSA.DataLayer;
using PDSA.DataLayer.DataClasses;
using PDSA.Validation;

using GalaxySMS.EntityLayer;
using GalaxySMS.ValidationLayer;
using GalaxySMS.DataLayer;

namespace GalaxySMS.BusinessLayer
{
    /// <summary>
    /// This class should be used when you need to select data for the PersonCredentialBadgeDataViewPDSA view.
    /// This class is generated using the Haystack Code Generator for .NET Utility.
    /// DO NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class PersonCredentialBadgeDataViewPDSAManager : PDSADataClassManagerReadOnlyBase
    {
        #region Constructors
        /// <summary>
        /// Constructor for the PersonCredentialBadgeDataViewPDSAManager class
        /// </summary>
        public PersonCredentialBadgeDataViewPDSAManager()
        {
            Init();
        }

        /// <summary>
        /// Constructor for the PersonCredentialBadgeDataViewPDSAManager class
        /// </summary>
        /// <param name="dataProvider">An instance of a PDSADataProvider</param>
        public PersonCredentialBadgeDataViewPDSAManager(PDSADataProvider dataProvider)
        {
            DataProvider = dataProvider;

            Init();
        }

        /// <summary>
        /// Constructor for the PersonCredentialBadgeDataViewPDSAManager class
        /// </summary>
        /// <param name="dataProviderName">The name of the DataProvider to use for all data access</param>
        public PersonCredentialBadgeDataViewPDSAManager(string dataProviderName) : base(dataProviderName)
        {
            // The base constructor calls the Init() method
        }
        #endregion

        #region Private variables
        private PersonCredentialBadgeDataViewPDSA _Entity = null;
        private PersonCredentialBadgeDataViewPDSA _SearchEntity = null;
        #endregion

        #region Public Properties
        /// <summary>
        /// Get/Set the entity class. This is the class that contains one property for each column in the table.
        /// </summary>
        public PersonCredentialBadgeDataViewPDSA Entity
        {
            get { return _Entity; }
            set
            {
                _Entity = value;
                if (Validator != null)
                    Validator.Entity = value;
                if (DataObject != null)
                    DataObject.Entity = value;
            }
        }

        /// <summary>
        /// Get/Set the Entity class used for searching
        /// </summary>
        public PersonCredentialBadgeDataViewPDSA SearchEntity
        {
            get
            {
                // Create Search Entity Class if not created
                if (_SearchEntity == null)
                {
                    _SearchEntity = new PersonCredentialBadgeDataViewPDSA();
                    InitSearchFilter();
                }

                return _SearchEntity;
            }
            set { _SearchEntity = value; }
        }

        /// <summary>
        /// Get/Set the validator class. This is the class that contains the business rules for the Entity class.
        /// </summary>
        public PersonCredentialBadgeDataViewPDSAValidator Validator { get; set; }
        /// <summary>
        /// Get/Set the data class that contains the CRUD logic for loading the Entity class
        /// </summary>
        public PersonCredentialBadgeDataViewPDSAData DataObject { get; set; }
        #endregion

        #region Init Method
        /// <summary>
        /// Initialize this class to a valid start state
        /// </summary>
        protected override void Init()
        {
            // Create Entity Class if not created
            if (Entity == null)
            {
                Entity = new PersonCredentialBadgeDataViewPDSA();

                // Set any default values on the Entity object
                InitEntityObject();
            }

            // Create Validator Class
            if (Validator == null)
                Validator = new PersonCredentialBadgeDataViewPDSAValidator(Entity);

            // Create Data Class if not created
            if (DataObject == null)
                DataObject = new PersonCredentialBadgeDataViewPDSAData(DataProvider, Entity, Validator);
            else
            {
                DataObject.DataProvider = DataProvider;
                DataObject.ValidatorObject = Validator;
                DataObject.Entity = Entity;
            }
            DataObject.CommandTimeout = Globals.Instance.SqlCommandTimeout;

            ClassName = "PersonCredentialBadgeDataViewPDSAManager";
        }
        #endregion

        #region DictionaryToEntity Method
        /// <summary>
        /// Takes the filled Dictionary object and puts the values into the Entity object
        /// </summary>
        /// <param name="values">A Dictionary object</param>
        /// <returns>An EmployeeType object</returns>
        public PersonCredentialBadgeDataViewPDSA DictionaryToEntity(Dictionary<string, string> values)
        {
            PersonCredentialBadgeDataViewPDSA ret = new PersonCredentialBadgeDataViewPDSA();

            // Initialize Entity Object
            InitEntityObject(ret);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.PersonUid))
                ret.PersonUid = PDSAProperty.ConvertToGuid(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.PersonUid]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.PersonCredentialUid))
                ret.PersonCredentialUid = PDSAProperty.ConvertToGuid(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.PersonCredentialUid]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.ActivationDateTime))
                ret.ActivationDateTime = Convert.ToDateTime(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.ActivationDateTime]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.Company))
                ret.Company = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.Company]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.ConcurrencyValue))
                ret.ConcurrencyValue = Convert.ToInt16(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.ConcurrencyValue]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.CountryOfBirthUid))
                ret.CountryOfBirthUid = PDSAProperty.ConvertToGuid(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.CountryOfBirthUid]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.DateOfBirth))
                ret.DateOfBirth = Convert.ToDateTime(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.DateOfBirth]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.DepartmentUid))
                ret.DepartmentUid = PDSAProperty.ConvertToGuid(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.DepartmentUid]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.EmploymentDate))
                ret.EmploymentDate = Convert.ToDateTime(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.EmploymentDate]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.EntityId))
                ret.EntityId = PDSAProperty.ConvertToGuid(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.EntityId]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.Ethnicity))
                ret.Ethnicity = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.Ethnicity]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.ExpirationDateTime))
                ret.ExpirationDateTime = Convert.ToDateTime(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.ExpirationDateTime]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.FirstName))
                ret.FirstName = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.FirstName]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.FullName))
                ret.FullName = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.FullName]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.GenderUid))
                ret.GenderUid = PDSAProperty.ConvertToGuid(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.GenderUid]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.HasPhysicalDisability))
                ret.HasPhysicalDisability = Convert.ToBoolean(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.HasPhysicalDisability]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.HasVertigo))
                ret.HasVertigo = Convert.ToBoolean(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.HasVertigo]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.HomeOfficeLocation))
                ret.HomeOfficeLocation = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.HomeOfficeLocation]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.Initials))
                ret.Initials = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.Initials]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.InsertDate))
                ret.InsertDate = Convert.ToDateTime(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.InsertDate]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.InsertName))
                ret.InsertName = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.InsertName]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.JobTitle))
                ret.JobTitle = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.JobTitle]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.LastName))
                ret.LastName = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.LastName]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.LegalName))
                ret.LegalName = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.LegalName]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.MiddleName))
                ret.MiddleName = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.MiddleName]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.NationalIdentificationNumber))
                ret.NationalIdentificationNumber = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.NationalIdentificationNumber]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.Nationality))
                ret.Nationality = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.Nationality]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.NickName))
                ret.NickName = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.NickName]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.OriginId))
                ret.OriginId = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.OriginId]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.PersonActiveStatusTypeUid))
                ret.PersonActiveStatusTypeUid = PDSAProperty.ConvertToGuid(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.PersonActiveStatusTypeUid]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.PersonId))
                ret.PersonId = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.PersonId]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.PersonRecordTypeUid))
                ret.PersonRecordTypeUid = PDSAProperty.ConvertToGuid(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.PersonRecordTypeUid]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.PreferredName))
                ret.PreferredName = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.PreferredName]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.PrimaryLanguage))
                ret.PrimaryLanguage = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.PrimaryLanguage]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.Race))
                ret.Race = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.Race]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.RowOrigin))
                ret.RowOrigin = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.RowOrigin]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.SecondaryLanguage))
                ret.SecondaryLanguage = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.SecondaryLanguage]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.SysGalEmployeeId))
                ret.SysGalEmployeeId = Convert.ToInt32(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.SysGalEmployeeId]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TerminationDate))
                ret.TerminationDate = Convert.ToDateTime(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TerminationDate]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData1))
                ret.TextData1 = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData1]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData2))
                ret.TextData2 = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData2]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData3))
                ret.TextData3 = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData3]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData4))
                ret.TextData4 = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData4]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData5))
                ret.TextData5 = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData5]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData6))
                ret.TextData6 = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData6]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData7))
                ret.TextData7 = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData7]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData8))
                ret.TextData8 = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData8]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData9))
                ret.TextData9 = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData9]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData10))
                ret.TextData10 = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData10]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData11))
                ret.TextData11 = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData11]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData12))
                ret.TextData12 = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData12]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData13))
                ret.TextData13 = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData13]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData14))
                ret.TextData14 = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData14]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData15))
                ret.TextData15 = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData15]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData16))
                ret.TextData16 = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData16]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData17))
                ret.TextData17 = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData17]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData18))
                ret.TextData18 = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData18]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData19))
                ret.TextData19 = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData19]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData20))
                ret.TextData20 = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData20]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData21))
                ret.TextData21 = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData21]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData22))
                ret.TextData22 = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData22]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData23))
                ret.TextData23 = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData23]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData24))
                ret.TextData24 = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData24]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData25))
                ret.TextData25 = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData25]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData26))
                ret.TextData26 = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData26]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData27))
                ret.TextData27 = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData27]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData28))
                ret.TextData28 = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData28]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData29))
                ret.TextData29 = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData29]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData30))
                ret.TextData30 = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData30]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData31))
                ret.TextData31 = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData31]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData32))
                ret.TextData32 = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData32]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData33))
                ret.TextData33 = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData33]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData34))
                ret.TextData34 = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData34]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData35))
                ret.TextData35 = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData35]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData36))
                ret.TextData36 = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData36]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData37))
                ret.TextData37 = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData37]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData38))
                ret.TextData38 = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData38]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData39))
                ret.TextData39 = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData39]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData40))
                ret.TextData40 = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData40]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData41))
                ret.TextData41 = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData41]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData42))
                ret.TextData42 = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData42]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData43))
                ret.TextData43 = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData43]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData44))
                ret.TextData44 = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData44]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData45))
                ret.TextData45 = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData45]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData46))
                ret.TextData46 = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData46]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData47))
                ret.TextData47 = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData47]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData48))
                ret.TextData48 = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData48]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData49))
                ret.TextData49 = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData49]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData50))
                ret.TextData50 = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.TextData50]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.Trace))
                ret.Trace = Convert.ToBoolean(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.Trace]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.UpdateDate))
                ret.UpdateDate = Convert.ToDateTime(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.UpdateDate]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.UpdateName))
                ret.UpdateName = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.UpdateName]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.VeryImportantPerson))
                ret.VeryImportantPerson = Convert.ToBoolean(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.VeryImportantPerson]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.PersonPhotoMainPhoto))
                ret.PersonPhotoMainPhoto = PDSAProperty.ConvertToByteArray(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.PersonPhotoMainPhoto]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.PersonPhotoAlternatePhoto))
                ret.PersonPhotoAlternatePhoto = PDSAProperty.ConvertToByteArray(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.PersonPhotoAlternatePhoto]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.AccessProfileUid))
                ret.AccessProfileUid = PDSAProperty.ConvertToGuid(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.AccessProfileUid]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.AccessProfileName))
                ret.AccessProfileName = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.AccessProfileName]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.CredentialActivationDate))
                ret.CredentialActivationDate = Convert.ToDateTime(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.CredentialActivationDate]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.CredentialDescription))
                ret.CredentialDescription = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.CredentialDescription]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.CredentialExpirationDateTime))
                ret.CredentialExpirationDateTime = Convert.ToDateTime(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.CredentialExpirationDateTime]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.CredentialCardNumber))
                ret.CredentialCardNumber = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.CredentialCardNumber]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.Credential26BitStandardFacilityCode))
                ret.Credential26BitStandardFacilityCode = Convert.ToInt16(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.Credential26BitStandardFacilityCode]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.Credential26BitStandardIdCode))
                ret.Credential26BitStandardIdCode = Convert.ToInt32(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.Credential26BitStandardIdCode]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.CredentialCorporate1K35BitCompanyCode))
                ret.CredentialCorporate1K35BitCompanyCode = Convert.ToInt32(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.CredentialCorporate1K35BitCompanyCode]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.CredentialCorporate1K35BitIdCode))
                ret.CredentialCorporate1K35BitIdCode = Convert.ToInt32(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.CredentialCorporate1K35BitIdCode]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.CredentialCorporate1K48BitCompanyCode))
                ret.CredentialCorporate1K48BitCompanyCode = Convert.ToInt32(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.CredentialCorporate1K48BitCompanyCode]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.CredentialCorporate1K48BitIdCode))
                ret.CredentialCorporate1K48BitIdCode = Convert.ToInt32(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.CredentialCorporate1K48BitIdCode]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.CredentialCypress37BitFacilityCode))
                ret.CredentialCypress37BitFacilityCode = Convert.ToInt32(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.CredentialCypress37BitFacilityCode]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.CredentialCypress37BitIdCode))
                ret.CredentialCypress37BitIdCode = Convert.ToInt32(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.CredentialCypress37BitIdCode]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.CredentialH1030237BitIdCode))
                ret.CredentialH1030237BitIdCode = Convert.ToInt64(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.CredentialH1030237BitIdCode]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.CredentialH1030437BitFacilityCode))
                ret.CredentialH1030437BitFacilityCode = Convert.ToInt32(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.CredentialH1030437BitFacilityCode]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.CredentialH1030437BitIdCode))
                ret.CredentialH1030437BitIdCode = Convert.ToInt32(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.CredentialH1030437BitIdCode]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.CredentialSoftwareHouse37BitFacilityCode))
                ret.CredentialSoftwareHouse37BitFacilityCode = Convert.ToInt32(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.CredentialSoftwareHouse37BitFacilityCode]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.CredentialSoftwareHouse37BitSiteCode))
                ret.CredentialSoftwareHouse37BitSiteCode = Convert.ToInt16(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.CredentialSoftwareHouse37BitSiteCode]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.CredentialSoftwareHouse37BitIdCode))
                ret.CredentialSoftwareHouse37BitIdCode = Convert.ToInt32(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.CredentialSoftwareHouse37BitIdCode]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.CredentialXceedId40BitSiteCode))
                ret.CredentialXceedId40BitSiteCode = Convert.ToInt32(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.CredentialXceedId40BitSiteCode]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.CredentialXceedId40BitIdCode))
                ret.CredentialXceedId40BitIdCode = Convert.ToInt32(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.CredentialXceedId40BitIdCode]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.CountryName))
                ret.CountryName = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.CountryName]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.DepartmentName))
                ret.DepartmentName = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.DepartmentName]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.EntityName))
                ret.EntityName = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.EntityName]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.Gender))
                ret.Gender = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.Gender]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.PersonActiveStatusType))
                ret.PersonActiveStatusType = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.PersonActiveStatusType]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.PersonRecordType))
                ret.PersonRecordType = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.PersonRecordType]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.Date1))
                ret.Date1 = Convert.ToDateTime(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.Date1]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.Date2))
                ret.Date2 = Convert.ToDateTime(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.Date2]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.SelectItem1))
                ret.SelectItem1 = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.SelectItem1]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.SelectItem2))
                ret.SelectItem2 = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.SelectItem2]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.SelectItem3))
                ret.SelectItem3 = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.SelectItem3]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.SelectItem4))
                ret.SelectItem4 = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.SelectItem4]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.SelectItem5))
                ret.SelectItem5 = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.SelectItem5]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.SelectItem6))
                ret.SelectItem6 = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.SelectItem6]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.SelectItem7))
                ret.SelectItem7 = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.SelectItem7]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.SelectItem8))
                ret.SelectItem8 = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.SelectItem8]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.SelectItem9))
                ret.SelectItem9 = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.SelectItem9]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.SelectItem10))
                ret.SelectItem10 = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.SelectItem10]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.CurrentDate))
                ret.CurrentDate = Convert.ToDateTime(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.CurrentDate]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.CurrentDateTime))
                ret.CurrentDateTime = Convert.ToDateTime(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.CurrentDateTime]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.BadgeTemplateName))
                ret.BadgeTemplateName = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.BadgeTemplateName]);

            if (values.ContainsKey(PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.DossierTemplateName))
                ret.DossierTemplateName = PDSAString.ConvertToStringTrim(values[PersonCredentialBadgeDataViewPDSAValidator.ColumnNames.DossierTemplateName]);

            return ret;
        }
        #endregion

        #region BuildCollection Method
        /// <summary>
        /// Returns a collection of PersonCredentialBadgeDataViewPDSA classes based on the filters set
        /// You can set the SearchEntity object with values to search on partial data
        /// prior to calling this method to filter the results
        /// </summary>
        /// <returns>PersonCredentialBadgeDataViewPDSACollection</returns>
        public PersonCredentialBadgeDataViewPDSACollection BuildCollection()
        {
            PersonCredentialBadgeDataViewPDSACollection coll = new PersonCredentialBadgeDataViewPDSACollection();
            PersonCredentialBadgeDataViewPDSA entity = null;
            DataSet ds;

            try
            {
                DataObject.Entity = Entity;
                ds = DataObject.GetDataSet();

                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[ds.Tables.Count - 1].Rows)
                    {
                        entity = DataObject.CreateEntityFromDataRow(dr);

                        // You can set any additional properties here

                        coll.Add(entity);
                    }
                }
            }
            catch (Exception ex)
            {
                // This is here for design time exceptions
                System.Diagnostics.Debug.WriteLine(ex.Message);
                var innerEx = ex.InnerException;
                while (innerEx != null)
                {
                    System.Diagnostics.Debug.WriteLine(innerEx.Message);
                    innerEx = innerEx.InnerException;
                }
            }

            return coll;
        }

        /// <summary>
        /// Build collection from a DataSet returned from a stored procedure
        /// </summary>
        /// <param name="ds">A DataSet</param>
        /// <returns>A collection of PersonCredentialBadgeDataViewPDSA objects</returns>
        public PersonCredentialBadgeDataViewPDSACollection BuildCollection(DataSet ds)
        {
            PersonCredentialBadgeDataViewPDSACollection coll = new PersonCredentialBadgeDataViewPDSACollection();

            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        coll.Add(DataObject.CreateEntityFromDataRow(item));
                    }
                }
            }

            return coll;
        }

        /// <summary>
        /// Build collection from a DataTable returned from a stored procedure
        /// </summary>
        /// <param name="dt">A DataTable</param>
        /// <returns>A collection of PersonCredentialBadgeDataViewPDSA objects</returns>
        public PersonCredentialBadgeDataViewPDSACollection BuildCollection(DataTable dt)
        {
            DataSet ds = new DataSet();

            ds.Tables.Add(dt);

            return BuildCollection(ds);
        }
        #endregion

        #region GetCollectionAsJSON Method
        /// <summary>
        /// Returns a collection of PersonCredentialBadgeDataViewPDSA objects as a JSON formatted string
        /// </summary>
        /// <returns>A JSON formatted string</returns>
        public string GetCollectionAsJSON()
        {
            return PDSAString.GetAsJSON(typeof(PersonCredentialBadgeDataViewPDSACollection), BuildCollection());
        }
        #endregion

        #region GetDataSet Method
        /// <summary>
        /// Get DataSet with all rows or with any filters you have set
        /// </summary>
        /// <returns>A DatSet object</returns>
        public DataSet GetDataSet()
        {
            return DataObject.GetDataSet();
        }

        /// <summary>
        /// Get DataSet using the SearchEntity object
        /// </summary>
        /// <returns>A DatSet object</returns>
        public DataSet GetDataSetUsingSearchFilters()
        {
            DataObject.SelectFilter = PersonCredentialBadgeDataViewPDSAData.SelectFilters.Search;

            // Create connection
            DataObject.CommandObject.Connection = DataProvider.CreateConnection(DataProvider.ConnectString);

            return DataProvider.GetDataSet(DataObject.CommandObject);
        }
        #endregion

        #region InitSearchFilter Method
        /// <summary>
        /// Re-Initialize a 'SearchEntity' property
        /// </summary>
        public void InitSearchFilter()
        {
            // Initialize Search Entity
            SearchEntity = InitSearchFilter(SearchEntity);
        }

        /// <summary>
        /// Re-Initialize a Search Entity object
        /// Usually you will use this to set the SearchEntity object
        /// 
        /// PersonCredentialBadgeDataViewPDSA.SearchEntity = mgr.InitSearchFilter(PersonCredentialBadgeDataViewPDSA.SearchEntity);
        /// </summary>
        /// <param name="searchEntity">A PersonCredentialBadgeDataViewPDSA object</param>
        /// <returns>An PersonCredentialBadgeDataViewPDSA object</returns>
        public PersonCredentialBadgeDataViewPDSA InitSearchFilter(PersonCredentialBadgeDataViewPDSA searchEntity)
        {
            searchEntity.Company = string.Empty;

            searchEntity.IsDirty = false;

            DataObject.SelectFilter = PersonCredentialBadgeDataViewPDSAData.SelectFilters.All;

            return searchEntity;
        }
        #endregion



        #region Clone Entity Class
        /// <summary>
        /// Clones the current PersonCredentialBadgeDataViewPDSA
        /// </summary>
        /// <returns>A cloned PersonCredentialBadgeDataViewPDSA object</returns>
        public PersonCredentialBadgeDataViewPDSA CloneEntity()
        {
            return CloneEntity(this.Entity);
        }

        /// <summary>
        /// Clones the passed in PersonCredentialBadgeDataViewPDSA
        /// </summary>
        /// <param name="entityToClone">The PersonCredentialBadgeDataViewPDSA entity to clone</param>
        /// <returns>A cloned PersonCredentialBadgeDataViewPDSA object</returns>
        public PersonCredentialBadgeDataViewPDSA CloneEntity(PersonCredentialBadgeDataViewPDSA entityToClone)
        {
            PersonCredentialBadgeDataViewPDSA newEntity = new PersonCredentialBadgeDataViewPDSA();

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
    }
}

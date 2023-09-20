using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
    /// <summary>
    /// Used to validate all parameters of the PersonSummary_SearchPDSA class.
    /// This class is generated using the Haystack Code Generator for .NET.
    /// You should NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class PersonSummary_SearchPDSAValidator : PDSAValidatorBase
    {
        #region Public Entity Property
        /// <summary>
        /// Get/Set the Entity class with the properties to validate
        /// </summary>
        private PersonSummary_SearchPDSA _Entity = null;

        /// <summary>
        /// Get/Set the Entity class with the properties to validate
        /// </summary>
        public new PersonSummary_SearchPDSA Entity
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
        /// Clones the current PersonSummary_SearchPDSA
        /// </summary>
        /// <returns>A cloned PersonSummary_SearchPDSA object</returns>
        public PersonSummary_SearchPDSA CloneEntity()
        {
            return CloneEntity(this.Entity);
        }

        /// <summary>
        /// Clones the passed in PersonSummary_SearchPDSA
        /// </summary>
        /// <param name="entityToClone">The PersonSummary_SearchPDSA entity to clone</param>
        /// <returns>A cloned PersonSummary_SearchPDSA object</returns>
        public PersonSummary_SearchPDSA CloneEntity(PersonSummary_SearchPDSA entityToClone)
        {
            PersonSummary_SearchPDSA newEntity = new PersonSummary_SearchPDSA();

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
            newEntity.SysGalEmployeeId = entityToClone.SysGalEmployeeId;
            newEntity.EntityName = entityToClone.EntityName;
            newEntity.DepartmentName = entityToClone.DepartmentName;
            newEntity.EntityId = entityToClone.EntityId;
            newEntity.ActivationDateTime = entityToClone.ActivationDateTime;
            newEntity.ExpirationDateTime = entityToClone.ExpirationDateTime;
            newEntity.InsertName = entityToClone.InsertName;
            newEntity.InsertDate = entityToClone.InsertDate;
            newEntity.UpdateName = entityToClone.UpdateName;
            newEntity.UpdateDate = entityToClone.UpdateDate;
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

            props.Add(PDSAProperty.Create(PersonSummary_SearchPDSAValidator.ParameterNames.EntityId, GetResourceMessage("GCS_PersonSummary_SearchPDSA_EntityId_Header", "Entity Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_PersonSummary_SearchPDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
            props.Add(PDSAProperty.Create(PersonSummary_SearchPDSAValidator.ParameterNames.UidValue, GetResourceMessage("GCS_PersonSummary_SearchPDSA_UidValue_Header", "Uid Value"), false, typeof(Guid), 0, GetResourceMessage("GCS_PersonSummary_SearchPDSA_UidValue_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
            props.Add(PDSAProperty.Create(PersonSummary_SearchPDSAValidator.ParameterNames.SearchByColumnNamesCSV, GetResourceMessage("GCS_PersonSummary_SearchPDSA_SearchByColumnNamesCSV_Header", "Search By Column Names CSV"), false, typeof(string), 8000, GetResourceMessage("GCS_PersonSummary_SearchPDSA_SearchByColumnNamesCSV_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
            props.Add(PDSAProperty.Create(PersonSummary_SearchPDSAValidator.ParameterNames.SearchData, GetResourceMessage("GCS_PersonSummary_SearchPDSA_SearchData_Header", "Search Data"), false, typeof(string), 8000, GetResourceMessage("GCS_PersonSummary_SearchPDSA_SearchData_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
            props.Add(PDSAProperty.Create(PersonSummary_SearchPDSAValidator.ParameterNames.SearchDataDelimiter, GetResourceMessage("GCS_PersonSummary_SearchPDSA_SearchDataDelimiter_Header", "Search Data Delimiter"), false, typeof(string), 8000, GetResourceMessage("GCS_PersonSummary_SearchPDSA_SearchDataDelimiter_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
            props.Add(PDSAProperty.Create(PersonSummary_SearchPDSAValidator.ParameterNames.CredentialPartNumber, GetResourceMessage("GCS_PersonSummary_SearchPDSA_CredentialPartNumber_Header", "Credential Part Number"), false, typeof(long), 0, GetResourceMessage("GCS_PersonSummary_SearchPDSA_CredentialPartNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt64("-9223372036854775808"), Convert.ToInt64("9223372036854775807"), 0, 0, @"", ""));
            props.Add(PDSAProperty.Create(PersonSummary_SearchPDSAValidator.ParameterNames.ExactMatch, GetResourceMessage("GCS_PersonSummary_SearchPDSA_ExactMatch_Header", "Exact Match"), false, typeof(short), 0, GetResourceMessage("GCS_PersonSummary_SearchPDSA_ExactMatch_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
            props.Add(PDSAProperty.Create(PersonSummary_SearchPDSAValidator.ParameterNames.OrderBy, GetResourceMessage("GCS_PersonSummary_SearchPDSA_OrderBy_Header", "Order By"), false, typeof(string), 8000, GetResourceMessage("GCS_PersonSummary_SearchPDSA_OrderBy_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
            props.Add(PDSAProperty.Create(PersonSummary_SearchPDSAValidator.ParameterNames.MaximumResults, GetResourceMessage("GCS_PersonSummary_SearchPDSA_MaximumResults_Header", "Maximum Results"), false, typeof(int), 0, GetResourceMessage("GCS_PersonSummary_SearchPDSA_MaximumResults_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
            props.Add(PDSAProperty.Create(PersonSummary_SearchPDSAValidator.ParameterNames.PageNumber, GetResourceMessage("GCS_PersonSummary_SearchPDSA_PageNumber_Header", "Page Number"), false, typeof(int), 0, GetResourceMessage("GCS_PersonSummary_SearchPDSA_PageNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
            props.Add(PDSAProperty.Create(PersonSummary_SearchPDSAValidator.ParameterNames.PageSize, GetResourceMessage("GCS_PersonSummary_SearchPDSA_PageSize_Header", "Page Size"), false, typeof(int), 0, GetResourceMessage("GCS_PersonSummary_SearchPDSA_PageSize_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
            props.Add(PDSAProperty.Create(PersonSummary_SearchPDSAValidator.ParameterNames.DateComparisonType, GetResourceMessage("GCS_PersonSummary_SearchPDSA_DateComparisonType_Header", "Date Comparison Type"), true, typeof(string), 8000, GetResourceMessage("GCS_PersonSummary_SearchPDSA_DateComparisonType_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
            props.Add(PDSAProperty.Create(PersonSummary_SearchPDSAValidator.ParameterNames.CultureName, GetResourceMessage("GCS_PersonSummary_SearchPDSA_CultureName_Header", "Culture Name"), false, typeof(string), 8000, GetResourceMessage("GCS_PersonSummary_SearchPDSA_CultureName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
            props.Add(PDSAProperty.Create(PersonSummary_SearchPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_PersonSummary_SearchPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_PersonSummary_SearchPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));

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

            this.Properties.GetByName(PersonSummary_SearchPDSAValidator.ParameterNames.EntityId).Value = Entity.EntityId;
            this.Properties.GetByName(PersonSummary_SearchPDSAValidator.ParameterNames.UidValue).Value = Entity.UidValue;
            this.Properties.GetByName(PersonSummary_SearchPDSAValidator.ParameterNames.SearchByColumnNamesCSV).Value = Entity.SearchByColumnNamesCSV;
            this.Properties.GetByName(PersonSummary_SearchPDSAValidator.ParameterNames.SearchData).Value = Entity.SearchData;
            this.Properties.GetByName(PersonSummary_SearchPDSAValidator.ParameterNames.SearchDataDelimiter).Value = Entity.SearchDataDelimiter;
            this.Properties.GetByName(PersonSummary_SearchPDSAValidator.ParameterNames.CredentialPartNumber).Value = Entity.CredentialPartNumber;
            this.Properties.GetByName(PersonSummary_SearchPDSAValidator.ParameterNames.ExactMatch).Value = Entity.ExactMatch;
            this.Properties.GetByName(PersonSummary_SearchPDSAValidator.ParameterNames.OrderBy).Value = Entity.OrderBy;
            this.Properties.GetByName(PersonSummary_SearchPDSAValidator.ParameterNames.MaximumResults).Value = Entity.MaximumResults;
            this.Properties.GetByName(PersonSummary_SearchPDSAValidator.ParameterNames.PageNumber).Value = Entity.PageNumber;
            this.Properties.GetByName(PersonSummary_SearchPDSAValidator.ParameterNames.PageSize).Value = Entity.PageSize;
            this.Properties.GetByName(PersonSummary_SearchPDSAValidator.ParameterNames.DateComparisonType).Value = Entity.DateComparisonType;
            this.Properties.GetByName(PersonSummary_SearchPDSAValidator.ParameterNames.CultureName).Value = Entity.CultureName;
            this.Properties.GetByName(PersonSummary_SearchPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

            if (this.Properties.GetByName(PersonSummary_SearchPDSAValidator.ParameterNames.EntityId).IsNull == false)
                Entity.EntityId = this.Properties.GetByName(PersonSummary_SearchPDSAValidator.ParameterNames.EntityId).GetAsGuid();
            if (this.Properties.GetByName(PersonSummary_SearchPDSAValidator.ParameterNames.UidValue).IsNull == false)
                Entity.UidValue = this.Properties.GetByName(PersonSummary_SearchPDSAValidator.ParameterNames.UidValue).GetAsGuid();
            if (this.Properties.GetByName(PersonSummary_SearchPDSAValidator.ParameterNames.SearchByColumnNamesCSV).IsNull == false)
                Entity.SearchByColumnNamesCSV = this.Properties.GetByName(PersonSummary_SearchPDSAValidator.ParameterNames.SearchByColumnNamesCSV).GetAsString();
            if (this.Properties.GetByName(PersonSummary_SearchPDSAValidator.ParameterNames.SearchData).IsNull == false)
                Entity.SearchData = this.Properties.GetByName(PersonSummary_SearchPDSAValidator.ParameterNames.SearchData).GetAsString();
            if (this.Properties.GetByName(PersonSummary_SearchPDSAValidator.ParameterNames.SearchDataDelimiter).IsNull == false)
                Entity.SearchDataDelimiter = this.Properties.GetByName(PersonSummary_SearchPDSAValidator.ParameterNames.SearchDataDelimiter).GetAsString();
            if (this.Properties.GetByName(PersonSummary_SearchPDSAValidator.ParameterNames.CredentialPartNumber).IsNull == false)
                Entity.CredentialPartNumber = this.Properties.GetByName(PersonSummary_SearchPDSAValidator.ParameterNames.CredentialPartNumber).GetAsLong();
            if (this.Properties.GetByName(PersonSummary_SearchPDSAValidator.ParameterNames.ExactMatch).IsNull == false)
                Entity.ExactMatch = this.Properties.GetByName(PersonSummary_SearchPDSAValidator.ParameterNames.ExactMatch).GetAsShort();
            if (this.Properties.GetByName(PersonSummary_SearchPDSAValidator.ParameterNames.OrderBy).IsNull == false)
                Entity.OrderBy = this.Properties.GetByName(PersonSummary_SearchPDSAValidator.ParameterNames.OrderBy).GetAsString();
            if (this.Properties.GetByName(PersonSummary_SearchPDSAValidator.ParameterNames.MaximumResults).IsNull == false)
                Entity.MaximumResults = this.Properties.GetByName(PersonSummary_SearchPDSAValidator.ParameterNames.MaximumResults).GetAsInteger();
            if (this.Properties.GetByName(PersonSummary_SearchPDSAValidator.ParameterNames.PageNumber).IsNull == false)
                Entity.PageNumber = this.Properties.GetByName(PersonSummary_SearchPDSAValidator.ParameterNames.PageNumber).GetAsInteger();
            if (this.Properties.GetByName(PersonSummary_SearchPDSAValidator.ParameterNames.PageSize).IsNull == false)
                Entity.PageSize = this.Properties.GetByName(PersonSummary_SearchPDSAValidator.ParameterNames.PageSize).GetAsInteger();
            if (this.Properties.GetByName(PersonSummary_SearchPDSAValidator.ParameterNames.DateComparisonType).IsNull == false)
                Entity.DateComparisonType = this.Properties.GetByName(PersonSummary_SearchPDSAValidator.ParameterNames.DateComparisonType).GetAsString();
            if (this.Properties.GetByName(PersonSummary_SearchPDSAValidator.ParameterNames.CultureName).IsNull == false)
                Entity.CultureName = this.Properties.GetByName(PersonSummary_SearchPDSAValidator.ParameterNames.CultureName).GetAsString();
            if (this.Properties.GetByName(PersonSummary_SearchPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
                Entity.RETURNVALUE = this.Properties.GetByName(PersonSummary_SearchPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
        }
        #endregion

        #region ColumnNames Class
        /// <summary>
        /// Contains static string properties that represent the name of each property in the PersonSummary_SearchPDSA class.
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

            /// <summary>   Identifier for the system gal employee. </summary>
            public static string SysGalEmployeeId = "SysGalEmployeeId";

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
            /// Returns '@UidValue'
            /// </summary>
            public static string UidValue = "@UidValue";

            /// <summary>
            /// Returns '@SearchByColumnNamesCSV'
            /// </summary>
            public static string SearchByColumnNamesCSV = "@SearchByColumnNamesCSV";
            /// <summary>
            /// Returns '@SearchData'
            /// </summary>
            public static string SearchData = "@SearchData";
            /// <summary>
            /// Returns '@SearchDataDelimiter'
            /// </summary>
            public static string SearchDataDelimiter = "@SearchDataDelimiter";
            /// <summary>
            /// Returns '@CredentialPartNumber'
            /// </summary>
            public static string CredentialPartNumber = "@CredentialPartNumber";
            /// <summary>
            /// Returns '@ExactMatch'
            /// </summary>
            public static string ExactMatch = "@ExactMatch";
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
            /// Returns '@RETURN_VALUE'
            /// </summary>
            public static string RETURNVALUE = "@RETURN_VALUE";
        }
        #endregion

        #region ParameterNames Class
        /// <summary>
        /// Contains static string properties that represent the name of each property in the PersonSummary_SearchPDSA class.
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
            /// Returns '@UidValue'
            /// </summary>
            public static string UidValue = "@UidValue";

            /// <summary>
            /// Returns '@SearchByColumnNamesCSV'
            /// </summary>
            public static string SearchByColumnNamesCSV = "@SearchByColumnNamesCSV";
            /// <summary>
            /// Returns '@SearchData'
            /// </summary>
            public static string SearchData = "@SearchData";
            /// <summary>
            /// Returns '@SearchDataDelimiter'
            /// </summary>
            public static string SearchDataDelimiter = "@SearchDataDelimiter";
            /// <summary>
            /// Returns '@CredentialPartNumber'
            /// </summary>
            public static string CredentialPartNumber = "@CredentialPartNumber";
            /// <summary>
            /// Returns '@ExactMatch'
            /// </summary>
            public static string ExactMatch = "@ExactMatch";
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
            /// Returns '@RETURN_VALUE'
            /// </summary>
            public static string RETURNVALUE = "@RETURN_VALUE";
        }
        #endregion
    }
}

using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
    /// <summary>
    /// Used to validate all parameters of the Credential_GetActivityEventDataPDSA class.
    /// This class is generated using the Haystack Code Generator for .NET.
    /// You should NOT modify this class as it is intended to be re-generated.
    /// </summary>
    public partial class Credential_GetActivityEventDataPDSAValidator : PDSAValidatorBase
    {
        #region Public Entity Property
        /// <summary>
        /// Get/Set the Entity class with the properties to validate
        /// </summary>
        private Credential_GetActivityEventDataPDSA _Entity = null;

        /// <summary>
        /// Get/Set the Entity class with the properties to validate
        /// </summary>
        public new Credential_GetActivityEventDataPDSA Entity
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
        /// Clones the current Credential_GetActivityEventDataPDSA
        /// </summary>
        /// <returns>A cloned Credential_GetActivityEventDataPDSA object</returns>
        public Credential_GetActivityEventDataPDSA CloneEntity()
        {
            return CloneEntity(this.Entity);
        }

        /// <summary>
        /// Clones the passed in Credential_GetActivityEventDataPDSA
        /// </summary>
        /// <param name="entityToClone">The Credential_GetActivityEventDataPDSA entity to clone</param>
        /// <returns>A cloned Credential_GetActivityEventDataPDSA object</returns>
        public Credential_GetActivityEventDataPDSA CloneEntity(Credential_GetActivityEventDataPDSA entityToClone)
        {
            Credential_GetActivityEventDataPDSA newEntity = new Credential_GetActivityEventDataPDSA();

            newEntity.CredentialUid = entityToClone.CredentialUid;
            newEntity.PersonUid = entityToClone.PersonUid;
            newEntity.PersonCredentialUid = entityToClone.PersonCredentialUid;
            newEntity.EntityId = entityToClone.EntityId;
            newEntity.ActivityEventText = entityToClone.ActivityEventText;
            newEntity.FirstName = entityToClone.FirstName;
            newEntity.MiddleName = entityToClone.MiddleName;
            newEntity.LastName = entityToClone.LastName;
            newEntity.FullName = entityToClone.FullName;
            newEntity.PreferredName = entityToClone.PreferredName;
            newEntity.LegalName = entityToClone.LegalName;
            newEntity.NickName = entityToClone.NickName;
            newEntity.CardNumber = entityToClone.CardNumber;
            newEntity.CardBinaryData = entityToClone.CardBinaryData;
            newEntity.PersonTrace = entityToClone.PersonTrace;
            newEntity.Company = entityToClone.Company;
            newEntity.EntityName = entityToClone.EntityName;
            newEntity.DepartmentUid = entityToClone.DepartmentUid;
            newEntity.DepartmentName = entityToClone.DepartmentName;
            newEntity.PersonRecordTypeUid = entityToClone.PersonRecordTypeUid;
            newEntity.RecordType = entityToClone.RecordType;
            newEntity.CredentialDescription = entityToClone.CredentialDescription;
            newEntity.CredentialTraceEnabled = entityToClone.CredentialTraceEnabled;
            newEntity.PersonExpirationModeUid = entityToClone.PersonExpirationModeUid;
            newEntity.UsageCount = entityToClone.UsageCount;
            newEntity.IsActive = entityToClone.IsActive;

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

            props.Add(PDSAProperty.Create(Credential_GetActivityEventDataPDSAValidator.ParameterNames.CardBinaryData, GetResourceMessage("GCS_Credential_GetActivityEventDataPDSA_CardBinaryData_Header", "Card Binary Data"), false, typeof(byte[]), 8000, GetResourceMessage("GCS_Credential_GetActivityEventDataPDSA_CardBinaryData_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, new byte[0], @"", ""));
            props.Add(PDSAProperty.Create(Credential_GetActivityEventDataPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_Credential_GetActivityEventDataPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_Credential_GetActivityEventDataPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));

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

            this.Properties.GetByName(Credential_GetActivityEventDataPDSAValidator.ParameterNames.CardBinaryData).Value = Entity.CardBinaryData;
            this.Properties.GetByName(Credential_GetActivityEventDataPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

            if (this.Properties.GetByName(Credential_GetActivityEventDataPDSAValidator.ParameterNames.CardBinaryData).IsNull == false)
                Entity.CardBinaryData = this.Properties.GetByName(Credential_GetActivityEventDataPDSAValidator.ParameterNames.CardBinaryData).GetAsByteArray();
            if (this.Properties.GetByName(Credential_GetActivityEventDataPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
                Entity.RETURNVALUE = this.Properties.GetByName(Credential_GetActivityEventDataPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
        }
        #endregion

        #region ColumnNames Class
        /// <summary>
        /// Contains static string properties that represent the name of each property in the Credential_GetActivityEventDataPDSA class.
        /// This class is generated by the Haystack Code Generator for .NET.
        /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
        /// </summary>
        public class ColumnNames
        {
            /// <summary>
            /// Returns 'CredentialUid'
            /// </summary>
            public static string CredentialUid = "CredentialUid";
            /// <summary>
            /// Returns 'PersonUid'
            /// </summary>
            public static string PersonUid = "PersonUid";
            /// <summary>
            /// Returns 'PersonCredentialUid'
            /// </summary>
            public static string PersonCredentialUid = "PersonCredentialUid";
            /// <summary>
            /// Returns 'EntityId'
            /// </summary>
            public static string EntityId = "EntityId";
            /// <summary>
            /// Returns 'ActivityEventText'
            /// </summary>
            public static string ActivityEventText = "ActivityEventText";
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
            /// Returns 'FullName'
            /// </summary>
            public static string FullName = "FullName";
            /// <summary>
            /// Returns 'PreferredName'
            /// </summary>
            public static string PreferredName = "PreferredName";
            /// <summary>
            /// Returns 'LegalName'
            /// </summary>
            public static string LegalName = "LegalName";
            /// <summary>
            /// Returns 'NickName'
            /// </summary>
            public static string NickName = "NickName";
            /// <summary>
            /// Returns 'CardNumber'
            /// </summary>
            public static string CardNumber = "CardNumber";
            /// <summary>
            /// Returns 'CardBinaryData'
            /// </summary>
            public static string CardBinaryData = "CardBinaryData";
            /// <summary>
            /// Returns 'PersonTrace'
            /// </summary>
            public static string PersonTrace = "PersonTrace";
            /// <summary>
            /// Returns 'Company'
            /// </summary>
            public static string Company = "Company";
            /// <summary>
            /// Returns 'EntityName'
            /// </summary>
            public static string EntityName = "EntityName";
            /// <summary>
            /// Returns 'DepartmentUid'
            /// </summary>
            public static string DepartmentUid = "DepartmentUid";
            /// <summary>
            /// Returns 'DepartmentName'
            /// </summary>
            public static string DepartmentName = "DepartmentName";
            /// <summary>
            /// Returns 'PersonRecordTypeUid'
            /// </summary>
            public static string PersonRecordTypeUid = "PersonRecordTypeUid";
            /// <summary>
            /// Returns 'RecordType'
            /// </summary>
            public static string RecordType = "RecordType";
            /// <summary>
            /// Returns 'CredentialDescription'
            /// </summary>
            public static string CredentialDescription = "CredentialDescription";
            /// <summary>
            /// Returns 'CredentialTraceEnabled'
            /// </summary>
            public static string CredentialTraceEnabled = "CredentialTraceEnabled";

            /// <summary>   The person expiration mode UID. </summary>
            public static string PersonExpirationModeUid = "PersonExpirationModeUid";

            /// <summary>   Number of usages. </summary>
            public static string UsageCount = "UsageCount";

            /// <summary>   The is active. </summary>
            public static string IsActive = "IsActive";
            /// <summary>
            /// Returns '@RETURN_VALUE'
            /// </summary>
            public static string RETURNVALUE = "@RETURN_VALUE";
        }
        #endregion

        #region ParameterNames Class
        /// <summary>
        /// Contains static string properties that represent the name of each property in the Credential_GetActivityEventDataPDSA class.
        /// This class is generated by the Haystack Code Generator for .NET.
        /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
        /// </summary>
        public class ParameterNames
        {
            /// <summary>
            /// Returns '@CardBinaryData'
            /// </summary>
            public static string CardBinaryData = "@CardBinaryData";
            /// <summary>
            /// Returns '@RETURN_VALUE'
            /// </summary>
            public static string RETURNVALUE = "@RETURN_VALUE";
        }
        #endregion
    }
}

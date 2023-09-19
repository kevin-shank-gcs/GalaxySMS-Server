////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\ExtendedClasses\CredentialFormat.cs
//
// summary:	Implements the credential format class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GalaxySMS.Common.Interfaces;
using GCS.Core.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A credential format. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class CredentialFormat
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CredentialFormat() : base()
        {
            Initialize();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The CredentialFormat to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CredentialFormat(CredentialFormat e) : base(e)
        {
            Initialize(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this CredentialFormat. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize()
        {
            base.Initialize();
            //this.Credentials = new HashSet<Credential>();
            this.CredentialFormatDataFields = new HashSet<ICredentialFormatDataField>();
            this.CredentialFormatParities = new HashSet<ICredentialFormatParity>();
            EntityIds = new HashSet<Guid>();
            MappedEntitiesPermissionLevels = new HashSet<EntityIdEntityMapPermissionLevel>();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this CredentialFormat. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The CredentialFormat to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize(CredentialFormat e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.CredentialFormatUid = e.CredentialFormatUid;
            this.DisplayResourceKey = e.DisplayResourceKey;
            this.DescriptionResourceKey = e.DescriptionResourceKey;
            this.Display = e.Display;
            this.Description = e.Description;
            this.CredentialFormatCode = e.CredentialFormatCode;
            this.BitLength = e.BitLength;
            this.IsEnabled = e.IsEnabled;
            this.BiometricEnrollmentSupported = e.BiometricEnrollmentSupported;
            this.BiometricIdField = e.BiometricIdField;
            this.UseCardNumber = e.UseCardNumber;
            this.BatchLoadSupported = e.BatchLoadSupported;
            this.BatchLoadIncrementField = e.BatchLoadIncrementField;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            //this.Credentials = e.Credentials.ToCollection();
            this.CredentialFormatDataFields = e.CredentialFormatDataFields.ToCollection();
            this.CredentialFormatParities = e.CredentialFormatParities.ToCollection();

            if (e.EntityIds != null)
                this.EntityIds = e.EntityIds.ToCollection();

            if (e.MappedEntitiesPermissionLevels != null)
                this.MappedEntitiesPermissionLevels = e.MappedEntitiesPermissionLevels.ToCollection();

            IsAllowed = e.IsAllowed;
            EntityId = e.EntityId;

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Makes a deep copy of this CredentialFormat. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The CredentialFormat to process. </param>
        ///
        /// <returns>   A copy of this CredentialFormat. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CredentialFormat Clone(CredentialFormat e)
        {
            return new CredentialFormat(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tests if this CredentialFormat is considered equal to another. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="other">    The other. </param>
        ///
        /// <returns>   True if the objects are considered equal, false if they are not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool Equals(CredentialFormat other)
        {
            return base.Equals(other);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if 'other' is primary key equal. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="other">    The other. </param>
        ///
        /// <returns>   True if primary key equal, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool IsPrimaryKeyEqual(CredentialFormat other)
        {
            if (other == null)
                return false;

            if (other.CredentialFormatUid != this.CredentialFormatUid)
                return false;
            return true;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Serves as the default hash function. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   A hash code for the current object. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Returns a string that represents the current object. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   A string that represents the current object. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public override string ToString()
        {
            return base.ToString();
        }

        /// <summary>   True if this CredentialFormat is allowed for the entity. </summary>
        private bool _isAllowed;

        [DataMember]
        public bool IsAllowed
        {
            get { return _isAllowed; }
            set
            {
                if (_isAllowed != value)
                {
                    _isAllowed = value;
                    OnPropertyChanged(() => IsAllowed);
                }
            }
        }


        /// <summary>   True if this CredentialFormat is allowed for the entity. </summary>
        private Guid _entityId;

        [DataMember]
        public Guid EntityId
        {
            get { return _entityId; }
            set
            {
                if (_entityId != value)
                {
                    _entityId = value;
                    OnPropertyChanged(() => EntityId);
                }
            }
        }

    }
}

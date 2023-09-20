////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\ExtendedClasses\PersonCredential.cs
//
// summary:	Implements the person credential class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GCS.Core.Common.Core;
using GCS.Core.Common.Contracts;
using FluentValidation;
using System.Collections.ObjectModel;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A person credential. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class PersonCredential
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public PersonCredential() : base()
        {
            Initialize();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The PersonCredential to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public PersonCredential(PersonCredential e) : base(e)
        {
            Initialize(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this PersonCredential. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize()
        {
            base.Initialize();
            this.PersonClusterPermissions = new HashSet<PersonClusterPermission>();
            this.PersonCredentialCommandScripts = new HashSet<PersonCredentialCommandScript>();
            this.Credential = new Credential();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this PersonCredential. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The PersonCredential to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize(PersonCredential e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.PersonCredentialUid = e.PersonCredentialUid;
            this.CredentialUid = e.CredentialUid;
            this.PersonUid = e.PersonUid;
            this.PersonCredentialRoleUid = e.PersonCredentialRoleUid;
            this.PersonActivationModeUid = e.PersonActivationModeUid;
            this.PersonExpirationModeUid = e.PersonExpirationModeUid;
            this.BadgeTemplateUid = e.BadgeTemplateUid;
            this.DossierBadgeTemplateUid = e.DossierBadgeTemplateUid;
            this.AccessPortalNoServerReplyBehaviorUid = e.AccessPortalNoServerReplyBehaviorUid;
            this.AccessPortalDeferToServerBehaviorUid = e.AccessPortalDeferToServerBehaviorUid;
            this.CredentialDescription = e.CredentialDescription;
            this.ActivationDateTime = e.ActivationDateTime;
            this.ExpirationDateTime = e.ExpirationDateTime;
            this.UsageCount = e.UsageCount;
            this.TraceEnabled = e.TraceEnabled;
            this.DuressEnabled = e.DuressEnabled;
            this.ReverseBits = e.ReverseBits;
            this.IsActive = e.IsActive;
            this.BiometricEnrollmentStatus = e.BiometricEnrollmentStatus;
            this.BadgePrintLimit = e.BadgePrintLimit;
            this.BadgePrintCount = e.BadgePrintCount;
            this.BadgeLastPrinted = e.BadgeLastPrinted;
            this.DossierPrintLimit = e.DossierPrintLimit;
            this.DossierPrintCount = e.DossierPrintCount;
            this.DossierLastPrinted = e.DossierLastPrinted;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.PersonClusterPermissions = e.PersonClusterPermissions.ToCollection();
            this.PersonCredentialCommandScripts = e.PersonCredentialCommandScripts.ToCollection();
            this.Credential = e.Credential;

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Makes a deep copy of this PersonCredential. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The PersonCredential to process. </param>
        ///
        /// <returns>   A copy of this PersonCredential. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public PersonCredential Clone(PersonCredential e)
        {
            return new PersonCredential(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tests if this PersonCredential is considered equal to another. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="other">    The other. </param>
        ///
        /// <returns>   True if the objects are considered equal, false if they are not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool Equals(PersonCredential other)
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

        public bool IsPrimaryKeyEqual(PersonCredential other)
        {
            if (other == null)
                return false;

            if (other.PersonCredentialUid != this.PersonCredentialUid)
                return false;
            return true;
        }

        /// <summary>   True if this PersonCredential is selected. </summary>
        private bool _isSelected;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether this PersonCredential is selected. </summary>
        ///
        /// <value> True if this PersonCredential is selected, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    OnPropertyChanged(() => IsSelected, false);
                }
            }
        }

        private BadgePreviewData _BadgePreviewData;

        public BadgePreviewData BadgePreviewData
        {
            get { return _BadgePreviewData; }
            set
            {
                if (_BadgePreviewData != value)
                {
                    _BadgePreviewData = value;
                    OnPropertyChanged(() => BadgePreviewData, false);
                }
            }
        }

        private BadgePreviewData _DossierPreviewData;

        public BadgePreviewData DossierPreviewData
        {
            get { return _DossierPreviewData; }
            set
            {
                if (_DossierPreviewData != value)
                {
                    _DossierPreviewData = value;
                    OnPropertyChanged(() => DossierPreviewData, false);
                }
            }
        }



        private Printer _selectedPrinter;

        public Printer SelectedPrinter
        {
            get { return _selectedPrinter; }
            set
            {
                if (_selectedPrinter != value)
                {
                    _selectedPrinter = value;
                    OnPropertyChanged(() => SelectedPrinter, false);
                }
            }
        }

        private PrintDispatcher _selectedPrintDispatcher;

        public PrintDispatcher SelectedPrintDispatcher
        {
            get { return _selectedPrintDispatcher; }
            set
            {
                if (_selectedPrintDispatcher != value)
                {
                    _selectedPrintDispatcher = value;
                    OnPropertyChanged(() => SelectedPrintDispatcher, false);
                }
            }
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
    }
}

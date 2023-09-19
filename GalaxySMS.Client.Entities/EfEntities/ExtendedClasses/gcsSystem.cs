////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\ExtendedClasses\gcsSystem.cs
//
// summary:	Implements the gcs system class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GCS.Core.Common.Core;
using FluentValidation;
using System.Collections.ObjectModel;
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The gcs system. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class gcsSystem
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsSystem()
        {
            Initialize();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The gcsSystem to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsSystem(gcsSystem e)
        {
            Initialize(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this gcsSystem. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize()
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this gcsSystem. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The gcsSystem to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize(gcsSystem e)
        {
            Initialize();
            if (e == null)
                return;
            this.SystemId = e.SystemId;
            this.License = e.License;
            this.PublicKey = e.PublicKey;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.SystemName = e.SystemName;
            this.CompanyName = e.CompanyName;
            this.CompanyEmail = e.CompanyEmail;
            this.SupportCompany = e.SupportCompany;
            this.SupportContact = e.SupportContact;
            this.SupportPhone = e.SupportPhone;
            this.SupportEmail = e.SupportEmail;
            this.SupportUrl = e.SupportUrl;
            this.SupportImage = e.SupportImage;
            this.SystemImage = e.SystemImage;
            this.SystemVersion = e.SystemVersion;
            this.IdProducerRootData = e.IdProducerRootData;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Makes a deep copy of this gcsSystem. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The gcsSystem to process. </param>
        ///
        /// <returns>   A copy of this gcsSystem. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsSystem Clone(gcsSystem e)
        {
            return new gcsSystem(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tests if this gcsSystem is considered equal to another. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="other">    The other. </param>
        ///
        /// <returns>   True if the objects are considered equal, false if they are not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool Equals(gcsSystem other)
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

        public bool IsPrimaryKeyEqual(gcsSystem other)
        {
            if (other == null)
                return false;

            if (other.SystemId != this.SystemId)
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

        private SubscriptionData _idProducerRootData;

        [DataMember]

        public SubscriptionData IdProducerRootData
        {
            get { return _idProducerRootData; }
            set
            {
                if (_idProducerRootData != value)
                {
                    _idProducerRootData = value;
                    OnPropertyChanged(() => IdProducerRootData, false);
                }
            }
        }


        public GalaxySMS.Common.Enums.IdProducerLicenseType IdProducerLicenseType
        {
            get
            {
                if (IdProducerRootData == null)
                    return GalaxySMS.Common.Enums.IdProducerLicenseType.None;
                if (IdProducerRootData?.FriendlyLicenseDetails.MaxCustomerCount == 0)
                    return GalaxySMS.Common.Enums.IdProducerLicenseType.Basic;
                return GalaxySMS.Common.Enums.IdProducerLicenseType.Advanced;
            }
            set
            {
                OnPropertyChanged(() => IdProducerLicenseType, false);
            }
        }


        public GalaxySMS.Common.Enums.YesNo IdProducerSupportsMultiplePrinters
        {
            get
            {
                if (IdProducerRootData == null || IdProducerRootData.FriendlyLicenseDetails?.SupportsMultiplePrinters == false ||  IdProducerRootData.FriendlyLicenseDetails?.LicensedMaxPrinterCount == 0)
                    return YesNo.No;

                return YesNo.Yes;
            }
            set
            {
                OnPropertyChanged(() => IdProducerSupportsMultiplePrinters, false);
            }
        }

        public GalaxySMS.Common.Enums.YesNo IdProducerSupportsMultipleCustomers
        {
            get
            {
                if (IdProducerRootData == null || IdProducerRootData.FriendlyLicenseDetails?.MaxCustomerCount == 0)
                    return YesNo.No;

                return YesNo.Yes;
            }
            set
            {
                OnPropertyChanged(() => IdProducerSupportsMultipleCustomers, false);
            }
        }

        private bool _IsLicenseValid;

        [DataMember]
        public bool IsLicenseValid
        {
            get { return _IsLicenseValid; }
            set
            {
                if (_IsLicenseValid != value)
                {
                    _IsLicenseValid = value;
                    OnPropertyChanged(() => IsLicenseValid, false);
                }
            }
        }


    }
}


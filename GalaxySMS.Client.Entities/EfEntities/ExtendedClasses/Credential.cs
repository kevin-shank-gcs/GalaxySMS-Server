////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\ExtendedClasses\Credential.cs
//
// summary:	Implements the credential class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GCS.Core.Common.Core;
using GCS.Core.Common.Contracts;
using FluentValidation;
using System.Collections.ObjectModel;
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A credential. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class Credential
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Credential() : base()
        {
            Initialize();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The Credential to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Credential(Credential e) : base(e)
        {
            Initialize(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this Credential. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize()
        {
            base.Initialize();
            if (this.Bqt36Bit == null)
                this.Bqt36Bit = new CredentialBqt36Bit();
            if (this.Standard26Bit == null)
                this.Standard26Bit = new Credential26BitStandard();
            if (this.Corporate1K35Bit == null)
                this.Corporate1K35Bit = new CredentialCorporate1K35Bit();
            if (this.Corporate1K48Bit == null)
                this.Corporate1K48Bit = new CredentialCorporate1K48Bit();
            if (this.Cypress37Bit == null)
                this.Cypress37Bit = new CredentialCypress37Bit();
            if (this.H1030437Bit == null)
                this.H1030437Bit = new CredentialH1030437Bit();
            if (this.H1030237Bit == null)
                this.H1030237Bit = new CredentialH1030237Bit();
            if (this.CredentialData == null)
                this.CredentialData = new CredentialData();
            if (this.PIV75Bit == null)
                this.PIV75Bit = new CredentialPIV75Bit();
            if (this.XceedId40Bit == null)
                this.XceedId40Bit = new CredentialXceedId40Bit();
            if (this.SoftwareHouse37Bit == null)
                this.SoftwareHouse37Bit = new CredentialSoftwareHouse37Bit();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this Credential. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The Credential to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize(Credential e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.CredentialUid = e.CredentialUid;
            this.CredentialFormatUid = e.CredentialFormatUid;
            this.CardNumber = e.CardNumber;
            this.CardNumberIsHex = e.CardNumberIsHex;
            this.CardBinaryData = e.CardBinaryData;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.BitCount = e.BitCount;

            this.Bqt36Bit = e.Bqt36Bit;
            this.Corporate1K35Bit = e.Corporate1K35Bit;
            this.Corporate1K48Bit = e.Corporate1K48Bit;
            this.CredentialFormat = e.CredentialFormat;
            this.Cypress37Bit = e.Cypress37Bit;
            this.CredentialData = e.CredentialData;
            this.H1030437Bit = e.H1030437Bit;
            this.H1030237Bit = e.H1030237Bit;
            this.PIV75Bit = e.PIV75Bit;
            this.XceedId40Bit = e.XceedId40Bit;
            this.SoftwareHouse37Bit = e.SoftwareHouse37Bit;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Makes a deep copy of this Credential. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The Credential to process. </param>
        ///
        /// <returns>   A copy of this Credential. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Credential Clone(Credential e)
        {
            return new Credential(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tests if this Credential is considered equal to another. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="other">    The other. </param>
        ///
        /// <returns>   True if the objects are considered equal, false if they are not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool Equals(Credential other)
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

        public bool IsPrimaryKeyEqual(Credential other)
        {
            if (other == null)
                return false;

            if (other.CredentialUid != this.CredentialUid)
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

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Ensures that credential exists. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void EnsureCredentialExists()
        {
            if( this.CredentialFormat == null)
                return;

            switch (this.CredentialFormat.CredentialFormatCode)
            {
                case CredentialFormatCodes.NumericCardCode:
                    break;
                case CredentialFormatCodes.MagneticStripeBarcodeAba:
                    break;
                case CredentialFormatCodes.Standard26Bit:
                    if (this.Standard26Bit == null)
                        this.Standard26Bit = new Credential26BitStandard();
                    break;
                case CredentialFormatCodes.GalaxyKeypad:
                    break;
                case CredentialFormatCodes.Corporate1K35Bit:
                    if (this.Corporate1K35Bit == null)
                        this.Corporate1K35Bit = new CredentialCorporate1K35Bit();
                    break;
                case CredentialFormatCodes.PIV75Bit:
                    if (this.PIV75Bit == null)
                        this.PIV75Bit = new CredentialPIV75Bit();
                    break;
                case CredentialFormatCodes.Bqt36Bit:
                    if (this.Bqt36Bit == null)
                        this.Bqt36Bit = new CredentialBqt36Bit();
                    break;
                case CredentialFormatCodes.XceedId40Bit:
                    if (this.XceedId40Bit == null)
                        this.XceedId40Bit = new CredentialXceedId40Bit();
                    break;
                case CredentialFormatCodes.USGovernmentID:
                    break;
                case CredentialFormatCodes.Corporate1K48Bit:
                    if (this.Corporate1K48Bit == null)
                        this.Corporate1K48Bit = new CredentialCorporate1K48Bit();
                    break;
                case CredentialFormatCodes.Cypress37Bit:
                    if (this.Cypress37Bit == null)
                        this.Cypress37Bit = new CredentialCypress37Bit();
                    break;
                case CredentialFormatCodes.H1030437Bit:
                    if (this.H1030437Bit == null)
                        this.H1030437Bit = new CredentialH1030437Bit();
                    break;
                case CredentialFormatCodes.H1030237Bit:
                    if (this.H1030237Bit == null)
                        this.H1030237Bit = new CredentialH1030237Bit();
                    break;
                case CredentialFormatCodes.SoftwareHouse37Bit:
                    if (this.SoftwareHouse37Bit == null)
                        this.SoftwareHouse37Bit = new CredentialSoftwareHouse37Bit();
                    break;
                case CredentialFormatCodes.None:
                    break;
                default:
                    if (this.CredentialData == null)
                        this.CredentialData = new CredentialData();
                    break;
            }
        }

    }
}

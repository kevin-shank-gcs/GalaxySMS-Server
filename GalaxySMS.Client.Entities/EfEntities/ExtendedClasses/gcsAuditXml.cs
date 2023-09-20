
////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\gcsAuditXml.cs
//
// summary:	Implements the gcs audit XML class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GCS.Core.Common.Core;
using FluentValidation;
using System.Collections.ObjectModel;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The gcs audit xml. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class gcsAuditXml
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsAuditXml()
        {
            Initialize();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The gcsAuditXml to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsAuditXml(gcsAuditXml e)
        {
            Initialize(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this gcsAuditXml. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize()
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this gcsAuditXml. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The gcsAuditXml to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize(gcsAuditXml e)
        {
            Initialize();
            if (e == null)
                return;
            this.AuditId = e.AuditId;
            this.Type = e.Type;
            this.TableName = e.TableName;
            this.PKField = e.PKField;
            this.PKValue = e.PKValue;
            this.FieldName = e.FieldName;
            this.OldValue = e.OldValue;
            this.NewValue = e.NewValue;
            this.XmlText = e.XmlText;
            this.UpdateDateTime = e.UpdateDateTime;
            this.UserName = e.UserName;
            this.HostMachineName = e.HostMachineName;
            this.AppName = e.AppName;
            this.NTDomain = e.NTDomain;
            this.NTUserName = e.NTUserName;
            this.NETAddress = e.NETAddress;
            this.ApplicationUserId = e.ApplicationUserId;
            this.TransactionID = e.TransactionID;
            this.Description = e.Description;

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Makes a deep copy of this gcsAuditXml. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The gcsAuditXml to process. </param>
        ///
        /// <returns>   A copy of this gcsAuditXml. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsAuditXml Clone(gcsAuditXml e)
        {
            return new gcsAuditXml(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tests if this gcsAuditXml is considered equal to another. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="other">    The other. </param>
        ///
        /// <returns>   True if the objects are considered equal, false if they are not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool Equals(gcsAuditXml other)
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

        public bool IsPrimaryKeyEqual(gcsAuditXml other)
        {
            if (other == null)
                return false;

            if (other.AuditId != this.AuditId)
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
    }
}




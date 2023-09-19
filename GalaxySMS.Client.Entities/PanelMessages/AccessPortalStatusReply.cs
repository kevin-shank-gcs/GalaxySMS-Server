////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	PanelMessages\AccessPortalStatusReply.cs
//
// summary:	Implements the access portal status reply class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GalaxySMS.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The access portal status reply. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class AccessPortalStatusReply : PanelMessageBase
    {
        /// <summary>   The access portal UID. </summary>
        private Guid _accessPortalUid;
        /// <summary>   The access portal status. </summary>
        private AccessPortalStatus _AccessPortalStatus;
        /// <summary>   The contact status. </summary>
        private AccessPortalContactStatus _contactStatus;
        /// <summary>   The lock status. </summary>
        private AccessPortalLockStatus _lockStatus;
        /// <summary>   The credential reader status. </summary>
        private CredentialReaderStatus _CredentialReaderStatus;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 1/3/2019. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AccessPortalStatusReply()
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 1/3/2019. </remarks>
        ///
        /// <param name="b">    The PanelMessageBase to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AccessPortalStatusReply(PanelMessageBase b)
            : base(b)
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 1/3/2019. </remarks>
        ///
        /// <param name="o">    The AccessPortalStatusReply to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AccessPortalStatusReply(AccessPortalStatusReply o)
            : base(o)
        {
            if (o != null)
            {
                AccessPortalUid = o.AccessPortalUid;
                AccessPortalStatus = o.AccessPortalStatus;
                ContactStatus = o.ContactStatus;
                LockStatus = o.LockStatus;
                CredentialReaderStatus = o.CredentialReaderStatus;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the access portal UID. </summary>
        ///
        /// <value> The access portal UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid AccessPortalUid
        {
            get { return _accessPortalUid; }
            set
            {
                if (_accessPortalUid != value)
                {
                    _accessPortalUid = value;
                    OnPropertyChanged(() => AccessPortalUid, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the access portal status. </summary>
        ///
        /// <value> The access portal status. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public AccessPortalStatus AccessPortalStatus
        {
            get { return _AccessPortalStatus; }
            set
            {
                if (_AccessPortalStatus != value)
                {
                    _AccessPortalStatus = value;
                    OnPropertyChanged(() => AccessPortalStatus, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the contact status. </summary>
        ///
        /// <value> The contact status. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public AccessPortalContactStatus ContactStatus
        {
            get { return _contactStatus; }
            set
            {
                if (_contactStatus != value)
                {
                    _contactStatus = value;
                    OnPropertyChanged(() => ContactStatus, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the lock status. </summary>
        ///
        /// <value> The lock status. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public AccessPortalLockStatus LockStatus
        {
            get { return _lockStatus; }
            set
            {
                if (_lockStatus != value)
                {
                    _lockStatus = value;
                    OnPropertyChanged(() => LockStatus, false);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the credential reader status. </summary>
        ///
        /// <value> The credential reader status. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public CredentialReaderStatus CredentialReaderStatus
        {
            get { return _CredentialReaderStatus; }
            set
            {
                if (_CredentialReaderStatus != value)
                {
                    _CredentialReaderStatus = value;
                    OnPropertyChanged(() => CredentialReaderStatus, false);
                }
            }
        }

    }

}

////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\DecodeRawCredentialNumberParameters.cs
//
// summary:	Implements the decode raw credential number parameters class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A decode credential number parameters. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class DecodeCredentialNumberParameters : DtoObjectBase
    {
        /// <summary>   Number of bits. </summary>
        private short _BitCount;
        /// <summary>   The credential number. </summary>
        private string _CredentialNumber;
        /// <summary>   The device UID. </summary>
        private Guid _deviceUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the number of bits. </summary>
        ///
        /// <value> The number of bits. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public short BitCount
        {
            get { return _BitCount; }
            set
            {
                if (_BitCount != value)
                {
                    _BitCount = value;
                    OnPropertyChanged(() => BitCount, true);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the credential number. </summary>
        ///
        /// <value> The credential number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string CredentialNumber
        {
            get { return _CredentialNumber; }
            set
            {
                if (_CredentialNumber != value)
                {
                    _CredentialNumber = value;
                    OnPropertyChanged(() => CredentialNumber, true);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the device UID. </summary>
        ///
        /// <value> The device UID. </value>
        ///=================================================================================================

        [DataMember]
        public Guid DeviceUid
        {
            get { return _deviceUid; }
            set
            {
                if (_deviceUid != value)
                {
                    _deviceUid = value;
                    OnPropertyChanged(() => DeviceUid, true);
                }
            }
        }

    }
}

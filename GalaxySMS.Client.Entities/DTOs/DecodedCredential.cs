////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\DecodedCredential.cs
//
// summary:	Implements the decoded credential class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GalaxySMS.Common.Enums;
using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Client.Entities
{
    [DataContract]

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A credential part. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A credential part. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A credential part. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A credential part. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class CredentialPart : DtoObjectBase
    {
        /// <summary>   The name. </summary>
        private string _Name;
        /// <summary>   The value. </summary>
        private uint _Value;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name. </summary>
        ///
        /// <value> The name. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string Name
        {
            get { return _Name; }
            set
            {
                if (_Name != value)
                {
                    _Name = value;
                    OnPropertyChanged(() => Name, true);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the value. </summary>
        ///
        /// <value> The value. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public uint Value
        {
            get { return _Value; }
            set
            {
                if (_Value != value)
                {
                    _Value = value;
                    OnPropertyChanged(() => Value, true);
                }
            }
        }

    }

    [DataContract]

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A decoded credential. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A decoded credential. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A decoded credential. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A decoded credential. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class DecodedCredential : DtoObjectBase
    {

        /// <summary>   The credential format code. </summary>
        private CredentialFormatCodes _CredentialFormatCode;
        /// <summary>   The data format string. </summary>
        private string _DataFormatString;
        /// <summary>   Number of bits. </summary>
        private short _BitCount;
        /// <summary>   The credential number. </summary>
        private string _CredentialNumber;
        /// <summary>   The credential parts. </summary>
        private List<CredentialPart> _credentialParts;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 10/1/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DecodedCredential()
        {
            CredentialParts = new List<CredentialPart>();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the data format. </summary>
        ///
        /// <value> The data format. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public CredentialFormatCodes CredentialFormatCode
        {
            get { return _CredentialFormatCode; }
            set
            {
                if (_CredentialFormatCode != value)
                {
                    _CredentialFormatCode = value;
                    OnPropertyChanged(() => CredentialFormatCode, true);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the data format string. </summary>
        ///
        /// <value> The data format string. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public string DataFormatString
        {
            get { return _DataFormatString; }
            set
            {
                if (_DataFormatString != value)
                {
                    _DataFormatString = value;
                    OnPropertyChanged(() => DataFormatString, true);
                }
            }
        }

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
        /// <summary>   Gets or sets the credential parts. </summary>
        ///
        /// <value> The credential parts. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public List<CredentialPart> CredentialParts
        {
            get { return _credentialParts; }
            set
            {
                if (_credentialParts != value)
                {
                    _credentialParts = value;
                    OnPropertyChanged(() => CredentialParts, true);
                }
            }
        }

    }

}

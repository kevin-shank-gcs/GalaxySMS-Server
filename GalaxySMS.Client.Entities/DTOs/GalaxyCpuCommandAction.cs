////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\GalaxyCpuCommandAction.cs
//
// summary:	Implements the galaxy CPU command action class
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
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A galaxy CPU command action. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class GalaxyCpuCommandAction : GalaxyCpuCommandBase
    {

        /// <summary>   The command action. </summary>
        private GalaxyCpuCommandActionCode _commandAction;
        /// <summary>   The credential in bytes. </summary>
        private byte[] _CredentialBytes;
        /// <summary>   The credential bytes string. </summary>
        private string _CredentialBytesString;
        /// <summary>   The input output group number. </summary>
        private ushort _InputOutputGroupNumber;
        /// <summary>   The string encoding format. </summary>
        private StringEncodingFormat _StringEncodingFormat;
        /// <summary>   The credential UID. </summary>
        private Guid _CredentialUid;
        /// <summary>   The command UID. </summary>
        private Guid _CommandUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 10/5/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyCpuCommandAction()
        {
            Init();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 10/5/2018. </remarks>
        ///
        /// <param name="o">    The GalaxyCpuCommandAction to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyCpuCommandAction(GalaxyCpuCommandAction o) 
        {
            Init();

            if (o == null)
                return;

            this.CommandAction = o.CommandAction;

            this.CredentialBytes = o.CredentialBytes;
            this.CredentialBytesString = o.CredentialBytesString;
            this.StringEncodingFormat = o.StringEncodingFormat;
            this.InputOutputGroupNumber = o.InputOutputGroupNumber;
            this.CredentialUid = o.CredentialUid;
            this.CommandUid = o.CommandUid;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this GalaxyCpuCommandAction. </summary>
        ///
        /// <remarks>   Kevin, 10/5/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Init()
        {
            this.CredentialBytesString = string.Empty;
            this.CredentialUid = Guid.Empty;
            this.CommandUid = Guid.Empty;

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the command action. </summary>
        ///
        /// <value> The command action. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public GalaxyCpuCommandActionCode CommandAction
        {
            get { return _commandAction; }
            set
            {
                if (_commandAction != value)
                {
                    _commandAction = value;
                    OnPropertyChanged(() => CommandAction, true);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets the credential bytes for ForgivePassback, Enable and Disable Credential commands.
        /// </summary>
        ///
        /// <value> The credential bytes. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]

        public byte[] CredentialBytes
        {
            get { return _CredentialBytes; }
            set
            {
                if (_CredentialBytes != value)
                {
                    _CredentialBytes = value;
                    OnPropertyChanged(() => CredentialBytes, true);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the string encoding format. </summary>
        ///
        /// <value> The string encoding format. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public StringEncodingFormat StringEncodingFormat
        {
            get { return _StringEncodingFormat; }
            set
            {
                if (_StringEncodingFormat != value)
                {
                    _StringEncodingFormat = value;
                    OnPropertyChanged(() => StringEncodingFormat, true);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets the credential bytes HEX encoded string for ForgivePassback, Enable and Disable
        /// Credential commands.
        /// </summary>
        ///
        /// <value> The credential bytes string. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string CredentialBytesString
        {
            get { return _CredentialBytesString; }
            set
            {
                if (_CredentialBytesString != value)
                {
                    _CredentialBytesString = value;
                    OnPropertyChanged(() => CredentialBytesString, true);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the input output group number. </summary>
        ///
        /// <value> The input output group number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public ushort InputOutputGroupNumber
        {
            get { return _InputOutputGroupNumber; }
            set
            {
                if (_InputOutputGroupNumber != value)
                {
                    _InputOutputGroupNumber = value;
                    OnPropertyChanged(() => InputOutputGroupNumber, true);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the credential UID. </summary>
        ///
        /// <value> The credential UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid CredentialUid
        {
            get { return _CredentialUid; }
            set
            {
                if (_CredentialUid != value)
                {
                    _CredentialUid = value;
                    OnPropertyChanged(() => CredentialUid, true);
                }
            }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the command UID. </summary>
        ///
        /// <value> The command UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid CommandUid
        {
            get { return _CommandUid; }
            set
            {
                if (_CommandUid != value)
                {
                    _CommandUid = value;
                    OnPropertyChanged(() => CommandUid, true);
                }
            }
        }

    }
}

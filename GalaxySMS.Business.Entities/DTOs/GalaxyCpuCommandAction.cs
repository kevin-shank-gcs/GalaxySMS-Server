﻿using GalaxySMS.Common.Enums;
using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace GalaxySMS.Business.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A galaxy CPU command action. </summary>
    ///
    /// <remarks>   Kevin, 10/5/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public partial class GalaxyCpuCommandAction : GalaxyCpuCommandBase
    {
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
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initialises this GalaxyCpuCommandAction. </summary>
        ///
        /// <remarks>   Kevin, 10/5/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Init()
        {
            this.CredentialUid = Guid.Empty;
            this.CredentialBytesString = string.Empty;
            InputOutputGroupNumber = 0;
            this.CommandUid = Guid.Empty;

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the command action. </summary>
        ///
        /// <value> The command action. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public GalaxyCpuCommandActionCode CommandAction { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets the credential bytes for ForgivePassback, Enable and Disable Credential commands.
        /// </summary>
        ///
        /// <value> The credential bytes. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public byte[] CredentialBytes { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the string encoding format. </summary>
        ///
        /// <value> The string encoding format. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public StringEncodingFormat StringEncodingFormat { get; set; }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets the credential bytes HEX encoded string for ForgivePassback, Enable and Disable
        /// Credential commands.
        /// </summary>
        ///
        /// <value> The credential bytes string. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string CredentialBytesString { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the input output group number. </summary>
        ///
        /// <value> The input output group number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public ushort InputOutputGroupNumber { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the credential UID. </summary>
        ///
        /// <value> The credential UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid CredentialUid { get; set; }

    }
}

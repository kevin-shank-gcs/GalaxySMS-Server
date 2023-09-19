////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\GalaxyCpuCommandAction.cs
//
// summary:	Implements the galaxy CPU command action class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GalaxySMS.Common.Enums;
using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;

namespace GalaxySMS.Api.Models.RequestModels
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A galaxy CPU command action. </summary>
    ///
    /// <remarks>   Kevin, 10/5/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    public partial class ClusterCommandActionReq : GalaxyCpuCommandBaseReq
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 10/5/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ClusterCommandActionReq() : base()
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

        public ClusterCommandActionReq(ClusterCommandActionReq o) : base(o)
        {
            Init();

            if (o == null)
                return;

            this.CommandAction = o.CommandAction;
            this.CredentialUid = o.CredentialUid;

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
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the command action. </summary>
        /// <remarks>   0 = ResetCpuWarm, 1 = ResetCpuCold, 2 = EnableDaughterBoardFlashUpdate, 3 = ClearAllCredentials, 4 = Ping, 5 = RequestControllerInformation, 6 = RequestCredentialCount, 7 = RequestLoggingInformation, 8 = ForgivePassbackForCredential, 9 = ForgivePassbackForAllCredentials, 10 = RecalibrateInputsAndOutputs, 11 = ActivateCrisisMode, 12 = ResetCrisisMode, 13 = EnableCredential, 14 = DisableCredential, 15 = RequestInputOutputGroupCounters, 16 = RequestBoardInformation, 17 = ClearLoggingBuffer, 18 = RetransmitLoggingBuffer, 19 = StartLogging, 20 = StopLogging, 21 = BeginFlashLoad, 22 = ValidateFlash, 23 = ValidateAndBurnFlash
        /// </remarks>
        /// <value> The command action. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        [Required]
        [EnumDataType(typeof(GalaxySMS.Common.Enums.GalaxyCpuCommandActionCode))]
        public GalaxyCpuCommandActionCode CommandAction { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets the credential bytes for ForgivePassback, Enable and Disable Credential commands.
        /// </summary>
        ///
        /// <value> The credential bytes. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public byte[] CredentialBytes { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the string encoding format. </summary>
        ///
        /// <value> The string encoding format. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public StringEncodingFormat StringEncodingFormat { get; set; }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets the credential bytes HEX encoded string for ForgivePassback, Enable and Disable
        /// Credential commands.
        /// </summary>
        ///
        /// <value> The credential bytes string. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public string CredentialBytesString { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the input output group number. </summary>
        ///
        /// <value> The input output group number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public ushort InputOutputGroupNumber { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the credential UID. </summary>
        ///
        /// <value> The credential UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        public Guid CredentialUid { get; set; }
    }
}

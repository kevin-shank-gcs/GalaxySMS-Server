////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\GalaxyCpuCommandAction.cs
//
// summary:	Implements the galaxy CPU command action class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GalaxySMS.Common.Enums;
using System;
using System.Runtime.Serialization;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A galaxy CPU command action. </summary>
    ///
    /// <remarks>   Kevin, 10/5/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

#if NetCoreApi
#else
    [DataContract]
#endif
    public partial class ClusterCommandAction : GalaxyCpuCommandBase, IGalaxyCpuCommandAction
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 10/5/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ClusterCommandAction()
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

        public ClusterCommandAction(ClusterCommandAction o)
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
        ///
        /// <value> The command action. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
#if NetCoreApi
#else
        [DataMember]
#endif
        public GalaxyCpuCommandActionCode CommandAction { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string CommandActionCode
        {
            get { return CommandAction.ToString(); }
            set { }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets the credential bytes for ForgivePassback, Enable and Disable Credential commands.
        /// </summary>
        ///
        /// <value> The credential bytes. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
#if NetCoreApi
#else
        [DataMember]
#endif
        public byte[] CredentialBytes { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the string encoding format. </summary>
        ///
        /// <value> The string encoding format. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
#if NetCoreApi
#else
        [DataMember]
#endif
        public StringEncodingFormat StringEncodingFormat { get; set; }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets the credential bytes HEX encoded string for ForgivePassback, Enable and Disable
        /// Credential commands.
        /// </summary>
        ///
        /// <value> The credential bytes string. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
#if NetCoreApi
#else
        [DataMember]
#endif
        public string CredentialBytesString { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the input output group number. </summary>
        ///
        /// <value> The input output group number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
#if NetCoreApi
#else
        [DataMember]
#endif
        public ushort InputOutputGroupNumber { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the credential UID. </summary>
        ///
        /// <value> The credential UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid CredentialUid { get; set; }
    }
}

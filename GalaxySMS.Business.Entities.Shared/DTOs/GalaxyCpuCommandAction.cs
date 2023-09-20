using GalaxySMS.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
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
    public interface IGalaxyCpuCommandAction : IGalaxyCpuCommandBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initialises this GalaxyCpuCommandAction. </summary>
        ///
        /// <remarks>   Kevin, 10/5/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        void Init();

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the command action. </summary>
        ///
        /// <value> The command action. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        GalaxyCpuCommandActionCode CommandAction { get; set; }


        string CommandActionCode { get; set; }

        /// <summary>
        /// Gets or sets the credential bytes for ForgivePassback, Enable and Disable Credential commands.
        /// </summary>
        ///
        /// <value> The credential bytes. </value>


        byte[] CredentialBytes { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the string encoding format. </summary>
        ///
        /// <value> The string encoding format. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        StringEncodingFormat StringEncodingFormat { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets the credential bytes HEX encoded string for ForgivePassback, Enable and Disable
        /// Credential commands.
        /// </summary>
        ///
        /// <value> The credential bytes string. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        string CredentialBytesString { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the input output group number. </summary>
        ///
        /// <value> The input output group number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        ushort InputOutputGroupNumber { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the credential UID. </summary>
        ///
        /// <value> The credential UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        Guid CredentialUid { get; set; }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A galaxy CPU command action. </summary>
    ///
    /// <remarks>   Kevin, 10/5/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

#if NetCoreApi
#else
    [DataContract]
#endif

    public partial class GalaxyCpuCommandAction : GalaxyCpuCommandBase, IGalaxyCpuCommandAction
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
            if (o.CredentialUids != null)
                this.CredentialUids = o.CredentialUids.ToList();
            if (o.CredentialBytesList != null)
                CredentialBytesList = o.CredentialBytesList.ToList();
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
            this.CredentialUids = new List<Guid>();
            CredentialBytesList = new List<byte[]>();
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


#if NetCoreApi
#else
        [DataMember]
#endif
        public List<Guid> CredentialUids { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public List<byte[]> CredentialBytesList { get; set; }
    }
}

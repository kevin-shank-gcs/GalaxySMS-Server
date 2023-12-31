﻿////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\AccessPortalCommandAction.cs
//
// summary:	Implements the access portal command action class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GalaxySMS.Common.Enums;
using GCS.Core.Common.Contracts;
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
    /// <summary>   The input device command action. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public partial class InputDeviceCommandAction : ObjectBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public InputDeviceCommandAction()
        {
            Init();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="o">    The AccessPortalCommandAction to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public InputDeviceCommandAction(InputDeviceCommandAction o)
        {
            Init();
            InputDeviceUid = o.InputDeviceUid;
            CommandAction = o.CommandAction;
            CommandUid = o.CommandUid;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initialises this AccessPortalCommandAction. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Init()
        {
            CommandAction = InputDeviceCommandActionCode.None;
            InputDeviceUid = Guid.Empty;
            CommandUid = Guid.Empty;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the command action. </summary>
        ///
        /// <value> The command action. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public InputDeviceCommandActionCode CommandAction { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the access portal UID. </summary>
        ///
        /// <value> The access portal UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid InputDeviceUid { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the command UID. </summary>
        ///
        /// <value> The command UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid CommandUid {get;set;}
    }

}

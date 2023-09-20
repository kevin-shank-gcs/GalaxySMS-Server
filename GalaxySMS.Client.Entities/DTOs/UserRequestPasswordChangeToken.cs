////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\UserSignInRequest.cs
//
// summary:	Implements the user sign in request class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;
using GCS.Framework.Security;
using FluentValidation;
using GCS.Framework.Utilities;
using GCS.Core.Common.Swagger;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A user sign in request base. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class UserRequestPasswordChangeToken : ObjectBaseSimple
    {
        ///// <summary>   Amount to sign in by. </summary>
        //private SignInUsing _signInBy;
        private string _userName;

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        ///// <summary>   Values that represent sign in usings. </summary>
        /////
        ///// <remarks>   Kevin, 12/26/2018. </remarks>
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        //public enum SignInUsing
        //{
        //    /// <summary>   An enum constant representing the user name option. </summary>
        //    UserName,
        //    /// <summary>   An enum constant representing the email option. </summary>
        //    Email,
        //    /// <summary>   An enum constant representing the automatic detect option. </summary>
        //    AutoDetect
        //}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public UserRequestPasswordChangeToken()
        {

        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the user. </summary>
        ///
        /// <value> The name of the user. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string UserName
        {
            get { return _userName; }
            set
            {
                if (_userName != value)
                {
                    _userName = value;
                    OnPropertyChanged(() => UserName);
                }
            }
        }

        private bool _sendViaEmail;

        [DataMember]
        public bool SendViaEmail    
        {
            get { return _sendViaEmail; }
            set
            {
                if (_sendViaEmail != value)
                {
                    _sendViaEmail = value;
                    OnPropertyChanged(() => SendViaEmail);
                }
            }
        }

        private bool _sendViaSms;

        [DataMember]
        public bool SendViaSms
        {
            get { return _sendViaSms; }
            set
            {
                if (_sendViaSms != value)
                {
                    _sendViaSms = value;
                    OnPropertyChanged(() => SendViaSms);
                }
            }
        }

    }

}

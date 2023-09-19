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

    [DataContract]
    public class UserRequestPasswordChangeTokenResponse : ObjectBaseSimple
    {
        /// <summary>   The email. </summary>
        private string _token;


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public UserRequestPasswordChangeTokenResponse()
        {

        }


        [DataMember]
        public string Token
        {
            get { return _token; }
            set
            {
                if (_token != value)
                {
                    _token = value;
                    OnPropertyChanged(() => Token);
                }
            }
        }

        private bool _unknownUser;

        [DataMember]
        public bool UnknownUser
        {
            get { return _unknownUser; }
            set
            {
                if (_unknownUser != value)
                {
                    _unknownUser = value;
                    OnPropertyChanged(() => UnknownUser);
                }
            }
        }

    }
}

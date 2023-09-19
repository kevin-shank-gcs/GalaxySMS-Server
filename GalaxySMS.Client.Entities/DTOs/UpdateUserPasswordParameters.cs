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
    public class UpdateUserPasswordParameters : ObjectBaseSimple
    {
        private string _newPassword;
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public UpdateUserPasswordParameters()
        {

        }

        private Guid _userId;

        [DataMember]
        public Guid UserId
        {
            get { return _userId; }
            set
            {
                if (_userId != value)
                {
                    _userId = value;
                    OnPropertyChanged(() => UserId);
                }
            }
        }


        [DataMember]
        public string NewPassword
        {
            get { return _newPassword; }
            set
            {
                if (_newPassword != value)
                {
                    _newPassword = value;
                    OnPropertyChanged(() => NewPassword);
                }
            }
        }

        private string _token;

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


    }
}

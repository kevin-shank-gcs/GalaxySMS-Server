////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\UserSignInResult.cs
//
// summary:	Implements the user sign in result class
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

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Encapsulates the result of a user sign in operation. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class UserSignInResult : DtoObjectBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public UserSignInResult()
        {
            RequestResult = UserSignInRequestResult.Unknown;
            SuccessInformation = new HashSet<SuccessInfo>();
            SuccessInformationMessages = new HashSet<string>();
        }

        /// <summary>   Information describing the request. </summary>
        private UserSignInRequest _requestData;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Contains the original request parameters. </summary>
        ///
        /// <value> Information describing the request. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public UserSignInRequest RequestData
        {
            get { return _requestData; }
            private set
            {
                if (_requestData != value)
                {
                    _requestData = value;
                    OnPropertyChanged(() => RequestData, false);
                }
            }
        }

        /// <summary>   The request result. </summary>
        private UserSignInRequestResult _requestResult;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the request result. </summary>
        /// <remarks>   This is an enum that describes the result. Success and SuccessWithInfo indicate that the operation succeeded. Any other value indicates that the user was not able to sign in successfully. For SuccessWithInfo, examine the SuccessInformation and SuccessInformationMessages collections for additional information that is informative to the user.
        /// </remarks>
        /// <value> The request result. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public UserSignInRequestResult RequestResult
        {
            get { return _requestResult; }
            private set
            {
                if (_requestResult != value)
                {
                    _requestResult = value;
                    OnPropertyChanged(() => RequestResult, false);
                }
            }
        }

        /// <summary>   Information describing the success. </summary>
        private IEnumerable<SuccessInfo> _successInformation;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets information describing the success. </summary>
        /// <remarks>   This collection contains enum values that represent information that is useful to to the user. Examples are: UserAccountSoonToExpire or PasswordMustBeChanged. </remarks>
        /// <value> Information describing the success. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IEnumerable<SuccessInfo> SuccessInformation 
        {
            get { return _successInformation; }
            private set
            {
                if (_successInformation != value)
                {
                    _successInformation = value;
                    OnPropertyChanged(() => SuccessInformation, false);
                }
            }
        }

        /// <summary>   The success information messages. </summary>
        private IEnumerable<string> _successInformationMessages;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the success information messages. </summary>
        /// <remarks>   This collection contains string values that represent information that is useful to to the user. They are user friendly messages that coorespond to the SuccessInfomation enum values. </remarks>
        /// <value> The success information messages. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public IEnumerable<string> SuccessInformationMessages
        {
            get { return _successInformationMessages; }
            private set
            {
                if (_successInformationMessages != value)
                {
                    _successInformationMessages = value;
                    OnPropertyChanged(() => SuccessInformationMessages, false);
                }
            }
        }
        /// <summary>   The account soon to expire in days. </summary>
        private int _accountSoonToExpireDays;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the account soon to expire days. </summary>
        /// <remarks>   Contains the number of days left until the user account will expire.</remarks>
        /// <value> The account soon to expire days. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public int AccountSoonToExpireDays
        {
            get { return _accountSoonToExpireDays; }
            private set
            {
                if (_accountSoonToExpireDays != value)
                {
                    _accountSoonToExpireDays = value;
                    OnPropertyChanged(() => AccountSoonToExpireDays, false);
                }
            }
        }
        /// <summary>   The password change in days. </summary>
        private int _passwordChangeDays;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the password change days. </summary>
        /// <remarks>   Contains the number of days left until the password must be changed.</remarks>
        /// <value> The password change days. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public int PasswordChangeDays
        {
            get { return _passwordChangeDays; }
            private set
            {
                if (_passwordChangeDays != value)
                {
                    _passwordChangeDays = value;
                    OnPropertyChanged(() => PasswordChangeDays, false);
                }
            }
        }

        /// <summary>   The user session token. </summary>
        private UserSessionToken _userSessionToken;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the session token. </summary>
        /// <remarks>   This is a complex object that contains important properties about the user session. </remarks>
        /// <value> The session token. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public UserSessionToken SessionToken
        {
            get { return _userSessionToken; }
            set
            {
                if (_userSessionToken != value)
                {
                    _userSessionToken = value;
                    OnPropertyChanged(() => SessionToken, false);
                }
            }
        }


    }
}

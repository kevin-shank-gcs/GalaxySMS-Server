////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\UserSignInResult.cs
//
// summary:	Implements the user sign in result class
///=================================================================================================

using GCS.Core.Common.Extensions;
using GCS.Framework.Security;
using System.Collections.Generic;
using System.Runtime.Serialization;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
#if NetCoreApi
#else
    [DataContract]
#endif
    public class UserSignInResult //: EntityBase
    {
        public UserSignInResult()
        {
            Init();
        }

        private void Init()
        {
            RequestResult = UserSignInRequestResult.Unknown;
            SuccessInformation = new HashSet<SuccessInfo>();
            SuccessInformationMessages = new HashSet<string>();
        }

        public UserSignInResult(UserSignInResult o)
        {
            Init();
            if (o != null)
            {
                RequestData = new UserSignInRequest(o.RequestData);
                RequestResult = o.RequestResult;
                if (o.SuccessInformation != null)
                    SuccessInformation = o.SuccessInformation.ToCollection();
                if (o.SuccessInformationMessages != null)
                    SuccessInformationMessages = o.SuccessInformationMessages.ToCollection();
                this.AccountSoonToExpireDays = o.AccountSoonToExpireDays;
                this.PasswordChangeDays = o.PasswordChangeDays;
                this.SessionToken = new UserSessionToken(o.SessionToken);
            }
        }
#if NetCoreApi
#else
        [DataMember]
#endif
        public UserSignInRequest RequestData { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Contains the result enum. </summary>
        ///
        /// <value> The request result. </value>
        ///=================================================================================================

#if NetCoreApi
#else
        [DataMember]
#endif
        public UserSignInRequestResult RequestResult { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Contains useful information about a successful request. </summary>
        ///
        /// <value> Information describing the success. </value>
        ///=================================================================================================

#if NetCoreApi
#else
        [DataMember]
#endif


        public ICollection<SuccessInfo> SuccessInformation { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Contains useful information about a successful request. </summary>
        ///
        /// <value> Information describing the success. </value>
        ///=================================================================================================
#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<string> SuccessInformationMessages { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Indicates that the account will soon expire in this many days. </summary>
        ///
        /// <value> The account soon to expire days. </value>
        ///=================================================================================================
#if NetCoreApi
#else
        [DataMember]
#endif
        public int AccountSoonToExpireDays { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Indicates that the users password must be changed within this many days. </summary>
        ///
        /// <value> The password change days. </value>
        ///=================================================================================================

#if NetCoreApi
#else
        [DataMember]
#endif

        public int PasswordChangeDays { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Contains the SessionToken data. </summary>
        ///
        /// <value> The session token. </value>
        ///=================================================================================================

#if NetCoreApi
#else
        [DataMember]
#endif
        public UserSessionToken SessionToken { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Framework.Security
{

    /// <summary>   Values that represent user sign in request results. </summary>
	public enum UserSignInRequestResult
	{
        Unknown,/// <summary>
        /// 
        /// </summary>
        MustProvideTwoFactorToken,/// <summary>
        /// A valid two factor authentication token must be provided as the next step in the authentication process
        /// </summary>
		Success,/// <summary>
        /// The user has been signed in successfully
        /// </summary>
        SuccessWithInfo,/// <summary>
        /// The user has been signed in successfully, however there is additional information that may be useful
        /// </summary>
		InvalidUserName,/// <summary>
        /// The provided UserName is not valid
        /// </summary>
        InvalidPassword,/// <summary>
        /// The provided Password is not valid
        /// </summary>
		UserAccountIsNotActive,/// <summary>
        /// The requested user is not active
        /// </summary>
		UserAccountIsLockedOut,/// <summary>
        /// The user account is locked out, typically due to too many unsuccessful attempts or an extended period of in-activity
        /// </summary>
		ApplicationNotPermitted,/// <summary>
        ///  The user is not permitted to access the application
        /// </summary>
        EmailAndPhoneNumberNotConfirmed,/// <summary>
        /// The users' email and/or phone number have not been confirmed. This is applicable to two-factor configurations
        /// </summary>
		InvalidTwoFactorToken,/// <summary>
        /// The two-factor token is not valid. It could have been incorrectly entered or the time-window for the token has expired
        /// </summary>
	}

    public enum SuccessInfo
    {
        None,
        UserAccountSoonToExpire,
        PasswordMustBeChanged
    }
}

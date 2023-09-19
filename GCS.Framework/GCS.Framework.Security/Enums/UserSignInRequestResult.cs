using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Framework.Security
{
	public enum UserSignInRequestResult
	{
        Unknown,
		Success,
        SuccessWithInfo,
		InvalidUserName,
        InvalidPassword,
		UserAccountIsNotActive,
		UserAccountIsLockedOut,
		ApplicationNotPermitted
	}

    public enum SuccessInfo
    {
        None,
        UserAccountSoonToExpire,
        PasswordMustBeChanged
    }
}

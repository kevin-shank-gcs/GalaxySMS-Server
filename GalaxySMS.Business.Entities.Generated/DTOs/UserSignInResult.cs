using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Framework.Security;

namespace GalaxySMS.Business.Entities
{
    public class UserSignInResult : EntityBase
    {
        public UserSignInResult()
        {
            RequestResult = UserSignInRequestResult.Unknown;
            SuccessInformation = new HashSet<SuccessInfo>();
            SuccessInformationMessages = new HashSet<string>();
        }

        public UserSignInRequest RequestData { get; set; }

        public UserSignInRequestResult RequestResult { get; set; }

        public ICollection<SuccessInfo> SuccessInformation { get; set; }

        public ICollection<string> SuccessInformationMessages { get; set; }

        public int AccountSoonToExpireDays { get; set; }

        public int PasswordChangeDays { get; set; }
        
        public UserSessionToken SessionToken { get; set; }
    }
}

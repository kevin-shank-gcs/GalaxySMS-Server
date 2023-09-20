using GalaxySMS.Common.Enums;
using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

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
    public partial class UpdateUserPasswordResult
    {
        private UpdateUserPasswordResultCodes _result;
        public enum UpdateUserPasswordResultCodes
        {
            UserNotFound,
            CurrentPasswordIncorrect,
            TokenInvalid,
            TokenHasExpired,
            NewPasswordInvalid,
            Success
        }

        public UpdateUserPasswordResult()
        {
        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public UpdateUserPasswordResultCodes Result {
            get
            {
                return _result;
            }
            set
            {
                _result = value;
                ResultText= Result.ToString();
            }
        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ResultText { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public PasswordValidationInfo ValidationInfo { get; set; }
    }
}

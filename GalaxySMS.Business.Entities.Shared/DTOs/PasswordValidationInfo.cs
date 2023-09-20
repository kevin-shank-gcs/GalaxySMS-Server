using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using GCS.Core.Common;
using GCS.Framework.Security;

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
    public partial class PasswordValidationInfo //: ObjectBase
    {
        public PasswordValidationInfo()
        {
            Results = new HashSet<PasswordValidationItem>();
        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<PasswordValidationItem> Results { get; set; }

        public PasswordValidationResult Result
        {
            get
            {
                if (Results == null || Results.Count == 0)
                    return PasswordValidationResult.Valid;
                return Results.First().Result;
            }
        }
        public string ResultMessage
        {
            get
            {
                if (Results == null || Results.Count == 0)
                    return string.Empty;
                return Results.First().Message;
            }
        }

    }

}

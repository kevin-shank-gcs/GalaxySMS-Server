using GCS.Core.Common.Core;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using GCS.Framework.Security;

namespace GalaxySMS.Client.Entities

{
    [DataContract]
    public partial class PasswordValidationInfo : ObjectBase
    {
        public PasswordValidationInfo()
        {
            Results = new HashSet<PasswordValidationItem>();
        }

        [DataMember]
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

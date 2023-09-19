using GCS.Core.Common.Core;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GCS.Framework.Security;

namespace GalaxySMS.Client.Entities
{
    [DataContract]
    public partial class PasswordValidationItem
    {

        [DataMember]
        public PasswordValidationResult Result { get; set; }

        [DataMember]
        public string Message { get; set; }
    }

}

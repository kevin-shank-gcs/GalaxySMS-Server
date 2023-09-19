using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Client.Entities
{
    [DataContract]
    public class TwoFactorAuthenticationData
    {
        [DataMember]
        public Guid SessionId {get;set;}

        [DataMember]
        public string TwoFactorToken { get; set; }
    }
}

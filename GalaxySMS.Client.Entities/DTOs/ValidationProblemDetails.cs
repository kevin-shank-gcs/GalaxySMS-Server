using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace GalaxySMS.Client.Entities
{
    [DataContract]
    public class ValidationProblemDetails
    {
        [DataMember]
        public IDictionary<string, string[]> Errors { get; set; }
    }
}

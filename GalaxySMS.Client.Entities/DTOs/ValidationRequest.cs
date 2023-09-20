using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using GalaxySMS.Common.Enums;

namespace GalaxySMS.Client.Entities
{
    [DataContract]
    public class ValidationRequestBase
    {
        [DataMember]
        public ValidationRequestType ValidationRequestType { get; set; }

        [DataMember]
        public string PropertyName { get; set; }
        //[DataMember]
        //public ValidationValueSource V1Source { get; set; }


        //[DataMember]
        //public ValidationValueSource V2Source { get; set; }

    }


    [DataContract]
    public class GuidValidationRequestItem : ValidationRequestBase
    {
        [DataMember]
        public Guid ClusterUid { get; set; }

        [DataMember]
        public Guid TimeScheduleUid { get; set; }
        
        [DataMember]
        public bool PreventSystemEntityMatches { get; set; }
    }

    [DataContract]
    public class GuidValidationRequest 
    {
        public GuidValidationRequest()
        {
            Items = new HashSet<GuidValidationRequestItem>();
        }

        [DataMember]
        public ICollection<GuidValidationRequestItem> Items { get; set; }

    }

}

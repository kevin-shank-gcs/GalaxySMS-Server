using GalaxySMS.Common.Enums;
using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace GalaxySMS.Client.Entities
{

    [DataContract]
    public partial class BackgroundJobInfo //: ObjectBase
    {
        public BackgroundJobInfo()
        {
            StateChanges = new HashSet<BackgroundJobStateChangeInfo>();
        }

        [DataMember]
        public Guid JobId { get; set; }

        [DataMember]
        public BackgroundJobState State { get; set; }

        [DataMember]
        public BackgroundJobOperationType JobType { get; set; }

        [DataMember]
        public string DataType { get; set; }

        [DataMember]
        public Guid DataItemUid { get; set; }

        [DataMember]
        public DateTimeOffset CreatedDateTime { get; set; }

        [DataMember]
        public DateTimeOffset? LastUpdatedDateTime { get; set; }

        [DataMember]
        public Guid UserId { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember] 
        public Guid EntityId { get; set; }

        [DataMember]
        public ICollection<BackgroundJobStateChangeInfo> StateChanges { get; set; }
    }
    
    [DataContract]
    public partial class BackgroundJobInfo<T> : BackgroundJobInfo //: ObjectBase
    {
        public BackgroundJobInfo()
        {

        }

        public BackgroundJobInfo(T data)
        {
            Data = data;
        }

        [DataMember]
        public T Data { get; set; }

    }

}

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
    public partial class BackgroundJobInfo //: ObjectBase
    {

		public BackgroundJobInfo()
        {
            StateChanges = new HashSet<BackgroundJobStateChangeInfo>();
        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid JobId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public BackgroundJobState State { get; set; }

        public string StateCode
        {
            get => State.ToString();
        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public BackgroundJobOperationType JobType { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string DataType { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid DataItemUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid EntityId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ItemName { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public DateTimeOffset CreatedDateTime { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public DateTimeOffset? LastUpdatedDateTime { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid UserId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string UserName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<BackgroundJobStateChangeInfo> StateChanges { get; set; }
    }


#if NetCoreApi
#else
    [DataContract]
#endif
    public partial class BackgroundJobInfo<T>:BackgroundJobInfo //: ObjectBase
    {
        public BackgroundJobInfo()
        {
            
        }

        public BackgroundJobInfo(T data)
        {
            Data = data;
        }
#if NetCoreApi
#else
        [DataMember]
#endif
        public T Data { get; set; }

    }

}

using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;

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
    public partial class gcsLargeObjectStorageBasic
    {
    	public System.Guid Uid { get; set; }
    	public Nullable<System.Guid> EntityId { get; set; }
    	public string UniqueTag { get; set; }
    	public string DataType { get; set; }
    	public string TextData { get; set; }
    	public byte[] FileStreamData { get; set; }
    	public byte[] BlobData { get; set; }
    	//public string InsertName { get; set; }
    	//public System.DateTimeOffset InsertDate { get; set; }
    	//public string UpdateName { get; set; }
    	//public Nullable<System.DateTimeOffset> UpdateDate { get; set; }
    	//public Nullable<short> ConcurrencyValue { get; set; }
    
    	//public gcsEntity gcsEntity { get; set; }
    
    }
}

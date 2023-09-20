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
using System;
using System.Runtime.Serialization;

namespace GalaxySMS.Business.Entities
#endif
{
#if NetCoreApi
#else
    [DataContract]
#endif

    public class OperationStatusInfo
    {
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid OperationUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool Successful { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public bool Timeout { get; set; }
        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public string CommandType { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public string CommandActionCode { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid PanelUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid CpuUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid CredentialUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string CommandActionCode { get; set; }

    }



}

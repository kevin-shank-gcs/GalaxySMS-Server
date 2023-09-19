////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\InitializeSystemDatabaseRequest.cs
//
// summary:	Implements the initialize system database request class
///=================================================================================================

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
//#if NetCoreApi
//#else
//    [DataContract]
//#endif
#if NetCoreApi
#elif WcfClient
    [DataContract]
#else
#endif
    public class InitializeSystemDatabaseRequest : EntityBase
    {
        public InitializeSystemDatabaseRequest()
        {
            Init();
        }


        private void Init()
        {
            InitializeSystemTables = false;
            this.Entities = new HashSet<gcsEntity>();
            this.Languages = new HashSet<gcsLanguage>();
            this.Applications = new HashSet<gcsApplication>();
            this.Users = new HashSet<gcsUser>();
            this.ApplicationAuditTypes = new HashSet<gcsApplicationAuditType>();
            this.SystemData = new gcsSystem();
        }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
#if NetCoreApi
#elif WcfClient
    [DataMember]
#else
#endif
        public ICollection<gcsEntity> Entities { get; set; }
        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
#if NetCoreApi
#elif WcfClient
    [DataMember]
#else
#endif
        public ICollection<gcsLanguage> Languages { get; set; }
        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
#if NetCoreApi
#elif WcfClient
    [DataMember]
#else
#endif
        public ICollection<gcsApplication> Applications { get; set; }
        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
#if NetCoreApi
#elif WcfClient
    [DataMember]
#else
#endif
        public ICollection<gcsUser> Users { get; set; }
        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
#if NetCoreApi
#elif WcfClient
    [DataMember]
#else
#endif
        public ICollection<gcsApplicationAuditType> ApplicationAuditTypes { get; set; } 

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
#if NetCoreApi
#elif WcfClient
    [DataMember]
#else
#endif
        public gcsSystem SystemData { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
#if NetCoreApi
#elif WcfClient
    [DataMember]
#else
#endif
        public bool InitializeSystemTables { get; set; }
    }
}

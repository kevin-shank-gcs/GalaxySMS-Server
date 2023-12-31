//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
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
#if NetCoreApi
#else
    [DataContract]
#endif
    public partial class AccessPortalGalaxyHardwareAddress : EntityBase, IIdentifiableEntity, IEquatable<AccessPortalGalaxyHardwareAddress>, ITableEntityBase
    {

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid AccessPortalGalaxyHardwareAddressUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid AccessPortalUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid GalaxyInterfaceBoardSectionNodeUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string InsertName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.DateTimeOffset InsertDate { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string UpdateName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<System.DateTimeOffset> UpdateDate { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<short> ConcurrencyValue { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif

        //        public AccessPortal AccessPortal { get; set; }

        //#if NetCoreApi
        //#else
        //        [DataMember]
        //#endif
        //        public GalaxyInterfaceBoardSectionNode GalaxyInterfaceBoardSectionNode { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether the node is active. </summary>
        ///
        /// <value> True if a node is active, false if not. </value>
        ///=================================================================================================


#if NetCoreApi
#else
        [DataMember]
#endif

        public bool IsNodeActive { get; set; }

    }
}

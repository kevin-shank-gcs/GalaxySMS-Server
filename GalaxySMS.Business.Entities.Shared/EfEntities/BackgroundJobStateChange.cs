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
    public partial class BackgroundJobStateChange : EntityBase, IIdentifiableEntity, IEquatable<BackgroundJobStateChange>
    {
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public System.Guid BackgroundJobStateChangeUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public System.Guid BackgroundJobUid { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public System.DateTimeOffset ChangeDateTime { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string State { get; set; }
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public string Info { get; set; }
    
    
    #if NetCoreApi
    #else
    	[DataMember]
    #endif
    	public BackgroundJob BackgroundJob { get; set; }
    
    }
}

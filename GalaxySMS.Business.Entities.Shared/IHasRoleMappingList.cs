////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	IHasEntityMappingList.cs
//
// summary:	Declares the IHasEntityMappingList interface
///=================================================================================================

using System;
using System.Collections.Generic;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
    public interface IHasRoleMappingList
    {
        ICollection<Guid> RoleIds { get; set; }
    }
}

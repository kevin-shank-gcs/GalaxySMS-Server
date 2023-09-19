////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	IHasEntityMappingList.cs
//
// summary:	Declares the IHasEntityMappingList interface
///=================================================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
    public interface IHasEntityMappingList
    {
        ICollection<Guid> EntityIds { get; set; }
        ICollection<EntityIdEntityMapPermissionLevel> MappedEntitiesPermissionLevels { get; set; }
    }
}

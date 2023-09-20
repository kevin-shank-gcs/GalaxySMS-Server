using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Business.Entities
{
    public interface IHasEntityMappingList
    {
        ICollection<Guid> EntityIds { get; set; }
        ICollection<EntityIdEntityMapPermissionLevel> MappedEntitiesPermissionLevels { get; set; }
    }
}

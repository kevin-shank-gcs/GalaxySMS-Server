using System;

namespace GalaxySMS.Common.Interfaces
{
    public interface ICurrentEntityInfo
    {
        Guid CurrentEntityId { get; set; }
        string CurrentEntityName { get; set; }
        string CurrentEntityType { get; set; }
    }
}
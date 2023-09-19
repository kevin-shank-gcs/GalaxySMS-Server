using System;
using System.Collections.Generic;
using System.Text;

namespace GalaxySMS.Common.Interfaces
{
    public interface IEntityValidation
    {
        Guid EntityId { get; set; }
        string EntityType { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Data.NetCore.Interfaces
{
    public interface ICurrentUserService : IService
    {
        string UserId { get; }
        Guid EntityId { get; }
    }
}

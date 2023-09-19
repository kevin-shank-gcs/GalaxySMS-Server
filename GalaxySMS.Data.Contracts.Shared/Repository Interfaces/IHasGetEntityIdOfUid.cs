using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Data.Contracts
{
    public interface IHasGetEntityId
    {
        Guid GetEntityId(Guid uid);
        
    }
}

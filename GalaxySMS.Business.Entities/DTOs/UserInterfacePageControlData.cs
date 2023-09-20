using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;

namespace GalaxySMS.Business.Entities
{
    public class UserInterfacePageControlData : EntityBase
    {
        public UserInterfacePageControlData()
        {
            ControlProperties = new HashSet<UserDefinedProperty>();
        }

        public ICollection<UserDefinedProperty> ControlProperties { get;set; }
    }
}

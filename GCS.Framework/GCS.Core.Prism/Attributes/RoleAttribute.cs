using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Core.Prism
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class RolesAttribute : Attribute
    {
        public string[] Roles { get; set; }

        public RolesAttribute(params string[] roles)
        {
            Roles = roles;
        }
    }
}

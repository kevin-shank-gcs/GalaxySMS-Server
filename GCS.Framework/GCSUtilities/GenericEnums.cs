using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GCS.Framework.Utilities
{
    public static class GenericEnums
    {
        public static T GetOne<T>(object o)
        {
            T one = (T)Enum.Parse(typeof(T), o.ToString());
            return one;
        }
    }
}

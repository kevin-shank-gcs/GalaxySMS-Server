using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlTypes;

namespace GCS.Framework.Utilities
{
    public class DateTimeFunctions
    {
        public static bool IsValidSQLDate(DateTime d)
        {
            var sqlMin = new DateTime(1753, 1, 1, 0, 0, 0);
            var sqlMax = new DateTime(9999, 12, 31, 23, 59, 59);
            if (d < sqlMin)
                return false;
            if (d > sqlMax)
                return false;
            return true;
        }
    }
}

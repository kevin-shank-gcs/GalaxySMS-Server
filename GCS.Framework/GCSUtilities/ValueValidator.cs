using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlTypes;

namespace GCS.Framework.Utilities
{
	public class ValueValidator
	{
		public static bool IsValid(DateTimeOffset value, DateTimeOffset minValue, DateTimeOffset maxValue)
		{
			if (value.Ticks < minValue.Ticks || value.Ticks > maxValue.Ticks)
				return false;
			return true;
		}

		public static bool IsSqlDateTimeMinMaxOrNull(SqlDateTime value)
		{
			if (value == SqlDateTime.Null)
				return true;

			if (value == SqlDateTime.MinValue )
				return true;
			if (value == SqlDateTime.MaxValue)
				return true;

			return false;
		}
	}
}

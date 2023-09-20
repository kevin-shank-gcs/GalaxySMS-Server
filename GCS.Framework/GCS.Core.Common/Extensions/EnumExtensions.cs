////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Extensions\EnumExtensions.cs
//
// summary:	Implements the enum extensions class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Core.Common.Extensions
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   An enum extensions. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static class EnumExtensions
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A T extension method that gets enum name. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="InvalidOperationException">    Thrown when the requested operation is
        ///                                                 invalid. </exception>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="value">    The value to act on. </param>
        ///
        /// <returns>   The enum name. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string GetEnumName<T>(this T value) where T : struct
        {
            var type = typeof(T);
            if (!type.IsEnum)
                throw new InvalidOperationException(string.Format("{0} is not an enum", type));
            return type.GetEnumName(value);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets an one. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="o">    The object to process. </param>
        ///
        /// <returns>   The one. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static T GetOne<T>(object o)
        {
            T one = (T)Enum.Parse(typeof(T), o.ToString());
            return one;
        }
    }
}

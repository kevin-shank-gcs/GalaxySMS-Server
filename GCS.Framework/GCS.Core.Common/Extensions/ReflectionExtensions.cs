////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Extensions\ReflectionExtensions.cs
//
// summary:	Implements the reflection extensions class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Core.Common.Reflection
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A reflection extensions. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static class ReflectionExtensions
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets full method name. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="methodBase">   The method base. </param>
        ///
        /// <returns>   The full method name. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string GetFullMethodName(System.Reflection.MethodBase methodBase)
        {
            if (methodBase == null)
                return string.Empty;
            if (methodBase.ReflectedType == null)
                return string.Empty;

            var result = string.Format(
                "{0}.{1}.{2}()",
                methodBase.ReflectedType.Namespace,
                methodBase.ReflectedType.Name,
                methodBase.Name);
            return result;
        }

    }
}

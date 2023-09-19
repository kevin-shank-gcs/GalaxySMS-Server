////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Extensions\LinqExtensions.cs
//
// summary:	Implements the linq extensions class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Core.Common.Extensions
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A linq extensions. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static class LinqExtensions
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Enumerates except in this collection. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <typeparam name="TSource">  Type of the source. </typeparam>
        /// <param name="first">    The first to act on. </param>
        /// <param name="second">   The second. </param>
        /// <param name="comparer"> The comparer. </param>
        ///
        /// <returns>
        /// An enumerator that allows foreach to be used to process except in this collection.
        /// </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static IEnumerable<TSource> Except<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second,
            Func<TSource, TSource, bool> comparer)
        {
            return first.Where(x => second.Count(y => comparer(x, y)) == 0); 
            
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Enumerates intersect in this collection. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <typeparam name="TSource">  Type of the source. </typeparam>
        /// <param name="first">    The first to act on. </param>
        /// <param name="second">   The second. </param>
        /// <param name="comparer"> The comparer. </param>
        ///
        /// <returns>
        /// An enumerator that allows foreach to be used to process intersect in this collection.
        /// </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static IEnumerable<TSource> Intersect<TSource>(this IEnumerable<TSource> first,
            IEnumerable<TSource> second, Func<TSource, TSource, bool> comparer)
        {
            return first.Where(x => second.Count(y => comparer(x, y)) == 1); 
            
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Enumerates descendants in this collection. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="source">       The source to act on. </param>
        /// <param name="DescendBy">    Amount to descend by. </param>
        ///
        /// <returns>
        /// An enumerator that allows foreach to be used to process descendants in this collection.
        /// </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        static public IEnumerable<T> Descendants<T>(this IEnumerable<T> source,
                                            Func<T, IEnumerable<T>> DescendBy)
        {
            foreach (T value in source)
            {
                yield return value;

                foreach (T child in DescendBy(value).Descendants<T>(DescendBy))
                {
                    yield return child;
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the pages in this collection. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <typeparam name="TSource">  Type of the source. </typeparam>
        /// <param name="source">   The source to act on. </param>
        /// <param name="page">     The page. </param>
        /// <param name="pageSize"> Size of the page. </param>
        ///
        /// <returns>
        /// An enumerator that allows foreach to be used to process the pages in this collection.
        /// </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static IEnumerable<TSource> GetPage<TSource>(this IEnumerable<TSource> source, int page, int pageSize)
        {
            if (page == 0 || pageSize == 0)
                return source;
            return source?.Skip((page - 1) * pageSize).Take(pageSize);
        }
    }

}

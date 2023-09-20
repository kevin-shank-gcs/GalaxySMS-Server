////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Extensions\CoreExtensions.cs
//
// summary:	Implements the core extensions class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GCS.Core.Common.Core;
using GCS.Core.Common.Utils;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
//#if NetCoreApi
//using GCS.Core.Common.Core.Api;
//#endif
namespace GCS.Core.Common.Extensions
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A core extensions. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static class CoreExtensions
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   An ObservableCollection&lt;T&gt; extension method that merges. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="source">       The source to act on. </param>
        /// <param name="collection">   The collection to act on. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void Merge<T>(this ObservableCollection<T> source, IEnumerable<T> collection)
        {
            Merge<T>(source, collection, false);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   An ObservableCollection&lt;T&gt; extension method that merges. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="source">           The source to act on. </param>
        /// <param name="collection">       The collection to act on. </param>
        /// <param name="ignoreDuplicates"> True to ignore duplicates. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void Merge<T>(this ObservableCollection<T> source, IEnumerable<T> collection, bool ignoreDuplicates)
        {
            if (collection != null)
            {
                foreach (T item in collection)
                {
                    bool addItem = true;

                    if (ignoreDuplicates)
                        addItem = !source.Contains(item);

                    if (addItem)
                        source.Add(item);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   An ObjectBase extension method that query if 'obj' is navigable. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="property"> The property. </param>
        ///
        /// <returns>   True if navigable, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static bool IsNavigable(this PropertyInfo property)
        {
            bool navigable = true;

            object[] attributes = property.GetCustomAttributes(typeof(NotNavigableAttribute), true);
            if (attributes.Length > 0)
                navigable = false;

            return navigable;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   An ObjectBase extension method that query if 'obj' is navigable. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="obj">          The obj to act on. </param>
        /// <param name="propertyName"> Name of the property. </param>
        ///
        /// <returns>   True if navigable, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static bool IsNavigable(this ObjectBase obj, string propertyName)
        {
            PropertyInfo propertyInfo = obj.GetType().GetProperty(propertyName);
            return propertyInfo.IsNavigable();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   An ObjectBase extension method that query if 'obj' is navigable. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="obj">                  The obj to act on. </param>
        /// <param name="propertyExpression">   The property expression. </param>
        ///
        /// <returns>   True if navigable, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static bool IsNavigable<T>(this ObjectBase obj, Expression<Func<T>> propertyExpression)
        {
            string propertyName = PropertySupport.ExtractPropertyName(propertyExpression);
            PropertyInfo propertyInfo = obj.GetType().GetProperty(propertyName);
            return propertyInfo.IsNavigable();
        }

        /// <summary>   The browsable properties. </summary>
        static Dictionary<string, bool> BrowsableProperties = new Dictionary<string, bool>();
        /// <summary>   The browsable property infos. </summary>
        static Dictionary<string, PropertyInfo[]> BrowsablePropertyInfos = new Dictionary<string, PropertyInfo[]>();

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   An object extension method that query if 'obj' is browsable. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="obj">      The obj to act on. </param>
        /// <param name="property"> The property. </param>
        ///
        /// <returns>   True if browsable, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static bool IsBrowsable(this object obj, PropertyInfo property)
        {
            string key = string.Format("{0}.{1}", obj.GetType(), property.Name);

            if (!BrowsableProperties.ContainsKey(key))
            {
                bool browsable = property.IsNavigable();
                BrowsableProperties.Add(key, browsable);
            }

            return BrowsableProperties[key];
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   An object extension method that gets browsable properties. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="obj">  The obj to act on. </param>
        ///
        /// <returns>   An array of property information. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static PropertyInfo[] GetBrowsableProperties(this object obj)
        {
            string key = obj.GetType().ToString();

            if (!BrowsablePropertyInfos.ContainsKey(key))
            {
                List<PropertyInfo> propertyInfoList = new List<PropertyInfo>();
                PropertyInfo[] properties = obj.GetType().GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    if ((property.PropertyType.IsSubclassOf(typeof(ObjectBase)) ||
                        property.PropertyType.GetInterface("IList") != null) ||
                        property.PropertyType.GetInterface("IEnumerable") != null &&
                        property.PropertyType != typeof(string))
                    {
                        // only add to list of the property is NOT marked with [NotNavigable]
                        if (IsBrowsable(obj, property))
                            propertyInfoList.Add(property);
                    }
                }

                BrowsablePropertyInfos.Add(key, propertyInfoList.ToArray());
            }

            return BrowsablePropertyInfos[key];
        }


        public static PropertyInfo[] GetComplexProperties(this System.Type t)
        {

            return t.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(p =>
                p.PropertyType != typeof(Guid) &&
                p.PropertyType != typeof(string) &&
                p.PropertyType != typeof(int) &&
                p.PropertyType != typeof(bool) &&
                p.PropertyType != typeof(short) &&
                p.PropertyType != typeof(ExtensionDataObject) &&
                p.PropertyType != typeof(DateTimeOffset) &&
                p.PropertyType != typeof(Guid?) &&
                p.PropertyType != typeof(int?) &&
                p.PropertyType != typeof(bool?) &&
                p.PropertyType != typeof(short?) &&
                p.PropertyType != typeof(DateTimeOffset?)).ToArray();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// A System.Collections.Specialized.StringCollection extension method that converts a collection
        /// to an observable collection.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="enumerableList">   The enumerableList to act on. </param>
        ///
        /// <returns>   Collection as an ObservableCollection&lt;string&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> enumerableList)
        {
            if (enumerableList != null)
            {
                //create an empty observable collection object
                var observableCollection = new ObservableCollection<T>();

                //loop through all the records and add to observable collection object
                foreach (var item in enumerableList)
                    observableCollection.Add(item);

                //return the populated observable collection
                return observableCollection;
            }
            return null;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// A System.Collections.Specialized.StringCollection extension method that converts a collection
        /// to an observable collection.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="collection">   The collection to act on. </param>
        ///
        /// <returns>   Collection as an ObservableCollection&lt;string&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static ObservableCollection<string> ToObservableCollection(this System.Collections.Specialized.StringCollection collection)
        {
            if (collection != null)
            {
                //create an empty observable collection object
                var observableCollection = new ObservableCollection<string>();

                //loop through all the records and add to observable collection object
                foreach (var item in collection)
                    observableCollection.Add(item);

                //return the populated observable collection
                return observableCollection;
            }
            return null;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// An IList&lt;T&gt; extension method that converts an enumerableList to a read only
        /// collection.
        /// </summary>
        ///
        /// <remarks>   Kevin, 2/4/2022. </remarks>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="enumerableList">   The enumerableList to act on. </param>
        ///
        /// <returns>   EnumerableList as a ReadOnlyCollection&lt;T&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static ReadOnlyCollection<T> ToReadOnlyCollection<T>(this IList<T> enumerableList)
        {
            if (enumerableList != null)
            {
                //create an empty observable collection object
                var roCollection = new ReadOnlyCollection<T>(enumerableList);
                //return the populated observable collection
                return roCollection;
            }
            return null;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// An IEnumerable&lt;T&gt; extension method that converts an enumerableList to a collection.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="enumerableList">   The enumerableList to act on. </param>
        ///
        /// <returns>   EnumerableList as an ICollection&lt;T&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static ICollection<T> ToCollection<T>(this IEnumerable<T> enumerableList)
        {
            if (enumerableList != null)
            {
                //create an empty observable collection object
                var collection = new Collection<T>();

                //loop through all the records and add to observable collection object
                foreach (var item in enumerableList)
                    collection.Add(item);

                //return the populated observable collection
                return collection;
            }
            return null;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   An ICollection&lt;T&gt; extension method that adds a range to 'source'. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="collection">   The collection to act on. </param>
        /// <param name="items">        The items. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void AddRange<T>(this ObservableCollection<T> collection, IEnumerable<T> items)
        {
            items.ToList().ForEach(collection.Add);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// An ICollection&lt;T&gt; extension method that adds a range to 'source'.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="destination">  The destination to act on. </param>
        /// <param name="source">       The source to act on. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void AddRange<T>(this ICollection<T> destination, IEnumerable<T> source)
        {
            List<T> list = destination as List<T>;

            if (list != null)
            {
                list.AddRange(source);
            }
            else
            {
                foreach (T item in source)
                {
                    destination.Add(item);
                }
            }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Enumerates append in this collection. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="first">    The first to act on. </param>
        /// <param name="second">   A variable-length parameters list containing second. </param>
        ///
        /// <returns>
        /// An enumerator that allows foreach to be used to process append in this collection.
        /// </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static IEnumerable Append(this IEnumerable first, params object[] second)
        {
            return first.OfType<object>().Concat(second);
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Enumerates append in this collection. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="first">    The first to act on. </param>
        /// <param name="second">   A variable-length parameters list containing second. </param>
        ///
        /// <returns>
        /// An enumerator that allows foreach to be used to process append in this collection.
        /// </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static IEnumerable<T> Append<T>(this IEnumerable<T> first, params T[] second)
        {
            return first.Concat(second);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Enumerates append in this collection. </summary>
        ///
        /// <remarks>   Kevin, 1/22/2019. </remarks>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="first">    The first to act on. </param>
        /// <param name="second">   A variable-length parameters list containing second. </param>
        ///
        /// <returns>
        /// An enumerator that allows foreach to be used to process append in this collection.
        /// </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static T[] Append<T>(this T[] first, T[] second)
        {
            if (first == null) throw new ArgumentNullException("first");
            if (second == null) throw new ArgumentNullException("second");
            int oldLen = first.Length;
            Array.Resize<T>(ref first, first.Length + second.Length);
            Array.Copy(second, 0, first, oldLen, second.Length);
            return first;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Enumerates prepend in this collection. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="first">    The first to act on. </param>
        /// <param name="second">   A variable-length parameters list containing second. </param>
        ///
        /// <returns>
        /// An enumerator that allows foreach to be used to process prepend in this collection.
        /// </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static IEnumerable Prepend(this IEnumerable first, params object[] second)
        {
            return second.Concat(first.OfType<object>());
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Enumerates prepend in this collection. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="first">    The first to act on. </param>
        /// <param name="second">   A variable-length parameters list containing second. </param>
        ///
        /// <returns>
        /// An enumerator that allows foreach to be used to process prepend in this collection.
        /// </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static IEnumerable<T> Prepend<T>(this IEnumerable<T> first, params T[] second)
        {
            return second.Concat(first);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// An ObservableCollection&lt;T&gt; extension method that removes this CoreExtensions.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="coll">         The coll to act on. </param>
        /// <param name="condition">    The condition. </param>
        ///
        /// <returns>   An int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static int Remove<T>(this ObservableCollection<T> coll, Func<T, bool> condition)
        {
            var itemsToRemove = coll.Where(condition).ToList();

            foreach (var itemToRemove in itemsToRemove)
            {
                coll.Remove(itemToRemove);
            }

            return itemsToRemove.Count;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Enumerates distinct by in this collection. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <typeparam name="TSource">  Type of the source. </typeparam>
        /// <typeparam name="TKey">     Type of the key. </typeparam>
        /// <param name="source">       The source to act on. </param>
        /// <param name="keySelector">  The key selector. </param>
        ///
        /// <returns>
        /// An enumerator that allows foreach to be used to process distinct by in this collection.
        /// </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   An object extension method that query if 'value' is number. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="value">    The value to act on. </param>
        ///
        /// <returns>   True if number, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static bool IsNumber(this object value)
        {
            return value is sbyte
                    || value is byte
                    || value is short
                    || value is ushort
                    || value is int
                    || value is uint
                    || value is long
                    || value is ulong
                    || value is float
                    || value is double
                    || value is decimal;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// An IEnumerable&lt;string&gt; extension method that converts an enumerableList to a unique
        /// identifier collection.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="enumerableList">   The enumerableList to act on. </param>
        ///
        /// <returns>   EnumerableList as an ICollection&lt;Guid&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static ICollection<Guid> ToGuidCollection(this IEnumerable<string> enumerableList)
        {
            if (enumerableList != null)
            {
                //create an empty collection object
                var collection = new Collection<Guid>();

                //loop through all the records and add to collection object
                foreach (var item in enumerableList)
                {
                    Guid g = Guid.Empty;
                    if (Guid.TryParse(item, out g))
                        collection.Add(g);
                }
                //return the populated collection
                return collection;
            }
            return null;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A T extension method that converts an o to a string collection. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="enumerableList">   The enumerableList to act on. </param>
        ///
        /// <returns>   O as an ICollection&lt;string&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static ICollection<string> ToStringCollection<T>(this IEnumerable<T> enumerableList)
        {
            if (enumerableList != null)
            {
                //create an empty collection object
                var collection = new Collection<string>();

                //loop through all the records and add to collection object
                foreach (var item in enumerableList)
                {
                    if (item != null)
                        collection.Add(item.ToString());
                }
                //return the populated collection
                return collection;
            }
            return null;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// An IEnumerable&lt;T&gt; extension method that determine if we are lengths equal.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="o">    The o to act on. </param>
        /// <param name="o1">   The first IEnumerable&lt;T&gt; </param>
        ///
        /// <returns>   True if lengths equal, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static bool AreLengthsEqual<T>(this T[] o, T[] o1)
        {
            int oLength = 0;
            int o1Length = 0;

            if (o == null && o1 == null)
                return true;
            if (o != null)
                oLength = o.Length;
            if (o1 != null)
                o1Length = o1.Length;

            return oLength == o1Length;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// An IEnumerable&lt;T&gt; extension method that determine if we are lengths equal.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="o">    The o to act on. </param>
        /// <param name="o1">   The first IEnumerable&lt;T&gt; </param>
        ///
        /// <returns>   True if lengths equal, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static bool AreLengthsEqual<T>(this IEnumerable<T> o, IEnumerable<T> o1)
        {
            int oLength = 0;
            int o1Length = 0;

            if (o == null && o1 == null)
                return true;
            if (o != null)
                oLength = o.Count();
            if (o1 != null)
                o1Length = o1.Count();

            return oLength == o1Length;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   An IEnumerable&lt;T&gt; extension method that gets a length. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="o">    The o to act on. </param>
        ///
        /// <returns>   The length. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static int GetLength<T>(this IEnumerable<T> o)
        {
            if (o == null)
                return 0;

            return o.Count();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// An IEnumerable&lt;T&gt; extension method that determine if we are contents equal.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="o">    The o to act on. </param>
        /// <param name="o1">   The first IEnumerable&lt;T&gt; </param>
        ///
        /// <returns>   True if contents equal, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static bool AreContentsEqual<T>(this IEnumerable<T> o, IEnumerable<T> o1)
        {
            if (o.AreLengthsEqual(o1) == false)
                return false;

            if (o.GetLength() == 0)
                return true;

            foreach (var i in o)
            {
                if (!o1.Contains(i))
                    return false;
            }

            return true;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A T extension method that converts an o to a string collection. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="o">    The o to act on. </param>
        ///
        /// <returns>   O as an ICollection&lt;string&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static ICollection<string> ToStringCollection<T>(this T o)
        {
            if (o != null)
            {
                //create an empty collection object
                var collection = new Collection<string>();

                if (o is IEnumerable)
                {
                    var e = o as IEnumerable;
                    foreach (var i in e)
                    {
                        collection.Add(i.ToString());
                    }
                }
                else
                    collection.Add(o.ToString());
                //return the populated collection
                return collection;
            }
            return null;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A T extension method that converts an o to a string array. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <param name="o">    The o to act on. </param>
        ///
        /// <returns>   O as a string[]. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string[] ToStringArray<T>(this T o)
        {
            if (o != null)
            {
                //create an empty collection object
                var collection = o.ToStringCollection();
                if (collection != null)
                    return collection.ToArray();
            }
            return null;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A char extension method that query if 'c' is hexadecimal. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="c">    The c to act on. </param>
        ///
        /// <returns>   True if hexadecimal, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static bool IsHex(this char c)
        {
            switch (c)
            {
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                case 'a':
                case 'b':
                case 'c':
                case 'd':
                case 'e':
                case 'f':
                case 'A':
                case 'B':
                case 'C':
                case 'D':
                case 'E':
                case 'F':
                    return true;

                default:
                    return false;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A Type extension method that implements interface. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="type">         The type to act on. </param>
        /// <param name="interFace">    The inter face. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static bool ImplementsInterface(this Type type, Type interFace)
        {
            return type.GetInterfaces().Contains(interFace);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   An object extension method that query if 'obj' is enumerable. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="type"> The type to act on. </param>
        ///
        /// <returns>   True if enumerable, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static bool IsEnumerable(this Type type)
        {
            return typeof(IEnumerable).IsAssignableFrom(type);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   An object extension method that query if 'obj' is enumerable. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="obj">  The obj to act on. </param>
        ///
        /// <returns>   True if enumerable, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static bool IsEnumerable(this object obj)
        {
            var type = obj.GetType();
            return typeof(IEnumerable).IsAssignableFrom(type);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   An object extension method that query if 'obj' is generic list. </summary>
        ///
        /// <remarks>   Kevin, 6/5/2019. </remarks>
        ///
        /// <param name="obj">  The obj to act on. </param>
        ///
        /// <returns>   True if generic list, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static bool IsGenericList(this object obj)
        {
            return IsGenericList(obj.GetType());
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   An object extension method that query if 'obj' is generic list. </summary>
        ///
        /// <remarks>   Kevin, 6/5/2019. </remarks>
        ///
        /// <exception cref="ArgumentNullException">    Thrown when one or more required arguments are
        ///                                             null. </exception>
        ///
        /// <param name="type"> The type to act on. </param>
        ///
        /// <returns>   True if generic list, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static bool IsGenericList(this Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            foreach (Type @interface in type.GetInterfaces())
            {
                if (@interface.IsGenericType)
                {
                    if (@interface.GetGenericTypeDefinition() == typeof(ICollection<>))
                    {
                        // if needed, you can also return the type used as generic argument
                        return true;
                    }
                }
            }

            return (type.GetInterface("IEnumerable") != null);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   An object extension method that gets message type. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="obj">  The obj to act on. </param>
        ///
        /// <returns>   The message type. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string GetMessageType(this object obj)
        {
            return obj.GetType().AssemblyQualifiedName;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   An object extension method that converts an obj to a JSON string. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="obj">  The obj to act on. </param>
        ///
        /// <returns>   Obj as a string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string ToJsonString(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }


        //public static T FromJsonString<T>(this string obj)
        //{
        //    return JsonConvert.DeserializeObject<T>(obj);
        //}
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   An object extension method that converts an obj to a JSON stream. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="obj">  The obj to act on. </param>
        ///
        /// <returns>   Obj as a Stream. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static Stream ToJsonStream(this object obj)
        {
            var json = obj.ToJsonString();
            return new MemoryStream(Encoding.Default.GetBytes(json));
        }

        public static bool SetPropertyByName(this Object obj, string name, Object value)
        {
            var prop = obj.GetType().GetProperty(name, BindingFlags.Public | BindingFlags.Instance);
            if (null == prop || !prop.CanWrite) return false;
            if (!obj.IsPropertyValueEqualByName(name, value))
            {
                prop.SetValue(obj, value, null);
                return true;
            }
            return false;
        }

        public static bool IsPropertyValueEqualByName(this Object obj, string name, Object value)
        {
            var prop = obj.GetType().GetProperty(name, BindingFlags.Public | BindingFlags.Instance);
            if (null == prop || !prop.CanWrite) return false;
            var currentValue = prop.GetValue(obj);
            return currentValue == value;
        }

        public static string ToSeparatedString<T>(this IEnumerable<T> enumerableList, char separator, bool quoteItems)
        {
            if (enumerableList != null)
            {
                //create an empty collection object
                var sb = new StringBuilder();

                //loop through all the records and add to collection object
                foreach (var item in enumerableList)
                {
                    if (item != null)
                    {
                        if (sb.Length > 0)
                            sb.Append(separator);
                        if (quoteItems)
                            sb.Append("\'");
                        sb.Append(item);
                        if (quoteItems)
                            sb.Append("\'");
                    }
                }
                //return the populated collection
                return sb.ToString();
            }
            return null;
        }

        public static bool HasValueAndNotEmpty(this Guid? g)
        {
            return g.HasValue && g.Value != Guid.Empty;
        }
    }
}

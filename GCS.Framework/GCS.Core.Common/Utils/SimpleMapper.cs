////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Utils\SimpleMapper.cs
//
// summary:	Implements the simple mapper class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using GCS.Core.Common.Extensions;

namespace GCS.Core.Common.Utils
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A simple mapper. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static class SimpleMapper
    {

        public static bool MyInterfaceFilter(Type typeObj, Object criteriaObj)
        {
            if (typeObj.ToString() == criteriaObj.ToString())
                return true;
            else
                return false;
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// public static void PropertyMap<T, U>(T source, U destination, DateTimeOffset?
        /// defaultNullDateTimeValue )
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <typeparam name="U">    Generic type parameter. </typeparam>
        /// <param name="source">       Source for the. </param>
        /// <param name="destination">  Destination for the. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void PropertyMap<T, U>(T source, U destination)
            where T : class, new()
            where U : class, new()
        {
            List<PropertyInfo> sourceProperties = source.GetType().GetProperties().ToList<PropertyInfo>();
            List<PropertyInfo> destinationProperties = destination.GetType().GetProperties().ToList<PropertyInfo>();

            foreach (PropertyInfo sourceProperty in sourceProperties)
            {
                PropertyInfo destinationProperty = destinationProperties.Find(item => item.Name == sourceProperty.Name);

                if (destinationProperty != null)
                {
                    try
                    {
                        object oValue = sourceProperty.GetValue(source, null);

                        if (sourceProperty.PropertyType != destinationProperty.PropertyType)
                        {
                            if (sourceProperty.PropertyType == typeof(DateTimeOffset?) &&
                                oValue == null)
                                oValue = DateTimeOffset.Now.MinSqlDateTime();
                            else if (sourceProperty.PropertyType == typeof(DateTimeOffset) &&
                                     ((DateTimeOffset)oValue).Year == 1753 &&
                                     ((DateTimeOffset)oValue).Month == 1 &&
                                     ((DateTimeOffset)oValue).Day == 1 &&
                                     ((DateTimeOffset)oValue).Hour == 0 &&
                                     ((DateTimeOffset)oValue).Minute == 0 &&
                                     ((DateTimeOffset)oValue).Second == 0)
                                oValue = null;
                        }

                        bool isSourceEnum = typeof(Enum).IsAssignableFrom(sourceProperty.PropertyType);
                        bool isDestEnum = typeof(Enum).IsAssignableFrom(destinationProperty.PropertyType);
                        try
                        {
                            if (destinationProperty.CanWrite && destinationProperty.GetSetMethod(/*nonPublic*/ true).IsPublic)
                            {
                                //if( destinationProperty.PropertyType.IsPrimitive == false && !destinationProperty.PropertyType.FullName.StartsWith("System.") )
                                //{
                                //    Trace.WriteLine($"SimpleMapper.PropertyMap skipping {destinationProperty.Name}");                                   
                                //}
                                //else 
                                if (isSourceEnum == isDestEnum || isDestEnum)
                                {
                                    destinationProperty.SetValue(destination, oValue, null);
                                }
                                else
                                {
                                    var convertedValue = Convert.ChangeType(oValue, destinationProperty.PropertyType);
                                    destinationProperty.SetValue(destination, convertedValue, null);
                                }
                            }
                        }
                        catch (ArgumentException ex)
                        {
                            Trace.WriteLine($"SimpleMapper.PropertyMap Exception mapping property: {source}.{sourceProperty.Name} - {destination}.{destinationProperty.Name}, {ex.ToString()}");
                        }
                    }
                    catch (ArgumentException ex)
                    {
                        Trace.WriteLine($"SimpleMapper.PropertyMap Exception mapping property: {source}.{sourceProperty.Name} - {destination}.{destinationProperty.Name}, {ex.ToString()}");
                    }
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Property map. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <typeparam name="U">    Generic type parameter. </typeparam>
        /// <param name="source">               Source for the. </param>
        /// <param name="destination">          Destination for the. </param>
        /// <param name="excludeProperties">    The exclude properties. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void PropertyMap<T, U>(T source, U destination, IEnumerable<string> excludeProperties)
            where T : class, new()
            where U : class, new()
        {
            List<PropertyInfo> sourceProperties = source.GetType().GetProperties().ToList<PropertyInfo>();
            List<PropertyInfo> destinationProperties = destination.GetType().GetProperties().ToList<PropertyInfo>();

            foreach (PropertyInfo sourceProperty in sourceProperties)
            {
                if (excludeProperties == null || string.IsNullOrEmpty(excludeProperties.FirstOrDefault(n => n == sourceProperty.Name)))
                {
                    PropertyInfo destinationProperty = destinationProperties.Find(item => item.Name == sourceProperty.Name);

                    if (destinationProperty != null)
                    {
                        try
                        {
                            object oValue = sourceProperty.GetValue(source, null);

                            if (sourceProperty.PropertyType != destinationProperty.PropertyType)
                            {
                                if (sourceProperty.PropertyType == typeof(DateTimeOffset?) &&
                                    oValue == null)
                                    oValue = DateTimeOffset.MinValue;
                                else if (sourceProperty.PropertyType == typeof(DateTimeOffset) &&
                                         ((DateTimeOffset)oValue).Year == 1753 &&
                                         ((DateTimeOffset)oValue).Month == 1 &&
                                         ((DateTimeOffset)oValue).Day == 1 &&
                                         ((DateTimeOffset)oValue).Hour == 0 &&
                                         ((DateTimeOffset)oValue).Minute == 0 &&
                                         ((DateTimeOffset)oValue).Second == 0)
                                    oValue = null;
                            }
                            if (destinationProperty.CanWrite && destinationProperty.GetSetMethod(/*nonPublic*/ true).IsPublic)
                                destinationProperty.SetValue(destination, oValue, null);
                            //else
                            //{
                            //    Trace.WriteLine(string.Format("Property '{0}' does not have a public setter", destinationProperty.Name));
                            //}
                        }
                        catch (ArgumentException ex)
                        {
                            Trace.WriteLine(ex.ToString());
                        }
                    }
                    else
                    {
                        Trace.WriteLine(string.Format("Property '{0}' excluded", sourceProperty.Name));
                    }

                }
            }
        }
    }
}

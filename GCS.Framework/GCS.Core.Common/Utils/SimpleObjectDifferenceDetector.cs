////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Utils\SimpleObjectDifferenceDetector.cs
//
// summary:	Implements the simple object difference detector class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GCS.Core.Common.Utils
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A simple object difference detector. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static class SimpleObjectDifferenceDetector
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Information about the property change. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public class PropertyChangeInformation
        {
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Default constructor. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

            public PropertyChangeInformation()
            {
                PropertyName = string.Empty;
                OriginalValue = null;
                NewValue = null;
                PropertyType = typeof (object);
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Constructor. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ///
            /// <param name="propertyName">     The name of the property. </param>
            /// <param name="originalValue">    The original value. </param>
            /// <param name="newValue">         The new value. </param>
            /// <param name="propertyType">     The type of the property. </param>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

            public PropertyChangeInformation(string propertyName, object originalValue, object newValue, Type propertyType)
            {
                PropertyName = propertyName;
                OriginalValue = originalValue;
                NewValue = newValue;
                PropertyType = propertyType;
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Gets or sets the name of the property. </summary>
            ///
            /// <value> The name of the property. </value>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

            public string PropertyName { get; set; }

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Gets or sets the original value. </summary>
            ///
            /// <value> The original value. </value>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

            public object OriginalValue { get; set; }

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Gets or sets the new value. </summary>
            ///
            /// <value> The new value. </value>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

            public object NewValue { get; set; }

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Gets or sets the type of the property. </summary>
            ///
            /// <value> The type of the property. </value>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

            public Type PropertyType { get; set; }

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Returns a string that represents the current object. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ///
            /// <returns>   A string that represents the current object. </returns>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

            public override string ToString()
            {
                return string.Format("PropertyName=\"{0}\", PropertyType={1}, OldValue=\"{2}\", NewValue=\"{3}\"",
                    PropertyName, PropertyType, OriginalValue, NewValue);
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A compare results. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public class CompareResults
        {
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Default constructor. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

            public CompareResults()
            {
                CompareDateTime = DateTimeOffset.Now;
                PropertyChanges = new Dictionary<string, PropertyChangeInformation>();
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Gets or sets the compare date time. </summary>
            ///
            /// <value> The compare date time. </value>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

            public DateTimeOffset CompareDateTime { get; internal set; }

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Gets or sets the property changes. </summary>
            ///
            /// <value> The property changes. </value>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

            public Dictionary<string, PropertyChangeInformation> PropertyChanges { get; internal set; }

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Compare objects. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        /// <typeparam name="U">    Generic type parameter. </typeparam>
        /// <param name="originalObject">       The original object. </param>
        /// <param name="newObject">            The new object. </param>
        /// <param name="propertiesToIgnore">   The properties to ignore. </param>
        ///
        /// <returns>   The CompareResults. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static CompareResults CompareObjects<T, U>(T originalObject, U newObject, List<String> propertiesToIgnore)
            where T : class, new()
            where U : class, new()
        {
            CompareResults results = new CompareResults();

            if (originalObject == null || newObject == null)
                return results;

            List<PropertyInfo> originalObjectProperties = originalObject.GetType().GetProperties().ToList<PropertyInfo>();
            List<PropertyInfo> newObjectProperties = newObject.GetType().GetProperties().ToList<PropertyInfo>();

            foreach (PropertyInfo originalProperty in originalObjectProperties)
            {
                if (propertiesToIgnore == null || 
                    propertiesToIgnore.Contains(originalProperty.Name) == false)
                { 
                    PropertyInfo newProperty = newObjectProperties.Find(item => item.Name == originalProperty.Name);

                    if (newProperty != null)
                    {
                        try
                        {
                            object originalPropertyValue = originalProperty.GetValue(originalObject, null);
                            object newPropertyValue = newProperty.GetValue(newObject, null);
                            if (originalPropertyValue != null)
                            {
                                if (originalPropertyValue.Equals(newPropertyValue) == false)
                                {
                                    bool bChanged = true;
                                    if (originalPropertyValue.GetType() == typeof (byte[]))
                                    {
                                        if (ByteArrayUtilities.ByteArrayEquals((byte[])originalPropertyValue, (byte[])newPropertyValue))
                                            bChanged = false;
                                    }
                                    if( bChanged == true)
                                    {
                                        results.PropertyChanges.Add(originalProperty.Name,
                                            new PropertyChangeInformation(originalProperty.Name,
                                                originalPropertyValue, newPropertyValue, originalPropertyValue.GetType()));
                                    }
                                }
                            }
                            else if (newPropertyValue != null)
                            {
                                results.PropertyChanges.Add(originalProperty.Name,
                                    new PropertyChangeInformation(originalProperty.Name,
                                        null, newPropertyValue, newPropertyValue.GetType()));
                            }
                        }
                        catch (ArgumentException e)
                        {
                            System.Diagnostics.Trace.WriteLine(e.ToString());
                        }
                        catch (Exception e)
                        {
                            System.Diagnostics.Trace.WriteLine(e.ToString());
                        }
                    }
                }
            }
            return results;
        }
    }
}
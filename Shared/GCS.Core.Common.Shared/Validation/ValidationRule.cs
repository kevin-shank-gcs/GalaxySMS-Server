﻿////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Validation\ValidationRule.cs
//
// summary:	Implements the validation rule class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Core.Common.Validation
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>
    /// This class holds the business rule failure message for a specific property.
    /// </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class ValidationRule
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor for PDSAValidation Class. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="propertyName"> The property name that is in error. </param>
        /// <param name="message">      The message. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ValidationRule(string propertyName, string message)
        {
            PropertyName = propertyName;
            Message = message;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the property name. </summary>
        ///
        /// <value> The name of the property. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string PropertyName { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Get/Set the business rule failure message. </summary>
        ///
        /// <value> The message. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string Message { get; set; }
    }


}

////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Exceptions\DataValidationException.cs
//
// summary:	Implements the data validation exception class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Validation;

namespace GCS.Core.Common.Exceptions
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Exception for signalling data validation errors. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class DataValidationException : ApplicationException
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="message">  The message. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataValidationException(string message)
            : this(message, null)
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="message">          The message. </param>
        /// <param name="innerException">   The inner exception. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataValidationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="validationFailures">   The validation failures. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DataValidationException(IEnumerable<FluentValidation.Results.ValidationFailure> validationFailures)
        {
            foreach( var vf in validationFailures)
                AddValidationRuleMessage(vf);
        }

        /// <summary>   The validation rules messages. </summary>
        private List<ValidationRule> _validationRulesMessages = new List<ValidationRule>();

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the validation rule messages. </summary>
        ///
        /// <value> The validation rule messages. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public ValidationRule[] ValidationRuleMessages
        {
            get
            {
                return _validationRulesMessages.ToArray();
            }
            internal set { ; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Adds a validation rule message to 'message'. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="rule"> The rule. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void AddValidationRuleMessage(ValidationRule rule)
        {
            _validationRulesMessages.Add(rule);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Adds a validation rule message to 'message'. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="validationFailure">    The validation failure. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void AddValidationRuleMessage(FluentValidation.Results.ValidationFailure validationFailure)
        {
            _validationRulesMessages.Add(new ValidationRule( validationFailure.PropertyName, validationFailure.ErrorMessage));
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Adds a validation rule message to 'message'. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="properyName">  Name of the propery. </param>
        /// <param name="message">      The message. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void AddValidationRuleMessage(string properyName, string message )
        {
            _validationRulesMessages.Add(new ValidationRule(properyName, message));
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Creates and returns a string representation of the current exception. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   A string representation of the current exception. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (ValidationRule vr in _validationRulesMessages)
            {
                sb.Append(string.Format(vr.Message + "\n"));
            }
            return sb.ToString();
        }
    }
}

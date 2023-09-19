////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	ExceptionDetailEx.cs
//
// summary:	Implements the exception detail ex class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Exceptions;

namespace GCS.Core.Common.ServiceModel
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   An exception detail ex. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class ExceptionDetailEx : System.ServiceModel.ExceptionDetail
    {
        /// <summary>   The messages. </summary>
        List<string> _messages = new List<string>();

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="exception">    The exception. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ExceptionDetailEx(Exception exception)
            : base(exception)
        {
        }


        public ExceptionDetailEx(DataValidationException exception)
            : base(exception)
        {
            ValidationErrors = new Dictionary<string, string[]>();
            foreach (var vrGroupings in exception.ValidationRuleMessages.GroupBy(o=>o.PropertyName))
            {
                foreach (var vr in vrGroupings)
                {
                    var errors = new List<string>();
                    errors.Add(vr.Message);
                    ValidationErrors.Add(vr.PropertyName, errors.ToArray());
                }
            }
        }


        public ExceptionDetailEx(System.Net.WebException exception)
            : base(exception)
        {
            if(exception.Response != null)
                _messages.Add(((HttpWebResponse)exception.Response).StatusDescription);
            else
            {
                _messages.Add(exception.Message);
                var ex = exception.InnerException;
                while( ex != null)
                {
                    _messages.Add(ex.Message);
                    ex = ex.InnerException;
                }
            }
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the messages. </summary>
        ///
        /// <value> The messages. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string[] Messages
        {
            get
            {
                if (_messages == null)
                    _messages = new List<string>();
                return _messages.ToArray();
            }
            internal set {; }
        }

        [DataMember]
        public IDictionary<string, string[]> ValidationErrors { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the preferred HTTP status code. </summary>
        ///
        /// <value> The preferred HTTP status code. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public HttpStatusCode PreferredHttpStatusCode { get; set; } = HttpStatusCode.BadRequest;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Adds a message. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="message">  The message. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void AddMessage(string message)
        {
            if (_messages == null)
                _messages = new List<string>();
            _messages.Add(message);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Returns the exception detail information for the exception passed to the constructor.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   The message and stack trace of the exception. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.Message + "\n");
            if (_messages != null)
            {
                foreach (string m in _messages)
                {
                    sb.Append(string.Format(m + "\n"));
                }
            }
            return sb.ToString();
        }
    }
}


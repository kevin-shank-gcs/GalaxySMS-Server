////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	ExceptionDetailEx.cs
//
// summary:	Implements the exception detail ex class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
            internal set { ; }
        }

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


////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Misc\CustomError.cs
//
// summary:	Implements the custom error class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.ServiceModel;

namespace GCS.Core.Common
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   (Serializable) a custom error. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [Serializable]
    public class CustomError
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Creates a new validation failure. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="error">    The error. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CustomError(string error)
        {
            PropertyName = string.Empty;
            ErrorMessage = error;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Creates a new validation failure. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="propertyName"> The name of the property. </param>
        /// <param name="error">        The error. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CustomError(string propertyName, string error)
        {
            PropertyName = propertyName;
            ErrorMessage = error;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Creates a new ValidationFailure. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="propertyName">     The name of the property. </param>
        /// <param name="error">            The error. </param>
        /// <param name="attemptedValue">   The attempted value. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CustomError(string propertyName, string error, object attemptedValue)
        {
            PropertyName = propertyName;
            ErrorMessage = error;
            AttemptedValue = attemptedValue;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Creates a new validation failure. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="exception">    The exception. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CustomError(Exception exception)
        {
            ExceptionDetail = new ExceptionDetail(exception);
            PropertyName = string.Empty;

            if (exception.InnerException != null)
            {
                ErrorMessages = new List<string>();
                ErrorMessages.Add(exception.Message);

                Exception ex = exception;
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    ErrorMessages.Add(ex.Message);
                }
                ErrorMessage = ex.Message;
            }
            else
            {
                ErrorMessage = exception.Message;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Creates a new validation failure. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="exceptionDetailEx">    The exception detail ex. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CustomError(ExceptionDetailEx exceptionDetailEx)
        {
            ExceptionDetailEx = exceptionDetailEx;

            PropertyName = string.Empty;
            if (exceptionDetailEx.InnerException != null)
            {
                ErrorMessages = new List<string>();
                ErrorMessages.Add(exceptionDetailEx.Message);
                
                ExceptionDetail ex = exceptionDetailEx.InnerException;

                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    ErrorMessages.Add(ex.Message);
                }

                ErrorMessage = ex.Message;
            }
            else
            {
                ErrorMessage = exceptionDetailEx.Message;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Creates a new validation failure. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="exceptionDetail">  The exception detail. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public CustomError(ExceptionDetail exceptionDetail)
        {
            ExceptionDetail = exceptionDetail;
            PropertyName = string.Empty;
            if (exceptionDetail.InnerException != null)
            {
                ErrorMessages = new List<string>();
                ErrorMessages.Add(exceptionDetail.Message);

                ExceptionDetail ex = exceptionDetail.InnerException;

                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                    ErrorMessages.Add(ex.Message);
                }

                ErrorMessage = ex.Message;
            }
            else
            {
                ErrorMessage = exceptionDetail.Message;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Creates a textual representation of the failure. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   A string that represents this CustomError. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public override string ToString()
        {
            if (string.IsNullOrEmpty(PropertyName))
                return ErrorMessage;

            return string.Format("'{0}' {1}", PropertyName, ErrorMessage);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   The name of the property. </summary>
        ///
        /// <value> The name of the property. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string PropertyName { get; internal set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   The error message. </summary>
        ///
        /// <value> A message describing the error. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string ErrorMessage { get; internal set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   The property value that caused the failure. </summary>
        ///
        /// <value> The attempted value. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public object AttemptedValue { get; internal set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Custom state associated with the failure. </summary>
        ///
        /// <value> The custom state. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public object CustomState { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the error messages. </summary>
        ///
        /// <value> The error messages. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public List<string> ErrorMessages { get; internal set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the exception detail. </summary>
        ///
        /// <value> The exception detail. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ExceptionDetail ExceptionDetail { get; internal set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the exception detail ex. </summary>
        ///
        /// <value> The exception detail ex. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ExceptionDetailEx ExceptionDetailEx { get; internal set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the type of the exception. </summary>
        ///
        /// <value> The type of the exception. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string ExceptionType
        {
            get
            {
                if (ExceptionDetailEx != null)
                    return ExceptionDetailEx.Type;
                if (ExceptionDetail != null)
                    return ExceptionDetail.Type;
                if (!string.IsNullOrWhiteSpace(PropertyName))
                    return PropertyName;
                if (!string.IsNullOrWhiteSpace(ErrorMessage))
                    return ErrorMessage;

                return string.Empty;
            }
        }
    }
}

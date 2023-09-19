////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\UserSignInRequest.cs
//
// summary:	Implements the user sign in request class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;
using GCS.Framework.Security;
using FluentValidation;
using GCS.Framework.Utilities;
using GCS.Core.Common.Swagger;

namespace GalaxySMS.Client.Entities
{
    [DataContract]
    public class UpdateUserPasswordResult : ObjectBaseSimple
    {
        private string _result;


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public UpdateUserPasswordResult()
        {

        }

        [DataMember]
        public string Result
        {
            get { return _result; }
            set
            {
                if (_result != value)
                {
                    _result = value;
                    OnPropertyChanged(() => Result);
                }
            }
        }
    }

}

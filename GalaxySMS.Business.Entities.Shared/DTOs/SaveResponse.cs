////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\SaveParameters.cs
//
// summary:	Implements the save parameters class
///=================================================================================================

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;
using GCS.Core.Common.Extensions;


#if NetCoreApi
using System.ComponentModel.DataAnnotations;
namespace GalaxySMS.Business.Entities.Api.NetCore
#else
namespace GalaxySMS.Business.Entities
#endif
{
#if NetCoreApi
#else
    [DataContract]
#endif
    public class SaveResponse : ISaveResponse
    {
        public SaveResponse()
        {
            Init();
        }

        private void Init()
        {
            Errors = new Dictionary<string, string[]>();
        }

        public SaveResponse(ISaveResponse p)
        {
            Init();
            Errors = p.Errors;
            OperationUid = p.OperationUid;
            SaveType = p.SaveType;
            HttpStatus = p.HttpStatus;
            //Ex = p.Ex;
        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid OperationUid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif  
        public SaveOperationType SaveType { get; set; } = SaveOperationType.AddOrUpdate;


#if NetCoreApi
#else
        [DataMember]
#endif  
        //public ValidationProblemDetails ValidationErrors { get; set; }
        public Dictionary<string, string[]> Errors { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif  
        public HttpStatusCode HttpStatus { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif  
//        public Exception Ex { get; set; }
    }

#if NetCoreApi
#else
    [DataContract]
#endif

    public class SaveResponse<T> : SaveResponse, ISaveResponse<T> where T : class, new()
    {
        public SaveResponse() : base()
        {
            Init();
        }

        private void Init()
        {
            Data = new T();
        }

        public SaveResponse(ISaveResponse p) : base(p)
        {
            Init();
        }

        public SaveResponse(ISaveResponse<T> p) : base(p)
        {
            Init();
            Data = p.Data;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the data. </summary>
        ///
        /// <value> The data. </value>
        ///=================================================================================================

#if NetCoreApi
#else
        [DataMember]
#endif

        public T Data { get; set; }
    }
}

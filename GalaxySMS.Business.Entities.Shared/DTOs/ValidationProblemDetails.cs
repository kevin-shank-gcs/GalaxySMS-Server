using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Extensions;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
#if NetCoreApi
#else
    [DataContract]
#endif
    public class ValidationProblemDetails : IValidationProblemDetails
    {
        public ValidationProblemDetails()
        {
            Errors = new Dictionary<string, string[]>();
        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Dictionary<string, string[]> Errors { get; set; }

        public bool IsValid => !Errors.Any();

        public void Merge(IValidationProblemDetails data)
        {
            if( data.Errors != null && data.Errors.Any())
                Errors.AddRange(data.Errors);
        }
    }
}

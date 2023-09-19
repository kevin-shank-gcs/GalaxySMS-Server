using System;
using System.Collections.Generic;

namespace GCS.Core.Common.Contracts
{
    public interface IValidationProblemDetails
    {
        IDictionary<string, string[]> Errors { get; set; }

        bool IsValid { get; }
        void Merge(ValidationProblemDetails data);
    }
}
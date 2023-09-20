using System;
using System.Collections.Generic;

namespace GCS.Core.Common.Contracts
{
    public interface IValidationProblemDetails
    {
        Dictionary<string, string[]> Errors { get; set; }
        bool IsValid { get; }
        void Merge(IValidationProblemDetails data);
    }
}
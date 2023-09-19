using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;

namespace GalaxySMS.Data.Contracts
{
    public interface IValidationRepository: IDataRepository
    {
        ValidationProblemDetails Validate(GuidValidationRequest validationProblemDetails);
    }
}

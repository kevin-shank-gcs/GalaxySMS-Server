using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IOutputCommandRepository : IDataRepository<OutputCommand>
    {
        IEnumerable<OutputCommand> GetAllOutputCommandsForOutputMode(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}


using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface ICommandScriptRepository : IDataRepository<CommandScript>
    {
        IEnumerable<CommandScript> GetAllCommandScriptsForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
    }
}


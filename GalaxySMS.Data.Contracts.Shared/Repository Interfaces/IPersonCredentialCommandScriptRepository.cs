using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IPersonCredentialCommandScriptRepository : IDataRepository<PersonCredentialCommandScript>
    {
        IEnumerable<PersonCredentialCommandScript> GetAllPersonCredentialCommandScriptsForPerson(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<PersonCredentialCommandScript> GetAllPersonCredentialCommandScriptsForPersonCredential(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<PersonCredentialCommandScript> GetAllPersonCredentialCommandScriptsForCommandScript(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<PersonCredentialCommandScript> GetAllPersonCredentialCommandScriptsForDelayedCommandScript(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
    }
}


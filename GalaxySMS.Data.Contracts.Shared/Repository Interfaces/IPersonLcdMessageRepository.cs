using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IPersonLcdMessageRepository : IDataRepository<PersonLcdMessage>
    {
        IEnumerable<PersonLcdMessage> GetAllPersonLcdMessagesForPerson(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);

    }
}


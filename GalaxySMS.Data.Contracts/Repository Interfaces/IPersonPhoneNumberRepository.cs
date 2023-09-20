using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IPersonPhoneNumberRepository : IDataRepository<PersonPhoneNumber>
    {
        IEnumerable<PersonPhoneNumber> GetAllPersonPhoneNumbersForPerson(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<PersonPhoneNumber> GetAllPersonPhoneNumbersForPhoneNumber(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);

    }
}


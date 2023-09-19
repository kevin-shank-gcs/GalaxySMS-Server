using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IPersonEmailAddressRepository : IDataRepository<PersonEmailAddress>
    {
        IEnumerable<PersonEmailAddress> GetAllPersonEmailAddressesForPerson(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<PersonEmailAddress> GetAllPersonEmailAddressesForEmailAddress(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);

    }
}


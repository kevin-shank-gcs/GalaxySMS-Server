using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IPersonDatePropertyRepository : IDataRepository<PersonDateProperty>
    {
        IEnumerable<PersonDateProperty> GetAllPersonDatePropertiesForUserDefinedProperty(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<PersonDateProperty> GetAllPersonDatePropertiesForPerson(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<PersonDateProperty> GetAllPersonDatePropertiesForUserDefinedPropertyAndPerson(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);

    }
}


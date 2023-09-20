using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IPersonNumberPropertyRepository : IDataRepository<PersonNumberProperty>
    {
        IEnumerable<PersonNumberProperty> GetAllPersonNumberPropertiesForUserDefinedProperty(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<PersonNumberProperty> GetAllPersonNumberPropertiesForPerson(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);

    }
}


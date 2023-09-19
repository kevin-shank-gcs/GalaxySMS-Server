using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IPersonTextPropertyRepository : IDataRepository<PersonTextProperty>
    {
        IEnumerable<PersonTextProperty> GetAllPersonTextPropertiesForUserDefinedProperty(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<PersonTextProperty> GetAllPersonTextPropertiesForPerson(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);

    }
}


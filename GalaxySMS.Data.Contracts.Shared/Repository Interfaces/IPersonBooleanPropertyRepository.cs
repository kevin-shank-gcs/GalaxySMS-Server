using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IPersonBooleanPropertyRepository : IDataRepository<PersonBooleanProperty>
    {
        IEnumerable<PersonBooleanProperty> GetAllPersonBooleanPropertiesForUserDefinedProperty(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<PersonBooleanProperty> GetAllPersonBooleanPropertiesForPerson(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<PersonBooleanProperty> GetAllPersonBooleanPropertiesForUserDefinedPropertyAndPerson(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);

    }
}


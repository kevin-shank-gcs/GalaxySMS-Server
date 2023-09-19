using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IPersonListPropertyItemRepository : IDataRepository<PersonListPropertyItem>
    {
        IEnumerable<PersonListPropertyItem> GetAllPersonListPropertyItemsForUserDefinedProperty(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<PersonListPropertyItem> GetAllPersonListPropertyItemsForUserDefinedListPropertyItem(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<PersonListPropertyItem> GetAllPersonListPropertyItemsForPerson(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<PersonListPropertyItem> GetAllPersonListPropertyItemsForUserDefinedPropertyAndPerson(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);

    }
}


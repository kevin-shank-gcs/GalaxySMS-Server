using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IUserDefinedListPropertyItemRepository : IDataRepository<UserDefinedListPropertyItem>
    {
        IEnumerable<UserDefinedListPropertyItem> GetAllUserDefinedListPropertyItemsForUserDefinedProperty(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        UserDefinedListPropertyItem GetByUserDefinedPropertyUidAndDisplay(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
    }
}


using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IPersonPropertyBagRepository : IDataRepository<PersonPropertyBag>
    {
        IEnumerable<PersonPropertyBag> GetAllPersonPropertyBagsPersonAndPropertyName(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<PersonPropertyBag> GetAllPersonPropertyBagsPersonAndTag(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);
        IEnumerable<PersonPropertyBag> GetAllPersonPropertyBagsForPerson(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto getParameters);

    }
}


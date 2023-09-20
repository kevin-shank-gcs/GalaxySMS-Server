using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using System.Collections.Generic;

namespace GalaxySMS.Data.Contracts
{
    public interface IUserDefinedPropertyRepository : IDataRepository<UserDefinedProperty>
    {
        IEnumerable<UserDefinedProperty> GetAllUserDefinedPropertiesForEntity(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        UserDefinedProperty GetByEntityIdAndPropertyName(IApplicationUserSessionDataHeader sessionData, IGetParametersWithPhoto parameters);
        
    }
}


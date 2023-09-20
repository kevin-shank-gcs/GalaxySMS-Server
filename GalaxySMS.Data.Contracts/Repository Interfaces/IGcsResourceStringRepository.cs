using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;
using System;
using PDSA.DataLayer.DataClasses;

namespace GalaxySMS.Data.Contracts
{
    public interface IGcsResourceStringRepository : IDataRepository<gcsResourceString>
    {
        gcsResourceString GetByResourceName(string resourceName, IApplicationUserSessionDataHeader sessionData, PDSATransaction transaction);

        IHasDisplayResourceKey SaveDisplayResource(IHasDisplayResourceKey entity, IApplicationUserSessionDataHeader sessionData,
            PDSATransaction transaction, ISaveParameters saveParams);

        IHasDescriptionResourceKey SaveDescriptionResource(IHasDescriptionResourceKey entity, IApplicationUserSessionDataHeader sessionData,
            PDSATransaction transaction, ISaveParameters saveParams);

        gcsResourceString SaveResourceString(gcsResourceString resource, IApplicationUserSessionDataHeader sessionData, PDSATransaction transaction, ISaveParameters saveParams);
    }
}

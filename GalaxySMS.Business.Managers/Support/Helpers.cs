using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Business.Entities;
using GalaxySMS.Data.Contracts;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Exceptions;
using GCS.Core.Common.ServiceModel;

namespace GalaxySMS.Business.Managers.Support
{
    public static class WcfManagerHelpers
    {
        public static Guid GetEntityIdOf(IHasGetEntityId repo, Guid uid, bool throwNotFoundException, string typeName, string propertyName)
        {
            var entityId = repo.GetEntityId(uid);
            if (entityId == Guid.Empty && throwNotFoundException)
            {
                if (entityId == Guid.Empty)
                {
                    NotFoundException ex = new NotFoundException($"{typeName} with {propertyName}: {uid} not found");
                    ExceptionDetailEx detail = new ExceptionDetailEx(ex);
                    throw new FaultException<ExceptionDetailEx>(detail, ex.Message);
                }
            }
            return entityId;
        }

        public static Guid GetEntityIdOfSite(Guid siteUid, bool throwNotFoundException, IDataRepositoryFactory dataRepositoryFactory)
        {
            var repository = dataRepositoryFactory.GetDataRepository<ISiteRepository>();
            return GetEntityIdOf(repository, siteUid, throwNotFoundException, nameof(Site), nameof(Site.SiteUid));
        }

        public static Guid GetEntityIdOfMercScpGroup(Guid mercScpGroupUid, bool throwNotFoundException, IDataRepositoryFactory dataRepositoryFactory)
        {
            var repository = dataRepositoryFactory.GetDataRepository<IMercScpGroupRepository>();
            return GetEntityIdOf(repository, mercScpGroupUid, throwNotFoundException, nameof(MercScpGroup), nameof(MercScpGroup.MercScpGroupUid));
        }

    }
}

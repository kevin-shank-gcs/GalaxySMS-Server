using System;
using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;

namespace GalaxySMS.Data.Contracts
{
    public interface IAccessPortalUpdateRepository
    {
        void SetIsEnabled(Guid accessPortalUid, bool isEnabled);
    }
}

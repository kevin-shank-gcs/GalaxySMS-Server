using GalaxySMS.Data.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.BusinessLayer;
using GCS.Core.Common.Logger;

namespace GalaxySMS.Data
{
    [Export(typeof(IAccessPortalUpdateRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class AccessPortalUpdateRepository: IAccessPortalUpdateRepository
    {
        public void SetIsEnabled(Guid accessPortalUid, bool isEnabled)
        {
            try
            {
                var mgr = new AccessPortal_SetIsEnabledPDSAManager();
                mgr.Entity.AccessPortalUid = accessPortalUid;
                mgr.Entity.IsEnabled = isEnabled;
                mgr.Execute();
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
                throw;
            }
        }
    }
}

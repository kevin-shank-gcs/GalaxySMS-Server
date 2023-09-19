using GalaxySMS.Business.Entities;
using GalaxySMS.BusinessLayer;
using GalaxySMS.Data.Contracts;
using GalaxySMS.Data.PDSA.ValidationClasses;
using GCS.Core.Common.Data;
using GCS.Core.Common.Exceptions;
using GCS.Core.Common.Extensions;
using GCS.Core.Common.Logger;
using PDSA.Validation;
using System;
using System.ComponentModel.Composition;

namespace GalaxySMS.Data
{
    [Export(typeof(IActivityEventAcknowledgementInsertRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ActivityEventAcknowledgementInsertRepository : DataInsertRepositoryBase<ActivityEventAcknowledgement>, IActivityEventAcknowledgementInsertRepository
    {
        protected override void InsertEntity(ActivityEventAcknowledgement entity)
        {
            //try
            //{
            //    var mgr = new ActivityEventAcknowledgementPDSA_InsertPDSAManager()
            //    {
            //        Entity =
            //        {
            //            ActivityEventAcknowledgementUid = entity.ActivityEventAcknowledgementUid,
            //            ActivityEventUid = entity.ActivityEventUid,
            //            DeviceEntityId = entity.DeviceEntityId,
            //            DeviceUid = entity.DeviceUid,
            //            ActivityEventCategory = entity.ActivityEventCategory,
            //            Response = entity.Response,
            //            AckedByUserId = entity.AckedByUserId,
            //            AckedByUserDisplayName = entity.AckedByUserDisplayName,
            //            AckedDateTime = entity.AckedDateTime,
            //            AckedUpdatedDateTime = entity.AckedUpdatedDateTime
            //        }
            //    };
            //    var ret = mgr.Execute();
            //}
            //catch (PDSAValidationException ex)
            //{
            //    DataValidationException dve = Converters.ConvertToDataValidationException(ex);
            //    throw dve;
            //}
            //catch (Exception ex)
            //{
            //    this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
            //    throw;
            //}

        }

    }
}

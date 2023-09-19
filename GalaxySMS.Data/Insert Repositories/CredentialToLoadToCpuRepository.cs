using GalaxySMS.Business.Entities;
using GalaxySMS.BusinessLayer;
using GalaxySMS.Data.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Data.PDSA.ValidationClasses;
using GCS.Core.Common.Data;
using GCS.Core.Common.Exceptions;
using GCS.Core.Common.Extensions;
using GCS.Core.Common.Logger;
using PDSA.Validation;
using GCS.Core.Common.Utils;

namespace GalaxySMS.Data
{
    [Export(typeof(ICredentialToLoadToCpuRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class CredentialToLoadToCpuRepository : DataInsertRepositoryBase<CredentialToLoadToCpu>, ICredentialToLoadToCpuRepository
    {
        protected override void InsertEntity(CredentialToLoadToCpu entity)
        {
            try
            {
                var mgr = new CredentialToLoadToCpuPDSAManager();
                mgr.InitEntityObject(entity);
                int rowCount = mgr.DataObject.Insert();
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
                throw;
            }

        }

        public void SaveLastCredentialLoadedDate(CredentialToLoadToCpu entity)
        {
            try
            {
                var mgr = new CredentialToLoadToCpu_SaveLastCredentialLoadedDatePDSAManager
                {
                    Entity =
                    {
                        CpuUid = entity.CpuUid,
                        CredentialUid = entity.CredentialUid
                    }
                };
                if (entity.LastCredentialLoadedDate.HasValue)
                    mgr.Entity.LastCredentialLoadedDate = entity.LastCredentialLoadedDate.Value;
                mgr.Execute();
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
                throw;
            }
        }

        public void SaveLastCredentialLoadedDate(Guid cpuUid, byte[] credentialData, DateTimeOffset lastLoadedDate)
        {

            try
            {
                var mgr = new CredentialToLoadToCpu_SaveLastCredentialLoadedDateByCredentialDataPDSAManager()
                {
                    Entity = new EntityLayer.CredentialToLoadToCpu_SaveLastCredentialLoadedDateByCredentialDataPDSA()
                    {
                        CpuUid = cpuUid,
                        CredentialData = credentialData,
                        LastCredentialLoadedDate = lastLoadedDate
                    }
                };

                this.Log().InfoFormat($"SaveLastCredentialLoadedDate mgr:{mgr.ToString()}, mgr.DataObject = {mgr.DataObject}, mgr.Entity = {mgr.Entity}, {mgr.Entity.CpuUid}, {mgr.Entity?.CredentialData?.Length}, {mgr.Entity?.LastCredentialLoadedDate}");

                mgr.Execute();
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
                throw;
            }
        }

        public void SaveLastPersonalAccessGroupLoadedDate(CredentialToLoadToCpu entity)
        {
            try
            {
                var mgr = new CredentialToLoadToCpu_SaveLastPersonalAccessGroupLoadedDatePDSAManager
                {
                    Entity =
                    {
                        CpuUid = entity.CpuUid,
                        CredentialUid = entity.CredentialUid
                    }
                };
                if (entity.LastPersonalAccessGroupLoadedDate.HasValue)
                    mgr.Entity.LastPersonalAccessGroupLoadedDate = entity.LastPersonalAccessGroupLoadedDate.Value;
                mgr.Execute();
            }
            catch (PDSAValidationException ex)
            {
                DataValidationException dve = Converters.ConvertToDataValidationException(ex);
                throw dve;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
                throw;
            }


        }
    }
}

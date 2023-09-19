using GalaxySMS.Business.Entities;
using GalaxySMS.Data.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Data
{
    [Export(typeof(IPanelDataPacketLogRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class PanelDataPacketLogRepository : DataRepositoryBase<PanelDataPacketLog>, IPanelDataPacketLogRepository
    {
        protected override PanelDataPacketLog AddEntity(GalaxySMSContext entityContext, PanelDataPacketLog entity)
        {
            return entityContext.PanelDataPacketLogSet.Add(entity);
        }

        protected override PanelDataPacketLog UpdateEntity(GalaxySMSContext entityContext, PanelDataPacketLog entity)
        {
            return (from e in entityContext.PanelDataPacketLogSet
                    where e.EntityGuid == entity.EntityGuid
                    select e).FirstOrDefault();
        }

        protected override void DeleteEntity(GalaxySMSContext dbContext, PanelDataPacketLog entity)
        {
            //try
            //{
            //    gcsUserRequirementsPDSAManager mgr = new gcsUserRequirementsPDSAManager();
            //    mgr.InitEntityObject(entity);
            //    mgr.DataObject.Delete();
            //    //mgr.DataObject.DeleteByPK(id);
            //}
            //catch (Exception ex)
            //{
            //    this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//GcsUserSettingRepository::DeleteEntity", ex);
            //    throw;
            //}

            // Entity Framework 
            //            base.Remove(id);
        }
        protected override IEnumerable<PanelDataPacketLog> GetEntities(GalaxySMSContext entityContext)
        {
            return from e in entityContext.PanelDataPacketLogSet
                   select e;
        }

        protected override PanelDataPacketLog GetEntityByIntId(GalaxySMSContext entityContext, int id)
        {
            var query = (from e in entityContext.PanelDataPacketLogSet
                         where e.EntityIdentifier == id
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }
        protected override PanelDataPacketLog GetEntityByGuidId(GalaxySMSContext entityContext, Guid guid)
        {
            var query = (from e in entityContext.PanelDataPacketLogSet
                         where e.EntityGuid == guid
                         select e);

            var results = query.FirstOrDefault();

            return results;
        }
    }
}

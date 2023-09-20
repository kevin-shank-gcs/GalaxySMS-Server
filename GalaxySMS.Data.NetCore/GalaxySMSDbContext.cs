using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Business.Entities;
using GalaxySMS.Common.Interfaces;
using GalaxySMS.Data.NetCore.Helpers;
using GalaxySMS.Data.NetCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GalaxySMS.Data.NetCore
{
    public class GalaxySMSDbContext : DbContext, IGalaxySMSDbContext
    {
        private ICurrentUserService _currentUserService;

        public GalaxySMSDbContext()
        {
            
        }
        public GalaxySMSDbContext(DbContextOptions<GalaxySMSDbContext> options, ICurrentUserService currentUserService)
            : base(options)
        {
            _currentUserService = currentUserService;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=.\\SQL2019DEV;Database=GalaxySMS;Trusted_Connection=True;MultipleActiveResultSets=true");
            //optionsBuilder.UseSqlServer(
            //    "Data Source =.\\SQL2019DEV;Initial Catalog =GalaxySMS;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        public virtual int SaveChanges(string userId, bool saveAuditTrail)
        {
            if (saveAuditTrail)
                new AuditHelper(this).AddAuditLogs(_currentUserService?.UserId);

            var result = SaveChanges();
            return result;
        }

        public async Task<int> SaveChangesAsync(string userId, bool saveAuditTrail)
        {
            if (saveAuditTrail)
                new AuditHelper(this).AddAuditLogs(_currentUserService?.UserId);

            var result = await SaveChangesAsync();
            return result;
        }

        public void ClearAllChangeStates()
        {
            var changedEntries = this.ChangeTracker.Entries().Where(o => o.State != EntityState.Unchanged).ToList();
            foreach (var entry in changedEntries)
            {
                entry.State = EntityState.Unchanged;
            }
            changedEntries = this.ChangeTracker.Entries().Where(o => o.State != EntityState.Unchanged).ToList();
        }


        public DbSet<gcsAudit> Audit { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<MercScp> MercScps { get; set; }
    }
}

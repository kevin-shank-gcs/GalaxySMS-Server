using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Business.Entities;

namespace GalaxySMS.Data.NetCore.Interfaces
{
    public interface IAuditDbContext
    {
        DbSet<gcsAudit> Audit { get; set; }
        ChangeTracker ChangeTracker { get; }
    }
}

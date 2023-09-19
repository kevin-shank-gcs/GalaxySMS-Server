using GalaxySMS.Business.Entities;
using GalaxySMS.Data.NetCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GalaxySMS.Data.NetCore;

public interface IGalaxySMSDbContext : IAuditDbContext, IDisposable
{
    DbSet<Person> Persons { get; set; }
}
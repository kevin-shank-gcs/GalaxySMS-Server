using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;

namespace GalaxySMS.Data
{
    public class GalaxySMSContext : GalaxySMSDBContextBase
    {
        public GalaxySMSContext()
            : base("name=GalaxySMS")
        {
            Database.SetInitializer<GalaxySMSContext>(null);
            //this.Configuration.LazyLoadingEnabled = false;
        }

        //public DbSet<Account> AccountSet { get; set; }

        //public DbSet<PanelDataPacketLog> PanelDataPacketLogSet { get; set; }

        //public DbSet<gcsUserSetting> GcsUserSettingSet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Ignore<PropertyChangedEventHandler>();
            modelBuilder.Ignore<ExtensionDataObject>();
            modelBuilder.Ignore<IIdentifiableEntity>();

            //modelBuilder.Entity<gcsUserSetting>().ToTable("gcsUserSetting", schemaName: "GCS");


            //modelBuilder.Entity<gcsUserSetting>().HasKey<Guid>(e => e.UserSettingId).Ignore(e => e.EntityIdentifier).Ignore(e => e.EntityGuid);
        }
    }
}

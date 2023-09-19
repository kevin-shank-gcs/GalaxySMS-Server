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

        public DbSet<Account> AccountSet { get; set; }

        public DbSet<PanelDataPacketLog> PanelDataPacketLogSet { get; set; }

        public DbSet<gcsUser> GcsUserSet { get; set; }
        public DbSet<gcsUserSetting> GcsUserSettingSet { get; set; }
        //public DbSet<gcsUserRequirement> GcsUserRequirementsSet { get; set; }
        //public DbSet<gcsUserSecurityQuestion> GcsUserSecurityQuestionSet { get; set; }

        public DbSet<gcsUserApplicationEntity> GcsUserApplicationEntitySet { get; set; }

        public DbSet<gcsUserOldPassword> GcsUserOldPasswordSet { get; set; }

        public DbSet<gcsUserRole> GcsUserRoleSet { get; set; }
        public DbSet<gcsUserEntity> GcsUserEntitySet { get; set; }

        //public DbSet<gcsLanguage> GcsLanguageSet { get; set; }

        //public DbSet<gcsLog> GcsLogSet { get; set; }

        //public DbSet<gcsApplication> GcsApplicationSet { get; set; }

        //public DbSet<gcsApplicationSetting> GcsApplicationSettingSet { get; set; }

        //public DbSet<gcsEntity> GcsEntitySet { get; set; }

        //public DbSet<gcsEntityApplication> GcsEntityApplicationSet { get; set; }

        //public DbSet<gcsRole> GcsRoleSet { get; set; }

        //public DbSet<gcsRoleEntity> GcsRoleEntitySet { get; set; }

        //public DbSet<gcsMenuItem> GcsMenuItemSet { get; set; }

        //public DbSet<gcsReferenceTable> GcsReferenceTableSet { get; set; }

        //public DbSet<gcsResourceString> GcsResourceStringSet { get; set; }

        //public DbSet<gcsResourceStringLanguage> GcsResourceStringLanguageSet { get; set; }

        //public DbSet<gcsResourceImage> GcsResourceImageSet { get; set; }

        //public DbSet<gcsImageType> GcsImageTypeSet { get; set; }

        //public DbSet<gcsPermissionCategory> GcsPermissionCategorySet { get; set; }

        //public DbSet<gcsPermission> GcsPermissionSet { get; set; }

        //public DbSet<gcsRolePermission> GcsRolePermissionSet { get; set; }

        //public DbSet<gcsSecurityControl> GcsSecurityControlSet { get; set; }

        //public DbSet<gcsSerializedObject> GcsSerializedObjectSet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Ignore<PropertyChangedEventHandler>();
            modelBuilder.Ignore<ExtensionDataObject>();
            modelBuilder.Ignore<IIdentifiableEntity>();

            //modelBuilder.Entity<gcsEntity>().ToTable("gcsEntity", schemaName: "GCS");

            //modelBuilder.Entity<gcsLanguage>().ToTable("gcsLanguage", schemaName: "GCS");
            //modelBuilder.Entity<gcsApplication>().ToTable("gcsApplication", schemaName: "GCS");
            //modelBuilder.Entity<gcsRole>().ToTable("gcsRole", schemaName: "GCS");
            modelBuilder.Entity<gcsUser>().ToTable("gcsUser", schemaName: "GCS");
            //modelBuilder.Entity<gcsUserRequirement>().ToTable("gcsUserRequirements", schemaName: "GCS");
            modelBuilder.Entity<gcsUserSetting>().ToTable("gcsUserSetting", schemaName: "GCS");
            //modelBuilder.Entity<gcsApplicationSetting>().ToTable("gcsApplicationSetting", schemaName: "GCS");
            //modelBuilder.Entity<gcsEntityApplication>().ToTable("gcsEntityApplication", schemaName: "GCS");
            modelBuilder.Entity<gcsUserOldPassword>().ToTable("gcsUserOldPassword", schemaName: "GCS");
            modelBuilder.Entity<gcsUserEntity>().ToTable("gcsUserEntity", schemaName: "GCS");


            modelBuilder.Entity<gcsEntity>().HasKey<Guid>(e => e.EntityId).Ignore(e => e.EntityIdentifier).Ignore(e => e.EntityGuid).Ignore(e => e.UserRequirements);
            //modelBuilder.Entity<gcsLanguage>().HasKey<Guid>(e => e.LanguageId).Ignore(e => e.EntityIdentifier).Ignore(e => e.EntityGuid);
            //modelBuilder.Entity<gcsApplication>().HasKey<Guid>(e => e.ApplicationId).
            //    Ignore(e => e.EntityIdentifier).
            //    Ignore(e => e.EntityGuid);

            modelBuilder.Entity<gcsUser>().HasKey<Guid>(e => e.UserId).Ignore(e => e.EntityIdentifier).Ignore(e => e.EntityGuid);
            modelBuilder.Entity<gcsUserSetting>().HasKey<Guid>(e => e.UserSettingId).Ignore(e => e.EntityIdentifier).Ignore(e => e.EntityGuid);
            //modelBuilder.Entity<gcsUserRequirement>().HasKey<Guid>(e => e.UserRequirementsId).Ignore(e => e.EntityIdentifier).Ignore(e => e.EntityGuid);
            modelBuilder.Entity<gcsUserSecurityQuestion>().HasKey<Guid>(e => e.UserSecurityQuestionId).Ignore(e => e.EntityIdentifier).Ignore(e => e.EntityGuid);
            modelBuilder.Entity<gcsUserApplicationEntity>().HasKey<Guid>(e => e.UserApplicationEntityId).Ignore(e => e.EntityIdentifier).Ignore(e => e.EntityGuid);
            modelBuilder.Entity<gcsUserOldPassword>().HasKey<Guid>(e => e.UserOldPasswordId).Ignore(e => e.EntityIdentifier).Ignore(e => e.EntityGuid);
            modelBuilder.Entity<gcsUserRole>().HasKey<Guid>(e => e.UserRoleId).Ignore(e => e.EntityIdentifier).Ignore(e => e.EntityGuid);
            modelBuilder.Entity<gcsUserEntity>().HasKey<Guid>(e => e.UserEntityId).Ignore(e => e.EntityIdentifier).Ignore(e => e.EntityGuid);
            modelBuilder.Entity<gcsLog>().HasKey<Guid>(e => e.LogId).Ignore(e => e.EntityIdentifier).Ignore(e => e.EntityGuid);
            //modelBuilder.Entity<gcsApplicationSetting>().HasKey<Guid>(e => e.ApplicationSettingId).Ignore(e => e.EntityIdentifier).Ignore(e => e.EntityGuid);
            //modelBuilder.Entity<gcsEntityApplication>().HasKey<Guid>(e => e.EntityApplicationId).Ignore(e => e.EntityIdentifier).Ignore(e => e.EntityGuid);
            //modelBuilder.Entity<gcsRole>().HasKey<Guid>(e => e.RoleId).Ignore(e => e.EntityIdentifier).Ignore(e => e.EntityGuid);
            //modelBuilder.Entity<gcsRoleEntity>().HasKey<Guid>(e => e.RoleEntityId).Ignore(e => e.EntityIdentifier).Ignore(e => e.EntityGuid);
            //modelBuilder.Entity<gcsMenuItem>().HasKey<Guid>(e => e.MenuItemId).Ignore(e => e.EntityIdentifier).Ignore(e => e.EntityGuid);
            //modelBuilder.Entity<gcsReferenceTable>().HasKey<Guid>(e => e.ReferenceTableId).Ignore(e => e.EntityIdentifier).Ignore(e => e.EntityGuid);
            //modelBuilder.Entity<gcsResourceString>().HasKey<Guid>(e => e.ResourceId).Ignore(e => e.EntityIdentifier).Ignore(e => e.EntityGuid);
            //modelBuilder.Entity<gcsResourceStringLanguage>().HasKey<Guid>(e => e.ResourceStringLanguageId).Ignore(e => e.EntityIdentifier).Ignore(e => e.EntityGuid);
            //modelBuilder.Entity<gcsResourceImage>().HasKey<Guid>(e => e.ResourceImageId).Ignore(e => e.EntityIdentifier).Ignore(e => e.EntityGuid);
            //modelBuilder.Entity<gcsImageType>().HasKey<Guid>(e => e.ImageTypeId).Ignore(e => e.EntityIdentifier).Ignore(e => e.EntityGuid);
            //modelBuilder.Entity<gcsPermissionCategory>().HasKey<Guid>(e => e.PermissionCategoryId).Ignore(e => e.EntityIdentifier).Ignore(e => e.EntityGuid);
            //modelBuilder.Entity<gcsPermission>().HasKey<Guid>(e => e.PermissionId).Ignore(e => e.EntityIdentifier).Ignore(e => e.EntityGuid);
            //modelBuilder.Entity<gcsRolePermission>().HasKey<Guid>(e => e.RolePermissionId).Ignore(e => e.EntityIdentifier).Ignore(e => e.EntityGuid);
            //modelBuilder.Entity<gcsSecurityControl>().HasKey<Guid>(e => e.SecurityControlId).Ignore(e => e.EntityIdentifier).Ignore(e => e.EntityGuid);
            //modelBuilder.Entity<gcsSerializedObject>().HasKey<Guid>(e => e.SerializedObjectId).Ignore(e => e.EntityIdentifier).Ignore(e => e.EntityGuid);
        }
    }
}

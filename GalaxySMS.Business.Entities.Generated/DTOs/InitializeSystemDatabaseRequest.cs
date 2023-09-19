using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;

namespace GalaxySMS.Business.Entities
{
    public class InitializeSystemDatabaseRequest : EntityBase
    {
        public InitializeSystemDatabaseRequest()
        {
            Init();
        }


        private void Init()
        {
            InitializeSystemTables = false;
            this.Entities = new HashSet<gcsEntity>();
            this.Languages = new HashSet<gcsLanguage>();
            this.Applications = new HashSet<gcsApplication>();
            this.Users = new HashSet<gcsUser>();
            this.ApplicationAuditTypes = new HashSet<gcsApplicationAuditType>();
            this.SystemData = new gcsSystem();
        }

        public ICollection<gcsEntity> Entities { get; set; }
        public ICollection<gcsLanguage> Languages { get; set; }
        public ICollection<gcsApplication> Applications { get; set; }
        public ICollection<gcsUser> Users { get; set; }

        public ICollection<gcsApplicationAuditType> ApplicationAuditTypes { get; set; } 

        public gcsSystem SystemData { get; set; }

        public bool InitializeSystemTables { get; set; }
    }
}

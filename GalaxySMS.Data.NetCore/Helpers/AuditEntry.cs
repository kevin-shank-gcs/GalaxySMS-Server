using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Business.Entities;
using GCS.Core.Common.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;

namespace GalaxySMS.Data.NetCore.Helpers
{


    public class AuditEntry
    {
        public EntityEntry Entry { get; }
        public AuditType AuditType { get; set; }
        public string AuditUser { get; set; }
        public string TableName { get; set; }
        public Dictionary<string, object> KeyValues { get; } = new Dictionary<string, object>();
        public Dictionary<string, object> OldValues { get; } = new Dictionary<string, object>();
        public Dictionary<string, object> NewValues { get; } = new Dictionary<string, object>();
        public List<string> ChangedColumns { get; } = new List<string>();

        public AuditEntry(EntityEntry entry, string auditUser)
        {
            Entry = entry;
            AuditUser = auditUser;
            SetChanges(GetEntry());
        }

        private EntityEntry GetEntry()
        {
            return Entry;
        }

        private void SetChanges(EntityEntry entry)
        {
            TableName = entry.Metadata.GetTableName();
            //TableName = entry.Metadata.Relational().TableName;
            foreach (PropertyEntry property in Entry.Properties)
            {
                string propertyName = property.Metadata.Name;
                //string dbColumnName = property.Metadata.Relational().ColumnName;
                string dbColumnName = property.Metadata.GetColumnName();

                if (property.Metadata.IsPrimaryKey())
                {
                    KeyValues[propertyName] = property.CurrentValue;
                    continue;
                }

                switch (Entry.State)
                {
                    case EntityState.Added:
                        NewValues[propertyName] = property.CurrentValue;
                        AuditType = AuditType.Create;
                        break;

                    case EntityState.Deleted:
                        OldValues[propertyName] = property.OriginalValue;
                        AuditType = AuditType.Delete;
                        break;

                    case EntityState.Modified:
                        if (property.IsModified)
                        {
                            ChangedColumns.Add(dbColumnName);

                            OldValues[propertyName] = property.OriginalValue;
                            NewValues[propertyName] = property.CurrentValue;
                            AuditType = AuditType.Update;
                        }
                        break;
                }
            }
        }

        public gcsAudit ToAudit()
        {
            var audit = new gcsAudit();
            audit.AuditId = GuidUtilities.GenerateComb();// Guid.NewGuid();
            audit.InsertDate = DateTimeOffset.UtcNow;
            audit.OperationType = AuditType.ToString();
            audit.InsertName = AuditUser;
            audit.TableName = TableName;
            audit.PrimaryKeyColumn = JsonConvert.SerializeObject(KeyValues);
            audit.OriginalValue = OldValues.Count == 0 ? null : JsonConvert.SerializeObject(OldValues);
            audit.NewValue = NewValues.Count == 0 ? null : JsonConvert.SerializeObject(NewValues);
            audit.ColumnName = ChangedColumns.Count == 0 ? null : JsonConvert.SerializeObject(ChangedColumns);

            return audit;
        }
    }

}

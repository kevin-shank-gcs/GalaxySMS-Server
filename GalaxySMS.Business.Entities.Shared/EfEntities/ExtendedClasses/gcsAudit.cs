
using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
	public partial class gcsAudit
    {
        public gcsAudit()
        {
            Initialize();
        }

        public gcsAudit(gcsAudit e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(gcsAudit e)
        {
            Initialize();
            if (e == null)
                return;
            this.AuditId = e.AuditId;
            this.TransactionId = e.TransactionId;
            this.TableName = e.TableName;
            this.OperationType = e.OperationType;
            this.PrimaryKeyColumn = e.PrimaryKeyColumn;
            this.PrimaryKeyValue = e.PrimaryKeyValue;
            this.RecordTag = e.RecordTag;
            this.AuditXml = e.AuditXml;
            this.ColumnName = e.ColumnName;
            this.OriginalValue = e.OriginalValue;
            this.NewValue = e.NewValue;
            this.OriginalBinaryValue = e.OriginalBinaryValue;
            this.NewBinaryValue = e.NewBinaryValue;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;

        }

        public gcsAudit Clone(gcsAudit e)
        {
            return new gcsAudit(e);
        }

        public bool Equals(gcsAudit other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(gcsAudit other)
        {
            if (other == null)
                return false;

            if (other.AuditId != this.AuditId)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

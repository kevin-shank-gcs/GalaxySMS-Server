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
	public partial class gcsApplicationAuditType
    {
        public gcsApplicationAuditType()
        {
            Initialize();
        }

        public gcsApplicationAuditType(gcsApplicationAuditType e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.gcsApplicationAudits = new HashSet<gcsApplicationAudit>();
            this.ConcurrencyValue = 0;
        }

        public void Initialize(gcsApplicationAuditType e)
        {
            Initialize();
            if (e == null)
                return;
            this.ApplicationAuditTypeId = e.ApplicationAuditTypeId;
            this.Display = e.Display;
            this.DisplayResourceKey = e.DisplayResourceKey;
            this.Description = e.Description;
            this.DescriptionResourceKey = e.DescriptionResourceKey;
            this.TypeCode = e.TypeCode;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.gcsApplicationAudits = e.gcsApplicationAudits.ToCollection();

        }

        public gcsApplicationAuditType Clone(gcsApplicationAuditType e)
        {
            return new gcsApplicationAuditType(e);
        }

        public bool Equals(gcsApplicationAuditType other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(gcsApplicationAuditType other)
        {
            if (other == null)
                return false;

            if (other.ApplicationAuditTypeId != this.ApplicationAuditTypeId)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}


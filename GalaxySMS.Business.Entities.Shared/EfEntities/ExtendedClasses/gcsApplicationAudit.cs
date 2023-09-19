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
	public partial class gcsApplicationAudit
    {
        public gcsApplicationAudit()
        {
            Initialize();
        }

        public gcsApplicationAudit(gcsApplicationAudit e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(gcsApplicationAudit e)
        {
            Initialize();
            if (e == null)
                return;
            this.AuditId = e.AuditId;
            this.ApplicationAuditTypeId = e.ApplicationAuditTypeId;
            this.TransactionId = e.TransactionId;
            this.ApplicationId = e.ApplicationId;
            this.UserId = e.UserId;
            this.ApplicationName = e.ApplicationName;
            this.ApplicationVersion = e.ApplicationVersion;
            this.MachineName = e.MachineName;
            this.LoginName = e.LoginName;
            this.WindowsUserName = e.WindowsUserName;
            this.AuditDetails = e.AuditDetails;
            this.AuditXml = e.AuditXml;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;

        }

        public gcsApplicationAudit Clone(gcsApplicationAudit e)
        {
            return new gcsApplicationAudit(e);
        }

        public bool Equals(gcsApplicationAudit other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(gcsApplicationAudit other)
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

        public override string ToString()
        {
            return base.ToString();
        }
    }
}


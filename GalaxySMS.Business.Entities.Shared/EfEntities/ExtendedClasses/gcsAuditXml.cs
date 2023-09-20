
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
	public partial class gcsAuditXml
    {
        public gcsAuditXml()
        {
            Initialize();
        }

        public gcsAuditXml(gcsAuditXml e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(gcsAuditXml e)
        {
            Initialize();
            if (e == null)
                return;
            this.AuditId = e.AuditId;
            this.Type = e.Type;
            this.TableName = e.TableName;
            this.PKField = e.PKField;
            this.PKValue = e.PKValue;
            this.FieldName = e.FieldName;
            this.OldValue = e.OldValue;
            this.NewValue = e.NewValue;
            this.XmlText = e.XmlText;
            this.UpdateDateTime = e.UpdateDateTime;
            this.UserName = e.UserName;
            this.HostMachineName = e.HostMachineName;
            this.AppName = e.AppName;
            this.NTDomain = e.NTDomain;
            this.NTUserName = e.NTUserName;
            this.NETAddress = e.NETAddress;
            this.ApplicationUserId = e.ApplicationUserId;
            this.TransactionID = e.TransactionID;
            this.Description = e.Description;

        }

        public gcsAuditXml Clone(gcsAuditXml e)
        {
            return new gcsAuditXml(e);
        }

        public bool Equals(gcsAuditXml other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(gcsAuditXml other)
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

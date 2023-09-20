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
	public partial class gcsReferenceTable
    {
        public gcsReferenceTable()
        {
            Initialize();
        }

        public gcsReferenceTable(gcsReferenceTable e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.ConcurrencyValue = 0;
        }

        public void Initialize(gcsReferenceTable e)
        {
            Initialize();
            if (e == null)
                return;
            this.ReferenceTableId = e.ReferenceTableId;
            this.ApplicationId = e.ApplicationId;
            this.LanguageId = e.LanguageId;
            this.TableName = e.TableName;
            this.TableDisplayName = e.TableDisplayName;
            this.TableDisplayNameResourceKey = e.TableDisplayNameResourceKey;
            this.PrimaryKeyColumnName = e.PrimaryKeyColumnName;
            this.IsActive = e.IsActive;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public gcsReferenceTable Clone(gcsReferenceTable e)
        {
            return new gcsReferenceTable(e);
        }

        public bool Equals(gcsReferenceTable other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(gcsReferenceTable other)
        {
            if (other == null)
                return false;

            if (other.ReferenceTableId != this.ReferenceTableId)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

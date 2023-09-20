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
	public partial class BadgeTemplateEntityMap
    {
        public BadgeTemplateEntityMap()
        {
            Initialize();
        }

        public BadgeTemplateEntityMap(BadgeTemplateEntityMap e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.ConcurrencyValue = 0;
        }

        public void Initialize(BadgeTemplateEntityMap e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.BadgeTemplateEntityMapUid = e.BadgeTemplateEntityMapUid;
            this.BadgeTemplateUid = e.BadgeTemplateUid;
            this.EntityId = e.EntityId;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public bool IsAnythingDirty
        {
            get
            {
                //foreach( var o in InterfaceBoardSections)
                //{
                //	if (o.IsAnythingDirty == true)
                //		return true;
                //}
                return IsDirty;
            }
        }

        public BadgeTemplateEntityMap Clone(BadgeTemplateEntityMap e)
        {
            return new BadgeTemplateEntityMap(e);
        }

        public bool Equals(BadgeTemplateEntityMap other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(BadgeTemplateEntityMap other)
        {
            if (other == null)
                return false;

            if (other.BadgeTemplateEntityMapUid != this.BadgeTemplateEntityMapUid)
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

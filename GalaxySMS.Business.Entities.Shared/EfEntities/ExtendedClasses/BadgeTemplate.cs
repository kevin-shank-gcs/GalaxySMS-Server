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
	public partial class BadgeTemplate
    {
        public BadgeTemplate()
        {
            Initialize();
        }

        public BadgeTemplate(BadgeTemplate e)
        {
            Initialize(e);
            this.ConcurrencyValue = 0;
        }

        public void Initialize()
        {
            this.EntityIds = new HashSet<Guid>();
            this.MappedEntitiesPermissionLevels = new HashSet<EntityIdEntityMapPermissionLevel>();
        }

        public void Initialize(BadgeTemplate e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.BadgeTemplateUid = e.BadgeTemplateUid;
            this.EntityId = e.EntityId;
            this.BadgeSystemTypeUid = e.BadgeSystemTypeUid;
            this.TemplateName = e.TemplateName;
            this.Description = e.Description;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.TemplateId = e.TemplateId;
            if (e.EntityIds != null)
                this.EntityIds = e.EntityIds.ToCollection();
            if (e.MappedEntitiesPermissionLevels != null)
                this.MappedEntitiesPermissionLevels = e.MappedEntitiesPermissionLevels.ToCollection();

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

        public BadgeTemplate Clone(BadgeTemplate e)
        {
            return new BadgeTemplate(e);
        }

        public bool Equals(BadgeTemplate other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(BadgeTemplate other)
        {
            if (other == null)
                return false;

            if (other.BadgeTemplateUid != this.BadgeTemplateUid)
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

        public ListItemBase ToListItemBase()
        {
            return new ListItemBase()
            {
                Uid = BadgeTemplateUid,
                EntityId = EntityId,
                Name = TemplateId,
                KeyValue = BadgeTemplateUid.ToString(),
                Image = null
            };
        }
    }
}

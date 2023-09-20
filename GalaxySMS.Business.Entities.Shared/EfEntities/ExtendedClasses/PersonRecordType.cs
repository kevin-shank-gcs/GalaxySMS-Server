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
	public partial class PersonRecordType
    {
        public PersonRecordType()
        {
            Initialize();
        }

        public PersonRecordType(PersonRecordType e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.ConcurrencyValue = 0;
        }

        public void Initialize(PersonRecordType e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.PersonRecordTypeUid = e.PersonRecordTypeUid;
            this.EntityId = e.EntityId;
            this.DisplayResourceKey = e.DisplayResourceKey;
            this.DescriptionResourceKey = e.DescriptionResourceKey;
            this.Display = e.Display;
            this.Description = e.Description;
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

        public PersonRecordType Clone(PersonRecordType e)
        {
            return new PersonRecordType(e);
        }

        public bool Equals(PersonRecordType other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(PersonRecordType other)
        {
            if (other == null)
                return false;

            if (other.PersonRecordTypeUid != this.PersonRecordTypeUid)
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
                Uid = PersonRecordTypeUid,
                EntityId = EntityId,
                Name = Display,
                KeyValue = Display,
                Image = null
            };
        }
    }
}

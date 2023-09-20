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
	public partial class PersonListPropertyItem
    {
        public PersonListPropertyItem()
        {
            Initialize();
        }

        public PersonListPropertyItem(PersonListPropertyItem e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.ConcurrencyValue = 0;
        }

        public void Initialize(PersonListPropertyItem e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.PersonListPropertyItemUid = e.PersonListPropertyItemUid;
            this.PersonUid = e.PersonUid;
            this.UserDefinedPropertyUid = e.UserDefinedPropertyUid;
            this.UserDefinedListPropertyItemUid = e.UserDefinedListPropertyItemUid;
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

        public PersonListPropertyItem Clone(PersonListPropertyItem e)
        {
            return new PersonListPropertyItem(e);
        }

        public bool Equals(PersonListPropertyItem other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(PersonListPropertyItem other)
        {
            if (other == null)
                return false;

            if (other.PersonListPropertyItemUid != this.PersonListPropertyItemUid)
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

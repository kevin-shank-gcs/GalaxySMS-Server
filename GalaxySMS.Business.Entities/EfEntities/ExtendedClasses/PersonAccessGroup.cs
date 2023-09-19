using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class PersonAccessGroup
    {
        public PersonAccessGroup()
        {
            Initialize();
        }

        public PersonAccessGroup(PersonAccessGroup e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(PersonAccessGroup e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.PersonAccessGroupUid = e.PersonAccessGroupUid;
            this.AccessGroupUid = e.AccessGroupUid;
            this.PersonClusterPermissionUid = e.PersonClusterPermissionUid;
            this.OrderNumber = e.OrderNumber;
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

        public PersonAccessGroup Clone(PersonAccessGroup e)
        {
            return new PersonAccessGroup(e);
        }

        public bool Equals(PersonAccessGroup other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(PersonAccessGroup other)
        {
            if (other == null)
                return false;

            if (other.PersonAccessGroupUid != this.PersonAccessGroupUid)
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

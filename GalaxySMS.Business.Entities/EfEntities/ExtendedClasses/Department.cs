using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class Department
    {
        public Department()
        {
            Initialize();
        }

        public Department(Department e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(Department e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.DepartmentUid = e.DepartmentUid;
            this.EntityId = e.EntityId;
            this.DepartmentName = e.DepartmentName;
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

        public Department Clone(Department e)
        {
            return new Department(e);
        }

        public bool Equals(Department other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(Department other)
        {
            if (other == null)
                return false;

            if (other.DepartmentUid != this.DepartmentUid)
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

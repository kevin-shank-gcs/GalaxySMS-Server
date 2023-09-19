using System.Runtime.Serialization;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
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
            this.ConcurrencyValue = 0;
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
            this.TotalRowCount = e.TotalRowCount;

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

        public ListItemBase ToListItemBase()
        {
            return new ListItemBase()
            {
                Uid = DepartmentUid,
                EntityId = EntityId,
                Name = DepartmentName,
                KeyValue = DepartmentUid.ToString(),
                Image = null
            };
        }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int TotalRowCount { get; set; }

    }
}

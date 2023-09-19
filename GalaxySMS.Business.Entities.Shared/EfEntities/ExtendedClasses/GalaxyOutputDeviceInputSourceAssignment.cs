#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
    public partial class GalaxyOutputDeviceInputSourceAssignment
    {
        public GalaxyOutputDeviceInputSourceAssignment()
        {
            Initialize();
        }

        public GalaxyOutputDeviceInputSourceAssignment(GalaxyOutputDeviceInputSourceAssignment e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.ConcurrencyValue = 0;
        }

        public void Initialize(GalaxyOutputDeviceInputSourceAssignment e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.GalaxyOutputDeviceInputSourceAssignmentUid = e.GalaxyOutputDeviceInputSourceAssignmentUid;
            this.GalaxyOutputDeviceInputSourceUid = e.GalaxyOutputDeviceInputSourceUid;
            this.InputOutputGroupAssignmentUid = e.InputOutputGroupAssignmentUid;
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

        public GalaxyOutputDeviceInputSourceAssignment Clone(GalaxyOutputDeviceInputSourceAssignment e)
        {
            return new GalaxyOutputDeviceInputSourceAssignment(e);
        }

        public bool Equals(GalaxyOutputDeviceInputSourceAssignment other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(GalaxyOutputDeviceInputSourceAssignment other)
        {
            if (other == null)
                return false;

            if (other.GalaxyOutputDeviceInputSourceAssignmentUid != this.GalaxyOutputDeviceInputSourceAssignmentUid)
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

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
    public partial class GalaxyOutputInputSourceTriggerCondition
    {
        public GalaxyOutputInputSourceTriggerCondition()
        {
            Initialize();
        }

        public GalaxyOutputInputSourceTriggerCondition(GalaxyOutputInputSourceTriggerCondition e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.ConcurrencyValue = 0;
        }

        public void Initialize(GalaxyOutputInputSourceTriggerCondition e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.GalaxyOutputInputSourceTriggerConditionUid = e.GalaxyOutputInputSourceTriggerConditionUid;
            this.DisplayResourceKey = e.DisplayResourceKey;
            this.DescriptionResourceKey = e.DescriptionResourceKey;
            this.BinaryResourceUid = e.BinaryResourceUid;
            this.Display = e.Display;
            this.Description = e.Description;
            this.Code = e.Code;
            this.IsDefault = e.IsDefault;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.ResourceClassName = e.ResourceClassName;
            this.UniqueResourceName = e.UniqueResourceName;
            this.DisplayResourceName = e.DisplayResourceName;
            this.DescriptionResourceName = e.DescriptionResourceName;
            this.gcsBinaryResource = new gcsBinaryResource(e.gcsBinaryResource);

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

        public GalaxyOutputInputSourceTriggerCondition Clone(GalaxyOutputInputSourceTriggerCondition e)
        {
            return new GalaxyOutputInputSourceTriggerCondition(e);
        }

        public bool Equals(GalaxyOutputInputSourceTriggerCondition other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(GalaxyOutputInputSourceTriggerCondition other)
        {
            if (other == null)
                return false;

            if (other.GalaxyOutputInputSourceTriggerConditionUid != this.GalaxyOutputInputSourceTriggerConditionUid)
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

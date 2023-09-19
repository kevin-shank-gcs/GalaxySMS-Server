#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif

{
    public partial class GalaxyOutputInputSourceMode
    {
        public GalaxyOutputInputSourceMode()
        {
            Initialize();
        }

        public GalaxyOutputInputSourceMode(GalaxyOutputInputSourceMode e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            gcsBinaryResource = new gcsBinaryResource();
            this.ConcurrencyValue = 0;
        }

        public void Initialize(GalaxyOutputInputSourceMode e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.GalaxyOutputInputSourceModeUid = e.GalaxyOutputInputSourceModeUid;
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

        public GalaxyOutputInputSourceMode Clone(GalaxyOutputInputSourceMode e)
        {
            return new GalaxyOutputInputSourceMode(e);
        }

        public bool Equals(GalaxyOutputInputSourceMode other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(GalaxyOutputInputSourceMode other)
        {
            if (other == null)
                return false;

            if (other.GalaxyOutputInputSourceModeUid != this.GalaxyOutputInputSourceModeUid)
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

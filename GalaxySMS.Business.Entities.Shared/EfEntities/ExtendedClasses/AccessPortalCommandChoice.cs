#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
    public partial class AccessPortalCommandChoice
    {
        public AccessPortalCommandChoice()
        {
            Initialize();
        }

        public AccessPortalCommandChoice(AccessPortalCommandChoice e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.ConcurrencyValue = 0;
        }

        public void Initialize(AccessPortalCommandChoice e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.AccessPortalCommandChoiceUid = e.AccessPortalCommandChoiceUid;
            this.AccessPortalCommandUid = e.AccessPortalCommandUid;
            this.Display = e.Display;
            this.DisplayResourceKey = e.DisplayResourceKey;
            this.Description = e.Description;
            this.DescriptionResourceKey = e.DescriptionResourceKey;
            this.ChoiceTypeCode = e.ChoiceTypeCode;
            this.ApproxWaitTime = e.ApproxWaitTime;
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

        public AccessPortalCommandChoice Clone(AccessPortalCommandChoice e)
        {
            return new AccessPortalCommandChoice(e);
        }

        public bool Equals(AccessPortalCommandChoice other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(AccessPortalCommandChoice other)
        {
            if (other == null)
                return false;

            if (other.AccessPortalCommandChoiceUid != this.AccessPortalCommandChoiceUid)
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

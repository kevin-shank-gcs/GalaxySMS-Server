using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
	public partial class StringResourcesTableEntityBase
    {
        public StringResourcesTableEntityBase()
        {
            Initialize();
        }

        public StringResourcesTableEntityBase(StringResourcesTableEntityBase e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            base.Initialize();
            this.ConcurrencyValue = 0;
        }

        public void Initialize(StringResourcesTableEntityBase e)
        {
            base.Initialize(e);
            Initialize();
            if (e == null)
                return;
            this.Display = e.Display;
            this.DisplayResourceKey = e.DisplayResourceKey;
            this.Description = e.Description;
            this.DescriptionResourceKey = e.DescriptionResourceKey;
            this.ResourceClassName = e.ResourceClassName;
            this.DisplayResourceName = e.DisplayResourceName;
            this.DescriptionResourceName = e.DescriptionResourceName;
            this.UniqueResourceName = e.UniqueResourceName;
        }

        public StringResourcesTableEntityBase Clone(StringResourcesTableEntityBase e)
        {
            return new StringResourcesTableEntityBase(e);
        }

        public bool Equals(StringResourcesTableEntityBase other)
        {
            return base.Equals(other);
        }

        //public bool IsPrimaryKeyEqual(TableEntityBase other)
        //{
        //    if (other == null)
        //        return false;

        //    if (other.AreaUid != this.AreaUid)
        //        return false;
        //    return true;
        //}

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

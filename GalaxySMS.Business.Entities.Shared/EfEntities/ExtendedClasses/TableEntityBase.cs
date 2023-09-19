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
	public partial class TableEntityBase
	{
		public TableEntityBase()
		{
			Initialize();
		}

		public TableEntityBase(TableEntityBase e)
		{
			Initialize(e);
		}

		public void Initialize()
		{
            this.ConcurrencyValue = 0;
        }

        public void Initialize(TableEntityBase e)
		{
			Initialize();
			if (e == null)
				return;
			//this.InsertName = e.InsertName;
			//this.InsertDate = e.InsertDate;
			//this.UpdateName = e.UpdateName;
			//this.UpdateDate = e.UpdateDate;
			//this.ConcurrencyValue = e.ConcurrencyValue;
		}

		public TableEntityBase Clone(TableEntityBase e)
		{
			return new TableEntityBase(e);
		}

		public bool Equals(TableEntityBase other)
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

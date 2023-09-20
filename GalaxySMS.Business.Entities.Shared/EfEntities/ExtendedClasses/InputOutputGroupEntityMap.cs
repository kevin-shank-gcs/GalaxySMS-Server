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
	public partial class InputOutputGroupEntityMap
    {
        public InputOutputGroupEntityMap()
        {
            Initialize();
        }

        public InputOutputGroupEntityMap(InputOutputGroupEntityMap e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.ConcurrencyValue = 0;
        }

        public void Initialize(InputOutputGroupEntityMap e)
        {
            Initialize();
            if (e == null)
                return;
            this.InputOutputGroupEntityMapUid = e.InputOutputGroupEntityMapUid;
            this.InputOutputGroupUid = e.InputOutputGroupUid;
            this.EntityId = e.EntityId;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public InputOutputGroupEntityMap Clone(InputOutputGroupEntityMap e)
        {
            return new InputOutputGroupEntityMap(e);
        }

        public bool Equals(InputOutputGroupEntityMap other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(InputOutputGroupEntityMap other)
        {
            if (other == null)
                return false;

            if (other.InputOutputGroupEntityMapUid != this.InputOutputGroupEntityMapUid)
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
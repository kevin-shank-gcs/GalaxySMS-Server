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
	public partial class gcsSerializedObject
    {
        public gcsSerializedObject()
        {
            Initialize();
        }

        public gcsSerializedObject(gcsSerializedObject e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.ConcurrencyValue = 0;
        }

        public void Initialize(gcsSerializedObject e)
        {
            Initialize();
            if (e == null)
                return;
            this.SerializedObjectId = e.SerializedObjectId;
            this.ApplicationId = e.ApplicationId;
            this.Key = e.Key;
            this.SerializedObject = e.SerializedObject;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public gcsSerializedObject Clone(gcsSerializedObject e)
        {
            return new gcsSerializedObject(e);
        }

        public bool Equals(gcsSerializedObject other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(gcsSerializedObject other)
        {
            if (other == null)
                return false;

            if (other.SerializedObjectId != this.SerializedObjectId)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}

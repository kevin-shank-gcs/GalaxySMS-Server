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
    public partial class gcsLargeObjectStorage
    {
        public gcsLargeObjectStorage()
        {
            Initialize();
        }

        public gcsLargeObjectStorage(gcsLargeObjectStorage e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.ConcurrencyValue = 0;
        }

        public void Initialize(gcsLargeObjectStorage e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.Uid = e.Uid;
            this.EntityId = e.EntityId;
            this.UniqueTag = e.UniqueTag;
            this.DataType = e.DataType;
            this.TextData = e.TextData;
            this.FileStreamData = e.FileStreamData;
            this.BlobData = e.BlobData;
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

        public gcsLargeObjectStorage Clone(gcsLargeObjectStorage e)
        {
            return new gcsLargeObjectStorage(e);
        }

        public bool Equals(gcsLargeObjectStorage other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(gcsLargeObjectStorage other)
        {
            if (other == null)
                return false;

            if (other.Uid != this.Uid)
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

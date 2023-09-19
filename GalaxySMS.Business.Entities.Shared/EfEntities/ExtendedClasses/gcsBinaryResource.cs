// Move to partial class
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
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
	public partial class gcsBinaryResource
    {
        public gcsBinaryResource()
        {
            Initialize();
        }

        public gcsBinaryResource(gcsBinaryResource e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.ConcurrencyValue = 0;
        }

        public void Initialize(gcsBinaryResource e)
        {
            Initialize();
            if (e == null)
                return;
            this.BinaryResourceUid = e.BinaryResourceUid;
            this.DataType = e.DataType;
            this.Category = e.Category;
            this.Tag = e.Tag;
            this.BinaryResource = e.BinaryResource;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
        }

        public gcsBinaryResource Clone(gcsBinaryResource e)
        {
            return new gcsBinaryResource(e);
        }

        public bool Equals(gcsBinaryResource other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(gcsBinaryResource other)
        {
            if (other == null)
                return false;

            if (other.BinaryResourceUid != this.BinaryResourceUid)
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

#if NetCoreApi
#else
        [DataMember]
#endif

        public bool HasBeenModified { get; set; }
    }
}



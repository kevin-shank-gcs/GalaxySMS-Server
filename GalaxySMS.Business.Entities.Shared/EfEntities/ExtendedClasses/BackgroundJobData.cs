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
    public partial class BackgroundJobData
    {
        public BackgroundJobData()
        {
            Initialize();
        }

        public BackgroundJobData(BackgroundJobData e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(BackgroundJobData e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.BackgroundJobUid = e.BackgroundJobUid;
            this.Data = e.Data;

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

        public BackgroundJobData Clone(BackgroundJobData e)
        {
            return new BackgroundJobData(e);
        }

        public bool Equals(BackgroundJobData other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(BackgroundJobData other)
        {
            if (other == null)
                return false;

            if (other.BackgroundJobUid != this.BackgroundJobUid)
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

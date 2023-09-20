using System;
using System.Collections.Generic;
using GalaxySMS.Common.Enums;
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
    public partial class BackgroundJobStateChange
    {
        public BackgroundJobStateChange()
        {
            Initialize();
        }

        public BackgroundJobStateChange(BackgroundJobStateChange e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(BackgroundJobStateChange e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.BackgroundJobStateChangeUid = e.BackgroundJobStateChangeUid;
            this.BackgroundJobUid = e.BackgroundJobUid;
            this.ChangeDateTime = e.ChangeDateTime;
            this.State = e.State;
            this.Info = e.Info;

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

        public BackgroundJobStateChange Clone(BackgroundJobStateChange e)
        {
            return new BackgroundJobStateChange(e);
        }

        public bool Equals(BackgroundJobStateChange other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(BackgroundJobStateChange other)
        {
            if (other == null)
                return false;

            if (other.BackgroundJobStateChangeUid != this.BackgroundJobStateChangeUid)
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

        public BackgroundJobStateChangeInfo ToBackgroundJobStateChangeInfo()
        {
            var bgjsci = new BackgroundJobStateChangeInfo()
            {
                ChangeDateTime = this.ChangeDateTime,
                Info = this.Info,
                State = EnumExtensions.GetOne<BackgroundJobState>(this.State)
            };
            return bgjsci;

        }
    }
}

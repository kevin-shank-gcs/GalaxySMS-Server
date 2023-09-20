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
    public partial class BackgroundJob
    {
        public BackgroundJob()
        {
            Initialize();
        }

        public BackgroundJob(BackgroundJob e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.BackgroundJobStateChanges = new HashSet<BackgroundJobStateChange>();
            this.ConcurrencyValue = 0;
        }

        public void Initialize(BackgroundJob e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.BackgroundJobUid = e.BackgroundJobUid;
            this.UserId = e.UserId;
            this.State = e.State;
            this.JobType = e.JobType;
            this.DataType = e.DataType;
            this.DataItemUid = e.DataItemUid;
            this.EntityId = e.EntityId;
            this.ItemName = e.ItemName;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.BackgroundJobStateChanges = e.BackgroundJobStateChanges.ToCollection();
            this.BackgroundJobData = e.BackgroundJobData;

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

        public BackgroundJob Clone(BackgroundJob e)
        {
            return new BackgroundJob(e);
        }

        public bool Equals(BackgroundJob other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(BackgroundJob other)
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

        public BackgroundJobInfo ToBackgroundJobInfo()
        {
            var bgji = new BackgroundJobInfo()
            {
                JobId = this.BackgroundJobUid,
                DataType = this.DataType,
                DataItemUid = this.DataItemUid,
                JobType = EnumExtensions.GetOne<BackgroundJobOperationType>(this.JobType),
                State = EnumExtensions.GetOne<BackgroundJobState>(this.State),
                CreatedDateTime = this.InsertDate,
                LastUpdatedDateTime = this.UpdateDate,
                UserId = UserId,
                UserName = InsertName, 
                EntityId = EntityId,
                ItemName = ItemName
            };
            foreach (var stateChange in this.BackgroundJobStateChanges)
            {
                bgji.StateChanges.Add(stateChange.ToBackgroundJobStateChangeInfo());
            }
            return bgji;
        }
    }
}
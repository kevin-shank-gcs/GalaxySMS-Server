using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GCS.Core.Common.Core;
using GCS.Core.Common.Contracts;
using FluentValidation;
using System.Collections.ObjectModel;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Client.Entities
{
    public partial class BackgroundJob
    {
        public BackgroundJob() : base()
        {
            Initialize();
        }

        public BackgroundJob(BackgroundJob e) : base(e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            base.Initialize();
            this.BackgroundJobStateChanges = new HashSet<BackgroundJobStateChange>();
        }

        public void Initialize(BackgroundJob e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
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
    }
}

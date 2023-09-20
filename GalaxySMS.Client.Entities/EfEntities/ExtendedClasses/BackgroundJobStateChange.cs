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
    public partial class BackgroundJobStateChange
    {
        public BackgroundJobStateChange() : base()
        {
            Initialize();
        }

        public BackgroundJobStateChange(BackgroundJobStateChange e) : base(e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            base.Initialize();
        }

        public void Initialize(BackgroundJobStateChange e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.BackgroundJobStateChangeUid = e.BackgroundJobStateChangeUid;
            this.BackgroundJobUid = e.BackgroundJobUid;
            this.ChangeDateTime = e.ChangeDateTime;
            this.State = e.State;
            this.Info = e.Info;

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
    }
}

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
    public partial class BackgroundJobData
    {
        public BackgroundJobData() : base()
        {
            Initialize();
        }

        public BackgroundJobData(BackgroundJobData e) : base(e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            base.Initialize();
        }

        public void Initialize(BackgroundJobData e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.BackgroundJobUid = e.BackgroundJobUid;
            this.Data = e.Data;

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
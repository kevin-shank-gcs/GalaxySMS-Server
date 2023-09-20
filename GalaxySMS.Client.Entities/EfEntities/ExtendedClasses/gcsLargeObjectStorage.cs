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
    public partial class gcsLargeObjectStorage
    {
        public gcsLargeObjectStorage() : base()
        {
            Initialize();
        }

        public gcsLargeObjectStorage(gcsLargeObjectStorage e) : base(e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            base.Initialize();
        }

        public void Initialize(gcsLargeObjectStorage e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
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

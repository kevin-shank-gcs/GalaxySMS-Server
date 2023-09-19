using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
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
        }

        public void Initialize(gcsSerializedObject e)
        {
            Initialize();
            if (e == null)
                return;
            this.SerializedObjectId = e.SerializedObjectId;
            this.ApplicationId = e.ApplicationId;
            this.ObjectGuid = e.ObjectGuid;
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

using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class OutputDeviceEntityMap
    {
        public OutputDeviceEntityMap()
        {
            Initialize();
        }

        public OutputDeviceEntityMap(OutputDeviceEntityMap e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(OutputDeviceEntityMap e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.OutputDeviceEntityMapUid = e.OutputDeviceEntityMapUid;
            this.OutputDeviceUid = e.OutputDeviceUid;
            this.EntityId = e.EntityId;
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

        public OutputDeviceEntityMap Clone(OutputDeviceEntityMap e)
        {
            return new OutputDeviceEntityMap(e);
        }

        public bool Equals(OutputDeviceEntityMap other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(OutputDeviceEntityMap other)
        {
            if (other == null)
                return false;

            if (other.OutputDeviceEntityMapUid != this.OutputDeviceEntityMapUid)
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
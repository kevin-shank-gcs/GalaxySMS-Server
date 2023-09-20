using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class InputDeviceEntityMap
    {
        public InputDeviceEntityMap()
        {
            Initialize();
        }

        public InputDeviceEntityMap(InputDeviceEntityMap e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(InputDeviceEntityMap e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.InputDeviceEntityMapUid = e.InputDeviceEntityMapUid;
            this.InputDeviceUid = e.InputDeviceUid;
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

        public InputDeviceEntityMap Clone(InputDeviceEntityMap e)
        {
            return new InputDeviceEntityMap(e);
        }

        public bool Equals(InputDeviceEntityMap other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(InputDeviceEntityMap other)
        {
            if (other == null)
                return false;

            if (other.InputDeviceEntityMapUid != this.InputDeviceEntityMapUid)
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
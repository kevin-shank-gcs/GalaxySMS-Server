using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class GalaxyActivityEventType
    {
        public GalaxyActivityEventType()
        {
            Initialize();
        }

        public GalaxyActivityEventType(GalaxyActivityEventType e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(GalaxyActivityEventType e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.GalaxyActivityEventTypeUid = e.GalaxyActivityEventTypeUid;
            this.DisplayResourceKey = e.DisplayResourceKey;
            this.DescriptionResourceKey = e.DescriptionResourceKey;
            this.Display = e.Display;
            this.Description = e.Description;
            this.EventType = e.EventType;
            this.ForeColor = e.ForeColor;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.ResourceClassName = e.ResourceClassName;
            this.UniqueResourceName = e.UniqueResourceName;
            this.DisplayResourceName = e.DisplayResourceName;
            this.DescriptionResourceName = e.DescriptionResourceName;

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

        public GalaxyActivityEventType Clone(GalaxyActivityEventType e)
        {
            return new GalaxyActivityEventType(e);
        }

        public bool Equals(GalaxyActivityEventType other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(GalaxyActivityEventType other)
        {
            if (other == null)
                return false;

            if (other.GalaxyActivityEventTypeUid != this.GalaxyActivityEventTypeUid)
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

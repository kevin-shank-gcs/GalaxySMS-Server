using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class GalaxyPanelCommandAudit
    {
        public GalaxyPanelCommandAudit()
        {
            Initialize();
        }

        public GalaxyPanelCommandAudit(GalaxyPanelCommandAudit e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(GalaxyPanelCommandAudit e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.GalaxyPanelCommandAuditUid = e.GalaxyPanelCommandAuditUid;
            this.GalaxyPanelCommandUid = e.GalaxyPanelCommandUid;
            this.GalaxyPanelUid = e.GalaxyPanelUid;
            this.UserId = e.UserId;
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

        public GalaxyPanelCommandAudit Clone(GalaxyPanelCommandAudit e)
        {
            return new GalaxyPanelCommandAudit(e);
        }

        public bool Equals(GalaxyPanelCommandAudit other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(GalaxyPanelCommandAudit other)
        {
            if (other == null)
                return false;

            if (other.GalaxyPanelCommandAuditUid != this.GalaxyPanelCommandAuditUid)
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

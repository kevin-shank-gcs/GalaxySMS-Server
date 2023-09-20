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
    public partial class GalaxyInterfaceBoardSectionModeCommand
    {
        public GalaxyInterfaceBoardSectionModeCommand() : base()
        {
            Initialize();
        }

        public GalaxyInterfaceBoardSectionModeCommand(GalaxyInterfaceBoardSectionModeCommand e) : base(e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            base.Initialize();
        }

        public void Initialize(GalaxyInterfaceBoardSectionModeCommand e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.GalaxyInterfaceBoardSectionModeCommandUid = e.GalaxyInterfaceBoardSectionModeCommandUid;
            this.InterfaceBoardSectionModeUid = e.InterfaceBoardSectionModeUid;
            this.GalaxyInterfaceBoardSectionCommandUid = e.GalaxyInterfaceBoardSectionCommandUid;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public GalaxyInterfaceBoardSectionModeCommand Clone(GalaxyInterfaceBoardSectionModeCommand e)
        {
            return new GalaxyInterfaceBoardSectionModeCommand(e);
        }

        public bool Equals(GalaxyInterfaceBoardSectionModeCommand other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(GalaxyInterfaceBoardSectionModeCommand other)
        {
            if (other == null)
                return false;

            if (other.GalaxyInterfaceBoardSectionModeCommandUid != this.GalaxyInterfaceBoardSectionModeCommandUid)
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

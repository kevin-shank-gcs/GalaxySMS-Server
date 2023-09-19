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
    public partial class GalaxyInterfaceBoardSectionCommand
    {
        public GalaxyInterfaceBoardSectionCommand() : base()
        {
            Initialize();
        }

        public GalaxyInterfaceBoardSectionCommand(GalaxyInterfaceBoardSectionCommand e) : base(e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            base.Initialize();
        }

        public void Initialize(GalaxyInterfaceBoardSectionCommand e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.GalaxyInterfaceBoardSectionCommandUid = e.GalaxyInterfaceBoardSectionCommandUid;
            this.Display = e.Display;
            this.DisplayResourceKey = e.DisplayResourceKey;
            this.Description = e.Description;
            this.DescriptionResourceKey = e.DescriptionResourceKey;
            this.CommandCode = e.CommandCode;
            this.IsActive = e.IsActive;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public GalaxyInterfaceBoardSectionCommand Clone(GalaxyInterfaceBoardSectionCommand e)
        {
            return new GalaxyInterfaceBoardSectionCommand(e);
        }

        public bool Equals(GalaxyInterfaceBoardSectionCommand other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(GalaxyInterfaceBoardSectionCommand other)
        {
            if (other == null)
                return false;

            if (other.GalaxyInterfaceBoardSectionCommandUid != this.GalaxyInterfaceBoardSectionCommandUid)
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

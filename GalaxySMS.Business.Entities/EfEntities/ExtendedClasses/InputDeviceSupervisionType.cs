using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class InputDeviceSupervisionType
    {
        public InputDeviceSupervisionType()
        {
            Initialize();
        }

        public InputDeviceSupervisionType(InputDeviceSupervisionType e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.GalaxyInputDevices = new HashSet<GalaxyInputDevice>();
            this.InterfaceBoardSectionModeIds = new HashSet<Guid>();
        }

        public void Initialize(InputDeviceSupervisionType e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.InputDeviceSupervisionTypeUid = e.InputDeviceSupervisionTypeUid;
            this.Display = e.Display;
            this.DisplayResourceKey = e.DisplayResourceKey;
            this.Description = e.Description;
            this.DescriptionResourceKey = e.DescriptionResourceKey;
            this.BinaryResourceUid = e.BinaryResourceUid;
            this.HasSeriesResistor = e.HasSeriesResistor;
            this.HasParallelResistor = e.HasParallelResistor;
            this.IsNormalOpen = e.IsNormalOpen;
            this.TroubleShortThreshold = e.TroubleShortThreshold;
            this.NormalChangeThreshold = e.NormalChangeThreshold;
            this.TroubleOpenThreshold = e.TroubleOpenThreshold;
            this.AlternateVoltagesEnabled = e.AlternateVoltagesEnabled;
            this.AlternateTroubleShortThreshold = e.AlternateTroubleShortThreshold;
            this.AlternateNormalChangeThreshold = e.AlternateNormalChangeThreshold;
            this.AlternateTroubleOpenThreshold = e.AlternateTroubleOpenThreshold;
            this.DisplayOrder = e.DisplayOrder;
            this.IsDefault = e.IsDefault;
            this.IsActive = e.IsActive;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.GalaxyInputDevices = e.GalaxyInputDevices.ToCollection();
            this.ResourceClassName = e.ResourceClassName;
            this.UniqueResourceName = e.UniqueResourceName;
            this.DisplayResourceName = e.DisplayResourceName;
            this.DescriptionResourceName = e.DescriptionResourceName;
            this.gcsBinaryResource = new gcsBinaryResource(e.gcsBinaryResource);

             if (e.GalaxyInputDevices != null)
                this.GalaxyInputDevices = e.GalaxyInputDevices.ToCollection();

             if (e.InterfaceBoardSectionModeIds != null)
                this.InterfaceBoardSectionModeIds = e.InterfaceBoardSectionModeIds.ToCollection();
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

        public InputDeviceSupervisionType Clone(InputDeviceSupervisionType e)
        {
            return new InputDeviceSupervisionType(e);
        }

        public bool Equals(InputDeviceSupervisionType other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(InputDeviceSupervisionType other)
        {
            if (other == null)
                return false;

            if (other.InputDeviceSupervisionTypeUid != this.InputDeviceSupervisionTypeUid)
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
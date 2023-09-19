using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

using System.Runtime.Serialization;

#if NetCoreApi
    namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
    namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
    public partial class MercScpIdReport
    {
        public MercScpIdReport()
        {
            Initialize();
        }

        public MercScpIdReport(MercScpIdReport e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(MercScpIdReport e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.MercScpIdReportUid = e.MercScpIdReportUid;
            this.MacAddress = e.MacAddress;
            this.DriverSpcId = e.DriverSpcId;
            this.ScpId = e.ScpId;
            this.SerialNumber = e.SerialNumber;
            this.DeviceId = e.DeviceId;
            this.DeviceVersion = e.DeviceVersion;
            this.SoftwareRevisionMajor = e.SoftwareRevisionMajor;
            this.SoftwareRevisionMinor = e.SoftwareRevisionMinor;
            this.CumulativeBuildCount = e.CumulativeBuildCount;
            this.NeedsConfiguration = e.NeedsConfiguration;
            this.TlsStatus = e.TlsStatus;
            this.OemCode = e.OemCode;
            this.CurrentOperatingMode = e.CurrentOperatingMode;
            this.Input1State = e.Input1State;
            this.Input2State = e.Input2State;
            this.Input3State = e.Input3State;
            this.BioDb1Active = e.BioDb1Active;
            this.BioDb1Max = e.BioDb1Max;
            this.BioDb2Active = e.BioDb2Active;
            this.BioDb2Max = e.BioDb2Max;
            this.AssetDbActive = e.AssetDbActive;
            this.AssetDbMax = e.AssetDbMax;
            this.FirmwareAdvisory = e.FirmwareAdvisory;
            this.DipSwitchCurrent = e.DipSwitchCurrent;
            this.DipSwitchPowerUp = e.DipSwitchPowerUp;
            this.DbActiveRecords = e.DbActiveRecords;
            this.DbMaxSize = e.DbMaxSize;
            this.CurrentClock = e.CurrentClock;
            this.RamFree = e.RamFree;
            this.RamSize = e.RamSize;
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

        public MercScpIdReport Clone(MercScpIdReport e)
        {
            return new MercScpIdReport(e);
        }

        public bool Equals(MercScpIdReport other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(MercScpIdReport other)
        {
            if (other == null)
                return false;

            if (other.MercScpIdReportUid != this.MercScpIdReportUid)
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

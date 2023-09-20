using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;


#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
    public partial class GalaxyOutputDeviceInputSource
    {
        public GalaxyOutputDeviceInputSource()
        {
            Initialize();
        }

        public GalaxyOutputDeviceInputSource(GalaxyOutputDeviceInputSource e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.GalaxyOutputDeviceInputSourceAssignments = new HashSet<GalaxyOutputDeviceInputSourceAssignment>();
            this.GalaxyOutputDeviceInputSourceInputOutputGroups = new HashSet<GalaxyOutputDeviceInputSourceInputOutputGroup>();
            this.ConcurrencyValue = 0;
        }

        public void Initialize(GalaxyOutputDeviceInputSource e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.GalaxyOutputDeviceInputSourceUid = e.GalaxyOutputDeviceInputSourceUid;
            this.OutputDeviceUid = e.OutputDeviceUid;
            this.GalaxyOutputInputSourceTriggerConditionUid = e.GalaxyOutputInputSourceTriggerConditionUid;
            this.GalaxyOutputInputSourceModeUid = e.GalaxyOutputInputSourceModeUid;
            this.InputOutputGroupUid = e.InputOutputGroupUid;
            this.SourceNumber = e.SourceNumber;
            this.InputOutputGroupMode = e.InputOutputGroupMode;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.GalaxyOutputDeviceInputSourceAssignments = e.GalaxyOutputDeviceInputSourceAssignments.ToCollection();
            this.GalaxyOutputDeviceInputSourceInputOutputGroups = e.GalaxyOutputDeviceInputSourceInputOutputGroups.ToCollection();
            this.InputOutputGroupNumber = e.InputOutputGroupNumber;
            this.InputOutputGroupName = e.InputOutputGroupName;
        }

        public bool IsAnythingDirty
        {
            get
            {
                if( IsDirty)
                    return true;
                var dirtyAssignments = GalaxyOutputDeviceInputSourceAssignments.Any(o => o.IsAnythingDirty);
                if( dirtyAssignments)
                    return true;
                var dirtyIOGroups = GalaxyOutputDeviceInputSourceInputOutputGroups.Any(o => o.IsAnythingDirty);
                if( dirtyIOGroups)
                    return true;
                //foreach (var o in GalaxyOutputDeviceInputSourceAssignments)
                //{
                //    if (o.IsAnythingDirty == true)
                //        return true;
                //}
                return IsDirty;
            }
        }

        public GalaxyOutputDeviceInputSource Clone(GalaxyOutputDeviceInputSource e)
        {
            return new GalaxyOutputDeviceInputSource(e);
        }

        public bool Equals(GalaxyOutputDeviceInputSource other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(GalaxyOutputDeviceInputSource other)
        {
            if (other == null)
                return false;

            if (other.GalaxyOutputDeviceInputSourceUid != this.GalaxyOutputDeviceInputSourceUid)
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


#if NetCoreApi
#else
        [DataMember]
#endif
        public int InputOutputGroupNumber { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string InputOutputGroupName { get; set; }


    }
}

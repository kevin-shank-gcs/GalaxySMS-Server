using System;
using System.Collections.Generic;
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
    public partial class RoleCluster
    {
        public RoleCluster()
        {
            Initialize();
        }

        public RoleCluster(RoleCluster e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.RoleClusterPermissions = new HashSet<RoleClusterPermission>();
            this.AccessPortals = new HashSet<RoleAccessPortal>();
            this.InputOutputGroups = new HashSet<RoleInputOutputGroup>();
            this.InputDevices = new HashSet<RoleInputDevice>();
            this.OutputDevices = new HashSet<RoleOutputDevice>();
            this.ConcurrencyValue = 0;
        }

        public void Initialize(RoleCluster e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.RoleClusterUid = e.RoleClusterUid;
            this.RoleId = e.RoleId;
            this.ClusterUid = e.ClusterUid;
            this.IncludeAllAccessPortals = e.IncludeAllAccessPortals;
            this.IncludeAllInputOutputGroups = e.IncludeAllInputOutputGroups;
            this.IncludeAllInputDevices = e.IncludeAllInputDevices;
            this.IncludeAllOutputDevices = e.IncludeAllOutputDevices;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.RoleClusterPermissions = e.RoleClusterPermissions.ToCollection();
            this.ClusterName = e.ClusterName;
            if (e.AccessPortals != null)
                this.AccessPortals = e.AccessPortals.ToCollection();
            if (e.InputOutputGroups != null)
                this.InputOutputGroups = e.InputOutputGroups.ToCollection();
            if (e.InputDevices != null)
                this.InputDevices = e.InputDevices.ToCollection();
            if (e.OutputDevices != null)
                this.OutputDevices = e.OutputDevices.ToCollection();
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

        public RoleCluster Clone(RoleCluster e)
        {
            return new RoleCluster(e);
        }

        public bool Equals(RoleCluster other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(RoleCluster other)
        {
            if (other == null)
                return false;

            if (other.RoleClusterUid != this.RoleClusterUid)
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
        public string ClusterName { get; set; }

    }
}

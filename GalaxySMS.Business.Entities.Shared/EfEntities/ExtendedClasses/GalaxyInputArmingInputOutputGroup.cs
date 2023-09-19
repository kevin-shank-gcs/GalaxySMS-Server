using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
    public partial class GalaxyInputArmingInputOutputGroup
    {
        public GalaxyInputArmingInputOutputGroup()
        {
            Initialize();
        }

        public GalaxyInputArmingInputOutputGroup(GalaxyInputArmingInputOutputGroup e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.ConcurrencyValue = 0;
        }

        public void Initialize(GalaxyInputArmingInputOutputGroup e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.GalaxyInputArmingInputOutputGroupUid = e.GalaxyInputArmingInputOutputGroupUid;
            this.InputDeviceUid = e.InputDeviceUid;
            this.InputOutputGroupUid = e.InputOutputGroupUid;
            this.OrderNumber = e.OrderNumber;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.InputOutputGroupNumber = e.InputOutputGroupNumber;
            this.InputOutputGroupName = e.InputOutputGroupName;

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

        public GalaxyInputArmingInputOutputGroup Clone(GalaxyInputArmingInputOutputGroup e)
        {
            return new GalaxyInputArmingInputOutputGroup(e);
        }

        public bool Equals(GalaxyInputArmingInputOutputGroup other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(GalaxyInputArmingInputOutputGroup other)
        {
            if (other == null)
                return false;

            if (other.GalaxyInputArmingInputOutputGroupUid != this.GalaxyInputArmingInputOutputGroupUid)
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

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
    public partial class MercScpType
    {
        public MercScpType()
        {
            Initialize();
        }

        public MercScpType(MercScpType e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(MercScpType e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.MercScpTypeUid = e.MercScpTypeUid;
            this.Display = e.Display;
            this.DisplayResourceKey = e.DisplayResourceKey;
            this.Description = e.Description;
            this.DescriptionResourceKey = e.DescriptionResourceKey;
            this.TypeCode = e.TypeCode;
            this.TypeCodeValue = e.TypeCodeValue;
            this.MaxReaders = e.MaxReaders;
            this.MaxInputs = e.MaxInputs;
            this.MaxOutputs = e.MaxOutputs;
            this.MaxSio485Ports = e.MaxSio485Ports;
            this.OnboardReaders = e.OnboardReaders;
            this.OnboardInputs = e.OnboardInputs;
            this.OnboardOutputs = e.OnboardOutputs;
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

        public MercScpType Clone(MercScpType e)
        {
            return new MercScpType(e);
        }

        public bool Equals(MercScpType other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(MercScpType other)
        {
            if (other == null)
                return false;

            if (other.MercScpTypeUid != this.MercScpTypeUid)
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
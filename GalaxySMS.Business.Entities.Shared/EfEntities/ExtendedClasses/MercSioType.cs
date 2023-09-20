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
    public partial class MercSioType
    {
        public MercSioType()
        {
            Initialize();
        }

        public MercSioType(MercSioType e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(MercSioType e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.MercSioTypeUid = e.MercSioTypeUid;
            this.Display = e.Display;
            this.DisplayResourceKey = e.DisplayResourceKey;
            this.Description = e.Description;
            this.DescriptionResourceKey = e.DescriptionResourceKey;
            this.TypeCode = e.TypeCode;
            this.TypeCodeValue = e.TypeCodeValue;
            this.ModelNumber = e.ModelNumber;
            this.MaxReaders = e.MaxReaders;
            this.MaxInputs = e.MaxInputs;
            this.MaxOutputs = e.MaxOutputs;
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

        public MercSioType Clone(MercSioType e)
        {
            return new MercSioType(e);
        }

        public bool Equals(MercSioType other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(MercSioType other)
        {
            if (other == null)
                return false;

            if (other.MercSioTypeUid != this.MercSioTypeUid)
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
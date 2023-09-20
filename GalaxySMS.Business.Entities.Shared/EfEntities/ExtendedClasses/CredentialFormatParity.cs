using System;
using System.Collections.Generic;
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
	public partial class CredentialFormatParity
    {
        public CredentialFormatParity()
        {
            Initialize();
        }

        public CredentialFormatParity(CredentialFormatParity e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.ConcurrencyValue = 0;
        }

        public void Initialize(CredentialFormatParity e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.CredentialFormatParityUid = e.CredentialFormatParityUid;
            this.CredentialFormatUid = e.CredentialFormatUid;
            this.ParityType = e.ParityType;
            this.HexMask = e.HexMask;
            this.HexMaskUlong = e.HexMaskUlong;
            this.BitPosition = e.BitPosition;
            this.ComputeSequence = e.ComputeSequence;
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

        public CredentialFormatParity Clone(CredentialFormatParity e)
        {
            return new CredentialFormatParity(e);
        }

        public bool Equals(CredentialFormatParity other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(CredentialFormatParity other)
        {
            if (other == null)
                return false;

            if (other.CredentialFormatParityUid != this.CredentialFormatParityUid)
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

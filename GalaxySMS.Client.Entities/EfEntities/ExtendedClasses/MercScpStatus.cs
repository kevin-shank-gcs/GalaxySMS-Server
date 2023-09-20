// Move to partial class
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
    public partial class MercScpStatus
    {
        public MercScpStatus() : base()
        {
            Initialize();
        }

        public MercScpStatus(MercScpStatus e) : base(e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            base.Initialize();
        }

        public void Initialize(MercScpStatus e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.MercScpUid = e.MercScpUid;
            this.Online = e.Online;
            this.LastConnected = e.LastConnected;
            this.LastDisconnected = e.LastDisconnected;

        }

        public MercScpStatus Clone(MercScpStatus e)
        {
            return new MercScpStatus(e);
        }

        public bool Equals(MercScpStatus other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(MercScpStatus other)
        {
            if (other == null)
                return false;

            if (other.MercScpUid != this.MercScpUid)
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

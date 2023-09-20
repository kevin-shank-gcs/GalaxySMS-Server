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
    public partial class MercScpType
    {
        public MercScpType() : base()
        {
            Initialize();
        }

        public MercScpType(MercScpType e) : base(e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            base.Initialize();
        }

        public void Initialize(MercScpType e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
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

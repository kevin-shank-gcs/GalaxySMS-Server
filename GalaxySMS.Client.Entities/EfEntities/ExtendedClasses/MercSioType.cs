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
    public partial class MercSioType
    {
        public MercSioType() : base()
        {
            Initialize();
        }

        public MercSioType(MercSioType e) : base(e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            base.Initialize();
        }

        public void Initialize(MercSioType e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
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

using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class PersonOtisElevator
    {
        public PersonOtisElevator()
        {
            Initialize();
        }

        public PersonOtisElevator(PersonOtisElevator e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(PersonOtisElevator e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.PersonUid = e.PersonUid;
            this.SplitGroupOperation = e.SplitGroupOperation;
            this.CimOverride = e.CimOverride;
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

        public PersonOtisElevator Clone(PersonOtisElevator e)
        {
            return new PersonOtisElevator(e);
        }

        public bool Equals(PersonOtisElevator other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(PersonOtisElevator other)
        {
            if (other == null)
                return false;

            if (other.PersonUid != this.PersonUid)
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

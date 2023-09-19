using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class PersonLcdMessage
    {
        public PersonLcdMessage()
        {
            Initialize();
        }

        public PersonLcdMessage(PersonLcdMessage e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(PersonLcdMessage e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.PersonLcdMessageUid = e.PersonLcdMessageUid;
            this.PersonLcdMessageDisplayModeUid = e.PersonLcdMessageDisplayModeUid;
            this.PersonUid = e.PersonUid;
            this.Message = e.Message;
            this.StartingDate = e.StartingDate;
            this.EndingDate = e.EndingDate;
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

        public PersonLcdMessage Clone(PersonLcdMessage e)
        {
            return new PersonLcdMessage(e);
        }

        public bool Equals(PersonLcdMessage other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(PersonLcdMessage other)
        {
            if (other == null)
                return false;

            if (other.PersonLcdMessageUid != this.PersonLcdMessageUid)
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

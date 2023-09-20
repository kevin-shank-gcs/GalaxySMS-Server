using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class PersonNote
    {
        public PersonNote()
        {
            Initialize();
        }

        public PersonNote(PersonNote e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(PersonNote e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.PersonNoteUid = e.PersonNoteUid;
            this.PersonUid = e.PersonUid;
            this.NoteUid = e.NoteUid;
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

        public PersonNote Clone(PersonNote e)
        {
            return new PersonNote(e);
        }

        public bool Equals(PersonNote other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(PersonNote other)
        {
            if (other == null)
                return false;

            if (other.PersonNoteUid != this.PersonNoteUid)
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

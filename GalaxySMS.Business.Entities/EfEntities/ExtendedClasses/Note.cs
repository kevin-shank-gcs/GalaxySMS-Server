using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Business.Entities
{
    public partial class Note
    {
        public Note()
        {
            Initialize();
        }

        public Note(Note e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.AccessPortalAlertEvents = new HashSet<AccessPortalAlertEvent>();
        }

        public void Initialize(Note e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.NoteUid = e.NoteUid;
            this.Category = e.Category;
            this.NoteText = e.NoteText;
            this.Photo = e.Photo;
            this.Document = e.Document;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.AccessPortalAlertEvents = e.AccessPortalAlertEvents.ToCollection();
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

        public Note Clone(Note e)
        {
            return new Note(e);
        }

        public bool Equals(Note other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(Note other)
        {
            if (other == null)
                return false;

            if (other.NoteUid != this.NoteUid)
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
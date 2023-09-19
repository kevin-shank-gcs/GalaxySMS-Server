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
    public partial class OutputDeviceNote
    {
        public OutputDeviceNote() : base()
        {
            Initialize();
        }

        public OutputDeviceNote(OutputDeviceNote e) : base(e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            base.Initialize();
        }

        public void Initialize(OutputDeviceNote e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.OutputDeviceNoteUid = e.OutputDeviceNoteUid;
            this.OutputDeviceUid = e.OutputDeviceUid;
            this.NoteUid = e.NoteUid;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public OutputDeviceNote Clone(OutputDeviceNote e)
        {
            return new OutputDeviceNote(e);
        }

        public bool Equals(OutputDeviceNote other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(OutputDeviceNote other)
        {
            if (other == null)
                return false;

            if (other.OutputDeviceNoteUid != this.OutputDeviceNoteUid)
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

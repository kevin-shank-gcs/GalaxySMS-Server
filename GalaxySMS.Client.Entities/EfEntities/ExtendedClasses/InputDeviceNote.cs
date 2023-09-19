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
    public partial class InputDeviceNote
    {
        public InputDeviceNote() : base()
        {
            Initialize();
        }

        public InputDeviceNote(InputDeviceNote e) : base(e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            base.Initialize();
        }

        public void Initialize(InputDeviceNote e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.InputDeviceNoteUid = e.InputDeviceNoteUid;
            this.InputDeviceUid = e.InputDeviceUid;
            this.NoteUid = e.NoteUid;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;

        }

        public InputDeviceNote Clone(InputDeviceNote e)
        {
            return new InputDeviceNote(e);
        }

        public bool Equals(InputDeviceNote other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(InputDeviceNote other)
        {
            if (other == null)
                return false;

            if (other.InputDeviceNoteUid != this.InputDeviceNoteUid)
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

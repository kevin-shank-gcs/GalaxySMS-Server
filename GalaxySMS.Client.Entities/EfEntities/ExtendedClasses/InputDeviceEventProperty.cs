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
    public partial class InputDeviceEventProperty
    {
        public InputDeviceEventProperty() : base()
        {
            Initialize();
        }

        public InputDeviceEventProperty(InputDeviceEventProperty e) : base(e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            base.Initialize();
            Note = new Note() { Category = GalaxySMS.Common.Constants.NoteCategories.InputDeviceAlertEventInstructions };
        }

        public void Initialize(InputDeviceEventProperty e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.InputDeviceEventPropertiesUid = e.InputDeviceEventPropertiesUid;
            this.InputDeviceUid = e.InputDeviceUid;
            this.AudioBinaryResourceUid = e.AudioBinaryResourceUid;
            this.UserInstructionsNoteUid = e.UserInstructionsNoteUid;
            this.AcknowledgeTimeScheduleUid = e.AcknowledgeTimeScheduleUid;
            this.InputDeviceAlertEventTypeUid = e.InputDeviceAlertEventTypeUid;
            this.AcknowledgePriority = e.AcknowledgePriority;
            this.ResponseRequired = e.ResponseRequired;
            this.Tag = e.Tag;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            
            if (e.gcsBinaryResource != null)
                this.gcsBinaryResource = new gcsBinaryResource(e.gcsBinaryResource);
            if (e.InputDeviceAlertEventType != null)
                this.InputDeviceAlertEventType = new InputDeviceAlertEventType(e.InputDeviceAlertEventType);
            if (e.Note != null)
                this.Note = new Note(e.Note);
        }

        public InputDeviceEventProperty Clone(InputDeviceEventProperty e)
        {
            return new InputDeviceEventProperty(e);
        }

        public bool Equals(InputDeviceEventProperty other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(InputDeviceEventProperty other)
        {
            if (other == null)
                return false;

            if (other.InputDeviceEventPropertiesUid != this.InputDeviceEventPropertiesUid)
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

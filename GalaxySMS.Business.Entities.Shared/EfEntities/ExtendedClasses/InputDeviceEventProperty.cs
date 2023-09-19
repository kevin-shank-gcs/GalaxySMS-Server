using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
    public partial class InputDeviceEventProperty
    {
        public InputDeviceEventProperty()
        {
            Initialize();
        }

        public InputDeviceEventProperty(InputDeviceEventProperty e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            Note = new Note() { Category = GalaxySMS.Common.Constants.NoteCategories.InputDeviceAlertEventInstructions,
                ConcurrencyValue = 0};
            this.ConcurrencyValue = 0;

        }

        public void Initialize(InputDeviceEventProperty e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.InputDeviceEventPropertiesUid = e.InputDeviceEventPropertiesUid;
            this.InputDeviceUid = e.InputDeviceUid;
            this.AudioBinaryResourceUid = e.AudioBinaryResourceUid;
            this.ResponseInstructionsUid = e.ResponseInstructionsUid;
            this.AcknowledgeTimeScheduleUid = e.AcknowledgeTimeScheduleUid;
            this.InputDeviceAlertEventTypeUid = e.InputDeviceAlertEventTypeUid;
            this.AcknowledgePriority = e.AcknowledgePriority;
            this.IsActive = e.IsActive;
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

        public bool IsAnythingDirty
        {
            get
            {
                //foreach( var o in InterfaceBoardSections)
                //{
                //	if (o.IsAnythingDirty == true)
                //		return true;
                //}
                if (this.Note != null)
                    if( Note.IsAnythingDirty)
                        return true;
                return IsDirty;
            }
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

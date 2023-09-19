using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;

namespace GalaxySMS.Client.Entities
{
    [DataContract]
    public partial class InputOutputGroupAssignmentSource : ObjectBase
    {
		#region Private Fields
        private Guid _inputOutputGroupAssignmentUid;
        private Guid _inputOutputGroupUid;
        private short _offsetIndex;
        private string _deviceName;
        private string _eventType;
        private string _deviceType;
        private string _display;
		#endregion

		#region Public Properties

        [DataMember]
		public Guid InputOutputGroupAssignmentUid
		{
			get { return _inputOutputGroupAssignmentUid; }
			set
			{
				if (_inputOutputGroupAssignmentUid != value)
				{
                    _inputOutputGroupAssignmentUid = value;
					OnPropertyChanged(() => InputOutputGroupAssignmentUid, true);
				}
			}
		}

        [DataMember]
		public Guid InputOutputGroupUid
		{
			get { return _inputOutputGroupUid; }
			set
			{
				if (_inputOutputGroupUid != value)
				{
					_inputOutputGroupUid = value;
					OnPropertyChanged(() => InputOutputGroupUid, true);
				}
			}
		}


        [DataMember]
		public short OffsetIndex
		{
			get { return _offsetIndex; }
			set
			{
				if (_offsetIndex != value)
				{
					_offsetIndex = value;
					OnPropertyChanged(() => OffsetIndex, true);
				}
			}
		}


        [DataMember]
		public string DeviceName
		{
			get { return _deviceName; }
			set
			{
				if (_deviceName != value)
				{
                    _deviceName = value;
					OnPropertyChanged(() => DeviceName, true);
				}
			}
		}


        [DataMember]
		public string EventType
		{
			get { return _eventType; }
			set
			{
				if (_eventType != value)
				{
					_eventType = value;
					OnPropertyChanged(() => EventType, true);
				}
			}
		}


        [DataMember]
		public string DeviceType
		{
			get { return _deviceType; }
			set
			{
				if (_deviceType != value)
				{
                    _deviceType = value;
					OnPropertyChanged(() => DeviceType, true);
				}
			}
		}


        [DataMember]
		public string Display
		{
			get { return _display; }
			set
			{
				if (_display != value)
				{
                    _display = value;
					OnPropertyChanged(() => Display, true);
				}
			}
		}

		private bool _isSelected;

		[DataMember]
		public bool IsSelected
		{
			get { return _isSelected; }
			set
			{
				if (_isSelected != value)
				{
					_isSelected = value;
					OnPropertyChanged(() => IsSelected, true);
				}
			}
		}


        private bool _LocalIOGroup;

        [DataMember]
        public bool LocalIOGroup
        {
            get { return _LocalIOGroup; }
            set
            {
                if (_LocalIOGroup != value)
                {
                    _LocalIOGroup = value;
                    OnPropertyChanged(() => LocalIOGroup, true);
                }
            }
        }

        private Guid _galaxyPanelUid;

        [DataMember]
        public Guid GalaxyPanelUid
        {
            get { return _galaxyPanelUid; }
            set
            {
                if (_galaxyPanelUid != value)
                {
                    _galaxyPanelUid = value;
                    OnPropertyChanged(() => GalaxyPanelUid, true);
                }
            }
        }



        #endregion

    }
}

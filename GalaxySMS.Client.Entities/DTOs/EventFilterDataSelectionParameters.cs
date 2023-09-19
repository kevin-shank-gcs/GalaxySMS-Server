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
    public class EventFilterDataSelectionParameters:DtoObjectBase
    {
        private Guid _personUid;
        
        [DataMember]
        public Guid PersonUid
        {
            get { return _personUid; }
            set
            {
                if (_personUid != value)
                {
                    _personUid = value;
                    OnPropertyChanged(() => PersonUid, true);
                }
            }
        }

        private Guid _ClusterUid;

        [DataMember]
        public Guid ClusterUid  
        {
            get { return _ClusterUid; }
            set
            {
                if (_ClusterUid != value)
                {
                    _ClusterUid = value;
                    OnPropertyChanged(() => ClusterUid, true);
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


        private Guid _AccessPortalUid;

        [DataMember]
        public Guid AccessPortalUid
        {
            get { return _AccessPortalUid; }
            set
            {
                if (_AccessPortalUid != value)
                {
                    _AccessPortalUid = value;
                    OnPropertyChanged(() => AccessPortalUid, true);
                }
            }
        }
            
        private Guid _inputDeviceUid;

        [DataMember]
        public Guid InputDeviceUid
        {
            get { return _inputDeviceUid; }
            set
            {
                if (_inputDeviceUid != value)
                {
                    _inputDeviceUid = value;
                    OnPropertyChanged(() => InputDeviceUid, true);
                }
            }
        }


        private Guid _OutputDeviceUid;
        [DataMember]

        public Guid OutputDeviceUid
        {
            get { return _OutputDeviceUid; }
            set
            {
                if (_OutputDeviceUid != value)
                {
                    _OutputDeviceUid = value;
                    OnPropertyChanged(() => OutputDeviceUid, true);
                }
            }
        }


        private ICollection<Guid> _EventTypeUIds;

        [DataMember]
        public ICollection<Guid> EventTypeUIds
        {
            get { return _EventTypeUIds; }
            set
            {
                if (_EventTypeUIds != value)
                {
                    _EventTypeUIds = value;
                    OnPropertyChanged(() => EventTypeUIds, true);
                }
            }
        }

    }
}

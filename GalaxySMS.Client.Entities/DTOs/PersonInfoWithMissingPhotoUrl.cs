using GalaxySMS.Common.Enums;
using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Client.Entities
{
    [DataContract]
    public partial class PersonInfoWithMissingPhotoUrl: ObjectBase
    {
        private Guid _personUid;
        private Guid _entityId;
        private string _lastName;
        private string _firstName;

        [DataMember]
        public System.Guid PersonUid
        {
            get { return _personUid; }
            set
            {
                if (_personUid != value)
                {
                    _personUid = value;
                    OnPropertyChanged(() => PersonUid, false);
                }
            }
        }


        [DataMember]
        public System.Guid EntityId
        {
            get { return _entityId; }
            set
            {
                if (_entityId != value)
                {
                    _entityId = value;
                    OnPropertyChanged(() => EntityId, false);
                }
            }
        }

        [DataMember]
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    OnPropertyChanged(() => LastName, false);
                }
            }
        }

        [DataMember]
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    OnPropertyChanged(() => FirstName, false);
                }
            }
        }

    }
}

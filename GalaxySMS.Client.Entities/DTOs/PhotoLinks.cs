using GCS.Core.Common.Core;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace GalaxySMS.Client.Entities
{
    [DataContract]
    public class PhotoLinks : DbObjectBase
    {
        private string _tag;

        [DataMember]
        public string Tag
        {
            get { return _tag; }
            set
            {
                if (_tag != value)
                {
                    _tag = value;
                    OnPropertyChanged(() => Tag, false);
                }
            }
        }


        private bool _isDefault;

        [DataMember]
        public bool IsDefault
        {
            get { return _isDefault; }
            set
            {
                if (_isDefault != value)
                {
                    _isDefault = value;
                    OnPropertyChanged(() => IsDefault, false);
                }
            }
        }


        private string _UniqueFilename;

        [DataMember]
        public string UniqueFilename
        {
            get { return _UniqueFilename; }
            set
            {
                if (_UniqueFilename != value)
                {
                    _UniqueFilename = value;
                    OnPropertyChanged(() => UniqueFilename, false);
                }
            }
        }


        private string _Original;

        [DataMember]
        public string Original
        {
            get { return _Original; }
            set
            {
                if (_Original != value)
                {
                    _Original = value;
                    OnPropertyChanged(() => Original, false);
                }
            }
        }

        private string _Default;

        [DataMember]
        public string Default
        {
            get { return _Default; }
            set
            {
                if (_Default != value)
                {
                    _Default = value;
                    OnPropertyChanged(() => Default, false);
                }
            }
        }



        private string _Small;

        [DataMember]
        public string Small
        {
            get { return _Small; }
            set
            {
                if (_Small != value)
                {
                    _Small = value;
                    OnPropertyChanged(() => Small, false);
                }
            }
        }

        private ObservableCollection<PhotoLink> _others = new ObservableCollection<PhotoLink>();

        [DataMember]
        public ObservableCollection<PhotoLink> Others
        {
            get { return _others = new ObservableCollection<PhotoLink>(); }
            set
            {
                if (_others != value)
                {
                    _others = value;
                    OnPropertyChanged(() => Others, false);
                }
            }
        }


    }
}

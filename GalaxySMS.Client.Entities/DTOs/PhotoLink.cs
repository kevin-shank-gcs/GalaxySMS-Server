using GCS.Core.Common.Core;
using System.Runtime.Serialization;


namespace GalaxySMS.Client.Entities
{
    [DataContract]
    public class PhotoLink : DbObjectBase
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

        private string _url;

        [DataMember]

        public string Url
        {
            get { return _url; }
            set
            {
                if (_url != value)
                {
                    _url = value;
                    OnPropertyChanged(() => Url, false);
                }
            }
        }

    }
}

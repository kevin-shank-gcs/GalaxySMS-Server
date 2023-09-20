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
    public class CredentialLoadedData : ObjectBase
    {
        private byte[] _cardData;

        [DataMember]
        public byte[] CardData
        {
            get { return _cardData; }
            set
            {
                if (_cardData != value)
                {
                    _cardData = value;
                    OnPropertyChanged(() => CardData, false);
                }
            }
        }


    }
}

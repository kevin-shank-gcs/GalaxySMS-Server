using GalaxySMS.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Client.Entities
{
    [DataContract]
    public class PanelLoadDataReply : PanelMessageBase
    {
        private PanelLoadDataType _dataType;
        private int _ItemNumber;
        private string _ItemString;
        private string _Description;
        private Guid _ItemGuid;
        private PanelInterfaceBoardSectionType _BoardSectionType;
        private GalaxySMS.Common.Enums.CredentialReaderDataFormat _CredentialReaderDataFormat;
        private List<CredentialLoadedData> _credentialsLoaded;

        public PanelLoadDataReply() : base() { }

        public PanelLoadDataReply(PanelMessageBase b)
            : base(b)
        {
        }

        public PanelLoadDataReply(PanelLoadDataReply o)
            : base(o)
        {
            if (o != null)
            {
                DataType = o.DataType;
                Description = o.Description;
                ItemNumber = o.ItemNumber;
                ItemString = o.ItemString;
                ItemGuid = o.ItemGuid;
                BoardSectionType = o.BoardSectionType;
                CredentialReaderDataFormat = o.CredentialReaderDataFormat;

            }
        }

        [DataMember]
        public PanelLoadDataType DataType
        {
            get { return _dataType; }
            set
            {
                if (_dataType != value)
                {
                    _dataType = value;
                    OnPropertyChanged(() => DataType, false);
                }
            }
        }

        [DataMember]
        public int ItemNumber
        {
            get { return _ItemNumber; }
            set
            {
                if (_ItemNumber != value)
                {
                    _ItemNumber = value;
                    OnPropertyChanged(() => ItemNumber, false);
                }
            }
        }


        [DataMember]
        public string ItemString
        {
            get { return _ItemString; }
            set
            {
                if (_ItemString != value)
                {
                    _ItemString = value;
                    OnPropertyChanged(() => ItemString, false);
                }
            }
        }


        [DataMember]
        public Guid ItemGuid
        {
            get { return _ItemGuid; }
            set
            {
                if (_ItemGuid != value)
                {
                    _ItemGuid = value;
                    OnPropertyChanged(() => ItemGuid, false);
                }
            }
        }


        [DataMember]
        public string Description
        {
            get { return _Description; }
            set
            {
                if (_Description != value)
                {
                    _Description = value;
                    OnPropertyChanged(() => Description, false);
                }
            }
        }

        [DataMember]
        public PanelInterfaceBoardSectionType BoardSectionType
        {
            get { return _BoardSectionType; }
            set
            {
                if (_BoardSectionType != value)
                {
                    _BoardSectionType = value;
                    OnPropertyChanged(() => BoardSectionType, false);
                }
            }
        }


        [DataMember]
        public GalaxySMS.Common.Enums.CredentialReaderDataFormat CredentialReaderDataFormat
        {
            get { return _CredentialReaderDataFormat; }
            set
            {
                if (_CredentialReaderDataFormat != value)
                {
                    _CredentialReaderDataFormat = value;
                    OnPropertyChanged(() => CredentialReaderDataFormat, false);
                }
            }
        }


        [DataMember]
        public List<CredentialLoadedData> CredentialsLoaded
        {
            get { return _credentialsLoaded; }
            set
            {
                if (_credentialsLoaded != value)
                {
                    _credentialsLoaded = value;
                    OnPropertyChanged(() => CredentialsLoaded, false);
                }
            }
        }



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Common.Enums;

namespace GalaxySMS.Business.Entities
{
    [DataContract]
    public class PanelLoadDataReply : PanelMessageBase
    {
        public PanelLoadDataReply() : base()
        {
            CredentialsLoaded = new List<CredentialLoadedData>();
        }

        public PanelLoadDataReply(PanelMessageBase b)
            : base(b)
        {
            CredentialsLoaded = new List<CredentialLoadedData>();
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
                CredentialReaderDataFormat =o.CredentialReaderDataFormat;
                CredentialsLoaded = o.CredentialsLoaded;
            }

        }

        public PanelLoadDataReply(PanelLoadDataReply o, bool copyCredentialsLoaded)
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
                CredentialReaderDataFormat =o.CredentialReaderDataFormat;
                if(copyCredentialsLoaded)
                    CredentialsLoaded = o.CredentialsLoaded.ToList();
                else
                {
                    CredentialsLoaded = new List<CredentialLoadedData>();                 
                }
            }

        }

        [DataMember]
        public PanelLoadDataType DataType { get; set; }

        [DataMember]
        public int ItemNumber { get; set; }

        [DataMember]
        public string ItemString { get; set; }

        [DataMember]
        public Guid ItemGuid { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public PanelInterfaceBoardSectionType BoardSectionType { get; set; }

        [DataMember]
        public GalaxySMS.Common.Enums.CredentialReaderDataFormat CredentialReaderDataFormat { get; set; }

        [DataMember]
        public List<CredentialLoadedData> CredentialsLoaded {get;set;}
    }
    
}

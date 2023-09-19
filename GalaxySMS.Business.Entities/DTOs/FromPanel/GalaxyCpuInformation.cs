using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Business.Entities
{
    [DataContract]
    public class GalaxyCpuInformation : PanelMessageBase
    {
        private PanelInqueryReply panelInqueryReply;
        private CredentialCountReply cardCountReply;
        private LoggingStatusReply loggingStatusReply;
        private PanelBoardInformationCollection _boards;

        public GalaxyCpuInformation()
        {
            InqueryReply = new PanelInqueryReply();
            CardCountReply = new CredentialCountReply();
            LoggingStatusReply = new LoggingStatusReply();
            Boards = new PanelBoardInformationCollection();
            InstanceGuid = string.Empty;
        }

        public GalaxyCpuInformation(PanelMessageBase b) : base(b)
        {
            InqueryReply = new PanelInqueryReply();
            CardCountReply = new CredentialCountReply();
            LoggingStatusReply = new LoggingStatusReply();
            Boards = new PanelBoardInformationCollection();
            InstanceGuid = string.Empty;
        }

        public GalaxyCpuInformation(GalaxyCpuInformation galaxyCpuInfo)
            : base(galaxyCpuInfo)
        {
            if (galaxyCpuInfo != null)
            {
                InqueryReply = new PanelInqueryReply(galaxyCpuInfo.InqueryReply);
                CardCountReply = new CredentialCountReply(galaxyCpuInfo.CardCountReply);
                LoggingStatusReply = new LoggingStatusReply(galaxyCpuInfo.LoggingStatusReply);
                Boards = new PanelBoardInformationCollection(galaxyCpuInfo.Boards);

                InstanceGuid = galaxyCpuInfo.InstanceGuid;
            }
            else
            {
                InqueryReply = new PanelInqueryReply();
                CardCountReply = new CredentialCountReply();
                LoggingStatusReply = new LoggingStatusReply();
                Boards = new PanelBoardInformationCollection();
                InstanceGuid = string.Empty;
            }
        }

        [DataMember]
        public String InstanceGuid { get; set; }

        [DataMember]
        public PanelInqueryReply InqueryReply
        {
            get { return panelInqueryReply; }
            set
            {
                panelInqueryReply = value;
            }
        }

        [DataMember]
        public CredentialCountReply CardCountReply
        {
            get { return cardCountReply; }
            set
            {
                cardCountReply = value;
            }
        }

        [DataMember]
        public LoggingStatusReply LoggingStatusReply
        {
            get { return loggingStatusReply; }
            set
            {
                loggingStatusReply = value;
            }
        }

        [DataMember]
        public PanelBoardInformationCollection Boards { get => _boards; set => _boards = value; }
    }
}

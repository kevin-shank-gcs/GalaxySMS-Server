using System;
using System.Runtime.Serialization;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
#if NetCoreApi
#else
    [DataContract]
#endif

    public class GalaxyCpuInformation : CpuHardwareAddress//PanelMessageBase
    {
        private PanelInqueryReply panelInqueryReply;
        private CredentialCountReply cardCountReply;
        private LoggingStatusReply loggingStatusReply;
        private PanelBoardInformationCollection _boards;

        //private PanelInqueryReplyBasic panelInqueryReply;
        //private CredentialCountReplyBasic cardCountReply;
        //private LoggingStatusReplyBasic loggingStatusReply;
        //private PanelBoardInformationCollectionBasic _boards;

        public GalaxyCpuInformation()
        {
            InqueryReply = new PanelInqueryReply();
            CardCountReply = new CredentialCountReply();
            LoggingStatusReply = new LoggingStatusReply();
            Boards = new PanelBoardInformationCollection();
            //InqueryReply = new PanelInqueryReplyBasic();
            //CardCountReply = new CredentialCountReplyBasic();
            //LoggingStatusReply = new LoggingStatusReplyBasic();
            //Boards = new PanelBoardInformationCollectionBasic();
            InstanceGuid = string.Empty;
        }

        public GalaxyCpuInformation(CpuHardwareAddress b) : base(b)//PanelMessageBase b) : base(b)
        {
            InqueryReply = new PanelInqueryReply();
            CardCountReply = new CredentialCountReply();
            LoggingStatusReply = new LoggingStatusReply();
            Boards = new PanelBoardInformationCollection();
            //InqueryReply = new PanelInqueryReplyBasic();
            //CardCountReply = new CredentialCountReplyBasic();
            //LoggingStatusReply = new LoggingStatusReplyBasic();
            //Boards = new PanelBoardInformationCollectionBasic();
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
                //InqueryReply = new PanelInqueryReplyBasic(galaxyCpuInfo.InqueryReply);
                //CardCountReply = new CredentialCountReplyBasic(galaxyCpuInfo.CardCountReply);
                //LoggingStatusReply = new LoggingStatusReplyBasic(galaxyCpuInfo.LoggingStatusReply);
                //Boards = new PanelBoardInformationCollectionBasic(galaxyCpuInfo.Boards);

                InstanceGuid = galaxyCpuInfo.InstanceGuid;
            }
            else
            {
                InqueryReply = new PanelInqueryReply();
                CardCountReply = new CredentialCountReply();
                LoggingStatusReply = new LoggingStatusReply();
                Boards = new PanelBoardInformationCollection();
                //InqueryReply = new PanelInqueryReplyBasic();
                //CardCountReply = new CredentialCountReplyBasic();
                //LoggingStatusReply = new LoggingStatusReplyBasic();
                //Boards = new PanelBoardInformationCollectionBasic();
                InstanceGuid = string.Empty;
            }
        }
#if NetCoreApi
#else
        [DataMember]
#endif
        public String InstanceGuid { get; set; }
#if NetCoreApi
#else
        [DataMember]
#endif
        public PanelInqueryReply InqueryReply
        //public PanelInqueryReplyBasic InqueryReply
        {
            get { return panelInqueryReply; }
            set
            {
                panelInqueryReply = value;
            }
        }
#if NetCoreApi
#else
        [DataMember]
#endif
        public CredentialCountReply CardCountReply
        //public CredentialCountReplyBasic CardCountReply
        {
            get { return cardCountReply; }
            set
            {
                cardCountReply = value;
            }
        }
#if NetCoreApi
#else
        [DataMember]
#endif
        public LoggingStatusReply LoggingStatusReply
        //public LoggingStatusReplyBasic LoggingStatusReply
        {
            get { return loggingStatusReply; }
            set
            {
                loggingStatusReply = value;
            }
        }
#if NetCoreApi
#else
        [DataMember]
#endif
        public PanelBoardInformationCollection Boards { get => _boards; set => _boards = value; }
        //        public PanelBoardInformationCollectionBasic Boards { get => _boards; set => _boards = value; }
    }
}

using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using System.Runtime.Serialization;
using GalaxySMS.Business.Entities.Api.NetCore;
using GalaxySMS.Common.Enums;

namespace GalaxySMS.Api.Models.ResponseModels
{

    public class GalaxyCpuInformationResp : CpuHardwareAddressResp//PanelMessageBaseResp
    {
        //private PanelInqueryReplyResp panelInqueryReply;
        //private CredentialCountReplyResp cardCountReply;
        //private LoggingStatusReplyResp loggingStatusReply;
        //private PanelBoardInformationCollectionResp _boards;
        private PanelInqueryReplyBasicResp panelInqueryReply;
        private CredentialCountReplyBasicResp cardCountReply;
        private LoggingStatusReplyBasicResp loggingStatusReply;
        private PanelBoardInformationCollectionBasicResp _boards;

        public GalaxyCpuInformationResp()
        {
            //InqueryReply = new PanelInqueryReplyResp();
            //CardCountReply = new CredentialCountReplyResp();
            //LoggingStatusReply = new LoggingStatusReplyResp();
            //Boards = new PanelBoardInformationCollectionResp();
            InqueryReply = new PanelInqueryReplyBasicResp();
            CardCountReply = new CredentialCountReplyBasicResp();
            LoggingStatusReply = new LoggingStatusReplyBasicResp();
            Boards = new PanelBoardInformationCollectionBasicResp();
            InstanceGuid = string.Empty;
        }

        public GalaxyCpuInformationResp(PanelMessageBaseResp b) : base(b)
        {
            //InqueryReply = new PanelInqueryReplyResp();
            //CardCountReply = new CredentialCountReplyResp();
            //LoggingStatusReply = new LoggingStatusReplyResp();
            //Boards = new PanelBoardInformationCollectionResp();
            InqueryReply = new PanelInqueryReplyBasicResp();
            CardCountReply = new CredentialCountReplyBasicResp();
            LoggingStatusReply = new LoggingStatusReplyBasicResp();
            Boards = new PanelBoardInformationCollectionBasicResp();
            InstanceGuid = string.Empty;
        }

        public GalaxyCpuInformationResp(GalaxyCpuInformationResp galaxyCpuInfo)
            : base(galaxyCpuInfo)
        {
            if (galaxyCpuInfo != null)
            {
                //InqueryReply = new PanelInqueryReplyResp(galaxyCpuInfo.InqueryReply);
                //CardCountReply = new CredentialCountReplyResp(galaxyCpuInfo.CardCountReply);
                //LoggingStatusReply = new LoggingStatusReplyResp(galaxyCpuInfo.LoggingStatusReply);
                //Boards = new PanelBoardInformationCollectionResp(galaxyCpuInfo.Boards);
                InqueryReply = new PanelInqueryReplyBasicResp(galaxyCpuInfo.InqueryReply);
                CardCountReply = new CredentialCountReplyBasicResp(galaxyCpuInfo.CardCountReply);
                LoggingStatusReply = new LoggingStatusReplyBasicResp(galaxyCpuInfo.LoggingStatusReply);
                Boards = new PanelBoardInformationCollectionBasicResp(galaxyCpuInfo.Boards);

                InstanceGuid = galaxyCpuInfo.InstanceGuid;
            }
            else
            {
                //InqueryReply = new PanelInqueryReplyResp();
                //CardCountReply = new CredentialCountReplyResp();
                //LoggingStatusReply = new LoggingStatusReplyResp();
                //Boards = new PanelBoardInformationCollectionResp();
                InqueryReply = new PanelInqueryReplyBasicResp();
                CardCountReply = new CredentialCountReplyBasicResp();
                LoggingStatusReply = new LoggingStatusReplyBasicResp();
                Boards = new PanelBoardInformationCollectionBasicResp();
                InstanceGuid = string.Empty;
            }
        }
        public String InstanceGuid { get; set; }
//        public PanelInqueryReplyResp InqueryReply
        public PanelInqueryReplyBasicResp InqueryReply
        {
            get { return panelInqueryReply; }
            set
            {
                panelInqueryReply = value;
            }
        }
        //        public CredentialCountReplyResp CardCountReply
        public CredentialCountReplyBasicResp CardCountReply
        {
            get { return cardCountReply; }
            set
            {
                cardCountReply = value;
            }
        }
//        public LoggingStatusReplyResp LoggingStatusReply
        public LoggingStatusReplyBasicResp LoggingStatusReply
        {
            get { return loggingStatusReply; }
            set
            {
                loggingStatusReply = value;
            }
        }

//        public PanelBoardInformationCollectionResp Boards { get => _boards; set => _boards = value; }
        public PanelBoardInformationCollectionBasicResp Boards { get => _boards; set => _boards = value; }
    }
}

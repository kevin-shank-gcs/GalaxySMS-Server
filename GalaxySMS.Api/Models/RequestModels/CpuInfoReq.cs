using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Common.Enums;

namespace GalaxySMS.Api.Models.RequestModels
{
    public class CpuInfoReq : CpuHardwareAddressReq
    {
        public string SerialNumber { get; set; }
        public CredentialDataSize CardCodeFormat { get; set; }
        public String IpAddress { get; set; }
        public List<PanelBoardInformationReq> Boards { get; set; }

        public CpuInfoReq()
        {
            Boards = new List<PanelBoardInformationReq>();
        }

        public CpuInfoReq(CpuInfoReq c) : base(c)
        {
            IpAddress = c.IpAddress;
            SerialNumber = c.SerialNumber;
            CardCodeFormat = c.CardCodeFormat;
            if (c.Boards != null)
                Boards = c.Boards.ToList();
        }


    }


    //public class CpuConnectionInfoReq
    //{
    //    public GalaxyCpuInformationReq GalaxyCpuInformation { get; set; }

    //    //public String UniqueId { get { return string.Format("{0:D3}:{1:D3}:{2:D}", GalaxyCpuInformation.ClusterNumber, GalaxyCpuInformation.PanelNumber, GalaxyCpuInformation.CpuId); } }

    //    //public String Description { get; set; }
    //    public String RemoteIpEndpoint { get; set; }
    //    //public String LocalIpEndpoint { get; set; }
    //    //public Boolean IsConnected { get; set; }
    //    //public Boolean IsAuthenticated { get; set; }
    //    //public DateTimeOffset CreatedDateTime { get; set; }
    //    //public String SocketHandle { get; set; }
    //    //        public GalaxyCpuDatabaseInformation CpuDatabaseInformation { get; set; }

    //    public CpuConnectionInfoReq()
    //    {
    //        GalaxyCpuInformation = new GalaxyCpuInformationReq();
    //    }

    //    public CpuConnectionInfoReq(CpuConnectionInfoReq c)
    //    {
    //        //            Description = c.Description;
    //        RemoteIpEndpoint = c.RemoteIpEndpoint;
    //        //LocalIpEndpoint = c.LocalIpEndpoint;
    //        //IsConnected = c.IsConnected;
    //        //IsAuthenticated = c.IsAuthenticated;
    //        //CreatedDateTime = c.CreatedDateTime;
    //        //SocketHandle = c.SocketHandle;
    //        GalaxyCpuInformation = new GalaxyCpuInformationReq(c.GalaxyCpuInformation);
    //        //CpuDatabaseInformation = new GalaxyCpuDatabaseInformation(c.CpuDatabaseInformation);
    //    }


    //    //public Guid EntityGuid
    //    //{
    //    //    get
    //    //    {
    //    //        Guid g = Guid.Empty;
    //    //        if (GalaxyCpuInformation != null)
    //    //            Guid.TryParse(GalaxyCpuInformation.InstanceGuid, out g);
    //    //        return g;
    //    //    }
    //    //    set
    //    //    {
    //    //        Guid g = value;
    //    //    }
    //    //}
    //}

    //public class PanelInqueryReplyBasicReq
    //{
    //    public PanelInqueryReplyBasicReq()
    //    {
    //        //Version = new FirmwareVersion();
    //    }


    //    public PanelInqueryReplyBasicReq(PanelInqueryReplyBasicReq p)
    //    {
    //        //Version = new FirmwareVersion();
    //        if (p != null)
    //        {
    //            SerialNumber = p.SerialNumber;
    //            //ModelNumber = p.ModelNumber;
    //            //Version.Major = p.Version.Major;
    //            //Version.Minor = p.Version.Minor;
    //            //Version.LetterCode = p.Version.LetterCode;

    //            //LastRestartColdOrWarm = p.LastRestartColdOrWarm;
    //            //CrisisModeActive = p.CrisisModeActive;
    //            //UnacknowledgedActivityLogCount = p.UnacknowledgedActivityLogCount;
    //            //ActivityLoggingEnabled = p.ActivityLoggingEnabled;
    //            CardCodeFormat = p.CardCodeFormat;
    //            //OptionSwitches = p.OptionSwitches;
    //            //ZLinkConnected = p.ZLinkConnected;
    //        }
    //    }
    //    public string SerialNumber { get; set; }
    //    //public CpuModel ModelNumber { get; set; }
    //    //public FirmwareVersion Version { get; set; }
    //    //public CpuResetType LastRestartColdOrWarm { get; set; }
    //    //public CrisisModeState CrisisModeActive { get; set; }
    //    //public UInt32 UnacknowledgedActivityLogCount { get; set; }
    //    //public ActivityLoggingEnabledState ActivityLoggingEnabled { get; set; }
    //    public CredentialDataSize CardCodeFormat { get; set; }
    //    //public Byte OptionSwitches { get; set; }
    //    //public Byte ZLinkConnected { get; set; }

    //}

    //public class GalaxyCpuInformationReq : CpuHardwareAddressReq
    //{
    //    private PanelInqueryReplyBasicReq panelInqueryReply;
    //    private PanelBoardInformationCollectionReq _boards;

    //    //private PanelInqueryReplyBasic panelInqueryReply;
    //    //private CredentialCountReplyBasic cardCountReply;
    //    //private LoggingStatusReplyBasic loggingStatusReply;
    //    //private PanelBoardInformationCollectionBasic _boards;

    //    public GalaxyCpuInformationReq()
    //    {
    //        InqueryReply = new PanelInqueryReplyBasicReq();
    //        Boards = new PanelBoardInformationCollectionReq();
    //        //InqueryReply = new PanelInqueryReplyBasic();
    //        //CardCountReply = new CredentialCountReplyBasic();
    //        //LoggingStatusReply = new LoggingStatusReplyBasic();
    //        //Boards = new PanelBoardInformationCollectionBasic();
    //        //            InstanceGuid = string.Empty;
    //    }

    //    public GalaxyCpuInformationReq(CpuHardwareAddressReq b) : base(b)//PanelMessageBase b) : base(b)
    //    {
    //        InqueryReply = new PanelInqueryReplyBasicReq();
    //        Boards = new PanelBoardInformationCollectionReq();
    //        //InqueryReply = new PanelInqueryReplyBasic();
    //        //CardCountReply = new CredentialCountReplyBasic();
    //        //LoggingStatusReply = new LoggingStatusReplyBasic();
    //        //Boards = new PanelBoardInformationCollectionBasic();
    //        //            InstanceGuid = string.Empty;
    //    }

    //    public GalaxyCpuInformationReq(GalaxyCpuInformationReq galaxyCpuInfo)
    //        : base(galaxyCpuInfo)
    //    {
    //        if (galaxyCpuInfo != null)
    //        {
    //            InqueryReply = new PanelInqueryReplyBasicReq(galaxyCpuInfo.InqueryReply);
    //            Boards = new PanelBoardInformationCollectionReq(galaxyCpuInfo.Boards);

    //            //                InstanceGuid = galaxyCpuInfo.InstanceGuid;
    //        }
    //        else
    //        {
    //            InqueryReply = new PanelInqueryReplyBasicReq();
    //            Boards = new PanelBoardInformationCollectionReq();
    //            //                InstanceGuid = string.Empty;
    //        }
    //    }
    //    //public String InstanceGuid { get; set; }
    //    public PanelInqueryReplyBasicReq InqueryReply
    //    //public PanelInqueryReplyBasic InqueryReply
    //    {
    //        get { return panelInqueryReply; }
    //        set
    //        {
    //            panelInqueryReply = value;
    //        }
    //    }

    //    public PanelBoardInformationCollectionReq Boards { get => _boards; set => _boards = value; }
    //    //        public PanelBoardInformationCollectionBasic Boards { get => _boards; set => _boards = value; }
    //}

}


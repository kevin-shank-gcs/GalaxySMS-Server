using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Api.Models.RequestModels;
using GalaxySMS.Api.Support;
using GalaxySMS.Common.Enums;
using Swashbuckle.AspNetCore.Filters;
using ApiEntities = GalaxySMS.Business.Entities.Api.NetCore;

namespace GalaxySMS.Api.Support
{

    //public class SaveCpuConnectionInfoReqExamples : IExamplesProvider<SaveParams<CpuConnectionInfoReq>>
    //{
    //    SaveParams<CpuConnectionInfoReq> IExamplesProvider<SaveParams<CpuConnectionInfoReq>>.GetExamples()
    //    {
    //        var data = new CpuConnectionInfoReq()
    //        {
    //            GalaxyCpuInformation = new GalaxyCpuInformationReq()
    //            {
    //                InqueryReply = new PanelInqueryReplyBasicReq()
    //                {
    //                    CardCodeFormat = CredentialDataSize.Standard48Bits,
    //                    SerialNumber = "02000000"
    //                },
    //                ClusterUid = Guid.Empty,
    //                ClusterNumber = 1,
    //                PanelNumber = 1,
    //                CpuId = 1,
    //                CpuModel = CpuModel.Cpu635,
    //                Boards = new PanelBoardInformationCollectionReq()
    //            },
    //            RemoteIpEndpoint = "192.168.1.1",
    //        };

    //        Add 1 635 DRM
    //       var ib635Drm = new PanelBoardInformationReq()
    //       {
    //           BoardNumber = 1,
    //           BoardType = Common.Enums.GalaxyInterfaceBoardType.DualReaderInterfaceBoard635
    //       };

    //        data.GalaxyCpuInformation.Boards.Add(ib635Drm);

    //        Add 1 635 DSI
    //       var ib635Dsi = new PanelBoardInformationReq()
    //       {
    //           BoardNumber = 2,
    //           BoardType = Common.Enums.GalaxyInterfaceBoardType.DualSerialInterfaceBoard635,
    //       };
    //        data.GalaxyCpuInformation.Boards.Add(ib635Dsi);

    //        return new SaveParams<CpuConnectionInfoReq>()
    //        {
    //            Data = data,
    //        };
    //    }
    //}

    public class SaveCpuInfoReqExamples : IExamplesProvider<SaveParams<CpuInfoReq>>
    {
        SaveParams<CpuInfoReq> IExamplesProvider<SaveParams<CpuInfoReq>>.GetExamples()
        {
            var data = new CpuInfoReq()
            {
                SerialNumber = string.Empty,
                CardCodeFormat = CredentialDataSize.Standard48Bits,
                IpAddress = "192.168.1.1",
                ClusterUid = Guid.Empty,
                ClusterNumber = 1,
                PanelNumber = 1,
                CpuId = 1,
                CpuModel = CpuModel.Cpu635,
                Boards = new List<PanelBoardInformationReq>(),
            };

            // Add 1 635 DRM
            var ib635Drm = new PanelBoardInformationReq()
            {
                BoardNumber = 1,
                BoardType = Common.Enums.GalaxyInterfaceBoardType.DualReaderInterfaceBoard635
            };

            data.Boards.Add(ib635Drm);

            // Add 1 635 DSI
            var ib635Dsi = new PanelBoardInformationReq()
            {
                BoardNumber = 2,
                BoardType = Common.Enums.GalaxyInterfaceBoardType.DualSerialInterfaceBoard635,
            };
            data.Boards.Add(ib635Dsi);

            return new SaveParams<CpuInfoReq>()
            {
                Data = data,
            };
        }
    }
}


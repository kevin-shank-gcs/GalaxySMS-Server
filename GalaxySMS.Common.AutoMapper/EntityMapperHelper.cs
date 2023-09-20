using AutoMapper;
using BusinessEntities = GalaxySMS.Business.Entities;
using BusinessEntitiesStd = GalaxySMS.Business.Entities.NetStd2;
using ClientEntities = GalaxySMS.Client.Entities;

namespace GalaxySMS.Common.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BusinessEntities.AbaSettings, ClientEntities.AbaSettings>().ReverseMap();
            CreateMap<BusinessEntities.GalaxyPanel_GetAlertEventAcknowledgeData, ClientEntities.GalaxyPanel_GetAlertEventAcknowledgeData>().ReverseMap();
            CreateMap<BusinessEntities.GalaxyCpuDatabaseInformation, ClientEntities.GalaxyCpuDatabaseInformation>().ReverseMap();

            CreateMap<BusinessEntitiesStd.PanelBoardInformationCollection, ClientEntities.PanelBoardInformationCollection>().ReverseMap();
            CreateMap<BusinessEntitiesStd.PanelBoardInformation, ClientEntities.PanelBoardInformation>().ReverseMap();
            CreateMap<BusinessEntitiesStd.PanelActivityLogMessageBase, ClientEntities.PanelActivityLogMessageBase>().ReverseMap();
            CreateMap<BusinessEntitiesStd.PanelActivityLogMessage, ClientEntities.PanelActivityLogMessage>().ReverseMap();
            CreateMap<BusinessEntitiesStd.PanelCredentialActivityLogMessage, ClientEntities.PanelCredentialActivityLogMessage>().ReverseMap();
            CreateMap<BusinessEntitiesStd.FlashProgressMessage, ClientEntities.FlashProgressMessage>().ReverseMap();
            CreateMap<BusinessEntitiesStd.PanelMessageBase, ClientEntities.PanelMessageBase>().ReverseMap();
            CreateMap<BusinessEntitiesStd.BoardSectionNodeHardwareAddress, ClientEntities.BoardSectionNodeHardwareAddress>().ReverseMap();
            CreateMap<BusinessEntitiesStd.BoardSectionHardwareAddress, ClientEntities.BoardSectionHardwareAddress>().ReverseMap();
            CreateMap<BusinessEntitiesStd.BoardHardwareAddress, ClientEntities.BoardHardwareAddress>().ReverseMap();
            CreateMap<BusinessEntitiesStd.CpuHardwareAddress, ClientEntities.CpuHardwareAddress>().ReverseMap();
            CreateMap<BusinessEntitiesStd.ClusterAddress, ClientEntities.ClusterAddress>().ReverseMap();
            CreateMap<BusinessEntitiesStd.PanelLoadDataReply, ClientEntities.PanelLoadDataReply>().ReverseMap();
            CreateMap<BusinessEntitiesStd.CredentialLoadedData, ClientEntities.CredentialLoadedData>().ReverseMap();
            CreateMap<BusinessEntitiesStd.GalaxyRegion, ClientEntities.GalaxyRegion>().ReverseMap();
            CreateMap<BusinessEntitiesStd.GalaxySite, ClientEntities.GalaxySite>().ReverseMap();

            CreateMap<BusinessEntitiesStd.SerialChannelGalaxyInputModuleDataCollection, ClientEntities.SerialChannelGalaxyInputModuleDataCollection>().ReverseMap();
            CreateMap<BusinessEntitiesStd.SerialChannelGalaxyInputModuleData, ClientEntities.SerialChannelGalaxyInputModuleData>().ReverseMap();
            CreateMap<BusinessEntitiesStd.InputDeviceVoltagesReply, ClientEntities.InputDeviceVoltagesReply>().ReverseMap();
            CreateMap<BusinessEntitiesStd.SerialChannelGalaxyDoorModuleDataCollection, ClientEntities.SerialChannelGalaxyDoorModuleDataCollection>().ReverseMap();
            CreateMap<BusinessEntitiesStd.SerialChannelGalaxyDoorModuleData, ClientEntities.SerialChannelGalaxyDoorModuleData>().ReverseMap();
            CreateMap<BusinessEntitiesStd.FirmwareVersion, ClientEntities.FirmwareVersion>().ReverseMap();
            CreateMap<BusinessEntitiesStd.AccessPortalStatusReply, ClientEntities.AccessPortalStatusReply>().ReverseMap();
            CreateMap<BusinessEntitiesStd.GalaxySite, ClientEntities.GalaxySite>().ReverseMap();



        }
    }

    //public class EntityMapperHelper
    //{
    //    [Obsolete]
    //    public static void MapAllEntities()
    //    {
    //        Mapper.Initialize(cfg => cfg.AddProfile<MappingProfile>());
    //    }
    //}
}

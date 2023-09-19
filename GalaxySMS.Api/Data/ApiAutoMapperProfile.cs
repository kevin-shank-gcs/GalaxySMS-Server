using AutoMapper;
using Azure;
using GalaxySMS.Api.Models.RequestModels;
using GalaxySMS.Api.Models.ResponseModels;
using Microsoft.AspNetCore.Http;
using ApiEntities = GalaxySMS.Business.Entities.Api.NetCore;
using RequestModels = GalaxySMS.Api.Models.RequestModels;
using ResponseModels = GalaxySMS.Api.Models.ResponseModels;
using WcfEntities = GalaxySMS.Business.Entities;

namespace GalaxySMS.Api.Data
{
    public class ApiAutoMapperProfile : Profile
    {
        public ApiAutoMapperProfile()
        {
            this.CreateMap<WcfEntities.AccessAndAlarmControlPermissionsEditingData, ApiEntities.AccessAndAlarmControlPermissionsEditingData>().ReverseMap();
            this.CreateMap<WcfEntities.AccessAndAlarmControlPermissionsEditingData, ApiEntities.AccessAndAlarmControlPermissionsEditingDataBasic>().ReverseMap();
            this.CreateMap<WcfEntities.AccessAndAlarmControlPermissionsEditingData, ApiEntities.AccessAndAlarmControlPermissionsEditingDataMinimal>().ReverseMap();
            this.CreateMap<WcfEntities.AccessAndAlarmControlPermissionsEditingData, ResponseModels.AccessAndAlarmControlPermissionsEditingDataBasicResp>().ReverseMap();
            this.CreateMap<WcfEntities.AccessGroup, ApiEntities.AccessGroup>().ReverseMap();
            this.CreateMap<WcfEntities.AccessGroup, ApiEntities.AccessGroupBasic>().ReverseMap();
            this.CreateMap<WcfEntities.AccessGroup, ApiEntities.AccessGroupMinimal>().ReverseMap();
            this.CreateMap<WcfEntities.AccessGroup, ResponseModels.AccessGroupResp>().ReverseMap();
            this.CreateMap<WcfEntities.AccessGroupEx, ApiEntities.AccessGroupEx>().ReverseMap();
            this.CreateMap<WcfEntities.AccessGroupEx, ApiEntities.AccessGroupBasic>().ReverseMap();
            this.CreateMap<WcfEntities.AccessGroupCounts, ApiEntities.AccessGroupCounts>().ReverseMap();
            this.CreateMap<WcfEntities.AccessGroupPersonInfo, ApiEntities.AccessGroupPersonInfo>().ReverseMap();
            this.CreateMap<WcfEntities.AccessGroupEditingData, ApiEntities.AccessGroupEditingDataBasic>().ReverseMap();

            this.CreateMap<RequestModels.AccessGroupReq, WcfEntities.AccessGroup>().ReverseMap();
            this.CreateMap<RequestModels.AccessGroupPutReq, WcfEntities.AccessGroup>().ReverseMap();
            //this.CreateMap<WcfEntities.AccessGroupBasic, ApiEntities.AccessGroupBasic>().ReverseMap();
            this.CreateMap<WcfEntities.AccessGroupAccessPortal, ApiEntities.AccessGroupAccessPortal>().ReverseMap();
            this.CreateMap<WcfEntities.AccessGroupAccessPortal, ApiEntities.AccessGroupAccessPortalBasic>().ReverseMap();
            this.CreateMap<RequestModels.AccessGroupAccessPortalReq, WcfEntities.AccessGroupAccessPortal>().ReverseMap();
            this.CreateMap<RequestModels.AccessGroupAccessPortalPutReq, WcfEntities.AccessGroupAccessPortal>().ReverseMap();
            this.CreateMap<RequestModels.AccessGroupAccessPortalApPutReq, WcfEntities.AccessGroupAccessPortal>().ReverseMap();
            //this.CreateMap<WcfEntities.AccessGroupAccessPortalBasic, ApiEntities.AccessGroupAccessPortalBasic>().ReverseMap();

            this.CreateMap<WcfEntities.AccessGroupSelectionItem, ApiEntities.AccessGroupSelectionItem>().ReverseMap();
            this.CreateMap<WcfEntities.AccessGroupSelectionItem, ApiEntities.AccessGroupSelectionItemBasic>().ReverseMap();
            this.CreateMap<WcfEntities.AccessGroupSelectionItem, ApiEntities.AccessGroupSelectionItemMinimal>().ReverseMap();
            this.CreateMap<WcfEntities.AccessGroupSelectionItemBasic, ResponseModels.AccessGroupSelectionItemBasicResp>().ReverseMap();
            this.CreateMap<WcfEntities.AccessGroupSelectionItemBasic, ApiEntities.AccessGroupSelectionItemBasic>().ReverseMap();
            this.CreateMap<WcfEntities.AccessGroupSelectionItemBasic, ApiEntities.AccessGroupSelectionItemMinimal>().ReverseMap();
            this.CreateMap<WcfEntities.AccessGroupSelectionItemMinimal, ApiEntities.AccessGroupSelectionItemMinimal>().ReverseMap();

            this.CreateMap<WcfEntities.AccessPortal, ApiEntities.AccessPortal>().ReverseMap();
            this.CreateMap<WcfEntities.AccessPortal, ApiEntities.AccessPortalBasic>().ForMember(dest => dest.PhotoImage, opt => opt.MapFrom(src => src.gcsBinaryResource.BinaryResource));
            this.CreateMap<WcfEntities.AccessPortal, ApiEntities.AccessPortalMinimal>();//.ForMember(dest => dest.PhotoImage, opt => opt.MapFrom(src => src.gcsBinaryResource.BinaryResource));
            this.CreateMap<WcfEntities.AccessPortal, ResponseModels.AccessPortalResp>().ReverseMap();
            this.CreateMap<WcfEntities.AccessPortal, RequestModels.AccessPortalPutReq>().ReverseMap();
            this.CreateMap<WcfEntities.AccessPortal, ApiEntities.AccessPortalSimpleItem>().ReverseMap();

            this.CreateMap<WcfEntities.AccessPortalAlertEvent, ApiEntities.AccessPortalAlertEvent>().ReverseMap();
            this.CreateMap<WcfEntities.AccessPortalAlertEvent, ApiEntities.AccessPortalAlertEventBasic>().ReverseMap();
            this.CreateMap<RequestModels.AccessPortalAlertEventPutReq, WcfEntities.AccessPortalAlertEvent>().ReverseMap();
            this.CreateMap<RequestModels.AccessPortalAlertEventReq, WcfEntities.AccessPortalAlertEvent>().ReverseMap();
            this.CreateMap<WcfEntities.AccessPortalAlertEventType, ApiEntities.AccessPortalAlertEventType>().ReverseMap();
            this.CreateMap<WcfEntities.AccessPortalAlertEventType, ApiEntities.AccessPortalAlertEventTypeBasic>().ReverseMap();
            this.CreateMap<RequestModels.AccessPortalAlertEventTypeReq, WcfEntities.AccessPortalAlertEventType>().ReverseMap();

            this.CreateMap<WcfEntities.AccessPortalArea, ApiEntities.AccessPortalArea>().ReverseMap();
            this.CreateMap<WcfEntities.AccessPortalArea, ApiEntities.AccessPortalAreaBasic>().ReverseMap();
            this.CreateMap<RequestModels.AccessPortalAreaPutReq, WcfEntities.AccessPortalArea>().ReverseMap();
            this.CreateMap<RequestModels.AccessPortalAreaReq, WcfEntities.AccessPortalArea>().ReverseMap();
            this.CreateMap<WcfEntities.AccessPortalAreaType, ApiEntities.AccessPortalAreaType>().ReverseMap();
            this.CreateMap<WcfEntities.AccessPortalAreaType, ApiEntities.AccessPortalAreaTypeBasic>().ReverseMap();

            this.CreateMap<WcfEntities.AccessPortalAuxiliaryOutput, ApiEntities.AccessPortalAuxiliaryOutput>().ReverseMap();
            this.CreateMap<WcfEntities.AccessPortalAuxiliaryOutput, ApiEntities.AccessPortalAuxiliaryOutputBasic>()
                .ForMember(dest => dest.ActivationDelayInCs, opt => opt.MapFrom(src => src.ActivationDelay))
                .ReverseMap();
            this.CreateMap<RequestModels.AccessPortalAuxiliaryOutputPutReq, WcfEntities.AccessPortalAuxiliaryOutput>()
                .ForMember(dest => dest.ActivationDelay, opt => opt.MapFrom(src => src.ActivationDelayInCs))
                .ReverseMap();
            this.CreateMap<RequestModels.AccessPortalAuxiliaryOutputReq, WcfEntities.AccessPortalAuxiliaryOutput>()
                .ForMember(dest => dest.ActivationDelay, opt => opt.MapFrom(src => src.ActivationDelayInCs))
                .ReverseMap();

            this.CreateMap<WcfEntities.AccessPortalAuxiliaryOutputMode, ApiEntities.AccessPortalAuxiliaryOutputMode>().ReverseMap();
            this.CreateMap<WcfEntities.AccessPortalAuxiliaryOutputMode, ApiEntities.AccessPortalAuxiliaryOutputModeBasic>().ReverseMap();
            this.CreateMap<WcfEntities.AccessPortalAuxiliaryOutputModeEditorData, ApiEntities.AccessPortalAuxiliaryOutputModeEditorData>().ReverseMap();
            this.CreateMap<WcfEntities.AccessPortalCommand, ApiEntities.AccessPortalCommand>().ReverseMap();
            this.CreateMap<WcfEntities.AccessPortalCommand, ApiEntities.AccessPortalCommandBasic>().ReverseMap();
            this.CreateMap<WcfEntities.AccessPortalCommandBasic, ApiEntities.AccessPortalCommandBasic>().ReverseMap();
            this.CreateMap<WcfEntities.AccessPortalCommandAction, ApiEntities.AccessPortalCommandAction>().ReverseMap();

            this.CreateMap<RequestModels.AccessPortalCommandActionReq, WcfEntities.AccessPortalCommandAction>().ReverseMap();

            this.CreateMap<WcfEntities.AccessPortalContactSupervisionType, ApiEntities.AccessPortalContactSupervisionType>().ReverseMap();
            this.CreateMap<WcfEntities.AccessPortalContactSupervisionType, ApiEntities.AccessPortalContactSupervisionTypeBasic>().ForMember(dest => dest.BinaryResource, opt => opt.MapFrom(src => src.gcsBinaryResource.BinaryResource));

            this.CreateMap<WcfEntities.AccessPortalDeferToServerBehavior, ApiEntities.AccessPortalDeferToServerBehavior>().ReverseMap();
            this.CreateMap<WcfEntities.AccessPortalDeferToServerBehavior, ApiEntities.AccessPortalDeferToServerBehaviorBasic>().ReverseMap();
            this.CreateMap<WcfEntities.AccessPortalDeferToServerBehavior, ResponseModels.AccessPortalDeferToServerBehaviorBasicResp>().ReverseMap();

            this.CreateMap<WcfEntities.AccessPortalElevatorControlType, ApiEntities.AccessPortalElevatorControlType>().ReverseMap();
            this.CreateMap<WcfEntities.AccessPortalElevatorControlType, ApiEntities.AccessPortalElevatorControlTypeBasic>().ForMember(dest => dest.BinaryResource, opt => opt.MapFrom(src => src.gcsBinaryResource.BinaryResource));

            this.CreateMap<WcfEntities.AccessPortalGalaxyCommonEditingData, ApiEntities.AccessPortalGalaxyCommonEditingData>().ReverseMap();
            this.CreateMap<WcfEntities.AccessPortalGalaxyCommonEditingData, ApiEntities.AccessPortalGalaxyCommonEditingDataBasic>().ReverseMap();
            this.CreateMap<WcfEntities.AccessPortalGalaxyPanelSpecificEditingData, ApiEntities.AccessPortalGalaxyPanelSpecificEditingData>().ReverseMap();
            this.CreateMap<WcfEntities.AccessPortalGalaxyPanelSpecificEditingData, ApiEntities.AccessPortalGalaxyPanelSpecificEditingDataBasic>().ReverseMap();

            this.CreateMap<WcfEntities.AccessPortalGalaxyHardwareAddress, ApiEntities.AccessPortalGalaxyHardwareAddress>().ReverseMap();
            this.CreateMap<WcfEntities.AccessPortalGalaxyHardwareAddress, ApiEntities.AccessPortalGalaxyHardwareAddressBasic>().ReverseMap();
            this.CreateMap<WcfEntities.AccessPortalLastUsageData, ApiEntities.AccessPortalLastUsageData>().ReverseMap();

            this.CreateMap<WcfEntities.AccessPortalListItem, ApiEntities.AccessPortalListItem>().ReverseMap();
            this.CreateMap<WcfEntities.AccessPortalItem, ApiEntities.AccessPortalItem>().ReverseMap();
            this.CreateMap<WcfEntities.AccessPortalListItemCommands, ApiEntities.AccessPortalListItemCommands>().ReverseMap();

            this.CreateMap<WcfEntities.AccessPortalLockPushButtonBehavior, ApiEntities.AccessPortalLockPushButtonBehavior>().ReverseMap();
            this.CreateMap<WcfEntities.AccessPortalLockPushButtonBehavior, ApiEntities.AccessPortalLockPushButtonBehaviorBasic>().ReverseMap();

            this.CreateMap<WcfEntities.AccessPortalMultiFactorMode, ApiEntities.AccessPortalMultiFactorMode>().ReverseMap();
            this.CreateMap<WcfEntities.AccessPortalMultiFactorMode, ApiEntities.AccessPortalMultiFactorModeBasic>().ReverseMap();

            this.CreateMap<WcfEntities.AccessPortalNoServerReplyBehavior, ApiEntities.AccessPortalNoServerReplyBehavior>().ReverseMap();
            this.CreateMap<WcfEntities.AccessPortalNoServerReplyBehavior, ApiEntities.AccessPortalNoServerReplyBehaviorBasic>().ReverseMap();

            this.CreateMap<WcfEntities.AccessPortalProperties, ApiEntities.AccessPortalProperties>().ReverseMap();
            this.CreateMap<WcfEntities.AccessPortalProperties, ApiEntities.AccessPortalPropertiesBasic>()
                .ForMember(dest => dest.UnlockDelayInCs, opt => opt.MapFrom(src => src.UnlockDelay))
                .ForMember(dest => dest.UnlockDurationInCs, opt => opt.MapFrom(src => src.UnlockDuration))
                .ForMember(dest => dest.RecloseDurationInCs, opt => opt.MapFrom(src => src.RecloseDuration))
                .ReverseMap();

            this.CreateMap<RequestModels.AccessPortalPropertiesPutReq, WcfEntities.AccessPortalProperties>()
                .ForMember(dest => dest.UnlockDelay, opt => opt.MapFrom(src => src.UnlockDelayInCs))
                .ForMember(dest => dest.UnlockDuration, opt => opt.MapFrom(src => src.UnlockDurationInCs))
                .ForMember(dest => dest.RecloseDuration, opt => opt.MapFrom(src => src.RecloseDurationInCs))
                .ReverseMap();
            this.CreateMap<RequestModels.AccessPortalPropertiesReq, WcfEntities.AccessPortalProperties>()
                .ForMember(dest => dest.UnlockDelay, opt => opt.MapFrom(src => src.UnlockDelayInCs))
                .ForMember(dest => dest.UnlockDuration, opt => opt.MapFrom(src => src.UnlockDurationInCs))
                .ForMember(dest => dest.RecloseDuration, opt => opt.MapFrom(src => src.RecloseDurationInCs))
                .ReverseMap();

            this.CreateMap<RequestModels.AccessPortalReq, WcfEntities.AccessPortal>().ReverseMap();

            this.CreateMap<WcfEntities.AccessPortalScheduleType, ApiEntities.AccessPortalScheduleType>().ReverseMap();
            this.CreateMap<WcfEntities.AccessPortalScheduleType, ApiEntities.AccessPortalScheduleTypeBasic>().ReverseMap();

            this.CreateMap<WcfEntities.AccessPortalSelectionItem, ApiEntities.AccessPortalSelectionItem>().ReverseMap();
            this.CreateMap<WcfEntities.AccessPortalSelectionItem, ApiEntities.AccessPortalSelectionItemBasic>().ReverseMap();
            this.CreateMap<WcfEntities.AccessPortalSelectionItem, ApiEntities.AccessPortalSelectionItemMinimal>().ReverseMap();
            this.CreateMap<WcfEntities.AccessPortalSelectionItemBasic, ResponseModels.AccessPortalSelectionItemBasicResp>().ReverseMap();
            this.CreateMap<WcfEntities.AccessPortalSelectionItemBasic, ApiEntities.AccessPortalSelectionItemBasic>().ReverseMap();
            //this.CreateMap<WcfEntities.AccessPortalSelectionItemBasic, ApiEntities.AccessPortalSelectionItemMinimal>().ReverseMap();
            this.CreateMap<WcfEntities.AccessPortalSelectionItemBasic, ApiEntities.AccessPortalSelectionItemMinimal>().ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.AccessPortalUid)
            ).ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.AccessPortalName)
            ).ReverseMap();
            this.CreateMap<WcfEntities.AccessPortalSelectionItemMinimal, ApiEntities.AccessPortalSelectionItemMinimal>().ReverseMap();

            this.CreateMap<WcfEntities.AccessPortalTimeSchedule, ApiEntities.AccessPortalTimeSchedule>().ReverseMap();
            this.CreateMap<WcfEntities.AccessPortalTimeSchedule, ApiEntities.AccessPortalTimeScheduleBasic>().ReverseMap();

            this.CreateMap<RequestModels.AccessPortalTimeSchedulePutReq, WcfEntities.AccessPortalTimeSchedule>().ReverseMap();
            this.CreateMap<RequestModels.AccessPortalTimeScheduleReq, WcfEntities.AccessPortalTimeSchedule>().ReverseMap();

            this.CreateMap<WcfEntities.AccessPortalType, ApiEntities.AccessPortalType>().ReverseMap();
            this.CreateMap<WcfEntities.AccessPortalType, ApiEntities.AccessPortalTypeBasic>().ReverseMap();

            this.CreateMap<WcfEntities.AccessProfile, ApiEntities.AccessProfile>().ReverseMap();
            this.CreateMap<WcfEntities.AccessProfile, ApiEntities.AccessProfileBasic>().ReverseMap();
            this.CreateMap<WcfEntities.AccessProfile, ResponseModels.AccessProfileBasicResp>().ReverseMap();
            this.CreateMap<RequestModels.AccessProfileReq, WcfEntities.AccessProfile>().ReverseMap();
            this.CreateMap<RequestModels.AccessProfilePutReq, WcfEntities.AccessProfile>().ReverseMap();
            this.CreateMap<WcfEntities.AccessProfileCounts, ApiEntities.AccessProfileCounts>().ReverseMap();
            this.CreateMap<WcfEntities.AccessProfileListItem, ApiEntities.AccessProfileListItem>();

            this.CreateMap<WcfEntities.AccessProfileAccessGroup, ApiEntities.AccessProfileAccessGroup>().ReverseMap();
            this.CreateMap<WcfEntities.AccessProfileAccessGroup, ApiEntities.AccessProfileAccessGroupBasic>().ReverseMap();
            this.CreateMap<WcfEntities.AccessProfileAccessGroup, ResponseModels.AccessProfileAccessGroupBasicResp>().ReverseMap();
            this.CreateMap<RequestModels.AccessProfileAccessGroupReq, WcfEntities.AccessProfileAccessGroup>().ReverseMap();
            this.CreateMap<RequestModels.AccessProfileAccessGroupPutReq, WcfEntities.AccessProfileAccessGroup>().ReverseMap();

            this.CreateMap<WcfEntities.AccessProfileCluster, ApiEntities.AccessProfileCluster>().ReverseMap();
            this.CreateMap<WcfEntities.AccessProfileCluster, ApiEntities.AccessProfileClusterBasic>().ReverseMap();
            this.CreateMap<WcfEntities.AccessProfileCluster, ResponseModels.AccessProfileClusterBasicResp>().ReverseMap();
            this.CreateMap<RequestModels.AccessProfileClusterReq, WcfEntities.AccessProfileCluster>().ReverseMap();
            this.CreateMap<RequestModels.AccessProfileClusterPutReq, WcfEntities.AccessProfileCluster>().ReverseMap();

            this.CreateMap<WcfEntities.AccessProfileEditingData, ApiEntities.AccessProfileEditingDataBasic>().ReverseMap();


            this.CreateMap<WcfEntities.AccessProfileInputOutputGroup, ApiEntities.AccessProfileInputOutputGroup>().ReverseMap();
            this.CreateMap<WcfEntities.AccessProfileInputOutputGroup, ApiEntities.AccessProfileInputOutputGroupBasic>().ReverseMap();
            this.CreateMap<WcfEntities.AccessProfileInputOutputGroup, ResponseModels.AccessProfileInputOutputGroupBasicResp>().ReverseMap();
            this.CreateMap<RequestModels.AccessProfileInputOutputGroupReq, WcfEntities.AccessProfileInputOutputGroup>().ReverseMap();
            this.CreateMap<RequestModels.AccessProfileInputOutputGroupPutReq, WcfEntities.AccessProfileInputOutputGroup>().ReverseMap();

            this.CreateMap<RequestModels.ActivityHistoryEventSearchParametersReq, WcfEntities.ActivityHistoryEventSearchParameters>().ReverseMap();
            this.CreateMap<RequestModels.AccessPortalActivityHistoryEventSearchParametersReq, WcfEntities.ActivityHistoryEventSearchParameters>().ReverseMap();
            this.CreateMap<RequestModels.GalaxyPanelActivityHistoryEventSearchParametersReq, WcfEntities.ActivityHistoryEventSearchParameters>().ReverseMap();
            this.CreateMap<RequestModels.InputDeviceActivityHistoryEventSearchParametersReq, WcfEntities.ActivityHistoryEventSearchParameters>().ReverseMap();
            this.CreateMap<RequestModels.OutputDeviceActivityHistoryEventSearchParametersReq, WcfEntities.ActivityHistoryEventSearchParameters>().ReverseMap();
            this.CreateMap<WcfEntities.ActivityHistoryEvent, ApiEntities.ActivityHistoryEvent>().ReverseMap();
            this.CreateMap<WcfEntities.ActivityHistoryEvent, ResponseModels.ActivityHistoryEventBasicResp>().ReverseMap();
            this.CreateMap<WcfEntities.ActivityHistoryEvent, ResponseModels.ActivityHistoryEventBasicWithEntityResp>().ReverseMap();

            this.CreateMap<WcfEntities.AcknowledgeAlarmEventParameters, ApiEntities.AcknowledgeAlarmEventParameters>().ReverseMap();
            this.CreateMap<WcfEntities.AcknowledgedAlarmBasicData, ApiEntities.AcknowledgedAlarmBasicData>().ReverseMap();
            this.CreateMap<WcfEntities.UnacknowledgeAlarmEventParameters, ApiEntities.UnacknowledgeAlarmEventParameters>().ReverseMap();
            
            this.CreateMap<WcfEntities.AcknowledgedAlarmBasicData, ResponseModels.AcknowledgedAlarmBasicData>().ReverseMap();

            this.CreateMap<WcfEntities.Address, ApiEntities.Address>().ReverseMap();
            this.CreateMap<WcfEntities.Address, ApiEntities.AddressBasic>().ReverseMap();
            //this.CreateMap<WcfEntities.AddressBasic, ApiEntities.AddressBasic>().ReverseMap();
            this.CreateMap<RequestModels.AddressReq, WcfEntities.Address>().ReverseMap();
            this.CreateMap<RequestModels.AddressPutReq, WcfEntities.Address>().ReverseMap();
            this.CreateMap<WcfEntities.Area, ApiEntities.Area>().ReverseMap();
            this.CreateMap<WcfEntities.Area, ApiEntities.AreaBasic>().ReverseMap();
            this.CreateMap<WcfEntities.Area, RequestModels.AreaReq>().ReverseMap();
            this.CreateMap<WcfEntities.Area, RequestModels.AreaPutReq>().ReverseMap();
            this.CreateMap<WcfEntities.Area, ResponseModels.AreaResp>().ReverseMap();
            //this.CreateMap<WcfEntities.AreaBasic, ApiEntities.AreaBasic>().ReverseMap();

            this.CreateMap<WcfEntities.AutomaticForgivePassbackFrequency, ApiEntities.AutomaticForgivePassbackFrequency>().ReverseMap();
            this.CreateMap<WcfEntities.AutomaticForgivePassbackFrequency, ApiEntities.AutomaticForgivePassbackFrequencyBasic>().ReverseMap();
            this.CreateMap<WcfEntities.BackgroundJobInfo, ApiEntities.BackgroundJobInfo>().ReverseMap();
            //this.CreateMap<WcfEntities.BackgroundJobInfo, ApiEntities.BackgroundJobInfo>().ReverseMap();


            this.CreateMap(typeof(WcfEntities.BackgroundJobInfo), typeof(ApiEntities.BackgroundJobInfo)).ReverseMap();
            this.CreateMap(typeof(WcfEntities.BackgroundJobInfo<>), typeof(ApiEntities.BackgroundJobInfo<>)).ReverseMap();

            this.CreateMap<WcfEntities.BackgroundJob, ApiEntities.BackgroundJob>().ReverseMap();
            this.CreateMap<WcfEntities.BackgroundJobData, ApiEntities.BackgroundJobData>().ReverseMap();
            this.CreateMap<WcfEntities.BackgroundJobStateChange, ApiEntities.BackgroundJobStateChange>().ReverseMap();
            this.CreateMap<WcfEntities.BackgroundJobStateChangeInfo, ApiEntities.BackgroundJobStateChangeInfo>().ReverseMap();
            
            this.CreateMap<WcfEntities.ClusterEditingData, ApiEntities.ClusterEditingData>().ReverseMap();
            this.CreateMap<RequestModels.ClusterReq, WcfEntities.Cluster>()
                .ForMember(m => m.ClusterType, opt => opt.Ignore())
                .ForMember(
                    dest => dest.LockoutDurationSeconds,
                    opt => opt.MapFrom(src => src.LockoutDurationInCs))
                .ForMember(
                    dest => dest.AccessRuleOverrideTimeout,
                    opt => opt.MapFrom(src => src.AccessRuleOverrideTimeoutInCs))
                .ForMember(
                    dest => dest.UnlimitedCredentialTimeout,
                    opt => opt.MapFrom(src => src.UnlimitedCredentialTimeoutInCs))
                .ReverseMap();
            this.CreateMap<RequestModels.ClusterPutReq, WcfEntities.Cluster>()
                .ForMember(m => m.ClusterType, opt => opt.Ignore())
                .ForMember(
                    dest => dest.LockoutDurationSeconds,
                    opt => opt.MapFrom(src => src.LockoutDurationInCs))
                .ForMember(
                    dest => dest.AccessRuleOverrideTimeout,
                    opt => opt.MapFrom(src => src.AccessRuleOverrideTimeoutInCs))
                .ForMember(
                    dest => dest.UnlimitedCredentialTimeout,
                    opt => opt.MapFrom(src => src.UnlimitedCredentialTimeoutInCs))
                .ReverseMap();

            this.CreateMap<RequestModels.ClusterPutReqMinimalChildren, WcfEntities.Cluster>()
                .ForMember(m => m.ClusterType, opt => opt.Ignore()).ReverseMap();


            //.ForMember(m=>m.CredentialDataLength, opt=> opt.Ignore())
            //.ForMember(m=>m.TimeScheduleType, opt=> opt.Ignore())
            //.ForMember(m=>m.AccessPortalLockedLedBehaviorMode, opt=> opt.Ignore())
            //.ForMember(m=>m.AccessPortalUnlockedLedBehaviorMode, opt=> opt.Ignore());

            this.CreateMap<WcfEntities.Cluster, ApiEntities.Cluster>().ReverseMap();
            this.CreateMap<WcfEntities.Cluster, ApiEntities.ClusterBasic>()
                .ForMember(
                dest => dest.LockoutDurationInCs,
                opt => opt.MapFrom(src => src.LockoutDurationSeconds))
                .ForMember(
                    dest => dest.AccessRuleOverrideTimeoutInCs,
                    opt => opt.MapFrom(src => src.AccessRuleOverrideTimeout))
                .ForMember(
                    dest => dest.UnlimitedCredentialTimeoutInCs,
                    opt => opt.MapFrom(src => src.UnlimitedCredentialTimeout))
                .ReverseMap();
            this.CreateMap<WcfEntities.Cluster, ApiEntities.ClusterMinimal>().ReverseMap();
            this.CreateMap<WcfEntities.Cluster, ResponseModels.ClusterResp>().ForMember(
                dest => dest.LockoutDurationInCs,
                opt => opt.MapFrom(src => src.LockoutDurationSeconds))
                .ForMember(
                    dest => dest.AccessRuleOverrideTimeoutInCs,
                    opt => opt.MapFrom(src => src.AccessRuleOverrideTimeout))
                .ForMember(
                    dest => dest.UnlimitedCredentialTimeoutInCs,
                    opt => opt.MapFrom(src => src.UnlimitedCredentialTimeout))
                .ReverseMap();

            this.CreateMap<WcfEntities.ClusterListItemCommands, ApiEntities.ClusterListItemCommands>().ReverseMap();
            this.CreateMap<WcfEntities.ClusterCounts, ApiEntities.ClusterCounts>().ReverseMap();
            this.CreateMap<WcfEntities.ClusterListItem, ApiEntities.ClusterListItem>().ReverseMap();
            
            //this.CreateMap<WcfEntities.ClusterBasic, ApiEntities.ClusterBasic>().ReverseMap();
            this.CreateMap<WcfEntities.ClusterCommand, ApiEntities.ClusterCommand>().ReverseMap();
            this.CreateMap<WcfEntities.ClusterCommand, ApiEntities.ClusterCommandBasic>().ReverseMap();
            //this.CreateMap<WcfEntities.ClusterCommandAction, ApiEntities.ClusterCommandAction>().ReverseMap();
            //this.CreateMap<RequestModels.ClusterCommandActionReq, WcfEntities.ClusterCommandAction>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyCpuCommandAction, ApiEntities.GalaxyCpuCommandAction>().ReverseMap();
            this.CreateMap<RequestModels.GalaxyCpuCommandActionReq, WcfEntities.GalaxyCpuCommandAction>().ReverseMap();

            this.CreateMap<WcfEntities.ClusterDataLoadParameters, ApiEntities.ClusterDataLoadParameters>().ReverseMap();
            this.CreateMap<RequestModels.ClusterDataLoadParametersReq, WcfEntities.ClusterDataLoadParameters>().ReverseMap();
            this.CreateMap<WcfEntities.LoadDataToPanelSettings, ApiEntities.LoadDataToPanelSettings>().ReverseMap();

            this.CreateMap<WcfEntities.ClusterEditingData, ApiEntities.ClusterEditingData>().ReverseMap();
            this.CreateMap<WcfEntities.ClusterEditingData, ApiEntities.ClusterEditingDataBasic>().ReverseMap();
            this.CreateMap<WcfEntities.ClusterCommandBasic, ApiEntities.ClusterCommandBasic>().ReverseMap();
            this.CreateMap<WcfEntities.ClusterEntityMap, ApiEntities.ClusterEntityMap>().ReverseMap();
            this.CreateMap<WcfEntities.ClusterEntityMap, ApiEntities.ClusterEntityMapBasic>().ReverseMap();
            this.CreateMap<WcfEntities.ClusterGalaxyPanelMinimal, ApiEntities.ClusterGalaxyPanelMinimal>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyPanelMinimal, ApiEntities.GalaxyPanelMinimal>().ReverseMap();

            //this.CreateMap<WcfEntities.ClusterEntityMapBasic, ApiEntities.ClusterEntityMapBasic>().ReverseMap();
            this.CreateMap<WcfEntities.ClusterInputOutputGroup, ApiEntities.ClusterInputOutputGroup>().ReverseMap();
            this.CreateMap<WcfEntities.ClusterInputOutputGroup, ApiEntities.ClusterInputOutputGroupBasic>().ReverseMap();
            //this.CreateMap<WcfEntities.ClusterInputOutputGroupBasic, ApiEntities.ClusterInputOutputGroupBasic>().ReverseMap();

            this.CreateMap<WcfEntities.ClusterLedBehaviorMode, ApiEntities.ClusterLedBehaviorMode>().ReverseMap();
            this.CreateMap<WcfEntities.ClusterLedBehaviorMode, ApiEntities.ClusterLedBehaviorModeBasic>().ReverseMap();

            this.CreateMap<WcfEntities.ClusterSelectionItem, ApiEntities.ClusterSelectionItem>().ReverseMap();
            this.CreateMap<WcfEntities.ClusterSelectionItem, ApiEntities.ClusterSelectionItemBasic>().ReverseMap();
            //this.CreateMap<WcfEntities.ClusterSelectionItem, ApiEntities.ClusterSelectionItemMinimal>().ReverseMap();
            this.CreateMap<WcfEntities.ClusterSelectionItem, ApiEntities.ClusterSelectionItemMinimal>().ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.ClusterUid)
            ).ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.ClusterName)
            ).ReverseMap();

            //            this.CreateMap<WcfEntities.ClusterSelectionItemBasic, ApiEntities.ClusterSelectionItemMinimal>().ReverseMap();
            this.CreateMap<WcfEntities.ClusterSelectionItemBasic, ApiEntities.ClusterSelectionItemMinimal>().ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.ClusterUid)
            ).ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.ClusterName)
            ).ReverseMap();

            this.CreateMap<WcfEntities.ClusterSelectionItemBasic, ResponseModels.ClusterSelectionItemBasicResp>().ReverseMap();
            this.CreateMap<WcfEntities.ClusterSelectionItemBasic, ApiEntities.ClusterSelectionItemBasic>().ReverseMap();
            this.CreateMap<WcfEntities.ClusterSelectionItemMinimal, ApiEntities.ClusterSelectionItemMinimal>().ReverseMap();
            this.CreateMap<WcfEntities.ClusterTimeScheduleItem, ApiEntities.ClusterTimeScheduleItem>().ReverseMap();

            
            this.CreateMap<WcfEntities.ClusterType, ApiEntities.ClusterType>().ReverseMap();
            this.CreateMap<WcfEntities.ClusterType, ApiEntities.ClusterTypeBasic>().ReverseMap();
            //this.CreateMap<WcfEntities.ClusterTypeBasic, ApiEntities.ClusterTypeBasic>().ReverseMap();
            this.CreateMap<WcfEntities.ClusterTypeClusterCommand, ApiEntities.ClusterTypeClusterCommand>().ReverseMap();
            this.CreateMap<WcfEntities.ClusterTypeClusterCommand, ApiEntities.ClusterTypeClusterCommandBasic>().ReverseMap();
            this.CreateMap<WcfEntities.ClusterTypeClusterCommandBasic, ApiEntities.ClusterTypeClusterCommandBasic>().ReverseMap();

            this.CreateMap(typeof(WcfEntities.CommandParameters), typeof(ApiEntities.CommandParameters)).ReverseMap();
            this.CreateMap(typeof(WcfEntities.CommandParameters<>), typeof(ApiEntities.CommandParameters<>)).ReverseMap();
            this.CreateMap<RequestModels.CommandParams, WcfEntities.CommandParameters>(MemberList.Source);
            this.CreateMap<RequestModels.CommandParamsSimple, WcfEntities.CommandParameters>(MemberList.Source);
            this.CreateMap(typeof(RequestModels.CommandParams<>), typeof(WcfEntities.CommandParameters<>), MemberList.Source);
            this.CreateMap(typeof(RequestModels.CommandParamsSimple<>), typeof(WcfEntities.CommandParameters<>), MemberList.Source);

            this.CreateMap<WcfEntities.CommandResponse, ResponseModels.CommandResponseSimple>().ReverseMap();
            this.CreateMap(typeof(WcfEntities.CommandResponse<>), typeof(ResponseModels.CommandResponseSimple<>)).ReverseMap();
            this.CreateMap(typeof(WcfEntities.CommandParameters<>), typeof(ResponseModels.CommandResponseSimple<>)).ReverseMap();
            this.CreateMap(typeof(WcfEntities.LoadDataCommandResponse<>), typeof(ResponseModels.LoadDataCommandResponseSimple<>)).ReverseMap();
            this.CreateMap<WcfEntities.PanelCommandResponseInfo, ApiEntities.PanelCommandResponseInfo>().ReverseMap();
            this.CreateMap<WcfEntities.CpuCommandResponseInfo, ApiEntities.CpuCommandResponseInfo>().ReverseMap();

            this.CreateMap<WcfEntities.LoadDataToPanelNotificationCounts, ApiEntities.LoadDataToPanelNotificationCounts>().ReverseMap();

            this.CreateMap<WcfEntities.ComputerInformation, ApiEntities.ComputerInformation>().ReverseMap();
            this.CreateMap<WcfEntities.Country, ApiEntities.Country>().ReverseMap();
            this.CreateMap<WcfEntities.Country, ApiEntities.CountryBasic>().ReverseMap();
            this.CreateMap<WcfEntities.Country, ResponseModels.CountryBasicResp>().ReverseMap();
            //this.CreateMap<WcfEntities.CountryBasic, ApiEntities.CountryBasic>().ReverseMap();
            this.CreateMap<RequestModels.CountryReq, WcfEntities.Country>().ReverseMap();
            this.CreateMap<WcfEntities.CpuConnectionInfo, ApiEntities.CpuConnectionInfo>().ReverseMap();
            this.CreateMap<WcfEntities.CpuConnectionInfo, ResponseModels.CpuConnectionInfoResp>().ReverseMap();
            //this.CreateMap<WcfEntities.CpuConnectionInfo, RequestModels.CpuConnectionInfoReq>().ReverseMap();
            //this.CreateMap<WcfEntities.PanelInqueryReply, RequestModels.PanelInqueryReplyBasicReq>().ReverseMap();
            this.CreateMap<WcfEntities.PanelBoardInformation, RequestModels.PanelBoardInformationReq>().ReverseMap();
            this.CreateMap<WcfEntities.PanelBoardInformationCollection, RequestModels.PanelBoardInformationCollectionReq>().ReverseMap();
            //this.CreateMap<WcfEntities.GalaxyCpuInformation, RequestModels.GalaxyCpuInformationReq>().ReverseMap();

            this.CreateMap<WcfEntities.CredentialDataLength, ApiEntities.CredentialDataLength>().ReverseMap();
            this.CreateMap<WcfEntities.CredentialDataLength, ApiEntities.CredentialDataLengthBasic>().ReverseMap();

            this.CreateMap<WcfEntities.Credential, ApiEntities.Credential>().ReverseMap();
            this.CreateMap<WcfEntities.Credential, ApiEntities.CredentialBasic>().ReverseMap();
            this.CreateMap<WcfEntities.Credential26BitStandard, ApiEntities.Credential26BitStandard>().ReverseMap();
            this.CreateMap<WcfEntities.Credential26BitStandard, ApiEntities.Credential26BitStandardBasic>().ReverseMap();
            this.CreateMap<WcfEntities.CredentialBqt36Bit, ApiEntities.CredentialBqt36Bit>().ReverseMap();
            this.CreateMap<WcfEntities.CredentialBqt36Bit, ApiEntities.CredentialBqt36BitBasic>().ReverseMap();
            this.CreateMap<WcfEntities.CredentialCorporate1K35Bit, ApiEntities.CredentialCorporate1K35Bit>().ReverseMap();
            this.CreateMap<WcfEntities.CredentialCorporate1K35Bit, ApiEntities.CredentialCorporate1K35BitBasic>().ReverseMap();
            this.CreateMap<WcfEntities.CredentialCorporate1K48Bit, ApiEntities.CredentialCorporate1K48Bit>().ReverseMap();
            this.CreateMap<WcfEntities.CredentialCorporate1K48Bit, ApiEntities.CredentialCorporate1K48BitBasic>().ReverseMap();
            this.CreateMap<WcfEntities.CredentialCypress37Bit, ApiEntities.CredentialCypress37Bit>().ReverseMap();
            this.CreateMap<WcfEntities.CredentialCypress37Bit, ApiEntities.CredentialCypress37BitBasic>().ReverseMap();
            this.CreateMap<WcfEntities.CredentialData, ApiEntities.CredentialData>().ReverseMap();
            this.CreateMap<WcfEntities.CredentialData, ApiEntities.CredentialDataBasic>().ReverseMap();
            this.CreateMap<WcfEntities.CredentialFormat, ApiEntities.CredentialFormat>().ReverseMap();
            this.CreateMap<WcfEntities.CredentialFormat, ApiEntities.CredentialFormatBasic>().ReverseMap();
            this.CreateMap<WcfEntities.CredentialFormat, ResponseModels.CredentialFormatBasicResp>().ReverseMap();
            this.CreateMap<WcfEntities.CredentialFormatDataField, ApiEntities.CredentialFormatDataField>().ReverseMap();
            this.CreateMap<WcfEntities.CredentialFormatDataField, ApiEntities.CredentialFormatDataFieldBasic>().ReverseMap();
            this.CreateMap<WcfEntities.CredentialFormatDataField, ResponseModels.CredentialFormatDataFieldBasicResp>().ReverseMap();
            this.CreateMap<WcfEntities.CredentialFormatParity, ApiEntities.CredentialFormatParity>().ReverseMap();
            this.CreateMap<WcfEntities.CredentialFormatParity, ApiEntities.CredentialFormatParityBasic>().ReverseMap();
            this.CreateMap<WcfEntities.CredentialH1030237Bit, ApiEntities.CredentialH1030237Bit>().ReverseMap();
            this.CreateMap<WcfEntities.CredentialH1030237Bit, ApiEntities.CredentialH1030237BitBasic>().ReverseMap();
            this.CreateMap<WcfEntities.CredentialH1030437Bit, ApiEntities.CredentialH1030437Bit>().ReverseMap();
            this.CreateMap<WcfEntities.CredentialH1030437Bit, ApiEntities.CredentialH1030437BitBasic>().ReverseMap();
            this.CreateMap<WcfEntities.CredentialPIV75Bit, ApiEntities.CredentialPIV75Bit>().ReverseMap();
            this.CreateMap<WcfEntities.CredentialPIV75Bit, ApiEntities.CredentialPIV75BitBasic>().ReverseMap();
            this.CreateMap<WcfEntities.CredentialSoftwareHouse37Bit, ApiEntities.CredentialSoftwareHouse37Bit>().ReverseMap();
            this.CreateMap<WcfEntities.CredentialSoftwareHouse37Bit, ApiEntities.CredentialSoftwareHouse37BitBasic>().ReverseMap();
            this.CreateMap<WcfEntities.CredentialXceedId40Bit, ApiEntities.CredentialXceedId40Bit>().ReverseMap();
            this.CreateMap<WcfEntities.CredentialXceedId40Bit, ApiEntities.CredentialXceedId40BitBasic>().ReverseMap();

            this.CreateMap<WcfEntities.DateType, ApiEntities.DateType>().ReverseMap();
            this.CreateMap<WcfEntities.DateType, ApiEntities.DateTypeBasic>().ReverseMap();
            this.CreateMap<WcfEntities.DateType, RequestModels.DateTypeReq>().ReverseMap();
            this.CreateMap<WcfEntities.DateType, RequestModels.DateTypePutReq>().ReverseMap();
            this.CreateMap<WcfEntities.DateType, RequestModels.DayTypeDateReq>().ReverseMap();
            this.CreateMap<WcfEntities.DateType, RequestModels.DateTypePutReqNoEntity>().ReverseMap();
            this.CreateMap<WcfEntities.DateType, RequestModels.DateTypePutReqNoEntity>().ReverseMap();
            
            //this.CreateMap<WcfEntities.DateTypeBasic, ApiEntities.DateTypeBasic>().ReverseMap();

            this.CreateMap<WcfEntities.DayType, ApiEntities.DayType>().ReverseMap();
            this.CreateMap<WcfEntities.DayType, ApiEntities.DayTypeBasic>().ReverseMap();
            this.CreateMap<WcfEntities.DayType, RequestModels.DayTypeReq>().ReverseMap();
            this.CreateMap<WcfEntities.DayType, RequestModels.DayTypePutReq>().ReverseMap();
            this.CreateMap<RequestModels.DayTypeTimePeriodReqBase, WcfEntities.DayType>();//.ReverseMap();
            this.CreateMap<RequestModels.DayTypeTimePeriodPutReqBase, WcfEntities.DayType>();//.ReverseMap();
            this.CreateMap<WcfEntities.DayTypeBasic, ApiEntities.DayTypeBasic>().ReverseMap();
            this.CreateMap<WcfEntities.DayTypeListItem, ApiEntities.DayTypeListItem>().ReverseMap();
            
            this.CreateMap<WcfEntities.DateTypeDefaultBehavior, ApiEntities.DateTypeDefaultBehavior>().ReverseMap();
            this.CreateMap<WcfEntities.DateTypeDefaultBehavior, ApiEntities.DateTypeDefaultBehaviorBasic>().ReverseMap();
            this.CreateMap<WcfEntities.DateTypeDefaultBehavior, RequestModels.DateTypeDefaultBehaviorReq>().ReverseMap();
            this.CreateMap<WcfEntities.DateTypeDefaultBehavior, RequestModels.DateTypeDefaultBehaviorPutReq>().ReverseMap();


            this.CreateMap<WcfEntities.DayTypeSelect, ApiEntities.DayTypeSelect>().ReverseMap();
            this.CreateMap<WcfEntities.DayTypeSelect, ApiEntities.DayTypeSelectBasic>().ReverseMap();
            //this.CreateMap<WcfEntities.DayTypeSelectBasic, ApiEntities.DayTypeSelectBasic>().ReverseMap();
            this.CreateMap<WcfEntities.DayTypeTimePeriods, ApiEntities.DayTypeTimePeriods>().ReverseMap();
            this.CreateMap<WcfEntities.DayTypeTimePeriods, RequestModels.DayTypeTimePeriodsReq>().ReverseMap();
            this.CreateMap<WcfEntities.DayTypeTimePeriods, RequestModels.DayTypeTimePeriodsPutReq>().ReverseMap();
            this.CreateMap<WcfEntities.DecodeCredentialNumberParameters, RequestModels.DecodeCredentialNumberParametersReq>().ReverseMap();
            this.CreateMap<WcfEntities.CredentialPart, ResponseModels.CredentialPartResp>().ReverseMap();
            this.CreateMap<WcfEntities.DecodedCredential, ResponseModels.DecodedCredentialResp>().ReverseMap();

            this.CreateMap<WcfEntities.DeleteParameters, ApiEntities.DeleteParameters>().ReverseMap();
            this.CreateMap(typeof(WcfEntities.DeleteParameters<>), typeof(ApiEntities.DeleteParameters<>)).ReverseMap();
            this.CreateMap<WcfEntities.EntityDeviceAlertEventSettings, ApiEntities.EntityDeviceAlertEventSettings>().ReverseMap();
            this.CreateMap<WcfEntities.DeviceAlertEventSettings, ApiEntities.DeviceAlertEventSettings>().ReverseMap();
            this.CreateMap<WcfEntities.ItemIdName, ApiEntities.ItemIdName>().ReverseMap();
            this.CreateMap<WcfEntities.EntityIdEntityMapPermissionLevel, ApiEntities.EntityIdEntityMapPermissionLevel>().ReverseMap();

            this.CreateMap<WcfEntities.EntityEditingData, ApiEntities.EntityEditingData>().ReverseMap();
            this.CreateMap<WcfEntities.EntityEditingData, ApiEntities.EntityEditingDataBasic>().ReverseMap();

            this.CreateMap<WcfEntities.EventFilterData, ApiEntities.EventFilterData>().ReverseMap();
            this.CreateMap<WcfEntities.EventType, ApiEntities.EventType>().ReverseMap();

            this.CreateMap<WcfEntities.GalaxyActivityEventType, ApiEntities.GalaxyActivityEventType>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyActivityEventType, ApiEntities.GalaxyActivityEventTypeBasic>().ForMember(
                dest => dest.EventTypeUid,
                opt => opt.MapFrom(src => src.GalaxyActivityEventTypeUid))
                .ForMember(
                dest => dest.Message,
                opt => opt.MapFrom(src => src.Display));

            this.CreateMap<WcfEntities.GalaxyActivityEventTypeBasic, ApiEntities.GalaxyActivityEventTypeBasic>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyActivityEventTypeBasicGroups, ApiEntities.GalaxyActivityEventTypeBasicGroups>().ReverseMap();

            this.CreateMap<WcfEntities.GalaxyClusterDayTypeMap, ApiEntities.GalaxyClusterDayTypeMap>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyClusterDayTypeMap, ApiEntities.GalaxyClusterDayTypeMapBasic>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyClusterDayTypeMap, RequestModels.GalaxyClusterDayTypeMapPutReq>().ReverseMap();
            //this.CreateMap<WcfEntities.GalaxyClusterDayTypeMapBasic, ApiEntities.GalaxyClusterDayTypeMapBasic>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyClusterTimeScheduleMap, ApiEntities.GalaxyClusterTimeScheduleMap>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyClusterTimeScheduleMap, ApiEntities.GalaxyClusterTimeScheduleMapBasic>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyClusterTimeScheduleMap, RequestModels.GalaxyClusterTimeScheduleMapPutReq>().ReverseMap();
            //this.CreateMap<WcfEntities.GalaxyClusterTimeScheduleMapBasic, ApiEntities.GalaxyClusterTimeScheduleMapBasic>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyCpuDatabaseInformation, ApiEntities.GalaxyCpuDatabaseInformation>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyCpuDatabaseInformation, ResponseModels.GalaxyCpuDatabaseInformationResp>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyCpu, ApiEntities.GalaxyCpu>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyCpu, ApiEntities.GalaxyCpuBasic>().ForMember(
                dest => dest.FlashVersion,
                opt => opt.MapFrom(src => src.Version)
            ).ReverseMap();
            this.CreateMap<RequestModels.GalaxyCpuReq, WcfEntities.GalaxyCpu>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyCpu, RequestModels.GalaxyCpuPostReq>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyCpu, RequestModels.GalaxyCpuPutReq>().ForMember(
                dest => dest.FlashVersion,
                opt => opt.MapFrom(src => src.Version)
            ).ReverseMap();

            this.CreateMap<WcfEntities.GalaxyRegion, ApiEntities.GalaxyRegion>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxySite, ApiEntities.GalaxySite>().ReverseMap();
            this.CreateMap<WcfEntities.CpuHardwareAddress, ApiEntities.CpuHardwareAddress>().ReverseMap();
            this.CreateMap<WcfEntities.BoardHardwareAddress, ApiEntities.BoardHardwareAddress>().ReverseMap();
            this.CreateMap<WcfEntities.BoardSectionHardwareAddress, ApiEntities.BoardSectionHardwareAddress>().ReverseMap();
            this.CreateMap<WcfEntities.BoardSectionNodeHardwareAddress, ApiEntities.BoardSectionNodeHardwareAddress>().ReverseMap();
            this.CreateMap<WcfEntities.PanelInqueryReply, ApiEntities.PanelInqueryReply>().ReverseMap();
            this.CreateMap<WcfEntities.CredentialCountReply, ApiEntities.CredentialCountReply>().ReverseMap();
            this.CreateMap<WcfEntities.LoggingStatusReply, ApiEntities.LoggingStatusReply>().ReverseMap();
            this.CreateMap<WcfEntities.PanelBoardInformation, ApiEntities.PanelBoardInformation>().ReverseMap();
            this.CreateMap<WcfEntities.PanelBoardInformationCollection, ApiEntities.PanelBoardInformationCollection>().ReverseMap();
            this.CreateMap<WcfEntities.FirmwareVersion, ApiEntities.FirmwareVersion>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyPanel_GetAlertEventAcknowledgeData, ApiEntities.GalaxyPanel_GetAlertEventAcknowledgeData>().ReverseMap();

            this.CreateMap<WcfEntities.GalaxyRegion, ResponseModels.GalaxyRegionResp>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxySite, ResponseModels.GalaxySiteResp>().ReverseMap();
            this.CreateMap<WcfEntities.CpuHardwareAddress, ResponseModels.CpuHardwareAddressResp>().ReverseMap();
            this.CreateMap<WcfEntities.BoardHardwareAddress, ResponseModels.BoardHardwareAddressResp>().ReverseMap();
            this.CreateMap<WcfEntities.BoardSectionHardwareAddress, ResponseModels.BoardSectionHardwareAddressResp>().ReverseMap();
            this.CreateMap<WcfEntities.BoardSectionNodeHardwareAddress, ResponseModels.BoardSectionNodeHardwareAddressResp>().ReverseMap();
            this.CreateMap<WcfEntities.PanelInqueryReply, ResponseModels.PanelInqueryReplyResp>().ReverseMap();
            this.CreateMap<WcfEntities.PanelInqueryReply, ResponseModels.PanelInqueryReplyBasicResp>().ReverseMap();
            this.CreateMap<WcfEntities.PanelInqueryReplyBasic, ResponseModels.PanelInqueryReplyBasicResp>().ReverseMap();
            this.CreateMap<WcfEntities.CredentialCountReply, ResponseModels.CredentialCountReplyResp>().ReverseMap();
            this.CreateMap<WcfEntities.CredentialCountReply, ApiEntities.CredentialCountReplySignalR>().ReverseMap();
            this.CreateMap<WcfEntities.CredentialCountReplySignalR, ApiEntities.CredentialCountReplySignalR>().ReverseMap();
            this.CreateMap<WcfEntities.CredentialCountReply, ResponseModels.CredentialCountReplyBasicResp>().ReverseMap();
            this.CreateMap<WcfEntities.CredentialCountReplyBasic, ResponseModels.CredentialCountReplyBasicResp>().ReverseMap();
            this.CreateMap<WcfEntities.LoggingStatusReply, ResponseModels.LoggingStatusReplyResp>().ReverseMap();
            this.CreateMap<WcfEntities.LoggingStatusReply, ResponseModels.LoggingStatusReplyBasicResp>().ReverseMap();
            this.CreateMap<WcfEntities.LoggingStatusReplyBasic, ResponseModels.LoggingStatusReplyBasicResp>().ReverseMap();
            this.CreateMap<WcfEntities.PanelBoardInformation, ResponseModels.PanelBoardInformationResp>().ReverseMap();
            this.CreateMap<WcfEntities.PanelBoardInformationCollection, ResponseModels.PanelBoardInformationCollectionResp>().ReverseMap();
            this.CreateMap<WcfEntities.PanelBoardInformationCollection, ResponseModels.PanelBoardInformationCollectionBasicResp>().ReverseMap();
            this.CreateMap<WcfEntities.PanelBoardInformationCollectionBasic, ResponseModels.PanelBoardInformationCollectionBasicResp>().ReverseMap();
            this.CreateMap<WcfEntities.FirmwareVersion, ResponseModels.FirmwareVersionResp>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyPanel_GetAlertEventAcknowledgeData, ResponseModels.GalaxyPanel_GetAlertEventAcknowledgeDataResp>().ReverseMap();

            //this.CreateMap<WcfEntities.GalaxyCpuBasic, ApiEntities.GalaxyCpuBasic>().ReverseMap();

            this.CreateMap<WcfEntities.GalaxyCpuModel, ApiEntities.GalaxyCpuModel>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyCpuModel, ApiEntities.GalaxyCpuModelBasic>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyCpuInformation, ApiEntities.GalaxyCpuInformation>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyCpuInformation, ResponseModels.GalaxyCpuInformationResp>().ReverseMap();

            //this.CreateMap<WcfEntities.GalaxyCpuModelBasic, ApiEntities.GalaxyCpuModelBasic>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyInterfaceBoard, ApiEntities.GalaxyInterfaceBoard>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyInterfaceBoard, ApiEntities.GalaxyInterfaceBoardBasic>().ReverseMap();
            this.CreateMap<RequestModels.GalaxyInterfaceBoardReq, WcfEntities.GalaxyInterfaceBoard>().ReverseMap();
            this.CreateMap<RequestModels.GalaxyInterfaceBoardPutReq, WcfEntities.GalaxyInterfaceBoard>().ReverseMap();

            //this.CreateMap<WcfEntities.GalaxyInterfaceBoardBasic, ApiEntities.GalaxyInterfaceBoardBasic>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyInterfaceBoardSection, ApiEntities.GalaxyInterfaceBoardSection>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyInterfaceBoardSection, ApiEntities.GalaxyInterfaceBoardSectionBasic>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyInterfaceBoardSection, ApiEntities.GalaxyInterfaceBoardSectionMinimal>().ReverseMap();
            this.CreateMap<RequestModels.GalaxyInterfaceBoardSectionReq, WcfEntities.GalaxyInterfaceBoardSection>().ReverseMap();
            this.CreateMap<RequestModels.GalaxyInterfaceBoardSectionPutReq, WcfEntities.GalaxyInterfaceBoardSection>().ReverseMap();


            //this.CreateMap<WcfEntities.GalaxyInterfaceBoardSectionBasic, ApiEntities.GalaxyInterfaceBoardSectionBasic>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyInterfaceBoardSectionNode, ApiEntities.GalaxyInterfaceBoardSectionNode>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyInterfaceBoardSectionNode, ApiEntities.GalaxyInterfaceBoardSectionNodeBasic>().ReverseMap();
            this.CreateMap<RequestModels.GalaxyInterfaceBoardSectionNodeReq, WcfEntities.GalaxyInterfaceBoardSectionNode>().ReverseMap();
            this.CreateMap<RequestModels.GalaxyInterfaceBoardSectionNodePutReq, WcfEntities.GalaxyInterfaceBoardSectionNode>().ReverseMap();
            //this.CreateMap<WcfEntities.GalaxyInterfaceBoardSectionNodeBasic, ApiEntities.GalaxyInterfaceBoardSectionNodeBasic>().ReverseMap();

            this.CreateMap<WcfEntities.GalaxyHardwareModule, ApiEntities.GalaxyHardwareModule>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyHardwareModule, ApiEntities.GalaxyHardwareModuleBasic>().ReverseMap();
            this.CreateMap<RequestModels.GalaxyHardwareModuleReq, WcfEntities.GalaxyHardwareModule>().ReverseMap();
            this.CreateMap<RequestModels.GalaxyHardwareModulePutReq, WcfEntities.GalaxyHardwareModule>().ReverseMap();
            //this.CreateMap<WcfEntities.GalaxyHardwareModuleBasic, ApiEntities.GalaxyHardwareModuleBasic>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyHardwareModuleType, ApiEntities.GalaxyHardwareModuleType>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyHardwareModuleType, ApiEntities.GalaxyHardwareModuleTypeBasic>().ReverseMap();
            //this.CreateMap<WcfEntities.GalaxyHardwareModuleTypeBasic, ApiEntities.GalaxyHardwareModuleTypeBasic>().ReverseMap();

            this.CreateMap<WcfEntities.GalaxyPanel, ApiEntities.GalaxyPanel>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyPanel, ApiEntities.GalaxyPanelBasic>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyPanel, ApiEntities.GalaxyPanelMinimal>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyPanel, ResponseModels.GalaxyPanelResp>().ReverseMap();
            this.CreateMap<RequestModels.GalaxyPanelReq, WcfEntities.GalaxyPanel>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyPanel, RequestModels.GalaxyPanelPutReq>().ReverseMap();

            //this.CreateMap<WcfEntities.GalaxyPanelBasic, ApiEntities.GalaxyPanelBasic>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyPanelAlertEvent, ApiEntities.GalaxyPanelAlertEvent>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyPanelAlertEvent, ApiEntities.GalaxyPanelAlertEventBasic>().ReverseMap();

            this.CreateMap<RequestModels.GalaxyPanelAlertEventReq, WcfEntities.GalaxyPanelAlertEvent>().ReverseMap();
            this.CreateMap<RequestModels.GalaxyPanelAlertEventPutReq, WcfEntities.GalaxyPanelAlertEvent>().ReverseMap();

            //this.CreateMap<WcfEntities.GalaxyPanelAlertEventBasic, ApiEntities.GalaxyPanelAlertEventBasic>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyPanelAlertEventType, ApiEntities.GalaxyPanelAlertEventType>().ReverseMap();
            //            this.CreateMap<WcfEntities.GalaxyPanelAlertEventType, ApiEntities.GalaxyPanelAlertEventTypeBasic>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyPanelAlertEventType, ApiEntities.GalaxyPanelAlertEventTypeBasic>().ForMember(
                dest => dest.AlertEventType,
                opt => opt.MapFrom(src => src.Tag)
            ).ReverseMap();
            //this.CreateMap<WcfEntities.GalaxyPanelAlertEventTypeBasic, ApiEntities.GalaxyPanelAlertEventTypeBasic>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyPanelEditingData, ApiEntities.GalaxyPanelEditingData>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyPanelEditingData, ApiEntities.GalaxyPanelEditingDataBasic>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyPanelEditingData, ApiEntities.GalaxyPanelEditingDataCommonBasic>().ReverseMap();

            this.CreateMap<WcfEntities.GalaxyPanelModel, ApiEntities.GalaxyPanelModel>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyPanelModel, ApiEntities.GalaxyPanelModelBasic>().ReverseMap();
            //this.CreateMap<WcfEntities.GalaxyPanelModelBasic, ApiEntities.GalaxyPanelModelBasic>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyPanelModelGalaxyPanelCommand, ApiEntities.GalaxyPanelModelGalaxyPanelCommand>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyPanelCommand, ApiEntities.GalaxyPanelCommand>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyPanelCommand, ApiEntities.GalaxyPanelCommandBasic>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyPanelCommandBasic, ApiEntities.GalaxyPanelCommandBasic>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyPanelSite, ApiEntities.GalaxyPanelSite>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyPanelSite, ApiEntities.GalaxyPanelSiteBasic>().ReverseMap();
            //this.CreateMap<WcfEntities.GalaxyPanelSiteBasic, ApiEntities.GalaxyPanelSiteBasic>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyTimePeriod, RequestModels.GalaxyTimePeriodReq>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyTimePeriod, RequestModels.GalaxyTimePeriodPutReq>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyTimePeriod, ApiEntities.GalaxyTimePeriod>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyTimePeriod, ApiEntities.GalaxyTimePeriodBasic>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyTimePeriod, ResponseModels.GalaxyTimePeriodResp>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyTimePeriodListItem, ApiEntities.GalaxyTimePeriodListItem>().ReverseMap();
            
            //this.CreateMap<WcfEntities.GalaxyTimePeriodBasic, ApiEntities.GalaxyTimePeriodBasic>().ReverseMap();

            this.CreateMap<WcfEntities.gcsApplication, ApiEntities.gcsApplication>().ReverseMap();
            this.CreateMap<WcfEntities.gcsApplicationBasic, ApiEntities.gcsApplicationBasic>().ReverseMap();
            //this.CreateMap<WcfEntities.gcsEntityRoleBasic, ApiEntities.gcsEntityRoleBasic>().ReverseMap();
            //this.CreateMap<WcfEntities.gcsEntityRoleMinimal, ApiEntities.gcsEntityRoleMinimal>().ReverseMap();
            this.CreateMap<WcfEntities.gcsApplication, ApiEntities.gcsApplicationBasic>().ReverseMap();

            this.CreateMap<WcfEntities.gcsApplication, RequestModels.ApplicationReq>().ReverseMap();
            this.CreateMap<WcfEntities.EntityRoleEditingData, ApiEntities.EntityRoleEditingData>().ReverseMap();
            this.CreateMap<WcfEntities.EntityRoleEditingData, ApiEntities.EntityRoleEditingDataMinimal>().ReverseMap();
            this.CreateMap<WcfEntities.gcsApplicationPermissionsMinimal, ApiEntities.gcsApplicationPermissionsMinimal>().ReverseMap();
            
            this.CreateMap<WcfEntities.gcsBinaryResource, RequestModels.BinaryResourceReq>().ReverseMap();
            this.CreateMap<WcfEntities.gcsBinaryResource, ApiEntities.gcsBinaryResourceMinimal>().ReverseMap();

            this.CreateMap<WcfEntities.gcsEntity, RequestModels.EntityReq>().ReverseMap();
            this.CreateMap<WcfEntities.gcsEntity, RequestModels.EntityPutReq>().ReverseMap();
            this.CreateMap<WcfEntities.gcsEntityEx, RequestModels.EntityPutReq>().ReverseMap();
            //this.CreateMap<WcfEntities.gcsEntityApplication, RequestModels.EntityApplicationReq>().ReverseMap();
            //this.CreateMap<WcfEntities.gcsEntityApplication, RequestModels.EntityApplicationPutReq>().ReverseMap();
            //this.CreateMap<WcfEntities.gcsEntityApplicationRole, RequestModels.EntityApplicationRoleReq>().ReverseMap();
            //this.CreateMap<WcfEntities.gcsEntityApplicationRole, RequestModels.EntityApplicationRolePutReq>().ReverseMap();

            this.CreateMap<WcfEntities.EntityRoleFilterData, ApiEntities.EntityRoleFilterData>().ReverseMap();
            this.CreateMap<WcfEntities.EntityRoleFilterData, ApiEntities.EntityRoleFilterDataMinimal>().ReverseMap();
            this.CreateMap<WcfEntities.gcsEntityFilterData, ApiEntities.gcsEntityFilterData>().ReverseMap();
            this.CreateMap<WcfEntities.gcsEntityFilterData, ApiEntities.gcsEntityFilterDataMinimal>().ReverseMap();
            this.CreateMap<WcfEntities.RoleFilters, ApiEntities.RoleFilters>().ReverseMap();
            this.CreateMap<WcfEntities.RoleFilters, RequestModels.RoleFiltersReq>().ReverseMap();
            this.CreateMap<WcfEntities.RoleFilters, RequestModels.RoleFiltersPutReq>().ReverseMap();

            this.CreateMap<WcfEntities.gcsPermission, RequestModels.PermissionReq>().ReverseMap();
            this.CreateMap<WcfEntities.gcsPermissionCategory, RequestModels.PermissionCategoryReq>().ReverseMap();
            this.CreateMap<WcfEntities.gcsRole, RequestModels.RoleReq>().ReverseMap();
            this.CreateMap<WcfEntities.gcsRole, RequestModels.RolePutReq>().ReverseMap();
            //this.CreateMap<WcfEntities.gcsRolePermission, RequestModels.RolePermissionReq>().ReverseMap();
            //this.CreateMap<WcfEntities.gcsRolePermission, RequestModels.RolePermissionPutReq>().ReverseMap();
            this.CreateMap<WcfEntities.gcsRolePermission, RequestModels.RolePermissionReq>().ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.PermissionId)
            ).ReverseMap();
            this.CreateMap<WcfEntities.gcsRolePermission, RequestModels.RolePermissionPutReq>().ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.PermissionId)
            ).ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.PermissionName)
            ).ReverseMap();
            this.CreateMap<WcfEntities.RoleAccessPortal, ApiEntities.RoleAccessPortal>().ReverseMap();
            //this.CreateMap<WcfEntities.RoleAccessPortal, RequestModels.RoleAccessPortalPutReq>().ReverseMap();
            this.CreateMap<WcfEntities.RoleAccessPortal, RequestModels.RoleAccessPortalPutReq>().ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.AccessPortalUid)
            ).ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.PortalName)
            ).ReverseMap();
            //this.CreateMap<WcfEntities.RoleAccessPortal, RequestModels.RoleAccessPortalReq>().ReverseMap();
            this.CreateMap<WcfEntities.RoleAccessPortal, RequestModels.RoleAccessPortalReq>().ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.AccessPortalUid)
            ).ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.PortalName)
            ).ReverseMap();
            this.CreateMap<WcfEntities.RoleAccessPortal, ApiEntities.RoleAccessPortalBasic>().ReverseMap();
            this.CreateMap<WcfEntities.RoleInputDevice, ApiEntities.RoleInputDevice>().ReverseMap();
            //this.CreateMap<WcfEntities.RoleInputDevice, RequestModels.RoleInputDevicePutReq>().ReverseMap();
            //this.CreateMap<WcfEntities.RoleInputDevice, RequestModels.RoleInputDeviceReq>().ReverseMap();
            this.CreateMap<WcfEntities.RoleInputDevice, RequestModels.RoleInputDevicePutReq>().ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.InputDeviceUid)
            ).ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.InputName)
            ).ReverseMap();
            this.CreateMap<WcfEntities.RoleInputDevice, RequestModels.RoleInputDeviceReq>().ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.InputDeviceUid)
            ).ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.InputName)
            ).ReverseMap();
            this.CreateMap<WcfEntities.RoleInputDevice, ApiEntities.RoleInputDeviceBasic>().ReverseMap();
            this.CreateMap<WcfEntities.RoleOutputDevice, ApiEntities.RoleOutputDevice>().ReverseMap();
            //this.CreateMap<WcfEntities.RoleOutputDevice, RequestModels.RoleOutputDevicePutReq>().ReverseMap();
            //this.CreateMap<WcfEntities.RoleOutputDevice, RequestModels.RoleOutputDeviceReq>().ReverseMap();
            this.CreateMap<WcfEntities.RoleOutputDevice, RequestModels.RoleOutputDevicePutReq>().ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.OutputDeviceUid)
            ).ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.OutputName)
            ).ReverseMap();
            this.CreateMap<WcfEntities.RoleOutputDevice, RequestModels.RoleOutputDeviceReq>().ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.OutputDeviceUid)
            ).ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.OutputName)
            ).ReverseMap();
            this.CreateMap<WcfEntities.RoleOutputDevice, ApiEntities.RoleOutputDeviceBasic>().ReverseMap();
            this.CreateMap<WcfEntities.RoleCluster, ApiEntities.RoleCluster>().ReverseMap();
            //this.CreateMap<WcfEntities.RoleCluster, RequestModels.RoleClusterPutReq>().ReverseMap();
            //this.CreateMap<WcfEntities.RoleCluster, RequestModels.RoleClusterReq>().ReverseMap();
            this.CreateMap<WcfEntities.RoleCluster, RequestModels.RoleClusterPutReq>().ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.ClusterUid)
            ).ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.ClusterName)
            ).ReverseMap();
            this.CreateMap<WcfEntities.RoleCluster, RequestModels.RoleClusterReq>().ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.ClusterUid)
            ).ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.ClusterName)
            ).ReverseMap();
            this.CreateMap<WcfEntities.RoleCluster, ApiEntities.RoleClusterBasic>().ReverseMap();

            this.CreateMap<WcfEntities.RoleSite, ApiEntities.RoleSite>().ReverseMap();
            //this.CreateMap<WcfEntities.RoleSite, RequestModels.RoleSitePutReq>().ReverseMap();
            //this.CreateMap<WcfEntities.RoleSite, RequestModels.RoleSiteReq>().ReverseMap();
            this.CreateMap<WcfEntities.RoleSite, RequestModels.RoleSitePutReq>().ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.SiteUid)
            ).ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.SiteName)
            ).ReverseMap();

            this.CreateMap<WcfEntities.RoleSite, RequestModels.RoleSiteReq>().ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.SiteUid)
            ).ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.SiteName)
            ).ReverseMap();

            //this.CreateMap<WcfEntities.RoleSite, ApiEntities.RoleSiteBasic>().ReverseMap();
            this.CreateMap<WcfEntities.RoleRegion, ApiEntities.RoleRegion>().ReverseMap();
            //this.CreateMap<WcfEntities.RoleRegion, RequestModels.RoleRegionPutReq>().ReverseMap();
            //this.CreateMap<WcfEntities.RoleRegion, RequestModels.RoleRegionReq>().ReverseMap();
            this.CreateMap<WcfEntities.RoleRegion, RequestModels.RoleRegionPutReq>().ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.RegionUid)
            ).ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.RegionName)
            ).ReverseMap();

            this.CreateMap<WcfEntities.RoleRegion, RequestModels.RoleRegionReq>().ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.RegionUid)
            ).ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.RegionName)
            ).ReverseMap();
            //this.CreateMap<WcfEntities.RoleSite, ApiEntities.RoleSiteBasic>().ReverseMap();






            this.CreateMap<WcfEntities.RoleInputOutputGroup, ApiEntities.RoleInputOutputGroup>().ReverseMap();
            //this.CreateMap<WcfEntities.RoleInputOutputGroup, RequestModels.RoleInputOutputGroupPutReq>().ReverseMap();
            //this.CreateMap<WcfEntities.RoleInputOutputGroup, RequestModels.RoleInputOutputGroupReq>().ReverseMap();
            this.CreateMap<WcfEntities.RoleInputOutputGroup, RequestModels.RoleInputOutputGroupPutReq>().ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.InputOutputGroupUid)
            ).ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.InputOutputGroupName)
            ).ReverseMap();
            this.CreateMap<WcfEntities.RoleInputOutputGroup, RequestModels.RoleInputOutputGroupReq>().ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.InputOutputGroupUid)
            ).ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.InputOutputGroupName)
            ).ReverseMap();
            this.CreateMap<WcfEntities.RoleInputOutputGroup, ApiEntities.RoleInputOutputGroupBasic>().ReverseMap();
            this.CreateMap<WcfEntities.gcsSystem, RequestModels.SystemReq>().ReverseMap();
            this.CreateMap<WcfEntities.gcsSystem, RequestModels.SystemPutReq>().ReverseMap();

            this.CreateMap<WcfEntities.gcsUserSave, RequestModels.UserPostReq>().ReverseMap();
            this.CreateMap<WcfEntities.gcsUser, RequestModels.UserPutReq>().ReverseMap();
            this.CreateMap<WcfEntities.gcsUser, ResponseModels.gcsUserResp>().ReverseMap();
            this.CreateMap<WcfEntities.gcsUserEditingData, ApiEntities.gcsUserEditingData>();//.ReverseMap();
            this.CreateMap<WcfEntities.gcsUserEditingEntityData, ApiEntities.gcsUserEditingEntityData>();//.ReverseMap();
            this.CreateMap<WcfEntities.gcsUserEditingApplicationData, ApiEntities.gcsUserEditingApplicationData>();//.ReverseMap();
            this.CreateMap<WcfEntities.gcsUserEditingUserRequirementData, ApiEntities.gcsUserEditingUserRequirementData>();//.ReverseMap();
            this.CreateMap<WcfEntities.UserEditingRoleData, ApiEntities.UserEditingRoleData>();//.ReverseMap();
            this.CreateMap<WcfEntities.UserEntityPermissions, ApiEntities.UserEntityPermissions>().ReverseMap();

            this.CreateMap<WcfEntities.gcsUserEntity, RequestModels.UserEntityPutReq>().ReverseMap();
            this.CreateMap<WcfEntities.gcsUserEntityRole, RequestModels.UserEntityRolePutReq>().ReverseMap();

            this.CreateMap<WcfEntities.gcsUserEntitySave, RequestModels.UserEntityPostReq>().ReverseMap();
            this.CreateMap<WcfEntities.gcsUserEntityRoleSave, RequestModels.UserEntityRolePostReq>().ReverseMap();
            this.CreateMap<WcfEntities.gcsUserEntityRole, RequestModels.UserEntityRolePostReq>().ReverseMap();
            this.CreateMap<WcfEntities.gcsUserRequirement, RequestModels.UserRequirementReq>().ReverseMap();
            this.CreateMap<WcfEntities.gcsUserRequirement, RequestModels.UserRequirementPutReq>().ReverseMap();
            this.CreateMap<WcfEntities.UserEntity, RequestModels.UserEntityPostReq>().ReverseMap();
            this.CreateMap<WcfEntities.UserEntity, RequestModels.UserEntityPutReq>().ReverseMap();

            this.CreateMap<WcfEntities.gcsApplicationAudit, ApiEntities.gcsApplicationAudit>().ReverseMap();
            this.CreateMap<WcfEntities.gcsApplicationAuditType, ApiEntities.gcsApplicationAuditType>().ReverseMap();
            this.CreateMap<WcfEntities.gcsApplicationSetting, ApiEntities.gcsApplicationSetting>().ReverseMap();
            this.CreateMap<WcfEntities.gcsApplicationSetting, ApiEntities.gcsApplicationSettingBasic>().ReverseMap();
            this.CreateMap<WcfEntities.gcsApplicationSetting, RequestModels.gcsApplicationSettingPostReq>().ReverseMap();
            this.CreateMap<WcfEntities.gcsApplicationSetting, RequestModels.gcsApplicationSettingPutReq>().ReverseMap();
            this.CreateMap<WcfEntities.gcsAudit, ApiEntities.gcsAudit>().ReverseMap();
            this.CreateMap<WcfEntities.gcsAuditXml, ApiEntities.gcsAuditXml>().ReverseMap();
            this.CreateMap<WcfEntities.gcsBinaryResource, ApiEntities.gcsBinaryResource>().ReverseMap();
            this.CreateMap<WcfEntities.gcsBinaryResource, ApiEntities.gcsBinaryResourceBasic>().ReverseMap();
            this.CreateMap<WcfEntities.gcsBinaryResourceBasic, ApiEntities.gcsBinaryResourceBasic>().ReverseMap();
            this.CreateMap<WcfEntities.gcsEntity, ApiEntities.gcsEntity>().ReverseMap();
            this.CreateMap<WcfEntities.gcsEntityEx, ApiEntities.gcsEntityEx>().ReverseMap();
            this.CreateMap<WcfEntities.gcsEntityCounts, ApiEntities.gcsEntityCounts>().ReverseMap();
            this.CreateMap<WcfEntities.gcsEntity, ApiEntities.gcsEntityBasic>().ReverseMap();
            this.CreateMap<WcfEntities.gcsEntityListItem, ApiEntities.gcsEntityListItem>().ReverseMap();
            this.CreateMap<WcfEntities.gcsEntityEx, ApiEntities.gcsEntityExBasic>().ReverseMap();
            this.CreateMap<WcfEntities.gcsEntityBasic, ApiEntities.gcsEntityBasic>().ReverseMap();
            this.CreateMap<WcfEntities.gcsEntityBasic, ApiEntities.gcsEntityExBasic>().ReverseMap();
            this.CreateMap<WcfEntities.gcsEntityExBasic, ApiEntities.gcsEntityExBasic>().ReverseMap();
            this.CreateMap<WcfEntities.gcsEntityIdProducer, ApiEntities.gcsEntityIdProducer>().ReverseMap();
            this.CreateMap<WcfEntities.gcsEnumNamespace, ApiEntities.gcsEnumNamespace>().ReverseMap();
            this.CreateMap<WcfEntities.gcsEnumValue, ApiEntities.gcsEnumValue>().ReverseMap();
            this.CreateMap<WcfEntities.gcsImageType, ApiEntities.gcsImageType>().ReverseMap();
            this.CreateMap<WcfEntities.gcsLanguage, ApiEntities.gcsLanguage>().ReverseMap();
            this.CreateMap<WcfEntities.gcsLanguage, ApiEntities.gcsLanguageBasic>().ReverseMap();
            this.CreateMap<WcfEntities.gcsLanguageBasic, ApiEntities.gcsLanguageBasic>().ReverseMap();

            this.CreateMap<WcfEntities.gcsLargeObjectStorage, ApiEntities.gcsLargeObjectStorage>().ReverseMap();
            this.CreateMap<WcfEntities.gcsLargeObjectStorage, ApiEntities.gcsLargeObjectStorageBasic>().ReverseMap();
            this.CreateMap<WcfEntities.gcsLargeObjectStorageBasic, ApiEntities.gcsLargeObjectStorageBasic>().ReverseMap();
            this.CreateMap<WcfEntities.gcsLargeObjectStorage, RequestModels.gcsLargeObjectStoragePostReq>().ReverseMap();
            this.CreateMap<WcfEntities.gcsLargeObjectStorage, RequestModels.gcsLargeObjectStoragePutReq>().ReverseMap();

            this.CreateMap<WcfEntities.gcsLog, ApiEntities.gcsLog>().ReverseMap();
            this.CreateMap<WcfEntities.gcsMenuItem, ApiEntities.gcsMenuItem>().ReverseMap();
            this.CreateMap<WcfEntities.gcsPermission, ApiEntities.gcsPermission>().ReverseMap();
            this.CreateMap<WcfEntities.gcsPermission, ApiEntities.gcsPermissionBasic>().ReverseMap();
            this.CreateMap<WcfEntities.gcsPermissionBasic, ApiEntities.gcsPermissionBasic>().ReverseMap();
            this.CreateMap<WcfEntities.gcsPermissionMinimal, ApiEntities.gcsPermissionMinimal>().ReverseMap();
            this.CreateMap<WcfEntities.gcsPermissionCategory, ApiEntities.gcsPermissionCategory>().ReverseMap();
            this.CreateMap<WcfEntities.gcsPermissionCategory, ApiEntities.gcsPermissionCategoryBasic>().ReverseMap();
            this.CreateMap<WcfEntities.gcsPermissionCategoryBasic, ApiEntities.gcsPermissionCategoryBasic>().ReverseMap();
            this.CreateMap<WcfEntities.gcsPermissionCategoryMinimal, ApiEntities.gcsPermissionCategoryMinimal>().ReverseMap();
            this.CreateMap<WcfEntities.gcsPermissionType, ApiEntities.gcsPermissionType>().ReverseMap();
            this.CreateMap<WcfEntities.gcsReferenceTable, ApiEntities.gcsReferenceTable>().ReverseMap();
            this.CreateMap<WcfEntities.gcsResourceImage, ApiEntities.gcsResourceImage>().ReverseMap();
            this.CreateMap<WcfEntities.gcsResourceString, ApiEntities.gcsResourceString>().ReverseMap();
            this.CreateMap<WcfEntities.gcsResourceStringLanguage, ApiEntities.gcsResourceStringLanguage>().ReverseMap();
            this.CreateMap<WcfEntities.gcsRole, ApiEntities.gcsRole>().ReverseMap();
            this.CreateMap<WcfEntities.gcsRole, ApiEntities.gcsRoleBasic>().ReverseMap();
            this.CreateMap<WcfEntities.gcsRolePermission, ApiEntities.gcsRolePermission>().ReverseMap();
            this.CreateMap<WcfEntities.gcsRolePermission, ApiEntities.gcsRolePermissionBasic>().ReverseMap();
            this.CreateMap<WcfEntities.gcsSecurityControl, ApiEntities.gcsSecurityControl>().ReverseMap();
            this.CreateMap<WcfEntities.gcsSerializedObject, ApiEntities.gcsSerializedObject>().ReverseMap();
            this.CreateMap<WcfEntities.gcsSerializedObject, ApiEntities.gcsSerializedObjectBasic>().ReverseMap();
            this.CreateMap<WcfEntities.gcsSerializedObjectBasic, ApiEntities.gcsSerializedObjectBasic>().ReverseMap();
            this.CreateMap<WcfEntities.gcsSerializedObject, RequestModels.gcsSerializedObjectPostReq>().ReverseMap();
            this.CreateMap<WcfEntities.gcsSerializedObject, RequestModels.gcsSerializedObjectPutReq>().ReverseMap();

            this.CreateMap<WcfEntities.gcsSetting, ApiEntities.gcsSetting>().ReverseMap();
            this.CreateMap<WcfEntities.gcsSetting, ApiEntities.gcsSettingBasic>().ReverseMap();
            this.CreateMap<WcfEntities.gcsSetting, RequestModels.gcsSettingPostReq>().ReverseMap();
            this.CreateMap<WcfEntities.gcsSetting, RequestModels.gcsSettingPutReq>().ReverseMap();
            this.CreateMap<WcfEntities.gcsSystem, ApiEntities.gcsSystem>().ReverseMap();
            this.CreateMap<WcfEntities.gcsUser, ApiEntities.gcsUser>().ReverseMap();
            this.CreateMap<WcfEntities.gcsUserBasic, ApiEntities.gcsUserBasic>().ReverseMap();
            this.CreateMap<WcfEntities.gcsUserBasic, ApiEntities.gcsUserBasicRoles>().ReverseMap();
            this.CreateMap<WcfEntities.gcsUserBasicRoles, ApiEntities.gcsUserBasicRoles>().ReverseMap();
            this.CreateMap<WcfEntities.gcsUserEntity, ApiEntities.gcsUserEntity>().ReverseMap();
            this.CreateMap<WcfEntities.gcsUserEntity, ApiEntities.gcsUserEntityBasic>().ReverseMap();
            this.CreateMap<WcfEntities.gcsUserEntityMinimal, ApiEntities.gcsUserEntityMinimal>().ReverseMap();
            this.CreateMap<WcfEntities.gcsUserEntityRole, ApiEntities.gcsUserEntityRole>().ReverseMap();
            this.CreateMap<WcfEntities.gcsUserEntityRole, ApiEntities.gcsUserEntityRoleBasic>().ReverseMap();
            this.CreateMap<WcfEntities.gcsUserEntityRoleMinimal, ApiEntities.gcsUserEntityRoleMinimal>().ReverseMap();
            this.CreateMap<WcfEntities.gcsUserOldPassword, ApiEntities.gcsUserOldPassword>().ReverseMap();
            this.CreateMap<WcfEntities.gcsUserRequirement, ApiEntities.gcsUserRequirement>().ReverseMap();
            this.CreateMap<WcfEntities.gcsUserSecurityQuestion, ApiEntities.gcsUserSecurityQuestion>().ReverseMap();
            this.CreateMap<WcfEntities.gcsUserSession, ApiEntities.gcsUserSession>().ReverseMap();
            this.CreateMap<WcfEntities.gcsUserSetting, ApiEntities.gcsUserSetting>().ReverseMap();
            this.CreateMap<WcfEntities.gcsUserSetting, ApiEntities.gcsUserSettingBasic>().ReverseMap();
            this.CreateMap<WcfEntities.gcsUserSetting, RequestModels.UserSettingPostReq>().ReverseMap();
            this.CreateMap<WcfEntities.gcsUserSetting, RequestModels.UserSettingPutReq>().ReverseMap();
            this.CreateMap<WcfEntities.GetHardwareAddressParameters, ApiEntities.GetHardwareAddressParameters>().ReverseMap();
            this.CreateMap<WcfEntities.GetParameters, ApiEntities.GetParameters>().ReverseMap();
            this.CreateMap(typeof(WcfEntities.GetParameters<>), typeof(ApiEntities.GetParameters<>)).ReverseMap();
            this.CreateMap<WcfEntities.GetParametersWithPhoto, ApiEntities.GetParametersWithPhoto>().ReverseMap();
            this.CreateMap(typeof(WcfEntities.GetParametersWithPhoto<>), typeof(ApiEntities.GetParametersWithPhoto<>)).ReverseMap();
            this.CreateMap<WcfEntities.GetCpuConnectionsParameters, ApiEntities.GetCpuConnectionsParameters>().ReverseMap();

            this.CreateMap<WcfEntities.GetAllSubscriptionsResponse, ApiEntities.GetAllSubscriptionsResponse>().ReverseMap();
            this.CreateMap<WcfEntities.ChildrenSubscription, ApiEntities.ChildrenSubscription>().ReverseMap();
            this.CreateMap<WcfEntities.SubscriptionData, ApiEntities.SubscriptionData>().ReverseMap();
            this.CreateMap<WcfEntities.FriendlyLicenseDetails, ApiEntities.FriendlyLicenseDetails>().ReverseMap();
            this.CreateMap<WcfEntities.SubscriptionConfig, ApiEntities.SubscriptionConfig>().ReverseMap();
            this.CreateMap<WcfEntities.PrintDispatcher, ApiEntities.PrintDispatcher>().ReverseMap();
            this.CreateMap<WcfEntities.Printer, ApiEntities.Printer>().ReverseMap();
            this.CreateMap<WcfEntities.PrinterDispatchersResponse, ApiEntities.PrinterDispatchersResponse>().ReverseMap();
            this.CreateMap<WcfEntities.SetMasterLicenseData, ApiEntities.SetMasterLicenseData>().ReverseMap();
            this.CreateMap<WcfEntities.SetMasterLicenseData.LicenseDetails, ApiEntities.SetMasterLicenseData.LicenseDetails>().ReverseMap();
            this.CreateMap<WcfEntities.PreviewData, ApiEntities.PreviewData>().ReverseMap();
            this.CreateMap<WcfEntities.IdProducerPrintRequestParameters, ApiEntities.IdProducerPrintRequestParameters>().ReverseMap();
            this.CreateMap<WcfEntities.CreatedPrintRequest, ApiEntities.CreatedPrintRequest>().ReverseMap();
            this.CreateMap<WcfEntities.ServerVersionNumber, ApiEntities.ServerVersionNumber>().ReverseMap();


            this.CreateMap<WcfEntities.InputDevice, ApiEntities.InputDevice>().ReverseMap();
            this.CreateMap<WcfEntities.InputDevice, ApiEntities.InputDeviceBasic>().ForMember(dest => dest.PhotoImage, opt => opt.MapFrom(src => src.gcsBinaryResource.BinaryResource));
            this.CreateMap<WcfEntities.InputDevice, ResponseModels.InputDeviceResp>().ReverseMap();
            this.CreateMap<WcfEntities.InputDevice, RequestModels.InputDevicePutReq>().ReverseMap();
            this.CreateMap<WcfEntities.InputDevice, ApiEntities.InputDeviceSimpleItem>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyInputDevice, ApiEntities.GalaxyInputDevice>().ReverseMap();
            this.CreateMap<WcfEntities.InputDeviceAlertEvent, ApiEntities.InputDeviceAlertEvent>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyInputDeviceTimeSchedule, ApiEntities.GalaxyInputDeviceTimeSchedule>().ReverseMap();
            this.CreateMap<WcfEntities.InputDeviceGalaxyHardwareAddress, ApiEntities.InputDeviceGalaxyHardwareAddress>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyInputArmingInputOutputGroup, ApiEntities.GalaxyInputArmingInputOutputGroup>().ReverseMap();
            this.CreateMap<WcfEntities.InputDeviceListItemCommands, ApiEntities.InputDeviceListItemCommands>().ReverseMap();


            this.CreateMap<RequestModels.GalaxyInputDevicePutReq, WcfEntities.GalaxyInputDevice>().ReverseMap();
            this.CreateMap<RequestModels.InputDeviceAlertEventPutReq, WcfEntities.InputDeviceAlertEvent>().ReverseMap();
            this.CreateMap<RequestModels.GalaxyInputDeviceTimeSchedulePutReq, WcfEntities.GalaxyInputDeviceTimeSchedule>().ReverseMap();
            this.CreateMap<RequestModels.InputDeviceGalaxyHardwareAddressPutReq, WcfEntities.InputDeviceGalaxyHardwareAddress>().ReverseMap();
            this.CreateMap<RequestModels.GalaxyInputArmingInputOutputGroupPutReq, WcfEntities.GalaxyInputArmingInputOutputGroup>().ReverseMap();

            this.CreateMap<WcfEntities.GalaxyInputDeviceTimeSchedule, ApiEntities.GalaxyInputDeviceTimeSchedule>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyInputDeviceTimeSchedule, ApiEntities.GalaxyInputDeviceTimeScheduleBasic>().ReverseMap();






            this.CreateMap<WcfEntities.GalaxyInputDevice, ApiEntities.GalaxyInputDeviceBasic>().ReverseMap();
            this.CreateMap<WcfEntities.InputDeviceEventProperty, ApiEntities.InputDeviceEventPropertyBasic>().ReverseMap();
            this.CreateMap<WcfEntities.InputDeviceEventProperty, ApiEntities.InputDeviceEventProperty>().ReverseMap();
            this.CreateMap<WcfEntities.InputCommand, ApiEntities.InputCommandBasic>().ReverseMap();
            this.CreateMap<WcfEntities.InputCommandBasic, ApiEntities.InputCommandBasic>().ReverseMap();
            this.CreateMap<WcfEntities.InputDeviceAlertEvent, ApiEntities.InputDeviceAlertEventBasic>().ReverseMap();
            this.CreateMap<WcfEntities.InputDeviceGalaxyHardwareAddress, ApiEntities.InputDeviceGalaxyHardwareAddressBasic>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyInputArmingInputOutputGroup, ApiEntities.GalaxyInputArmingInputOutputGroupBasic>().ReverseMap();
            this.CreateMap<WcfEntities.InputDeviceAlertEventType, ApiEntities.InputDeviceAlertEventTypeBasic>().ReverseMap();
            this.CreateMap<WcfEntities.InputDeviceCommandAction, ApiEntities.InputDeviceCommandAction>().ReverseMap();

            this.CreateMap<RequestModels.InputDeviceCommandActionReq, WcfEntities.InputDeviceCommandAction>().ReverseMap();

            this.CreateMap<WcfEntities.InputDeviceGalaxyCommonEditingData, ApiEntities.InputDeviceGalaxyCommonEditingData>().ReverseMap();
            this.CreateMap<WcfEntities.InputDeviceGalaxyCommonEditingData, ApiEntities.InputDeviceGalaxyCommonEditingDataBasic>().ReverseMap();
            this.CreateMap<WcfEntities.InputDeviceHardwareSpecificEditingData, ApiEntities.InputDeviceHardwareSpecificEditingData>().ReverseMap();
            this.CreateMap<WcfEntities.InputDeviceHardwareSpecificEditingData, ApiEntities.InputDeviceHardwareSpecificEditingDataBasic>().ReverseMap();

            this.CreateMap<WcfEntities.InputDeviceGalaxyCommonEditingData, ApiEntities.InputDeviceGalaxyCommonEditingData>().ReverseMap();
            this.CreateMap<WcfEntities.InputDeviceGalaxyCommonEditingData, ApiEntities.InputDeviceGalaxyCommonEditingDataBasic>().ReverseMap();
            this.CreateMap<WcfEntities.InputDeviceSupervisionType, ApiEntities.InputDeviceSupervisionTypeBasic>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyInputMode, ApiEntities.GalaxyInputModeBasic>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyInputDelayType, ApiEntities.GalaxyInputDelayTypeBasic>().ReverseMap();

            this.CreateMap<WcfEntities.InputDeviceSelectionItem, ApiEntities.InputDeviceSelectionItem>().ReverseMap();
            this.CreateMap<WcfEntities.InputDeviceSelectionItem, ApiEntities.InputDeviceSelectionItemBasic>().ReverseMap();
            this.CreateMap<WcfEntities.InputDeviceSelectionItem, ApiEntities.InputDeviceSelectionItemMinimal>().ReverseMap();
            this.CreateMap<WcfEntities.InputDeviceSelectionItemBasic, ResponseModels.InputDeviceSelectionItemBasicResp>().ReverseMap();
            this.CreateMap<WcfEntities.InputDeviceSelectionItemBasic, ApiEntities.InputDeviceSelectionItemBasic>().ReverseMap();
//            this.CreateMap<WcfEntities.InputDeviceSelectionItemBasic, ApiEntities.InputDeviceSelectionItemMinimal>().ReverseMap();
            this.CreateMap<WcfEntities.InputDeviceSelectionItemBasic, ApiEntities.InputDeviceSelectionItemMinimal>().ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.InputDeviceUid)
            ).ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.InputName)
            ).ReverseMap();
            this.CreateMap<WcfEntities.InputDeviceSelectionItemMinimal, ApiEntities.InputDeviceSelectionItemMinimal>().ReverseMap();

            this.CreateMap<WcfEntities.OutputDevice, ApiEntities.OutputDevice>().ReverseMap();
            this.CreateMap<WcfEntities.OutputDevice, ApiEntities.OutputDeviceBasic>().ForMember(dest => dest.PhotoImage, opt => opt.MapFrom(src => src.gcsBinaryResource.BinaryResource));
            this.CreateMap<WcfEntities.OutputDevice, ResponseModels.OutputDeviceResp>().ReverseMap();
            this.CreateMap<WcfEntities.OutputDevice, RequestModels.OutputDevicePutReq>().ReverseMap();
            this.CreateMap<WcfEntities.OutputDevice, ApiEntities.OutputDeviceSimpleItem>().ReverseMap();

            this.CreateMap<WcfEntities.OutputDeviceSelectionItem, ApiEntities.OutputDeviceSelectionItem>().ReverseMap();
            this.CreateMap<WcfEntities.OutputDeviceSelectionItem, ApiEntities.OutputDeviceSelectionItemBasic>().ReverseMap();
            this.CreateMap<WcfEntities.OutputDeviceSelectionItem, ApiEntities.OutputDeviceSelectionItemMinimal>().ReverseMap();
            this.CreateMap<WcfEntities.OutputDeviceSelectionItemBasic, ResponseModels.OutputDeviceSelectionItemBasicResp>().ReverseMap();
            this.CreateMap<WcfEntities.OutputDeviceSelectionItemBasic, ApiEntities.OutputDeviceSelectionItemBasic>().ReverseMap();
            //this.CreateMap<WcfEntities.OutputDeviceSelectionItemBasic, ApiEntities.OutputDeviceSelectionItemMinimal>().ReverseMap();
            this.CreateMap<WcfEntities.OutputDeviceSelectionItemBasic, ApiEntities.OutputDeviceSelectionItemMinimal>().ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.OutputDeviceUid)
            ).ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.OutputName)
            ).ReverseMap();
            this.CreateMap<WcfEntities.OutputDeviceSelectionItemMinimal, ApiEntities.OutputDeviceSelectionItemMinimal>().ReverseMap();

            this.CreateMap<WcfEntities.GalaxyOutputDevice, ApiEntities.GalaxyOutputDevice>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyOutputDevice, ApiEntities.GalaxyOutputDeviceBasic>().ReverseMap();
            this.CreateMap<WcfEntities.OutputCommand, ApiEntities.OutputCommandBasic>().ReverseMap();
            this.CreateMap<WcfEntities.OutputCommandBasic, ApiEntities.OutputCommandBasic>().ReverseMap();
            this.CreateMap<WcfEntities.OutputDeviceListItemCommands, ApiEntities.OutputDeviceListItemCommands>().ReverseMap();

            this.CreateMap<WcfEntities.OutputDeviceGalaxyHardwareAddress, ApiEntities.OutputDeviceGalaxyHardwareAddress>().ReverseMap();
            this.CreateMap<WcfEntities.OutputDeviceGalaxyHardwareAddress, ApiEntities.OutputDeviceGalaxyHardwareAddressBasic>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyOutputDeviceInputSource, ApiEntities.GalaxyOutputDeviceInputSource>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyOutputDeviceInputSource, ApiEntities.GalaxyOutputDeviceInputSourceBasic>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyOutputDeviceInputSourceAssignment, ApiEntities.GalaxyOutputDeviceInputSourceAssignment>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyOutputDeviceInputSourceAssignment, ApiEntities.GalaxyOutputDeviceInputSourceAssignmentBasic>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyOutputDeviceInputSourceInputOutputGroup, ApiEntities.GalaxyOutputDeviceInputSourceInputOutputGroup>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyOutputDeviceInputSourceInputOutputGroup, ApiEntities.GalaxyOutputDeviceInputSourceInputOutputGroupBasic>().ReverseMap();
            this.CreateMap<WcfEntities.OutputDeviceCommandAction, ApiEntities.OutputDeviceCommandAction>().ReverseMap();

            this.CreateMap<RequestModels.OutputDeviceCommandActionReq, WcfEntities.OutputDeviceCommandAction>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyOutputMode, ApiEntities.GalaxyOutputModeBasic>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyOutputInputSourceRelationship, ApiEntities.GalaxyOutputInputSourceRelationshipBasic>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyOutputInputSourceMode, ApiEntities.GalaxyOutputInputSourceModeBasic>().ReverseMap();
            this.CreateMap<WcfEntities.GalaxyOutputInputSourceTriggerCondition, ApiEntities.GalaxyOutputInputSourceTriggerConditionBasic>().ReverseMap();


            this.CreateMap<WcfEntities.OutputDeviceGalaxyCommonEditingData, ApiEntities.OutputDeviceGalaxyCommonEditingData>().ReverseMap();
            this.CreateMap<WcfEntities.OutputDeviceGalaxyCommonEditingData, ApiEntities.OutputDeviceGalaxyCommonEditingDataBasic>().ReverseMap();

            this.CreateMap<WcfEntities.OutputDeviceHardwareSpecificEditingData, ApiEntities.OutputDeviceHardwareSpecificEditingData>().ReverseMap();
            this.CreateMap<WcfEntities.OutputDeviceHardwareSpecificEditingData, ApiEntities.OutputDeviceHardwareSpecificEditingDataBasic>().ReverseMap();

            this.CreateMap<RequestModels.GalaxyOutputDevicePutReq, WcfEntities.GalaxyOutputDevice>().ReverseMap();
            this.CreateMap<RequestModels.GalaxyOutputDeviceInputSourcePutReq, WcfEntities.GalaxyOutputDeviceInputSource>().ReverseMap();
            this.CreateMap<RequestModels.OutputDeviceGalaxyHardwareAddressPutReq, WcfEntities.OutputDeviceGalaxyHardwareAddress>().ReverseMap();
            this.CreateMap<RequestModels.GalaxyOutputDeviceInputSourceAssignmentPutReq, WcfEntities.GalaxyOutputDeviceInputSourceAssignment>().ReverseMap();
            this.CreateMap<RequestModels.GalaxyOutputDeviceInputSourceInputOutputGroupPutReq, WcfEntities.GalaxyOutputDeviceInputSourceInputOutputGroup>().ReverseMap();

            this.CreateMap<WcfEntities.InputOutputGroup, ApiEntities.InputOutputGroup>().ReverseMap();
            this.CreateMap<WcfEntities.InputOutputGroup, ApiEntities.InputOutputGroupBasic>().ReverseMap();
            this.CreateMap<WcfEntities.InputOutputGroup, ApiEntities.InputOutputGroupMinimal>().ReverseMap();
            this.CreateMap<WcfEntities.InputOutputGroup, RequestModels.InputOutputGroupPutReq>().ReverseMap();
            this.CreateMap<WcfEntities.InputOutputGroup, RequestModels.InputOutputGroupReq>().ReverseMap();
            this.CreateMap<WcfEntities.InputOutputGroup, ResponseModels.InputOutputGroupResp>().ReverseMap();

            //this.CreateMap<WcfEntities.InputOutputGroupBasic, ApiEntities.InputOutputGroupBasic>().ReverseMap();
            this.CreateMap<WcfEntities.InputOutputGroupAssignment, ApiEntities.InputOutputGroupAssignment>().ReverseMap();
            this.CreateMap<WcfEntities.InputOutputGroupAssignment, ApiEntities.InputOutputGroupAssignmentBasic>().ReverseMap();

            this.CreateMap<RequestModels.InputOutputGroupAssignmentReq, WcfEntities.InputOutputGroupAssignment>().ReverseMap();
            this.CreateMap<WcfEntities.InputOutputGroupCommandAction, ApiEntities.InputOutputGroupCommandAction>().ReverseMap();
            this.CreateMap<WcfEntities.InputOutputGroupCommandAction, RequestModels.InputOutputGroupCommandActionReq>().ReverseMap();
            this.CreateMap<WcfEntities.InputOutputGroupCommand, ApiEntities.InputOutputGroupCommandBasic>().ReverseMap();
            this.CreateMap<WcfEntities.InputOutputGroupCommandBasic, ApiEntities.InputOutputGroupCommandBasic>().ReverseMap();

            this.CreateMap<WcfEntities.InputOutputGroupSelectionItem, ApiEntities.InputOutputGroupSelectionItem>().ReverseMap();
            this.CreateMap<WcfEntities.InputOutputGroupSelectionItem, ApiEntities.InputOutputGroupSelectionItemBasic>().ReverseMap();
            //this.CreateMap<WcfEntities.InputOutputGroupSelectionItem, ApiEntities.InputOutputGroupSelectionItemMinimal>().ReverseMap();
            this.CreateMap<WcfEntities.InputOutputGroupSelectionItem, ApiEntities.InputOutputGroupSelectionItemMinimal>().ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.InputOutputGroupUid)
            ).ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.InputOutputGroupName)
            ).ReverseMap();
            this.CreateMap<WcfEntities.InputOutputGroupSelectionItemBasic, ResponseModels.InputOutputGroupSelectionItemBasicResp>().ReverseMap();
            this.CreateMap<WcfEntities.InputOutputGroupSelectionItemBasic, ApiEntities.InputOutputGroupSelectionItemBasic>().ReverseMap();
//            this.CreateMap<WcfEntities.InputOutputGroupSelectionItemBasic, ApiEntities.InputOutputGroupSelectionItemMinimal>().ReverseMap();
            this.CreateMap<WcfEntities.InputOutputGroupSelectionItemBasic, ApiEntities.InputOutputGroupSelectionItemMinimal>().ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.InputOutputGroupUid)
            ).ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.InputOutputGroupName)
            ).ReverseMap();
            this.CreateMap<WcfEntities.InputOutputGroupSelectionItemMinimal, ApiEntities.InputOutputGroupSelectionItemMinimal>().ReverseMap();

            //this.CreateMap<WcfEntities.InputOutputGroupAssignmentBasic, ApiEntities.InputOutputGroupAssignmentBasic>().ReverseMap();
            this.CreateMap<WcfEntities.InterfaceBoardSectionMode, ApiEntities.InterfaceBoardSectionMode>().ReverseMap();
            this.CreateMap<WcfEntities.InterfaceBoardSectionMode, ApiEntities.InterfaceBoardSectionModeBasic>().ReverseMap();
            this.CreateMap<WcfEntities.InterfaceBoardType, ApiEntities.InterfaceBoardType>().ReverseMap();
            this.CreateMap<WcfEntities.InterfaceBoardType, ApiEntities.InterfaceBoardTypeBasic>().ReverseMap();


            this.CreateMap<WcfEntities.License, ApiEntities.License>().ReverseMap();
            this.CreateMap<WcfEntities.LicenseCustomer, ApiEntities.LicenseCustomer>().ReverseMap();
            this.CreateMap<WcfEntities.LicenseFeature, ApiEntities.LicenseFeature>().ReverseMap();
            this.CreateMap<WcfEntities.LicenseAttribute, ApiEntities.LicenseAttribute>().ReverseMap();

            this.CreateMap<WcfEntities.LiquidCrystalDisplay, ApiEntities.LiquidCrystalDisplay>().ReverseMap();
            this.CreateMap<WcfEntities.LiquidCrystalDisplay, ApiEntities.LiquidCrystalDisplayBasic>().ReverseMap();

            this.CreateMap<WcfEntities.LiquidCrystalDisplayGalaxyHardwareAddress, ApiEntities.LiquidCrystalDisplayGalaxyHardwareAddress>().ReverseMap();
            this.CreateMap<WcfEntities.LiquidCrystalDisplayGalaxyHardwareAddress, ApiEntities.LiquidCrystalDisplayGalaxyHardwareAddressBasic>().ReverseMap();

            this.CreateMap<WcfEntities.ListItemBase, ApiEntities.ListItemBase>().ReverseMap();
            this.CreateMap<WcfEntities.Note, ApiEntities.Note>().ReverseMap();
            this.CreateMap<WcfEntities.Note, ApiEntities.NoteBasic>().ReverseMap();
            this.CreateMap<RequestModels.NotePutReq, WcfEntities.Note>().ReverseMap();
            this.CreateMap<RequestModels.NoteReq, WcfEntities.Note>().ReverseMap();

            this.CreateMap<WcfEntities.PersonSummarySearchParameters, ApiEntities.PersonSummarySearchParameters>().ReverseMap();
            this.CreateMap<WcfEntities.PagedResultBase, ApiEntities.PagedResultBase>().ReverseMap();
            this.CreateMap(typeof(WcfEntities.ArrayResponse<>), typeof(ApiEntities.ArrayResponse<>)).ReverseMap();

            this.CreateMap<WcfEntities.PersonSummary, ApiEntities.PersonSummary>().ReverseMap();
            this.CreateMap<WcfEntities.PersonSummary, ApiEntities.PersonSummaryBasic>().ReverseMap();
            this.CreateMap<WcfEntities.PersonLastUsageData, ApiEntities.PersonLastUsageData>().ReverseMap();
            this.CreateMap<WcfEntities.PersonInfoWithMissingPhotoUrl, ApiEntities.PersonInfoWithMissingPhotoUrl>().ReverseMap();
            
            this.CreateMap<WcfEntities.SaveFileParameters, ApiEntities.SaveFileParameters>().ReverseMap();
            this.CreateMap<WcfEntities.SavePhotoParameters, ApiEntities.SavePhotoParameters>().ReverseMap();
            this.CreateMap<WcfEntities.SaveFileResponse, ApiEntities.SaveFileResponse>().ReverseMap();
            this.CreateMap<WcfEntities.SavePhotoResponse, ApiEntities.SavePhotoResponse>().ReverseMap();
            this.CreateMap<WcfEntities.SaveDefaultPhotoResponse, ApiEntities.SaveDefaultPhotoResponse>().ReverseMap();
            this.CreateMap<WcfEntities.PersonSavePhotoResponse, ApiEntities.PersonSavePhotoResponse>().ReverseMap();


            this.CreateMap<WcfEntities.PersonPhoto, ApiEntities.PersonPhoto>().ReverseMap();
            this.CreateMap<WcfEntities.PersonPhoto, ApiEntities.PersonPhotoBasic>().ReverseMap();
            this.CreateMap<WcfEntities.PersonPhotoBasic, ApiEntities.PersonPhotoBasic>().ReverseMap();
            this.CreateMap<WcfEntities.PhotoLink, ApiEntities.PhotoLink>().ReverseMap();
            this.CreateMap<WcfEntities.PhotoLinks, ApiEntities.PhotoLinks>().ReverseMap();
            this.CreateMap<WcfEntities.PersonPhotoScaled, ApiEntities.PersonPhotoScaled>().ReverseMap();


            this.CreateMap<WcfEntities.Person, ApiEntities.Person>().ReverseMap();
            this.CreateMap<WcfEntities.Person, ApiEntities.PersonBasic>().ReverseMap();
            this.CreateMap<WcfEntities.Person, ResponseModels.PersonResp>().ReverseMap();

            this.CreateMap<WcfEntities.PersonEditingData, ApiEntities.PersonEditingData>().ReverseMap();
            this.CreateMap<WcfEntities.PersonEditingData, ApiEntities.PersonEditingDataBasic>().ReverseMap();
            this.CreateMap<WcfEntities.PersonEditingData, ResponseModels.PersonEditingDataBasicResp>().ReverseMap();
            
            this.CreateMap<WcfEntities.PersonRecordType, ApiEntities.PersonRecordType>().ReverseMap();
            this.CreateMap<WcfEntities.PersonRecordType, ApiEntities.PersonRecordTypeBasicResp>().ReverseMap();
            this.CreateMap<WcfEntities.PersonRecordType, ResponseModels.PersonRecordTypeBasicResp>().ReverseMap();
            this.CreateMap<WcfEntities.PersonActiveStatusType, ApiEntities.PersonActiveStatusType>().ReverseMap();
            this.CreateMap<WcfEntities.PersonActiveStatusType, ApiEntities.PersonActiveStatusTypeBasic>().ReverseMap();
            this.CreateMap<WcfEntities.PersonActiveStatusType, ResponseModels.PersonActiveStatusTypeBasicResp>().ReverseMap();
            this.CreateMap<WcfEntities.Gender, ApiEntities.Gender>().ReverseMap();
            this.CreateMap<WcfEntities.Gender, ApiEntities.GenderBasic>().ReverseMap();
            this.CreateMap<WcfEntities.Gender, ResponseModels.GenderBasicResp>().ReverseMap();
            this.CreateMap<WcfEntities.Department, ApiEntities.Department>().ReverseMap();
            this.CreateMap<WcfEntities.Department, ApiEntities.DepartmentBasic>().ReverseMap();
            this.CreateMap<WcfEntities.Department, ResponseModels.DepartmentBasicResp>().ReverseMap();
            this.CreateMap<WcfEntities.Department, RequestModels.DepartmentReq>().ReverseMap();
            this.CreateMap<WcfEntities.Department, RequestModels.DepartmentPutReq>().ReverseMap();
            this.CreateMap<WcfEntities.BadgeTemplate, ApiEntities.BadgeTemplate>().ReverseMap();
            this.CreateMap<WcfEntities.BadgeTemplate, ApiEntities.BadgeTemplateBasic>().ReverseMap();
            this.CreateMap<WcfEntities.BadgeTemplate, ResponseModels.BadgeTemplateBasicResp>().ReverseMap();
            this.CreateMap<WcfEntities.CellCarrier, ApiEntities.CellCarrier>().ReverseMap();
            this.CreateMap<WcfEntities.CellCarrier, ApiEntities.CellCarrierBasic>().ReverseMap();
            this.CreateMap<WcfEntities.CellCarrier, ResponseModels.CellCarrierBasicResp>().ReverseMap();
            this.CreateMap<WcfEntities.CommandScript, ApiEntities.CommandScript>().ReverseMap();
            this.CreateMap<WcfEntities.CommandScript, ApiEntities.CommandScriptBasic>().ReverseMap();
            this.CreateMap<WcfEntities.CommandScript, ResponseModels.CommandScriptBasicResp>().ReverseMap();
            this.CreateMap<WcfEntities.PersonActivationMode, ApiEntities.PersonActivationMode>().ReverseMap();
            this.CreateMap<WcfEntities.PersonActivationMode, ApiEntities.PersonActivationModeBasic>().ReverseMap();
            this.CreateMap<WcfEntities.PersonActivationMode, ResponseModels.PersonActivationModeBasicResp>().ReverseMap();
            this.CreateMap<WcfEntities.PersonExpirationMode, ApiEntities.PersonExpirationMode>().ReverseMap();
            this.CreateMap<WcfEntities.PersonExpirationMode, ApiEntities.PersonExpirationModeBasic>().ReverseMap();
            this.CreateMap<WcfEntities.PersonExpirationMode, ResponseModels.PersonExpirationModeBasicResp>().ReverseMap();
            this.CreateMap<WcfEntities.PersonCredentialRole, ApiEntities.PersonCredentialRole>().ReverseMap();
            this.CreateMap<WcfEntities.PersonCredentialRole, ApiEntities.PersonCredentialRoleBasic>().ReverseMap();
            this.CreateMap<WcfEntities.PersonCredentialRole, ResponseModels.PersonCredentialRoleBasicResp>().ReverseMap();
            this.CreateMap<WcfEntities.AccessPortalNoServerReplyBehavior, ApiEntities.AccessPortalNoServerReplyBehavior>().ReverseMap();
            this.CreateMap<WcfEntities.AccessPortalNoServerReplyBehavior, ApiEntities.AccessPortalNoServerReplyBehaviorBasic>().ReverseMap();
            this.CreateMap<WcfEntities.AccessPortalNoServerReplyBehavior, ResponseModels.AccessPortalNoServerReplyBehaviorBasicResp>().ReverseMap();



            this.CreateMap<WcfEntities.UserInterfacePageControlData, ApiEntities.UserInterfacePageControlData>().ReverseMap();
            this.CreateMap<WcfEntities.UserInterfacePageControlData, ApiEntities.UserInterfacePageControlDataBasic>().ReverseMap();
            this.CreateMap<WcfEntities.UserDefinedProperty, ApiEntities.UserDefinedProperty>().ReverseMap();
            this.CreateMap<WcfEntities.UserDefinedProperty, ApiEntities.UserDefinedPropertyBasic>().ReverseMap();
            this.CreateMap<WcfEntities.UserDefinedBooleanPropertyRule, ApiEntities.UserDefinedBooleanPropertyRule>().ReverseMap();
            this.CreateMap<WcfEntities.UserDefinedBooleanPropertyRule, ApiEntities.UserDefinedBooleanPropertyRuleBasic>().ReverseMap();
            this.CreateMap<WcfEntities.UserDefinedDatePropertyRule, ApiEntities.UserDefinedDatePropertyRule>().ReverseMap();
            this.CreateMap<WcfEntities.UserDefinedDatePropertyRule, ApiEntities.UserDefinedDatePropertyRuleBasic>().ReverseMap();
            this.CreateMap<WcfEntities.UserDefinedListPropertyItem, ApiEntities.UserDefinedListPropertyItem>().ReverseMap();
            this.CreateMap<WcfEntities.UserDefinedListPropertyItem, ApiEntities.UserDefinedListPropertyItemBasic>().ReverseMap();
            this.CreateMap<WcfEntities.UserDefinedListPropertyRule, ApiEntities.UserDefinedListPropertyRule>().ReverseMap();
            this.CreateMap<WcfEntities.UserDefinedListPropertyRule, ApiEntities.UserDefinedListPropertyRuleBasic>().ReverseMap();
            this.CreateMap<WcfEntities.UserDefinedNumberPropertyRule, ApiEntities.UserDefinedNumberPropertyRule>().ReverseMap();
            this.CreateMap<WcfEntities.UserDefinedNumberPropertyRule, ApiEntities.UserDefinedNumberPropertyRuleBasic>().ReverseMap();
            this.CreateMap<WcfEntities.UserDefinedPropertyType, ApiEntities.UserDefinedPropertyType>().ReverseMap();
            this.CreateMap<WcfEntities.UserDefinedPropertyType, ApiEntities.UserDefinedPropertyTypeBasic>().ReverseMap();
            this.CreateMap<WcfEntities.UserDefinedTextPropertyRule, ApiEntities.UserDefinedTextPropertyRule>().ReverseMap();
            this.CreateMap<WcfEntities.UserDefinedTextPropertyRule, ApiEntities.UserDefinedTextPropertyRuleBasic>().ReverseMap();
            this.CreateMap<WcfEntities.UserDefinedGuidPropertyRule, ApiEntities.UserDefinedGuidPropertyRule>().ReverseMap();
            this.CreateMap<WcfEntities.UserDefinedGuidPropertyRule, ApiEntities.UserDefinedGuidPropertyRuleBasic>().ReverseMap();
            this.CreateMap<WcfEntities.PropertySensitivityLevel, ApiEntities.PropertySensitivityLevel>().ReverseMap();
            this.CreateMap<WcfEntities.PropertySensitivityLevel, ApiEntities.PropertySensitivityLevelBasic>().ReverseMap();
            this.CreateMap<WcfEntities.PropertySensitivityLevelPermission, ApiEntities.PropertySensitivityLevelPermission>().ReverseMap();
            this.CreateMap<WcfEntities.PropertySensitivityLevelPermission, ApiEntities.PropertySensitivityLevelPermissionBasic>().ReverseMap();








            this.CreateMap<WcfEntities.PersonAccessControlProperty, ApiEntities.PersonAccessControlProperty>().ReverseMap();
            this.CreateMap<WcfEntities.PersonAccessControlProperty, ApiEntities.PersonAccessControlPropertyBasic>().ReverseMap();
            this.CreateMap<WcfEntities.PersonAccessGroup, ApiEntities.PersonAccessGroup>().ReverseMap();
            this.CreateMap<WcfEntities.PersonAccessGroup, ApiEntities.PersonAccessGroupBasic>().ReverseMap();
            this.CreateMap<WcfEntities.PersonAddress, ApiEntities.PersonAddress>().ReverseMap();
            this.CreateMap<WcfEntities.PersonAddress, ApiEntities.PersonAddressBasic>().ReverseMap();
            this.CreateMap<WcfEntities.PersonClusterPermission, ApiEntities.PersonClusterPermission>().ReverseMap();
            this.CreateMap<WcfEntities.PersonClusterPermission, ApiEntities.PersonClusterPermissionBasic>().ReverseMap();
            this.CreateMap<WcfEntities.PersonCredentialCommandScript, ApiEntities.PersonCredentialCommandScript>().ReverseMap();
            this.CreateMap<WcfEntities.PersonCredentialCommandScript, ApiEntities.PersonCredentialCommandScriptBasic>().ReverseMap();
            this.CreateMap<WcfEntities.PersonCredential, ApiEntities.PersonCredential>().ReverseMap();
            this.CreateMap<WcfEntities.PersonCredential, ApiEntities.PersonCredentialBasic>().ReverseMap();
            this.CreateMap<WcfEntities.PersonEmailAddress, ApiEntities.PersonEmailAddress>().ReverseMap();
            this.CreateMap<WcfEntities.PersonEmailAddress, ApiEntities.PersonEmailAddressBasic>().ReverseMap();
            this.CreateMap<WcfEntities.PersonInputOutputGroup, ApiEntities.PersonInputOutputGroup>().ReverseMap();
            this.CreateMap<WcfEntities.PersonInputOutputGroup, ApiEntities.PersonInputOutputGroupBasic>().ReverseMap();
            this.CreateMap<WcfEntities.PersonLcdMessage, ApiEntities.PersonLcdMessage>().ReverseMap();
            this.CreateMap<WcfEntities.PersonLcdMessage, ApiEntities.PersonLcdMessageBasic>().ReverseMap();
            this.CreateMap<WcfEntities.PersonNote, ApiEntities.PersonNote>().ReverseMap();
            this.CreateMap<WcfEntities.PersonNote, ApiEntities.PersonNoteBasic>().ReverseMap();
            this.CreateMap<WcfEntities.PersonOtisElevator, ApiEntities.PersonOtisElevator>().ReverseMap();
            this.CreateMap<WcfEntities.PersonOtisElevator, ApiEntities.PersonOtisElevatorBasic>().ReverseMap();
            this.CreateMap<WcfEntities.PersonPersonalAccessGroup, ApiEntities.PersonPersonalAccessGroup>().ReverseMap();
            this.CreateMap<WcfEntities.PersonPersonalAccessGroup, ApiEntities.PersonPersonalAccessGroupBasic>().ReverseMap();
            this.CreateMap<WcfEntities.PersonPhoneNumber, ApiEntities.PersonPhoneNumber>().ReverseMap();
            this.CreateMap<WcfEntities.PersonPhoneNumber, ApiEntities.PersonPhoneNumberBasic>().ReverseMap();
            this.CreateMap<WcfEntities.PersonPropertyBag, ApiEntities.PersonPropertyBag>().ReverseMap();
            this.CreateMap<WcfEntities.PersonPropertyBag, ApiEntities.PersonPropertyBagBasic>().ReverseMap();
            this.CreateMap<WcfEntities.AccessPortalUidItem, ApiEntities.AccessPortalUidItem>().ReverseMap();
            this.CreateMap<WcfEntities.AccessGroupUidItem, ApiEntities.AccessGroupUidItem>().ReverseMap();

            this.CreateMap<RequestModels.SearchPropertyReq, WcfEntities.SearchProperty>().ReverseMap();
            this.CreateMap<RequestModels.PersonSummarySearchParametersReq, WcfEntities.PersonSummarySearchParameters>().ForMember(dest => dest.GetString, opt => opt.MapFrom(src => src.SearchTextValue));

            this.CreateMap<RequestModels.PersonReq, WcfEntities.Person>().ReverseMap();
            this.CreateMap<RequestModels.PersonAccessControlPropertyReq, WcfEntities.PersonAccessControlProperty>().ReverseMap();
            this.CreateMap<WcfEntities.PersonAccessControlProperty, ApiEntities.PersonAccessControlPropertyBasic>().ReverseMap();

            this.CreateMap<RequestModels.PersonAddressReq, WcfEntities.PersonAddress>().ReverseMap();
            this.CreateMap<RequestModels.PersonClusterPermissionReq, WcfEntities.PersonClusterPermission>().ReverseMap();
            this.CreateMap<RequestModels.PersonCredentialReq, WcfEntities.PersonCredential>().ReverseMap();
            this.CreateMap<RequestModels.PersonCredentialCommandScriptReq, WcfEntities.PersonCredentialCommandScript>().ReverseMap();
            this.CreateMap<RequestModels.PersonEmailAddressReq, WcfEntities.PersonEmailAddress>().ReverseMap();
            this.CreateMap<RequestModels.PersonLcdMessageReq, WcfEntities.PersonLcdMessage>().ReverseMap();
            this.CreateMap<RequestModels.PersonNoteReq, WcfEntities.PersonNote>().ReverseMap();
            this.CreateMap<RequestModels.PersonOtisElevatorReq, WcfEntities.PersonOtisElevator>().ReverseMap();
            this.CreateMap<RequestModels.PersonPropertyBagReq, WcfEntities.PersonPropertyBag>().ReverseMap();
            this.CreateMap<RequestModels.PersonPhoneNumberReq, WcfEntities.PersonPhoneNumber>().ReverseMap();
            this.CreateMap<RequestModels.PersonPhotoReq, WcfEntities.PersonPhoto>().ReverseMap();
            this.CreateMap<RequestModels.PersonAccessGroupReq, WcfEntities.PersonAccessGroup>().ReverseMap();
            this.CreateMap<RequestModels.PersonInputOutputGroupReq, WcfEntities.PersonInputOutputGroup>().ReverseMap();
            this.CreateMap<RequestModels.PersonPersonalAccessGroupReq, WcfEntities.PersonPersonalAccessGroup>().ReverseMap();

            this.CreateMap<RequestModels.CredentialReq, WcfEntities.Credential>().ReverseMap();
            this.CreateMap<RequestModels.Credential26BitStandardReq, WcfEntities.Credential26BitStandard>().ReverseMap();
            this.CreateMap<RequestModels.CredentialBqt36BitReq, WcfEntities.CredentialBqt36Bit>().ReverseMap();
            this.CreateMap<RequestModels.CredentialCorporate1K35BitReq, WcfEntities.CredentialCorporate1K35Bit>().ReverseMap();
            this.CreateMap<RequestModels.CredentialCorporate1K48BitReq, WcfEntities.CredentialCorporate1K48Bit>().ReverseMap();
            this.CreateMap<RequestModels.CredentialFormatReq, WcfEntities.CredentialFormat>().ReverseMap();
            this.CreateMap<RequestModels.CredentialCypress37BitReq, WcfEntities.CredentialCypress37Bit>().ReverseMap();
            this.CreateMap<RequestModels.CredentialDataReq, WcfEntities.CredentialData>().ReverseMap();
            this.CreateMap<RequestModels.CredentialH1030437BitReq, WcfEntities.CredentialH1030437Bit>().ReverseMap();
            this.CreateMap<RequestModels.CredentialH1030237BitReq, WcfEntities.CredentialH1030237Bit>().ReverseMap();
            this.CreateMap<RequestModels.CredentialPIV75BitReq, WcfEntities.CredentialPIV75Bit>().ReverseMap();
            this.CreateMap<RequestModels.CredentialXceedId40BitReq, WcfEntities.CredentialXceedId40Bit>().ReverseMap();
            this.CreateMap<RequestModels.CredentialSoftwareHouse37BitReq, WcfEntities.CredentialSoftwareHouse37Bit>().ReverseMap();
            this.CreateMap<RequestModels.CredentialFormatDataFieldReq, WcfEntities.CredentialFormatDataField>().ReverseMap();
            this.CreateMap<RequestModels.CredentialFormatParityReq, WcfEntities.CredentialFormatParity>().ReverseMap();


            this.CreateMap<RequestModels.PersonPutReq, WcfEntities.Person>().ReverseMap();
            this.CreateMap<RequestModels.PersonAccessControlPropertyPutReq, WcfEntities.PersonAccessControlProperty>().ReverseMap();
            this.CreateMap<RequestModels.PersonAddressPutReq, WcfEntities.PersonAddress>().ReverseMap();
            this.CreateMap<RequestModels.PersonClusterPermissionPutReq, WcfEntities.PersonClusterPermission>().ReverseMap();
            this.CreateMap<RequestModels.PersonCredentialPutReq, WcfEntities.PersonCredential>().ReverseMap();
            this.CreateMap<RequestModels.PersonCredentialCommandScriptPutReq, WcfEntities.PersonCredentialCommandScript>().ReverseMap();

            this.CreateMap<RequestModels.PersonEmailAddressPutReq, WcfEntities.PersonEmailAddress>().ReverseMap();
            this.CreateMap<RequestModels.PersonLcdMessagePutReq, WcfEntities.PersonLcdMessage>().ReverseMap();
            this.CreateMap<RequestModels.PersonNotePutReq, WcfEntities.PersonNote>().ReverseMap();
            this.CreateMap<RequestModels.PersonOtisElevatorPutReq, WcfEntities.PersonOtisElevator>().ReverseMap();
            this.CreateMap<RequestModels.PersonPropertyBagPutReq, WcfEntities.PersonPropertyBag>().ReverseMap();
            this.CreateMap<RequestModels.PersonPhoneNumberPutReq, WcfEntities.PersonPhoneNumber>().ReverseMap();
            this.CreateMap<RequestModels.PersonPhotoPutReq, WcfEntities.PersonPhoto>().ReverseMap();
            this.CreateMap<RequestModels.PersonAccessGroupPutReq, WcfEntities.PersonAccessGroup>().ReverseMap();
            this.CreateMap<RequestModels.PersonInputOutputGroupPutReq, WcfEntities.PersonInputOutputGroup>().ReverseMap();
            this.CreateMap<RequestModels.PersonPersonalAccessGroupPutReq, WcfEntities.PersonPersonalAccessGroup>().ReverseMap();

            this.CreateMap<RequestModels.CredentialPutReq, WcfEntities.Credential>().ReverseMap();
            this.CreateMap<RequestModels.Credential26BitStandardPutReq, WcfEntities.Credential26BitStandard>().ReverseMap();
            this.CreateMap<RequestModels.CredentialBqt36BitPutReq, WcfEntities.CredentialBqt36Bit>().ReverseMap();
            this.CreateMap<RequestModels.CredentialCorporate1K35BitPutReq, WcfEntities.CredentialCorporate1K35Bit>().ReverseMap();
            this.CreateMap<RequestModels.CredentialCorporate1K48BitPutReq, WcfEntities.CredentialCorporate1K48Bit>().ReverseMap();
            this.CreateMap<RequestModels.CredentialFormatPutReq, WcfEntities.CredentialFormat>().ReverseMap();
            this.CreateMap<RequestModels.CredentialCypress37BitPutReq, WcfEntities.CredentialCypress37Bit>().ReverseMap();
            this.CreateMap<RequestModels.CredentialDataPutReq, WcfEntities.CredentialData>().ReverseMap();
            this.CreateMap<RequestModels.CredentialH1030437BitPutReq, WcfEntities.CredentialH1030437Bit>().ReverseMap();
            this.CreateMap<RequestModels.CredentialH1030237BitPutReq, WcfEntities.CredentialH1030237Bit>().ReverseMap();
            this.CreateMap<RequestModels.CredentialPIV75BitPutReq, WcfEntities.CredentialPIV75Bit>().ReverseMap();
            this.CreateMap<RequestModels.CredentialXceedId40BitPutReq, WcfEntities.CredentialXceedId40Bit>().ReverseMap();
            this.CreateMap<RequestModels.CredentialSoftwareHouse37BitPutReq, WcfEntities.CredentialSoftwareHouse37Bit>().ReverseMap();
            this.CreateMap<RequestModels.CredentialFormatDataFieldPutReq, WcfEntities.CredentialFormatDataField>().ReverseMap();
            this.CreateMap<RequestModels.CredentialFormatParityPutReq, WcfEntities.CredentialFormatParity>().ReverseMap();



            this.CreateMap<WcfEntities.PinRequiredMode, ApiEntities.PinRequiredMode>().ReverseMap();
            this.CreateMap<WcfEntities.PinRequiredMode, ApiEntities.PinRequiredModeBasic>().ReverseMap();

            //this.CreateMap<WcfEntities.NoteBasic, ApiEntities.NoteBasic>().ReverseMap();
            this.CreateMap<WcfEntities.Region, ApiEntities.Region>().ReverseMap();
            this.CreateMap<WcfEntities.Region, ApiEntities.RegionBasic>().ReverseMap();
            this.CreateMap<WcfEntities.RegionListItem, ApiEntities.RegionListItem>().ReverseMap();
            //this.CreateMap<WcfEntities.RegionBasic, ApiEntities.RegionBasic>().ReverseMap();
            this.CreateMap<RequestModels.RegionReq, WcfEntities.Region>().ReverseMap();
            this.CreateMap<RequestModels.RegionReq, WcfEntities.Region>().ReverseMap();
            this.CreateMap<RequestModels.RegionPutReq, WcfEntities.Region>().ReverseMap();

            this.CreateMap<WcfEntities.RegionSelectionItem, ApiEntities.RegionSelectionItem>().ReverseMap();
            this.CreateMap<WcfEntities.RegionSelectionItem, ApiEntities.RegionSelectionItemBasic>().ReverseMap();
//            this.CreateMap<WcfEntities.RegionSelectionItem, ApiEntities.RegionSelectionItemMinimal>().ReverseMap();
            this.CreateMap<WcfEntities.RegionSelectionItem, ApiEntities.RegionSelectionItemMinimal>().ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.RegionUid)
            ).ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.RegionName)
            ).ReverseMap();
            //            this.CreateMap<WcfEntities.RegionSelectionItemBasic, ApiEntities.RegionSelectionItemMinimal>().ReverseMap();
            this.CreateMap<WcfEntities.RegionSelectionItemBasic, ApiEntities.RegionSelectionItemMinimal>().ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.RegionUid)
            ).ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.RegionName)
            ).ReverseMap();

            this.CreateMap<WcfEntities.RegionSelectionItemBasic, ApiEntities.RegionSelectionItemBasic>().ReverseMap();
            this.CreateMap<WcfEntities.RegionSelectionItemBasic, ResponseModels.RegionSelectionItemBasicResp>().ReverseMap();
            this.CreateMap<WcfEntities.RegionSelectionItemMinimal, ApiEntities.RegionSelectionItemMinimal>().ReverseMap();

            this.CreateMap<WcfEntities.Site, ApiEntities.Site>().ReverseMap();
            this.CreateMap<WcfEntities.Site, ApiEntities.SiteBasic>().ReverseMap();
            //this.CreateMap<WcfEntities.SiteBasic, ApiEntities.SiteBasic>().ReverseMap();
            this.CreateMap<RequestModels.SiteReq, WcfEntities.Site>().ReverseMap();
            this.CreateMap<RequestModels.SitePutReq, WcfEntities.Site>().ReverseMap();
            this.CreateMap<WcfEntities.SiteListItem, ApiEntities.SiteListItem>().ReverseMap();
            this.CreateMap<WcfEntities.SiteSelectionItem, ApiEntities.SiteSelectionItem>().ReverseMap();
            this.CreateMap<WcfEntities.SiteSelectionItem, ApiEntities.SiteSelectionItemBasic>().ReverseMap();
            //this.CreateMap<WcfEntities.SiteSelectionItem, ApiEntities.SiteSelectionItemMinimal>().ReverseMap();
            this.CreateMap<WcfEntities.SiteSelectionItem, ApiEntities.SiteSelectionItemMinimal>().ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.SiteUid)
            ).ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.SiteName)
            ).ReverseMap();

            //           this.CreateMap<WcfEntities.SiteSelectionItemBasic, ApiEntities.SiteSelectionItemMinimal>().ReverseMap();
            this.CreateMap<WcfEntities.SiteSelectionItemBasic, ApiEntities.SiteSelectionItemMinimal>().ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.SiteUid)
            ).ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.SiteName)
            ).ReverseMap();
            this.CreateMap<WcfEntities.SiteSelectionItemBasic, ResponseModels.SiteSelectionItemBasicResp>().ReverseMap();
            this.CreateMap<WcfEntities.SiteSelectionItemBasic, ApiEntities.SiteSelectionItemBasic>().ReverseMap();
            this.CreateMap<WcfEntities.SiteSelectionItemMinimal, ApiEntities.SiteSelectionItemMinimal>().ReverseMap();
            this.CreateMap<RequestModels.EntityIdEntityMapPermissionLevelReq, WcfEntities.EntityIdEntityMapPermissionLevel>().ReverseMap();

            this.CreateMap<WcfEntities.SaveParameters, ApiEntities.SaveParameters>().ReverseMap();
            this.CreateMap<RequestModels.SaveParams, WcfEntities.SaveParameters>().ReverseMap();
            this.CreateMap(typeof(WcfEntities.SaveParameters<>), typeof(ApiEntities.SaveParameters<>)).ReverseMap();
            this.CreateMap(typeof(RequestModels.SaveParams<>), typeof(WcfEntities.SaveParameters<>)).ReverseMap();

            //this.CreateMap(typeof(RequestModels.SaveParams<>), typeof(ApiEntities.SaveParameters<>));
            this.CreateMap<WcfEntities.StateProvince, ApiEntities.StateProvince>().ReverseMap();
            this.CreateMap<WcfEntities.StateProvince, ApiEntities.StateProvinceBasic>().ReverseMap();
            this.CreateMap<WcfEntities.StateProvince, ResponseModels.StateProvinceBasicResp>().ReverseMap();
            //this.CreateMap<WcfEntities.StateProvinceBasic, ApiEntities.StateProvinceBasic>().ReverseMap();
            this.CreateMap<RequestModels.StateProvinceReq, WcfEntities.StateProvince>().ReverseMap();

            this.CreateMap<WcfEntities.StringObjectPairBase, ApiEntities.StringObjectPairBase>().ReverseMap();
            this.CreateMap<WcfEntities.StringShortPair, ApiEntities.StringShortPair>().ReverseMap();
            this.CreateMap<WcfEntities.StringUShortPair, ApiEntities.StringUShortPair>().ReverseMap();
            this.CreateMap<WcfEntities.StringIntPair, ApiEntities.StringIntPair>().ReverseMap();
            this.CreateMap<WcfEntities.StringUIntPair, ApiEntities.StringUIntPair>().ReverseMap();

            this.CreateMap<WcfEntities.TimePeriod, ApiEntities.TimePeriod>().ReverseMap();
            this.CreateMap<WcfEntities.TimePeriod, ApiEntities.TimePeriodBasic>().ForMember(
                dest => dest.s,
                opt => opt.MapFrom(src => src.StartTime)
            ).ForMember(
                dest => dest.e,
                opt => opt.MapFrom(src => src.EndTime)
            ).ReverseMap();
            this.CreateMap<WcfEntities.TimePeriod, RequestModels.TimePeriodReq>().ReverseMap();
            this.CreateMap<WcfEntities.TimePeriod, RequestModels.TimePeriodPutReq>().ReverseMap();
            //this.CreateMap<WcfEntities.TimePeriodBasic, ApiEntities.TimePeriodBasic>().ReverseMap();
            this.CreateMap<WcfEntities.TimeSchedule, ApiEntities.TimeSchedule>().ReverseMap();
            this.CreateMap<WcfEntities.TimeSchedule, ApiEntities.TimeScheduleBasic>().ReverseMap();
            this.CreateMap<WcfEntities.TimeSchedule, ApiEntities.TimeScheduleMinimal>().ReverseMap();
            this.CreateMap<WcfEntities.TimeSchedule, RequestModels.TimeScheduleReq>().ReverseMap();
            this.CreateMap<WcfEntities.TimeSchedule, RequestModels.TimeSchedulePutReq>().ReverseMap();
            this.CreateMap<WcfEntities.TimeSchedule, ResponseModels.TimeScheduleResp>().ReverseMap();
            this.CreateMap<WcfEntities.TimeScheduleListItem, ApiEntities.TimeScheduleListItem>().ReverseMap();
            this.CreateMap<WcfEntities.TimeScheduleListItem, ApiEntities.ListItemBaseSimple>().ReverseMap();
            
            //this.CreateMap<WcfEntities.TimeScheduleBasic, ApiEntities.TimeScheduleBasic>().ReverseMap();
            this.CreateMap<WcfEntities.TimeScheduleDayTypeTimePeriod, ApiEntities.TimeScheduleDayTypeTimePeriod>().ReverseMap();
            this.CreateMap<WcfEntities.TimeScheduleDayTypeTimePeriod, ApiEntities.TimeScheduleDayTypeTimePeriodBasic>().ReverseMap();
            //this.CreateMap<WcfEntities.TimeScheduleDayTypeTimePeriodBasic, ApiEntities.TimeScheduleDayTypeTimePeriodBasic>().ReverseMap();
            this.CreateMap<WcfEntities.TimeScheduleDayTypeGalaxyTimePeriod, ApiEntities.TimeScheduleDayTypeGalaxyTimePeriod>().ReverseMap();
            this.CreateMap<WcfEntities.TimeScheduleDayTypeGalaxyTimePeriod, ApiEntities.TimeScheduleDayTypeGalaxyTimePeriodBasic>().ReverseMap();
            //this.CreateMap<WcfEntities.TimeScheduleDayTypeGalaxyTimePeriodBasic, ApiEntities.TimeScheduleDayTypeGalaxyTimePeriodBasic>().ReverseMap();

            this.CreateMap<WcfEntities.TimeScheduleSelectionItem, ApiEntities.TimeScheduleSelectionItem>().ReverseMap();
            this.CreateMap<WcfEntities.TimeScheduleSelectionItem, ApiEntities.TimeScheduleSelectionItemBasic>().ReverseMap();
            this.CreateMap<WcfEntities.TimeScheduleSelectionItem, ApiEntities.TimeScheduleSelectionItemMinimal>().ReverseMap();
            this.CreateMap<WcfEntities.TimeScheduleSelectionItemBasic, ResponseModels.TimeScheduleSelectionItemBasicResp>().ReverseMap();
            this.CreateMap<WcfEntities.TimeScheduleSelectionItemBasic, ApiEntities.TimeScheduleSelectionItemBasic>().ReverseMap();
            this.CreateMap<WcfEntities.TimeScheduleSelectionItemBasic, ApiEntities.TimeScheduleSelectionItemMinimal>().ReverseMap();
            this.CreateMap<WcfEntities.TimeScheduleSelectionItemMinimal, ApiEntities.TimeScheduleSelectionItemMinimal>().ReverseMap();

            this.CreateMap<WcfEntities.TimeScheduleType, ApiEntities.TimeScheduleType>().ReverseMap();
            this.CreateMap<WcfEntities.TimeScheduleType, ApiEntities.TimeScheduleTypeBasic>().ReverseMap();

            this.CreateMap<WcfEntities.TimeScheduleSelect, ApiEntities.TimeScheduleSelect>().ReverseMap();
            this.CreateMap<WcfEntities.TimeScheduleSelect, ApiEntities.TimeScheduleSelectBasic>().ReverseMap();
            this.CreateMap<WcfEntities.TimeScheduleClusterItem, ApiEntities.TimeScheduleClusterItem>();
            this.CreateMap<WcfEntities.TimeScheduleUsageData, ApiEntities.TimeScheduleUsageData>();
            this.CreateMap<WcfEntities.TimeScheduleMappings, ApiEntities.TimeScheduleMappings>();
            this.CreateMap<WcfEntities.TimeScheduleUsageItem, ApiEntities.TimeScheduleUsageItem>();
            this.CreateMap<WcfEntities.TimeScheduleUsageItemAccessGroupAccessPortal, ApiEntities.TimeScheduleUsageItemAccessGroupAccessPortal>();
            this.CreateMap<WcfEntities.TimeScheduleUsageItemPersonalAccessGroup, ApiEntities.TimeScheduleUsageItemPersonalAccessGroup>();


            this.CreateMap<WcfEntities.TimeZone, ApiEntities.TimeZone>().ReverseMap();
            this.CreateMap<WcfEntities.TimeZone, ApiEntities.TimeZoneBasic>().ReverseMap();
            this.CreateMap<WcfEntities.TimeZoneListItem, ApiEntities.TimeZoneListItem>().ReverseMap();

            //this.CreateMap<WcfEntities.TimeScheduleSelectBasic, ApiEntities.TimeScheduleSelectBasic>().ReverseMap();
            this.CreateMap<WcfEntities.TwoFactorAuthenticationData, ApiEntities.TwoFactorAuthenticationData>().ReverseMap();
            this.CreateMap<WcfEntities.UserData, ApiEntities.UserData>().ReverseMap();
            this.CreateMap<WcfEntities.UserEntity, ApiEntities.UserEntity>().ReverseMap();
            this.CreateMap<WcfEntities.UserPermission, ApiEntities.UserPermission>().ReverseMap();
            this.CreateMap<WcfEntities.UserRole, ApiEntities.UserRole>().ReverseMap();
            this.CreateMap<WcfEntities.UserSessionSettings, ApiEntities.UserSessionSettings>().ReverseMap();
            this.CreateMap<WcfEntities.UserSessionToken, ApiEntities.UserSessionToken>().ReverseMap();
            this.CreateMap<WcfEntities.UserSignInRequest, ApiEntities.UserSignInRequest>().ReverseMap();
            this.CreateMap<WcfEntities.UserSignInResult, ApiEntities.UserSignInResult>().ReverseMap();
            this.CreateMap<WcfEntities.WindowsUserIdentity, ApiEntities.WindowsUserIdentity>().ReverseMap();
            this.CreateMap<ApiEntities.UserRequestPasswordChangeToken, WcfEntities.UserRequestPasswordChangeToken>();
            this.CreateMap<ApiEntities.UpdateUserPasswordParameters, WcfEntities.UpdateUserPasswordParameters>();
            this.CreateMap<WcfEntities.UserRequestPasswordChangeTokenResponse, ApiEntities.UserRequestPasswordChangeTokenResponse>();
            this.CreateMap<WcfEntities.UpdateUserPasswordResult, ApiEntities.UpdateUserPasswordResult>();


            // Mercury entities
            this.CreateMap<WcfEntities.MercScpIdReport, ApiEntities.MercScpIdReport>().ReverseMap();
            this.CreateMap<RequestModels.MercScpIdReportReq, WcfEntities.MercScpIdReport>().ReverseMap();
            this.CreateMap<WcfEntities.MercScpGroup, ApiEntities.MercScpGroup>().ReverseMap();
            this.CreateMap<WcfEntities.MercScpGroup, ApiEntities.MercScpGroupBasic>().ReverseMap();
            this.CreateMap<WcfEntities.MercScpGroupListItemCommands, ApiEntities.MercScpGroupListItemCommands>().ReverseMap();
            this.CreateMap<WcfEntities.MercScpGroup, RequestModels.MercScpGroupPutReq>().ReverseMap();
            this.CreateMap<WcfEntities.MercScpGroup, RequestModels.MercScpGroupReq>().ReverseMap();
            this.CreateMap<WcfEntities.MercScpGroup, ApiEntities.MercScpGroupMinimal>().ReverseMap();
            this.CreateMap<WcfEntities.MercScpGroup, RequestModels.ClusterPutReqMinimalChildren>().ReverseMap();
            this.CreateMap<WcfEntities.MercScpGroup, ResponseModels.MercScpGroupResp>().ReverseMap();
            this.CreateMap<WcfEntities.MercScpGroupEditingData, ApiEntities.MercScpGroupEditingDataBasic>().ReverseMap();



            this.CreateMap<WcfEntities.MercScp, ApiEntities.MercScp>().ReverseMap();
            this.CreateMap<WcfEntities.MercScp, ApiEntities.MercScpBasic>().ReverseMap();
            this.CreateMap<WcfEntities.MercScp, ResponseModels.MercScpResp>().ReverseMap();
            this.CreateMap<WcfEntities.MercScpEditingData, ApiEntities.MercScpEditingData>().ReverseMap();
            this.CreateMap<WcfEntities.MercScp, RequestModels.MercScpReq>().ReverseMap();
            this.CreateMap<WcfEntities.MercScp, RequestModels.MercScpPutReq>().ReverseMap();
            this.CreateMap<WcfEntities.MercScpStatus, ApiEntities.MercScpStatus>().ReverseMap();

            this.CreateMap<RequestModels.MercScpActivityHistoryEventSearchParametersReq, WcfEntities.ActivityHistoryEventSearchParameters>().ReverseMap();

            this.CreateMap<WcfEntities.MercScp, ApiEntities.MercScp>().ReverseMap();

            this.CreateMap<WcfEntities.MercScp, ApiEntities.MercScp>().ReverseMap();




        }
    }
}

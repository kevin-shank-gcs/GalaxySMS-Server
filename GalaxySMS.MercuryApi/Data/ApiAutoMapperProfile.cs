using AutoMapper;
using Azure;
using GalaxySMS.Api.Models.RequestModels;
using GalaxySMS.Api.Models.ResponseModels;
using ApiEntities = GalaxySMS.Business.Entities.Api.NetCore;
using RequestModels = GalaxySMS.Api.Models.RequestModels;
using ResponseModels = GalaxySMS.Api.Models.ResponseModels;
using WcfEntities = GalaxySMS.Business.Entities;

namespace GalaxySMS.MercuryApi.Data
{
    public class ApiAutoMapperProfile : Profile
    {
        public ApiAutoMapperProfile()
        {
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


            this.CreateMap<WcfEntities.gcsSetting, ApiEntities.gcsSetting>().ReverseMap();
            this.CreateMap<WcfEntities.gcsSetting, ApiEntities.gcsSettingBasic>().ReverseMap();
            this.CreateMap<WcfEntities.gcsSetting, RequestModels.gcsSettingPostReq>().ReverseMap();
            this.CreateMap<WcfEntities.gcsSetting, RequestModels.gcsSettingPutReq>().ReverseMap();

            
            this.CreateMap<WcfEntities.SaveResponse, ApiEntities.SaveResponse>().ReverseMap();
            this.CreateMap(typeof(WcfEntities.SaveResponse<>), typeof(ApiEntities.SaveResponse<>)).ReverseMap();

            this.CreateMap<WcfEntities.SaveParameters, ApiEntities.SaveParameters>().ReverseMap();
            this.CreateMap<RequestModels.SaveParams, WcfEntities.SaveParameters>().ReverseMap();
            this.CreateMap(typeof(WcfEntities.SaveParameters<>), typeof(ApiEntities.SaveParameters<>)).ReverseMap();
            this.CreateMap(typeof(RequestModels.SaveParams<>), typeof(WcfEntities.SaveParameters<>)).ReverseMap();

            this.CreateMap<WcfEntities.StringObjectPairBase, ApiEntities.StringObjectPairBase>().ReverseMap();
            this.CreateMap<WcfEntities.StringShortPair, ApiEntities.StringShortPair>().ReverseMap();
            this.CreateMap<WcfEntities.StringUShortPair, ApiEntities.StringUShortPair>().ReverseMap();
            this.CreateMap<WcfEntities.StringIntPair, ApiEntities.StringIntPair>().ReverseMap();
            this.CreateMap<WcfEntities.StringUIntPair, ApiEntities.StringUIntPair>().ReverseMap();

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

            this.CreateMap<WcfEntities.gcsApplicationSetting, ApiEntities.gcsApplicationSetting>().ReverseMap();
            this.CreateMap<WcfEntities.gcsApplicationSetting, ApiEntities.gcsApplicationSettingBasic>().ReverseMap();
            this.CreateMap<WcfEntities.gcsApplicationSetting, RequestModels.gcsApplicationSettingPostReq>().ReverseMap();
            this.CreateMap<WcfEntities.gcsApplicationSetting, RequestModels.gcsApplicationSettingPutReq>().ReverseMap();

            // Mercury entities
            this.CreateMap<AscendGalaxyLibrary.Serialization.Mercury.MercuryPanel, WcfEntities.MercuryPanel>().ReverseMap();
            this.CreateMap<WcfEntities.MercuryPanel, ApiEntities.MercuryPanel>().ReverseMap();

            this.CreateMap<WcfEntities.gcsUserSession, ApiEntities.gcsUserSession>().ReverseMap();
            this.CreateMap<WcfEntities.gcsUserSetting, ApiEntities.gcsUserSetting>().ReverseMap();
            this.CreateMap<WcfEntities.gcsUserSetting, ApiEntities.gcsUserSettingBasic>().ReverseMap();
            this.CreateMap<WcfEntities.gcsUserSetting, RequestModels.UserSettingPostReq>().ReverseMap();
            this.CreateMap<WcfEntities.gcsUserSetting, RequestModels.UserSettingPutReq>().ReverseMap();
            this.CreateMap<WcfEntities.GetParameters, ApiEntities.GetParameters>().ReverseMap();
            this.CreateMap(typeof(WcfEntities.GetParameters<>), typeof(ApiEntities.GetParameters<>)).ReverseMap();
            this.CreateMap<WcfEntities.GetParametersWithPhoto, ApiEntities.GetParametersWithPhoto>().ReverseMap();
            this.CreateMap(typeof(WcfEntities.GetParametersWithPhoto<>), typeof(ApiEntities.GetParametersWithPhoto<>)).ReverseMap();

        }
    }
}

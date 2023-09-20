using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WcfEntities = GalaxySMS.Business.Entities;
using IpProducerApiEntities = GCS.Framework.Badging.IdProducer.Entities;

namespace GalaxySMS.Business.Managers.Support
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {

            this.CreateMap<WcfEntities.FriendlyLicenseDetails, IpProducerApiEntities.FriendlyLicenseDetails>().ReverseMap();
            this.CreateMap<WcfEntities.SubscriptionConfig, IpProducerApiEntities.SubscriptionConfig>().ReverseMap();
            this.CreateMap<WcfEntities.PrintDispatcher, IpProducerApiEntities.PrintDispatcher>().ReverseMap();
            this.CreateMap<WcfEntities.Printer, IpProducerApiEntities.Printer>().ReverseMap();
            this.CreateMap<WcfEntities.PrinterDispatchersResponse, IpProducerApiEntities.PrinterDispatchersResponse>().ReverseMap();
            this.CreateMap<WcfEntities.SetMasterLicenseData, IpProducerApiEntities.SetMasterLicenseData>().ReverseMap();
            this.CreateMap<WcfEntities.SubscriptionData, IpProducerApiEntities.SubscriptionData>().ReverseMap();
            this.CreateMap<WcfEntities.ChildrenSubscription, IpProducerApiEntities.ChildrenSubscription>().ReverseMap();
            this.CreateMap<WcfEntities.SubscriptionTemplateField, IpProducerApiEntities.SubscriptionTemplateField>().ReverseMap();
            this.CreateMap<WcfEntities.CardTemplateLite, IpProducerApiEntities.CardTemplateLite>().ReverseMap();
            this.CreateMap<WcfEntities.PreviewData, IpProducerApiEntities.PreviewData>().ReverseMap();
        }
    }
    
}

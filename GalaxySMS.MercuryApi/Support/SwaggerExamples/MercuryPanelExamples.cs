using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Api.Models.RequestModels;
using GalaxySMS.Common.Enums;
using GalaxySMS.Common.Shared.Enums;
using Swashbuckle.AspNetCore.Filters;
using ApiEntities = GalaxySMS.Business.Entities.Api.NetCore;

namespace GalaxySMS.MercuryApi.Support
{
    public class SaveMercuryPanelExamples : IExamplesProvider<List<ApiEntities.MercuryPanel>>
    {
        List<ApiEntities.MercuryPanel> IExamplesProvider<List<ApiEntities.MercuryPanel>>.GetExamples()
        {
            var data = new List<ApiEntities.MercuryPanel>
            {

            };

            data.Add(new ApiEntities.MercuryPanel()
            {
                MacAddress = "1B-F1-1A-CF-D3-ED",
                Authorized = true,
                Description = "some desc",
                DeviceManufacturer = DeviceManufacturer.Mercury,
                Guid = Guid.Empty.ToString(),
                LastConnected = DateTime.Now,
                Name = "some unique name",
                Online = true,
                PanelType = MercuryPanelType.LP1501,
                Serialnumber = 123456
            });

            data.Add(new ApiEntities.MercuryPanel()
            {
                MacAddress = "1B-F1-1A-CF-D3-EF",
                Authorized = true,
                Description = "some desc",
                DeviceManufacturer = DeviceManufacturer.Mercury,
                Guid = Guid.Empty.ToString(),
                LastConnected = DateTime.Now,
                Name = "some unique name",
                Online = true,
                PanelType = MercuryPanelType.LP1502,
                Serialnumber = 654321
            });


            return data;
        }
    }

}
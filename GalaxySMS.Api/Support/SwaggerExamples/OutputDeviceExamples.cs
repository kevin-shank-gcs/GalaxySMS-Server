using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Api.Models.RequestModels;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Filters;
using ApiEntities = GalaxySMS.Business.Entities.Api.NetCore;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Api.Support
{

    public class SaveApiEntitiesOutputDeviceExamples : IExamplesProvider<SaveParams<OutputDevicePutReq>>
    {
        SaveParams<OutputDevicePutReq> IExamplesProvider<SaveParams<OutputDevicePutReq>>.GetExamples()
        {
            var data = new SaveParams<OutputDevicePutReq>()
            {
                Data = new OutputDevicePutReq()
                {
                    OutputName = "Sample Output Name",
                    ConcurrencyValue = 1,
                    Notes = new List<NotePutReq>(),
                    GalaxyOutputDevice = new GalaxyOutputDevicePutReq()
                }
            };
            data.Data.GalaxyOutputDevice.GalaxyOutputDeviceInputSources= new List<GalaxyOutputDeviceInputSourcePutReq>();

            for( int x = 0; x < 4; x++)
            {
                var o = new GalaxyOutputDeviceInputSourcePutReq()
                {
                    GalaxyOutputDeviceInputSourceAssignments = new List<GalaxyOutputDeviceInputSourceAssignmentPutReq>(),
                    GalaxyOutputDeviceInputSourceInputOutputGroups = new List<GalaxyOutputDeviceInputSourceInputOutputGroupPutReq>(),
                };
                data.Data.GalaxyOutputDevice.GalaxyOutputDeviceInputSources.Add(o );
            }

            data.SavePhoto = false;
            //data.Options.Add(new KeyValuePair<string, string>(nameof(GalaxySMS.Common.Enums.SaveInputDeviceAreasOption), GalaxySMS.Common.Enums.SaveInputDeviceAreasOption.DeleteMissingItems.ToString()));
            //data.Options.Add(new KeyValuePair<string, string>(nameof(GalaxySMS.Common.Enums.SaveInputDeviceSchedulesOption), GalaxySMS.Common.Enums.SaveInputDeviceSchedulesOption.DeleteMissingItems.ToString()));
            //data.IgnoreProperties.Add(nameof(data.Data.Notes));
            return data;
        }
    }


    public class GetHistoryApiEntitiesOutputDeviceExamples : IExamplesProvider<OutputDeviceActivityHistoryEventSearchParametersReq>
    {
        OutputDeviceActivityHistoryEventSearchParametersReq IExamplesProvider<OutputDeviceActivityHistoryEventSearchParametersReq>.GetExamples()
        {
            var data = new OutputDeviceActivityHistoryEventSearchParametersReq()
            {
                StartDateTime = DateTimeOffset.Now.Today().Subtract(new TimeSpan(7, 0, 0, 0)),
                EndDateTime = DateTimeOffset.Now,
            };


            return data;
        }
    }
}

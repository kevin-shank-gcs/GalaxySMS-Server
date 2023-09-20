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

    public class SaveApiEntitiesInputDeviceExamples : IExamplesProvider<SaveParams<InputDevicePutReq>>
    {
        SaveParams<InputDevicePutReq> IExamplesProvider<SaveParams<InputDevicePutReq>>.GetExamples()
        {
            var data = new SaveParams<InputDevicePutReq>()
            {
                Data = new InputDevicePutReq()
                {
                    InputName = "Sample Input Name",
                    ConcurrencyValue = 1,
                    Notes = new List<NotePutReq>(),
                    GalaxyInputDevice = new GalaxyInputDevicePutReq()
                }

            };
            data.Data.GalaxyInputDevice.AlertEvents = new List<InputDeviceAlertEventPutReq>();
            data.Data.GalaxyInputDevice.TimeSchedule = new GalaxyInputDeviceTimeSchedulePutReq();
            data.Data.GalaxyInputDevice.ArmingInputOutputGroups = new List<GalaxyInputArmingInputOutputGroupPutReq>();

            data.SavePhoto = false;
            //data.Options.Add(new KeyValuePair<string, string>(nameof(GalaxySMS.Common.Enums.SaveInputDeviceAreasOption), GalaxySMS.Common.Enums.SaveInputDeviceAreasOption.DeleteMissingItems.ToString()));
            //data.Options.Add(new KeyValuePair<string, string>(nameof(GalaxySMS.Common.Enums.SaveInputDeviceSchedulesOption), GalaxySMS.Common.Enums.SaveInputDeviceSchedulesOption.DeleteMissingItems.ToString()));
            //data.IgnoreProperties.Add(nameof(data.Data.Notes));
            return data;
        }
    }


    public class GetHistoryApiEntitiesInputDeviceExamples : IExamplesProvider<InputDeviceActivityHistoryEventSearchParametersReq>
    {
        InputDeviceActivityHistoryEventSearchParametersReq IExamplesProvider<InputDeviceActivityHistoryEventSearchParametersReq>.GetExamples()
        {
            var data = new InputDeviceActivityHistoryEventSearchParametersReq()
            {
                StartDateTime = DateTimeOffset.Now.Today().Subtract(new TimeSpan(7, 0, 0, 0)),
                EndDateTime = DateTimeOffset.Now,
            };


            return data;
        }
    }
}

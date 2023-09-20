using GalaxySMS.Data.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaxySMS.Business.Entities;
using GalaxySMS.BusinessLayer;
using GalaxySMS.Common.Constants;
using GalaxySMS.Common.Enums;
using GalaxySMS.EntityLayer;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Extensions;
using GCS.Core.Common.Logger;
using GCS.Core.Common.Utils;

namespace GalaxySMS.Data
{
    [Export(typeof(IDeviceAlertEventSettingsRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class DeviceAlertEventSettingsRepository : IDeviceAlertEventSettingsRepository
    {
        [Import] private IDataRepositoryFactory _dataRepositoryFactory;
        [Import] private IAccessPortalAlertEventRepository _accessPortalAlertEventRepository;
        [Import] private IGalaxyPanelAlertEventRepository _galaxyPanelAlertEventRepository;
        [Import] private IInputDeviceEventPropertiesRepository _inputDeviceEventPropertiesRepository;

        public EntityDeviceAlertEventSettings GetForEntityId(Guid entityId, bool isActive)
        {
            try
            {
                var mgr = new DeviceAlertEventSettings_ByEntityIdPDSAManager
                {
                    Entity =
                    {
                        EntityId = entityId,
                        IsActive = isActive
                    }
                };
                var data = mgr.BuildCollection();
                var results = new EntityDeviceAlertEventSettings()
                {
                    EntityId = entityId
                };

                var first = data.FirstOrDefault();
                if (first != null)
                {
                    results.EntityId = first.EntityId;
                    results.EntityName = first.EntityName;
                }

                var deviceTypeData = data.GroupBy(o => o.DeviceType);
                foreach (var dtd in deviceTypeData)
                {
                    var clusterData = dtd.GroupBy(o => o.ClusterUid);
                    foreach (var cd in clusterData)
                    {
                        var scheduleData = cd.GroupBy(o => o.AcknowledgeTimeScheduleUid);
                        {
                            foreach (var sd in scheduleData)
                            {
                                var eventTypeGroupsData = sd.GroupBy(o => o.AlertEventsFlag);
                                foreach (var etg in eventTypeGroupsData)
                                {
                                    var f = etg.FirstOrDefault();
                                    if (f != null)
                                    {
                                        var settings = new DeviceAlertEventSettings()
                                        {
                                            DeviceType = f.DeviceType,
                                            Cluster = new ItemIdName()
                                            {
                                                Id = f.ClusterUid,
                                                Name = f.ClusterName
                                            },
                                            Schedule = new ItemIdName()
                                            {
                                                Id = f.AcknowledgeTimeScheduleUid,
                                                Name = f.TimeSchedule
                                            },

                                        };
                                        foreach (var eventType in etg.DistinctBy(o => o.AlertEventTypeUid))
                                        {
                                            settings.EventTypes.Add(new ItemIdName()
                                            {
                                                Id = eventType.AlertEventTypeUid,
                                                Name = eventType.EventType
                                            });
                                        }
                                        foreach (var device in etg.DistinctBy(o => o.DeviceId))
                                        {
                                            settings.Devices.Add(new ItemIdName()
                                            {
                                                Id = device.DeviceId,
                                                Name = device.DeviceName
                                            });
                                        }

                                        results.Data.Add(settings);
                                    }
                                }
                            }
                        }
                    }
                }


                return results;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
                throw;
            }
        }

        public EntityDeviceAlertEventSettings SaveForEntityId(SaveParameters<EntityDeviceAlertEventSettings> parameters, bool isActive, IApplicationUserSessionDataHeader sessionData)
        {
            if (parameters?.Data == null)
            {
                return null;
            }
            try
            {
                // Validate that all specified AcknowledgeTimeScheduleUid values are valid for the entity & clusters
                foreach (var daes in parameters.Data.Data.Where(o => o.Schedule.Id != TimeScheduleIds.TimeSchedule_Never &&
                                                                    o.Schedule.Id != TimeScheduleIds.TimeSchedule_Always))
                {
                    //var isScheduleMappedToCluster =
                }


                // Start by flattening all incoming records to make it easier to process
                var incomingData = Flatten(parameters.Data);

                // Validate that all specified AcknowledgeTimeScheduleUid values are valid for the entity & clusters

                var incomingAccessPortalData = incomingData.Where(o => o.DeviceType == DeviceType.AccessPortal.ToString()).ToList();
                var incomingGalaxyPanelData = incomingData.Where(o => o.DeviceType == DeviceType.GalaxyPanel.ToString()).ToList();
                var incomingInputDeviceData = incomingData.Where(o => o.DeviceType == DeviceType.InputDevice.ToString()).ToList();

                var existingAccessPortalAlertEvents = _accessPortalAlertEventRepository.GetByEntityId(sessionData,
                    new GetParametersWithPhoto() { UniqueId = parameters.Data.EntityId, IncludeMemberCollections = false }).ToList();
                var existingGalaxyPanelAlertEvents = _galaxyPanelAlertEventRepository.GetByEntityId(sessionData,
                    new GetParametersWithPhoto() { UniqueId = parameters.Data.EntityId, IncludeMemberCollections = false }).ToList();
                var existingInputDeviceAlertEvents = _inputDeviceEventPropertiesRepository.GetByEntityId(sessionData,
                    new GetParametersWithPhoto() { UniqueId = parameters.Data.EntityId, IncludeMemberCollections = false }).ToList();

                foreach (var apd in incomingAccessPortalData)
                {
                    var existingApd = existingAccessPortalAlertEvents.FirstOrDefault(o =>
                        o.AccessPortalUid == apd.DeviceId &&
                        o.AccessPortalAlertEventTypeUid == apd.AlertEventTypeUid);
                    if (existingApd != null)
                    {
                        if (existingApd.AcknowledgeTimeScheduleUid != apd.AcknowledgeTimeScheduleUid ||
                            (apd.AcknowledgeTimeScheduleUid != TimeScheduleIds.TimeSchedule_Never &&
                             existingApd.IsActive == false))
                        {
                            existingApd.AcknowledgeTimeScheduleUid = apd.AcknowledgeTimeScheduleUid;
                            if (existingApd.IsActive == false &&
                                apd.AcknowledgeTimeScheduleUid != TimeScheduleIds.TimeSchedule_Never)
                                existingApd.IsActive = true;
                            existingApd.UpdateDate = DateTimeOffset.Now;
                            existingApd.UpdateName = sessionData.UserName;
                            var updatedApd =
                                _accessPortalAlertEventRepository.Update(existingApd, sessionData, parameters);
                        }
                    }
                    //else
                    //{   // Must add one
                    //    existingApd = new AccessPortalAlertEvent()
                    //    {
                    //        EntityId = apd.EntityId,
                    //        AccessPortalAlertEventUid = GuidUtilities.GenerateComb(),
                    //        AccessPortalUid = apd.DeviceId,
                    //        AccessPortalAlertEventTypeUid = apd.AlertEventTypeUid,
                    //        AcknowledgeTimeScheduleUid = apd.AcknowledgeTimeScheduleUid,
                    //        IsActive = true,
                    //        InsertDate = DateTimeOffset.Now,
                    //        InsertName = sessionData.UserName,
                    //        UpdateDate = DateTimeOffset.Now,
                    //        UpdateName = sessionData.UserName,
                    //        ConcurrencyValue = 0
                    //    };
                    //    var updatedApd =
                    //        _accessPortalAlertEventRepository.Add(existingApd, sessionData, parameters);
                    //}
                }


                var existingApNotNever = existingAccessPortalAlertEvents
                    .Where(o => o.AcknowledgeTimeScheduleUid != TimeScheduleIds.TimeSchedule_Never).ToList();
                foreach (var existingApd in existingApNotNever)
                {
                    var incomingApd = incomingAccessPortalData.FirstOrDefault(o =>
                        o.DeviceId == existingApd.AccessPortalUid &&
                        o.AlertEventTypeUid == existingApd.AccessPortalAlertEventTypeUid);
                    if (incomingApd == null || incomingApd.AcknowledgeTimeScheduleUid == TimeScheduleIds.TimeSchedule_Never)
                    {
                        existingApd.AcknowledgeTimeScheduleUid = TimeScheduleIds.TimeSchedule_Never;
                        //if (incomingApd.IsActive == false && existingApd.AcknowledgeTimeScheduleUid != TimeScheduleIds.TimeSchedule_Never)
                        //    incomingApd.IsActive = true;
                        existingApd.UpdateDate = DateTimeOffset.Now;
                        existingApd.UpdateName = sessionData.UserName;
                        var updatedApd = _accessPortalAlertEventRepository.Update(existingApd, sessionData, parameters);
                    }
                }

                // Galaxy Panel events

                foreach (var gpd in incomingGalaxyPanelData)
                {
                    var existingGpd = existingGalaxyPanelAlertEvents.FirstOrDefault(o =>
                        o.GalaxyPanelUid == gpd.DeviceId &&
                        o.GalaxyPanelAlertEventTypeUid == gpd.AlertEventTypeUid);
                    if (existingGpd != null)
                    {
                        if (existingGpd.AcknowledgeTimeScheduleUid != gpd.AcknowledgeTimeScheduleUid ||
                            (gpd.AcknowledgeTimeScheduleUid != TimeScheduleIds.TimeSchedule_Never &&
                             existingGpd.IsActive == false))
                        {
                            existingGpd.AcknowledgeTimeScheduleUid = gpd.AcknowledgeTimeScheduleUid;
                            if (existingGpd.IsActive == false &&
                                gpd.AcknowledgeTimeScheduleUid != TimeScheduleIds.TimeSchedule_Never)
                                existingGpd.IsActive = true;
                            existingGpd.UpdateDate = DateTimeOffset.Now;
                            existingGpd.UpdateName = sessionData.UserName;
                            var updatedApd =
                                _galaxyPanelAlertEventRepository.Update(existingGpd, sessionData, parameters);
                        }
                    }
                }


                var existingGpNotNever = existingGalaxyPanelAlertEvents
                    .Where(o => o.AcknowledgeTimeScheduleUid != TimeScheduleIds.TimeSchedule_Never).ToList();
                foreach (var existingGpd in existingGpNotNever)
                {
                    var incomingApd = incomingGalaxyPanelData.FirstOrDefault(o =>
                        o.DeviceId == existingGpd.GalaxyPanelUid &&
                        o.AlertEventTypeUid == existingGpd.GalaxyPanelAlertEventTypeUid);
                    if (incomingApd == null || incomingApd.AcknowledgeTimeScheduleUid == TimeScheduleIds.TimeSchedule_Never)
                    {
                        existingGpd.AcknowledgeTimeScheduleUid = TimeScheduleIds.TimeSchedule_Never;
                        //if (incomingApd.IsActive == false && existingApd.AcknowledgeTimeScheduleUid != TimeScheduleIds.TimeSchedule_Never)
                        //    incomingApd.IsActive = true;
                        existingGpd.UpdateDate = DateTimeOffset.Now;
                        existingGpd.UpdateName = sessionData.UserName;
                        var updatedApd = _galaxyPanelAlertEventRepository.Update(existingGpd, sessionData, parameters);
                    }
                }


                // Input Device 

                foreach (var idd in incomingInputDeviceData)
                {
                    var existingIdd = existingInputDeviceAlertEvents.FirstOrDefault(o =>
                        o.InputDeviceUid == idd.DeviceId &&
                        o.InputDeviceAlertEventTypeUid == idd.AlertEventTypeUid);
                    if (existingIdd != null)
                    {
                        if (existingIdd.AcknowledgeTimeScheduleUid != idd.AcknowledgeTimeScheduleUid ||
                            (idd.AcknowledgeTimeScheduleUid != TimeScheduleIds.TimeSchedule_Never &&
                             existingIdd.IsActive == false))
                        {
                            existingIdd.AcknowledgeTimeScheduleUid = idd.AcknowledgeTimeScheduleUid;
                            if (existingIdd.IsActive == false &&
                                idd.AcknowledgeTimeScheduleUid != TimeScheduleIds.TimeSchedule_Never)
                                existingIdd.IsActive = true;
                            existingIdd.UpdateDate = DateTimeOffset.Now;
                            existingIdd.UpdateName = sessionData.UserName;
                            var updatedApd =
                                _inputDeviceEventPropertiesRepository.Update(existingIdd, sessionData, parameters);
                        }
                    }
                }


                var existingIdNotNever = existingInputDeviceAlertEvents
                    .Where(o => o.AcknowledgeTimeScheduleUid != TimeScheduleIds.TimeSchedule_Never).ToList();
                foreach (var existingIdd in existingIdNotNever)
                {
                    var incomingApd = incomingInputDeviceData.FirstOrDefault(o =>
                        o.DeviceId == existingIdd.InputDeviceUid &&
                        o.AlertEventTypeUid == existingIdd.InputDeviceAlertEventTypeUid);
                    if (incomingApd == null || incomingApd.AcknowledgeTimeScheduleUid == TimeScheduleIds.TimeSchedule_Never)
                    {
                        existingIdd.AcknowledgeTimeScheduleUid = TimeScheduleIds.TimeSchedule_Never;
                        //if (incomingApd.IsActive == false && existingApd.AcknowledgeTimeScheduleUid != TimeScheduleIds.TimeSchedule_Never)
                        //    incomingApd.IsActive = true;
                        existingIdd.UpdateDate = DateTimeOffset.Now;
                        existingIdd.UpdateName = sessionData.UserName;
                        var updatedApd = _inputDeviceEventPropertiesRepository.Update(existingIdd, sessionData, parameters);
                    }
                }
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
                throw;
            }
            return GetForEntityId(parameters.Data.EntityId, isActive);
        }

        private IEnumerable<DeviceAlertEventSettingsViewPDSA> Flatten(EntityDeviceAlertEventSettings data)
        {
            var flattened = new List<DeviceAlertEventSettingsViewPDSA>();
            if (data != null)
            {
                var entityId = data.EntityId;
                //var galaxyPanels = data.Data.Where(o => o.DeviceTypeCode == DeviceTypeCode.GalaxyPanel.ToString());
                //var accessPortals = data.Data.Where(o => o.DeviceTypeCode == DeviceTypeCode.AccessPortal.ToString());
                //var inputDevices = data.Data.Where(o => o.DeviceTypeCode == DeviceTypeCode.InputDevice.ToString());
                foreach (var o in data.Data)
                {
                    foreach (var p in o.Devices)
                    {
                        foreach (var et in o.EventTypes)
                        {
                            flattened.Add(new DeviceAlertEventSettingsViewPDSA()
                            {
                                EntityId = entityId,
                                DeviceType = o.DeviceType,
                                ClusterUid = o.Cluster.Id,
                                AcknowledgeTimeScheduleUid = o.Schedule.Id,
                                DeviceId = p.Id,
                                AlertEventTypeUid = et.Id
                            });
                        }
                    }
                }
            }

            return flattened;
        }


        public ValidationProblemDetails Validate(EntityDeviceAlertEventSettings data, ISaveParameters saveParams, IApplicationUserSessionDataHeader sessionData)
        {
            var response = new ValidationProblemDetails();
            var errorsArray = new List<string>();
            var tsRepo = _dataRepositoryFactory.GetDataRepository<ITimeScheduleRepository>();
            var clusterRepo = _dataRepositoryFactory.GetDataRepository<IClusterRepository>();
            var accessPortalRepo = _dataRepositoryFactory.GetDataRepository<IAccessPortalRepository>();
            var galaxyPanelRepo = _dataRepositoryFactory.GetDataRepository<IGalaxyPanelRepository>();
            var inputDeviceRepo = _dataRepositoryFactory.GetDataRepository<IInputDeviceRepository>();

            var accessPortalUidsForEntity = accessPortalRepo.GetAllPrimaryKeyUidsForEntityId(data.EntityId);
            var galaxyPanelUidsForEntity = galaxyPanelRepo.GetAllPrimaryKeyUidsForEntityId(data.EntityId);
            var inputDeviceUidsForEntity = inputDeviceRepo.GetAllPrimaryKeyUidsForEntityId(data.EntityId);

            var idxDeviceAlertEventSetting = 0;

            foreach (var o in data.Data)
            {
                // Validate that the Cluster.Id belongs to the entity (data.EntityId)
                var clusterEntityId = clusterRepo.GetEntityId(o.Cluster.Id);
                if (clusterEntityId != data.EntityId)
                {
                    errorsArray.Add(
                        $"{nameof(Cluster)} with {nameof(Cluster.ClusterUid)}:'{o.Cluster.Id}' ({o.Cluster.Name}) is not found or is not associated with entity '{data.EntityId}' - ({data.EntityName}).");
                    response.Errors.Add($"{nameof(data)}[{idxDeviceAlertEventSetting}]", errorsArray.ToArray());
                }

                var accessPortalUidsForCluster = accessPortalRepo.GetAllPrimaryKeyUidsForClusterUid(data.EntityId);
                var galaxyPanelUidsForCluster = galaxyPanelRepo.GetAllPrimaryKeyUidsForClusterUid(data.EntityId);
                var inputDeviceUidsForCluster = inputDeviceRepo.GetAllPrimaryKeyUidsForClusterUid(data.EntityId);

                // Validate that the specified Schedule.Id is mapped to the cluster
                var tsUids = tsRepo.GetUidsForCluster(o.Cluster.Id);
                if (!tsUids.Contains(o.Schedule.Id))
                {
                    errorsArray.Add(
                        $"{nameof(TimeSchedule)} with {nameof(TimeSchedule.TimeScheduleUid)}:'{o.Schedule.Id}' ({o.Schedule.Name}) is not found or is not mapped with the cluster '{o.Cluster.Id}' - ({o.Cluster.Name}).");
                    response.Errors.Add($"{nameof(data)}[{idxDeviceAlertEventSetting}]", errorsArray.ToArray());
                }

                // Validate that the Devices[x].Id are associated with the Cluster.Id

                var idxDevice = 0;
                if (o.DeviceType == DeviceType.AccessPortal.ToString())
                {
                    foreach (var d in o.Devices)
                    {
                        if (!accessPortalUidsForEntity.Contains(d.Id))
                        {
                            errorsArray.Add(
                                $"{nameof(AccessPortal)} with {nameof(AccessPortal.AccessPortalUid)}:'{d.Id}' ({d.Name}) is not found or is not associated with entity '{data.EntityId}' - ({data.EntityName}).");
                            response.Errors.Add($"{nameof(data)}[{idxDeviceAlertEventSetting}].{nameof(o.Devices)}[{idxDevice}]", errorsArray.ToArray());
                        }
                    }

                    idxDevice++;
                }

                if (o.DeviceType == DeviceType.GalaxyPanel.ToString())
                {
                    foreach (var d in o.Devices)
                    {
                        if (!galaxyPanelUidsForEntity.Contains(d.Id))
                        {
                            errorsArray.Add(
                                $"{nameof(GalaxyPanel)} with {nameof(GalaxyPanel.GalaxyPanelUid)}:'{d.Id}' ({d.Name}) is not found or is not associated with entity '{data.EntityId}' - ({data.EntityName}).");
                            response.Errors.Add($"{nameof(data)}[{idxDeviceAlertEventSetting}].{nameof(o.Devices)}[{idxDevice}]", errorsArray.ToArray());
                        }
                    }

                    idxDevice++;
                }

                if (o.DeviceType == DeviceType.InputDevice.ToString())
                {
                    foreach (var d in o.Devices)
                    {
                        if (!inputDeviceUidsForEntity.Contains(d.Id))
                        {
                            errorsArray.Add(
                                $"{nameof(InputDevice)} with {nameof(InputDevice.InputDeviceUid)}:'{d.Id}' ({d.Name}) is not found or is not associated with entity '{data.EntityId}' - ({data.EntityName}).");
                            response.Errors.Add($"{nameof(data)}[{idxDeviceAlertEventSetting}].{nameof(o.Devices)}[{idxDevice}]", errorsArray.ToArray());
                        }
                    }

                    idxDevice++;
                }
                //if (!saveParams.Ignore(nameof(AccessPortal.AlertEvents)))
                //{
                //    var alertEventResults = ValidateAlertEvents(data.AlertEvents, data.ClusterUid,
                //        nameof(data.AlertEvents), tsUids, sessionData);
                //    response.Merge(alertEventResults);
                //}

                idxDeviceAlertEventSetting++;
            }

            return response;
        }

    }
}

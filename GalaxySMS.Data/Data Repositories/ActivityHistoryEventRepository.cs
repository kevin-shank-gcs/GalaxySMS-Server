using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Business.Entities;
using GalaxySMS.BusinessLayer;
using GalaxySMS.Common.Enums;
using GalaxySMS.Data.Contracts;
using GalaxySMS.DataLayer;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Extensions;
using GCS.Core.Common.Logger;
using GCS.Core.Common.Utils;
using Exception = System.Exception;

namespace GalaxySMS.Data
{
    [Export(typeof(IActivityHistoryEventRepository))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class ActivityHistoryEventRepository : IActivityHistoryEventRepository
    {
        [Import] private IDataRepositoryFactory _dataRepositoryFactory;

        public IArrayResponse<ActivityHistoryEvent> GetActivityHistoryEvents(IApplicationUserSessionDataHeader sessionData, ActivityHistoryEventSearchParameters parameters)
        {
            try
            {
                var response = new ArrayResponse<ActivityHistoryEvent>();

                AcknowledgedAlarmBasicData_ByActivityEventUidPDSAManager ackMgr = null;
                //if (parameters.IncludeAcknowlegements)
                //    ackMgr = new AcknowledgedAlarmBasicData_ByActivityEventUidPDSAManager();
                var mgr = new select_ActivityHistoryPDSAManager
                {
                    Entity =
                    {
                        EntityId = parameters.UniqueId,
                        UserId = parameters.UserId
                    }
                };

                if (!parameters.StartDateTime.HasValue)
                    parameters.StartDateTime = DateTimeOffset.MinValue;
                if (!parameters.EndDateTime.HasValue)
                    parameters.EndDateTime = DateTimeOffset.MaxValue;

                if (parameters.StartDateTime <= DateTimeOffset.Now.MinSqlDateTime())
                    parameters.StartDateTime = DateTimeOffset.Now.MinSqlDateTime();
                if (parameters.EndDateTime.HasValue && parameters.EndDateTime < parameters.StartDateTime)
                    parameters.EndDateTime = DateTimeOffset.UtcNow.AddDays(1);

                mgr.Entity.StartDateTime = parameters.StartDateTime.Value;
                mgr.Entity.EndDateTime = parameters.EndDateTime.Value;
                mgr.Entity.ClusterUid = parameters.ClusterUid;
                mgr.Entity.DeviceUid = parameters.DeviceUid;
                mgr.Entity.PersonUid = parameters.PersonUid;
                mgr.Entity.IsAcknowledgeable = parameters.IsAcknowledgeable;
                mgr.Entity.IsActionRequired = parameters.IsActionRequired;
                mgr.Entity.IsTraced = parameters.IsTraced;
                mgr.Entity.StartPriority = parameters.StartPriority;
                mgr.Entity.EndPriority = parameters.EndPriority;
                mgr.Entity.JustNumber = parameters.JustNumber;

                mgr.Entity.Priorities = parameters.Priorities.ToSeparatedString(',', false);
                mgr.Entity.EventTypeUids = parameters.EventTypeUids.ToSeparatedString(',', true);
                mgr.Entity.PageNumber = parameters.PageNumber;
                mgr.Entity.PageSize = parameters.PageSize;
                mgr.Entity.SortColumn = nameof(ActivityHistoryEvent.ActivityDateTime);

                mgr.Entity.DescendingOrder = parameters.DescendingOrder;
                mgr.Entity.IncludeLoggingOnOffEvents = parameters.IncludeLoggingOnOffEvents;
                var pdsaCollection = mgr.BuildCollection();
                if (pdsaCollection != null)
                {
                    var results = new List<ActivityHistoryEvent>();
                    foreach (var pdsaEntity in pdsaCollection)
                    {
                        var convertedEntity = new ActivityHistoryEvent();
                        SimpleMapper.PropertyMap(pdsaEntity, convertedEntity);
                        results.Add(convertedEntity);
                        if (parameters.JustNumber)
                            break;
                        if (parameters.IncludeAcknowlegements && convertedEntity.AckCount > 0 )
                        {
                            ackMgr = new AcknowledgedAlarmBasicData_ByActivityEventUidPDSAManager
                            {
                                Entity =
                                {
                                    ActivityEventUid = convertedEntity.PK
                                }
                            };
                            var acknowlegements = ackMgr.BuildCollection();
                            if (acknowlegements != null)
                            {
                                convertedEntity.Acknowledgements = acknowlegements.ToAcknowledgedAlarmBasicDataCollection();
                            }
                            else
                            {
                                convertedEntity.Acknowledgements = new List<AcknowledgedAlarmBasicData>();
                            }
                        }
                    }

                    var first = results.FirstOrDefault();
                    var totalItemCount = 0;
                    if (first != null)
                    {
                        totalItemCount = first.TotalItemCount;
                        if (parameters.JustNumber)
                            results.Clear();
                    }

                    return ArrayResponseHelpers.ToArrayResponse(results, parameters.PageNumber, parameters.PageSize, totalItemCount);
                }

                return response;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalRepository::GetEntities", ex);
                throw;
            }

        }
        public IArrayResponse<ActivityHistoryEvent> GetActivityEvents(IApplicationUserSessionDataHeader sessionData, ActivityHistoryEventSearchParameters parameters)
        {
            try
            {
                var response = new ArrayResponse<ActivityHistoryEvent>();

                ActivityEventAcknowledgementPDSA_ByActivityEventUidPDSAManager ackMgr = null;
                //if (parameters.IncludeAcknowlegements)
                //    ackMgr = new AcknowledgedAlarmBasicData_ByActivityEventUidPDSAManager();
                var mgr = new select_ActivityEventsPDSAManager
                {
                    Entity =
                    {
                        EntityId = parameters.UniqueId,
                        UserId = parameters.UserId
                    }
                };

                if (!parameters.StartDateTime.HasValue)
                    parameters.StartDateTime = DateTimeOffset.MinValue;
                if (!parameters.EndDateTime.HasValue)
                    parameters.EndDateTime = DateTimeOffset.MaxValue;

                if (parameters.StartDateTime <= DateTimeOffset.Now.MinSqlDateTime())
                    parameters.StartDateTime = DateTimeOffset.Now.MinSqlDateTime();
                if (parameters.EndDateTime.HasValue && parameters.EndDateTime < parameters.StartDateTime)
                    parameters.EndDateTime = DateTimeOffset.UtcNow.AddDays(1);

                mgr.Entity.StartDateTime = parameters.StartDateTime.Value;
                mgr.Entity.EndDateTime = parameters.EndDateTime.Value;
                mgr.Entity.ClusterUid = parameters.ClusterUid;
                mgr.Entity.DeviceUid = parameters.DeviceUid;
                mgr.Entity.PersonUid = parameters.PersonUid;
                mgr.Entity.IsAcknowledgeable = parameters.IsAcknowledgeable;
                mgr.Entity.IsActionRequired = parameters.IsActionRequired;
                mgr.Entity.IsTraced = parameters.IsTraced;
                mgr.Entity.StartPriority = parameters.StartPriority;
                mgr.Entity.EndPriority = parameters.EndPriority;
                mgr.Entity.JustNumber = parameters.JustNumber;

                mgr.Entity.Priorities = parameters.Priorities.ToSeparatedString(',', false);
                mgr.Entity.EventTypeUids = parameters.EventTypeUids.ToSeparatedString(',', true);
                mgr.Entity.PageNumber = parameters.PageNumber;
                mgr.Entity.PageSize = parameters.PageSize;
                mgr.Entity.SortColumn = nameof(ActivityHistoryEvent.ActivityDateTime);

                mgr.Entity.DescendingOrder = parameters.DescendingOrder;
                mgr.Entity.IncludeLoggingOnOffEvents = parameters.IncludeLoggingOnOffEvents;
                var pdsaCollection = mgr.BuildCollection();
                if (pdsaCollection != null)
                {
                    var results = new List<ActivityHistoryEvent>();
                    foreach (var pdsaEntity in pdsaCollection)
                    {
                        var convertedEntity = new ActivityHistoryEvent();
                        SimpleMapper.PropertyMap(pdsaEntity, convertedEntity);
                        results.Add(convertedEntity);
                        if (parameters.JustNumber)
                            break;
                        if (parameters.IncludeAcknowlegements && convertedEntity.AckCount > 0)
                        {
                            ackMgr = new ActivityEventAcknowledgementPDSA_ByActivityEventUidPDSAManager
                            {
                                Entity =
                                {
                                    ActivityEventUid = convertedEntity.PK
                                }
                            };
                            var acknowlegements = ackMgr.BuildCollection();
                            if (acknowlegements != null)
                            {
                                convertedEntity.Acknowledgements = acknowlegements.ToAcknowledgedAlarmBasicDataCollection();
                            }
                            else
                            {
                                convertedEntity.Acknowledgements = new List<AcknowledgedAlarmBasicData>();
                            }
                        }
                    }

                    var first = results.FirstOrDefault();
                    var totalItemCount = 0;
                    if (first != null)
                    {
                        totalItemCount = first.TotalItemCount;
                        if (parameters.JustNumber)
                            results.Clear();
                    }

                    return ArrayResponseHelpers.ToArrayResponse(results, parameters.PageNumber, parameters.PageSize, totalItemCount);
                }

                return response;
            }
            catch (Exception ex)
            {
                this.Log().Error($"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");//AccessPortalRepository::GetEntities", ex);
                throw;
            }

        }

        public EventFilterData GetEventFilterData(IApplicationUserSessionDataHeader sessionData, EventFilterDataSelectionParameters parameters)
        {
            try
            {
                var response = new EventFilterData();

                if (parameters != null)
                {
                    if (parameters.PersonUid != Guid.Empty)
                    {
                        var personRepo = _dataRepositoryFactory.GetDataRepository<IPersonRepository>();
                        var persons = personRepo.SearchForPersonSummary(sessionData,
                            new PersonSummarySearchParameters() { PersonUid = parameters.PersonUid, SearchType = PersonSearchType.ByPersonUid });
                        var p = persons.FirstOrDefault();
                        if (p != null)
                        {
                            response.LastName = p.LastName;
                            response.FirstName = p.FirstName;
                        }
                    }

                    if (parameters.ClusterUid != Guid.Empty)
                    {
                        var clusterRepo = _dataRepositoryFactory.GetDataRepository<IClusterRepository>();
                        var c = clusterRepo.Get(parameters.ClusterUid, sessionData, new GetParametersWithPhoto() { IncludeMemberCollections = false, IncludePhoto = false, IncludeCommands = false });
                        if (c != null)
                        {
                            response.ClusterName = c.ClusterName;
                        }
                    }

                    var mgr = new GetDeviceInformationPDSAManager();
                    if (parameters.AccessPortalUid != Guid.Empty)
                    {
                        mgr.Entity.Uid = parameters.AccessPortalUid;
                        mgr.Entity.DeviceType = DeviceType.AccessPortal.ToString();
                    }
                    else if (parameters.InputDeviceUid != Guid.Empty)
                    {
                        mgr.Entity.Uid = parameters.InputDeviceUid;
                        mgr.Entity.DeviceType = DeviceType.InputDevice.ToString();
                    }
                    else if (parameters.OutputDeviceUid != Guid.Empty)
                    {
                        mgr.Entity.Uid = parameters.OutputDeviceUid;
                        mgr.Entity.DeviceType = DeviceType.OutputDevice.ToString();
                    }
                    else if (parameters.GalaxyPanelUid != Guid.Empty)
                    {
                        mgr.Entity.Uid = parameters.GalaxyPanelUid;
                        mgr.Entity.DeviceType = DeviceType.GalaxyPanel.ToString();
                    }

                    var data = mgr.BuildCollection();
                    if (data != null)
                    {
                        var o = data.FirstOrDefault();
                        if (o != null)
                        {
                            response.DeviceName = o.Name;
                            response.DeviceType = o.DeviceType;
                        }
                    }

                    if (parameters.EventTypeUIds != null && parameters.EventTypeUIds.Any())
                    {
                        var eventTypeRepo =
                            _dataRepositoryFactory.GetDataRepository<IGalaxyActivityEventTypeRepository>();
                        var eventTypes = eventTypeRepo.GetAll(sessionData, new GetParametersWithPhoto());
                        foreach (var etId in parameters.EventTypeUIds.Distinct())
                        {
                            var et = eventTypes.FirstOrDefault(e => e.GalaxyActivityEventTypeUid == etId);
                            if (et != null)
                            {
                                response.EventTypes.Add(new EventType()
                                {
                                    Id = et.GalaxyActivityEventTypeUid,
                                    Name = et.Display
                                });
                            }
                        }
                    }
                }

                return response;
            }
            catch (Exception ex)
            {
                this.Log().Error(
                    $"{System.Reflection.MethodBase.GetCurrentMethod()?.Name} exception: {ex.ToString()}");
                throw;
            }
        }
    }
}

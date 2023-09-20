using GalaxySMS.Api.Models.RequestModels;
using GalaxySMS.Common.Enums;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using ApiEntities = GalaxySMS.Business.Entities.Api.NetCore;
using GCS.Core.Common.Extensions;


namespace GalaxySMS.Api.Support
{
    public class SaveGalaxyPanelExamples : IExamplesProvider<SaveParams<GalaxyPanelReq>>
    {
        SaveParams<GalaxyPanelReq> IExamplesProvider<SaveParams<GalaxyPanelReq>>.GetExamples()
        {
            var data = new GalaxyPanelReq()
            {
                ClusterUid = Guid.Empty,
                PanelNumber = 0,
                PanelName = "Sample Panel Name",
                Location = "Sample Location",
                GalaxyPanelModel = Common.Enums.GalaxyPanelModel.GalaxyPanel635,
                Cpus = new List<GalaxyCpuReq>(),
                InterfaceBoards = new List<GalaxyInterfaceBoardReq>(),
                AlertEvents = new List<GalaxyPanelAlertEventReq>()
            };

            data.Cpus.Add(new GalaxyCpuReq()
            {
                CpuNumber = 1,
                IsActive = true,
                DefaultEventLoggingOn = true
            });

            // Add 1 635 DRM
            var ib635DRM = new GalaxyInterfaceBoardReq()
            {
                BoardNumber = 1,
                BoardType = Common.Enums.GalaxyInterfaceBoardType.DualReaderInterfaceBoard635
            };

            data.InterfaceBoards.Add(ib635DRM);

            // Add 1 635 DSI
            var ib635DSI = new GalaxyInterfaceBoardReq()
            {
                BoardNumber = 2,
                BoardType = Common.Enums.GalaxyInterfaceBoardType.DualSerialInterfaceBoard635,
                InterfaceBoardSections = new List<GalaxyInterfaceBoardSectionReq>(),
            };

            // DSI section 1 with two 635 input modules
            var inputModuleSection = new GalaxyInterfaceBoardSectionReq()
            {
                SectionNumber = 1,
                SectionMode = Common.Enums.PanelInterfaceBoardSectionType.RS485InputModule,
                IsSectionActive = true,
                GalaxyHardwareModules = new List<GalaxyHardwareModuleReq>(),
            };

            for (short moduleNumber = 1; moduleNumber <= 2; moduleNumber++)
            {
                var inputModule = new GalaxyHardwareModuleReq
                {
                    ModuleNumber = moduleNumber,
                    IsModuleActive = true,
                    ModuleType = Common.Enums.GalaxyHardwareModuleType.InputModule16,
                    GalaxyInterfaceBoardSectionNodes = new List<GalaxyInterfaceBoardSectionNodeReq>(),
                };

                for (short x = 1; x <= 16; x++)
                {
                    inputModule.GalaxyInterfaceBoardSectionNodes.Add(new GalaxyInterfaceBoardSectionNodeReq()
                    {
                        NodeNumber = x,
                        IsNodeActive = true,
                    });
                }

                inputModuleSection.GalaxyHardwareModules.Add(inputModule);
            }

            ib635DSI.InterfaceBoardSections.Add(inputModuleSection);

            // DSI section 2 = relay modules module
            var outputModuleSection = new GalaxyInterfaceBoardSectionReq()
            {
                SectionNumber = 2,
                SectionMode = Common.Enums.PanelInterfaceBoardSectionType.OutputRelays,
                IsSectionActive = true,
                GalaxyHardwareModules = new List<GalaxyHardwareModuleReq>(),
            };

            for (short moduleNumber = 1; moduleNumber <= 3; moduleNumber++)
            {
                var relayModule = new GalaxyHardwareModuleReq
                {
                    ModuleNumber = moduleNumber,
                    IsModuleActive = true,
                    ModuleType = Common.Enums.GalaxyHardwareModuleType.RelayModule8,
                    GalaxyInterfaceBoardSectionNodes = new List<GalaxyInterfaceBoardSectionNodeReq>(),
                };
                for (short x = 1; x <= 8; x++)
                {
                    relayModule.GalaxyInterfaceBoardSectionNodes.Add(new GalaxyInterfaceBoardSectionNodeReq()
                    {
                        NodeNumber = x,
                        IsNodeActive = true,
                    });
                }

                outputModuleSection.GalaxyHardwareModules.Add(relayModule);
            }

            ib635DSI.InterfaceBoardSections.Add(outputModuleSection);

            data.InterfaceBoards.Add(ib635DSI);

            data.AlertEvents.Add(new GalaxyPanelAlertEventReq()
            {
                GalaxyPanelAlertEventTypeUid = GalaxySMS.Common.Constants.GalaxyPanelAlertEventTypeIds.ACFailure,
                AlertEventType = GalaxyPanelAlertEventType.ACFailure,
            });

            data.AlertEvents.Add(new GalaxyPanelAlertEventReq()
            {
                GalaxyPanelAlertEventTypeUid = GalaxySMS.Common.Constants.GalaxyPanelAlertEventTypeIds.LowBattery,
                AlertEventType = GalaxyPanelAlertEventType.LowBattery,
            });

            data.AlertEvents.Add(new GalaxyPanelAlertEventReq()
            {
                GalaxyPanelAlertEventTypeUid = GalaxySMS.Common.Constants.GalaxyPanelAlertEventTypeIds.Tamper,
                AlertEventType = GalaxyPanelAlertEventType.Tamper,
            });

            data.AlertEvents.Add(new GalaxyPanelAlertEventReq()
            {
                GalaxyPanelAlertEventTypeUid = GalaxySMS.Common.Constants.GalaxyPanelAlertEventTypeIds.EmergencyUnlock,
                AlertEventType = GalaxyPanelAlertEventType.EmergencyUnlock,
            });
            return new SaveParams<GalaxyPanelReq>()
            {
                Data = data,
            };
        }
    }
    public class SaveGalaxyPanelPutExamples : IExamplesProvider<SaveParams<GalaxyPanelPutReq>>
    {
        SaveParams<GalaxyPanelPutReq> IExamplesProvider<SaveParams<GalaxyPanelPutReq>>.GetExamples()
        {
            var data = new GalaxyPanelPutReq()
            {
                ClusterUid = Guid.Empty,
                PanelNumber = 0,
                PanelName = "Sample Panel Name",
                Location = "Sample Location",
                GalaxyPanelModel = Common.Enums.GalaxyPanelModel.GalaxyPanel635,
                Cpus = new List<GalaxyCpuPutReq>(),
                InterfaceBoards = new List<GalaxyInterfaceBoardPutReq>(),
                AlertEvents = new List<GalaxyPanelAlertEventPutReq>()
            };

            data.Cpus.Add(new GalaxyCpuPutReq()
            {
                CpuNumber = 1,
                IsActive = true,
                DefaultEventLoggingOn = true
            });

            // Add 1 635 DRM
            var ib635DRM = new GalaxyInterfaceBoardPutReq()
            {
                BoardNumber = 1,
                BoardType = Common.Enums.GalaxyInterfaceBoardType.DualReaderInterfaceBoard635
            };

            data.InterfaceBoards.Add(ib635DRM);

            // Add 1 635 DSI
            var ib635DSI = new GalaxyInterfaceBoardPutReq()
            {
                BoardNumber = 2,
                BoardType = Common.Enums.GalaxyInterfaceBoardType.DualSerialInterfaceBoard635,
                InterfaceBoardSections = new List<GalaxyInterfaceBoardSectionPutReq>(),
            };

            // DSI section 1 with two 635 input modules
            var inputModuleSection = new GalaxyInterfaceBoardSectionPutReq()
            {
                SectionNumber = 1,
                SectionMode = Common.Enums.PanelInterfaceBoardSectionType.RS485InputModule,
                IsSectionActive = true,
                GalaxyHardwareModules = new List<GalaxyHardwareModulePutReq>(),
            };

            for (short moduleNumber = 1; moduleNumber <= 2; moduleNumber++)
            {
                var inputModule = new GalaxyHardwareModulePutReq
                {
                    ModuleNumber = moduleNumber,
                    IsModuleActive = true,
                    ModuleType = Common.Enums.GalaxyHardwareModuleType.InputModule16,
                    GalaxyInterfaceBoardSectionNodes = new List<GalaxyInterfaceBoardSectionNodePutReq>(),
                };

                for (short x = 1; x <= 16; x++)
                {
                    inputModule.GalaxyInterfaceBoardSectionNodes.Add(new GalaxyInterfaceBoardSectionNodePutReq()
                    {
                        NodeNumber = x,
                        IsNodeActive = true,
                    });
                }

                inputModuleSection.GalaxyHardwareModules.Add(inputModule);
            }

            ib635DSI.InterfaceBoardSections.Add(inputModuleSection);

            // DSI section 2 = relay modules module
            var outputModuleSection = new GalaxyInterfaceBoardSectionPutReq()
            {
                SectionNumber = 2,
                SectionMode = Common.Enums.PanelInterfaceBoardSectionType.OutputRelays,
                IsSectionActive = true,
                GalaxyHardwareModules = new List<GalaxyHardwareModulePutReq>(),
            };

            for (short moduleNumber = 1; moduleNumber <= 3; moduleNumber++)
            {
                var relayModule = new GalaxyHardwareModulePutReq
                {
                    ModuleNumber = moduleNumber,
                    IsModuleActive = true,
                    ModuleType = Common.Enums.GalaxyHardwareModuleType.RelayModule8,
                    GalaxyInterfaceBoardSectionNodes = new List<GalaxyInterfaceBoardSectionNodePutReq>(),
                };
                for (short x = 1; x <= 8; x++)
                {
                    relayModule.GalaxyInterfaceBoardSectionNodes.Add(new GalaxyInterfaceBoardSectionNodePutReq()
                    {
                        NodeNumber = x,
                        IsNodeActive = true,
                    });
                }

                outputModuleSection.GalaxyHardwareModules.Add(relayModule);
            }

            ib635DSI.InterfaceBoardSections.Add(outputModuleSection);

            data.InterfaceBoards.Add(ib635DSI);

            data.AlertEvents.Add(new GalaxyPanelAlertEventPutReq()
            {
                GalaxyPanelAlertEventTypeUid = GalaxySMS.Common.Constants.GalaxyPanelAlertEventTypeIds.ACFailure,
                AlertEventType = GalaxyPanelAlertEventType.ACFailure,
            });

            data.AlertEvents.Add(new GalaxyPanelAlertEventPutReq()
            {
                GalaxyPanelAlertEventTypeUid = GalaxySMS.Common.Constants.GalaxyPanelAlertEventTypeIds.LowBattery,
                AlertEventType = GalaxyPanelAlertEventType.LowBattery,
            });

            data.AlertEvents.Add(new GalaxyPanelAlertEventPutReq()
            {
                GalaxyPanelAlertEventTypeUid = GalaxySMS.Common.Constants.GalaxyPanelAlertEventTypeIds.Tamper,
                AlertEventType = GalaxyPanelAlertEventType.Tamper,
            });

            data.AlertEvents.Add(new GalaxyPanelAlertEventPutReq()
            {
                GalaxyPanelAlertEventTypeUid = GalaxySMS.Common.Constants.GalaxyPanelAlertEventTypeIds.EmergencyUnlock,
                AlertEventType = GalaxyPanelAlertEventType.EmergencyUnlock,
            });

            return new SaveParams<GalaxyPanelPutReq>()
            {
                Data = data,
            };
        }
    }

    public class SaveApiEntitiesGalaxyPanelExamples : IExamplesProvider<SaveParams<ApiEntities.GalaxyPanel>>
    {
        SaveParams<ApiEntities.GalaxyPanel> IExamplesProvider<SaveParams<ApiEntities.GalaxyPanel>>.GetExamples()
        {
            return new SaveParams<ApiEntities.GalaxyPanel>()
            {
                Data = new ApiEntities.GalaxyPanel()
                {
                    ClusterUid = Globals.Instance.ClusterUid,
                }

            };
        }
    }


    public class
        GetHistoryApiEntitiesGalaxyPanelExamples : IExamplesProvider<
            GalaxyPanelActivityHistoryEventSearchParametersReq>
    {
        GalaxyPanelActivityHistoryEventSearchParametersReq
            IExamplesProvider<GalaxyPanelActivityHistoryEventSearchParametersReq>.GetExamples()
        {
            var data = new GalaxyPanelActivityHistoryEventSearchParametersReq()
            {
                StartDateTime = DateTimeOffset.Now.Today() - new TimeSpan(7, 0, 0, 0),
                EndDateTime = DateTimeOffset.Now,
            };

            return data;
        }
    }
}
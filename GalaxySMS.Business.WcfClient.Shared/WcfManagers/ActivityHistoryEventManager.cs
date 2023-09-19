using GalaxySMS.Business.Entities;
#if NETCOREAPP
using GalaxySMS.Client.Contracts.NetCore;
#else
using GalaxySMS.Client.Contracts;
#endif
using GalaxySMS.Client.SDK.DataClasses;
using GCS.Core.Common;
using GCS.Core.Common.ServiceModel;
using System;
using System.Collections.Generic;
using System.ServiceModel;
//using System.Threading.Channels;
using System.Threading.Tasks;

namespace GalaxySMS.Client.SDK.Managers
{
    public class ActivityHistoryEventManager : ManagerBase
    {
        #region Private fields
        #endregion

        #region Public properties

        #endregion

        #region Constructor

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ActivityHistoryEventManager()
        {

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="galaxySiteServerConnection">   The galaxy site server connection. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ActivityHistoryEventManager(IGalaxySiteServerConnection galaxySiteServerConnection)
            : base(galaxySiteServerConnection)
        {
        }
        #endregion

        #region Public Methods

        public async Task<ArrayResponse<ActivityHistoryEvent>> GetActivityHistoryEventsAsync(ActivityHistoryEventSearchParameters parameters)
        {
            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                    {
                        var data = await proxy.GetActivityHistoryEventsAsync(parameters);
                        return data;
                    });
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                AddError(new CustomError(ex.Detail));
            }
            catch (FaultException<ExceptionDetailEx> ex)
            {
                AddError(new CustomError(ex.Detail));
            }
            catch (Exception ex)
            {
                AddError(new CustomError(ex.Message));
            }
            return null;
        }

        public async Task<EventFilterData> GetEventFilterDataAsync(EventFilterDataSelectionParameters parameters)
        {
            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                    {
                        var data = await proxy.GetEventFilterDataAsync(parameters);
                        return data;
                    });
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                AddError(new CustomError(ex.Detail));
            }
            catch (FaultException<ExceptionDetailEx> ex)
            {
                AddError(new CustomError(ex.Detail));
            }
            catch (Exception ex)
            {
                AddError(new CustomError(ex.Message));
            }
            return null;

        }

        //public async Task<GalaxyActivityEventType[]> GetAllGalaxyActivityEventTypesAsync(GetParametersWithPhoto parameters)
        //{
        //    try
        //    {
        //        return await WithClientFuncAsync(
        //            _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
        //                GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
        //            {
        //                var data = await proxy.GetAllGalaxyActivityEventTypeAsync(parameters);
        //                return data;
        //            });
        //    }
        //    catch (FaultException<ExceptionDetail> ex)
        //    {
        //        AddError(new CustomError(ex.Detail));
        //    }
        //    catch (FaultException<ExceptionDetailEx> ex)
        //    {
        //        AddError(new CustomError(ex.Detail));
        //    }
        //    catch (Exception ex)
        //    {
        //        AddError(new CustomError(ex.Message));
        //    }
        //    return null;

        //}

        public async Task<EntityDeviceAlertEventSettings> GetDeviceAlertEventSettingsAsync(GetParametersWithPhoto parameters)
        {
            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                    {
                        var data = await proxy.GetDeviceAlertEventSettingsAsync(parameters);
                        return data;
                    });
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                AddError(new CustomError(ex.Detail));
            }
            catch (FaultException<ExceptionDetailEx> ex)
            {
                AddError(new CustomError(ex.Detail));
            }
            catch (Exception ex)
            {
                AddError(new CustomError(ex.Message));
            }
            return null;

        }

        public async Task<EntityDeviceAlertEventSettings> SaveDeviceAlertEventSettingsAsync(SaveParameters<EntityDeviceAlertEventSettings> parameters)
        {
            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                    {
                        var data = await proxy.SaveDeviceAlertEventSettingsAsync(parameters);
                        return data;
                    });
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                AddError(new CustomError(ex.Detail));
            }
            catch (FaultException<ExceptionDetailEx> ex)
            {
                AddError(new CustomError(ex.Detail));
            }
            catch (Exception ex)
            {
                AddError(new CustomError(ex.Message));
            }
            return null;

        }
        #endregion

    }
}

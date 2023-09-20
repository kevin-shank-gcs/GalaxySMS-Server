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
using System.Linq;
using System.ServiceModel;
//using System.Threading.Channels;
using System.Threading.Tasks;

namespace GalaxySMS.Client.SDK.Managers
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Manager for alarm event acknowledges. </summary>
    ///
    /// <remarks>   Kevin, 4/29/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class AlarmEventAcknowledgeManager : ManagerBase
    {
        #region Private fields

        #endregion

        #region Public properties

        #endregion

        #region Constructor

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 4/29/2019. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AlarmEventAcknowledgeManager() : base()
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 4/29/2019. </remarks>
        ///
        /// <param name="galaxySiteServerConnection">   The galaxy site server connection. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AlarmEventAcknowledgeManager(IGalaxySiteServerConnection galaxySiteServerConnection)
            : base(galaxySiteServerConnection)
        {
        }

        #endregion

        #region Public methods

        #region Acknowledge Alarm Event

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Acknowledge alarm event. </summary>
        ///
        /// <remarks>   Kevin, 4/29/2019. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A GUID. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AcknowledgedAlarmBasicData AcknowledgeAlarmEvent(SaveParameters<AcknowledgeAlarmEventParameters> parameters)
        {
            InitializeErrorsCollection();
            AcknowledgedAlarmBasicData data = null;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            data = proxy.AcknowledgeAlarmEvent(parameters);
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
                        if (Errors.Count != 0)
                            OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
                    });
            return data;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Acknowledge alarm event asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 4/29/2019. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;Guid&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<AcknowledgedAlarmBasicData> AcknowledgeAlarmEventAsync(SaveParameters<AcknowledgeAlarmEventParameters> parameters)
        {
            InitializeErrorsCollection();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var data = await proxy.AcknowledgeAlarmEventAsync(parameters);
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
        #region Acknowledge Alarm Event

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Acknowledge alarm event. </summary>
        ///
        /// <remarks>   Kevin, 4/29/2019. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A GUID. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int UnacknowledgeAlarmEvent(SaveParameters<UnacknowledgeAlarmEventParameters> parameters)
        {
            InitializeErrorsCollection();
            int data = 0;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            data = proxy.UnacknowledgeAlarmEvent(parameters);
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
                        if (Errors.Count != 0)
                            OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
                    });
            return data;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Acknowledge alarm event asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 4/29/2019. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;Guid&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<int> UnacknowledgeAlarmEventAsync(SaveParameters<UnacknowledgeAlarmEventParameters> parameters)
        {
            InitializeErrorsCollection();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var data = await proxy.UnacknowledgeAlarmEventAsync(parameters);
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

            return 0;
        }

        #endregion

        #region Get Unacknowledged Alarms

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets unacknowledged alarms. </summary>
        ///
        /// <remarks>   Kevin, 4/30/2019. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The unacknowledged alarms. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ICollection<PanelActivityLogMessage> GetUnacknowledgedAlarms(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            var results = new List<PanelActivityLogMessage>();
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            var data = proxy.GetUnacknowledgedAlarms(parameters);
                            if( data != null)
                            results = data.ToList();
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
                        if (Errors.Count != 0)
                            OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
                    });
            return results;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets unacknowledged alarms asynchronous. </summary>
        ///
        /// <remarks>   Set the parameters.CurrentEntityId value to the entity that you want alarms for. Guid.Empty will return all unacknowledged alarms </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The unacknowledged alarms asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ICollection<PanelActivityLogMessage>> GetUnacknowledgedAlarmsAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var data = await proxy.GetUnacknowledgedAlarmsAsync(parameters);
                            return data.ToList();
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

            return new List<PanelActivityLogMessage>();
        }
        #endregion
        #endregion

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Raises the errors occurred event. </summary>
        ///
        /// <remarks>   Set the parameters.CurrentEntityId value to the entity that you want alarms for. Guid.Empty will return all unacknowledged alarms </remarks>
        ///
        /// <param name="e">    Event information to send to registered event handlers. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected override void OnErrorsOccurred(ErrorsOccurredEventArgs e)
        {
            base.OnErrorsOccurred(e);
        }
    }
}
////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Managers\SeedDatabaseManager.cs
//
// summary:	Implements the role manager class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Client.Contracts;
using GalaxySMS.Client.Entities;
using GalaxySMS.Client.SDK.DataClasses;
using GCS.Core.Common;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Logger;
using GCS.Core.Common.ServiceModel;

namespace GalaxySMS.Client.SDK.Managers
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Manager for panel data processings. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class PanelDataProcessingManager : ManagerBase
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

        public PanelDataProcessingManager() : base()
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="galaxySiteServerConnection">   The galaxy site server connection. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public PanelDataProcessingManager(IGalaxySiteServerConnection galaxySiteServerConnection)
            : base(galaxySiteServerConnection)
        {
        }

        #endregion

        #region Public methods

        #region SavePanelDataPacketLog

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves a panel data packet log. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void SavePanelDataPacketLog(PanelDataPacketLog parameters)
        {
            InitializeErrorsCollection();
            bool result = false;
            WithClient<IPanelDataProcessingService>(
                _ServiceFactory.CreateClient<IPanelDataProcessingService>(Binding,
                    GetServiceAddress(ServiceNames.PanelDataProcessingService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            proxy.SavePanelDataPacketLog(parameters);
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

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves a panel data packet log asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task SavePanelDataPacketLogAsync(PanelDataPacketLog parameters)
        {
            InitializeErrorsCollection();
            bool result = false;

            try
            {
                WithClient(
                    _ServiceFactory.CreateClient<IPanelDataProcessingService>(Binding,
                        GetServiceAddress(ServiceNames.PanelDataProcessingService), ClientUserSessionData), async proxy =>
                        {
                            await proxy.SavePanelDataPacketLogAsync(parameters);
                        });
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                AddError(new CustomError(ex.Detail));
            }
            catch (FaultException<ExceptionDetailEx> ex)
            {
                AddError(new CustomError(ex.Message));
            }
            catch (Exception ex)
            {
                AddError(new CustomError(ex.Message));
            }
        }

        #endregion

        #region GetGalaxyCpuDatabaseInformation

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets galaxy CPU database information. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="cpuHardwareAddress">   The CPU hardware address. </param>
        ///
        /// <returns>   The galaxy CPU database information. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyCpuDatabaseInformation GetGalaxyCpuDatabaseInformation(CpuHardwareAddress cpuHardwareAddress)
        {
            InitializeErrorsCollection();
            GalaxyCpuDatabaseInformation data = null;
            WithClient<IPanelDataProcessingService>(
                _ServiceFactory.CreateClient<IPanelDataProcessingService>(Binding,
                    GetServiceAddress(ServiceNames.PanelDataProcessingService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            data = proxy.GetGalaxyCpuDatabaseInformation(cpuHardwareAddress);
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
        /// <summary>   Gets galaxy CPU database information asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="cpuHardwareAddress">   The CPU hardware address. </param>
        ///
        /// <returns>   The galaxy CPU database information asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<GalaxyCpuDatabaseInformation> GetGalaxyCpuDatabaseInformationAsync(CpuHardwareAddress cpuHardwareAddress)
        {
            InitializeErrorsCollection();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IPanelDataProcessingService>(Binding,
                        GetServiceAddress(ServiceNames.PanelDataProcessingService), ClientUserSessionData), async proxy =>
                        {
                            var data = await proxy.GetGalaxyCpuDatabaseInformationAsync(cpuHardwareAddress);
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

        public async Task<bool> UpdateGalaxyCpuConnectionAsync(GalaxyCpuConnection cpuConnection)
        {
            InitializeErrorsCollection();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IPanelDataProcessingService>(Binding,
                        GetServiceAddress(ServiceNames.PanelDataProcessingService), ClientUserSessionData), async proxy =>
                    {
                        await proxy.UpdateGalaxyCpuConnectionAsync(cpuConnection);
                        return true;
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

            return true;
        }

        #endregion

        #region GetGalaxyCpuDatabaseInformation

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets galaxy cluster panel information. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="cpuHardwareAddress">   The CPU hardware address. </param>
        ///
        /// <returns>   The galaxy cluster panel information. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyCpuDatabaseInformation GetGalaxyClusterPanelInformation(CpuHardwareAddress cpuHardwareAddress)
        {
            InitializeErrorsCollection();
            GalaxyCpuDatabaseInformation data = null;
            WithClient<IPanelDataProcessingService>(
                _ServiceFactory.CreateClient<IPanelDataProcessingService>(Binding,
                    GetServiceAddress(ServiceNames.PanelDataProcessingService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            data = proxy.GetGalaxyClusterPanelInformation(cpuHardwareAddress);
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
        /// <summary>   Gets galaxy cluster panel information asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="cpuHardwareAddress">   The CPU hardware address. </param>
        ///
        /// <returns>   The galaxy cluster panel information asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<GalaxyCpuDatabaseInformation> GetGalaxyClusterPanelInformationAsync(CpuHardwareAddress cpuHardwareAddress)
        {
            InitializeErrorsCollection();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<IPanelDataProcessingService>(Binding,
                        GetServiceAddress(ServiceNames.PanelDataProcessingService), ClientUserSessionData), async proxy =>
                        {
                            var data = await proxy.GetGalaxyClusterPanelInformationAsync(cpuHardwareAddress);
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
        #endregion

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Raises the errors occurred event. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    Event information to send to registered event handlers. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected override void OnErrorsOccurred(ErrorsOccurredEventArgs e)
        {
            base.OnErrorsOccurred(e);
        }
    }
}
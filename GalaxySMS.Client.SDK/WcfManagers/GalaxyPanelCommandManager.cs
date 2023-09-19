////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Managers\GalaxyPanelCommandManager.cs
//
// summary:	Implements the GalaxyPanelCommand manager class
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
    /// <summary>   Manager for galaxy panel commands. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class GalaxyPanelCommandManager : ManagerBase
    {
        #region Private fields

        /// <summary>   The galaxy panel commands. </summary>
        private List<GalaxyPanelCommand> _GalaxyPanelCommands;

        #endregion

        #region Public properties

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the galaxy panel commands. </summary>
        ///
        /// <value> The galaxy panel commands. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<GalaxyPanelCommand> GalaxyPanelCommands { get; internal set; }

        #endregion

        #region Constructor

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyPanelCommandManager() : base()
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="galaxySiteServerConnection">   The galaxy site server connection. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyPanelCommandManager(IGalaxySiteServerConnection galaxySiteServerConnection)
            : base(galaxySiteServerConnection)
        {
            _GalaxyPanelCommands = new List<GalaxyPanelCommand>();
        }

        #endregion

        #region Public methods

        #region Get All Commands

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all galaxy panel commands. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all galaxy panel commands. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<GalaxyPanelCommand> GetAllGalaxyPanelCommands(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _GalaxyPanelCommands = new List<GalaxyPanelCommand>();

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            var data = proxy.GetAllGalaxyPanelCommands(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _GalaxyPanelCommands.Add(o);
                            }
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

            GalaxyPanelCommands = new ReadOnlyCollection<GalaxyPanelCommand>(_GalaxyPanelCommands);
            return GalaxyPanelCommands;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all galaxy panel commands asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all galaxy panel commands asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ReadOnlyCollection<GalaxyPanelCommand>> GetAllGalaxyPanelCommandsAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _GalaxyPanelCommands = new List<GalaxyPanelCommand>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var data = await proxy.GetAllGalaxyPanelCommandsAsync(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _GalaxyPanelCommands.Add(o);
                            }
                            GalaxyPanelCommands = new ReadOnlyCollection<GalaxyPanelCommand>(_GalaxyPanelCommands);
                            return GalaxyPanelCommands;
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

            return GalaxyPanelCommands;
        }

        #endregion

        #region Get All Commands for Panel Model

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all galaxy panel commands for panel model. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all galaxy panel commands for panel model. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<GalaxyPanelCommand> GetAllGalaxyPanelCommandsForPanelModel(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _GalaxyPanelCommands = new List<GalaxyPanelCommand>();

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            var data = proxy.GetGalaxyPanelCommandsByPanelModel(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _GalaxyPanelCommands.Add(o);
                            }
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

            GalaxyPanelCommands = new ReadOnlyCollection<GalaxyPanelCommand>(_GalaxyPanelCommands);
            return GalaxyPanelCommands;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all galaxy panel commands for type asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all galaxy panel commands for type asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ReadOnlyCollection<GalaxyPanelCommand>> GetAllGalaxyPanelCommandsForTypeAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _GalaxyPanelCommands = new List<GalaxyPanelCommand>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var data = await proxy.GetGalaxyPanelCommandsByPanelModelAsync(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _GalaxyPanelCommands.Add(o);
                            }
                            GalaxyPanelCommands = new ReadOnlyCollection<GalaxyPanelCommand>(_GalaxyPanelCommands);
                            return GalaxyPanelCommands;
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

            return GalaxyPanelCommands;
        }

        #endregion

        #region Delete

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the galaxy panel command described by parameters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   An int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int DeleteGalaxyPanelCommand(DeleteParameters<GalaxyPanelCommand> parameters)
        {
            int countDeleted = 0;
            InitializeErrorsCollection();
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            countDeleted = proxy.DeleteGalaxyPanelCommand(parameters);
                            if(countDeleted == 1)
                                _GalaxyPanelCommands.Remove(parameters.Data);
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
            return countDeleted;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the galaxy panel command asynchronous described by parameters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;int&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<int> DeleteGalaxyPanelCommandAsync(DeleteParameters<GalaxyPanelCommand> parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            int countDeleted = 0;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            // For some reason, the DeleteSiteAsync throws a WCF exception
                            countDeleted = await proxy.DeleteGalaxyPanelCommandAsync(parameters);
                            if(countDeleted == 1 )
                            {
                                _GalaxyPanelCommands.Remove(parameters.Data);
                                GalaxyPanelCommands = new ReadOnlyCollection<GalaxyPanelCommand>(_GalaxyPanelCommands);
                                
                            }
                            return countDeleted;
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
            return countDeleted;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Deletes the galaxy panel command by unique identifier described by parameters.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   An int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int DeleteGalaxyPanelCommandByUniqueId(DeleteParameters parameters)
        {
            InitializeErrorsCollection();
            int countDeleted = 0;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            countDeleted = proxy.DeleteGalaxyPanelCommandByPk(parameters);
                            if (countDeleted == 1)
                            {
                                foreach (var o in _GalaxyPanelCommands)
                                {
                                    if (o.GalaxyPanelCommandUid == parameters.UniqueId)
                                    {
                                        _GalaxyPanelCommands.Remove(o);
                                        break;
                                    }
                                }
                                GalaxyPanelCommands = new ReadOnlyCollection<GalaxyPanelCommand>(_GalaxyPanelCommands);
                            }
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
            return countDeleted;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Deletes the galaxy panel command by unique identifier asynchronous described by
        /// parameters.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;int&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<int> DeleteGalaxyPanelCommandByUniqueIdAsync(DeleteParameters parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            int countDeleted = 0;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            countDeleted = await proxy.DeleteGalaxyPanelCommandByPkAsync(parameters);
                            if( countDeleted == 1)
                            {
                                foreach (var o in _GalaxyPanelCommands)
                                {
                                    if (o.GalaxyPanelCommandUid == parameters.UniqueId)
                                    {
                                        _GalaxyPanelCommands.Remove(o);
                                        break;
                                    }
                                }
                                GalaxyPanelCommands = new ReadOnlyCollection<GalaxyPanelCommand>(_GalaxyPanelCommands);
                            }
                            return countDeleted;
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
            return countDeleted;
        }

        #endregion

        #region Save

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves a galaxy panel command. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A GalaxyPanelCommand. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyPanelCommand SaveGalaxyPanelCommand(SaveParameters<GalaxyPanelCommand> parameters)
        {
            InitializeErrorsCollection();
            GalaxyPanelCommand savedItem = null;
            bool isNew = (parameters.Data.GalaxyPanelCommandUid == Guid.Empty);
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            savedItem = proxy.SaveGalaxyPanelCommand(parameters);
                            if (isNew == false)
                            {
                                var originalItem = (from i in _GalaxyPanelCommands
                                    where i.GalaxyPanelCommandUid == parameters.Data.GalaxyPanelCommandUid
                                    select i).FirstOrDefault();
                                if (originalItem != null)
                                    _GalaxyPanelCommands.Remove(originalItem);
                            }
                            _GalaxyPanelCommands.Add(savedItem);
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
                    });

            if (Errors.Count != 0)
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));

            return savedItem;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves a galaxy panel command asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;GalaxyPanelCommand&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<GalaxyPanelCommand> SaveGalaxyPanelCommandAsync(SaveParameters<GalaxyPanelCommand> parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            GalaxyPanelCommand savedItem = null;
            bool isNew = false;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            isNew = (parameters.Data.GalaxyPanelCommandUid == Guid.Empty);
                            savedItem = await proxy.SaveGalaxyPanelCommandAsync(parameters);
                            if( isNew == false)
                            {
                                var originalItem = (from i in _GalaxyPanelCommands
                                    where i.GalaxyPanelCommandUid == parameters.Data.GalaxyPanelCommandUid
                                    select i).FirstOrDefault();
                                if (originalItem != null)
                                    _GalaxyPanelCommands.Remove(originalItem);
                            }
                            _GalaxyPanelCommands.Add(savedItem);
                            return savedItem;
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

            return savedItem;
        }

        #endregion

        #region Get by Uid

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets galaxy panel command. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The galaxy panel command. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyPanelCommand GetGalaxyPanelCommand(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            GalaxyPanelCommand GalaxyPanelCommand = null;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            GalaxyPanelCommand = proxy.GetGalaxyPanelCommand(parameters);
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
                    });

            if (Errors.Count != 0)
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));

            return GalaxyPanelCommand;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets galaxy panel command asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The galaxy panel command asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<GalaxyPanelCommand> GetGalaxyPanelCommandAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            GalaxyPanelCommand GalaxyPanelCommand = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            GalaxyPanelCommand = await proxy.GetGalaxyPanelCommandAsync(parameters);
                            return GalaxyPanelCommand;
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

            return GalaxyPanelCommand;
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
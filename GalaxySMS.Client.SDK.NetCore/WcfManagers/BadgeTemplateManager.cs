////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Managers\RoleManager.cs
//
// summary:	Implements the role manager class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Business.Entities;
using GalaxySMS.Client.Contracts.NetCore;
using GalaxySMS.Client.SDK.DataClasses;
using GCS.Core.Common;
using GCS.Core.Common.Logger;
using GCS.Core.Common.ServiceModel;

namespace GalaxySMS.Client.SDK.Managers
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Manager for badge templates. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class BadgeTemplateManager : ManagerBase
    {
        #region Private fields

        /// <summary>   The badgetemplates. </summary>
        private List<BadgeTemplate> _BadgeTemplates;
        private List<ListItemBase> _BadgeTemplatesList;

        #endregion

        #region Public properties

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the badgetemplates. </summary>
        ///
        /// <value> The badgetemplates. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<BadgeTemplate> BadgeTemplates { get; internal set; }

        public ReadOnlyCollection<ListItemBase> BadgeTemplatesList { get; internal set; }
        #endregion

        #region Constructor

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public BadgeTemplateManager() : base()
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="galaxySiteServerConnection">   The galaxy site server connection. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public BadgeTemplateManager(IGalaxySiteServerConnection galaxySiteServerConnection)
            : base(galaxySiteServerConnection)
        {
            _BadgeTemplates = new List<BadgeTemplate>();
        }

        #endregion

        #region Public methods

        #region Get all badgetemplates for entity


        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the badgetemplates. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="ex">           Thrown when an ex error condition occurs. </exception>
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        /// <param name="rethrow">      True to rethrow. </param>
        ///
        /// <returns>   The badgetemplates. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<BadgeTemplate> GetBadgeTemplates(GetParametersWithPhoto parameters, bool rethrow)
        {
            InitializeErrorsCollection();
            _BadgeTemplates = new List<BadgeTemplate>();

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            BadgeTemplate[] badgetemplates = proxy.GetAllBadgeTemplatesForEntity(parameters);
                            if (badgetemplates != null)
                            {
                                foreach (var region in badgetemplates)
                                {
                                    _BadgeTemplates.Add(region);
                                }
                            }
                        }
                        catch (FaultException<ExceptionDetail> ex)
                        {
                            AddError(new CustomError(ex.Detail));
                            if (rethrow)
                                throw ex;
                        }
                        catch (FaultException<ExceptionDetailEx> ex)
                        {
                            AddError(new CustomError(ex.Detail));
                            if (rethrow)
                                throw ex;
                        }
                        catch (Exception ex)
                        {
                            AddError(new CustomError(ex.Message));
                            if (rethrow)
                                throw ex;
                        }
                        if (Errors.Count != 0)
                            OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
                    });

            BadgeTemplates = new ReadOnlyCollection<BadgeTemplate>(_BadgeTemplates);
            return BadgeTemplates;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets badgetemplates asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The badgetemplates asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ReadOnlyCollection<BadgeTemplate>> GetBadgeTemplatesAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _BadgeTemplates = new List<BadgeTemplate>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            BadgeTemplate[] badgetemplates = await proxy.GetAllBadgeTemplatesForEntityAsync(parameters);
                            if (badgetemplates != null)
                            {
                                foreach (var region in badgetemplates)
                                    _BadgeTemplates.Add(region);
                            }
                            BadgeTemplates = new ReadOnlyCollection<BadgeTemplate>(_BadgeTemplates);
                            return BadgeTemplates;
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

            return BadgeTemplates;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets badgetemplates list items. </summary>
        ///
        /// <exception cref="ex">           Thrown when an ex error condition occurs. </exception>
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        /// <param name="rethrow">      True to rethrow. </param>
        ///
        /// <returns>   The badgetemplates list items. </returns>
        ///=================================================================================================

        public ReadOnlyCollection<ListItemBase> GetBadgeTemplatesListItems(GetParametersWithPhoto parameters, bool rethrow)
        {
            InitializeErrorsCollection();
            _BadgeTemplatesList = new List<ListItemBase>();

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            var badgetemplates = proxy.GetAllBadgeTemplatesListEntity(parameters);
                            if (badgetemplates != null)
                            {
                                foreach (var region in badgetemplates)
                                {
                                    _BadgeTemplatesList.Add(region);
                                }
                            }
                        }
                        catch (FaultException<ExceptionDetail> ex)
                        {
                            AddError(new CustomError(ex.Detail));
                            if (rethrow)
                                throw ex;
                        }
                        catch (FaultException<ExceptionDetailEx> ex)
                        {
                            AddError(new CustomError(ex.Detail));
                            if (rethrow)
                                throw ex;
                        }
                        catch (Exception ex)
                        {
                            AddError(new CustomError(ex.Message));
                            if (rethrow)
                                throw ex;
                        }
                        if (Errors.Count != 0)
                            OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
                    });

            BadgeTemplatesList = new ReadOnlyCollection<ListItemBase>(_BadgeTemplatesList);
            return BadgeTemplatesList;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets badgetemplates list items asynchronous. </summary>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The badgetemplates list items asynchronous. </returns>
        ///=================================================================================================

        public async Task<ReadOnlyCollection<ListItemBase>> GetBadgeTemplatesListItemsAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _BadgeTemplatesList = new List<ListItemBase>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var badgetemplates = await proxy.GetAllBadgeTemplatesListEntityAsync(parameters);
                            if (badgetemplates != null)
                            {
                                foreach (var region in badgetemplates)
                                    _BadgeTemplatesList.Add(region);
                            }
                            BadgeTemplatesList = new ReadOnlyCollection<ListItemBase>(_BadgeTemplatesList);
                            return BadgeTemplatesList;
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

            return BadgeTemplatesList;
        }

        #endregion

        #region GetAll

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all badgetemplates. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all badgetemplates. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<BadgeTemplate> GetAllBadgeTemplates(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _BadgeTemplates = new List<BadgeTemplate>();

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            BadgeTemplate[] badgetemplates = proxy.GetAllBadgeTemplates(parameters);
                            if (badgetemplates != null)
                            {
                                foreach (var region in badgetemplates)
                                    _BadgeTemplates.Add(region);
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

            BadgeTemplates = new ReadOnlyCollection<BadgeTemplate>(_BadgeTemplates);
            return BadgeTemplates;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all badgetemplates asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all badgetemplates asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ReadOnlyCollection<BadgeTemplate>> GetAllBadgeTemplatesAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _BadgeTemplates = new List<BadgeTemplate>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            BadgeTemplate[] badgetemplates = await proxy.GetAllBadgeTemplatesAsync(parameters);
                            if (badgetemplates != null)
                            {
                                foreach (var region in badgetemplates)
                                    _BadgeTemplates.Add(region);
                            }
                            BadgeTemplates = new ReadOnlyCollection<BadgeTemplate>(_BadgeTemplates);
                            return BadgeTemplates;
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

            return BadgeTemplates;
        }


        public ReadOnlyCollection<ListItemBase> GetAllBadgeTemplatesListItems(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _BadgeTemplatesList = new List<ListItemBase>();

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            var badgetemplates = proxy.GetAllBadgeTemplatesList(parameters);
                            if (badgetemplates != null)
                            {
                                foreach (var region in badgetemplates)
                                    _BadgeTemplatesList.Add(region);
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

            BadgeTemplatesList = new ReadOnlyCollection<ListItemBase>(_BadgeTemplatesList);
            return BadgeTemplatesList;
        }

        public async Task<ReadOnlyCollection<ListItemBase>> GetAllBadgeTemplatesListItemsAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _BadgeTemplatesList = new List<ListItemBase>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var badgetemplates = await proxy.GetAllBadgeTemplatesListAsync(parameters);
                            if (badgetemplates != null)
                            {
                                foreach (var region in badgetemplates)
                                    _BadgeTemplatesList.Add(region);
                            }
                            BadgeTemplatesList = new ReadOnlyCollection<ListItemBase>(_BadgeTemplatesList);
                            return BadgeTemplatesList;
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

            return BadgeTemplatesList;
        }
        #endregion

        #region Delete

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the region described by parameters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   An int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int DeleteBadgeTemplate(DeleteParameters<BadgeTemplate> parameters)
        {
            int ret = 0;
            InitializeErrorsCollection();
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            ret = proxy.DeleteBadgeTemplate(parameters);
                            _BadgeTemplates.Remove(parameters.Data);
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
            return ret;
        }

        //public async Task<int> DeleteBadgeTemplateAsync(DeleteParameters<BadgeTemplate> parameters)
        //{
        //    InitializeErrorsCollection();
        //    DateTimeOffset startedAt = DateTimeOffset.Now;

        //    try
        //    {
        //        await WithClientAsync(
        //            _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
        //                GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
        //                {
        //                    // For some reason, the DeleteBadgeTemplateAsync throws a WCF exception
        //                    //await proxy.DeleteBadgeTemplateAsync(parameters);
        //                    proxy.DeleteBadgeTemplate(parameters);
        //                    _BadgeTemplates.Remove(parameters.Data);
        //                    BadgeTemplates = new ReadOnlyCollection<BadgeTemplate>(_BadgeTemplates);
        //                });
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
        //}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the region asynchronous described by parameters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;int&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<int> DeleteBadgeTemplateAsync(DeleteParameters<BadgeTemplate> parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            int ret = 0;
            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            // For some reason, the DeleteBadgeTemplateAsync throws a WCF exception
                            ret = await proxy.DeleteBadgeTemplateAsync(parameters);
                            _BadgeTemplates.Remove(parameters.Data);
                            BadgeTemplates = new ReadOnlyCollection<BadgeTemplate>(_BadgeTemplates);
                            return ret;
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
            return ret;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the region by unique identifier described by parameters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int DeleteBadgeTemplateByUniqueId(DeleteParameters parameters)
        {
            InitializeErrorsCollection();
            int x = 0;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            x = proxy.DeleteBadgeTemplateByPk(parameters);
                            foreach (var r in _BadgeTemplates)
                            {
                                if (r.BadgeTemplateUid == parameters.UniqueId)
                                {
                                    _BadgeTemplates.Remove(r);
                                    break;
                                }
                            }
                            BadgeTemplates = new ReadOnlyCollection<BadgeTemplate>(_BadgeTemplates);
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
            return x;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Deletes the region by unique identifier asynchronous described by parameters.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<int> DeleteBadgeTemplateByUniqueIdAsync(DeleteParameters parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            int x = 0;
            try
            {
                //return await WithClientAsync(
                return await WithClientFuncAsync(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                    {
                        x = await proxy.DeleteBadgeTemplateByPkAsync(parameters);
                        foreach (var r in _BadgeTemplates)
                        {
                            if (r.BadgeTemplateUid == parameters.UniqueId)
                            {
                                _BadgeTemplates.Remove(r);
                                break;
                            }
                        }
                        BadgeTemplates = new ReadOnlyCollection<BadgeTemplate>(_BadgeTemplates);
                        return x;
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
            return x;
        }

        #endregion

        #region Save

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves a region. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A BadgeTemplate. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public BadgeTemplate SaveBadgeTemplate(SaveParameters<BadgeTemplate> parameters)
        {
            InitializeErrorsCollection();
            BadgeTemplate savedBadgeTemplate = null;
            bool isNew = (parameters.Data.BadgeTemplateUid == Guid.Empty);
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            savedBadgeTemplate = proxy.SaveBadgeTemplate(parameters);
                            if (isNew == false)
                            {
                                var originalItem = (from i in _BadgeTemplates
                                                    where i.BadgeTemplateUid == parameters.Data.BadgeTemplateUid
                                                    select i).FirstOrDefault();
                                if (originalItem != null)
                                    _BadgeTemplates.Remove(originalItem);
                            }
                            _BadgeTemplates.Add(savedBadgeTemplate);
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

            return savedBadgeTemplate;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves a region asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;BadgeTemplate&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<BadgeTemplate> SaveBadgeTemplateAsync(SaveParameters<BadgeTemplate> parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            BadgeTemplate savedBadgeTemplate = null;
            bool isNew = false;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            isNew = (parameters.Data.BadgeTemplateUid == Guid.Empty);
                            savedBadgeTemplate = await proxy.SaveBadgeTemplateAsync(parameters);
                            if (isNew == false)
                            {
                                var originalItem = (from i in _BadgeTemplates
                                                    where i.BadgeTemplateUid == parameters.Data.BadgeTemplateUid
                                                    select i).FirstOrDefault();
                                if (originalItem != null)
                                    _BadgeTemplates.Remove(originalItem);
                            }
                            return savedBadgeTemplate;
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

            return savedBadgeTemplate;
        }

        #endregion

        #region Get by Uid

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets a region. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The region. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public BadgeTemplate GetBadgeTemplate(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            BadgeTemplate region = null;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            region = proxy.GetBadgeTemplate(parameters);
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

            return region;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets region asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The region asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<BadgeTemplate> GetBadgeTemplateAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            BadgeTemplate region = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            region = await proxy.GetBadgeTemplateAsync(parameters);
                            return region;
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

            return region;
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
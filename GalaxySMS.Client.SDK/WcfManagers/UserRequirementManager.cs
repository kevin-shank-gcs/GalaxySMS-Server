////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Managers\EntityManager.cs
//
// summary:	Implements the entity manager class
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
    #region EventArg Classes

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Additional information for get all userRequirements completed events. </summary>
    ///
    /// <remarks>   Kevin, 4/22/2014. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class GetAllUserRequirementsCompletedEventArgs : EventArgsBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 4/22/2014. </remarks>
        ///
        /// <param name="userRequirements">     The userRequirements. </param>
        /// <param name="requestInvokedAt">     The request invoked at Date/Time. </param>
        /// <param name="requestCompletedAt">   The request completed at Date/Time. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GetAllUserRequirementsCompletedEventArgs(ReadOnlyCollection<gcsUserRequirement> userRequirements, DateTimeOffset requestInvokedAt, DateTimeOffset requestCompletedAt)
            : base(requestInvokedAt, requestCompletedAt)
        {
            UserRequirements = userRequirements;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the userRequirements. </summary>
        ///
        /// <value> The userRequirements. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<gcsUserRequirement> UserRequirements { get; internal set; }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Additional information for delete entity completed events. </summary>
    ///
    /// <remarks>   Kevin, 4/22/2014. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class DeleteUserRequirementCompletedEventArgs : EventArgsBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 4/22/2014. </remarks>
        ///
        /// <param name="userRequirement">      The userRequirement. </param>
        /// <param name="requestInvokedAt">     The request invoked at Date/Time. </param>
        /// <param name="requestCompletedAt">   The request completed at Date/Time. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DeleteUserRequirementCompletedEventArgs(gcsUserRequirement userRequirement, DateTimeOffset requestInvokedAt, DateTimeOffset requestCompletedAt)
            : base(requestInvokedAt, requestCompletedAt)
        {
            UserRequirement = userRequirement;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the entity. </summary>
        ///
        /// <value> The entity. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsUserRequirement UserRequirement { get; internal set; }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Additional information for save entity completed events. </summary>
    ///
    /// <remarks>   Kevin, 4/22/2014. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class SaveUserRequirementCompletedEventArgs : EventArgsBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 4/22/2014. </remarks>
        ///
        /// <param name="userRequirement">      The userRequirement. </param>
        /// <param name="isNew">                true if this object is new, false if not. </param>
        /// <param name="requestInvokedAt">     The request invoked at Date/Time. </param>
        /// <param name="requestCompletedAt">   The request completed at Date/Time. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public SaveUserRequirementCompletedEventArgs(gcsUserRequirement userRequirement, Boolean isNew, DateTimeOffset requestInvokedAt, DateTimeOffset requestCompletedAt)
            : base(requestInvokedAt, requestCompletedAt)
        {
            UserRequirement = userRequirement;
            IsNew = isNew;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the entity. </summary>
        ///
        /// <value> The entity. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsUserRequirement UserRequirement { get; internal set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether this object is new. </summary>
        ///
        /// <value> true if this object is new, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Boolean IsNew { get; internal set; }
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Additional information for get user requirement completed events. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class GetUserRequirementCompletedEventArgs : EventArgsBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 4/22/2014. </remarks>
        ///
        /// <param name="userRequirement">      The userRequirement. </param>
        /// <param name="requestInvokedAt">     The request invoked at Date/Time. </param>
        /// <param name="requestCompletedAt">   The request completed at Date/Time. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GetUserRequirementCompletedEventArgs(gcsUserRequirement userRequirement, DateTimeOffset requestInvokedAt, DateTimeOffset requestCompletedAt)
            : base(requestInvokedAt, requestCompletedAt)
        {
            UserRequirement = userRequirement;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the entity. </summary>
        ///
        /// <value> The entity. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsUserRequirement UserRequirement { get; internal set; }
    }
    #endregion

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Manager for user requirements. </summary>
    ///
    /// <remarks>   Kevin, 4/22/2014. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class UserRequirementManager : ManagerBase
    {
        #region Private fields
        /// <summary>   The userRequirements. </summary>
        private List<gcsUserRequirement> _UserRequirements;
        #endregion

        #region Public properties

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the userRequirements. </summary>
        ///
        /// <value> The userRequirements. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<gcsUserRequirement> UserRequirements { get; internal set; }
        #endregion

        #region Events and Delegates

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Delegate for handling GetAllUserRequirementsCompleted events. </summary>
        ///
        /// <remarks>   Kevin, 4/22/2014. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Get all userRequirements completed event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void GetAllUserRequirementsCompletedEventHandler(object sender, GetAllUserRequirementsCompletedEventArgs e);
        /// <summary>   Event queue for all listeners interested in getAllEntitesCompleted events. </summary>
        public event GetAllUserRequirementsCompletedEventHandler GetAllUserRequirementsCompletedEvent;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Delegate for handling DeleteUserRequirementCompleted events. </summary>
        ///
        /// <remarks>   Kevin, 4/22/2014. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Delete userRequirement completed event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void DeleteUserRequirementCompletedEventHandler(object sender, DeleteUserRequirementCompletedEventArgs e);
        /// <summary>   Event queue for all listeners interested in deleteEntityCompleted events. </summary>
        public event DeleteUserRequirementCompletedEventHandler DeleteUserRequirementCompletedEvent;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Delegate for handling SaveUserRequirementCompleted events. </summary>
        ///
        /// <remarks>   Kevin, 4/22/2014. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Save entity completed event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void SaveUserRequirementCompletedEventHandler(object sender, SaveUserRequirementCompletedEventArgs e);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Event queue for all listeners interested in saveUserRequirementCompleted events.
        /// </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public event SaveUserRequirementCompletedEventHandler SaveUserRequirementCompletedEvent;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Delegate for handling GetUserRequirementCompleted events. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Get user requirement completed event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public delegate void GetUserRequirementCompletedEventHandler(object sender, GetUserRequirementCompletedEventArgs e);

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Event queue for all listeners interested in getUserRequirementCompleted events.
        /// </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public event GetUserRequirementCompletedEventHandler GetUserRequirementCompletedEvent;
        #endregion

        #region Constructor

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 4/22/2014. </remarks>
        ///
        /// <param name="galaxySiteServerConnection">   The galaxy site server connection. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public UserRequirementManager(IGalaxySiteServerConnection galaxySiteServerConnection)
            : base(galaxySiteServerConnection)
        {
            _UserRequirements = new List<gcsUserRequirement>();
        }
        #endregion

        #region Public methods

        #region GetAll

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all userRequirements. </summary>
        ///
        /// <remarks>   Kevin, 4/22/2014. </remarks>
        ///
        /// <returns>   all userRequirements. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<gcsUserRequirement> GetAllUserRequirements()
        {
            _UserRequirements = new List<gcsUserRequirement>();
            InitializeErrorsCollection();

            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            gcsUserRequirement[] userRequirements = proxy.GetAllUserRequirements();
                            if (userRequirements != null)
                            {
                                foreach (gcsUserRequirement entity in userRequirements)
                                    _UserRequirements.Add(entity);
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
                    });

            UserRequirements = new ReadOnlyCollection<gcsUserRequirement>(_UserRequirements);
            if (Errors.Count != 0)
                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
            return UserRequirements;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all userRequirements asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 4/22/2014. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void GetAllUserRequirementsAsync()
        {
            _UserRequirements = new List<gcsUserRequirement>();
            InitializeErrorsCollection();

            DateTimeOffset startedAt = DateTimeOffset.Now;

            WithClientAsync<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                    {
                        if (proxy != null)
                        {
                            Func<Task> task = async () =>
                            {
                                Task<gcsUserRequirement[]> t = proxy.GetAllUserRequirementsAsync();
                                gcsUserRequirement[] userRequirements = await t;
                                if (userRequirements != null)
                                {
                                    foreach (gcsUserRequirement entity in userRequirements)
                                    {
                                        _UserRequirements.Add(entity);
                                    }
                                }
                            };
                            try
                            {
                                task().Wait();
                                DateTimeOffset endedAt = DateTimeOffset.Now;
                                var handler = GetAllUserRequirementsCompletedEvent;
                                if (handler != null)
                                {
                                    handler(this,
                                        new GetAllUserRequirementsCompletedEventArgs(
                                            new ReadOnlyCollection<gcsUserRequirement>(_UserRequirements), startedAt, endedAt));
                                }
                            }
                            catch (AggregateException ae)
                            {
                                ae = ae.Flatten();
                                foreach (Exception ex in ae.InnerExceptions)
                                {
                                    AddError(new CustomError(ex.Message));
                                    this.Log().Debug(ex.Message);
                                }
                                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
                            }
                        }
                    });
        }
        #endregion

        #region Delete

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the userRequirements described by entityId. </summary>
        ///
        /// <remarks>   Kevin, 4/22/2014. </remarks>
        ///
        /// <param name="entityId"> The entityId. </param>
        ///
        /// <returns>   The user requirement for entity identifier. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsUserRequirement GetUserRequirementForEntityId(Guid entityId)
        {
            gcsUserRequirement userRequirement = null;
            InitializeErrorsCollection();
            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            userRequirement = proxy.GetUserRequirementForEntity(entityId);
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
            return userRequirement;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the userRequirements asynchronous described by entityId. </summary>
        ///
        /// <remarks>   Kevin, 4/22/2014. </remarks>
        ///
        /// <param name="entityId"> The entityId. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void GetUserRequirementForEntityIdAsync(Guid entityId)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            gcsUserRequirement userRequirement = null;
            WithClientAsync<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                    {
                        if (proxy != null)
                        {
                            Func<Task> task = async () =>
                            {
                                Task<gcsUserRequirement> t = proxy.GetUserRequirementForEntityAsync(entityId);
                                userRequirement = await t;
                            };

                            try
                            {
                                task().Wait();
                                DateTimeOffset endedAt = DateTimeOffset.Now;
                                var handler = GetUserRequirementCompletedEvent;
                                if (handler != null)
                                {
                                    handler(this,
                                        new GetUserRequirementCompletedEventArgs(
                                            userRequirement, startedAt, endedAt));
                                }
                            }
                            catch (AggregateException ae)
                            {
                                ae = ae.Flatten();
                                foreach (Exception ex in ae.InnerExceptions)
                                {
                                    AddError(new CustomError(ex.Message));
                                    this.Log().Debug(ex.Message);
                                }
                                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
                            }
                        }
                    });

        }
        #endregion

        #region Delete

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the entity described by entity. </summary>
        ///
        /// <remarks>   Kevin, 4/22/2014. </remarks>
        ///
        /// <param name="entity">   The entity. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void DeleteUserRequirement(gcsUserRequirement entity)
        {
            InitializeErrorsCollection();
            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            proxy.DeleteUserRequirement(entity);
                            _UserRequirements.Remove(entity);
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
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the entity asynchronous described by entity. </summary>
        ///
        /// <remarks>   Kevin, 4/22/2014. </remarks>
        ///
        /// <param name="entity">   The entity. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void DeleteUserRequirementAsync(gcsUserRequirement entity)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;

            WithClientAsync<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                    {
                        if (proxy != null)
                        {
                            Func<Task> task = async () =>
                            {
                                Task tDelete = proxy.DeleteUserRequirementAsync(entity);
                                await tDelete;
                                _UserRequirements.Remove(entity);
                            };

                            try
                            {
                                task().Wait();
                                DateTimeOffset endedAt = DateTimeOffset.Now;
                                var handler = DeleteUserRequirementCompletedEvent;
                                if (handler != null)
                                {
                                    handler(this,
                                        new DeleteUserRequirementCompletedEventArgs(
                                            entity, startedAt, endedAt));
                                }
                            }
                            catch (AggregateException ae)
                            {
                                ae = ae.Flatten();
                                foreach (Exception ex in ae.InnerExceptions)
                                {
                                    AddError(new CustomError(ex.Message));
                                    this.Log().Debug(ex.Message);
                                }
                                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
                            }
                        }
                    });

        }
        #endregion

        #region Save

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves a user requirement. </summary>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A gcsUserRequirement. </returns>
        ///=================================================================================================

        public gcsUserRequirement SaveUserRequirement(SaveParameters<gcsUserRequirement> parameters)
        {
            InitializeErrorsCollection();
            gcsUserRequirement savedUserRequirement = null;
            bool isNew = (parameters.Data.UserRequirementsId == Guid.Empty);
            WithClient<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), proxy =>
                    {
                        try
                        {

                            savedUserRequirement = proxy.SaveUserRequirement(parameters);
                            _UserRequirements.Add(savedUserRequirement);
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

            return savedUserRequirement;

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves a user requirement asynchronous. </summary>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///=================================================================================================

        public void SaveUserRequirementAsync(SaveParameters<gcsUserRequirement> parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            gcsUserRequirement savedUserRequirement = null;
            bool isNew = false;

            WithClientAsync<IAdministrationService>(
                _ServiceFactory.CreateClient<IAdministrationService>(Binding,
                    GetServiceAddress(ServiceNames.AdministrationService), ClientUserSessionData), async proxy =>
                    {
                        if (proxy != null)
                        {
                            Func<Task> task = async () =>
                            {
                                isNew = (parameters.Data.UserRequirementsId == Guid.Empty);
                                Task<gcsUserRequirement> t = proxy.SaveUserRequirementAsync(parameters);
                                savedUserRequirement = await t;
                            };
                            try
                            {
                                task().Wait();
                                if (savedUserRequirement != null)
                                {
                                    DateTimeOffset endedAt = DateTimeOffset.Now;
                                    var handler = SaveUserRequirementCompletedEvent;
                                    if (handler != null)
                                    {
                                        handler(this,
                                            new SaveUserRequirementCompletedEventArgs(
                                                savedUserRequirement, isNew, startedAt, endedAt));
                                    }
                                }
                            }
                            catch (AggregateException ae)
                            {
                                ae = ae.Flatten();
                                foreach (Exception ex in ae.InnerExceptions)
                                {
                                    AddError(new CustomError(ex.Message));
                                    this.Log().Debug(ex.Message);
                                }
                                OnErrorsOccurred(new ErrorsOccurredEventArgs(Errors));
                            }
                        }
                    });
        }
        #endregion
        #endregion

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Raises the errors occurred event. </summary>
        ///
        /// <remarks>   Kevin, 4/22/2014. </remarks>
        ///
        /// <param name="e">    Event information to send to registered event handlers. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected override void OnErrorsOccurred(ErrorsOccurredEventArgs e)
        {
            base.OnErrorsOccurred(e);
        }
    }
}

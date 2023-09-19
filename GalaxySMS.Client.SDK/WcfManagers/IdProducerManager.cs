////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Managers\PersonManager.cs
//
// summary:	Implements the Person manager class
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

    public class IdProducerManager : ManagerBase
    {
        #region Private fields



        #endregion

        #region Public properties

        #endregion

        #region Constructor

        public IdProducerManager() : base()
        {
        }

        public IdProducerManager(IGalaxySiteServerConnection galaxySiteServerConnection)
            : base(galaxySiteServerConnection)
        {
        }

        #endregion

        #region Public methods
        
        #region EnsureIsLicensed
        public SubscriptionData EnsureIsLicensed(SaveParameters<IdProducerSaveMasterLicenseParameters> parameters)
        {
            InitializeErrorsCollection();
            SubscriptionData returnData = null;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            returnData = proxy.IdProducerEnsureIsLicensed(parameters);
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

            return returnData;
        }

        public async Task<SubscriptionData> EnsureIsLicensedAsync(SaveParameters<IdProducerSaveMasterLicenseParameters> parameters)
        {
            InitializeErrorsCollection();
            SubscriptionData returnData = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            returnData = await proxy.IdProducerEnsureIsLicensedAsync(parameters);
                            return returnData;
                        });
            }
            catch (FaultException<ExceptionDetail> ex)
            {
                //AddError(new CustomError(ex.Detail));
            }
            catch (FaultException<ExceptionDetailEx> ex)
            {
                AddError(new CustomError(ex.Message));
                AddError(new CustomError(ex.Detail));
            }
            catch (Exception ex)
            {
                AddError(new CustomError(ex.Message));
            }

            return returnData;
        }
        #endregion

        #region UpdateRootSubscriptionCompanyName
        public bool UpdateRootSubscriptionCompanyName(SaveParameters<IdProducerUpdateRootCustomerNameParameters> parameters)
        {
            InitializeErrorsCollection();
            var bReturn = false;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            bReturn = proxy.IdProducerUpdateRootSubscriptionCompanyName(parameters);
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

            return bReturn;
        }

        public async Task<bool> UpdateRootSubscriptionCompanyNameAsync(SaveParameters<IdProducerUpdateRootCustomerNameParameters> parameters)
        {
            InitializeErrorsCollection();
            var bReturn = false;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            bReturn = await proxy.IdProducerUpdateRootSubscriptionCompanyNameAsync(parameters);
                            return bReturn;
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

            return bReturn;
        }        
        
        #endregion

        #region SyncSubscriptionAndEntity
        public SubscriptionData SyncSubscriptionAndEntity(SaveParameters<IdProducerSyncSubscriptionAndEntityParameters> parameters)
        {
            InitializeErrorsCollection();
            SubscriptionData returnData = null;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            returnData = proxy.IdProducerSyncSubscriptionAndEntity(parameters);
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

            return returnData;
        }

        public async Task<SubscriptionData> SyncSubscriptionAndEntityAsync(SaveParameters<IdProducerSyncSubscriptionAndEntityParameters> parameters)
        {
            InitializeErrorsCollection();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var retData = await proxy.IdProducerSyncSubscriptionAndEntityAsync(parameters);
                            return retData;
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

        #region GetSubscriptions
        public SubscriptionData[] GetSubscriptions(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            SubscriptionData[] returnData = null;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            returnData = proxy.IdProducerGetSubscriptions(parameters);
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

            return returnData;
        }

        public async Task<SubscriptionData[]> GetSubscriptionsAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var retData = await proxy.IdProducerGetSubscriptionsAsync(parameters);
                            return retData;
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

        #region GetRootSubscription
        public SubscriptionData GetRootSubscription(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            SubscriptionData returnData = null;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            returnData = proxy.IdProducerGetRootSubscription(parameters);
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

            return returnData;
        }

        public async Task<SubscriptionData> GetRootSubscriptionAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var retData = await proxy.IdProducerGetRootSubscriptionAsync(parameters);
                            return retData;
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

        protected override void OnErrorsOccurred(ErrorsOccurredEventArgs e)
        {
            base.OnErrorsOccurred(e);
        }
    }
}
////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Managers\GalaxyFlashImageManager.cs
//
// summary:	Implements the GalaxyFlashImage manager class
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
    /// <summary>   Manager for galaxy CPU Flash Images. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class GalaxyFlashImageManager : ManagerBase
    {
        #region Private fields

        /// <summary>   The galaxy CPU Flash Images. </summary>
        private List<GalaxyFlashImage> _GalaxyFlashImages;

        #endregion

        #region Public properties

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the galaxy CPU Flash Images. </summary>
        ///
        /// <value> The galaxy CPU Flash Images. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<GalaxyFlashImage> GalaxyFlashImages { get; internal set; }

        #endregion

        #region Constructor

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyFlashImageManager() : base()
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="galaxySiteServerConnection">   The galaxy site server connection. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyFlashImageManager(IGalaxySiteServerConnection galaxySiteServerConnection)
            : base(galaxySiteServerConnection)
        {
            _GalaxyFlashImages = new List<GalaxyFlashImage>();
        }

        #endregion

        #region Public methods

        #region Get All Cpu Flash Images

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all galaxy CPU Flash Images. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all galaxy CPU Flash Images. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<GalaxyFlashImage> GetAllGalaxyFlashImages(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _GalaxyFlashImages = new List<GalaxyFlashImage>();

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            var data = proxy.GetAllGalaxyFlashImages(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _GalaxyFlashImages.Add(o);
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

            GalaxyFlashImages = new ReadOnlyCollection<GalaxyFlashImage>(_GalaxyFlashImages);
            return GalaxyFlashImages;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all galaxy CPU Flash Images asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all galaxy CPU Flash Images asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ReadOnlyCollection<GalaxyFlashImage>> GetAllGalaxyFlashImagesAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _GalaxyFlashImages = new List<GalaxyFlashImage>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var data = await proxy.GetAllGalaxyFlashImagesAsync(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _GalaxyFlashImages.Add(o);
                            }
                            GalaxyFlashImages = new ReadOnlyCollection<GalaxyFlashImage>(_GalaxyFlashImages);
                            return GalaxyFlashImages;
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

            return GalaxyFlashImages;
        }

        #endregion

        #region Get All Cpu Flash Images By Cpu Model Type Code

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all galaxy CPU Flash Images. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all galaxy CPU Flash Images. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<GalaxyFlashImage> GetAllGalaxyFlashImagesForGalaxyCpuModelTypeCode(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _GalaxyFlashImages = new List<GalaxyFlashImage>();

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            var data = proxy.GetAllGalaxyFlashImagesForGalaxyCpuModelTypeCode(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _GalaxyFlashImages.Add(o);
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

            GalaxyFlashImages = new ReadOnlyCollection<GalaxyFlashImage>(_GalaxyFlashImages);
            return GalaxyFlashImages;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all galaxy CPU Flash Images asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all galaxy CPU Flash Images asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ReadOnlyCollection<GalaxyFlashImage>> GetAllGalaxyFlashImagesForGalaxyCpuModelTypeCodeAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _GalaxyFlashImages = new List<GalaxyFlashImage>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var data = await proxy.GetAllGalaxyFlashImagesForGalaxyCpuModelTypeCodeAsync(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _GalaxyFlashImages.Add(o);
                            }
                            GalaxyFlashImages = new ReadOnlyCollection<GalaxyFlashImage>(_GalaxyFlashImages);
                            return GalaxyFlashImages;
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

            return GalaxyFlashImages;
        }

        #endregion
        #region Get All Cpu Flash Images By Cpu Model Uid

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all galaxy CPU Flash Images. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all galaxy CPU Flash Images. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<GalaxyFlashImage> GetAllGalaxyFlashImagesForGalaxyCpuModelUid(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _GalaxyFlashImages = new List<GalaxyFlashImage>();

            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            var data = proxy.GetAllGalaxyFlashImagesForGalaxyCpuModelUid(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _GalaxyFlashImages.Add(o);
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

            GalaxyFlashImages = new ReadOnlyCollection<GalaxyFlashImage>(_GalaxyFlashImages);
            return GalaxyFlashImages;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets all galaxy CPU Flash Images asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   all galaxy CPU Flash Images asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<ReadOnlyCollection<GalaxyFlashImage>> GetAllGalaxyFlashImagesForGalaxyCpuModelUidAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            _GalaxyFlashImages = new List<GalaxyFlashImage>();

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            var data = await proxy.GetAllGalaxyFlashImagesForGalaxyCpuModelUidAsync(parameters);
                            if (data != null)
                            {
                                foreach (var o in data)
                                    _GalaxyFlashImages.Add(o);
                            }
                            GalaxyFlashImages = new ReadOnlyCollection<GalaxyFlashImage>(_GalaxyFlashImages);
                            return GalaxyFlashImages;
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

            return GalaxyFlashImages;
        }

        #endregion

        #region Delete

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes the galaxy CPU model described by parameters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   An int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int DeleteGalaxyFlashImage(DeleteParameters<GalaxyFlashImage> parameters)
        {
            int countDeleted = 0;
            InitializeErrorsCollection();
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            countDeleted = proxy.DeleteGalaxyFlashImage(parameters);
                            if(countDeleted == 1)
                                _GalaxyFlashImages.Remove(parameters.Data);
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
        /// <summary>   Deletes the galaxy CPU model asynchronous described by parameters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;int&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<int> DeleteGalaxyFlashImageAsync(DeleteParameters<GalaxyFlashImage> parameters)
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
                            countDeleted = await proxy.DeleteGalaxyFlashImageAsync(parameters);
                            if(countDeleted == 1 )
                            {
                                _GalaxyFlashImages.Remove(parameters.Data);
                                GalaxyFlashImages = new ReadOnlyCollection<GalaxyFlashImage>(_GalaxyFlashImages);
                                
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
        /// Deletes the galaxy CPU model by unique identifier described by parameters.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   An int. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public int DeleteGalaxyFlashImageByUniqueId(DeleteParameters parameters)
        {
            InitializeErrorsCollection();
            int countDeleted = 0;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            countDeleted = proxy.DeleteGalaxyFlashImageByPk(parameters);
                            if (countDeleted == 1)
                            {
                                foreach (var o in _GalaxyFlashImages)
                                {
                                    if (o.GalaxyFlashImageUid == parameters.UniqueId)
                                    {
                                        _GalaxyFlashImages.Remove(o);
                                        break;
                                    }
                                }
                                GalaxyFlashImages = new ReadOnlyCollection<GalaxyFlashImage>(_GalaxyFlashImages);
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
        /// Deletes the galaxy CPU model by unique identifier asynchronous described by parameters.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;int&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<int> DeleteGalaxyFlashImageByUniqueIdAsync(DeleteParameters parameters)
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
                            countDeleted = await proxy.DeleteGalaxyFlashImageByPkAsync(parameters);
                            if( countDeleted == 1)
                            {
                                foreach (var o in _GalaxyFlashImages)
                                {
                                    if (o.GalaxyFlashImageUid == parameters.UniqueId)
                                    {
                                        _GalaxyFlashImages.Remove(o);
                                        break;
                                    }
                                }
                                GalaxyFlashImages = new ReadOnlyCollection<GalaxyFlashImage>(_GalaxyFlashImages);
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
        /// <summary>   Saves a galaxy CPU model. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A GalaxyFlashImage. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyFlashImage SaveGalaxyFlashImage(SaveParameters<GalaxyFlashImage> parameters)
        {
            InitializeErrorsCollection();
            GalaxyFlashImage savedItem = null;
            bool isNew = (parameters.Data.GalaxyFlashImageUid == Guid.Empty);
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            savedItem = proxy.SaveGalaxyFlashImage(parameters);
                            if (isNew == false)
                            {
                                var originalItem = (from i in _GalaxyFlashImages
                                    where i.GalaxyFlashImageUid == parameters.Data.GalaxyFlashImageUid
                                    select i).FirstOrDefault();
                                if (originalItem != null)
                                    _GalaxyFlashImages.Remove(originalItem);
                            }
                            _GalaxyFlashImages.Add(savedItem);
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
        /// <summary>   Saves a galaxy CPU model asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   A Task&lt;GalaxyFlashImage&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<GalaxyFlashImage> SaveGalaxyFlashImageAsync(SaveParameters<GalaxyFlashImage> parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            GalaxyFlashImage savedItem = null;
            bool isNew = false;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            isNew = (parameters.Data.GalaxyFlashImageUid == Guid.Empty);
                            savedItem = await proxy.SaveGalaxyFlashImageAsync(parameters);
                            if( isNew == false)
                            {
                                var originalItem = (from i in _GalaxyFlashImages
                                    where i.GalaxyFlashImageUid == parameters.Data.GalaxyFlashImageUid
                                    select i).FirstOrDefault();
                                if (originalItem != null)
                                    _GalaxyFlashImages.Remove(originalItem);
                            }
                            _GalaxyFlashImages.Add(savedItem);
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
        /// <summary>   Gets galaxy CPU model. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The galaxy CPU model. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GalaxyFlashImage GetGalaxyFlashImage(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            GalaxyFlashImage GalaxyFlashImage = null;
            WithClient<ISystemManagementService>(
                _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                    GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), proxy =>
                    {
                        try
                        {
                            GalaxyFlashImage = proxy.GetGalaxyFlashImage(parameters);
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

            return GalaxyFlashImage;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets galaxy CPU model asynchronous. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameters">   Options for controlling the operation. </param>
        ///
        /// <returns>   The galaxy CPU model asynchronous. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<GalaxyFlashImage> GetGalaxyFlashImageAsync(GetParametersWithPhoto parameters)
        {
            InitializeErrorsCollection();
            DateTimeOffset startedAt = DateTimeOffset.Now;
            GalaxyFlashImage GalaxyFlashImage = null;

            try
            {
                return await WithClientFuncAsync(
                    _ServiceFactory.CreateClient<ISystemManagementService>(Binding,
                        GetServiceAddress(ServiceNames.SystemManagementService), ClientUserSessionData), async proxy =>
                        {
                            GalaxyFlashImage = await proxy.GetGalaxyFlashImageAsync(parameters);
                            return GalaxyFlashImage;
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

            return GalaxyFlashImage;
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
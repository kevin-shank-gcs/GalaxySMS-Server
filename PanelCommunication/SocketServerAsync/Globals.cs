////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Globals.cs
//
// summary:	Implements the globals class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GalaxySMS.Client.Entities;
using GalaxySMS.Client.SDK.DataClasses;
using GalaxySMS.Client.SDK.Helpers;
using GalaxySMS.Client.SDK.Managers;
using GalaxySMS.Common.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCS.Framework.Flash;
using AutoMapper;
using GalaxySMS.Common.AutoMapper;
using GalaxySMS.Common.Constants;
using InputOutputGroup = GalaxySMS.Client.Entities.InputOutputGroup;

namespace GCS.PanelCommunication.PanelCommunicationServerAsync
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A globals. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class Globals
    {
        #region Private fields
        /// <summary>   The instance. </summary>
        private static Globals _instance;
        /// <summary>   Information describing the credential event. </summary>
        private Dictionary<byte[], Credential_ActivityEventData> _credentialEventData = new Dictionary<byte[], Credential_ActivityEventData>();
        // Dictionary of GalaxyActivityEventType keyed by the string EventType value
        private Dictionary<PanelActivityEventCode, GalaxyActivityEventType> _eventTypeData = new Dictionary<PanelActivityEventCode, GalaxyActivityEventType>();
        private Dictionary<Guid, GalaxyFlashImageHelper> _galaxyFlashImages = new Dictionary<Guid, GalaxyFlashImageHelper>();
        private Dictionary<string, InputOutputGroup> _inputOutputGroupData = new Dictionary<string, InputOutputGroup>();
        private readonly object _eventTypeDataLock = new object();
        private readonly object _credentialEventDataLock = new object();
        //private readonly EntityMapperHelper _entityMapper = new EntityMapperHelper();
        #endregion

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Globals()
        {

            var configuration = new MapperConfiguration(cfg => {
                cfg.AddProfile<MappingProfile>();
            });

            Mapper = configuration.CreateMapper();
        }

        #region Public Properties

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the instance. </summary>
        ///
        /// <value> The instance. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static Globals Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Globals();
                }
                return _instance;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the server connection. </summary>
        ///
        /// <value> The server connection. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public IGalaxySiteServerConnection ServerConnection { get; set; }
        public IMapper Mapper { get; internal set; }

        #endregion

        #region Public Methods

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the manager. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <typeparam name="T">    Generic type parameter. </typeparam>
        ///
        /// <returns>   The manager. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public T GetManager<T>() where T : ManagerBase, new()
        {
            var sessionHeader = Globals.Instance.ServerConnection.ClientUserSessionData;
            var manager = Helpers.GetManager<T>(Globals.Instance.ServerConnection.ConnectionSettings.ServerAddress,
                GalaxySiteServerConnectionSettings.WcfBindingType.Tcp, string.Empty, string.Empty, sessionHeader);
            return manager;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets credential activity event data. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="data"> The data. </param>
        ///
        /// <returns>   The credential activity event data. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public async Task<Credential_ActivityEventData> GetCredentialActivityEventData(byte[] data)
        {
            if (data == null)
                return null;

            if (_credentialEventData == null)
            {
                lock (_credentialEventDataLock)
                {
                    _credentialEventData = new Dictionary<byte[], Credential_ActivityEventData>();
                }
            }

            Credential_ActivityEventData returnValue = null;
            lock (_credentialEventDataLock)
            {
                if (_credentialEventData.TryGetValue(data, out returnValue) == true)
                {   // The credential data exists
                    return returnValue;
                }
            }

            var dataMgr = Globals.Instance.GetManager<ActivityEventManager>();
            var c = await dataMgr.GetCredentialActivityEventDataAsync(data);
            if (c != null)
            {
                lock (_credentialEventDataLock)
                {
                    if (_credentialEventData.TryGetValue(data, out returnValue) == true)
                    {   // The credential data exists
                        return returnValue;
                    }
                    _credentialEventData.Add(data, c);
                    return c;
                }
            }

            c = new Credential_ActivityEventData()
            {
                CardBinaryData = data,
            };

            return c;
        }

        public async Task<GalaxyActivityEventType> GetGalaxyActivityEventType(PanelActivityEventCode eventType)
        {
            GalaxyActivityEventType returnValue = null;
            try
            {
                if (_eventTypeData == null)
                {
                    lock (_eventTypeDataLock)
                    {
                        _eventTypeData = new Dictionary<PanelActivityEventCode, GalaxyActivityEventType>();
                    }
                }

                lock (_eventTypeDataLock)
                {
                    if (_eventTypeData.TryGetValue(eventType, out returnValue) == true)
                    {   // The credential data exists
                        return returnValue;
                    }
                }

                var dataMgr = Globals.Instance.GetManager<GalaxyActivityEventTypeManager>();
                var o = await dataMgr.GetGalaxyActivityEventTypeByEventTypeAsync(new GetParametersWithPhoto()
                {
                    GetString = eventType.ToString(),
                });

                if (o != null)
                {
                    lock (_eventTypeDataLock)
                    {
                        if (_eventTypeData.TryGetValue(eventType, out returnValue) == true)
                        {   // The credential data exists
                            return returnValue;
                        }
                        //Trace.WriteLine($"Adding {eventType} to _eventTypeData");
                        _eventTypeData.Add(eventType, o);
                    }
                }


                return o;
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
            return returnValue;
        }

        public async Task<InputOutputGroup> GetInputOutputGroupData(int clusterGroupId, int clusterNumber, int inputOutputGroupNumber)
        {
            var key = string.Format(UniqueHardwareAddressFormat.InputOutputGroup, clusterGroupId, clusterNumber, inputOutputGroupNumber);
            if (_inputOutputGroupData == null)
            {
                lock (_inputOutputGroupData)
                {
                    _inputOutputGroupData = new Dictionary<string, InputOutputGroup>();
                }
            }

            InputOutputGroup returnValue = null;
            lock (_inputOutputGroupData)
            {
                if (_inputOutputGroupData.TryGetValue(key, out returnValue) == true)
                {   // The credential data exists
                    return returnValue;

                }
            }

            var mgr = Globals.Instance.GetManager<GalaxyInputOutputGroupManager>();
            var iog = await mgr.GetInputOutputGroupByClusterAddressAndInputOutputGroupNumberAsync(new GetParametersWithPhoto()
            {
                ClusterGroupId = clusterGroupId,
                ClusterNumber = clusterNumber,
                GetInt32 = inputOutputGroupNumber,
                DoNotValidateAuthorization = true
            });
            if (iog != null)
            {
                lock (_inputOutputGroupData)
                {
                    if (_inputOutputGroupData.TryGetValue(key, out returnValue) == true)
                    {   
                        return returnValue;
                    }
                    _inputOutputGroupData.Add(key, iog);
                    return iog;
                }
            }

            iog = new InputOutputGroup()
            {
                IOGroupNumber = inputOutputGroupNumber,
            };

            return iog;
        }

        public async Task<bool> IsTimeScheduleActive(Guid timeScheduleUid, GalaxySMS.Common.Enums.TimeScheduleType scheduleType, Guid clusterUid, DateTimeOffset dateTime)
        {
            if( timeScheduleUid == GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Always)
                return true;
            if( timeScheduleUid == GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never)
                return false;

            var mgr = Globals.Instance.GetManager<TimeScheduleManager>();

            var isActive = await mgr.IsTimeScheduleActiveAsync(timeScheduleUid, scheduleType, clusterUid, dateTime);
            return isActive;
        }

        public async Task<GalaxyFlashImageHelper> GetGalaxyFlashImage(Guid galaxyFlashImageUid)
        {
            GalaxyFlashImageHelper returnValue = null;
            if (_galaxyFlashImages.TryGetValue(galaxyFlashImageUid, out returnValue))
                return returnValue;

            var mgr = Globals.Instance.GetManager<GalaxyFlashImageManager>();
            var o = await mgr.GetGalaxyFlashImageAsync(new GetParametersWithPhoto() { UniqueId = galaxyFlashImageUid });
            if (o != null)
            {
                returnValue = new GalaxyFlashImageHelper();
                if (returnValue.ReadFlashS28Buffer(o.Data) == true)
                {
                    _galaxyFlashImages.Add(galaxyFlashImageUid, returnValue);
                }
            }
            return returnValue;

        }
        #endregion
    }
}

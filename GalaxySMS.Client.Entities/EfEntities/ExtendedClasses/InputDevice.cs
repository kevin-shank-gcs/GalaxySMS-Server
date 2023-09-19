////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\ExtendedClasses\InputDevice.cs
//
// summary:	Implements the input device class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GCS.Core.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   An input device. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class InputDevice
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public InputDevice() : base()
        {
            Initialize();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The InputDevice to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public InputDevice(InputDevice e) : base(e)
        {
            Initialize(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this InputDevice. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize()
        {
            base.Initialize();
            this.EntityIds = new HashSet<Guid>();
            this.RoleIds = new HashSet<Guid>();
            MappedEntitiesPermissionLevels = new HashSet<EntityIdEntityMapPermissionLevel>();

            this.InputDeviceEventProperties = new HashSet<InputDeviceEventProperty>();
            Notes = new HashSet<Note>();

            GalaxyInputDevice = new GalaxyInputDevice();

            Commands = new HashSet<InputCommand>();

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this InputDevice. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The InputDevice to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize(InputDevice e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.InputDeviceUid = e.InputDeviceUid;
            this.EntityId = e.EntityId;
            this.SiteUid = e.SiteUid;
            this.BinaryResourceUid = e.BinaryResourceUid;
            this.InputName = e.InputName;
            this.Location = e.Location;
            this.ServiceComment = e.ServiceComment;
            this.CriticalityComment = e.CriticalityComment;
            this.Comment = e.Comment;
            this.EMailEventsEnabled = e.EMailEventsEnabled;
            this.TransmitEventsEnabled = e.TransmitEventsEnabled;
            this.FileOutputEnabled = e.FileOutputEnabled;
            //this.IsActive = e.IsActive;
            this.IsTemplate = e.IsTemplate;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            if (e.gcsBinaryResource != null)
                this.gcsBinaryResource = new gcsBinaryResource(e.gcsBinaryResource);
            if (e.EntityIds != null)
                this.EntityIds = e.EntityIds.ToCollection();
            if (e.RoleIds != null)
                this.RoleIds = e.RoleIds.ToCollection();
            if (e.MappedEntitiesPermissionLevels != null)
                this.MappedEntitiesPermissionLevels = e.MappedEntitiesPermissionLevels.ToCollection();
            if (e.Notes != null)
                this.Notes = e.Notes.ToCollection();

            this.GalaxyInputDevice = e.GalaxyInputDevice;

            if (e.InputDeviceEventProperties != null)
                this.InputDeviceEventProperties = e.InputDeviceEventProperties.ToCollection();

            this.RegionName = e.RegionName;
            this.SiteName = e.SiteName;

            this.ClusterUid = e.ClusterUid;
            this.GalaxyPanelUid = e.GalaxyPanelUid;
            this.ClusterGroupId = e.ClusterGroupId;
            this.ClusterNumber = e.ClusterNumber;
            this.PanelNumber = e.PanelNumber;
            this.BoardNumber = e.BoardNumber;
            this.SectionNumber = e.SectionNumber;
            this.ModuleNumber = e.ModuleNumber;
            this.NodeNumber = e.NodeNumber;
            this.IsNodeActive = e.IsNodeActive;
            this.ClusterTypeUid = e.ClusterTypeUid;
            this.ClusterTypeCode = e.ClusterTypeCode;
            this.GalaxyPanelModelUid = e.GalaxyPanelModelUid;
            this.GalaxyPanelTypeCode = e.GalaxyPanelTypeCode;
            this.InterfaceBoardTypeUid = e.InterfaceBoardTypeUid;
            this.InterfaceBoardTypeCode = e.InterfaceBoardTypeCode;
            this.InterfaceBoardModel = e.InterfaceBoardModel;
            this.InterfaceBoardSectionModeUid = e.InterfaceBoardSectionModeUid;
            this.InterfaceBoardSectionModeCode = e.InterfaceBoardSectionModeCode;
            this.GalaxyHardwareModuleTypeUid = e.GalaxyHardwareModuleTypeUid;
            this.ModuleTypeCode = e.ModuleTypeCode;
            this.TotalRowCount = e.TotalRowCount;
            this.IsBoundToHardware = e.IsBoundToHardware;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Makes a deep copy of this InputDevice. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The InputDevice to process. </param>
        ///
        /// <returns>   A copy of this InputDevice. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public InputDevice Clone(InputDevice e)
        {
            return new InputDevice(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tests if this InputDevice is considered equal to another. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="other">    The other. </param>
        ///
        /// <returns>   True if the objects are considered equal, false if they are not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool Equals(InputDevice other)
        {
            return base.Equals(other);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if 'other' is primary key equal. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="other">    The other. </param>
        ///
        /// <returns>   True if primary key equal, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool IsPrimaryKeyEqual(InputDevice other)
        {
            if (other == null)
                return false;

            if (other.InputDeviceUid != this.InputDeviceUid)
                return false;
            return true;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Serves as the default hash function. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   A hash code for the current object. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Returns a string that represents the current object. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   A string that represents the current object. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public override string ToString()
        {
            return base.ToString();
        }
        /// <summary>   The command menu. </summary>
        private ObservableCollection<MenuItem> _commandMenu;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the command menu. </summary>
        ///
        /// <value> The command menu. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ObservableCollection<MenuItem> CommandMenu
        {
            get { return _commandMenu; }
            set
            {
                if (_commandMenu != value)
                {
                    _commandMenu = value;
                    OnPropertyChanged(() => CommandMenu, false);
                }
            }
        }

        /// <summary>   The commands. </summary>
        private ICollection<InputCommand> _commands;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the commands. </summary>
        ///
        /// <value> The commands. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        [DataMember]

        public ICollection<InputCommand> Commands
        {
            get { return _commands; }
            set
            {
                if (_commands != value)
                {
                    _commands = value;
                    OnPropertyChanged(() => Commands, false);
                }
            }
        }

        private InputDeviceStatusReply _lastStatusReply;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the last status reply. </summary>
        /// <remarks>   This is a client-side only property provided as a convenience. The client application can populate this property as status updates are received from the server</remarks>
        /// <value> The last status reply. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public InputDeviceStatusReply LastStatusReply
        {
            get { return _lastStatusReply; }
            set
            {
                if (_lastStatusReply != value)
                {
                    _lastStatusReply = value;
                    OnPropertyChanged(() => LastStatusReply, false);
                }
            }
        }

        public InputDeviceEventProperty MainEventProperties => InputDeviceEventProperties.FirstOrDefault();


        public string HardwareAddressString
        {
            get
            {
                return $"Cluster Group #:{ClusterGroupId}, Cluster #:{ClusterNumber}, Panel #:{PanelNumber}, Board #:{BoardNumber}, Section #:{SectionNumber}, Module #: {ModuleNumber}, Input #:{NodeNumber}";
            }
        }


        private int _TotalRowCount;

        [DataMember]
        public int TotalRowCount
        {
            get => _TotalRowCount;
            set
            {
                if (_TotalRowCount != value)
                {
                    _TotalRowCount = value;
                    OnPropertyChanged(() => TotalRowCount, false);
                }
            }
        }

    }
}
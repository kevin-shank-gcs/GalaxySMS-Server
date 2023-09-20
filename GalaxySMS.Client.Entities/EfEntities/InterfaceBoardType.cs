//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GalaxySMS.Client.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using GCS.Core.Common.Core;
    using FluentValidation;
    using System.Collections.ObjectModel;

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   An interface board type. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public partial class InterfaceBoardType : DbObjectBase, IHasBinaryResource
    {

        /// <summary>   The interface board type UID. </summary>
        private System.Guid _interfaceBoardTypeUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the interface board type UID. </summary>
        ///
        /// <value> The interface board type UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public System.Guid InterfaceBoardTypeUid
        {
            get { return _interfaceBoardTypeUid; }
            set
            {
                if (_interfaceBoardTypeUid != value)
                {
                    _interfaceBoardTypeUid = value;
                    OnPropertyChanged(() => InterfaceBoardTypeUid);
                }
            }
        }

        /// <summary>   The type code. </summary>
        private short _typeCode;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the type code. </summary>
        ///
        /// <value> The type code. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public short TypeCode
        {
            get { return _typeCode; }
            set
            {
                if (_typeCode != value)
                {
                    _typeCode = value;
                    OnPropertyChanged(() => TypeCode);
                }
            }
        }

        /// <summary>   The display. </summary>
        private string _display;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the display. </summary>
        ///
        /// <value> The display. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string Display
        {
            get { return _display; }
            set
            {
                if (_display != value)
                {
                    _display = value;
                    OnPropertyChanged(() => Display);
                }
            }
        }

        /// <summary>   The description. </summary>
        private string _description;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the description. </summary>
        ///
        /// <value> The description. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged(() => Description);
                }
            }
        }

        /// <summary>   The display resource key. </summary>
        private Guid? _displayResourceKey;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the display resource key. </summary>
        ///
        /// <value> The display resource key. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid? DisplayResourceKey
        {
            get { return _displayResourceKey; }
            set
            {
                if (_displayResourceKey != value)
                {
                    _displayResourceKey = value;
                    OnPropertyChanged(() => DisplayResourceKey);
                }
            }
        }

        /// <summary>   The description resource key. </summary>
        private Guid? _descriptionResourceKey;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the description resource key. </summary>
        ///
        /// <value> The description resource key. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid? DescriptionResourceKey
        {
            get { return _descriptionResourceKey; }
            set
            {
                if (_descriptionResourceKey != value)
                {
                    _descriptionResourceKey = value;
                    OnPropertyChanged(() => DescriptionResourceKey);
                }
            }
        }

        /// <summary>   The model. </summary>
        private string _model;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the model. </summary>
        ///
        /// <value> The model. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string Model
        {
            get { return _model; }
            set
            {
                if (_model != value)
                {
                    _model = value;
                    OnPropertyChanged(() => Model);
                }
            }
        }

        /// <summary>   Number of sections. </summary>
        private short _numberOfSections;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the number of sections. </summary>
        ///
        /// <value> The total number of sections. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public short NumberOfSections
        {
            get { return _numberOfSections; }
            set
            {
                if (_numberOfSections != value)
                {
                    _numberOfSections = value;
                    OnPropertyChanged(() => NumberOfSections);
                }
            }
        }

        /// <summary>   The binary resource UID. </summary>
        private Nullable<System.Guid> _binaryResourceUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the binary resource UID. </summary>
        ///
        /// <value> The binary resource UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Nullable<System.Guid> BinaryResourceUid
        {
            get { return _binaryResourceUid; }
            set
            {
                if (_binaryResourceUid != value)
                {
                    _binaryResourceUid = value;
                    OnPropertyChanged(() => BinaryResourceUid);
                }
            }
        }


        /// <summary>   The gcs binary resource. </summary>
        private gcsBinaryResource _gcsBinaryResource;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the gcs binary resource. </summary>
        ///
        /// <value> The gcs binary resource. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public virtual gcsBinaryResource gcsBinaryResource
        {
            get { return _gcsBinaryResource; }
            set
            {
                if (_gcsBinaryResource != value)
                {
                    _gcsBinaryResource = value;
                    OnPropertyChanged(() => gcsBinaryResource);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name. </summary>
        ///
        /// <value> The name. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string Name
        {
            get { return Display; }
            set
            {
                if (Name != value)
                {
                    Display = value;
                    OnPropertyChanged(() => Name);
                }
            }
        }

        /// <summary>   Name of the insert. </summary>
        private string _insertName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the insert. </summary>
        ///
        /// <value> The name of the insert. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string InsertName
        {
            get { return _insertName; }
            set
            {
                if (_insertName != value)
                {
                    _insertName = value;
                    OnPropertyChanged(() => InsertName);
                }
            }
        }

        /// <summary>   The insert date. </summary>
        private System.DateTimeOffset _insertDate;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the insert date. </summary>
        ///
        /// <value> The insert date. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public System.DateTimeOffset InsertDate
        {
            get { return _insertDate; }
            set
            {
                if (_insertDate != value)
                {
                    _insertDate = value;
                    OnPropertyChanged(() => InsertDate);
                }
            }
        }

        /// <summary>   Name of the update. </summary>
        private string _updateName;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the update. </summary>
        ///
        /// <value> The name of the update. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public string UpdateName
        {
            get { return _updateName; }
            set
            {
                if (_updateName != value)
                {
                    _updateName = value;
                    OnPropertyChanged(() => UpdateName);
                }
            }
        }

        /// <summary>   The update. </summary>
        private Nullable<System.DateTimeOffset> _updateDate;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the update. </summary>
        ///
        /// <value> The update date. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Nullable<System.DateTimeOffset> UpdateDate
        {
            get { return _updateDate; }
            set
            {
                if (_updateDate != value)
                {
                    _updateDate = value;
                    OnPropertyChanged(() => UpdateDate);
                }
            }
        }

        /// <summary>   The concurrency value. </summary>
        private Nullable<short> _concurrencyValue;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the concurrency value. </summary>
        ///
        /// <value> The concurrency value. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Nullable<short> ConcurrencyValue
        {
            get { return _concurrencyValue; }
            set
            {
                if (_concurrencyValue != value)
                {
                    _concurrencyValue = value;
                    OnPropertyChanged(() => ConcurrencyValue);
                }
            }
        }

        /// <summary>   The galaxy panel model uids. </summary>
        private ObservableCollection<Guid> _GalaxyPanelModelUids;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the galaxy panel model uids. </summary>
        ///
        /// <value> The galaxy panel model uids. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public ObservableCollection<Guid> GalaxyPanelModelUids
        {
            get { return _GalaxyPanelModelUids; }
            set
            {
                if (_GalaxyPanelModelUids != value)
                {
                    _GalaxyPanelModelUids = value;
                    OnPropertyChanged(() => GalaxyPanelModelUids, false);
                }
            }
        }

    }

}

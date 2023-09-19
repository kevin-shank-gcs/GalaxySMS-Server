using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GCS.Core.Common.Core;
using GCS.Core.Common.Contracts;
using FluentValidation;
using System.Collections.ObjectModel;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Client.Entities
{
    public partial class GalaxyOutputDeviceInputSource
    {
        public GalaxyOutputDeviceInputSource() : base()
        {
            Initialize();
        }

        public GalaxyOutputDeviceInputSource(GalaxyOutputDeviceInputSource e) : base(e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            base.Initialize();
            this.GalaxyOutputDeviceInputSourceAssignments = new ObservableCollection<GalaxyOutputDeviceInputSourceAssignment>();
            this.GalaxyOutputDeviceInputSourceInputOutputGroups = new ObservableCollection<GalaxyOutputDeviceInputSourceInputOutputGroup>();
        }

        public void Initialize(GalaxyOutputDeviceInputSource e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.GalaxyOutputDeviceInputSourceUid = e.GalaxyOutputDeviceInputSourceUid;
            this.OutputDeviceUid = e.OutputDeviceUid;
            this.GalaxyOutputInputSourceTriggerConditionUid = e.GalaxyOutputInputSourceTriggerConditionUid;
            this.GalaxyOutputInputSourceModeUid = e.GalaxyOutputInputSourceModeUid;
            this.InputOutputGroupUid = e.InputOutputGroupUid;
            this.SourceNumber = e.SourceNumber;
            this.InputOutputGroupMode = e.InputOutputGroupMode;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.GalaxyOutputDeviceInputSourceAssignments = e.GalaxyOutputDeviceInputSourceAssignments.ToObservableCollection();
            this.GalaxyOutputDeviceInputSourceInputOutputGroups = e.GalaxyOutputDeviceInputSourceInputOutputGroups.ToObservableCollection();
        }

        public GalaxyOutputDeviceInputSource Clone(GalaxyOutputDeviceInputSource e)
        {
            return new GalaxyOutputDeviceInputSource(e);
        }

        public bool Equals(GalaxyOutputDeviceInputSource other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(GalaxyOutputDeviceInputSource other)
        {
            if (other == null)
                return false;

            if (other.GalaxyOutputDeviceInputSourceUid != this.GalaxyOutputDeviceInputSourceUid)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        private string _headerTitle;

        public string HeaderTitle
        {
            get { return _headerTitle; }
            set
            {
                if (_headerTitle != value)
                {
                    _headerTitle = value;
                    OnPropertyChanged(() => HeaderTitle, false);
                }
            }
        }

        private string _headerToolTip;

        public string HeaderToolTip
        {
            get { return _headerToolTip; }
            set
            {
                if (_headerToolTip != value)
                {
                    _headerToolTip = value;
                    OnPropertyChanged(() => HeaderToolTip, false);
                }
            }
        }

        private ObservableCollection<InputOutputGroupAssignmentSource> _inputOutputGroupAssignmentSourcesNotUsed;
        private ObservableCollection<InputOutputGroupAssignmentSource> _inputOutputGroupAssignmentSourcesUsed;
        private ObservableCollection<InputOutputGroup> _inputOutputGroupInputOutputGroupsNotUsed;
        private ObservableCollection<InputOutputGroup> _inputOutputGroupInputOutputGroupsUsed;

        public ObservableCollection<InputOutputGroupAssignmentSource> InputOutputGroupAssignmentSourcesNotUsed
        {
            get { return _inputOutputGroupAssignmentSourcesNotUsed; }
            set
            {
                if (_inputOutputGroupAssignmentSourcesNotUsed != value)
                {
                    _inputOutputGroupAssignmentSourcesNotUsed = value;
                    OnPropertyChanged(() => InputOutputGroupAssignmentSourcesNotUsed, true);
                }
            }
        }
        
        public ObservableCollection<InputOutputGroupAssignmentSource> InputOutputGroupAssignmentSourcesUsed
        {
            get { return _inputOutputGroupAssignmentSourcesUsed; }
            set
            {
                if (_inputOutputGroupAssignmentSourcesUsed != value)
                {
                    _inputOutputGroupAssignmentSourcesUsed = value;
                    OnPropertyChanged(() => InputOutputGroupAssignmentSourcesUsed, true);
                }
            }
        }

        public ObservableCollection<InputOutputGroup> InputOutputGroupInputOutputGroupsNotUsed
        {
            get { return _inputOutputGroupInputOutputGroupsNotUsed; }
            set
            {
                if (_inputOutputGroupInputOutputGroupsNotUsed != value)
                {
                    _inputOutputGroupInputOutputGroupsNotUsed = value;
                    OnPropertyChanged(() => InputOutputGroupInputOutputGroupsNotUsed, true);
                }
            }
        }
        
        public ObservableCollection<InputOutputGroup> InputOutputGroupInputOutputGroupsUsed
        {
            get { return _inputOutputGroupInputOutputGroupsUsed; }
            set
            {
                if (_inputOutputGroupInputOutputGroupsUsed != value)
                {
                    _inputOutputGroupInputOutputGroupsUsed = value;
                    OnPropertyChanged(() => InputOutputGroupInputOutputGroupsUsed, true);
                }
            }
        }

        private ObservableCollection<InputOutputGroupAssignmentSource> _selectedIncludedAssignmentSources;
        private ObservableCollection<InputOutputGroupAssignmentSource> _selectedNotIncludedAssignmentSources;
        private ObservableCollection<InputOutputGroup> _selectedIncludedInputOutputGroups;
        private ObservableCollection<InputOutputGroup> _selectedNotIncludedInputOutputGroups;
 
        public ObservableCollection<InputOutputGroupAssignmentSource> SelectedIncludedAssignmentSources
        {
            get
            { return _selectedIncludedAssignmentSources; }
            set
            {
                if (_selectedIncludedAssignmentSources != value)
                {
                    _selectedIncludedAssignmentSources = value;
                    OnPropertyChanged(() => SelectedIncludedAssignmentSources, false);
                }
            }
        }
        
        public ObservableCollection<InputOutputGroupAssignmentSource> SelectedNotIncludedAssignmentSources
        {
            get
            { return _selectedNotIncludedAssignmentSources; }
            set
            {
                if (_selectedNotIncludedAssignmentSources != value)
                {
                    _selectedNotIncludedAssignmentSources = value;
                    OnPropertyChanged(() => SelectedNotIncludedAssignmentSources, false);
                }
            }
        }
 
        public ObservableCollection<InputOutputGroup> SelectedIncludedInputOutputGroups
        {
            get
            { return _selectedIncludedInputOutputGroups; }
            set
            {
                if (_selectedIncludedInputOutputGroups != value)
                {
                    _selectedIncludedInputOutputGroups = value;
                    OnPropertyChanged(() => SelectedIncludedInputOutputGroups, false);
                }
            }
        }
        
        public ObservableCollection<InputOutputGroup> SelectedNotIncludedInputOutputGroups
        {
            get
            { return _selectedNotIncludedInputOutputGroups; }
            set
            {
                if (_selectedNotIncludedInputOutputGroups != value)
                {
                    _selectedNotIncludedInputOutputGroups = value;
                    OnPropertyChanged(() => SelectedNotIncludedInputOutputGroups, false);
                }
            }
        }
    }
}

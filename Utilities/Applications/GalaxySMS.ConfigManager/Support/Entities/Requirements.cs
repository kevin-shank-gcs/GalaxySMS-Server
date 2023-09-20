using GalaxySMS.ConfigManager.Properties;
using GCS.Core.Common.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.ConfigManager.Support.Entities
{
    public enum RequirementType
    {
        NetFramework_4_8,
        //            NetCore_3_1,    // published API includes .NET core files locally, so we don't need to install shared version
        //GCSAdminsGroup,
        GCSServicesGroup,
        //GCSClientsGroup,
        GCSServiceAccount,
        //GCSClientAccount,
        SQLServerInstance,
        //GalaxySMSDb,    // can't determine this until connect to specific instance
        //GalaxySMSAuditActivityDb,// can't determine this until connect to specific instance
        MSMQ,
        Redis,
        IIS
    }

    public enum InstallStatus
    {
        Unknown,
        NotInstalled,
        PartiallyInstalled,
        Installed
    }


    public class Requirement : ObjectBase
    {
        private string _title;
        private string _description;
        private bool _isComplete;
        private int _orderNumber;
        private string _statusMessage;
        private RequirementType _type;
        private List<uint> _acceptableValues;
        private bool _partiallyInstalled;
        private InstallStatus _status;

        public Requirement()
        {
            AcceptableValues = new List<uint>();
        }

        public string Title
        {
            get { return _title; }
            set
            {
                if (_title != value)
                {
                    _title = value;
                    OnPropertyChanged(() => Title, true);
                }
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged(() => Description, true);
                }
            }
        }


        public InstallStatus Status
        {
            get { return _status; }
            set
            {
                if (_status != value)
                {
                    _status = value;
                    OnPropertyChanged(() => Status, true);
                }
            }
        }

        public int OrderNumber
        {
            get { return _orderNumber; }
            set
            {
                if (_orderNumber != value)
                {
                    _orderNumber = value;
                    OnPropertyChanged(() => OrderNumber, true);
                }
            }
        }

        public List<uint> AcceptableValues
        {
            get { return _acceptableValues; }
            set
            {
                if (_acceptableValues != value)
                {
                    _acceptableValues = value;
                    OnPropertyChanged(() => AcceptableValues, true);
                }
            }
        }
        public uint ValueDetected { get; set; }

        public string StatusMessage
        {
            get
            {
                switch (Status)
                {
                    case InstallStatus.Unknown:
                        return Resources.InstallStatus_Unknown;

                    case InstallStatus.NotInstalled:
                        return Resources.InstallStatus_NotInstalled;

                    case InstallStatus.PartiallyInstalled:
                        return Resources.InstallStatus_PartiallyInstalled;

                    case InstallStatus.Installed:
                        return Resources.InstallStatus_Installed;

                    default:
                        return string.Empty;
                }
            }

        }

        public RequirementType Type
        {
            get { return _type; }
            set
            {
                if (_type != value)
                {
                    _type = value;
                    OnPropertyChanged(() => Type, true);
                }
            }
        }


    }

    public class Requirements : ObjectBase
    {
        private ObservableCollection<Requirement> _requirements;

        public Requirements()
        {
            Items = new ObservableCollection<Requirement>();
        }

        public ObservableCollection<Requirement> Items
        {
            get { return _requirements; }
            set
            {
                if (_requirements != value)
                {
                    _requirements = value;
                    OnPropertyChanged(() => Items, true);
                }
            }
        }


        public bool AllCompleted
        {
            get { return !Items.Any(o => o.Status != InstallStatus.Installed); }
            set
            {
                OnPropertyChanged(() => AllCompleted, true);
            }
        }


    }
}

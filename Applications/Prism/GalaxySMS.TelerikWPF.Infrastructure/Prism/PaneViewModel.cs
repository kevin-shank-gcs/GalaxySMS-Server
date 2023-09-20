using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using GCS.Core.Common.UI.Core;
using Telerik.Windows.Controls.Docking;

namespace GalaxySMS.TelerikWPF.Infrastructure.Prism
{
    //[XmlRoot("PaneViewModel")]
    //public class PaneViewModel : ViewModelBase
    //{
    //    private string header;
    //    private DockState initialPosition;
    //    private bool isActive;
    //    private bool isHidden;
    //    private bool isDocument;

    //    public PaneViewModel()
    //    {
    //    }

    //    public PaneViewModel(Type contentType)
    //    {
    //        this.ContentType = contentType;
    //    }

    //    [XmlAttribute]
    //    public string Header
    //    {
    //        get
    //        {
    //            return this.header;
    //        }
    //        set
    //        {
    //            if (this.header != value)
    //            {
    //                this.header = value;
    //                this.OnPropertyChanged("Header");
    //            }
    //        }
    //    }

    //    [XmlAttribute]
    //    public DockState InitialPosition
    //    {
    //        get
    //        {
    //            return this.initialPosition;
    //        }
    //        set
    //        {
    //            if (this.initialPosition != value)
    //            {
    //                this.initialPosition = value;
    //                this.OnPropertyChanged("InitialPosition");
    //            }
    //        }
    //    }

    //    [XmlAttribute]
    //    public bool IsActive
    //    {
    //        get
    //        {
    //            return this.isActive;
    //        }
    //        set
    //        {
    //            if (this.isActive != value)
    //            {
    //                this.isActive = value;
    //                this.OnPropertyChanged("IsActive");
    //            }
    //        }
    //    }

    //    [XmlAttribute]
    //    public bool IsHidden
    //    {
    //        get
    //        {
    //            return this.isHidden;
    //        }
    //        set
    //        {
    //            if (this.isHidden != value)
    //            {
    //                this.isHidden = value;
    //                this.OnPropertyChanged("IsHidden");
    //            }
    //        }
    //    }

    //    [XmlAttribute]
    //    public bool IsDocument
    //    {
    //        get
    //        {
    //            return this.isDocument;
    //        }
    //        set
    //        {
    //            if (this.isDocument != value)
    //            {
    //                this.isDocument = value;
    //                this.OnPropertyChanged("IsDocument");
    //            }
    //        }
    //    }

    //    [XmlIgnore]
    //    public Type ContentType
    //    {
    //        get;
    //        private set;
    //    }

    //    [XmlAttribute]
    //    public string TypeName
    //    {
    //        get
    //        {
    //            return this.ContentType == null ? string.Empty : this.ContentType.AssemblyQualifiedName;
    //        }
    //        set
    //        {
    //            this.ContentType = value == null ? null : Type.GetType(value);
    //        }
    //    }
    //}

    [Export(typeof(PaneViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    [XmlRoot("PaneViewModel")]
    public class PaneViewModel : ViewModelBase, IPaneViewModel
    {
        private string _prismRegionName;
        private string _header;
        private DockState _dockPosition;
        private bool _isActive;
        private bool _isHidden;
        private bool _isDocument;

        [ImportingConstructor]
        public PaneViewModel()
        {

        }
        public PaneViewModel(Type contentType)
        {
            this.ContentType = contentType;
        }

        [XmlAttribute]
        public string PrismRegionName
        {
            get { return _prismRegionName; }
            set
            {
                if (_prismRegionName != value)
                {
                    _prismRegionName = value;
                    OnPropertyChanged(() => PrismRegionName, false);
                }
            }
        }

        [XmlAttribute]
        public string Header
        {
            get { return _header; }

            set
            {
                if (_header != value)
                {
                    _header = value;
                    OnPropertyChanged(() => Header, false);
                }
            }
        }

        [XmlAttribute]
        public DockState DockPosition
        {
            get { return _dockPosition; }

            set
            {
                if (_dockPosition != value)
                {
                    _dockPosition = value;
                    OnPropertyChanged(() => DockPosition, false);
                }
            }
        }

        [XmlAttribute]
        public bool IsActive
        {
            get { return _isActive; }

            set
            {
                if (_isActive != value)
                {
                    _isActive = value;
                    OnPropertyChanged(() => IsActive, false);
                }
            }
        }

        [XmlAttribute]
        public bool IsHidden
        {
            get { return _isHidden; }

            set
            {
                if (_isHidden != value)
                {
                    _isHidden = value;
                    OnPropertyChanged(() => IsHidden, false);
                }
            }
        }

        [XmlAttribute]
        public bool IsDocument
        {
            get { return _isDocument; }

            set
            {
                if (_isDocument != value)
                {
                    _isDocument = value;
                    OnPropertyChanged(() => IsDocument, false);
                }
            }
        }

        [XmlIgnore]
        public Type ContentType
        {
            get;
            private set;
        }

        [XmlAttribute]
        public string TypeName
        {
            get
            {
                return this.ContentType == null ? string.Empty : this.ContentType.AssemblyQualifiedName;
            }
            set
            {
                this.ContentType = value == null ? null : Type.GetType(value);
            }
        }

        [XmlIgnore]
        public object Content { get; set; }
    }

}

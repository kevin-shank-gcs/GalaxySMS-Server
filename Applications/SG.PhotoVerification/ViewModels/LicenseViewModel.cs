﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using SG.PhotoVerification.Properties;
using GCS.Core.Common.UI.Core;
using GCS.Framework.Utilities;
using Portable.Licensing;

namespace SG.PhotoVerification.ViewModels
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class LicenseViewModel : ViewModelBase
    {
        #region Constructor

        public LicenseViewModel()
        {
            Attributes = Globals.Instance.MyAssemblyAtrributes;
            HeaderBackground = new LinearGradientBrush(Colors.SteelBlue, Colors.DarkGray, .5);
            MiddleBackground = new LinearGradientBrush(Colors.SkyBlue, Colors.WhiteSmoke, .5);
            GradientStartColor = Colors.Transparent;
            GradientMiddleColor = Colors.Transparent;
            GradientStopColor = Colors.Transparent;
            AboutUri = new Uri("http://www.galaxysys.com");
            AboutUriDescription = Properties.Resources.AboutView_AboutUriDescription;
        }
        #endregion

        #region Public properties


        private Nullable<bool> _dialogResult;

        public Nullable<bool> DialogResult
        {
            get { return _dialogResult; }
            internal set
            {
                _dialogResult = value;
                OnPropertyChanged(() => DialogResult, false);
            }
        }

        public Color GradientStartColor { get; set; }
        public Color GradientMiddleColor { get; set; }
        public Color GradientStopColor { get; set; }

        private Brush _headerBackground;

        public Brush HeaderBackground
        {
            get { return _headerBackground; }
            set
            {
                if (_headerBackground != value)
                {
                    _headerBackground = value;
                    OnPropertyChanged(() => HeaderBackground, false);
                }
            }
        }


        private Brush _middleBackground;

        public Brush MiddleBackground
        {
            get { return _middleBackground; }
            set
            {
                if (_middleBackground != value)
                {
                    _middleBackground = value;
                    OnPropertyChanged(() => MiddleBackground, false);
                }
            }
        }

        private Brush _footerBackground;

        public Brush FooterBackground
        {
            get { return _footerBackground; }
            set
            {
                if (_footerBackground != value)
                {
                    _footerBackground = value;
                    OnPropertyChanged(() => FooterBackground, false);
                }
            }
        }


        private string _headerText;

        public string HeaderText
        {
            get { return _headerText; }
            set
            {
                if (_headerText != value)
                {
                    _headerText = value;
                    OnPropertyChanged(() => HeaderText, false);
                }
            }
        }

        private string _footerText;

        public string FooterText
        {
            get { return _footerText; }
            set
            {
                if (_footerText != value)
                {
                    _footerText = value;
                    OnPropertyChanged(() => FooterText, false);
                }
            }
        }

        public string CopyrightNotice
        {
            get { return Attributes.Copyright; }
        }

        public string ApplicationName
        {
            get { return Attributes.Title; }
        }

        private AssemblyAttributes _attributes;

        public Guid ApplicationGuid
        {
            get { return Attributes.Guid; }
        }

        public AssemblyAttributes Attributes
        {
            get { return _attributes; }
            internal set
            {
                _attributes = value;
                OnPropertyChanged(() => Attributes, false);
            }
        }

        private Uri _aboutUri;
        private string _aboutUriDescription;

        public Uri AboutUri
        {
            get { return _aboutUri; }
            internal set
            {
                _aboutUri = value;
                OnPropertyChanged(() => AboutUri, false);
            }
        }

        public string AboutUriDescription
        {
            get { return _aboutUriDescription; }
            set
            {
                _aboutUriDescription = value; OnPropertyChanged(() => AboutUriDescription, false);
            }
        }

        public Globals Globals
        {
            get { return Globals.Instance; }
        }

        public License MyLicense
        {
            get { return Globals.Instance.MyLicense; }
        }

        public IDictionary<string, string> ProductFeatures
        {
            get { return MyLicense.ProductFeatures.GetAll(); }
        }
        public override string ViewTitle
        {
            get
            {
                return string.Format(Resources.AboutView_Title, Attributes.Title);
            }
        }

        #endregion Public properties
    }
}

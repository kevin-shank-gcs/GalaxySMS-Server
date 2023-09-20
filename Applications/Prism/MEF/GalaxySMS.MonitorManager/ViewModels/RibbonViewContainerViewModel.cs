using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.TelerikWPF.Infrastructure.Ribbon.ViewModels;
using GCS.Core.Common.UI.Core;
using Telerik.Windows.Controls.RibbonView;

namespace GalaxySMS.MonitorManager.ViewModels
{
    [Export(typeof(RibbonViewContainerViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]

    public class RibbonViewContainerViewModel : ViewModelBase
    {
        private RibbonTabViewModel selectedTab;
        private DelegateCommand<object> removeTab;
        private DelegateCommand<object> addButton;
        private DelegateCommand<object> addGroup;
        private DelegateCommand<object> addTab;
        private ObservableCollection<ButtonViewModel> applicationMenuItems;
        private ObservableCollection<ButtonViewModel> quickAccessItems;
        private ObservableCollection<RibbonTabViewModel> tabs;

        [ImportingConstructor]
        public RibbonViewContainerViewModel()
        {
            GenerateTabs();

            this.SelectedTab = this.Tabs[0];
        }

        private void GenerateTabs()
        {
            tabs = new ObservableCollection<RibbonTabViewModel>();

            var homeTab = new RibbonTabViewModel();
            homeTab.Text = "Home";
            var viewTab = new RibbonTabViewModel();
            viewTab.Text = "View";
            var textTab = new RibbonTabViewModel();
            textTab.Text = "Text";

            homeTab.Groups.Add(GetClipboardGroup());
            homeTab.Groups.Add(GetImageGroup());
            homeTab.Groups.Add(GetToolsGroup());
            homeTab.Groups.Add(GetBrushesGroup());

            viewTab.Groups.Add(GetGroup("Zoom"));
            viewTab.Groups.Add(GetGroup("Show"));
            viewTab.Groups.Add(GetGroup("Display"));

            textTab.Groups.Add(GetGroup("Clipboard"));
            textTab.Groups.Add(GetGroup("Font"));
            textTab.Groups.Add(GetGroup("Background"));
            textTab.Groups.Add(GetGroup("colors"));

            Tabs.Add(homeTab);
            Tabs.Add(viewTab);
            Tabs.Add(textTab);

            quickAccessItems = new ObservableCollection<ButtonViewModel>();
            quickAccessItems.Add(GetButton("save", "Save", false));
            quickAccessItems.Add(GetButton("undo", "Undo", false));
            quickAccessItems.Add(GetButton("print", "Print", false));

            applicationMenuItems = new ObservableCollection<ButtonViewModel>();
            applicationMenuItems.Add(GetButton("save", "Save", true));
            applicationMenuItems.Add(GetButton("undo", "Undo", true));
            applicationMenuItems.Add(GetButton("print", "Print", true));

            addTab = new GCS.Core.Common.UI.Core.DelegateCommand<object>(AddTabHandler);
            addGroup = new DelegateCommand<object>(AddGroupHandler);
            addButton = new DelegateCommand<object>(AddButtonHandler);
            removeTab = new DelegateCommand<object>(RemoveTabHandler);
        }

        private GroupViewModel GetGroup(string name)
        {
            GroupViewModel group = new GroupViewModel();
            group.Text = name;
            return group;
        }

        private void RemoveTabHandler(object o)
        {
            if (this.SelectedTab != null)
            {
                this.Tabs.Remove(this.SelectedTab);
                if (this.Tabs.Count > 0)
                {
                    this.SelectedTab = this.Tabs[0];
                }
            }
        }

        private void AddButtonHandler(object o)
        {
            if (this.SelectedTab != null && this.SelectedTab.Groups.Count > 0)
            {
                int group = (new Random()).Next(SelectedTab.Groups.Count);
                ButtonViewModel b = new ButtonViewModel(); b.Text = "New button"; b.Size = ButtonSize.Medium;
                SelectedTab.Groups[group].Buttons.Add(b);
            }
        }

        private void AddGroupHandler(object o)
        {
            if (this.SelectedTab != null)
            {
                GroupViewModel group = new GroupViewModel();
                group.Text = "New group";
                this.SelectedTab.Groups.Add(group);
            }
        }

        private void AddTabHandler(object o)
        {
            var tab = new RibbonTabViewModel();
            tab.Text = "New tab";
            this.Tabs.Add(tab);
        }

        public ObservableCollection<RibbonTabViewModel> Tabs
        {
            get
            {
                return tabs;
            }
        }

        public ObservableCollection<ButtonViewModel> QuickAccessItems
        {
            get
            {
                return quickAccessItems;
            }
        }

        public ObservableCollection<ButtonViewModel> ApplicationMenuItems
        {
            get
            {
                return applicationMenuItems;
            }
        }

        public RibbonTabViewModel SelectedTab
        {
            get
            {
                return this.selectedTab;
            }
            set
            {
                if (this.selectedTab != value)
                {
                    this.selectedTab = value;
                    OnPropertyChanged("SelectedTab");
                }
            }
        }

        public string Title
        {
            get { return "Untitled"; }
        }


        public DelegateCommand<object> AddTab
        {
            get
            {
                return addTab;
            }
        }

        public DelegateCommand<object> AddGroup
        {
            get
            {
                return addGroup;
            }
        }

        public DelegateCommand<object> AddButton
        {
            get
            {
                return addButton;
            }
        }

        public DelegateCommand<object> RemoveTab
        {
            get
            {
                return removeTab;
            }
        }

        private GroupViewModel GetClipboardGroup()
        {
            GroupViewModel clipboard = new GroupViewModel();
            clipboard.Text = "Clipboard";
            SplitButtonViewModel split = new SplitButtonViewModel();
            split.Text = "Paste";
            split.Size = ButtonSize.Large;
            split.LargeImage = GetPath("MVVM/paste.png");
            clipboard.Buttons.Add(split);

            ButtonGroupViewModel buttonsGroup = new ButtonGroupViewModel();
            buttonsGroup.Buttons.Add(GetButton("cut", "Cut"));
            buttonsGroup.Buttons.Add(GetButton("copy", "Copy"));

            clipboard.Buttons.Add(buttonsGroup);
            return clipboard;
        }

        private GroupViewModel GetImageGroup()
        {
            GroupViewModel image = new GroupViewModel();
            image.Text = "Image";
            SplitButtonViewModel split = new SplitButtonViewModel();
            split.Text = "Select";
            split.Size = ButtonSize.Large;
            split.LargeImage = GetPath("MVVM/select.png");
            image.Buttons.Add(split);

            ButtonGroupViewModel buttonsGroup = new ButtonGroupViewModel();
            buttonsGroup.Buttons.Add(GetSmallButton("crop", "Crop"));
            buttonsGroup.Buttons.Add(GetSmallButton("resize", "Resize"));
            buttonsGroup.Buttons.Add(GetSmallButton("rotate", "Rotate"));

            image.Buttons.Add(buttonsGroup);
            return image;
        }

        private GroupViewModel GetToolsGroup()
        {
            GroupViewModel image = new GroupViewModel();
            image.Text = "Tools";

            ButtonGroupViewModel buttonsGroup = new ButtonGroupViewModel();
            buttonsGroup.IsSmallGroup = true;
            buttonsGroup.Buttons.Add(GetSmallButton("pen"));
            buttonsGroup.Buttons.Add(GetSmallButton("paint-bucket"));
            buttonsGroup.Buttons.Add(GetSmallButton("text"));
            buttonsGroup.Buttons.Add(GetSmallButton("eraser"));
            buttonsGroup.Buttons.Add(GetSmallButton("eyedropper"));
            buttonsGroup.Buttons.Add(GetSmallButton("zoom"));

            image.Buttons.Add(buttonsGroup);
            return image;
        }

        private GroupViewModel GetBrushesGroup()
        {
            GroupViewModel brushes = new GroupViewModel();
            brushes.Text = "Brushes";

            SplitButtonViewModel split = new SplitButtonViewModel();
            split.Size = ButtonSize.Large;
            split.Text = "Brushes";
            split.LargeImage = GetPath("MVVM/brush1.png");
            brushes.Buttons.Add(split);

            return brushes;
        }

        private ButtonViewModel GetButton(string image, string text, bool large)
        {
            ButtonViewModel b = new ButtonViewModel();
            b.SmallImage = GetPath(string.Format("MVVM/{0}.png", image));
            if (large)
                b.LargeImage = GetPath(string.Format("MVVM/{0}.png", image));
            b.Text = text;

            return b;
        }

        private ButtonViewModel GetButton(string image, string text)
        {
            return GetButton(image, text, true);
        }

        private ButtonViewModel GetSmallButton(string image)
        {
            ButtonViewModel b = new ButtonViewModel();
            b.SmallImage = GetPath(string.Format("MVVM/{0}.png", image));
            return b;
        }

        private ButtonViewModel GetSmallButton(string image, string text)
        {
            ButtonViewModel b = GetSmallButton(image);
            b.Text = text;
            return b;
        }

        #region Internal

        private const string format = "/RibbonView;component/Images/RibbonView/{0}";

        private string GetPath(string fileName)
        {
            string icon = string.Format(format, fileName);

            return icon;
        }

        #endregion Internal
    }
}

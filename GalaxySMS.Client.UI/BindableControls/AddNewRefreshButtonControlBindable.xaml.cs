using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GalaxySMS.Client.UI
{
    /// <summary>
    /// Interaction logic for AddNewRefreshButtonControlBindable.xaml
    /// </summary>
    public partial class AddNewRefreshButtonControlBindable : UserControl
    {
        #region AddNewCommand
        public static readonly DependencyProperty AddNewCommandProperty =
            DependencyProperty.Register(
                "AddNewCommand",
                typeof(ICommand),
                typeof(AddNewRefreshButtonControlBindable),
                new UIPropertyMetadata(null));
        public ICommand AddNewCommand
        {
            get { return (ICommand) GetValue(AddNewCommandProperty); }
            set { SetValue(AddNewCommandProperty, value); }
        }
        #endregion

        #region IsAddNewVisible
        public static readonly DependencyProperty IsAddNewVisibleProperty =
            DependencyProperty.Register(
                "IsAddNewVisible",
                typeof(bool),
                typeof(AddNewRefreshButtonControlBindable),
                new UIPropertyMetadata(null));
        public bool IsAddNewVisible
        {
            get { return (bool) GetValue(IsAddNewVisibleProperty); }
            set { SetValue(IsAddNewVisibleProperty, value); }
        }
        #endregion
        
        #region AddNewToolTip
        public static readonly DependencyProperty AddNewToolTipProperty =
            DependencyProperty.Register(
                "AddNewToolTip",
                typeof(object),
                typeof(AddNewRefreshButtonControlBindable),
                new UIPropertyMetadata(null));
        public object AddNewToolTip
        {
            get { return (object) GetValue(AddNewToolTipProperty); }
            set { SetValue(AddNewToolTipProperty, value); }
        }
        #endregion

        #region AddNewText
        public static readonly DependencyProperty AddNewTextProperty =
            DependencyProperty.Register(
                "AddNewText",
                typeof(string),
                typeof(AddNewRefreshButtonControlBindable),
                new UIPropertyMetadata(null));
        public string AddNewText
        {
            get { return (string) GetValue(AddNewTextProperty); }
            set { SetValue(AddNewTextProperty, value); }
        }
        #endregion

        #region AddNewImageSource
        public static readonly DependencyProperty AddNewImageSourceProperty =
            DependencyProperty.Register(
                "AddNewImageSource",
                typeof(ImageSource),
                typeof(AddNewRefreshButtonControlBindable),
                new UIPropertyMetadata(null));
        public ImageSource AddNewImageSource
        {
            get { return (ImageSource) GetValue(AddNewImageSourceProperty); }
            set { SetValue(AddNewImageSourceProperty, value); }
        }
        #endregion

        #region ImageHeight
        public static readonly DependencyProperty ImageHeightProperty =
            DependencyProperty.Register(
                "ImageHeight",
                typeof(double),
                typeof(AddNewRefreshButtonControlBindable),
                new UIPropertyMetadata(null));
        public double ImageHeight
        {
            get { return (double) GetValue(ImageHeightProperty); }
            set { SetValue(ImageHeightProperty, value); }
        }
        #endregion

        #region ImageWidth
        public static readonly DependencyProperty ImageWidthProperty =
            DependencyProperty.Register(
                "ImageWidth",
                typeof(double),
                typeof(AddNewRefreshButtonControlBindable),
                new UIPropertyMetadata(null));
        public double ImageWidth
        {
            get { return (double) GetValue(ImageWidthProperty); }
            set { SetValue(ImageWidthProperty, value); }
        }
        #endregion

        #region RefreshCommand
        public static readonly DependencyProperty RefreshCommandProperty =
            DependencyProperty.Register(
                "RefreshCommand",
                typeof(ICommand),
                typeof(AddNewRefreshButtonControlBindable),
                new UIPropertyMetadata(null));
        public ICommand RefreshCommand
        {
            get { return (ICommand) GetValue(RefreshCommandProperty); }
            set { SetValue(RefreshCommandProperty, value); }
        }
        #endregion

        #region IsRefreshVisible
        public static readonly DependencyProperty IsRefreshVisibleProperty =
            DependencyProperty.Register(
                "IsRefreshVisible",
                typeof(bool),
                typeof(AddNewRefreshButtonControlBindable),
                new UIPropertyMetadata(null));
        public bool IsRefreshVisible
        {
            get { return (bool) GetValue(IsRefreshVisibleProperty); }
            set { SetValue(IsRefreshVisibleProperty, value); }
        }
        #endregion

        #region RefreshToolTip
        public static readonly DependencyProperty RefreshToolTipProperty =
            DependencyProperty.Register(
                "RefreshToolTip",
                typeof(object),
                typeof(AddNewRefreshButtonControlBindable),
                new UIPropertyMetadata(null));
        public object RefreshToolTip
        {
            get { return (object) GetValue(RefreshToolTipProperty); }
            set { SetValue(RefreshToolTipProperty, value); }
        }
        #endregion

        #region RefreshText
        public static readonly DependencyProperty RefreshTextProperty =
            DependencyProperty.Register(
                "RefreshText",
                typeof(string),
                typeof(AddNewRefreshButtonControlBindable),
                new UIPropertyMetadata(null));
        public string RefreshText
        {
            get { return (string) GetValue(RefreshTextProperty); }
            set { SetValue(RefreshTextProperty, value); }
        }
        #endregion

        #region RefreshImageSource
        public static readonly DependencyProperty RefreshImageSourceProperty =
            DependencyProperty.Register(
                "RefreshImageSource",
                typeof(ImageSource),
                typeof(AddNewRefreshButtonControlBindable),
                new UIPropertyMetadata(null));
        public ImageSource RefreshImageSource
        {
            get { return (ImageSource) GetValue(RefreshImageSourceProperty); }
            set { SetValue(RefreshImageSourceProperty, value); }
        }
        #endregion


        public AddNewRefreshButtonControlBindable()
        {
            InitializeComponent();
            ImageHeight = 16;
            ImageWidth = 16;
        }
    }
}

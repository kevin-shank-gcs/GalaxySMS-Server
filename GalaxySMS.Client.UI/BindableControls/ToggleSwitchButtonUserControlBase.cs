using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Telerik.Windows.Controls;

namespace GalaxySMS.Client.UI
{

    public class ToggleSwitchButtonUserControlBase : UserControl
    {
        public ToggleSwitchButtonUserControlBase()
        {
            ImageWidth = 16;// double.NaN;
            ImageHeight = 16;// double.NaN;
            ControlMargin = 1;
            ContentMargin = 3;
            ContentPosition = SwitchButtonContentPosition.Both;
            CheckedStateTextVisibility = Visibility.Collapsed;
        }

        #region Command
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register(
                "Command",
                typeof(ICommand),
                typeof(ToggleSwitchButtonUserControlBase),
                new UIPropertyMetadata(null));
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
        #endregion

        #region CommandParameter
        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register(
                "CommandParameter",
                typeof(object),
                typeof(ToggleSwitchButtonUserControlBase),
                new UIPropertyMetadata(null));
        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }
        #endregion

        #region IsVisible
        public static readonly DependencyProperty IsVisibleProperty =
            DependencyProperty.Register(
                "IsVisible",
                typeof(bool),
                typeof(ToggleSwitchButtonUserControlBase),
                new UIPropertyMetadata(null));
        public bool IsVisible
        {
            get { return (bool)GetValue(IsVisibleProperty); }
            set { SetValue(IsVisibleProperty, value); }
        }
        #endregion

        #region ToolTip
        public static readonly DependencyProperty ToolTipProperty =
            DependencyProperty.Register(
                "ToolTip",
                typeof(object),
                typeof(ToggleSwitchButtonUserControlBase),
                new UIPropertyMetadata(null));
        public object ToolTip
        {
            get { return (object)GetValue(ToolTipProperty); }
            set { SetValue(ToolTipProperty, value); }
        }
        #endregion

        #region TitleText
        public static readonly DependencyProperty TitleTextProperty =
            DependencyProperty.Register(
                "TitleText",
                typeof(string),
                typeof(ToggleSwitchButtonUserControlBase),
                new UIPropertyMetadata(null));
        public string TitleText
        {
            get { return (string)GetValue(TitleTextProperty); }
            set { SetValue(TitleTextProperty, value); }
        }
        #endregion

        #region TitleStyle
        public static readonly DependencyProperty TitleStyleProperty =
            DependencyProperty.Register(
                "TitleStyle",
                typeof(Style),
                typeof(ToggleSwitchButtonUserControlBase),
                new UIPropertyMetadata(null));
        public Style TitleStyle
        {
            get { return (Style)GetValue(TitleStyleProperty); }
            set { SetValue(TitleStyleProperty, value); }
        }
        #endregion

        #region CheckedImageSource
        public static readonly DependencyProperty CheckedImageSourceProperty =
            DependencyProperty.Register(
                "CheckedImageSource",
                typeof(ImageSource),
                typeof(ToggleSwitchButtonUserControlBase),
                new UIPropertyMetadata(null));
        public ImageSource CheckedImageSource
        {
            get { return (ImageSource)GetValue(CheckedImageSourceProperty); }
            set { SetValue(CheckedImageSourceProperty, value); }
        }
        #endregion

        #region UncheckedImageSource
        public static readonly DependencyProperty UncheckedImageSourceProperty =
            DependencyProperty.Register(
                "UncheckedImageSource",
                typeof(ImageSource),
                typeof(ToggleSwitchButtonUserControlBase),
                new UIPropertyMetadata(null));
        public ImageSource UncheckedImageSource
        {
            get { return (ImageSource)GetValue(UncheckedImageSourceProperty); }
            set { SetValue(UncheckedImageSourceProperty, value); }
        }
        #endregion

        #region CheckedToolTip
        public static readonly DependencyProperty CheckedToolTipProperty =
            DependencyProperty.Register(
                "CheckedToolTip",
                typeof(object),
                typeof(ToggleSwitchButtonUserControlBase),
                new UIPropertyMetadata(null));
        public object CheckedToolTip
        {
            get { return (object)GetValue(CheckedToolTipProperty); }
            set { SetValue(CheckedToolTipProperty, value); }
        }
        #endregion

        #region CheckedTitleText
        public static readonly DependencyProperty CheckedTitleTextProperty =
            DependencyProperty.Register(
                "CheckedTitleText",
                typeof(string),
                typeof(ToggleSwitchButtonUserControlBase),
                new UIPropertyMetadata(null));
        public string CheckedTitleText
        {
            get { return (string)GetValue(CheckedTitleTextProperty); }
            set { SetValue(CheckedTitleTextProperty, value); }
        }
        #endregion

        #region UncheckedToolTip
        public static readonly DependencyProperty UncheckedToolTipProperty =
            DependencyProperty.Register(
                "UncheckedToolTip",
                typeof(object),
                typeof(ToggleSwitchButtonUserControlBase),
                new UIPropertyMetadata(null));
        public object UncheckedToolTip
        {
            get { return (object)GetValue(UncheckedToolTipProperty); }
            set { SetValue(UncheckedToolTipProperty, value); }
        }
        #endregion

        #region UncheckedTitleText
        public static readonly DependencyProperty UncheckedTitleTextProperty =
            DependencyProperty.Register(
                "UncheckedTitleText",
                typeof(string),
                typeof(ToggleSwitchButtonUserControlBase),
                new UIPropertyMetadata(null));
        public string UncheckedTitleText
        {
            get { return (string)GetValue(UncheckedTitleTextProperty); }
            set { SetValue(UncheckedTitleTextProperty, value); }
        }
        #endregion

        #region ImageHeight
        public static readonly DependencyProperty ImageHeightProperty =
            DependencyProperty.Register(
                "ImageHeight",
                typeof(double),
                typeof(ToggleSwitchButtonUserControlBase),
                new UIPropertyMetadata(null));
        public double ImageHeight
        {
            get { return (double)GetValue(ImageHeightProperty); }
            set { SetValue(ImageHeightProperty, value); }
        }
        #endregion

        #region ImageWidth
        public static readonly DependencyProperty ImageWidthProperty =
            DependencyProperty.Register(
                "ImageWidth",
                typeof(double),
                typeof(ToggleSwitchButtonUserControlBase),
                new UIPropertyMetadata(null));
        public double ImageWidth
        {
            get { return (double)GetValue(ImageWidthProperty); }
            set { SetValue(ImageWidthProperty, value); }
        }
        #endregion

        #region ControlMargin
        public static readonly DependencyProperty ControlMarginProperty =
            DependencyProperty.Register(
                "ControlMargin",
                typeof(double),
                typeof(ToggleSwitchButtonUserControlBase),
                new UIPropertyMetadata(null));
        public double ControlMargin
        {
            get { return (double)GetValue(ControlMarginProperty); }
            set { SetValue(ControlMarginProperty, value); }
        }
        #endregion

        #region ContentMargin
        public static readonly DependencyProperty ContentMarginProperty =
            DependencyProperty.Register(
                "ContentMargin",
                typeof(double),
                typeof(ToggleSwitchButtonUserControlBase),
                new UIPropertyMetadata(null));
        public double ContentMargin
        {
            get { return (double)GetValue(ContentMarginProperty); }
            set { SetValue(ContentMarginProperty, value); }
        }
        #endregion

        #region IsChecked
        public static readonly DependencyProperty IsCheckedProperty =
            DependencyProperty.Register(
                "IsChecked",
                typeof(bool),
                typeof(ToggleSwitchButtonUserControlBase),
                new UIPropertyMetadata(null));
        public bool IsChecked
        {
            get { return (bool)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
        }
        #endregion    

        #region ContentPosition
        public static readonly DependencyProperty ContentPositionProperty =
            DependencyProperty.Register(
                "ContentPosition",
                typeof(SwitchButtonContentPosition),
                typeof(ToggleSwitchButtonUserControlBase),
                new UIPropertyMetadata(null));
        public SwitchButtonContentPosition ContentPosition
        {
            get { return (SwitchButtonContentPosition)GetValue(ContentPositionProperty); }
            set { SetValue(ContentPositionProperty, value); }
        }
        #endregion     

        #region CheckedStateTextVisibility
        public static readonly DependencyProperty CheckedStateTextVisibilityProperty =
            DependencyProperty.Register(
                "CheckedStateTextVisibility",
                typeof(Visibility),
                typeof(ToggleSwitchButtonUserControlBase),
                new UIPropertyMetadata(null));
        public Visibility CheckedStateTextVisibility
        {
            get { return (Visibility)GetValue(CheckedStateTextVisibilityProperty); }
            set { SetValue(CheckedStateTextVisibilityProperty, value); }
        }
        #endregion

        #region CheckedContentText
        public static readonly DependencyProperty CheckedContentTextProperty =
            DependencyProperty.Register(
                "CheckedContentText",
                typeof(string),
                typeof(ToggleSwitchButtonUserControlBase),
                new UIPropertyMetadata(null));
        public string CheckedContentText
        {
            get { return (string)GetValue(CheckedContentTextProperty); }
            set { SetValue(CheckedContentTextProperty, value); }
        }
        #endregion

        #region CheckedStateText
        public static readonly DependencyProperty CheckedStateTextProperty =
            DependencyProperty.Register(
                "CheckedStateText",
                typeof(string),
                typeof(ToggleSwitchButtonUserControlBase),
                new UIPropertyMetadata(null));
        public string CheckedStateText
        {
            get { return (string)GetValue(CheckedStateTextProperty); }
            set { SetValue(CheckedStateTextProperty, value); }
        }
        #endregion

        #region UncheckedContentText
        public static readonly DependencyProperty UncheckedContentTextProperty =
            DependencyProperty.Register(
                "UncheckedContentText",
                typeof(string),
                typeof(ToggleSwitchButtonUserControlBase),
                new UIPropertyMetadata(null));
        public string UncheckedContentText
        {
            get { return (string)GetValue(UncheckedContentTextProperty); }
            set { SetValue(UncheckedContentTextProperty, value); }
        }
        #endregion
        
        #region UncheckedStateText
        public static readonly DependencyProperty UncheckedStateTextProperty =
            DependencyProperty.Register(
                "UncheckedStateText",
                typeof(string),
                typeof(ToggleSwitchButtonUserControlBase),
                new UIPropertyMetadata(null));
        public string UncheckedStateText
        {
            get { return (string)GetValue(UncheckedStateTextProperty); }
            set { SetValue(UncheckedStateTextProperty, value); }
        }
        #endregion

        #region StateTextStyle
        public static readonly DependencyProperty StateTextStyleProperty =
            DependencyProperty.Register(
                "StateTextStyle",
                typeof(Style),
                typeof(ToggleSwitchButtonUserControlBase),
                new UIPropertyMetadata(null));
        public Style StateTextStyle
        {
            get { return (Style)GetValue(StateTextStyleProperty); }
            set { SetValue(StateTextStyleProperty, value); }
        }
        #endregion
        
        #region CheckedContent
        public static readonly DependencyProperty CheckedContentProperty =
            DependencyProperty.Register(
                "CheckedContent",
                typeof(object),
                typeof(ToggleSwitchButtonUserControlBase),
                new UIPropertyMetadata(null));
        public object CheckedContent
        {
            get { return (object)GetValue(CheckedContentProperty); }
            set { SetValue(CheckedContentProperty, value); }
        }
        #endregion

        #region UncheckedContent
        public static readonly DependencyProperty UncheckedContentProperty =
            DependencyProperty.Register(
                "UncheckedContent",
                typeof(object),
                typeof(ToggleSwitchButtonUserControlBase),
                new UIPropertyMetadata(null));
        public object UncheckedContent
        {
            get { return (object)GetValue(UncheckedContentProperty); }
            set { SetValue(UncheckedContentProperty, value); }
        }
        #endregion
    }
}

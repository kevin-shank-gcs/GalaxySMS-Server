using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace GalaxySMS.Client.UI
{
    public enum LeftOrRight { Left, Right }

    public class ButtonUserControlBase : UserControl
    {
        public ButtonUserControlBase()
        {
            ImageWidth = 16;// double.NaN;
            ImageHeight = 16;// double.NaN;
            ImageColumn = 0;
            TextColumn = 1;
            ButtonMargin=1;
            ContentMargin = 3;
            //ImagePosition = LeftOrRight.Left;
        }

        #region Command
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register(
                "Command",
                typeof(ICommand),
                typeof(ButtonUserControlBase),
                new UIPropertyMetadata(null));
        public ICommand Command
        {
            get { return (ICommand) GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
        #endregion

        #region CommandParameter
        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register(
                "CommandParameter",
                typeof(object),
                typeof(ButtonUserControlBase),
                new UIPropertyMetadata(null));
        public object CommandParameter
        {
            get { return (object) GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }
        #endregion

        #region IsVisible
        public static readonly DependencyProperty IsVisibleProperty =
            DependencyProperty.Register(
                "IsVisible",
                typeof(bool),
                typeof(ButtonUserControlBase),
                new UIPropertyMetadata(null));
        public bool IsVisible
        {
            get { return (bool) GetValue(IsVisibleProperty); }
            set { SetValue(IsVisibleProperty, value); }
        }
        #endregion

        #region ToolTip
        public static readonly DependencyProperty ToolTipProperty =
            DependencyProperty.Register(
                "ToolTip",
                typeof(object),
                typeof(ButtonUserControlBase),
                new UIPropertyMetadata(null));
        public object ToolTip
        {
            get { return (object) GetValue(ToolTipProperty); }
            set { SetValue(ToolTipProperty, value); }
        }
        #endregion

        #region Text
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(
                "Text",
                typeof(string),
                typeof(ButtonUserControlBase),
                new UIPropertyMetadata(null));
        public string Text
        {
            get { return (string) GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        #endregion

        #region ImageSource
        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register(
                "ImageSource",
                typeof(ImageSource),
                typeof(ButtonUserControlBase),
                new UIPropertyMetadata(null));
        public ImageSource ImageSource
        {
            get { return (ImageSource) GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }
        #endregion

        #region ImageHeight
        public static readonly DependencyProperty ImageHeightProperty =
            DependencyProperty.Register(
                "ImageHeight",
                typeof(double),
                typeof(ButtonUserControlBase),
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
                typeof(ButtonUserControlBase),
                new UIPropertyMetadata(null));
        public double ImageWidth
        {
            get { return (double) GetValue(ImageWidthProperty); }
            set { SetValue(ImageWidthProperty, value); }
        }
        #endregion

        #region ButtonMargin
        public static readonly DependencyProperty ButtonMarginProperty =
            DependencyProperty.Register(
                "ButtonMargin",
                typeof(double),
                typeof(ButtonUserControlBase),
                new UIPropertyMetadata(null));
        public double ButtonMargin
        {
            get { return (double) GetValue(ButtonMarginProperty); }
            set { SetValue(ButtonMarginProperty, value); }
        }
        #endregion
        
        #region ContentMargin
        public static readonly DependencyProperty ContentMarginProperty =
            DependencyProperty.Register(
                "ContentMargin",
                typeof(double),
                typeof(ButtonUserControlBase),
                new UIPropertyMetadata(null));
        public double ContentMargin
        {
            get { return (double) GetValue(ContentMarginProperty); }
            set { SetValue(ContentMarginProperty, value); }
        }
        #endregion
        
        #region ImageColumn
        public static readonly DependencyProperty ImageColumnProperty =
            DependencyProperty.Register(
                "ImageColumn",
                typeof(Int32),
                typeof(ButtonUserControlBase),
                new UIPropertyMetadata(null));
        public Int32 ImageColumn
        {
            get { return (Int32) GetValue(ImageColumnProperty); }
            set { SetValue(ImageColumnProperty, value); }
        }
        #endregion

        #region TextColumn
        public static readonly DependencyProperty TextColumnProperty =
            DependencyProperty.Register(
                "TextColumn",
                typeof(Int32),
                typeof(ButtonUserControlBase),
                new UIPropertyMetadata(null));
        public Int32 TextColumn
        {
            get { return (Int32) GetValue(TextColumnProperty); }
            set { SetValue(TextColumnProperty, value); }
        }
        #endregion

        #region ImagePosition
        public static readonly DependencyProperty ImagePositionProperty =
            DependencyProperty.Register(
                "ImagePosition",
                typeof(LeftOrRight),
                typeof(ButtonUserControlBase),
                new UIPropertyMetadata(null));
        public LeftOrRight ImagePosition
        {
            get { return (LeftOrRight) GetValue(ImagePositionProperty); }
            set {
                switch(value)
                {
                    case LeftOrRight.Left:
                        ImageColumn = 0;
                        TextColumn = 1;
                        break;
                    case LeftOrRight.Right:
                        ImageColumn = 1;
                        TextColumn = 0;
                        break;
                }
                SetValue(ImagePositionProperty, value);
            }
        }
        #endregion


    }
}

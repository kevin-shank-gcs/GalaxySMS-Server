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
    public class LabeledTextBoxUserControlBase : UserControl
    {
        public enum LeftOrTop { Left, Top }
        public LabeledTextBoxUserControlBase()
        {
            LabelPosition = LeftOrTop.Top;
            IsVisible = true;
            IsEnabled = true;
            IsReadOnly = false;
        }

        #region IsVisible
        public static readonly DependencyProperty IsVisibleProperty =
            DependencyProperty.Register(
                "IsVisible",
                typeof(bool),
                typeof(LabeledTextBoxUserControlBase),
                new UIPropertyMetadata(null));
        public bool IsVisible
        {
            get { return (bool) GetValue(IsVisibleProperty); }
            set { SetValue(IsVisibleProperty, value); }
        }
        #endregion

        #region IsEnabled
        public static readonly DependencyProperty IsEnabledProperty =
            DependencyProperty.Register(
                "IsEnabled",
                typeof(bool),
                typeof(LabeledTextBoxUserControlBase),
                new UIPropertyMetadata(null));
        public bool IsEnabled
        {
            get { return (bool)GetValue(IsEnabledProperty); }
            set { SetValue(IsEnabledProperty, value); }
        }
        #endregion

        #region IsReadOnly
        public static readonly DependencyProperty IsReadOnlyProperty =
            DependencyProperty.Register(
                "IsReadOnly",
                typeof(bool),
                typeof(LabeledTextBoxUserControlBase),
                new UIPropertyMetadata(null));
        public bool IsReadOnly
        {
            get { return (bool)GetValue(IsReadOnlyProperty); }
            set { SetValue(IsReadOnlyProperty, value); }
        }
        #endregion

        #region ToolTip
        public static readonly DependencyProperty ToolTipProperty =
            DependencyProperty.Register(
                "ToolTip",
                typeof(object),
                typeof(LabeledTextBoxUserControlBase),
                new UIPropertyMetadata(null));
        public object ToolTip
        {
            get { return (object) GetValue(ToolTipProperty); }
            set { SetValue(ToolTipProperty, value); }
        }
        #endregion

        #region LabelText
        public static readonly DependencyProperty LabelTextProperty =
            DependencyProperty.Register(
                "LabelText",
                typeof(string),
                typeof(LabeledTextBoxUserControlBase),
                new UIPropertyMetadata(null));
        public string LabelText
        {
            get { return (string) GetValue(LabelTextProperty); }
            set { SetValue(LabelTextProperty, value); }
        }
        #endregion

        #region LabelColumn
        public static readonly DependencyProperty LabelColumnProperty =
            DependencyProperty.Register(
                "LabelColumn",
                typeof(Int32),
                typeof(LabeledTextBoxUserControlBase),
                new UIPropertyMetadata(null));
        public Int32 LabelColumn
        {
            get { return (Int32) GetValue(LabelColumnProperty); }
            set { SetValue(LabelColumnProperty, value); }
        }
        #endregion

        #region LabelRow
        public static readonly DependencyProperty LabelRowProperty =
            DependencyProperty.Register(
                "LabelRow",
                typeof(Int32),
                typeof(LabeledTextBoxUserControlBase),
                new UIPropertyMetadata(null));
        public Int32 LabelRow
        {
            get { return (Int32) GetValue(LabelRowProperty); }
            set { SetValue(LabelRowProperty, value); }
        }
        #endregion

        #region LabelPosition
        public static readonly DependencyProperty LabelPositionProperty =
            DependencyProperty.Register(
                "LabelPosition",
                typeof(LeftOrTop),
                typeof(LabeledTextBoxUserControlBase),
                new UIPropertyMetadata(null));
        public LeftOrTop LabelPosition
        {
            get { return (LeftOrTop) GetValue(LabelPositionProperty); }
            set
            {
                switch (value)
                {
                    case LeftOrTop.Left:
                        LabelColumn = 0;
                        LabelRow = 1;
                        break;
                    case LeftOrTop.Top:
                        LabelColumn = 1;
                        LabelRow = 0;
                        break;
                }
                SetValue(LabelPositionProperty, value);
            }
        }
        #endregion

        #region LabelVerticalAlignment
        public static readonly DependencyProperty LabelVerticalAlignmentProperty =
            DependencyProperty.Register(
                "LabelVerticalAlignment",
                typeof(VerticalAlignment),
                typeof(LabeledTextBoxUserControlBase),
                new UIPropertyMetadata(null));
        public VerticalAlignment LabelVerticalAlignment
        {
            get { return (VerticalAlignment) GetValue(LabelVerticalAlignmentProperty); }
            set
            {
                SetValue(LabelVerticalAlignmentProperty, value);
            }
        }
        #endregion

        #region TextBoxValue
        public static readonly DependencyProperty TextBoxValueProperty =
            DependencyProperty.Register(
                "TextBoxValue",
                typeof(string),
                typeof(LabeledTextBoxUserControlBase),
                new UIPropertyMetadata(null));
        public string TextBoxValue
        {
            get { return (string) GetValue(TextBoxValueProperty); }
            set { SetValue(TextBoxValueProperty, value); }
        }
        #endregion

        #region TextMask
        public static readonly DependencyProperty TextMaskProperty =
            DependencyProperty.Register(
                "TextMask",
                typeof(string),
                typeof(LabeledTextBoxUserControlBase),
                new UIPropertyMetadata(null));
        public string TextMask
        {
            get { return (string) GetValue(TextMaskProperty); }
            set { SetValue(TextMaskProperty, value); }
        }
        #endregion

        #region EmptyContent
        public static readonly DependencyProperty EmptyContentProperty =
            DependencyProperty.Register(
                "EmptyContent",
                typeof(string),
                typeof(LabeledTextBoxUserControlBase),
                new UIPropertyMetadata(null));
        public string EmptyContent
        {
            get { return (string)GetValue(EmptyContentProperty); }
            set { SetValue(EmptyContentProperty, value); }
        }
        #endregion

        #region MinimumLength
        public static readonly DependencyProperty MinimumLengthProperty =
            DependencyProperty.Register(
                "MinimumLength",
                typeof(Int32),
                typeof(LabeledTextBoxUserControlBase),
                new UIPropertyMetadata(null));
        public Int32 MinimumLength
        {
            get { return (Int32)GetValue(MinimumLengthProperty); }
            set { SetValue(MinimumLengthProperty, value); }
        }
        #endregion

        #region MaximumLength
        public static readonly DependencyProperty MaximumLengthProperty =
            DependencyProperty.Register(
                "MaximumLength",
                typeof(Int32),
                typeof(LabeledTextBoxUserControlBase),
                new UIPropertyMetadata(null));
        public Int32 MaximumLength
        {
            get { return (Int32)GetValue(MaximumLengthProperty); }
            set { SetValue(MaximumLengthProperty, value); }
        }
        #endregion
    }
}

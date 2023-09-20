////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Core\DialogService.cs
//
// summary:	Implements the dialog service class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using GCS.Core.Common.UI.Interfaces;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Navigation;
using GCS.Core.Common.UI.Extensions;

namespace GCS.Core.Common.UI.Core
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A service for accessing dialogs information. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [Export(typeof(IDialogService))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public  class DialogService : IDialogService
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the view model. </summary>
        ///
        /// <value> The view model. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ViewModelBase ViewModel { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the dialog window. </summary>
        ///
        /// <value> The dialog window. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Window DialogWindow { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the radians dialog window. </summary>
        ///
        /// <value> The radians dialog window. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public RadWindow RadDialogWindow { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the popup window. </summary>
        ///
        /// <value> The popup window. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Popup PopupWindow { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Shows the message box. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="content">  The content. </param>
        /// <param name="title">    The title. </param>
        /// <param name="buttons">  The buttons. </param>
        ///
        /// <returns>   A MessageBoxResult. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public MessageBoxResult ShowMessageBox(string content,
        string title, MessageBoxButton buttons)
        {
            return MessageBox.Show(content, title, buttons);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Creates the window. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   The new window. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Window CreateWindow()
        {
            Window win = new Window();
            win.WindowStyle = WindowStyle.ToolWindow;
            win.ResizeMode = ResizeMode.CanResizeWithGrip;
            win.SetFlowDirection();

            return win;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Creates radians window. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   The new radians window. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public RadWindow CreateRadWindow()
        {
            RadWindow win = new RadWindow();
            win.HideMinimizeButton = true;
            win.ResizeMode = ResizeMode.CanResizeWithGrip;
            win.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            win.CanMove = true;
            win.SizeToContent = true;
            RadWindowInteropHelper.SetAllowTransparency(win, false);
            win.SetFlowDirection();
            return win;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Creates the popup. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   The new popup. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Popup CreatePopup()
        {
            Popup pop = new Popup();
            pop.SetFlowDirection();

            return pop;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sets flow direction. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="pop">  The pop. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private static void SetFlowDirection(Popup pop)
        {
            if (CultureInfo.CurrentUICulture.TextInfo.IsRightToLeft)
                pop.FlowDirection = FlowDirection.RightToLeft;
            else
                pop.FlowDirection = FlowDirection.LeftToRight;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Shows the dialog. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="viewModel">    The view model. </param>
        /// <param name="dialog">       The dialog. </param>
        ///
        /// <returns>   A Nullable&lt;bool&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Nullable<bool> ShowDialog(ViewModelBase viewModel, Window dialog)
        {
            if (dialog == null)
            {
                dialog = CreateWindow();
            }
            DialogWindow = dialog;
            DialogWindow.SizeToContent = SizeToContent.WidthAndHeight;
            DialogWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            ViewModel = viewModel;
            dialog.Title = viewModel.ViewTitle;
            dialog.DataContext = ViewModel;
            dialog.Owner = Application.Current.MainWindow;
            dialog.ShowInTaskbar = false;
            dialog.SetFlowDirection();
            return dialog.ShowDialog();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Shows the dialog. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="userControl">  The user control. </param>
        /// <param name="dialog">       The dialog. </param>
        /// <param name="windowTitle">  The window title. </param>
        ///
        /// <returns>   A Nullable&lt;bool&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Nullable<bool> ShowDialog(UserControl userControl, Window dialog, string windowTitle)
        {
            if (dialog == null)
            {
                dialog = CreateWindow();
            }

            DialogWindow = dialog;
            DialogWindow.SizeToContent = SizeToContent.WidthAndHeight;
            DialogWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            dialog.Title = windowTitle;
            dialog.Content = userControl;
            dialog.Owner = Application.Current.MainWindow;
            dialog.ShowInTaskbar = false;
            dialog.SetFlowDirection();
            return dialog.ShowDialog();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Shows the dialog. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="viewModel">    The view model. </param>
        /// <param name="content">      The content. </param>
        /// <param name="dialog">       The dialog. </param>
        /// <param name="windowTitle">  The window title. </param>
        ///
        /// <returns>   A Nullable&lt;bool&gt; </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Nullable<bool> ShowDialog(ViewModelBase viewModel, object content, Window dialog, string windowTitle)
        {
            if (dialog == null)
            {
                dialog = CreateWindow();
            }

            DialogWindow = dialog;
            DialogWindow.Content = content;
            ViewModel = viewModel;
            DialogWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            DialogWindow.SizeToContent = SizeToContent.WidthAndHeight;
            dialog.Title = windowTitle;
            dialog.DataContext = ViewModel;
            dialog.Owner = Application.Current.MainWindow;
            dialog.ShowInTaskbar = false;
            dialog.SetFlowDirection();
            return dialog.ShowDialog();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Shows the radians dialog. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="viewModel">    The view model. </param>
        /// <param name="dialog">       The dialog. </param>
        ///
        /// <returns>   A bool? </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool? ShowRadDialog(ViewModelBase viewModel, RadWindow dialog)
        {
            if (dialog == null)
            {
                dialog = CreateRadWindow();
            }
            RadDialogWindow = dialog;
            ViewModel = viewModel;
            dialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            dialog.Header = viewModel.ViewTitle;
            dialog.DataContext = ViewModel;
            dialog.Owner = Application.Current.MainWindow;
            dialog.ShowDialog();
            dialog.SetFlowDirection();
            return dialog.DialogResult;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Shows the radians dialog. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="viewModel">    The view model. </param>
        /// <param name="content">      The content. </param>
        /// <param name="dialog">       The dialog. </param>
        /// <param name="windowTitle">  The window title. </param>
        ///
        /// <returns>   A bool? </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool? ShowRadDialog(ViewModelBase viewModel, object content, RadWindow dialog, string windowTitle)
        {
            if (dialog == null)
            {
                dialog = CreateRadWindow();
            }
            RadDialogWindow = dialog;
            RadDialogWindow.Content = content;
            ViewModel = viewModel;
            dialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            dialog.Header = viewModel.ViewTitle;
            dialog.DataContext = ViewModel;
            dialog.Owner = Application.Current.MainWindow;
            dialog.ShowDialog();
            dialog.SetFlowDirection();
            return dialog.DialogResult;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Shows the radians dialog. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="userControl">  The user control. </param>
        /// <param name="dialog">       The dialog. </param>
        /// <param name="windowTitle">  The window title. </param>
        ///
        /// <returns>   A bool? </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool? ShowRadDialog(UserControl userControl, RadWindow dialog, string windowTitle)
        {
            if (dialog == null)
            {
                dialog = CreateRadWindow();
            }

            RadDialogWindow = dialog;
            dialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            dialog.Content = userControl;
            dialog.Header = windowTitle;
            dialog.Owner = Application.Current.MainWindow;
            dialog.SetFlowDirection();
            dialog.ShowDialog();
            return dialog.DialogResult;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Shows the popup. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="viewModel">    The view model. </param>
        /// <param name="popup">        The popup. </param>
        ///
        /// <returns>   A bool? </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool? ShowPopup(ViewModelBase viewModel, Popup popup)
        {
            if (popup == null)
            {
                popup = CreatePopup();
            }
            PopupWindow = popup;
            ViewModel = viewModel;
            SetFlowDirection(PopupWindow);

            PopupWindow.DataContext = ViewModel;
            PopupWindow.IsOpen = true;
            return true;

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Shows the popup. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="userControl">  The user control. </param>
        /// <param name="popup">        The popup. </param>
        ///
        /// <returns>   A bool? </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool? ShowPopup(UserControl userControl, Popup popup)
        {
            if (popup == null)
            {
                popup = CreatePopup();
            }

            PopupWindow = popup;
            PopupWindow.Child = userControl;
            SetFlowDirection(PopupWindow);
            PopupWindow.IsOpen = true;
            return true;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Alerts the given dialog parameters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="content">  The content. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Alert(object content)
        {
            RadWindow.Alert(new DialogParameters()
            {
                Content = content,
            });
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Alerts the given dialog parameters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="content">  The content. </param>
        /// <param name="closed">   The closed. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Alert(object content, EventHandler<WindowClosedEventArgs> closed)
        {
            RadWindow.Alert(content, closed);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Alerts the given dialog parameters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="dialogParameters"> Options for controlling the dialog. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Alert(DialogParameters dialogParameters)
        {
            RadWindow.Alert(dialogParameters);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Prompts the given dialog parameters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="content">  The content. </param>
        /// <param name="closed">   The closed. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Prompt(object content, EventHandler<WindowClosedEventArgs> closed)
        {
            RadWindow.Prompt(content, closed);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Prompts the given dialog parameters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="content">              The content. </param>
        /// <param name="closed">               The closed. </param>
        /// <param name="defaultPromptResult">  The default prompt result. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Prompt(object content, EventHandler<WindowClosedEventArgs> closed, string defaultPromptResult)
        {
            RadWindow.Prompt(content, closed, defaultPromptResult);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Prompts the given dialog parameters. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="dialogParameters"> Options for controlling the dialog. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Prompt(DialogParameters dialogParameters)
        {
            RadWindow.Prompt(dialogParameters);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Confirms. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="dialogParameters"> Options for controlling the dialog. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Confirm(DialogParameters dialogParameters)
        {
            RadWindow.Confirm(dialogParameters);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Confirms. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="content">  The content. </param>
        /// <param name="closed">   The closed. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Confirm(object content, EventHandler<WindowClosedEventArgs> closed)
        {
            RadWindow.Confirm(content, closed);
        }

    }
}

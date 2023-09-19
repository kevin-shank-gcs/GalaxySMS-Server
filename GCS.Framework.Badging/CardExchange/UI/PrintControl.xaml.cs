using CardExchangeRemotable;
using GCS.Core.Common.Extensions;
using GCS.Core.Common.UI.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Telerik.Windows.Controls;
using GCS.Framework.Imaging;
using Image = System.Windows.Controls.Image;

namespace GCS.Framework.Badging.CardExchange.UI
{
    /// <summary>
    /// Interaction logic for PrintControl.xaml
    /// </summary>
    public partial class PrintControl : UserControlViewBase
    {
        private CardExchangeRemotable.ServerObject m_objPrintServer;
        private CardExchangeRemotable.ClientObject m_objClient;
        private string _StatusMessage;
        private string _messages;
        private string _PrintServerURL;
        private int _ClientPort;
        private uint _PersonID;
        private uint _cardId;
        private int _PrintCount;
        private bool _AutoPreview;
        private bool _AutoPrint;
        private bool _AutoClose;
        private bool _DisplayErrorMessages;
        private bool _ThrowExceptions;
        private bool _EnableBadgeLayoutSelection;
        private bool _EnablePrint;
        private ObservableCollection<string> _LayoutNames;
        private string _BadgeLayoutName;
        private Timer timer1;
        private bool _canPrint;
        private bool _canPreview;
        private bool _EnableRefresh;

        public PrintControl()
        {
            InitializeComponent();
            DataContext = this;

            RefreshPreviewCommand = new DelegateCommand<object>(ExecuteRefreshPreviewCommand, CanExecuteRefreshPreviewCommand);
            PrintCommand = new DelegateCommand<object>(ExecutePrintCommand, CanExecutePrintCommand);
            CloseCommand = new DelegateCommand<object>(ExecuteCloseCommand, CanExecuteCloseCommand);

            Loaded += PrintControl_Loaded;
            Unloaded += PrintControl_Unloaded;
            timer1 = new Timer();
            timer1.Elapsed += Timer1_Elapsed;
            timer1.AutoReset = true;
        }

        private void Timer1_Elapsed(object sender, ElapsedEventArgs e)
        {
            Trace.WriteLine(string.Format("Timer1_Elapsed. AutoPreview:{0}, BadgeLayoutName:{1}, AutoPrint:{2}, EnablePrint:{3}, AutoClose:{4}",
                AutoPreview, BadgeLayoutName, AutoPrint, EnablePrint, AutoClose));
            timer1.Enabled = false;
            if (AutoPreview && BadgeLayoutName.Length > 0)
            {
                AutoPreview = false;
                ExecuteRefreshPreviewCommand(null);
                return;
            }

            if (AutoPrint && BadgeLayoutName.Length > 0 && EnablePrint)
            {
                AutoPrint = false;
                ExecutePrintCommand(null);
                return;
            }

            if (AutoClose == true && timer1.Interval == 1000)
                ExecuteCloseCommand(null);
        }

        public string PrintServerURL
        {
            get { return _PrintServerURL; }
            set
            {
                if (_PrintServerURL != value)
                {
                    _PrintServerURL = value;
                    OnPropertyChanged(() => PrintServerURL);
                }
            }
        }

        public int ClientPort
        {
            get { return _ClientPort; }
            set
            {
                if (_ClientPort != value)
                {
                    _ClientPort = value;
                    OnPropertyChanged(() => ClientPort);
                }
            }
        }

        public uint PersonID
        {
            get { return _PersonID; }
            set
            {
                if (_PersonID != value)
                {
                    _PersonID = value;
                    OnPropertyChanged(() => PersonID);
                    OnPropertyChanged(() => UniqueId);
                }
            }
        }

        public uint CardID
        {
            get { return _cardId; }
            set
            {
                if (_cardId != value)
                {
                    _cardId = value;
                    OnPropertyChanged(() => CardID);
                    OnPropertyChanged(() => UniqueId);
                }
            }
        }

        public string UniqueId
        {
            get
            {
                if (PersonID != -1 && CardID == -1)
                    return string.Format("{0}", PersonID);
                else
                    return string.Format("{0}:{1}",
                        PersonID, CardID);
            }
            set
            {
                OnPropertyChanged(() => UniqueId);
            }
        }

        public string BadgeLayoutName
        {
            get { return _BadgeLayoutName; }
            set
            {
                if (_BadgeLayoutName != value)
                {
                    _BadgeLayoutName = value;
                    OnPropertyChanged(() => BadgeLayoutName);
                }
            }
        }

        public int PrintCount
        {
            get { return _PrintCount; }
            set
            {
                if (_PrintCount != value)
                {
                    _PrintCount = value;
                    OnPropertyChanged(() => PrintCount);
                }
            }
        }

        public bool AutoPreview
        {
            get { return _AutoPreview; }
            set
            {
                if (_AutoPreview != value)
                {
                    _AutoPreview = value;
                    OnPropertyChanged(() => AutoPreview);
                }
            }
        }

        public bool AutoPrint
        {
            get { return _AutoPrint; }
            set
            {
                if (_AutoPrint != value)
                {
                    _AutoPrint = value;
                    OnPropertyChanged(() => AutoPrint);
                }
            }
        }

        public bool AutoClose
        {
            get { return _AutoClose; }
            set
            {
                if (_AutoClose != value)
                {
                    _AutoClose = value;
                    OnPropertyChanged(() => AutoClose);
                }
            }
        }

        public bool DisplayErrorMessages
        {
            get { return _DisplayErrorMessages; }
            set
            {
                if (_DisplayErrorMessages != value)
                {
                    _DisplayErrorMessages = value;
                    OnPropertyChanged(() => DisplayErrorMessages);
                }
            }
        }

        public bool ThrowExceptions
        {
            get { return _ThrowExceptions; }
            set
            {
                if (_ThrowExceptions != value)
                {
                    _ThrowExceptions = value;
                    OnPropertyChanged(() => ThrowExceptions);
                }
            }
        }

        public bool EnableBadgeLayoutSelection
        {
            get { return _EnableBadgeLayoutSelection; }
            set
            {
                if (_EnableBadgeLayoutSelection != value)
                {
                    _EnableBadgeLayoutSelection = value;
                    OnPropertyChanged(() => EnableBadgeLayoutSelection);
                }
            }
        }

        public bool EnablePrint
        {
            get { return _EnablePrint; }
            set
            {
                if (_EnablePrint != value)
                {
                    _EnablePrint = value;
                    OnPropertyChanged(() => EnablePrint);
                }
            }
        }


        public bool EnableRefresh
        {
            get { return _EnableRefresh; }
            set
            {
                if (_EnableRefresh != value)
                {
                    _EnableRefresh = value;
                    OnPropertyChanged(() => EnableRefresh);
                }
            }
        }

        public string Messages
        {
            get { return _messages; }
            set
            {
                if (_messages != value)
                {
                    _messages = value;
                    OnPropertyChanged(() => Messages);
                }
            }
        }


        public string StatusMessage
        {
            get { return _StatusMessage; }
            set
            {
                if (_StatusMessage != value)
                {
                    _StatusMessage = value;
                    OnPropertyChanged(() => StatusMessage);
                }
            }
        }

        public ObservableCollection<string> LayoutNames
        {
            get { return _LayoutNames; }
            set
            {
                if (_LayoutNames != value)
                {
                    _LayoutNames = value;
                    OnPropertyChanged(() => LayoutNames);
                }
            }
        }


        public DelegateCommand<object> RefreshPreviewCommand { get; private set; }
        public DelegateCommand<object> PrintCommand { get; private set; }
        public DelegateCommand<object> CloseCommand { get; private set; }

        private void GetLayoutNames()
        {
            try
            {
                //Clear the layout-names combo box
                LayoutNames = new ObservableCollection<string>();

                // Fill the layout-names combo box
                LayoutNames = ((PrintServer)m_objPrintServer).GetLayoutNames().ToObservableCollection();
                if (LayoutNames == null)
                    MessageBox.Show($"LayoutNames is null");
            }
            catch (Exception ex)
            {
                if (DisplayErrorMessages == true)
                    MessageBox.Show($"GetLayoutNames exception: {ex.Message}", Properties.Resources.ErrorHeader);
            }
        }

        private void PrintControl_Loaded(object sender, RoutedEventArgs e)
        {
            var window = this.ParentOfType<RadWindow>();
            window.Visibility = Visibility.Collapsed;
            try
            {
                CardExchangeRemotable.Licensing.CheckLicense();
            }
            catch (Exception ex)
            {
                if (DisplayErrorMessages == true)
                    MessageBox.Show(
                        string.Format(Properties.Resources.LicenseCheckFailed + "{0}", ex.Message),
                        Properties.Resources.ErrorHeader);
                //ExecuteCloseCommand(null);
                //return;
            }
            //Connect to the remotable print-server object
            //This can be either a print server or a dispatcher
            try
            {
                m_objPrintServer = (CardExchangeRemotable.ServerObject)(RemotableObject.Connect(
                    PrintServerURL));
            }
            catch (Exception ex)
            {
                if (DisplayErrorMessages == true)
                    MessageBox.Show(string.Format("RemotableObject.Connect error: {0}", ex.Message),
                        Properties.Resources.ErrorHeader);
                ExecuteCloseCommand(null);
                return;
            }

            //Create and register a client object
            m_objClient = new ClientObject();
            m_objClient.JobStatusChanged += m_objClient_JobStatusChanged;
            m_objClient.JobErrorReported += m_objClient_JobErrorReported;

            try
            {
                System.Runtime.Remoting.ObjRef objObjectRef =
                    RemotableObject.Publish(m_objClient, ClientPort);
            }
            catch (Exception ex)
            {
                if (DisplayErrorMessages == true)
                    MessageBox.Show($"RemotableObject.Publish error: {ex.Message}", Properties.Resources.ErrorHeader);
                GetLayoutNames();

                ExecuteCloseCommand(null);
                return;
            }

            GetLayoutNames();
            //if (PersonID == -1)
            //{
            //    ExecuteCloseCommand(null);
            //    return;
            //}

            window.Visibility = Visibility.Visible;

            if (LayoutNames.Contains(BadgeLayoutName) == false)
            {
                string sMsg = string.Format("{0}\n({1})", Properties.Resources.RequestedBadgeLayoutNotFound, BadgeLayoutName);
                if (DisplayErrorMessages == true)
                    MessageBox.Show(sMsg, Properties.Resources.ErrorHeader);
                else if (ThrowExceptions == true)
                    throw new Exception(sMsg);
                EnableSystemMenuCloseX(true);
                EnablePrintAndPreviewBtns(false);
                if (AutoClose)
                {
                    window.Visibility = Visibility.Collapsed;
                    ExecuteCloseCommand(null);
                }
            }
            else
            {
                Trace.WriteLine(string.Format("PrintControl_Loaded. AutoPreview:{0}, BadgeLayoutName:{1}",
                    AutoPreview, BadgeLayoutName));

                if (AutoPreview && BadgeLayoutName.Length > 0)
                {
                    timer1.Interval = 200;
                    timer1.Enabled = true;
                }
            }
        }

        private void PrintControl_Unloaded(object sender, RoutedEventArgs e)
        {
            try
            {
                timer1.Enabled = false;
                RemotableObject.Disconnect(m_objClient);
                //          RemotableObject.Disconnect(m_objPrintServer);
            }
            catch (Exception ex)
            {
                if (DisplayErrorMessages == true)
                {
                    MessageBox.Show(ex.Message);
                    MessageBox.Show(string.Format("FormClosing error: {0}", ex.Message));
                }
            }
        }

        private bool CanExecuteCloseCommand(object obj)
        {
            return true;
            var window = this.ParentOfType<RadWindow>();
            return window.CanClose;
        }

        private void ExecuteCloseCommand(object obj)
        {
            if (!Dispatcher.CheckAccess())
            {
                Trace.WriteLine("ExecuteCloseCommand calling Dispatcher.Invoke");
                //' This event generally enters on another thread than the main one
                //' For user-interface related actions, this function should be called on the main thread
                Dispatcher.BeginInvoke(new Action(delegate ()
                {
                    ExecuteCloseCommand(obj);
                }));

                Trace.WriteLine("ExecuteCloseCommand Dispatcher.Invoke called");
            }
            else
            {
                var window = this.ParentOfType<RadWindow>();
                window.Close();
            }
        }

        private bool CanExecutePrintCommand(object obj)
        {
            if (!string.IsNullOrEmpty(BadgeLayoutName) && EnablePrint)
                return true;
            return false;
        }

        private void ExecutePrintCommand(object obj)
        {
            if (!Dispatcher.CheckAccess())
            {
                Trace.WriteLine("ExecutePrintCommand calling Dispatcher.Invoke");
                //' This event generally enters on another thread than the main one
                //' For user-interface related actions, this function should be called on the main thread
                Dispatcher.BeginInvoke(new Action(delegate ()
                {
                    ExecutePrintCommand(obj);
                }));

                Trace.WriteLine("ExecutePrintCommand Dispatcher.Invoke called");
            }
            else
            {
                int intJobID;
                string strShortDescription;

                Messages = string.Empty;

                Cursor = Cursors.Wait;

                try
                {
                    EnableSystemMenuCloseX(false);
                    EnablePrintAndPreviewBtns(false);
                    // Make sure that values have been entered for the layout name and the key value
                    if (BadgeLayoutName == String.Empty)
                    {
                        Messages = Properties.Resources.NoLayoutSpecified;

                        if (DisplayErrorMessages == true)
                            MessageBox.Show(Messages, Properties.Resources.ErrorHeader);
                        if (ThrowExceptions == true)
                            throw new Exception(Messages);
                    }
                    else if (UniqueId == String.Empty)
                    {
                        Messages = Properties.Resources.NoKeySpecified;

                        if (DisplayErrorMessages == true)
                            MessageBox.Show(Messages, Properties.Resources.ErrorHeader);
                        if (ThrowExceptions == true)
                            throw new Exception(Messages);
                    }
                    else
                    {
                        // If so, generate a descriptive text for the preview request ...
                        strShortDescription = String.Format("{0}[{1}]", BadgeLayoutName, UniqueId);

                        // and send the print job
                        intJobID = m_objPrintServer.PrintCard(UniqueId, BadgeLayoutName, null, null, strShortDescription, m_objClient);
                    }
                }
                catch (Exception ex)
                {
                    string strMessage = Properties.Resources.GenericError + '\n' + ex.Message;

                    while (ex.InnerException != null)
                    {
                        ex = ex.InnerException;
                        strMessage += string.Format("\n{0}", ex.Message);
                    }

                    if (DisplayErrorMessages == true)
                        RadWindow.Alert(new DialogParameters()
                        {
                            Content = strMessage,
                            Header = Properties.Resources.GenericError,
                        });

                    Messages = strMessage;

                    EnableSystemMenuCloseX(true);
                    EnablePrintAndPreviewBtns(true);
                }
                finally
                {
                    Cursor = Cursors.Arrow;
                }
            }
        }

        private bool CanExecuteRefreshPreviewCommand(object obj)
        {
            if (!string.IsNullOrEmpty(BadgeLayoutName) && EnableRefresh)
                return true;
            return false;
        }

        private void ExecuteRefreshPreviewCommand(object obj)
        {

            if (!Dispatcher.CheckAccess())
            {
                Trace.WriteLine("ExecuteRefreshPreviewCommand calling Dispatcher.Invoke");
                //' This event generally enters on another thread than the main one
                //' For user-interface related actions, this function should be called on the main thread
                Dispatcher.BeginInvoke(new Action(delegate ()
                {
                    ExecuteRefreshPreviewCommand(obj);
                }));

                Trace.WriteLine("ExecuteRefreshPreviewCommand Dispatcher.Invoke called");
            }
            else
            {
                Trace.WriteLine("ExecuteRefreshPreviewCommand");
                int intJobID;
                string strShortDescription;
                Messages = string.Empty;

                Cursor = Cursors.Wait;

                try
                {
                    // Make sure that values have been entered for the layout name and the key value
                    if (BadgeLayoutName == String.Empty)
                    {
                        Trace.WriteLine("BadgeLayoutName == String.Empty");
                        if (DisplayErrorMessages == true)
                            MessageBox.Show(Properties.Resources.NoLayoutSpecified, Properties.Resources.ErrorHeader);
                        if (ThrowExceptions == true)
                            throw new Exception(Properties.Resources.NoLayoutSpecified);
                    }
                    else if (UniqueId == String.Empty)
                    {
                        Trace.WriteLine("UniqueId == String.Empty");
                        if (DisplayErrorMessages == true)
                            MessageBox.Show(Properties.Resources.NoKeySpecified, Properties.Resources.ErrorHeader);
                        if (ThrowExceptions == true)
                            throw new Exception(Properties.Resources.NoKeySpecified);
                    }
                    else
                    {
                        Trace.WriteLine("EnableSystemMenuCloseX(false)");
                        EnableSystemMenuCloseX(false);
                        Trace.WriteLine("EnablePrintAndPreviewBtns(false)");
                        EnablePrintAndPreviewBtns(false);
                        // If so, generate a descriptive text for the preview request ...
                        strShortDescription = String.Format("{0}[{1}]", BadgeLayoutName, UniqueId);

                        Trace.WriteLine("m_objPrintServer.GetPreview");
                        // and request the preview
                        intJobID = m_objPrintServer.GetPreview(UniqueId, BadgeLayoutName, null, null, strShortDescription, m_objClient);
                    }
                }
                catch (Exception ex)
                {
                    string strMessage = ex.Message;

                    while (ex.InnerException != null)
                    {
                        ex = ex.InnerException;
                        strMessage += string.Format("\n{0}", ex.Message);
                    }

                    if (DisplayErrorMessages == true)
                    {
                        RadWindow.Alert(new DialogParameters()
                        {
                            Content = strMessage,
                            Header = Properties.Resources.GenericError,
                        });
                    }
                    Messages = strMessage;

                    EnableSystemMenuCloseX(true);
                    EnablePrintAndPreviewBtns(true);
                }
                finally
                {
                    Cursor = Cursors.Arrow;
                }

            }
        }

        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool DeleteObject(IntPtr value);

        public static BitmapSource GetImageStream(System.Drawing.Image myImage)
        {
            if (myImage == null)
                return null;

            var bitmap = new Bitmap(myImage);
            IntPtr bmpPt = bitmap.GetHbitmap();
            BitmapSource bitmapSource =
                System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                    bmpPt,
                    IntPtr.Zero,
                    Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions());

            //freeze bitmapSource and clear memory to avoid memory leaks
            bitmapSource.Freeze();
            DeleteObject(bmpPt);

            return bitmapSource;
        }

        #region "Client event handlers "

        private void m_objClient_JobStatusChanged(object sender, CardExchangeRemotable.JobStatusEventArgs e)
        {
            PrintJob objPrintJob = m_objClient.get_PrintJob(e.JobID);

            //if( !Dispatcher.CheckAccess() == false )
            //    SetPrintAndPreviewBtnsVisibility(true);

            // This event catches all status changes of the current print jobs and preview requests
            // Here, for any completed preview request the resulting preview is shown in the picture box
            if (objPrintJob.JobType == JobType.Preview)//&& objPrintJob.JobStatus == JobStatus.Executed)
            {

                if (!Dispatcher.CheckAccess())
                {
                    Trace.WriteLine("m_objClient_JobStatusChanged calling Dispatcher.Invoke");
                    //' This event generally enters on another thread than the main one
                    //' For user-interface related actions, this function should be called on the main thread
                    Dispatcher.BeginInvoke(new JobStatusEventDelegate(ref m_objClient_JobStatusChanged), new Object[] { sender, e });
                    Trace.WriteLine("m_objClient_JobStatusChanged Dispatcher.Invoke called");
                }
                else
                {
                    Trace.WriteLine(string.Format("m_objClient_JobStatusChanged: {0}", objPrintJob.JobStatus));
                    if (objPrintJob.JobStatus == JobStatus.Executed)
                    {
                        //Trace.WriteLine($"PreviewFront:{objPrintJob.PreviewFront}, PreviewBack:{objPrintJob.PreviewBack}");
                        imgPreview.Source = GetImageStream(objPrintJob.PreviewFront);
                        imgPreviewBack.Source = GetImageStream(objPrintJob.PreviewBack);

                        //Trace.WriteLine(string.Format("imgPreview.Source Height: {0}", imgPreview.Source.Height));
                        //Trace.WriteLine(string.Format("imgPreviewBack.Source Height: {0}", imgPreviewBack.Source.Height));
                    }

                    StatusMessage = objPrintJob.JobStatus.ToString();

                    switch (objPrintJob.JobStatus)
                    {
                        case JobStatus.Aborted:
                        case JobStatus.Canceled:
                        case JobStatus.ExceptionThrown:
                        case JobStatus.Rejected:
                            EnableSystemMenuCloseX(true);
                            EnablePrintAndPreviewBtns(true);
                            if (AutoClose == true)
                            {
                                timer1.Interval = 1000;
                                timer1.Enabled = true;
                            }
                            break;

                        case JobStatus.Executed:
                            if (AutoPrint == true)
                            {
                                timer1.Enabled = true;
                            }
                            else
                            {
                                EnableSystemMenuCloseX(true);
                                EnablePrintAndPreviewBtns(true);
                                if (AutoClose == true)
                                {
                                    timer1.Interval = 1000;
                                    timer1.Enabled = true;
                                }
                            }
                            break;

                        default:
                            break;
                    }
                }
            }
            else if (objPrintJob.JobType == JobType.PrintJob)// && objPrintJob.JobStatus == JobStatus.Executed)
            {
                if (!Dispatcher.CheckAccess())
                {
                    //' This event generally enters on another thread than the main one
                    //' For user-interface related actions, this function should be called on the main thread
                    Dispatcher.BeginInvoke(new JobStatusEventDelegate(ref m_objClient_JobStatusChanged), new Object[] { sender, e });
                }
                else
                {
                    //' Show the preview in the picture box
                    StatusMessage = objPrintJob.JobStatus.ToString();

                    if (objPrintJob.JobStatus == JobStatus.Executed)
                    {
                        PrintCount++;

                        Messages = Properties.Resources.BadgePrinted;

                        if (AutoClose == true)
                        {
                            timer1.Interval = 1000;
                            timer1.Enabled = true;
                        }
                        //else
                        //    MessageBox.Show(Properties.Resources.BadgePrinted, Properties.Resources.GenericHeader);
                    }
                    switch (objPrintJob.JobStatus)
                    {
                        case JobStatus.Aborted:
                        case JobStatus.Canceled:
                        case JobStatus.ExceptionThrown:
                        case JobStatus.Executed:
                        case JobStatus.Rejected:
                            EnableSystemMenuCloseX(true);
                            EnablePrintAndPreviewBtns(true);
                            break;

                        default:
                            break;
                    }
                }
            }


        }

        private void m_objClient_JobErrorReported(Object sender, JobErrorEventArgs e)
        {
            PrintJob objPrintJob;

            // This event catches all errors that occur in the current print jobs and preview requests
            // In this example, the error message is shown in a message box
            if (!Dispatcher.CheckAccess())
            {
                // This event generally enters on another thread than the main one
                // For user-interface related actions, this function should be called on the main thread
                Dispatcher.BeginInvoke(new JobErrorEventDelegate(ref m_objClient_JobErrorReported), new Object[] { sender, e });
            }
            else
            {
                // Retrieve the print-job info from the client object
                objPrintJob = m_objClient.get_PrintJob(e.JobID);

                // Show an error message
                Messages = String.Format(Properties.Resources.ErrorInJob + "{0}\n{1}", objPrintJob.ShortDescription, e.Message);
                if (DisplayErrorMessages == true)
                    RadWindow.Alert(new DialogParameters()
                    {
                        Content = Messages,
                        Header = Properties.Resources.GenericError,
                    });
                // Tell the print server not to halt the execution
                e.Action = JobErrorAction.Continue;
                EnableSystemMenuCloseX(true);
                EnablePrintAndPreviewBtns(true);
            }

        }

        #endregion

        private void EnableSystemMenuCloseX(bool bEnable)
        {
            var window = this.ParentOfType<RadWindow>();
            window.CanClose = bEnable;
            //IntPtr hMenu = GetSystemMenu(this.Handle, false);
            //int menuItemCount = GetMenuItemCount(hMenu);
            //if (bEnable == false)
            //    EnableMenuItem(hMenu, menuItemCount - 1, MF_BYPOSITION | MF_DISABLED | MF_GRAYED);
            //else
            //    EnableMenuItem(hMenu, menuItemCount - 1, MF_BYPOSITION | MF_ENABLED);

            //btnClose.Enabled = bEnable;

            //Hide();
            //Show();
            //BringToFront();
        }

        private void EnablePrintAndPreviewBtns(bool bEnable)
        {
            EnablePrint = bEnable;
            EnableRefresh = bEnable;
        }

    }
}

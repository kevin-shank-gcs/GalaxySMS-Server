using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using DSREventViewer;
using GCS.AssaAbloyDSR;

namespace GCS.AssaAbloyTestApp
{
    internal static class Program
    {
        public static ServiceHost MyServiceHost;
 //       public static DsrCallbackService _callbackService;

        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            string callbackUrl = "http://192.168.19.10:9091/callback";
            try
            {
                Application.ApplicationExit += Application_ApplicationExit;
                MyServiceHost = new ServiceHost(typeof(DsrCallbackInterfaceImpl));
                var httpBinding = new BasicHttpBinding();
                httpBinding.Security.Mode = BasicHttpSecurityMode.None;

                var customHttpBinding = new CustomBinding();
                customHttpBinding.Elements.Add(new TextMessageEncodingBindingElement(MessageVersion.Soap12, Encoding.UTF8));
                customHttpBinding.Elements.Add(new HttpTransportBindingElement());
                var ep = MyServiceHost.AddServiceEndpoint(typeof(DsrCallbackInterface),
                    customHttpBinding, new Uri(callbackUrl));

                MyServiceHost.Description.Behaviors.Remove(typeof(ServiceDebugBehavior));
                MyServiceHost.Description.Behaviors.Add(new ServiceDebugBehavior() { IncludeExceptionDetailInFaults = true });
                try
                {
                    MyServiceHost.Open();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }


        //private static void Main()
        //{
        //    try
        //    {
        //        Application.ApplicationExit += Application_ApplicationExit;
        //        _callbackService = new DsrCallbackService();

        //        _callbackService.Start();

        //        Application.EnableVisualStyles();
        //        Application.SetCompatibleTextRenderingDefault(false);
        //        Application.Run(new MainForm());
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //    }
        //}

        private static void Application_ApplicationExit(
            object sender, EventArgs e)
        {
            if (MyServiceHost != null)
            {
                MyServiceHost.Close();
                MyServiceHost = null;
            }
        }

    //    private static void Application_ApplicationExit(
    //object sender, EventArgs e)
    //    {
    //        if (_callbackService != null)
    //        {
    //            _callbackService.Stop();
    //            _callbackService = null;
    //        }
    //    }
    }
}
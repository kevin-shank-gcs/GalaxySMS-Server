using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Framework.Badging.IdProducer.Entities
{
    //public class PrinterData
    //{
    //    public int ID { get; set; }
    //    public int SubscriptionID { get; set; }
    //    public int PrintDispatcherID { get; set; }
    //    public string LocalPrinterName { get; set; }
    //    public string PaperSizeName { get; set; }
    //    public int PrinterProfileID { get; set; }
    //    public int Resolution { get; set; }
    //    public int Orientation { get; set; }
    //    public bool SimulatePrinting { get; set; }
    //    public bool SavePreviewToFile { get; set; }
    //    public bool UsePrinterEncoder { get; set; }
    //    public bool UsePrinterControl { get; set; }
    //    public int FrontRotate { get; set; }
    //    public int FrontRenderingMode { get; set; }
    //    public int FrontNudgeX { get; set; }
    //    public int FrontNudgeY { get; set; }
    //    public int BackRotate { get; set; }
    //    public int BackRenderingMode { get; set; }
    //    public int BackNudgeX { get; set; }
    //    public int BackNudgeY { get; set; }
    //    public int PageFit { get; set; }
    //    public string FriendlyName { get; set; }
    //    public object SmartCardReader { get; set; }
    //    public bool IsQueuedDefault { get; set; }
    //    public bool IsActive { get; set; }
    //    public bool IsOnline { get; set; }
    //}

    public class PrintersResponse
    {
        public Printer[] Printers { get; set; }
        public bool IsSuccessful { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorCodeStr { get; set; }
        public string ErrorMessage { get; set; }
        public string UserWhoMadeCall { get; set; }
    }

  
}

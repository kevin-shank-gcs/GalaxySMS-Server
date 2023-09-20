using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Business.Managers
{
    public class IdProducerSettings
    {
        public string Url { get; set; }
        public string DevUrl { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool FailIfPrintDispatcherStopped { get; set; }
        public int DefaultSubscriptionId { get; set; }
        public string WebClientUrl { get; set; }
        public bool AlwaysUseRootSubscription { get; set; }
        public string SignalRUrl { get; set; }  

    }
}

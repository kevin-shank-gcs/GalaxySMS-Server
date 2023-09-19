using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Logger;
using GCS.PanelDataProcessors.Interfaces;
using GCS.PanelOutputDataHandlers;
using System.Threading;

namespace GCS.PanelDataHandlers
{
    public class PanelOutputDataProcessor : IPanelOutputDataProcessor
    {
        private CancellationTokenSource _cancellationTokenSource;
        private CancellationToken _cancellationToken;
        public void ProcessData(System.Collections.Concurrent.BlockingCollection<object> queue)
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _cancellationToken = _cancellationTokenSource.Token;

            Task task = new Task(() =>
            {
                //System.Diagnostics.Trace.WriteLine(string.Format("*** {0}: PanelOutputDataProcessor Task starting", DateTimeOffset.Now.ToString()));
                this.Log().DebugFormat("*** {0}: PanelOutputDataProcessor Task starting", DateTimeOffset.Now.ToString());
                IPanelOutputDataMessageHandler recorder = new PanelOutputDataMessageHandler();
                foreach (var workItem in queue.GetConsumingEnumerable())
                {
                    //_cancellationToken.ThrowIfCancellationRequested();
                    if (_cancellationToken.IsCancellationRequested)
                    {
//                        GCS.Framework.Logging.LogWriter.LogDebugInformation("PanelOutputDataProcessor cancellation requested");
                        this.Log().DebugFormat("PanelOutputDataProcessor cancellation requested");
                        throw new OperationCanceledException(_cancellationToken);
                    }

                    recorder.HandleMessage(workItem);
                    //this.Log().DebugFormat("*** {0}: PanelOutputDataProcessor Processing message: {1}, Queue Count:{2}", DateTimeOffset.Now.ToString(), workItem.GetType().ToString(), queue.Count);

                }
                //System.Diagnostics.Trace.WriteLine(string.Format("*** {0}: PanelOutputDataProcessor Task ending", DateTimeOffset.Now.ToString()));
                this.Log().DebugFormat("*** {0}: PanelOutputDataProcessor Task ending", DateTimeOffset.Now.ToString());
            }, _cancellationToken, TaskCreationOptions.LongRunning);
            task.Start();
        }



        public void StopProcessor()
        {
            if (_cancellationTokenSource != null)
                _cancellationTokenSource.Cancel();
        }
    }
}

using GCS.Core.Common.Logger;
using GCS.PanelDataProcessors.Interfaces;
using GCS.PanelOutputDataHandlers;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GCS.PanelDataHandlers
{
    public class MercPanelOutputDataProcessor : IPanelOutputDataProcessor
    {
        private CancellationTokenSource _cancellationTokenSource;
        private CancellationToken _cancellationToken;
        public SystemType SystemType { get; private set; } = PanelDataProcessors.Interfaces.SystemType.Mercury;

        public MercPanelOutputDataProcessor()
        {
        }

        public void ProcessData(System.Collections.Concurrent.BlockingCollection<object> queue)
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _cancellationToken = _cancellationTokenSource.Token;

#if NETFRAMEWORK
            Task task = new Task(() =>
            {
                this.Log().DebugFormat("*** {0}: MercPanelOutputDataProcessor Task starting", DateTimeOffset.Now.ToString());
                IPanelOutputDataMessageHandler recorder = new MercPanelOutputDataMessageHandler();
                foreach (var workItem in queue.GetConsumingEnumerable())
                {
                    //_cancellationToken.ThrowIfCancellationRequested();
                    if (_cancellationToken.IsCancellationRequested)
                    {
                        this.Log().DebugFormat("MercPanelOutputDataProcessor cancellation requested");
                        throw new OperationCanceledException(_cancellationToken);
                    }

                    recorder.HandleMessage(workItem);
                    //this.Log().DebugFormat("*** {0}: MercPanelOutputDataProcessor Processing message: {1}, Queue Count:{2}", DateTimeOffset.Now.ToString(), workItem.GetType().ToString(), queue.Count);

                }
                this.Log().DebugFormat("*** {0}: MercPanelOutputDataProcessor Task ending", DateTimeOffset.Now.ToString());
            }, _cancellationToken, TaskCreationOptions.LongRunning);
            task.Start();
#elif NETCOREAPP
            Task task = new Task(() =>
            {
//                this.Log().DebugFormat("*** {0}: MercPanelOutputDataProcessor Task starting", DateTimeOffset.Now.ToString());
                IPanelOutputDataMessageHandler recorder = new MercPanelOutputDataMessageHandler();
                foreach (var workItem in queue.GetConsumingEnumerable())
                {
                    //_cancellationToken.ThrowIfCancellationRequested();
                    if (_cancellationToken.IsCancellationRequested)
                    {
                        //this.Log().DebugFormat("MercPanelOutputDataProcessor cancellation requested");
                        throw new OperationCanceledException(_cancellationToken);
                    }

                    recorder.HandleMessage(workItem);
                    //this.Log().DebugFormat("*** {0}: MercPanelOutputDataProcessor Processing message: {1}, Queue Count:{2}", DateTimeOffset.Now.ToString(), workItem.GetType().ToString(), queue.Count);

                }
                //this.Log().DebugFormat("*** {0}: MercPanelOutputDataProcessor Task ending", DateTimeOffset.Now.ToString());
            }, _cancellationToken, TaskCreationOptions.LongRunning);
            task.Start();
#endif
        }

        public async Task ProcessDataAsync(System.Collections.Concurrent.BlockingCollection<object> queue)
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _cancellationToken = _cancellationTokenSource.Token;

#if NETFRAMEWORK
            Task task = new Task(async () =>
           {
               this.Log().DebugFormat("*** {0}: MercPanelOutputDataProcessor Task starting", DateTimeOffset.Now.ToString());
               IPanelOutputDataMessageHandler recorder = new MercPanelOutputDataMessageHandler();
               foreach (var workItem in queue.GetConsumingEnumerable())
               {
                    //_cancellationToken.ThrowIfCancellationRequested();
                    if (_cancellationToken.IsCancellationRequested)
                   {
                       this.Log().DebugFormat("MercPanelOutputDataProcessor cancellation requested");
                       throw new OperationCanceledException(_cancellationToken);
                   }

                   await recorder.HandleMessageAsync(workItem);
                    //this.Log().DebugFormat("*** {0}: MercPanelOutputDataProcessor Processing message: {1}, Queue Count:{2}", DateTimeOffset.Now.ToString(), workItem.GetType().ToString(), queue.Count);

                }
               this.Log().DebugFormat("*** {0}: MercPanelOutputDataProcessor Task ending", DateTimeOffset.Now.ToString());
           }, _cancellationToken, TaskCreationOptions.LongRunning);
            task.Start();
#elif NETCOREAPP
            Task task = new Task(async() =>
            {
                //this.Log().DebugFormat("*** {0}: MercPanelOutputDataProcessor Task starting", DateTimeOffset.Now.ToString());
                IPanelOutputDataMessageHandler recorder = new MercPanelOutputDataMessageHandler();
                foreach (var workItem in queue.GetConsumingEnumerable())
                {
                    //_cancellationToken.ThrowIfCancellationRequested();
                    if (_cancellationToken.IsCancellationRequested)
                    {
                        //this.Log().DebugFormat("MercPanelOutputDataProcessor cancellation requested");
                        throw new OperationCanceledException(_cancellationToken);
                    }

                    await recorder.HandleMessageAsync(workItem);
                    //this.Log().DebugFormat("*** {0}: MercPanelOutputDataProcessor Processing message: {1}, Queue Count:{2}", DateTimeOffset.Now.ToString(), workItem.GetType().ToString(), queue.Count);

                }
                //this.Log().DebugFormat("*** {0}: MercPanelOutputDataProcessor Task ending", DateTimeOffset.Now.ToString());
            }, _cancellationToken, TaskCreationOptions.LongRunning);
            task.Start();
#endif
        }


        public void StopProcessor()
        {
            if (_cancellationTokenSource != null)
                _cancellationTokenSource.Cancel();
        }
    }
}

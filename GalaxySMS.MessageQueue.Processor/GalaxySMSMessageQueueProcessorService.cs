using GCS.Core.Common.Contracts;
using GCS.Core.Common.Logger;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Reflection;
using GalaxySMS.Client.SDK.Managers;
#if UseSerilog
using Serilog;
#else
using log4net;
#endif

namespace GalaxySMS.MessageQueue.Processor
{
    public partial class GalaxySMSMessageQueueProcessorService : ServiceBase
    {
        GCS.Core.Common.Contracts.ILogger _logger = null;
        public QueueListener QListener { get; internal set; }
        public GalaxySMSMessageQueueProcessorService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            _logger = LogManager.GetLogger<GalaxySMSMessageQueueProcessorService>();
            this.Log().Info($"GalaxySMS.MessageQueue.Processor starting; args:{args}");
            var queueName = string.Empty;
            if (args != null)
            {
                int argX = 0;
                var strQueueNameParam = "-listenOnQueueName:";
                foreach (var arg in args)
                {
                    if( arg.StartsWith(strQueueNameParam))
                    {
                        queueName = arg.Substring(strQueueNameParam.Length);
                    }
                    this.Log().Info($"args[{argX}]:{arg}");
                    argX++;
                }
            }

            var catalog = new List<ComposablePartCatalog>()
            {
                new AssemblyCatalog(Assembly.GetExecutingAssembly())
            };
            var uiAssembly = typeof(EntityManager).Assembly;
            catalog.Add(new AssemblyCatalog(uiAssembly));

            //            ObjectBase.Container = MEFLoader.Init(catalog);
            StaticObjects.Container = MEFLoader.Init(catalog);


            QListener = new QueueListener();
            QListener.Start(queueName);
            this.Log().Info($"GalaxySMS.MessageQueue.Processor started");
        }

        protected override void OnStop()
        {
            this.Log().Info($"GalaxySMS.MessageQueue.Processor stopping");
            if (QListener != null)
                QListener.Stop();
            this.Log().Info($"GalaxySMS.MessageQueue.Processor stopped");
            Log.CloseAndFlush();
        }
    }
}

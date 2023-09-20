using System;
using System.Threading.Tasks;
using GalaxySMS.Business.Entities;
#if NETFRAMEWORK
#if SignalRCore
using GalaxySMS.Client.SDK.Managers;
using GalaxySMS.MessageQueue.Integration2;
using GCS.Core.Common.Utils;
using BusinessEntitiesStd = GalaxySMS.Business.Entities.NetStd2;
using AutoMapper;
#else
using GalaxySMS.Business.SignalR;
using GalaxySMS.Client.SDK.Managers;
#endif
#elif NETCOREAPP
#endif
using GalaxySMS.Common.Enums;

using GalaxySMS.MessageQueue.Integration.Workflows.Spec;
using GCS.Core.Common.Logger;

namespace GalaxySMS.MessageQueue.Integration.Workflows
{
    public class GalaxyJobWorkflow : IPanelMessageWorkflow
    {
#if NETFRAMEWORK
#if SignalRCore
        public SignalRCore.SignalRClient SignalRClient { get; set; }
        public IMapper Mapper { get; internal set; }

        public GalaxyJobWorkflow()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });

            Mapper = configuration.CreateMapper();
        }

#else
        public SignalRClient SignalRClient { get; set; }
#endif
#elif NETCOREAPP
#endif
        public object Data { get; set; }

        public async void Run()
        {
            var msg = string.Empty;
            if (Data != null)
            {
                var t = Data.GetType();
                msg = t.ToString();
                var logString = $"{DateTimeOffset.Now.TimeOfDay} GalaxyJobWorkflow processing message: {msg}";
                //this.Log().InfoFormat( logString);
#if NETFRAMEWORK
                try
                {
                    if (t == typeof(SaveJobParameters<gcsEntity>))
                    {
                        if (Data is SaveJobParameters<gcsEntity> jobParameters)
                        {
                            // Make call to WCF service to save gcsEntity
                            var mgr = MyHelpers.GetManager<EntityManager>(jobParameters.UserSessionData);
                            var result = await mgr.SaveEntityAsync(jobParameters.SaveParameters);
                            var jobMgr = MyHelpers.GetManager<BackgroundJobManager>(jobParameters.UserSessionData);
                            if (mgr.HasErrors)
                            {
                                // save BackgroundJobState of Aborted with info
                                await jobMgr.SaveBackgroundJobStateAsync(jobParameters.JobId,
                                    BackgroundJobState.Aborted, mgr.GetErrorsString());
                            }
                            if (SignalRClient != null)
                            {
#if SignalRCore
                                var jobInfo = await jobMgr.GetBackgroundJobAsync(new GetParametersWithPhoto()
                                    {UniqueId = jobParameters.JobId});
                                SignalRClient.NotifyBackgroundJobInfoAsync(
                                    Mapper.Map<BusinessEntitiesStd.BackgroundJobInfo>(jobInfo));
#else
                                var jobInfo = await jobMgr.GetBackgroundJobAsync(new GetParametersWithPhoto()
                                    {UniqueId = jobParameters.JobId});
                                
                                SignalRClient.NotifyBackgroundJobInfoAsync(jobInfo);
#endif
                            }

                            logString +=
                                $"{Environment.NewLine}{jobParameters.SaveParameters.Data.EntityName}";
                        }
                    }
                    else if (t == typeof(SaveJobParameters<CommandParameters<ClusterDataLoadParameters>>))
                    {
                        if (Data is SaveJobParameters<CommandParameters<ClusterDataLoadParameters>> jobParameters)
                        {
                            // Make call to WCF service to save gcsEntity
                            var mgr = MyHelpers.GetManager<GalaxyPanelCommunicationManager>(jobParameters.UserSessionData);
                            var result = await mgr.SendClusterDataToPanelsAsync(jobParameters.SaveParameters.Data);
                            var jobMgr = MyHelpers.GetManager<BackgroundJobManager>(jobParameters.UserSessionData);
                            if (mgr.HasErrors)
                            {
                                // save BackgroundJobState of Aborted with info
                                await jobMgr.SaveBackgroundJobStateAsync(jobParameters.JobId,
                                    BackgroundJobState.Aborted, mgr.GetErrorsString());
                            }
                            if (SignalRClient != null)
                            {
#if SignalRCore
                                var jobInfo = await jobMgr.GetBackgroundJobAsync(new GetParametersWithPhoto()
                                    {UniqueId = jobParameters.JobId});
                                SignalRClient.NotifyBackgroundJobInfoAsync(
                                    Mapper.Map<BusinessEntitiesStd.BackgroundJobInfo>(jobInfo));
#else
                                var jobInfo = await jobMgr.GetBackgroundJobAsync(new GetParametersWithPhoto()
                                    { UniqueId = jobParameters.JobId });

                                SignalRClient.NotifyBackgroundJobInfoAsync(jobInfo);
#endif
                            }

                            logString +=
                                $"{Environment.NewLine}{jobParameters.SaveParameters.Data.Data.GalaxyPanelUid}";
                        }
                    }

                    this.Log().InfoFormat(logString);
                }
                catch (Exception e)
                {
                    this.Log().ErrorFormat(
                        $"{DateTimeOffset.Now.TimeOfDay} GalaxyJobWorkflow {Data.GetType()} error: {e}");
                }

#elif NETCOREAPP

#endif
            }
        }

        public async Task RunAsync()
        {

        }

        private void SendNotificationEvent()
        {
        }
    }
}
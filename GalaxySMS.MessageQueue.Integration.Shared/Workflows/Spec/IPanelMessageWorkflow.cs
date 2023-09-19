using System.Threading.Tasks;

#if NETFRAMEWORK
#if SignalRCore
#else
using GalaxySMS.Business.SignalR;
#endif
#elif NETCOREAPP
#endif

namespace GalaxySMS.MessageQueue.Integration.Workflows.Spec
{
    public interface IPanelMessageWorkflow
    {
#if NETFRAMEWORK
#if SignalRCore
        SignalRCore.SignalRClient SignalRClient { get; set; }
#else
        SignalRClient SignalRClient { get; set; }
#endif
#elif NETCOREAPP
#endif
        object Data { get; set; }
        void Run();

        //Task RunAsync();
    }
}

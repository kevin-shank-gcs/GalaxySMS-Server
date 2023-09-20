using System.Threading.Tasks;

namespace GalaxySMS.SignalRCore
{
    public interface ISignalRCoreClient
    {
        bool IsConnected { get; }
        Task Start();
    }
}

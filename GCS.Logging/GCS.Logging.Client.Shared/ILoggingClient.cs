using GCS.Logging.Shared;
using System.Threading.Tasks;

namespace GCS.Logging
{
    public interface ILoggingClient
    {
        Task WriteDiagnostic(LogDetail data);
        Task WriteError(LogDetail data);
        Task WriteInfo(LogDetail data);
        Task WritePerformance(LogDetail data);
        Task WriteUsage(LogDetail data);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Logging.Core
{
    //public class EnvironmentVariableNames
    //{
    //    public const string GCS_LOGFILE_PERF = "GCS_LOGFILE_PERF";
    //    public const string GCS_LOGFILE_USAGE = "GCS_LOGFILE_USAGE";
    //    public const string GCS_LOGFILE_ERROR = "GCS_LOGFILE_ERROR";
    //    public const string GCS_LOGFILE_DIAG = "GCS_LOGFILE_DIAG";
    //    public const string GCS_LOGFILE_INFO = "GCS_LOGFILE_INFO";
    //}
    public class LogTargets
    {
        public const string Files = "Files";
        public const string SqlServer = "SQLServer";
        public const string ElasticSearch = "ElasticSearch";
        public const string Api = "Api";
    }

}

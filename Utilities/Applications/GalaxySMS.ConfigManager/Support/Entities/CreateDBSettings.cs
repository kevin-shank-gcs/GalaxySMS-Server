using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.ConfigManager.Support.Entities
{
    public class CreateDBSettings : SqlInstanceData
    {
        public class SqlLoginInfo
        {
            public string LoginName { get; set; }
            public string LoginNameQualified
            {
                get
                {
                    if (IsWindowsLogin)
                        return $"{Environment.MachineName}\\{LoginName}";
                    return LoginName;
                }
            }
            public string Password { get; set; }
            public bool IsWindowsLogin { get; set; }
            public string DefaultDatabase { get; set; }

            public string SqlCreateLoginCmd
            {
                get
                {
                    var sql = string.Empty;
                    if (string.IsNullOrEmpty(LoginName) || (IsWindowsLogin == false && string.IsNullOrEmpty(Password)))
                        return sql;


                    if (IsWindowsLogin)
                    {
                        sql = $"CREATE LOGIN [{LoginNameQualified}] FROM WINDOWS";
                    }
                    else
                    {
                        sql = $"CREATE LOGIN [{LoginNameQualified}] WITH PASSWORD = '{Password}'";
                    }

                    if (!string.IsNullOrEmpty(DefaultDatabase))
                        sql += $", DEFAULT_DATABASE = {DefaultDatabase}";
                    return sql;
                }
            }

            public string SqlCreateUserCmd
            {
                get
                {
                    var sql = string.Empty;
                    if (string.IsNullOrEmpty(LoginName) || (IsWindowsLogin == false && string.IsNullOrEmpty(Password)))
                        return sql;

                    sql = $"CREATE USER [{LoginNameQualified}] FOR LOGIN [{LoginNameQualified}] WITH DEFAULT_SCHEMA=[GCS];";
                    sql += $"ALTER ROLE [db_datareader] ADD MEMBER [{LoginNameQualified}];";
                    sql += $"ALTER ROLE [db_datawriter] ADD MEMBER [{LoginNameQualified}];";
                    sql += $"ALTER ROLE [db_backupoperator] ADD MEMBER [{LoginNameQualified}];";
                    return sql;
                }
            }

            public string SqlLoginExistsCmd
            {
                get
                {
                    var sql = string.Empty;
                    if (string.IsNullOrEmpty(LoginName) || (IsWindowsLogin == false && string.IsNullOrEmpty(Password)))
                        return sql;

                    if (IsWindowsLogin)
                        sql = $"SELECT COUNT(*) FROM sys.server_principals where type = 'U' and name='{LoginNameQualified}'";
                    else
                        sql = $"SELECT COUNT(*) FROM sys.server_principals where type = 'S' and name='{LoginNameQualified}'";

                    return sql;
                }
            }
        }

        public enum DBNames
        {
            GalaxySMS,
            GalaxySMS_AuditActivity,
            GalaxySMS_Logging,
            GalaxySMS_Hangfire
        }

        public static string ToDatabaseName( DBNames o)
        {
            return o.ToString().Replace('_', '-');
        }

        public enum SizeType
        {
            KB,
            MB,
            GB,
            TB
        }

        public enum MaxSizeType
        {
            KB,
            MB,
            GB,
            TB,
            UNLIMITED
        }

        public enum GrowthType
        {
            KB,
            MB,
            GB,
            TB,
            Percent
        }

        public CreateDBSettings() : base()
        {
            Init();
        }

        public CreateDBSettings(SqlInstanceData o) : base(o)
        {
            Init();
        }

        private void Init()
        {
            DataFileSize = 64;
            DataFileSizeMagnitude = SizeType.MB;
            DataFileMaxSize = 0;
            DataFileMaxSizeMagnitude = MaxSizeType.UNLIMITED;
            DataFileGrowth = 10;
            DataFileGrowthMagnitude = GrowthType.Percent;

            LogFileSize = 64;
            LogFileSizeMagnitude = SizeType.MB;
            LogFileMaxSize = 0;
            LogFileMaxSizeMagnitude = MaxSizeType.UNLIMITED;
            LogFileGrowth = 10;
            LogFileGrowthMagnitude = GrowthType.Percent;

            SqlLogins = new List<SqlLoginInfo>();
            Scripts = new List<string>();
        }

        public string DatabaseName { get; set; }
        public uint DataFileSize { get; set; }
        public SizeType DataFileSizeMagnitude { get; set; }
        public uint DataFileMaxSize { get; set; }
        public MaxSizeType DataFileMaxSizeMagnitude { get; set; }
        public uint DataFileGrowth { get; set; }
        public GrowthType DataFileGrowthMagnitude { get; set; }
        public uint LogFileSize { get; set; }
        public SizeType LogFileSizeMagnitude { get; set; }
        public uint LogFileMaxSize { get; set; }
        public MaxSizeType LogFileMaxSizeMagnitude { get; set; }
        public uint LogFileGrowth { get; set; }
        public GrowthType LogFileGrowthMagnitude { get; set; }

        public bool AddFileStreamGroup { get; set; }

        public string DataFileSizeString
        {
            get
            {
                if (DataFileSize == 0)
                    return "65536KB";

                return $"{DataFileSize}{DataFileSizeMagnitude.ToString()}";
            }
        }

        public string DataFileMaxSizeString
        {
            get
            {
                if (DataFileMaxSize == 0 || DataFileMaxSizeMagnitude == MaxSizeType.UNLIMITED)
                    return MaxSizeType.UNLIMITED.ToString();

                return $"{DataFileMaxSize}{DataFileMaxSizeMagnitude.ToString()}";
            }
        }

        public string DataFileGrowthString
        {
            get
            {
                if (DataFileGrowth == 0)
                    return "65536KB";
                if (DataFileGrowthMagnitude == GrowthType.Percent)
                    return $"{DataFileGrowth}%";
                return $"{DataFileGrowth}{DataFileGrowthMagnitude.ToString()}";

            }
        }

        public string LogFileSizeString
        {
            get
            {
                if (LogFileSize == 0)
                    return "65536KB";

                return $"{LogFileSize}{LogFileSizeMagnitude.ToString()}";
            }
        }

        public string LogFileMaxSizeString
        {
            get
            {
                if (LogFileMaxSize == 0 || LogFileMaxSizeMagnitude == MaxSizeType.UNLIMITED)
                    return MaxSizeType.UNLIMITED.ToString();

                return $"{LogFileMaxSize}{LogFileMaxSizeMagnitude}";
            }
        }

        public string LogFileGrowthString
        {
            get
            {
                if (LogFileGrowth == 0)
                    return "65536KB";
                if (LogFileGrowthMagnitude == GrowthType.Percent)
                    return $"{LogFileGrowth}%";

                return $"{LogFileGrowth}{LogFileGrowthMagnitude}";

            }
        }

        public string SQLCmd
        {
            get
            {
                if (AddFileStreamGroup == false)
                    return $"CREATE DATABASE [{DatabaseName}] CONTAINMENT = NONE ON PRIMARY ( NAME = N'{DatabaseName}', FILENAME = N'{DataFilePath}{DatabaseName}.mdf', SIZE = {DataFileSizeString}, MAXSIZE = {DataFileMaxSizeString}, FILEGROWTH = {DataFileGrowthString} ) LOG ON ( NAME = N'{DatabaseName}_log', FILENAME = N'{LogFilePath}{DatabaseName}_log.ldf', SIZE = {LogFileSizeString} , MAXSIZE = {LogFileMaxSizeString} , FILEGROWTH = {LogFileGrowthString} )";

                return $"CREATE DATABASE [{DatabaseName}] CONTAINMENT = NONE ON PRIMARY ( NAME = N'{DatabaseName}', FILENAME = N'{DataFilePath}{DatabaseName}.mdf', SIZE = {DataFileSizeString}, MAXSIZE = {DataFileMaxSizeString}, FILEGROWTH = {DataFileGrowthString} ), FILEGROUP {DatabaseName}FileStreamFileGroup1 CONTAINS FILESTREAM( NAME = {DatabaseName}FileStream, FILENAME = N'{DataFilePath}{DatabaseName}FileStream') LOG ON ( NAME = N'{DatabaseName}_log', FILENAME = N'{LogFilePath}{DatabaseName}_log.ldf', SIZE = {LogFileSizeString} , MAXSIZE = {LogFileMaxSizeString} , FILEGROWTH = {LogFileGrowthString} )";
            }
        }

        public string CreateScriptFilename { get; set; }
        public string OutputFilename { get; set; }
        public List<SqlLoginInfo> SqlLogins { get; set; }
        public List<string> Scripts { get; set; }


    }
}

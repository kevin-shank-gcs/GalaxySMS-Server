using Serilog;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using GCS.Logging.Shared;
using Serilog.Events;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using Microsoft.Extensions.Configuration;
using Serilog.Sinks.MSSqlServer;
using Serilog.Sinks.MSSqlServer.Sinks.MSSqlServer.Options;

namespace GCS.Logging.Core
{
    //https://app.pluralsight.com/course-player?clipId=94b6931e-cd2b-4a2f-87fd-81a3fa4e17d4

    public static class Logger
    {
        private static readonly ILogger _perfLogger;
        private static readonly ILogger _usageLogger;
        private static readonly ILogger _errorLogger;
        private static readonly ILogger _diagnosticLogger;
        private static readonly ILogger _infoLogger;
        private static IConfigurationRoot configuration;

        static Logger()
        {
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", false)
                .Build();

            var logTarget = configuration["LogTarget"];
            if (logTarget == LogTargets.Files)
            {
                var fileLoggingEnabled = Convert.ToBoolean(configuration["FileLogger:Enabled"]);
                if (fileLoggingEnabled)
                {
                    var perfFilename = configuration["FileLogger:Logfiles:Performance"];
                    var maxFileSize = Convert.ToInt32(configuration["FileLogger:MaxSize"]);
                    var retainForDays = Convert.ToInt32(configuration["FileLogger:RetainForDays"]);
                    if (maxFileSize <= 0)
                        maxFileSize = 1024 * 1024;
                    if (retainForDays <= 0)
                        retainForDays = 15;

                    var perfDiagFilename = perfFilename + "-{Date}.txt";
                    _perfLogger = new LoggerConfiguration()
                        //.WriteTo.File(path: Environment.GetEnvironmentVariable(EnvironmentVariableNames.GCS_LOGFILE_PERF))
                        //.WriteTo.File(path: $"{perfFilename}.txt")
                        .WriteTo.File(perfDiagFilename, 
                            fileSizeLimitBytes:maxFileSize, 
                            retainedFileCountLimit:retainForDays,
                            shared:true)
                        .CreateLogger();

                    var usageFilename = configuration["FileLogger:Logfiles:Usage"];
                    var usageDiagFilename = usageFilename + "-{Date}.txt";
                    _usageLogger = new LoggerConfiguration()
                        //                .WriteTo.File(path: Environment.GetEnvironmentVariable(EnvironmentVariableNames.GCS_LOGFILE_USAGE))
                        //.WriteTo.File(path: $"{usageFilename}.txt")
                        .WriteTo.File(usageDiagFilename, 
                            fileSizeLimitBytes:maxFileSize, 
                            retainedFileCountLimit:retainForDays,
                            shared:true)
                        .CreateLogger();

                    var errorFilename = configuration["FileLogger:Logfiles:Error"];
                    var errorDiagFilename = errorFilename + "-{Date}.txt";
                    _errorLogger = new LoggerConfiguration()
                        //                .WriteTo.File(path: Environment.GetEnvironmentVariable(EnvironmentVariableNames.GCS_LOGFILE_ERROR))
                        //.WriteTo.File(path: $"{errorFilename}.txt")
                        .WriteTo.File(errorDiagFilename, 
                            fileSizeLimitBytes:maxFileSize, 
                            retainedFileCountLimit:retainForDays,
                            shared:true)
                        .CreateLogger();

                    var diagFilename = configuration["FileLogger:Logfiles:Diagnostic"];
                    var rollingDiagFilename = diagFilename + "-{Date}.txt";
                    _diagnosticLogger = new LoggerConfiguration()
                        //                .WriteTo.File(path: Environment.GetEnvironmentVariable(EnvironmentVariableNames.GCS_LOGFILE_DIAG))
                        //.WriteTo.File(path: $"{diagFilename}.txt")
                        .WriteTo.File(rollingDiagFilename, 
                            fileSizeLimitBytes:maxFileSize, 
                            retainedFileCountLimit:retainForDays,
                            shared:true)
                        .CreateLogger();

                    var infoFilename = configuration["FileLogger:Logfiles:Information"];
                    var rollingInfoFilename = infoFilename + "-{Date}.txt";
                    _infoLogger = new LoggerConfiguration()
                        //                .WriteTo.File(path: Environment.GetEnvironmentVariable(EnvironmentVariableNames.GCS_LOGFILE_INFO))
                        //.WriteTo.File(path: $"{infoFilename}.txt")
                        .WriteTo.File(rollingInfoFilename, 
                            fileSizeLimitBytes:maxFileSize, 
                            retainedFileCountLimit:retainForDays,
                            shared:true)
                        .CreateLogger();
                }
            }
            else if (logTarget == LogTargets.SqlServer)
            {
                var mssqlLoggingEnabled = Convert.ToBoolean(configuration["MSSQLLogger:Enabled"]);

                if (mssqlLoggingEnabled)
                {
                    var mssqlConnectionString = configuration["MSSQLLogger:ConnectionString"];
                    var batchPostingLimit = Convert.ToUInt16(configuration["MSSQLLogger:BatchPostingLimit"]);
                    var batchPeriod = Convert.ToInt32(configuration["MSSQLLogger:BatchPeriod"]);
                    _perfLogger = new LoggerConfiguration()
                        //.WriteTo.MSSqlServer(mssqlConnectionString, "PerfLogs", autoCreateSqlTable: true,
                        //    columnOptions: GetSqlColumnOptions(), batchPostingLimit: batchPostingLimit)
                        .WriteTo.MSSqlServer(connectionString:mssqlConnectionString, 
                            sinkOptions: new SinkOptions()
                            {
                                TableName = "PerfLogs",
                                AutoCreateSqlTable = true,
                                BatchPostingLimit = batchPostingLimit,
                                BatchPeriod = new TimeSpan(0, 0, 0, batchPeriod)
                            },
                            columnOptions: GetSqlColumnOptions())
                        .CreateLogger();

                    _usageLogger = new LoggerConfiguration()
                        //.WriteTo.MSSqlServer(mssqlConnectionString, "UsageLogs", autoCreateSqlTable: true,
                        //    columnOptions: GetSqlColumnOptions(), batchPostingLimit: batchPostingLimit)
                        .WriteTo.MSSqlServer(connectionString:mssqlConnectionString, 
                            sinkOptions: new SinkOptions()
                            {
                                TableName = "UsageLogs",
                                AutoCreateSqlTable = true,
                                BatchPostingLimit = batchPostingLimit,
                                BatchPeriod = new TimeSpan(0, 0, 0, batchPeriod)
                            },
                            columnOptions: GetSqlColumnOptions())
                        .CreateLogger();

                    _errorLogger = new LoggerConfiguration()
                        //.WriteTo.MSSqlServer(mssqlConnectionString, "ErrorLogs", autoCreateSqlTable: true,
                        //    columnOptions: GetSqlColumnOptions(), batchPostingLimit: batchPostingLimit)
                        .WriteTo.MSSqlServer(connectionString:mssqlConnectionString, 
                            sinkOptions: new SinkOptions()
                            {
                                TableName = "ErrorLogs",
                                AutoCreateSqlTable = true,
                                BatchPostingLimit = batchPostingLimit,
                                BatchPeriod = new TimeSpan(0, 0, 0, batchPeriod)
                            },
                            columnOptions: GetSqlColumnOptions())
                        .CreateLogger();

                    _diagnosticLogger = new LoggerConfiguration()
                        //.WriteTo.MSSqlServer(mssqlConnectionString, "DiagnosticLogs", autoCreateSqlTable: true,
                        //    columnOptions: GetSqlColumnOptions(), batchPostingLimit: batchPostingLimit)
                        .WriteTo.MSSqlServer(connectionString:mssqlConnectionString, 
                            sinkOptions: new SinkOptions()
                            {
                                TableName = "DiagnosticLogs",
                                AutoCreateSqlTable = true,
                                BatchPostingLimit = batchPostingLimit,
                                BatchPeriod = new TimeSpan(0, 0, 0, batchPeriod)
                            },
                            columnOptions: GetSqlColumnOptions())
                        .CreateLogger();

                    _infoLogger = new LoggerConfiguration()
                        //.WriteTo.MSSqlServer(mssqlConnectionString, "InformationLogs", autoCreateSqlTable: true,
                        //    columnOptions: GetSqlColumnOptions(), batchPostingLimit: batchPostingLimit)
                        .WriteTo.MSSqlServer(connectionString:mssqlConnectionString, 
                            sinkOptions: new SinkOptions()
                            {
                                TableName = "InformationLogs",
                                AutoCreateSqlTable = true,
                                BatchPostingLimit = batchPostingLimit,
                                BatchPeriod = new TimeSpan(0, 0, 0, batchPeriod)
                            },
                            columnOptions: GetSqlColumnOptions())
                        .CreateLogger();
                }

            }
            else if (logTarget == LogTargets.ElasticSearch)
            {
                var elasticSearchEnabled = Convert.ToBoolean(configuration["ElasticSearchLogger:Enabled"]);
                if (elasticSearchEnabled)
                {
                    var elasticSearchUrl = configuration["ElasticSearchLogger:Url"];
                    _perfLogger = new LoggerConfiguration()
                        .WriteTo.Elasticsearch(elasticSearchUrl,
                            indexFormat: "perf-{0:yyyy.MM.dd}",
                            inlineFields: true)
                        .CreateLogger();

                    _usageLogger = new LoggerConfiguration()
                        .WriteTo.Elasticsearch(elasticSearchUrl,
                            indexFormat: "usage-{0:yyyy.MM.dd}",
                            inlineFields: true)
                        .CreateLogger();

                    _errorLogger = new LoggerConfiguration()
                        .WriteTo.Elasticsearch(elasticSearchUrl,
                            indexFormat: "error-{0:yyyy.MM.dd}",
                            inlineFields: true)
                        .CreateLogger();

                    _diagnosticLogger = new LoggerConfiguration()
                        .WriteTo.Elasticsearch(elasticSearchUrl,
                            indexFormat: "diagnostic-{0:yyyy.MM.dd}",
                            inlineFields: true)
                        .CreateLogger();

                    _infoLogger = new LoggerConfiguration()
                        .WriteTo.Elasticsearch(elasticSearchUrl,
                            indexFormat: "info-{0:yyyy.MM.dd}",
                            inlineFields: true)
                        .CreateLogger();
                }

            }

            Serilog.Debugging.SelfLog.Enable(msg => Debug.WriteLine(msg));
        }

        public static void WritePerf(LogDetail infoToLog)
        {
            //            _perfLogger.Write(LogEventLevel.Information, "{@FlogDetail}", infoToLog);
            _perfLogger.Write(LogEventLevel.Information,
                "{Timestamp}{Message}{Layer}{Location}{Product}" +
                "{CustomException}{ElapsedMilliseconds}{Exception}{Hostname}" +
                "{UserId}{UserName}{CorrelationId}{AdditionalInfo}",
                infoToLog.Timestamp, infoToLog.Message,
                infoToLog.Layer, infoToLog.Location,
                infoToLog.Product, infoToLog.CustomException,
                infoToLog.ElapsedMilliseconds, infoToLog.Exception?.ToBetterString(),
                infoToLog.Hostname, infoToLog.UserId,
                infoToLog.UserName, infoToLog.CorrelationId,
                infoToLog.AdditionalInfo
            );
        }
        public static void WriteUsage(LogDetail infoToLog)
        {
            //            _usageLogger.Write(LogEventLevel.Information, "{@FlogDetail}", infoToLog);
            _usageLogger.Write(LogEventLevel.Information,
                "{Timestamp}{Message}{Layer}{Location}{Product}" +
                "{CustomException}{ElapsedMilliseconds}{Exception}{Hostname}" +
                "{UserId}{UserName}{CorrelationId}{AdditionalInfo}",
                infoToLog.Timestamp, infoToLog.Message,
                infoToLog.Layer, infoToLog.Location,
                infoToLog.Product, infoToLog.CustomException,
                infoToLog.ElapsedMilliseconds, infoToLog.Exception?.ToBetterString(),
                infoToLog.Hostname, infoToLog.UserId,
                infoToLog.UserName, infoToLog.CorrelationId,
                infoToLog.AdditionalInfo
            );
        }
        public static void WriteError(LogDetail infoToLog)
        {
            if (infoToLog.Exception != null)
            {
                var procName = FindProcName(infoToLog.Exception);
                infoToLog.Location = string.IsNullOrEmpty(procName) ? infoToLog.Location : procName;
                infoToLog.Message = GetMessageFromException(infoToLog.Exception);
            }
            //            _errorLogger.Write(LogEventLevel.Information, "{@FlogDetail}", infoToLog);            
            _errorLogger.Write(LogEventLevel.Information,
                "{Timestamp}{Message}{Layer}{Location}{Product}" +
                "{CustomException}{ElapsedMilliseconds}{Exception}{Hostname}" +
                "{UserId}{UserName}{CorrelationId}{AdditionalInfo}",
                infoToLog.Timestamp, infoToLog.Message,
                infoToLog.Layer, infoToLog.Location,
                infoToLog.Product, infoToLog.CustomException,
                infoToLog.ElapsedMilliseconds, infoToLog.Exception?.ToBetterString(),
                infoToLog.Hostname, infoToLog.UserId,
                infoToLog.UserName, infoToLog.CorrelationId,
                infoToLog.AdditionalInfo
            );
        }

        public static void WriteDiagnostic(LogDetail infoToLog)
        {
            var writeDiagnostics = Convert.ToBoolean(configuration["EnableDiagnostics"]);
            if (!writeDiagnostics)
                return;

            //            _diagnosticLogger.Write(LogEventLevel.Information, "{@FlogDetail}", infoToLog);
            _diagnosticLogger.Write(LogEventLevel.Information,
                "{Timestamp}{Message}{Layer}{Location}{Product}" +
                "{CustomException}{ElapsedMilliseconds}{Exception}{Hostname}" +
                "{UserId}{UserName}{CorrelationId}{AdditionalInfo}",
                infoToLog.Timestamp, infoToLog.Message,
                infoToLog.Layer, infoToLog.Location,
                infoToLog.Product, infoToLog.CustomException,
                infoToLog.ElapsedMilliseconds, infoToLog.Exception?.ToBetterString(),
                infoToLog.Hostname, infoToLog.UserId,
                infoToLog.UserName, infoToLog.CorrelationId,
                infoToLog.AdditionalInfo
            );
        }

        public static void WriteInfo(LogDetail infoToLog)
        {
            //_infoLogger.Write(LogEventLevel.Information, "{@FlogDetail}", infoToLog);
            _infoLogger.Write(LogEventLevel.Information,
                "{Timestamp}{Message}{Layer}{Location}{Product}" +
                "{CustomException}{ElapsedMilliseconds}{Exception}{Hostname}" +
                "{UserId}{UserName}{CorrelationId}{AdditionalInfo}",
                infoToLog.Timestamp, infoToLog.Message,
                infoToLog.Layer, infoToLog.Location,
                infoToLog.Product, infoToLog.CustomException,
                infoToLog.ElapsedMilliseconds, infoToLog.Exception?.ToBetterString(),
                infoToLog.Hostname, infoToLog.UserId,
                infoToLog.UserName, infoToLog.CorrelationId,
                infoToLog.AdditionalInfo
            );
        }

        private static string GetMessageFromException(Exception ex)
        {
            if (ex.InnerException != null)
                return GetMessageFromException(ex.InnerException);

            return ex.Message;
        }

        private static string FindProcName(Exception ex)
        {
            var sqlEx = ex as SqlException;
            if (sqlEx != null)
            {
                var procName = sqlEx.Procedure;
                if (!string.IsNullOrEmpty(procName))
                    return procName;
            }

            if (!string.IsNullOrEmpty((string)ex.Data["Procedure"]))
            {
                return (string)ex.Data["Procedure"];
            }

            if (ex.InnerException != null)
                return FindProcName(ex.InnerException);

            return null;
        }

        public static ColumnOptions GetSqlColumnOptions()
        {
            var colOptions = new ColumnOptions();
            colOptions.Store.Remove(StandardColumn.Properties);
            colOptions.Store.Remove(StandardColumn.MessageTemplate);
            colOptions.Store.Remove(StandardColumn.Message);
            colOptions.Store.Remove(StandardColumn.Exception);
            colOptions.Store.Remove(StandardColumn.TimeStamp);
            colOptions.Store.Remove(StandardColumn.Level);
            colOptions.AdditionalColumns = new List<SqlColumn>()            {
                new SqlColumn {DataType = SqlDbType.DateTimeOffset, ColumnName = "Timestamp"},
                new SqlColumn {DataType = SqlDbType.NVarChar, ColumnName = "Product"},
                new SqlColumn {DataType = SqlDbType.NVarChar, ColumnName = "Layer"},
                new SqlColumn {DataType = SqlDbType.NVarChar, ColumnName = "Location"},
                new SqlColumn {DataType = SqlDbType.NVarChar, ColumnName = "Message"},
                new SqlColumn {DataType = SqlDbType.NVarChar, ColumnName = "Hostname"},
                new SqlColumn {DataType = SqlDbType.NVarChar, ColumnName = "UserId"},
                new SqlColumn {DataType = SqlDbType.NVarChar, ColumnName = "UserName"},
                new SqlColumn {DataType = SqlDbType.NVarChar, ColumnName = "Exception"},
                new SqlColumn {DataType = SqlDbType.Int, ColumnName = "ElapsedMilliseconds"},
                new SqlColumn {DataType = SqlDbType.NVarChar, ColumnName = "CorrelationId"},
                new SqlColumn {DataType = SqlDbType.NVarChar, ColumnName = "CustomException"},
                new SqlColumn {DataType = SqlDbType.NVarChar, ColumnName = "AdditionalInfo"},
            };
            //colOptions.AdditionalDataColumns = new Collection<DataColumn>
            //{
            //    new DataColumn {DataType = typeof(DateTimeOffset), ColumnName = "Timestamp"},
            //    new DataColumn {DataType = typeof(string), ColumnName = "Product"},
            //    new DataColumn {DataType = typeof(string), ColumnName = "Layer"},
            //    new DataColumn {DataType = typeof(string), ColumnName = "Location"},
            //    new DataColumn {DataType = typeof(string), ColumnName = "Message"},
            //    new DataColumn {DataType = typeof(string), ColumnName = "Hostname"},
            //    new DataColumn {DataType = typeof(string), ColumnName = "UserId"},
            //    new DataColumn {DataType = typeof(string), ColumnName = "UserName"},
            //    new DataColumn {DataType = typeof(string), ColumnName = "Exception"},
            //    new DataColumn {DataType = typeof(int), ColumnName = "ElapsedMilliseconds"},
            //    new DataColumn {DataType = typeof(string), ColumnName = "CorrelationId"},
            //    new DataColumn {DataType = typeof(string), ColumnName = "CustomException"},
            //    new DataColumn {DataType = typeof(string), ColumnName = "AdditionalInfo"},
            //};

            return colOptions;
        }

    }
}

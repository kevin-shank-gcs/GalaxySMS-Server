using GalaxySMS.Business.Entities;
using GalaxySMS.BusinessLayer;
using GalaxySMS.Common.Shared.Enums;
using PDSA.DataLayer.Providers;
using System;
using System.Collections.Generic;
using System.Data;
using PDSA.DataAccess;

namespace GalaxySMS.Data
{
    public class GalaxySMSDatabaseManager
    {
        public static int GetGuidForeignKeyReferenceCount(string tableName, string columnName, Guid guidValue)
        {
            gcs_ForeignKeyReferencedCountGuidPDSAManager mgr = new gcs_ForeignKeyReferencedCountGuidPDSAManager();
            mgr.Entity.TableName = tableName;
            mgr.Entity.ColumnName = columnName;
            mgr.Entity.GuidValue = guidValue;
            mgr.BuildCollection();

            return Convert.ToInt32(mgr.Entity.Result);
        }

        public static int GetBigIntForeignKeyReferenceCount(string tableName, string columnName, Int64 bigIntValue)
        {
            gcs_ForeignKeyReferencedCountBigIntPDSAManager mgr = new gcs_ForeignKeyReferencedCountBigIntPDSAManager();
            mgr.Entity.TableName = tableName;
            mgr.Entity.ColumnName = columnName;
            mgr.Entity.BigIntValue = bigIntValue;
            mgr.BuildCollection();

            return Convert.ToInt32(mgr.Entity.Result);
        }

        public static int GetRowCountFromTableByColumnValue(string tableName, string columnName, Guid guidValue)
        {
            gcs_GetRowCountFromTableByGuidColumnValuePDSAManager mgr = new gcs_GetRowCountFromTableByGuidColumnValuePDSAManager();
            mgr.Entity.TableName = tableName;
            mgr.Entity.ColumnName = columnName;
            mgr.Entity.GuidValue = guidValue;
            mgr.BuildCollection();

            return Convert.ToInt32(mgr.Entity.Result);
        }

        public static int GetRowCountFromTableByColumnValueBigInt(string tableName, string columnName, Int64 bigIntValue)
        {
            gcs_GetRowCountFromTableByBigIntColumnValuePDSAManager mgr =
                new gcs_GetRowCountFromTableByBigIntColumnValuePDSAManager();
            mgr.Entity.TableName = tableName;
            mgr.Entity.ColumnName = columnName;
            mgr.Entity.BigIntValue = bigIntValue;
            mgr.BuildCollection();

            return Convert.ToInt32(mgr.Entity.Result);
        }

        public static int CanRowBeDeleted(string tableName, string columnName, Guid guidValue)
        {
            gcs_CanRowBeDeletedPDSAManager mgr = new gcs_CanRowBeDeletedPDSAManager();
            mgr.Entity.TableName = tableName;
            mgr.Entity.ColumnName = columnName;
            mgr.Entity.GuidValue = guidValue;
            mgr.BuildCollection();

            return Convert.ToInt32(mgr.Entity.Result);
        }

        public static int CanRowBeDeletedBigInt(string tableName, string columnName, Int64 bigIntValue)
        {
            gcs_CanRowBeDeletedBigIntPDSAManager mgr = new gcs_CanRowBeDeletedBigIntPDSAManager();
            mgr.Entity.TableName = tableName;
            mgr.Entity.ColumnName = columnName;
            mgr.Entity.BigIntValue = bigIntValue;
            mgr.BuildCollection();

            return Convert.ToInt32(mgr.Entity.Result);
        }

        public static int DoesRowExist(string tableName, string columnName, Guid guidValue)
        {
            gcs_DoesRowExistPDSAManager mgr = new gcs_DoesRowExistPDSAManager();
            mgr.Entity.TableName = tableName;
            mgr.Entity.ColumnName = columnName;
            mgr.Entity.GuidValue = guidValue;
            mgr.BuildCollection();

            return Convert.ToInt32(mgr.Entity.Result);
        }

        public static int DoesRowExistString(string tableName, string columnName, string stringValue)
        {
            var mgr = new gcs_DoesRowExistNVarCharPDSAManager();
            mgr.Entity.TableName = tableName;
            mgr.Entity.ColumnName = columnName;
            mgr.Entity.Value = stringValue;
            mgr.BuildCollection();

            return Convert.ToInt32(mgr.Entity.Result);
        }

        public static int DoesRowExistBigInt(string tableName, string columnName, Int64 bigIntValue)
        {
            gcs_DoesRowExistBigIntPDSAManager mgr = new gcs_DoesRowExistBigIntPDSAManager();
            mgr.Entity.TableName = tableName;
            mgr.Entity.ColumnName = columnName;
            mgr.Entity.BigIntValue = bigIntValue;
            mgr.BuildCollection();

            return Convert.ToInt32(mgr.Entity.Result);
        }

        public static IEnumerable<GetTableColumnInformation> GetTableColumnInformation(string schemaName, string tableName, string columnName)
        {
            var results = new List<GetTableColumnInformation>();

            var mgr = new GetTableColumnInformationPDSAManager();
            mgr.Entity.TableSchema = schemaName;
            mgr.Entity.TableName = tableName;
            mgr.Entity.ColumnName = columnName;
            var result = mgr.BuildCollection();
            if (result != null)
            {
                foreach (var o in result)
                    results.Add(mgr.ConvertPDSAEntity(o));
            }
            return results;
        }

        public static T GetScalar<T>(string sql)
        {
            
            var sqlClient = new PDSADataSqlClient();
            var connection = sqlClient.CreateConnection();
            var command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            var item = command.ExecuteScalar();
            T result = (T)Convert.ChangeType(item, typeof(T));
            return result;
            //var o = Activator.CreateInstance<T>();
            //return o;
        }


        public static IEnumerable<Guid> GetAllUidsFromTable(string schemaName, string tableName, string columnName)
        {
            var results = new List<Guid>();
            var mgr = new gcs_GetAllColumnGuidValuesPDSAManager();
            mgr.Entity.SchemaName = schemaName;
            mgr.Entity.TableName = tableName;
            mgr.Entity.ColumnName = columnName;
            var data = mgr.BuildCollection();
            foreach (var o in data)
            {
                results.Add(o.Uid);
            }
            return results;
            //var o = Activator.CreateInstance<T>();
            //return o;
        }


        public static IEnumerable<Guid> GetAllUidsFromTable(string schemaName, string tableName, string columnName, string where)
        {
            var results = new List<Guid>();
            var mgr = new gcs_GetAllColumnGuidValuesPDSAManager();
            mgr.Entity.SchemaName = schemaName;
            mgr.Entity.TableName = tableName;
            mgr.Entity.ColumnName = columnName;
            mgr.Entity.Where = where;
            var data = mgr.BuildCollection();
            foreach (var o in data)
            {
                results.Add(o.Uid);
            }
            return results;
            //var o = Activator.CreateInstance<T>();
            //return o;
        }

        public static int SetIsolationLevel(SqlTransactionIsolationLevels level)
        {
            var mgr = new gcs_SetTransactionIsolationLevelPDSAManager();
            switch (level)
            {
                case SqlTransactionIsolationLevels.ReadUncommitted:
                    mgr.Entity.IsolationLevel = "READ UNCOMMITTED";
                    break;
                case SqlTransactionIsolationLevels.ReadCommitted:
                    mgr.Entity.IsolationLevel = "READ COMMITTED";
                    break;
                case SqlTransactionIsolationLevels.RepeatableRead:
                    mgr.Entity.IsolationLevel = "REPEATABLE READ";
                    break;
                case SqlTransactionIsolationLevels.Snapshot:
                    mgr.Entity.IsolationLevel = "SNAPSHOT";
                    break;
                case SqlTransactionIsolationLevels.Serializable:
                    mgr.Entity.IsolationLevel = "SERIALIZABLE";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(level), level, null);
            }
            var result = mgr.Execute();
            return result;

        }

        public static int ResetConcurrencyValue(string tableName, string uidColumn, Guid uid)
        {
            var mgr = new ResetConcurrencyValuePDSAManager();
            mgr.DataObject.Entity.tableName = tableName;
            mgr.DataObject.Entity.uidColumn = uidColumn;
            mgr.DataObject.Entity.uid = uid;
            var result = mgr.Execute();
            return result;

        }

    }
}

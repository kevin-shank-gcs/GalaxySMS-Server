using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using GalaxySMS.Business.Entities;
using GCS.Core.Common.Contracts;

namespace GalaxySMS.Data
{
    public class GalaxySMSDBContextBase : DbContext
    {
        public GalaxySMSDBContextBase()
            : base("name=GalaxySMS")
        {
            Database.SetInitializer<GalaxySMSDBContextBase>(null);
        }

        public GalaxySMSDBContextBase(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            Database.SetInitializer<GalaxySMSDBContextBase>(null);
        }

        public int GetGuidForeignKeyReferenceCount(string tableName, string columnName, Guid guidValue)
        {
            var tableNameParam = new SqlParameter
            {
                ParameterName = "TableName",
                Value = tableName
            };
            var columnNameParam = new SqlParameter
            {
                ParameterName = "ColumnName",
                Value = columnName
            };
            var guidValueParam = new SqlParameter
            {
                ParameterName = "GuidValue",
                Value = guidValue
            };
            var resultParam = new SqlParameter
            {
                ParameterName = "Result",
                Value = 0,
                Direction = System.Data.ParameterDirection.Output
            };
            var ret =
                this.Database.ExecuteSqlCommand(
                    "exec [dbo].[gcs_ForeignKeyReferencedCountGuid] @TableName, @ColumnName, @GuidValue, @Result OUTPUT",
                    tableNameParam, columnNameParam, guidValueParam, resultParam);

            return Convert.ToInt32(resultParam.Value);

        }
        public int GetRowCountFromTableByColumnValue(string tableName, string columnName, Guid guidValue)
        {
            var tableNameParam = new SqlParameter
            {
                ParameterName = "TableName",
                Value = tableName
            };
            var columnNameParam = new SqlParameter
            {
                ParameterName = "ColumnName",
                Value = columnName
            };
            var guidValueParam = new SqlParameter
            {
                ParameterName = "GuidValue",
                Value = guidValue
            };
            var resultParam = new SqlParameter
            {
                ParameterName = "Result",
                Value = 0,
                Direction = System.Data.ParameterDirection.Output
            };
            var ret =
                this.Database.ExecuteSqlCommand(
                    "exec [dbo].[gcs_GetRowCountFromTableByGuidColumnValue] @TableName, @ColumnName, @GuidValue, @Result OUTPUT",
                    tableNameParam, columnNameParam, guidValueParam, resultParam);

            return Convert.ToInt32(resultParam.Value);

        }
        public int CanRowBeDeleted(string tableName, string columnName, Guid guidValue)
        {
            var tableNameParam = new SqlParameter
            {
                ParameterName = "TableName",
                Value = tableName
            };
            var columnNameParam = new SqlParameter
            {
                ParameterName = "ColumnName",
                Value = columnName
            };
            var guidValueParam = new SqlParameter
            {
                ParameterName = "GuidValue",
                Value = guidValue
            };
            var resultParam = new SqlParameter
            {
                ParameterName = "Result",
                Value = 0,
                Direction = System.Data.ParameterDirection.Output
            };
            var ret =
                this.Database.ExecuteSqlCommand(
                    "exec [dbo].[gcs_CanRowBeDeleted] @TableName, @ColumnName, @GuidValue, @Result OUTPUT",
                    tableNameParam, columnNameParam, guidValueParam, resultParam);

            return Convert.ToInt32(resultParam.Value);

        }
    }
}

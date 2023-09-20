using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.BusinessLayer;

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
        public static int GetRowCountFromTableByColumnValue(string tableName, string columnName, Guid guidValue)
        {
            gcs_GetRowCountFromTableByGuidColumnValuePDSAManager mgr = new gcs_GetRowCountFromTableByGuidColumnValuePDSAManager();
            mgr.Entity.TableName = tableName;
            mgr.Entity.ColumnName = columnName;
            mgr.Entity.GuidValue = guidValue;
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
    }
}

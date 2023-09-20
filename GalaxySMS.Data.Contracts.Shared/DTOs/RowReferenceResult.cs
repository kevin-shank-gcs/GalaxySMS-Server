using GCS.Core.Common.Core;
using System;

namespace GalaxySMS.Data.Contracts
{
    public class RowReferenceResult : DataContractBase
    {
        public enum RuleType { NoAction, Cascade, SetNull, SetDefault }
        public string ConstraintName { get; set; }
        public string TableSchema { get; set; }
        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public Guid RowPrimaryKeyGuid { get; set; }
        public int RowPrimaryKeyId { get; set; }
        public string RowPrimaryKeyString { get; set; }
        public RuleType UpdateRule { get; set; }
        public RuleType DeleteRule { get; set; }


    }
}

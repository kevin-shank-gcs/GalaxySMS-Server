namespace GalaxySMS.Business.Entities
{
    using System;
    using System.Collections.Generic;
    using GCS.Core.Common.Contracts;
    using GCS.Core.Common.Core;

    public partial class GetTableColumnInformation
    {
        #region Public Properties
        public string DatabaseName { get; set; }
        public string TableSchema { get; set; }
        public string TableName { get; set; }
        public string ColumnName { get; set; }
        public string IsNullable { get; set; }
        public int ColumnOrdinalPosition { get; set; }
        public string DefaultValue { get; set; }
        public string DataType { get; set; }
        public int CharacterMaximumLength { get; set; }
        public byte[] NumericPrecision { get; set; }
        public short NumericPrecisionRadix { get; set; }
        public int NumericScale { get; set; }
        public short DateTimePrecision { get; set; }
        public int RETURNVALUE { get; set; }
        #endregion
    }
}

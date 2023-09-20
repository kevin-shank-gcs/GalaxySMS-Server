using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
    public partial class GetTableColumnInformation
    {
        public GetTableColumnInformation()
        {
            Initialize();
        }

        public GetTableColumnInformation(GetTableColumnInformation e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
        }

        public void Initialize(GetTableColumnInformation e)
        {
            Initialize();
            if (e == null)
                return;

            DatabaseName = e.DatabaseName;
            TableSchema = e.TableSchema;
            TableName = e.TableName;
            ColumnName = e.ColumnName;
            IsNullable = e.IsNullable;
            ColumnOrdinalPosition = e.ColumnOrdinalPosition;
            DefaultValue = e.DefaultValue;
            DataType = e.DataType;
            CharacterMaximumLength = e.CharacterMaximumLength;
            NumericPrecision = e.NumericPrecision;
            NumericPrecisionRadix = e.NumericPrecisionRadix;
            NumericScale = e.NumericScale;
            DateTimePrecision = e.DateTimePrecision;
            IsComputed = e.IsComputed;
            RETURNVALUE = e.RETURNVALUE;

        }

        public bool IsAnythingDirty
        {
            get
            {
                return false;
            }
        }

        public GetTableColumnInformation Clone(GetTableColumnInformation e)
        {
            return new GetTableColumnInformation(e);
        }

        public bool Equals(GetTableColumnInformation other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(GetTableColumnInformation other)
        {
            if (other == null)
                return false;

            if (other.TableSchema != this.TableSchema ||
                other.TableName != this.TableName ||
                other.ColumnName != this.ColumnName)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}

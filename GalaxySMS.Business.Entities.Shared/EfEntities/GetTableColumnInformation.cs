////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\GetTableColumnInformation.cs
//
// summary:	Implements the get table column information class
////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
#if NetCoreApi
#else
    [DataContract]
#endif


    public partial class GetTableColumnInformation
    {
        #region Public Properties

#if NetCoreApi
#else
        [DataMember]
#endif
        public string DatabaseName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TableSchema { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string TableName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ColumnName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string IsNullable { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int   ColumnOrdinalPosition { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string DefaultValue { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string DataType { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int   CharacterMaximumLength { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public byte[] NumericPrecision { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
         public short NumericPrecisionRadix { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int   NumericScale { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
         public short DateTimePrecision { get; set; }


#if NetCoreApi
#else
        [DataMember]
#endif
        public int IsComputed { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int   RETURNVALUE { get; set; }
        #endregion
    }
}

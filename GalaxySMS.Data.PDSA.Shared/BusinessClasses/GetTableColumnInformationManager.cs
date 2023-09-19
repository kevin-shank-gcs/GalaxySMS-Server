using System;
using System.Data;

using PDSA;
using PDSA.Common;
using PDSA.DataLayer;
using PDSA.DataLayer.DataClasses;

using GalaxySMS.EntityLayer;
using GalaxySMS.ValidationLayer;
using GalaxySMS.DataLayer;
using GalaxySMS.Business.Entities;
using GCS.Core.Common.Utils;

namespace GalaxySMS.BusinessLayer
{
    /// <summary>
    /// This class is used to call the stored procedure GetTableColumnInformationPDSA
    /// This class is generated using the Haystack Code Generator for .NET Utility.
    /// You may add additional methods to this class.
    /// </summary>
    public partial class GetTableColumnInformationPDSAManager
    {
        #region Your Custom Properties and Methods
        #region ConvertPDSACollection
        /// <summary>
        /// Call this method to convert a PDSACollection to an IEnumerable collection of an equivalent Brand objects 
        /// </summary>
        public GetTableColumnInformation ConvertPDSAEntity(GetTableColumnInformationPDSA pdsaEntity)
        {
            var convertedEntity = new GetTableColumnInformation();
            SimpleMapper.PropertyMap(pdsaEntity, convertedEntity);
            return convertedEntity;
        }

        #endregion
        #endregion
    }
}

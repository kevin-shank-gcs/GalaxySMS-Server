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
    /// This class is used to call the stored procedure Cluster_GetHardwareAddressPDSA
    /// This class is generated using the Haystack Code Generator for .NET Utility.
    /// You may add additional methods to this class.
    /// </summary>
    public partial class Cluster_GetHardwareAddressPDSAManager
    {
        #region Your Custom Properties and Methods
        #region ConvertPDSACollection
        /// <summary>
        /// Call this method to convert a PDSACollection to an IEnumerable collection of an equivalent Brand objects 
        /// </summary>
        public Cluster_GetHardwareAddress ConvertPDSAEntity(Cluster_GetHardwareAddressPDSA pdsaEntity)
        {
            var convertedEntity = new Cluster_GetHardwareAddress();
            SimpleMapper.PropertyMap(pdsaEntity, convertedEntity);
            return convertedEntity;
        }
        #endregion
        #endregion
    }
}

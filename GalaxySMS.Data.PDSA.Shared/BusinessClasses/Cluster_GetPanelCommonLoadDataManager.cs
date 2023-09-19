using System;
using System.Data;
using GalaxySMS.Business.Entities;
using PDSA;
using PDSA.Common;
using PDSA.DataLayer;
using PDSA.DataLayer.DataClasses;

using GalaxySMS.EntityLayer;
using GalaxySMS.ValidationLayer;
using GalaxySMS.DataLayer;
using GCS.Core.Common.Utils;

namespace GalaxySMS.BusinessLayer
{
    /// <summary>
    /// This class is used to call the stored procedure Cluster_GetPanelCommonLoadDataPDSA
    /// This class is generated using the Haystack Code Generator for .NET Utility.
    /// You may add additional methods to this class.
    /// </summary>
    public partial class Cluster_GetPanelCommonLoadDataPDSAManager
    {
        #region Your Custom Properties and Methods
        #region ConvertPDSACollection
        /// <summary>
        /// Call this method to convert a PDSACollection to an IEnumerable collection of an equivalent Brand objects 
        /// </summary>
        public Cluster_CommonPanelLoadData ConvertPDSAEntity(Cluster_GetPanelCommonLoadDataPDSA pdsaEntity)
        {
            var convertedEntity = new Cluster_CommonPanelLoadData();
            SimpleMapper.PropertyMap(pdsaEntity, convertedEntity);
            return convertedEntity;
        }

        #endregion

        #endregion
    }
}

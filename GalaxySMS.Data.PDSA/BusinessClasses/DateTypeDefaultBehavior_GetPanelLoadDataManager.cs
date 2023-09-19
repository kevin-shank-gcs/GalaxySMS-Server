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
  /// This class is used to call the stored procedure DateTypeDefaultBehavior_GetPanelLoadDataPDSA
  /// This class is generated using the Haystack Code Generator for .NET Utility.
  /// You may add additional methods to this class.
  /// </summary>
  public partial class DateTypeDefaultBehavior_GetPanelLoadDataPDSAManager
  {
        #region Your Custom Properties and Methods
        #region ConvertPDSACollection
        /// <summary>
        /// Call this method to convert a PDSACollection to an IEnumerable collection of an equivalent Brand objects 
        /// </summary>
        public DateTypeDefaultBehavior_PanelLoadData ConvertPDSAEntity(DateTypeDefaultBehavior_GetPanelLoadDataPDSA pdsaEntity)
        {
            var convertedEntity = new DateTypeDefaultBehavior_PanelLoadData();
            SimpleMapper.PropertyMap(pdsaEntity, convertedEntity);
            return convertedEntity;
        }

        #endregion


        #endregion
    }
}

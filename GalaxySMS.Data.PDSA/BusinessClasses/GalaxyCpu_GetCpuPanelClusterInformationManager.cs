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
  /// This class is used to call the stored procedure GalaxyCpu_GetCpuPanelClusterInformationPDSA
  /// This class is generated using the Haystack Code Generator for .NET Utility.
  /// You may add additional methods to this class.
  /// </summary>
  public partial class GalaxyCpu_GetCpuPanelClusterInformationPDSAManager
  {
    #region Your Custom Properties and Methods
        public GalaxyCpuDatabaseInformation ConvertPDSAEntity(GalaxyCpu_GetCpuPanelClusterInformationPDSA pdsaEntity)
        {
            var convertedEntity = new GalaxyCpuDatabaseInformation();
            SimpleMapper.PropertyMap(pdsaEntity, convertedEntity);
            return convertedEntity;
        }
    #endregion
  }
}

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
  /// This class is used to call the stored procedure InputDevice_GetAlertEventAcknowledgeDataPDSA
  /// This class is generated using the Haystack Code Generator for .NET Utility.
  /// You may add additional methods to this class.
  /// </summary>
  public partial class InputDevice_GetAlertEventAcknowledgeDataPDSAManager
  {
    #region Your Custom Properties and Methods
    #region Your Custom Properties and Methods
    public InputDevice_GetAlertEventAcknowledgeData ConvertPDSAEntity(InputDevice_GetAlertEventAcknowledgeDataPDSA pdsaEntity)
    {
        var convertedEntity = new InputDevice_GetAlertEventAcknowledgeData();
        SimpleMapper.PropertyMap(pdsaEntity, convertedEntity);
        return convertedEntity;
    }         
    #endregion   
    #endregion
  }
}

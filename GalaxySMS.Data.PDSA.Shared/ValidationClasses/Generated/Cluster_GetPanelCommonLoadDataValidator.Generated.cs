using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the Cluster_GetPanelCommonLoadDataPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class Cluster_GetPanelCommonLoadDataPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private Cluster_GetPanelCommonLoadDataPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new Cluster_GetPanelCommonLoadDataPDSA Entity
    {
      get { return _Entity; }
      set
      {
        _Entity = value;
        base.Entity = value;
      }
    }
    #endregion
  
    #region Clone Entity Class
    /// <summary>
    /// Clones the current Cluster_GetPanelCommonLoadDataPDSA
    /// </summary>
    /// <returns>A cloned Cluster_GetPanelCommonLoadDataPDSA object</returns>
    public Cluster_GetPanelCommonLoadDataPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in Cluster_GetPanelCommonLoadDataPDSA
    /// </summary>
    /// <param name="entityToClone">The Cluster_GetPanelCommonLoadDataPDSA entity to clone</param>
    /// <returns>A cloned Cluster_GetPanelCommonLoadDataPDSA object</returns>
    public Cluster_GetPanelCommonLoadDataPDSA CloneEntity(Cluster_GetPanelCommonLoadDataPDSA entityToClone)
    {
      Cluster_GetPanelCommonLoadDataPDSA newEntity = new Cluster_GetPanelCommonLoadDataPDSA();

      newEntity.ClusterUid = entityToClone.ClusterUid;
      newEntity.ClusterNumber = entityToClone.ClusterNumber;
      newEntity.ClusterName = entityToClone.ClusterName;
      newEntity.InsertDate = entityToClone.InsertDate;
      newEntity.UpdateDate = entityToClone.UpdateDate;
      newEntity.ClusterGroupId = entityToClone.ClusterGroupId;
      newEntity.IsActive = entityToClone.IsActive;
      newEntity.AbaStartDigit = entityToClone.AbaStartDigit;
      newEntity.AbaStopDigit = entityToClone.AbaStopDigit;
      newEntity.AbaFoldOption = entityToClone.AbaFoldOption;
      newEntity.AbaClipOption = entityToClone.AbaClipOption;
      newEntity.WiegandStartBit = entityToClone.WiegandStartBit;
      newEntity.WiegandStopBit = entityToClone.WiegandStopBit;
      newEntity.CardaxStartBit = entityToClone.CardaxStartBit;
      newEntity.CardaxStopBit = entityToClone.CardaxStopBit;
      newEntity.LockoutAfterInvalidAttempts = entityToClone.LockoutAfterInvalidAttempts;
      newEntity.LockoutDurationSeconds = entityToClone.LockoutDurationSeconds;
      newEntity.AccessRuleOverrideTimeout = entityToClone.AccessRuleOverrideTimeout;
      newEntity.UnlimitedCredentialTimeout = entityToClone.UnlimitedCredentialTimeout;
      newEntity.TimeZoneId = entityToClone.TimeZoneId;
      newEntity.ActivateCrisisIOGroupNumber = entityToClone.ActivateCrisisIOGroupNumber;
      newEntity.ResetCrisisIOGroupNumber = entityToClone.ResetCrisisIOGroupNumber;
      newEntity.LockedLED = entityToClone.LockedLED;
      newEntity.UnlockedLED = entityToClone.UnlockedLED;
      newEntity.ClusterTypeCode = entityToClone.ClusterTypeCode;
      newEntity.CredentialDataLength = entityToClone.CredentialDataLength;
      newEntity.TimeScheduleTypeCode = entityToClone.TimeScheduleTypeCode;

      return newEntity;
    }
    #endregion

    #region CreateProperties Method
    /// <summary>
    /// Creates the collection of PDSAProperty objects. These are used to control validation and null handling.
    /// </summary>
    /// <returns>A collection of PDSAProperty objects</returns>
    public override PDSAProperties CreateProperties()
    {
      PDSAProperties props = new PDSAProperties();
      
      props.Add(PDSAProperty.Create(Cluster_GetPanelCommonLoadDataPDSAValidator.ParameterNames.ClusterUid, GetResourceMessage("GCS_Cluster_GetPanelCommonLoadDataPDSA_ClusterUid_Header", "Cluster Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_Cluster_GetPanelCommonLoadDataPDSA_ClusterUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(Cluster_GetPanelCommonLoadDataPDSAValidator.ParameterNames.ClusterGroupId, GetResourceMessage("GCS_Cluster_GetPanelCommonLoadDataPDSA_AccountCode_Header", "Account Code"), false, typeof(string), 8000, GetResourceMessage("GCS_Cluster_GetPanelCommonLoadDataPDSA_AccountCode_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(Cluster_GetPanelCommonLoadDataPDSAValidator.ParameterNames.ClusterNumber, GetResourceMessage("GCS_Cluster_GetPanelCommonLoadDataPDSA_ClusterNumber_Header", "Cluster Number"), false, typeof(int), 0, GetResourceMessage("GCS_Cluster_GetPanelCommonLoadDataPDSA_ClusterNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("1"), Convert.ToInt32("65535"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(Cluster_GetPanelCommonLoadDataPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_Cluster_GetPanelCommonLoadDataPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_Cluster_GetPanelCommonLoadDataPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
      return props;
    }
    #endregion
    
    #region InitProperties Method
    /// <summary>
    /// Called by the constructor to create the PDSAProperties collection of all properties that will be validated.
    /// </summary>
    protected override void InitProperties()
    {
      // Set the Properties collection to the collection of Entity Properties
      Properties = CreateProperties();
    }
    #endregion

    #region EntityDataToProperties Method
    /// <summary>
    /// Moves the Entity class data into the Properties collection.
    /// </summary>
    protected override void EntityDataToProperties()
    {
      if (this.Properties == null)
      {
        this.InitProperties();
      }
      
      this.Properties.GetByName(Cluster_GetPanelCommonLoadDataPDSAValidator.ParameterNames.ClusterUid).Value = Entity.ClusterUid;
      this.Properties.GetByName(Cluster_GetPanelCommonLoadDataPDSAValidator.ParameterNames.ClusterGroupId).Value = Entity.ClusterGroupId;
      this.Properties.GetByName(Cluster_GetPanelCommonLoadDataPDSAValidator.ParameterNames.ClusterNumber).Value = Entity.ClusterNumber;
      this.Properties.GetByName(Cluster_GetPanelCommonLoadDataPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (this.Properties == null)
      {
        this.InitProperties();
      }

      if(this.Properties.GetByName(Cluster_GetPanelCommonLoadDataPDSAValidator.ParameterNames.ClusterUid).IsNull == false)
        Entity.ClusterUid = this.Properties.GetByName(Cluster_GetPanelCommonLoadDataPDSAValidator.ParameterNames.ClusterUid).GetAsGuid();
      if(this.Properties.GetByName(Cluster_GetPanelCommonLoadDataPDSAValidator.ParameterNames.ClusterGroupId).IsNull == false)
        Entity.ClusterGroupId = this.Properties.GetByName(Cluster_GetPanelCommonLoadDataPDSAValidator.ParameterNames.ClusterGroupId).GetAsInteger();
      if(this.Properties.GetByName(Cluster_GetPanelCommonLoadDataPDSAValidator.ParameterNames.ClusterNumber).IsNull == false)
        Entity.ClusterNumber = this.Properties.GetByName(Cluster_GetPanelCommonLoadDataPDSAValidator.ParameterNames.ClusterNumber).GetAsInteger();
      if(this.Properties.GetByName(Cluster_GetPanelCommonLoadDataPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(Cluster_GetPanelCommonLoadDataPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the Cluster_GetPanelCommonLoadDataPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'ClusterUid'
    /// </summary>
    public static string ClusterUid = "ClusterUid";
    /// <summary>
    /// Returns 'ClusterNumber'
    /// </summary>
    public static string ClusterNumber = "ClusterNumber";
    /// <summary>
    /// Returns 'ClusterName'
    /// </summary>
    public static string ClusterName = "ClusterName";
    /// <summary>
    /// Returns 'InsertDate'
    /// </summary>
    public static string InsertDate = "InsertDate";
    /// <summary>
    /// Returns 'UpdateDate'
    /// </summary>
    public static string UpdateDate = "UpdateDate";
    /// <summary>
    /// Returns 'ClusterGroupId'
    /// </summary>
    public static string ClusterGroupId = "ClusterGroupId";
    /// <summary>
    /// Returns 'IsActive'
    /// </summary>
    public static string IsActive = "IsActive";
    /// <summary>
    /// Returns 'AbaStartDigit'
    /// </summary>
    public static string AbaStartDigit = "AbaStartDigit";
    /// <summary>
    /// Returns 'AbaStopDigit'
    /// </summary>
    public static string AbaStopDigit = "AbaStopDigit";
    /// <summary>
    /// Returns 'AbaFoldOption'
    /// </summary>
    public static string AbaFoldOption = "AbaFoldOption";
    /// <summary>
    /// Returns 'AbaClipOption'
    /// </summary>
    public static string AbaClipOption = "AbaClipOption";
    /// <summary>
    /// Returns 'WiegandStartBit'
    /// </summary>
    public static string WiegandStartBit = "WiegandStartBit";
    /// <summary>
    /// Returns 'WiegandStopBit'
    /// </summary>
    public static string WiegandStopBit = "WiegandStopBit";
    /// <summary>
    /// Returns 'CardaxStartBit'
    /// </summary>
    public static string CardaxStartBit = "CardaxStartBit";
    /// <summary>
    /// Returns 'CardaxStopBit'
    /// </summary>
    public static string CardaxStopBit = "CardaxStopBit";
    /// <summary>
    /// Returns 'LockoutAfterInvalidAttempts'
    /// </summary>
    public static string LockoutAfterInvalidAttempts = "LockoutAfterInvalidAttempts";
    /// <summary>
    /// Returns 'LockoutDurationSeconds'
    /// </summary>
    public static string LockoutDurationSeconds = "LockoutDurationSeconds";
    /// <summary>
    /// Returns 'AccessRuleOverrideTimeout'
    /// </summary>
    public static string AccessRuleOverrideTimeout = "AccessRuleOverrideTimeout";
    /// <summary>
    /// Returns 'UnlimitedCredentialTimeout'
    /// </summary>
    public static string UnlimitedCredentialTimeout = "UnlimitedCredentialTimeout";
    /// <summary>
    /// Returns 'TimeZoneId'
    /// </summary>
    public static string TimeZoneId = "TimeZoneId";
    /// <summary>
    /// Returns 'ActivateCrisisIOGroupNumber'
    /// </summary>
    public static string ActivateCrisisIOGroupNumber = "ActivateCrisisIOGroupNumber";
    /// <summary>
    /// Returns 'ResetCrisisIOGroupNumber'
    /// </summary>
    public static string ResetCrisisIOGroupNumber = "ResetCrisisIOGroupNumber";
    /// <summary>
    /// Returns 'LockedLED'
    /// </summary>
    public static string LockedLED = "LockedLED";
    /// <summary>
    /// Returns 'UnlockedLED'
    /// </summary>
    public static string UnlockedLED = "UnlockedLED";
    /// <summary>
    /// Returns 'ClusterTypeCode'
    /// </summary>
    public static string ClusterTypeCode = "ClusterTypeCode";
    /// <summary>
    /// Returns 'CredentialDataLength'
    /// </summary>
    public static string CredentialDataLength = "CredentialDataLength";
    /// <summary>
    /// Returns 'TimeScheduleTypeCode'
    /// </summary>
    public static string TimeScheduleTypeCode = "TimeScheduleTypeCode";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the Cluster_GetPanelCommonLoadDataPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@ClusterUid'
    /// </summary>
    public static string ClusterUid = "@ClusterUid";
    /// <summary>
    /// Returns '@ClusterGroupId'
    /// </summary>
    public static string ClusterGroupId = "@ClusterGroupId";
    /// <summary>
    /// Returns '@ClusterNumber'
    /// </summary>
    public static string ClusterNumber = "@ClusterNumber";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}

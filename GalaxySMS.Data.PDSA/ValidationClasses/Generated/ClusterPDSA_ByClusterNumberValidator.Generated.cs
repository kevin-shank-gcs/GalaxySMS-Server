using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the ClusterPDSA_ByClusterNumberPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class ClusterPDSA_ByClusterNumberPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private ClusterPDSA_ByClusterNumberPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new ClusterPDSA_ByClusterNumberPDSA Entity
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
    /// Clones the current ClusterPDSA_ByClusterNumberPDSA
    /// </summary>
    /// <returns>A cloned ClusterPDSA_ByClusterNumberPDSA object</returns>
    public ClusterPDSA_ByClusterNumberPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in ClusterPDSA_ByClusterNumberPDSA
    /// </summary>
    /// <param name="entityToClone">The ClusterPDSA_ByClusterNumberPDSA entity to clone</param>
    /// <returns>A cloned ClusterPDSA_ByClusterNumberPDSA object</returns>
    public ClusterPDSA_ByClusterNumberPDSA CloneEntity(ClusterPDSA_ByClusterNumberPDSA entityToClone)
    {
      ClusterPDSA_ByClusterNumberPDSA newEntity = new ClusterPDSA_ByClusterNumberPDSA();

      newEntity.ClusterUid = entityToClone.ClusterUid;
      newEntity.ClusterTypeUid = entityToClone.ClusterTypeUid;
      newEntity.ClusterNumber = entityToClone.ClusterNumber;
      newEntity.ClusterName = entityToClone.ClusterName;
      newEntity.InsertName = entityToClone.InsertName;
      newEntity.InsertDate = entityToClone.InsertDate;
      newEntity.UpdateName = entityToClone.UpdateName;
      newEntity.UpdateDate = entityToClone.UpdateDate;
      newEntity.ConcurrencyValue = entityToClone.ConcurrencyValue;
      newEntity.EntityId = entityToClone.EntityId;
      newEntity.SiteUid = entityToClone.SiteUid;
      newEntity.CredentialDataLengthUid = entityToClone.CredentialDataLengthUid;
      newEntity.TimeScheduleTypeUid = entityToClone.TimeScheduleTypeUid;
      newEntity.BinaryResourceUid = entityToClone.BinaryResourceUid;
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
      newEntity.CrisisActivateInputOutputGroupUid = entityToClone.CrisisActivateInputOutputGroupUid;
      newEntity.CrisisResetInputOutputGroupUid = entityToClone.CrisisResetInputOutputGroupUid;
      newEntity.AccessPortalLockedLedBehaviorModeUid = entityToClone.AccessPortalLockedLedBehaviorModeUid;
      newEntity.AccessPortalUnlockedLedBehaviorModeUid = entityToClone.AccessPortalUnlockedLedBehaviorModeUid;
      newEntity.AccessPortalTypeUid = entityToClone.AccessPortalTypeUid;
      newEntity.TemplateAccessPortalUid = entityToClone.TemplateAccessPortalUid;
      newEntity.CurrentTimeForCluster = entityToClone.CurrentTimeForCluster;
      newEntity.ClusterGroupId = entityToClone.ClusterGroupId;
      newEntity.TotalRowCount = entityToClone.TotalRowCount;

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
      
      props.Add(PDSAProperty.Create(ClusterPDSA_ByClusterNumberPDSAValidator.ParameterNames.ClusterNumber, GetResourceMessage("GCS_ClusterPDSA_ByClusterNumberPDSA_ClusterNumber_Header", "Cluster Number"), false, typeof(int), 0, GetResourceMessage("GCS_ClusterPDSA_ByClusterNumberPDSA_ClusterNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(ClusterPDSA_ByClusterNumberPDSAValidator.ParameterNames.PageNumber, GetResourceMessage("GCS_ClusterPDSA_ByClusterNumberPDSA_PageNumber_Header", "Page Number"), false, typeof(int), 0, GetResourceMessage("GCS_ClusterPDSA_ByClusterNumberPDSA_PageNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(ClusterPDSA_ByClusterNumberPDSAValidator.ParameterNames.PageSize, GetResourceMessage("GCS_ClusterPDSA_ByClusterNumberPDSA_PageSize_Header", "Page Size"), false, typeof(int), 0, GetResourceMessage("GCS_ClusterPDSA_ByClusterNumberPDSA_PageSize_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(ClusterPDSA_ByClusterNumberPDSAValidator.ParameterNames.SortColumn, GetResourceMessage("GCS_ClusterPDSA_ByClusterNumberPDSA_SortColumn_Header", "Sort Column"), false, typeof(string), 8000, GetResourceMessage("GCS_ClusterPDSA_ByClusterNumberPDSA_SortColumn_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(ClusterPDSA_ByClusterNumberPDSAValidator.ParameterNames.DescendingOrder, GetResourceMessage("GCS_ClusterPDSA_ByClusterNumberPDSA_DescendingOrder_Header", "Descending Order"), false, typeof(bool), 0, GetResourceMessage("GCS_ClusterPDSA_ByClusterNumberPDSA_DescendingOrder_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(ClusterPDSA_ByClusterNumberPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_ClusterPDSA_ByClusterNumberPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_ClusterPDSA_ByClusterNumberPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(ClusterPDSA_ByClusterNumberPDSAValidator.ParameterNames.ClusterNumber).Value = Entity.ClusterNumber;
      this.Properties.GetByName(ClusterPDSA_ByClusterNumberPDSAValidator.ParameterNames.PageNumber).Value = Entity.PageNumber;
      this.Properties.GetByName(ClusterPDSA_ByClusterNumberPDSAValidator.ParameterNames.PageSize).Value = Entity.PageSize;
      this.Properties.GetByName(ClusterPDSA_ByClusterNumberPDSAValidator.ParameterNames.SortColumn).Value = Entity.SortColumn;
      this.Properties.GetByName(ClusterPDSA_ByClusterNumberPDSAValidator.ParameterNames.DescendingOrder).Value = Entity.DescendingOrder;
      this.Properties.GetByName(ClusterPDSA_ByClusterNumberPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(ClusterPDSA_ByClusterNumberPDSAValidator.ParameterNames.ClusterNumber).IsNull == false)
        Entity.ClusterNumber = this.Properties.GetByName(ClusterPDSA_ByClusterNumberPDSAValidator.ParameterNames.ClusterNumber).GetAsInteger();
      if(this.Properties.GetByName(ClusterPDSA_ByClusterNumberPDSAValidator.ParameterNames.PageNumber).IsNull == false)
        Entity.PageNumber = this.Properties.GetByName(ClusterPDSA_ByClusterNumberPDSAValidator.ParameterNames.PageNumber).GetAsInteger();
      if(this.Properties.GetByName(ClusterPDSA_ByClusterNumberPDSAValidator.ParameterNames.PageSize).IsNull == false)
        Entity.PageSize = this.Properties.GetByName(ClusterPDSA_ByClusterNumberPDSAValidator.ParameterNames.PageSize).GetAsInteger();
      if(this.Properties.GetByName(ClusterPDSA_ByClusterNumberPDSAValidator.ParameterNames.SortColumn).IsNull == false)
        Entity.SortColumn = this.Properties.GetByName(ClusterPDSA_ByClusterNumberPDSAValidator.ParameterNames.SortColumn).GetAsString();
      if(this.Properties.GetByName(ClusterPDSA_ByClusterNumberPDSAValidator.ParameterNames.DescendingOrder).IsNull == false)
        Entity.DescendingOrder = this.Properties.GetByName(ClusterPDSA_ByClusterNumberPDSAValidator.ParameterNames.DescendingOrder).GetAsBool();
      if(this.Properties.GetByName(ClusterPDSA_ByClusterNumberPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(ClusterPDSA_ByClusterNumberPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the ClusterPDSA_ByClusterNumberPDSA class.
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
    /// Returns 'ClusterTypeUid'
    /// </summary>
    public static string ClusterTypeUid = "ClusterTypeUid";
    /// <summary>
    /// Returns 'ClusterNumber'
    /// </summary>
    public static string ClusterNumber = "ClusterNumber";
    /// <summary>
    /// Returns 'ClusterName'
    /// </summary>
    public static string ClusterName = "ClusterName";
    /// <summary>
    /// Returns 'InsertName'
    /// </summary>
    public static string InsertName = "InsertName";
    /// <summary>
    /// Returns 'InsertDate'
    /// </summary>
    public static string InsertDate = "InsertDate";
    /// <summary>
    /// Returns 'UpdateName'
    /// </summary>
    public static string UpdateName = "UpdateName";
    /// <summary>
    /// Returns 'UpdateDate'
    /// </summary>
    public static string UpdateDate = "UpdateDate";
    /// <summary>
    /// Returns 'ConcurrencyValue'
    /// </summary>
    public static string ConcurrencyValue = "ConcurrencyValue";
    /// <summary>
    /// Returns 'EntityId'
    /// </summary>
    public static string EntityId = "EntityId";
    /// <summary>
    /// Returns 'SiteUid'
    /// </summary>
    public static string SiteUid = "SiteUid";
    /// <summary>
    /// Returns 'CredentialDataLengthUid'
    /// </summary>
    public static string CredentialDataLengthUid = "CredentialDataLengthUid";
    /// <summary>
    /// Returns 'TimeScheduleTypeUid'
    /// </summary>
    public static string TimeScheduleTypeUid = "TimeScheduleTypeUid";
    /// <summary>
    /// Returns 'BinaryResourceUid'
    /// </summary>
    public static string BinaryResourceUid = "BinaryResourceUid";
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
    /// Returns 'CrisisActivateInputOutputGroupUid'
    /// </summary>
    public static string CrisisActivateInputOutputGroupUid = "CrisisActivateInputOutputGroupUid";
    /// <summary>
    /// Returns 'CrisisResetInputOutputGroupUid'
    /// </summary>
    public static string CrisisResetInputOutputGroupUid = "CrisisResetInputOutputGroupUid";
    /// <summary>
    /// Returns 'AccessPortalLockedLedBehaviorModeUid'
    /// </summary>
    public static string AccessPortalLockedLedBehaviorModeUid = "AccessPortalLockedLedBehaviorModeUid";
    /// <summary>
    /// Returns 'AccessPortalUnlockedLedBehaviorModeUid'
    /// </summary>
    public static string AccessPortalUnlockedLedBehaviorModeUid = "AccessPortalUnlockedLedBehaviorModeUid";
    /// <summary>
    /// Returns 'AccessPortalTypeUid'
    /// </summary>
    public static string AccessPortalTypeUid = "AccessPortalTypeUid";
    /// <summary>
    /// Returns 'TemplateAccessPortalUid'
    /// </summary>
    public static string TemplateAccessPortalUid = "TemplateAccessPortalUid";
    /// <summary>
    /// Returns 'CurrentTimeForCluster'
    /// </summary>
    public static string CurrentTimeForCluster = "CurrentTimeForCluster";
    /// <summary>
    /// Returns 'ClusterGroupId'
    /// </summary>
    public static string ClusterGroupId = "ClusterGroupId";
    /// <summary>
    /// Returns 'TotalRowCount'
    /// </summary>
    public static string TotalRowCount = "TotalRowCount";
    /// <summary>
    /// Returns '@PageNumber'
    /// </summary>
    public static string PageNumber = "@PageNumber";
    /// <summary>
    /// Returns '@PageSize'
    /// </summary>
    public static string PageSize = "@PageSize";
    /// <summary>
    /// Returns '@SortColumn'
    /// </summary>
    public static string SortColumn = "@SortColumn";
    /// <summary>
    /// Returns '@DescendingOrder'
    /// </summary>
    public static string DescendingOrder = "@DescendingOrder";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the ClusterPDSA_ByClusterNumberPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@ClusterNumber'
    /// </summary>
    public static string ClusterNumber = "@ClusterNumber";
    /// <summary>
    /// Returns '@PageNumber'
    /// </summary>
    public static string PageNumber = "@PageNumber";
    /// <summary>
    /// Returns '@PageSize'
    /// </summary>
    public static string PageSize = "@PageSize";
    /// <summary>
    /// Returns '@SortColumn'
    /// </summary>
    public static string SortColumn = "@SortColumn";
    /// <summary>
    /// Returns '@DescendingOrder'
    /// </summary>
    public static string DescendingOrder = "@DescendingOrder";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}

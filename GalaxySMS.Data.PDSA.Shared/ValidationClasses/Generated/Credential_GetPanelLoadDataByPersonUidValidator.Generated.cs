using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the Credential_GetPanelLoadDataByPersonUidPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class Credential_GetPanelLoadDataByPersonUidPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private Credential_GetPanelLoadDataByPersonUidPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new Credential_GetPanelLoadDataByPersonUidPDSA Entity
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
    /// Clones the current Credential_GetPanelLoadDataByPersonUidPDSA
    /// </summary>
    /// <returns>A cloned Credential_GetPanelLoadDataByPersonUidPDSA object</returns>
    public Credential_GetPanelLoadDataByPersonUidPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in Credential_GetPanelLoadDataByPersonUidPDSA
    /// </summary>
    /// <param name="entityToClone">The Credential_GetPanelLoadDataByPersonUidPDSA entity to clone</param>
    /// <returns>A cloned Credential_GetPanelLoadDataByPersonUidPDSA object</returns>
    public Credential_GetPanelLoadDataByPersonUidPDSA CloneEntity(Credential_GetPanelLoadDataByPersonUidPDSA entityToClone)
    {
      Credential_GetPanelLoadDataByPersonUidPDSA newEntity = new Credential_GetPanelLoadDataByPersonUidPDSA();

      newEntity.PersonUid = entityToClone.PersonUid;
      newEntity.FirstName = entityToClone.FirstName;
      newEntity.LastName = entityToClone.LastName;
      newEntity.PersonId = entityToClone.PersonId;
      newEntity.PersonActivationDateTime = entityToClone.PersonActivationDateTime;
      newEntity.PersonExpirationDateTime = entityToClone.PersonExpirationDateTime;
      newEntity.PersonTerminationDate = entityToClone.PersonTerminationDate;
      newEntity.VeryImportantPerson = entityToClone.VeryImportantPerson;
      newEntity.HasPhysicalDisability = entityToClone.HasPhysicalDisability;
      newEntity.HasVertigo = entityToClone.HasVertigo;
      newEntity.PersonInactiveState = entityToClone.PersonInactiveState;
      newEntity.PINExempt = entityToClone.PINExempt;
      newEntity.PassbackExempt = entityToClone.PassbackExempt;
      newEntity.CanToggleLockState = entityToClone.CanToggleLockState;
      newEntity.PersonAccessControlPropertiesIsActive = entityToClone.PersonAccessControlPropertiesIsActive;
      newEntity.PIN = entityToClone.PIN;
      newEntity.PersonAccessControlPropertiesAccessProfileUid = entityToClone.PersonAccessControlPropertiesAccessProfileUid;
      newEntity.PersonCredentialUid = entityToClone.PersonCredentialUid;
      newEntity.CredentialUid = entityToClone.CredentialUid;
      newEntity.CredentialActivationDateTime = entityToClone.CredentialActivationDateTime;
      newEntity.CredentialExpirationDateTime = entityToClone.CredentialExpirationDateTime;
      newEntity.CredentialUsageCount = entityToClone.CredentialUsageCount;
      newEntity.DuressEnabled = entityToClone.DuressEnabled;
      newEntity.ReverseBits = entityToClone.ReverseBits;
      newEntity.TraceEnabled = entityToClone.TraceEnabled;
      newEntity.PersonCredentialIsActive = entityToClone.PersonCredentialIsActive;
      newEntity.CredentialRoleCode = entityToClone.CredentialRoleCode;
      newEntity.CredentialActivationModeCode = entityToClone.CredentialActivationModeCode;
      newEntity.CredentialExpirationModeCode = entityToClone.CredentialExpirationModeCode;
      newEntity.NoServerReplyBehaviorCode = entityToClone.NoServerReplyBehaviorCode;
      newEntity.DeferToServerBehaviorCode = entityToClone.DeferToServerBehaviorCode;
      newEntity.LastPanelImpactingChangeDate = entityToClone.LastPanelImpactingChangeDate;
      newEntity.CredentialBits = entityToClone.CredentialBits;
      newEntity.CredentialFormatDisplay = entityToClone.CredentialFormatDisplay;
      newEntity.CredentialFormatCode = entityToClone.CredentialFormatCode;
      newEntity.BitCount = entityToClone.BitCount;
      newEntity.CardBinaryData = entityToClone.CardBinaryData;
      newEntity.CardNumber = entityToClone.CardNumber;
      newEntity.CardNumberIsHex = entityToClone.CardNumberIsHex;
      newEntity.FacCompSiteCode = entityToClone.FacCompSiteCode;
      newEntity.IdCode = entityToClone.IdCode;
      newEntity.IssueCode = entityToClone.IssueCode;
      newEntity.LcdStartingDate = entityToClone.LcdStartingDate;
      newEntity.LcdEndingDate = entityToClone.LcdEndingDate;
      newEntity.LcdMessage = entityToClone.LcdMessage;
      newEntity.LcdMessageDisplayModeCode = entityToClone.LcdMessageDisplayModeCode;
      newEntity.ClusterUid = entityToClone.ClusterUid;
      newEntity.ClusterName = entityToClone.ClusterName;
      newEntity.ClusterGroupId = entityToClone.ClusterGroupId;
      newEntity.ClusterNumber = entityToClone.ClusterNumber;
      newEntity.ClusterTypeCode = entityToClone.ClusterTypeCode;
      newEntity.ClusterIsActive = entityToClone.ClusterIsActive;
      newEntity.CredentialDataLength = entityToClone.CredentialDataLength;
      newEntity.PanelNumber = entityToClone.PanelNumber;
      newEntity.CpuNumber = entityToClone.CpuNumber;
      newEntity.AccessGroup1 = entityToClone.AccessGroup1;
      newEntity.AccessGroup2 = entityToClone.AccessGroup2;
      newEntity.AccessGroup3 = entityToClone.AccessGroup3;
      newEntity.AccessGroup4 = entityToClone.AccessGroup4;
      newEntity.PersonalAccessGroupNumber = entityToClone.PersonalAccessGroupNumber;
      newEntity.InputOutputGroup1 = entityToClone.InputOutputGroup1;
      newEntity.InputOutputGroup2 = entityToClone.InputOutputGroup2;
      newEntity.InputOutputGroup3 = entityToClone.InputOutputGroup3;
      newEntity.InputOutputGroup4 = entityToClone.InputOutputGroup4;
      newEntity.OtisSplitGroupOperation = entityToClone.OtisSplitGroupOperation;
      newEntity.OtisCimOverride = entityToClone.OtisCimOverride;
      newEntity.CpuUid = entityToClone.CpuUid;
      newEntity.ServerAddress = entityToClone.ServerAddress;
      newEntity.IsConnected = entityToClone.IsConnected;

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
      
      props.Add(PDSAProperty.Create(Credential_GetPanelLoadDataByPersonUidPDSAValidator.ParameterNames.PersonUid, GetResourceMessage("GCS_Credential_GetPanelLoadDataByPersonUidPDSA_PersonUid_Header", "Person Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_Credential_GetPanelLoadDataByPersonUidPDSA_PersonUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(Credential_GetPanelLoadDataByPersonUidPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_Credential_GetPanelLoadDataByPersonUidPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_Credential_GetPanelLoadDataByPersonUidPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(Credential_GetPanelLoadDataByPersonUidPDSAValidator.ParameterNames.PersonUid).Value = Entity.PersonUid;
      this.Properties.GetByName(Credential_GetPanelLoadDataByPersonUidPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(Credential_GetPanelLoadDataByPersonUidPDSAValidator.ParameterNames.PersonUid).IsNull == false)
        Entity.PersonUid = this.Properties.GetByName(Credential_GetPanelLoadDataByPersonUidPDSAValidator.ParameterNames.PersonUid).GetAsGuid();
      if(this.Properties.GetByName(Credential_GetPanelLoadDataByPersonUidPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(Credential_GetPanelLoadDataByPersonUidPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the Credential_GetPanelLoadDataByPersonUidPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'PersonUid'
    /// </summary>
    public static string PersonUid = "PersonUid";
    /// <summary>
    /// Returns 'FirstName'
    /// </summary>
    public static string FirstName = "FirstName";
    /// <summary>
    /// Returns 'LastName'
    /// </summary>
    public static string LastName = "LastName";
    /// <summary>
    /// Returns 'PersonId'
    /// </summary>
    public static string PersonId = "PersonId";
    /// <summary>
    /// Returns 'PersonActivationDateTime'
    /// </summary>
    public static string PersonActivationDateTime = "PersonActivationDateTime";
    /// <summary>
    /// Returns 'PersonExpirationDateTime'
    /// </summary>
    public static string PersonExpirationDateTime = "PersonExpirationDateTime";
    /// <summary>
    /// Returns 'PersonTerminationDate'
    /// </summary>
    public static string PersonTerminationDate = "PersonTerminationDate";
    /// <summary>
    /// Returns 'VeryImportantPerson'
    /// </summary>
    public static string VeryImportantPerson = "VeryImportantPerson";
    /// <summary>
    /// Returns 'HasPhysicalDisability'
    /// </summary>
    public static string HasPhysicalDisability = "HasPhysicalDisability";
    /// <summary>
    /// Returns 'HasVertigo'
    /// </summary>
    public static string HasVertigo = "HasVertigo";
    /// <summary>
    /// Returns 'PersonInactiveState'
    /// </summary>
    public static string PersonInactiveState = "PersonInactiveState";
    /// <summary>
    /// Returns 'PINExempt'
    /// </summary>
    public static string PINExempt = "PINExempt";
    /// <summary>
    /// Returns 'PassbackExempt'
    /// </summary>
    public static string PassbackExempt = "PassbackExempt";
    /// <summary>
    /// Returns 'CanToggleLockState'
    /// </summary>
    public static string CanToggleLockState = "CanToggleLockState";
    /// <summary>
    /// Returns 'PersonAccessControlPropertiesIsActive'
    /// </summary>
    public static string PersonAccessControlPropertiesIsActive = "PersonAccessControlPropertiesIsActive";
    /// <summary>
    /// Returns 'PIN'
    /// </summary>
    public static string PIN = "PIN";
    /// <summary>
    /// Returns 'PersonAccessControlPropertiesAccessProfileUid'
    /// </summary>
    public static string PersonAccessControlPropertiesAccessProfileUid = "PersonAccessControlPropertiesAccessProfileUid";
    /// <summary>
    /// Returns 'PersonCredentialUid'
    /// </summary>
    public static string PersonCredentialUid = "PersonCredentialUid";
    /// <summary>
    /// Returns 'CredentialUid'
    /// </summary>
    public static string CredentialUid = "CredentialUid";
    /// <summary>
    /// Returns 'CredentialActivationDateTime'
    /// </summary>
    public static string CredentialActivationDateTime = "CredentialActivationDateTime";
    /// <summary>
    /// Returns 'CredentialExpirationDateTime'
    /// </summary>
    public static string CredentialExpirationDateTime = "CredentialExpirationDateTime";
    /// <summary>
    /// Returns 'CredentialUsageCount'
    /// </summary>
    public static string CredentialUsageCount = "CredentialUsageCount";
    /// <summary>
    /// Returns 'DuressEnabled'
    /// </summary>
    public static string DuressEnabled = "DuressEnabled";
    /// <summary>
    /// Returns 'ReverseBits'
    /// </summary>
    public static string ReverseBits = "ReverseBits";
    /// <summary>
    /// Returns 'TraceEnabled'
    /// </summary>
    public static string TraceEnabled = "TraceEnabled";
    /// <summary>
    /// Returns 'PersonCredentialIsActive'
    /// </summary>
    public static string PersonCredentialIsActive = "PersonCredentialIsActive";
    /// <summary>
    /// Returns 'CredentialRoleCode'
    /// </summary>
    public static string CredentialRoleCode = "CredentialRoleCode";
    /// <summary>
    /// Returns 'CredentialActivationModeCode'
    /// </summary>
    public static string CredentialActivationModeCode = "CredentialActivationModeCode";
    /// <summary>
    /// Returns 'CredentialExpirationModeCode'
    /// </summary>
    public static string CredentialExpirationModeCode = "CredentialExpirationModeCode";
    /// <summary>
    /// Returns 'NoServerReplyBehaviorCode'
    /// </summary>
    public static string NoServerReplyBehaviorCode = "NoServerReplyBehaviorCode";
    /// <summary>
    /// Returns 'DeferToServerBehaviorCode'
    /// </summary>
    public static string DeferToServerBehaviorCode = "DeferToServerBehaviorCode";
    /// <summary>
    /// Returns 'LastPanelImpactingChangeDate'
    /// </summary>
    public static string LastPanelImpactingChangeDate = "LastPanelImpactingChangeDate";
    /// <summary>
    /// Returns 'CredentialBits'
    /// </summary>
    public static string CredentialBits = "CredentialBits";
    /// <summary>
    /// Returns 'CredentialFormatDisplay'
    /// </summary>
    public static string CredentialFormatDisplay = "CredentialFormatDisplay";
    /// <summary>
    /// Returns 'CredentialFormatCode'
    /// </summary>
    public static string CredentialFormatCode = "CredentialFormatCode";
    /// <summary>
    /// Returns 'BitCount'
    /// </summary>
    public static string BitCount = "BitCount";
    /// <summary>
    /// Returns 'CardBinaryData'
    /// </summary>
    public static string CardBinaryData = "CardBinaryData";
    /// <summary>
    /// Returns 'CardNumber'
    /// </summary>
    public static string CardNumber = "CardNumber";
    /// <summary>
    /// Returns 'CardNumberIsHex'
    /// </summary>
    public static string CardNumberIsHex = "CardNumberIsHex";
    /// <summary>
    /// Returns 'FacCompSiteCode'
    /// </summary>
    public static string FacCompSiteCode = "FacCompSiteCode";
    /// <summary>
    /// Returns 'IdCode'
    /// </summary>
    public static string IdCode = "IdCode";
    /// <summary>
    /// Returns 'IssueCode'
    /// </summary>
    public static string IssueCode = "IssueCode";
    /// <summary>
    /// Returns 'LcdStartingDate'
    /// </summary>
    public static string LcdStartingDate = "LcdStartingDate";
    /// <summary>
    /// Returns 'LcdEndingDate'
    /// </summary>
    public static string LcdEndingDate = "LcdEndingDate";
    /// <summary>
    /// Returns 'LcdMessage'
    /// </summary>
    public static string LcdMessage = "LcdMessage";
    /// <summary>
    /// Returns 'LcdMessageDisplayModeCode'
    /// </summary>
    public static string LcdMessageDisplayModeCode = "LcdMessageDisplayModeCode";
    /// <summary>
    /// Returns 'ClusterUid'
    /// </summary>
    public static string ClusterUid = "ClusterUid";
    /// <summary>
    /// Returns 'ClusterName'
    /// </summary>
    public static string ClusterName = "ClusterName";
    /// <summary>
    /// Returns 'ClusterGroupId'
    /// </summary>
    public static string ClusterGroupId = "ClusterGroupId";
    /// <summary>
    /// Returns 'ClusterNumber'
    /// </summary>
    public static string ClusterNumber = "ClusterNumber";
    /// <summary>
    /// Returns 'ClusterTypeCode'
    /// </summary>
    public static string ClusterTypeCode = "ClusterTypeCode";
    /// <summary>
    /// Returns 'ClusterIsActive'
    /// </summary>
    public static string ClusterIsActive = "ClusterIsActive";
    /// <summary>
    /// Returns 'CredentialDataLength'
    /// </summary>
    public static string CredentialDataLength = "CredentialDataLength";
    /// <summary>
    /// Returns 'PanelNumber'
    /// </summary>
    public static string PanelNumber = "PanelNumber";
    /// <summary>
    /// Returns 'CpuNumber'
    /// </summary>
    public static string CpuNumber = "CpuNumber";
    /// <summary>
    /// Returns 'AccessGroup1'
    /// </summary>
    public static string AccessGroup1 = "AccessGroup1";
    /// <summary>
    /// Returns 'AccessGroup2'
    /// </summary>
    public static string AccessGroup2 = "AccessGroup2";
    /// <summary>
    /// Returns 'AccessGroup3'
    /// </summary>
    public static string AccessGroup3 = "AccessGroup3";
    /// <summary>
    /// Returns 'AccessGroup4'
    /// </summary>
    public static string AccessGroup4 = "AccessGroup4";
    /// <summary>
    /// Returns 'PersonalAccessGroupNumber'
    /// </summary>
    public static string PersonalAccessGroupNumber = "PersonalAccessGroupNumber";
    /// <summary>
    /// Returns 'InputOutputGroup1'
    /// </summary>
    public static string InputOutputGroup1 = "InputOutputGroup1";
    /// <summary>
    /// Returns 'InputOutputGroup2'
    /// </summary>
    public static string InputOutputGroup2 = "InputOutputGroup2";
    /// <summary>
    /// Returns 'InputOutputGroup3'
    /// </summary>
    public static string InputOutputGroup3 = "InputOutputGroup3";
    /// <summary>
    /// Returns 'InputOutputGroup4'
    /// </summary>
    public static string InputOutputGroup4 = "InputOutputGroup4";
    /// <summary>
    /// Returns 'OtisSplitGroupOperation'
    /// </summary>
    public static string OtisSplitGroupOperation = "OtisSplitGroupOperation";
    /// <summary>
    /// Returns 'OtisCimOverride'
    /// </summary>
    public static string OtisCimOverride = "OtisCimOverride";
    /// <summary>
    /// Returns 'CpuUid'
    /// </summary>
    public static string CpuUid = "CpuUid";
    /// <summary>
    /// Returns 'ServerAddress'
    /// </summary>
    public static string ServerAddress = "ServerAddress";
    /// <summary>
    /// Returns 'IsConnected'
    /// </summary>
    public static string IsConnected = "IsConnected";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the Credential_GetPanelLoadDataByPersonUidPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@PersonUid'
    /// </summary>
    public static string PersonUid = "@PersonUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}

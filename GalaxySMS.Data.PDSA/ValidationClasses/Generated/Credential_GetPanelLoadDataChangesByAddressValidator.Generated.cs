using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the Credential_GetPanelLoadDataChangesByAddressPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class Credential_GetPanelLoadDataChangesByAddressPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private Credential_GetPanelLoadDataChangesByAddressPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new Credential_GetPanelLoadDataChangesByAddressPDSA Entity
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
    /// Clones the current Credential_GetPanelLoadDataChangesByAddressPDSA
    /// </summary>
    /// <returns>A cloned Credential_GetPanelLoadDataChangesByAddressPDSA object</returns>
    public Credential_GetPanelLoadDataChangesByAddressPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in Credential_GetPanelLoadDataChangesByAddressPDSA
    /// </summary>
    /// <param name="entityToClone">The Credential_GetPanelLoadDataChangesByAddressPDSA entity to clone</param>
    /// <returns>A cloned Credential_GetPanelLoadDataChangesByAddressPDSA object</returns>
    public Credential_GetPanelLoadDataChangesByAddressPDSA CloneEntity(Credential_GetPanelLoadDataChangesByAddressPDSA entityToClone)
    {
      Credential_GetPanelLoadDataChangesByAddressPDSA newEntity = new Credential_GetPanelLoadDataChangesByAddressPDSA();

      newEntity.CredentialToLoadToCpuUid = entityToClone.CredentialToLoadToCpuUid;
      newEntity.LastCredentialChangeDate = entityToClone.LastCredentialChangeDate;
      newEntity.LastCredentialLoadedDate = entityToClone.LastCredentialLoadedDate;
      newEntity.LastPanelImpactingChangeDate = entityToClone.LastPanelImpactingChangeDate;
      newEntity.CpuUid = entityToClone.CpuUid;
      newEntity.PersonUid = entityToClone.PersonUid;
      newEntity.FirstName = entityToClone.FirstName;
      newEntity.LastName = entityToClone.LastName;
      newEntity.PersonId = entityToClone.PersonId;
      newEntity.PersonActivationDateTime = entityToClone.PersonActivationDateTime;
      newEntity.PersonExpirationDateTime = entityToClone.PersonExpirationDateTime;
      newEntity.PersonEmploymentDate = entityToClone.PersonEmploymentDate;
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
      newEntity.TimeZoneId = entityToClone.TimeZoneId;
      newEntity.CurrentTimeForCluster = entityToClone.CurrentTimeForCluster;
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
      
      props.Add(PDSAProperty.Create(Credential_GetPanelLoadDataChangesByAddressPDSAValidator.ParameterNames.ClusterNumber, GetResourceMessage("GCS_Credential_GetPanelLoadDataChangesByAddressPDSA_ClusterNumber_Header", "Cluster Number"), false, typeof(int), 0, GetResourceMessage("GCS_Credential_GetPanelLoadDataChangesByAddressPDSA_ClusterNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(Credential_GetPanelLoadDataChangesByAddressPDSAValidator.ParameterNames.PanelNumber, GetResourceMessage("GCS_Credential_GetPanelLoadDataChangesByAddressPDSA_PanelNumber_Header", "Panel Number"), false, typeof(int), 0, GetResourceMessage("GCS_Credential_GetPanelLoadDataChangesByAddressPDSA_PanelNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(Credential_GetPanelLoadDataChangesByAddressPDSAValidator.ParameterNames.CpuNumber, GetResourceMessage("GCS_Credential_GetPanelLoadDataChangesByAddressPDSA_CpuNumber_Header", "Cpu Number"), false, typeof(short), 0, GetResourceMessage("GCS_Credential_GetPanelLoadDataChangesByAddressPDSA_CpuNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt16("-32768"), Convert.ToInt16("32767"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(Credential_GetPanelLoadDataChangesByAddressPDSAValidator.ParameterNames.ClusterGroupId, GetResourceMessage("GCS_Credential_GetPanelLoadDataChangesByAddressPDSA_ClusterGroupId_Header", "Cluster Group Id"), false, typeof(int), 0, GetResourceMessage("GCS_Credential_GetPanelLoadDataChangesByAddressPDSA_ClusterGroupId_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(Credential_GetPanelLoadDataChangesByAddressPDSAValidator.ParameterNames.ServerAddress, GetResourceMessage("GCS_Credential_GetPanelLoadDataChangesByAddressPDSA_ServerAddress_Header", "Server Address"), false, typeof(string), 8000, GetResourceMessage("GCS_Credential_GetPanelLoadDataChangesByAddressPDSA_ServerAddress_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(Credential_GetPanelLoadDataChangesByAddressPDSAValidator.ParameterNames.IsConnected, GetResourceMessage("GCS_Credential_GetPanelLoadDataChangesByAddressPDSA_IsConnected_Header", "Is Connected"), false, typeof(bool), 0, GetResourceMessage("GCS_Credential_GetPanelLoadDataChangesByAddressPDSA_IsConnected_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, false, @"", ""));
      props.Add(PDSAProperty.Create(Credential_GetPanelLoadDataChangesByAddressPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_Credential_GetPanelLoadDataChangesByAddressPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_Credential_GetPanelLoadDataChangesByAddressPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(Credential_GetPanelLoadDataChangesByAddressPDSAValidator.ParameterNames.ClusterNumber).Value = Entity.ClusterNumber;
      this.Properties.GetByName(Credential_GetPanelLoadDataChangesByAddressPDSAValidator.ParameterNames.PanelNumber).Value = Entity.PanelNumber;
      this.Properties.GetByName(Credential_GetPanelLoadDataChangesByAddressPDSAValidator.ParameterNames.CpuNumber).Value = Entity.CpuNumber;
      this.Properties.GetByName(Credential_GetPanelLoadDataChangesByAddressPDSAValidator.ParameterNames.ClusterGroupId).Value = Entity.ClusterGroupId;
      this.Properties.GetByName(Credential_GetPanelLoadDataChangesByAddressPDSAValidator.ParameterNames.ServerAddress).Value = Entity.ServerAddress;
      this.Properties.GetByName(Credential_GetPanelLoadDataChangesByAddressPDSAValidator.ParameterNames.IsConnected).Value = Entity.IsConnected;
      this.Properties.GetByName(Credential_GetPanelLoadDataChangesByAddressPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(Credential_GetPanelLoadDataChangesByAddressPDSAValidator.ParameterNames.ClusterNumber).IsNull == false)
        Entity.ClusterNumber = this.Properties.GetByName(Credential_GetPanelLoadDataChangesByAddressPDSAValidator.ParameterNames.ClusterNumber).GetAsInteger();
      if(this.Properties.GetByName(Credential_GetPanelLoadDataChangesByAddressPDSAValidator.ParameterNames.PanelNumber).IsNull == false)
        Entity.PanelNumber = this.Properties.GetByName(Credential_GetPanelLoadDataChangesByAddressPDSAValidator.ParameterNames.PanelNumber).GetAsInteger();
      if(this.Properties.GetByName(Credential_GetPanelLoadDataChangesByAddressPDSAValidator.ParameterNames.CpuNumber).IsNull == false)
        Entity.CpuNumber = this.Properties.GetByName(Credential_GetPanelLoadDataChangesByAddressPDSAValidator.ParameterNames.CpuNumber).GetAsShort();
      if(this.Properties.GetByName(Credential_GetPanelLoadDataChangesByAddressPDSAValidator.ParameterNames.ClusterGroupId).IsNull == false)
        Entity.ClusterGroupId = this.Properties.GetByName(Credential_GetPanelLoadDataChangesByAddressPDSAValidator.ParameterNames.ClusterGroupId).GetAsInteger();
      if(this.Properties.GetByName(Credential_GetPanelLoadDataChangesByAddressPDSAValidator.ParameterNames.ServerAddress).IsNull == false)
        Entity.ServerAddress = this.Properties.GetByName(Credential_GetPanelLoadDataChangesByAddressPDSAValidator.ParameterNames.ServerAddress).GetAsString();
      if(this.Properties.GetByName(Credential_GetPanelLoadDataChangesByAddressPDSAValidator.ParameterNames.IsConnected).IsNull == false)
        Entity.IsConnected = this.Properties.GetByName(Credential_GetPanelLoadDataChangesByAddressPDSAValidator.ParameterNames.IsConnected).GetAsBool();
      if(this.Properties.GetByName(Credential_GetPanelLoadDataChangesByAddressPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(Credential_GetPanelLoadDataChangesByAddressPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the Credential_GetPanelLoadDataChangesByAddressPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'CredentialToLoadToCpuUid'
    /// </summary>
    public static string CredentialToLoadToCpuUid = "CredentialToLoadToCpuUid";
    /// <summary>
    /// Returns 'LastCredentialChangeDate'
    /// </summary>
    public static string LastCredentialChangeDate = "LastCredentialChangeDate";
    /// <summary>
    /// Returns 'LastCredentialLoadedDate'
    /// </summary>
    public static string LastCredentialLoadedDate = "LastCredentialLoadedDate";
    /// <summary>
    /// Returns 'LastPanelImpactingChangeDate'
    /// </summary>
    public static string LastPanelImpactingChangeDate = "LastPanelImpactingChangeDate";
    /// <summary>
    /// Returns 'CpuUid'
    /// </summary>
    public static string CpuUid = "CpuUid";
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
    /// Returns 'PersonEmploymentDate'
    /// </summary>
    public static string PersonEmploymentDate = "PersonEmploymentDate";
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
    /// Returns 'TimeZoneId'
    /// </summary>
    public static string TimeZoneId = "TimeZoneId";
    /// <summary>
    /// Returns 'CurrentTimeForCluster'
    /// </summary>
    public static string CurrentTimeForCluster = "CurrentTimeForCluster";
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
    /// Contains static string properties that represent the name of each property in the Credential_GetPanelLoadDataChangesByAddressPDSA class.
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
    /// Returns '@PanelNumber'
    /// </summary>
    public static string PanelNumber = "@PanelNumber";
    /// <summary>
    /// Returns '@CpuNumber'
    /// </summary>
    public static string CpuNumber = "@CpuNumber";
    /// <summary>
    /// Returns '@ClusterGroupId'
    /// </summary>
    public static string ClusterGroupId = "@ClusterGroupId";
    /// <summary>
    /// Returns '@ServerAddress'
    /// </summary>
    public static string ServerAddress = "@ServerAddress";
    /// <summary>
    /// Returns '@IsConnected'
    /// </summary>
    public static string IsConnected = "@IsConnected";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}

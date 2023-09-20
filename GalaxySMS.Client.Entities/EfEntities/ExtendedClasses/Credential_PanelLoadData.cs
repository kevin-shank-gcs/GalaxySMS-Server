namespace GalaxySMS.Client.Entities
{
    public partial class Credential_PanelLoadData
    {
        public Credential_PanelLoadData() : base()
        {
            Initialize();
        }

        public Credential_PanelLoadData(Credential_PanelLoadData e) : base(e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            base.Initialize();
        }

        public void Initialize(Credential_PanelLoadData e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.PersonUid = e.PersonUid;
            this.FirstName = e.FirstName;
            this.LastName = e.LastName;
            this.PersonId = e.PersonId;
            this.PersonActivationDateTime = e.PersonActivationDateTime;
            this.PersonExpirationDateTime = e.PersonExpirationDateTime;
            this.PersonEmploymentDate = e.PersonEmploymentDate;
            this.PersonTerminationDate = e.PersonTerminationDate;
            this.VeryImportantPerson = e.VeryImportantPerson;
            this.HasPhysicalDisability = e.HasPhysicalDisability;
            this.HasVertigo = e.HasVertigo;
            this.PersonInactiveState = e.PersonInactiveState;
            this.PINExempt = e.PINExempt;
            this.PassbackExempt = e.PassbackExempt;
            this.CanToggleLockState = e.CanToggleLockState;
            this.PersonAccessControlPropertiesIsActive = e.PersonAccessControlPropertiesIsActive;
            this.PIN = e.PIN;
            this.PersonAccessControlPropertiesAccessProfileUid = e.PersonAccessControlPropertiesAccessProfileUid;
            this.PersonCredentialUid = e.PersonCredentialUid;
            this.CredentialUid = e.CredentialUid;
            this.CredentialActivationDateTime = e.CredentialActivationDateTime;
            this.CredentialExpirationDateTime = e.CredentialExpirationDateTime;
            this.CredentialUsageCount = e.CredentialUsageCount;
            this.DuressEnabled = e.DuressEnabled;
            this.ReverseBits = e.ReverseBits;
            this.TraceEnabled = e.TraceEnabled;
            this.PersonCredentialIsActive = e.PersonCredentialIsActive;
            this.CredentialRoleCode = e.CredentialRoleCode;
            this.CredentialActivationModeCode = e.CredentialActivationModeCode;
            this.CredentialExpirationModeCode = e.CredentialExpirationModeCode;
            this.NoServerReplyBehaviorCode = e.NoServerReplyBehaviorCode;
            this.DeferToServerBehaviorCode = e.DeferToServerBehaviorCode;
            this.LastPanelImpactingChangeDate = e.LastPanelImpactingChangeDate;
            this.CredentialBits = e.CredentialBits;
            this.CredentialFormatDisplay = e.CredentialFormatDisplay;
            this.CredentialFormatCode = e.CredentialFormatCode;
            this.BitCount = e.BitCount;
            this.CardBinaryData = e.CardBinaryData;
            this.CardNumber = e.CardNumber;
            this.CardNumberIsHex = e.CardNumberIsHex;
            this.FacCompSiteCode = e.FacCompSiteCode;
            this.IdCode = e.IdCode;
            this.IssueCode = e.IssueCode;
            this.LcdStartingDate = e.LcdStartingDate;
            this.LcdEndingDate = e.LcdEndingDate;
            this.LcdMessage = e.LcdMessage;
            this.LcdMessageDisplayModeCode = e.LcdMessageDisplayModeCode;
            this.ClusterUid = e.ClusterUid;
            this.ClusterName = e.ClusterName;
            this.ClusterGroupId = e.ClusterGroupId;
            this.ClusterNumber = e.ClusterNumber;
            this.ClusterTypeCode = e.ClusterTypeCode;
            this.ClusterIsActive = e.ClusterIsActive;
            this.CredentialDataLength = e.CredentialDataLength;
            this.PanelNumber = e.PanelNumber;
            this.CpuNumber = e.CpuNumber;
            this.AccessGroup1 = e.AccessGroup1;
            this.AccessGroup2 = e.AccessGroup2;
            this.AccessGroup3 = e.AccessGroup3;
            this.AccessGroup4 = e.AccessGroup4;
            this.PersonalAccessGroupNumber = e.PersonalAccessGroupNumber;
            this.InputOutputGroup1 = e.InputOutputGroup1;
            this.InputOutputGroup2 = e.InputOutputGroup2;
            this.InputOutputGroup3 = e.InputOutputGroup3;
            this.InputOutputGroup4 = e.InputOutputGroup4;
            this.OtisSplitGroupOperation = e.OtisSplitGroupOperation;
            this.OtisCimOverride = e.OtisCimOverride;
            this.CpuUid = e.CpuUid;
            this.ServerAddress = e.ServerAddress;
            this.IsConnected = e.IsConnected;

        }

        public Credential_PanelLoadData Clone(Credential_PanelLoadData e)
        {
            return new Credential_PanelLoadData(e);
        }

        public bool Equals(Credential_PanelLoadData other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(Credential_PanelLoadData other)
        {
            if (other == null)
                return false;

            if (other.PersonUid != this.PersonUid)
                return false;
            if (other.PersonId != this.PersonId)
                return false;
            if (other.VeryImportantPerson != this.VeryImportantPerson)
                return false;
            if (other.HasPhysicalDisability != this.HasPhysicalDisability)
                return false;
            if (other.HasVertigo != this.HasVertigo)
                return false;
            if (other.PersonInactiveState != this.PersonInactiveState)
                return false;
            if (other.PINExempt != this.PINExempt)
                return false;
            if (other.PassbackExempt != this.PassbackExempt)
                return false;
            if (other.CanToggleLockState != this.CanToggleLockState)
                return false;
            if (other.PersonAccessControlPropertiesIsActive != this.PersonAccessControlPropertiesIsActive)
                return false;
            if (other.PersonAccessControlPropertiesAccessProfileUid != this.PersonAccessControlPropertiesAccessProfileUid)
                return false;
            if (other.PersonCredentialUid != this.PersonCredentialUid)
                return false;
            if (other.CredentialUid != this.CredentialUid)
                return false;
            if (other.CredentialUsageCount != this.CredentialUsageCount)
                return false;
            if (other.DuressEnabled != this.DuressEnabled)
                return false;
            if (other.ReverseBits != this.ReverseBits)
                return false;
            if (other.TraceEnabled != this.TraceEnabled)
                return false;
            if (other.PersonCredentialIsActive != this.PersonCredentialIsActive)
                return false;
            if (other.CredentialRoleCode != this.CredentialRoleCode)
                return false;
            if (other.CredentialActivationModeCode != this.CredentialActivationModeCode)
                return false;
            if (other.CredentialExpirationModeCode != this.CredentialExpirationModeCode)
                return false;
            if (other.NoServerReplyBehaviorCode != this.NoServerReplyBehaviorCode)
                return false;
            if (other.DeferToServerBehaviorCode != this.DeferToServerBehaviorCode)
                return false;
            if (other.LastPanelImpactingChangeDate != this.LastPanelImpactingChangeDate)
                return false;
            if (other.CredentialBits != this.CredentialBits)
                return false;
            if (other.CredentialFormatDisplay != this.CredentialFormatDisplay)
                return false;
            if (other.CredentialFormatCode != this.CredentialFormatCode)
                return false;
            if (other.BitCount != this.BitCount)
                return false;
            if (other.CardBinaryData != this.CardBinaryData)
                return false;
            if (other.CardNumber != this.CardNumber)
                return false;
            if (other.CardNumberIsHex != this.CardNumberIsHex)
                return false;
            if (other.LcdStartingDate != this.LcdStartingDate)
                return false;
            if (other.LcdEndingDate != this.LcdEndingDate)
                return false;
            if (other.LcdMessage != this.LcdMessage)
                return false;
            if (other.LcdMessageDisplayModeCode != this.LcdMessageDisplayModeCode)
                return false;
            if (other.ClusterUid != this.ClusterUid)
                return false;
            if (other.ClusterName != this.ClusterName)
                return false;
            if (other.ClusterNumber != this.ClusterNumber)
                return false;
            if (other.ClusterTypeCode != this.ClusterTypeCode)
                return false;
            if (other.ClusterIsActive != this.ClusterIsActive)
                return false;
            if (other.CredentialDataLength != this.CredentialDataLength)
                return false;
            if (other.PanelNumber != this.PanelNumber)
                return false;
            if (other.CpuNumber != this.CpuNumber)
                return false;
            if (other.OtisSplitGroupOperation != this.OtisSplitGroupOperation)
                return false;
            if (other.OtisCimOverride != this.OtisCimOverride)
                return false;
            if (other.CpuUid != this.CpuUid)
                return false;
            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}

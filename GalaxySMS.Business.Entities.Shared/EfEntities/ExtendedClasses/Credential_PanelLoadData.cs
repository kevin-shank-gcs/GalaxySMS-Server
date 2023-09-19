using System;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{

    public partial class Credential_PanelLoadData
    {
        public Credential_PanelLoadData()
        {
            Initialize();
        }

        public Credential_PanelLoadData(Credential_PanelLoadData e)
        {
            Initialize(e);
        }

        public void Initialize()
        {

        }

        public void Initialize(Credential_PanelLoadData e)
        {
            Initialize();
            if (e == null)
                return;
            PersonUid = e.PersonUid;
            FirstName = e.FirstName;
            LastName = e.LastName;
            PersonId = e.PersonId;
            PersonActivationDateTime = e.PersonActivationDateTime;
            PersonExpirationDateTime = e.PersonExpirationDateTime;
            PersonEmploymentDate = e.PersonEmploymentDate;
            PersonTerminationDate = e.PersonTerminationDate;
            VeryImportantPerson = e.VeryImportantPerson;
            HasPhysicalDisability = e.HasPhysicalDisability;
            HasVertigo = e.HasVertigo;
            PersonInactiveState = e.PersonInactiveState;
            PINExempt = e.PINExempt;
            PassbackExempt = e.PassbackExempt;
            CanToggleLockState = e.CanToggleLockState;
            PersonAccessControlPropertiesIsActive = e.PersonAccessControlPropertiesIsActive;
            PIN = e.PIN;
            PersonAccessControlPropertiesAccessProfileUid = e.PersonAccessControlPropertiesAccessProfileUid;
            PersonCredentialUid = e.PersonCredentialUid;
            CredentialUid = e.CredentialUid;
            CredentialActivationDateTime = e.CredentialActivationDateTime;
            CredentialExpirationDateTime = e.CredentialExpirationDateTime;
            CredentialUsageCount = e.CredentialUsageCount;
            DuressEnabled = e.DuressEnabled;
            ReverseBits = e.ReverseBits;
            TraceEnabled = e.TraceEnabled;
            PersonCredentialIsActive = e.PersonCredentialIsActive;
            CredentialRoleCode = e.CredentialRoleCode;
            CredentialActivationModeCode = e.CredentialActivationModeCode;
            CredentialExpirationModeCode = e.CredentialExpirationModeCode;
            NoServerReplyBehaviorCode = e.NoServerReplyBehaviorCode;
            DeferToServerBehaviorCode = e.DeferToServerBehaviorCode;
            LastPanelImpactingChangeDate = e.LastPanelImpactingChangeDate;
            CredentialBits = e.CredentialBits;
            CredentialFormatDisplay = e.CredentialFormatDisplay;
            CredentialFormatCode = e.CredentialFormatCode;
            BitCount = e.BitCount;
            CardBinaryData = e.CardBinaryData;
            CardNumber = e.CardNumber;
            CardNumberIsHex = e.CardNumberIsHex;
            FacCompSiteCode = e.FacCompSiteCode;
            IdCode = e.IdCode;
            IssueCode = e.IssueCode;
            LcdStartingDate = e.LcdStartingDate;
            LcdEndingDate = e.LcdEndingDate;
            LcdMessage = e.LcdMessage;
            LcdMessageDisplayModeCode = e.LcdMessageDisplayModeCode;
            ClusterUid = e.ClusterUid;
            ClusterName = e.ClusterName;
            ClusterGroupId = e.ClusterGroupId;
            ClusterNumber = e.ClusterNumber;
            ClusterTypeCode = e.ClusterTypeCode;
            ClusterIsActive = e.ClusterIsActive;
            CredentialDataLength = e.CredentialDataLength;
            PanelNumber = e.PanelNumber;
            CpuNumber = e.CpuNumber;
            AccessGroup1 = e.AccessGroup1;
            AccessGroup2 = e.AccessGroup2;
            AccessGroup3 = e.AccessGroup3;
            AccessGroup4 = e.AccessGroup4;
            PersonalAccessGroupNumber = e.PersonalAccessGroupNumber;
            InputOutputGroup1 = e.InputOutputGroup1;
            InputOutputGroup2 = e.InputOutputGroup2;
            InputOutputGroup3 = e.InputOutputGroup3;
            InputOutputGroup4 = e.InputOutputGroup4;
            OtisSplitGroupOperation = e.OtisSplitGroupOperation;
            OtisCimOverride = e.OtisCimOverride;
            CpuUid = e.CpuUid;
            ServerAddress = e.ServerAddress;
            IsConnected = e.IsConnected;
            OperationUid = e.OperationUid;
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

            if (other.PersonCredentialUid != this.PersonCredentialUid)
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

        public Guid OperationUid { get; set; }  
    }
}

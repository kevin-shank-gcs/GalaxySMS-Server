using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Common.Enums;
using GCS.Core.Common.Core;

namespace GalaxySMS.Business.Entities
{
    /// <summary>
    /// This class contains properties for each data value that makes up a Credential_PanelLoadDataPDSA.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>

    public partial class Credential_PanelLoadData : ObjectBase
    {
        #region Public Properties
        public Guid PersonUid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonId { get; set; }
        public DateTimeOffset PersonActivationDateTime { get; set; }
        public DateTimeOffset PersonExpirationDateTime { get; set; }
        public DateTimeOffset PersonTerminationDate { get; set; }
        public bool VeryImportantPerson { get; set; }
        public bool HasPhysicalDisability { get; set; }
        public bool HasVertigo { get; set; }
        public bool PersonInactiveState { get; set; }
        public bool PINExempt { get; set; }
        public bool PassbackExempt { get; set; }
        public bool CanToggleLockState { get; set; }
        public bool PersonAccessControlPropertiesIsActive { get; set; }
        public int PIN { get; set; }
        public Guid PersonAccessControlPropertiesAccessProfileUid { get; set; }
        public Guid PersonCredentialUid { get; set; }
        public Guid CredentialUid { get; set; }
        public DateTimeOffset CredentialActivationDateTime { get; set; }
        public DateTimeOffset CredentialExpirationDateTime { get; set; }
        public short CredentialUsageCount { get; set; }
        public bool DuressEnabled { get; set; }
        public bool ReverseBits { get; set; }
        public bool TraceEnabled { get; set; }
        public bool PersonCredentialIsActive { get; set; }

        //public short CredentialRoleCode { get; set; }
        public PersonCredentialRoles CredentialRoleCode { get; set; }
//        public short CredentialActivationModeCode { get; set; }
        public PersonActivationModes CredentialActivationModeCode { get; set; }
//        public short CredentialExpirationModeCode { get; set; }
        public PersonExpirationModes CredentialExpirationModeCode { get; set; }
//        public short NoServerReplyBehaviorCode { get; set; }
        public GalaxySMS.Common.Enums.AccessPortalNoServerReplyBehavior NoServerReplyBehaviorCode { get; set; }
//        public short DeferToServerBehaviorCode { get; set; }
        public GalaxySMS.Common.Enums.AccessPortalDeferToServerBehavior DeferToServerBehaviorCode { get; set; }
        public DateTimeOffset LastPanelImpactingChangeDate { get; set; }
        public byte[] CredentialBits { get; set; }
        public string CredentialFormatDisplay { get; set; }
        public short CredentialFormatCode { get; set; }
        public short BitCount { get; set; }
        public byte[] CardBinaryData { get; set; }
        public string CardNumber { get; set; }
        public bool CardNumberIsHex { get; set; }
        public long FacCompSiteCode { get; set; }
        public long IdCode { get; set; }
        public long IssueCode { get; set; }
        public DateTimeOffset LcdStartingDate { get; set; }
        public DateTimeOffset LcdEndingDate { get; set; }
        public string LcdMessage { get; set; }
        public short LcdMessageDisplayModeCode { get; set; }
        public Guid ClusterUid { get; set; }
        public string ClusterName { get; set; }
        public int ClusterGroupId { get; set; }
        public int ClusterNumber { get; set; }
        public string ClusterTypeCode { get; set; }
        public bool ClusterIsActive { get; set; }
        public short CredentialDataLength { get; set; }
        public int PanelNumber { get; set; }
        public int CpuNumber { get; set; }  
        public int AccessGroup1 { get; set; }
        public int AccessGroup2 { get; set; }
        public int AccessGroup3 { get; set; }
        public int AccessGroup4 { get; set; }
        public int PersonalAccessGroupNumber { get; set; }
        public int InputOutputGroup1 { get; set; }
        public int InputOutputGroup2 { get; set; }
        public int InputOutputGroup3 { get; set; }
        public int InputOutputGroup4 { get; set; }
        public bool OtisSplitGroupOperation { get; set; }
        public bool OtisCimOverride { get; set; }
        public Guid CpuUid { get; set; }
        #endregion
    }
}

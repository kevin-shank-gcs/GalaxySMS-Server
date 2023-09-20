using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
	public partial class PersonCredential
    {
        public PersonCredential()
        {
            Initialize();
        }

        public PersonCredential(PersonCredential e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.PersonClusterPermissions = new HashSet<PersonClusterPermission>();
            this.PersonCredentialCommandScripts = new HashSet<PersonCredentialCommandScript>();
            this.Credential = new Credential();
            this.ConcurrencyValue = 0;
        }

        public void Initialize(PersonCredential e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.PersonCredentialUid = e.PersonCredentialUid;
            this.CredentialUid = e.CredentialUid;
            this.PersonUid = e.PersonUid;
            this.PersonCredentialRoleUid = e.PersonCredentialRoleUid;
            this.PersonActivationModeUid = e.PersonActivationModeUid;
            this.PersonExpirationModeUid = e.PersonExpirationModeUid;
            this.BadgeTemplateUid = e.BadgeTemplateUid;
            this.DossierBadgeTemplateUid = e.DossierBadgeTemplateUid;
            this.AccessPortalNoServerReplyBehaviorUid = e.AccessPortalNoServerReplyBehaviorUid;
            this.AccessPortalDeferToServerBehaviorUid = e.AccessPortalDeferToServerBehaviorUid;
            this.CredentialDescription = e.CredentialDescription;
            this.ActivationDateTime = e.ActivationDateTime;
            this.ExpirationDateTime = e.ExpirationDateTime;
            this.UsageCount = e.UsageCount;
            this.TraceEnabled = e.TraceEnabled;
            this.DuressEnabled = e.DuressEnabled;
            this.ReverseBits = e.ReverseBits;
            this.IsActive = e.IsActive;
            this.BiometricEnrollmentStatus = e.BiometricEnrollmentStatus;
            this.BadgePrintLimit = e.BadgePrintLimit;
            this.BadgePrintCount = e.BadgePrintCount;
            this.BadgeLastPrinted = e.BadgeLastPrinted;
            this.DossierPrintLimit = e.DossierPrintLimit;
            this.DossierPrintCount = e.DossierPrintCount;
            this.DossierLastPrinted = e.DossierLastPrinted;
            this.SysGalCardId = e.SysGalCardId;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.PersonClusterPermissions = e.PersonClusterPermissions.ToCollection();
            this.PersonCredentialCommandScripts = e.PersonCredentialCommandScripts.ToCollection();
            this.Credential = e.Credential;

        }

        public bool IsAnythingDirty
        {
            get
            {
                if( IsDirty )
                    return IsDirty;

                if( Credential.IsAnythingDirty)
                    return Credential.IsAnythingDirty;

                foreach (var o in PersonClusterPermissions)
                {
                    if (o.IsAnythingDirty == true)
                        return true;
                }

                foreach (var o in PersonCredentialCommandScripts)
                {
                    if (o.IsAnythingDirty == true)
                        return true;
                }

                return IsDirty;
            }
        }

        public PersonCredential Clone(PersonCredential e)
        {
            return new PersonCredential(e);
        }

        public bool Equals(PersonCredential other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(PersonCredential other)
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

    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
#if NetCoreApi
#else
    [DataContract]
#endif

    public partial class gcsUserSave : EntityBase, IIdentifiableEntity, IEquatable<gcsUserSave>
    {

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid UserId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<System.Guid> LanguageId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public System.Guid PrimaryEntityId { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string FirstName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string LastName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string UserInitials { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string DisplayName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string UserPassword { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<System.DateTimeOffset> LastLoginDate { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string UserTheme { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsLockedOut { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsActive { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool ResetPasswordFlag { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<System.DateTimeOffset> LastPasswordResetDate { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<System.DateTime> UserActivationDate { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<System.DateTime> UserExpirationDate { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool ImportedFromActiveDirectory { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<System.Guid> ActiveDirectoryObjectGuid { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public byte[] SecurityImage { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public byte[] UserImage { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<short> ConcurrencyValue { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string Email { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string UserName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public int AccessFailedCount { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string ConcurrencyStamp { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool EmailConfirmed { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool LockoutEnabled { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Nullable<System.DateTimeOffset> LockoutEnd { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public string NormalizedEmail { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public string NormalizedUserName { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string PhoneNumber { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool PhoneNumberConfirmed { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string SecurityStamp { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public bool TwoFactorEnabled { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public string PasswordHash { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public ICollection<gcsUserSetting> gcsUserSettings { get; set; }

//#if NetCoreApi
//#else
//        [DataMember]
//#endif
//        public ICollection<gcsUserOldPassword> gcsUserOldPasswords { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public ICollection<gcsUserEntitySave> UserEntities { get; set; }

    }

}

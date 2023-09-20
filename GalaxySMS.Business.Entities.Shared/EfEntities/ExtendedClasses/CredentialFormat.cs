using GalaxySMS.Common.Interfaces;
using GCS.Core.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

#if NetCoreApi
namespace GalaxySMS.Business.Entities.Api.NetCore
#elif NETSTANDARD2_0
namespace GalaxySMS.Business.Entities.NetStd2
#else
namespace GalaxySMS.Business.Entities
#endif
{
    public partial class CredentialFormat
    {
        public CredentialFormat()
        {
            Initialize();
        }

        public CredentialFormat(CredentialFormat e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.EntityIds = new HashSet<Guid>();
            this.MappedEntitiesPermissionLevels = new HashSet<EntityIdEntityMapPermissionLevel>();
            //this.Credentials = new HashSet<Credential>();
            this.CredentialFormatDataFields = new HashSet<ICredentialFormatDataField>();
            this.CredentialFormatParities = new HashSet<ICredentialFormatParity>();
            this.ConcurrencyValue = 0;
        }

        public void Initialize(CredentialFormat e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.CredentialFormatUid = e.CredentialFormatUid;
            this.DisplayResourceKey = e.DisplayResourceKey;
            this.DescriptionResourceKey = e.DescriptionResourceKey;
            this.Display = e.Display;
            this.Description = e.Description;
            this.CredentialFormatCode = e.CredentialFormatCode;
            this.BitLength = e.BitLength;
            this.IsEnabled = e.IsEnabled;
            this.BiometricEnrollmentSupported = e.BiometricEnrollmentSupported;
            this.BiometricIdField = e.BiometricIdField;
            this.UseCardNumber = e.UseCardNumber;
            this.BatchLoadSupported = e.BatchLoadSupported;
            this.BatchLoadIncrementField = e.BatchLoadIncrementField;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            //this.Credentials = e.Credentials.ToCollection();
            this.CredentialFormatDataFields = e.CredentialFormatDataFields.ToCollection();
            this.CredentialFormatParities = e.CredentialFormatParities.ToCollection();
            if (e.EntityIds != null)
                this.EntityIds = e.EntityIds.ToCollection();
            if (e.MappedEntitiesPermissionLevels != null)
                this.MappedEntitiesPermissionLevels = e.MappedEntitiesPermissionLevels.ToCollection();

            IsAllowed = e.IsAllowed;
            EntityId = e.EntityId;

        }

        public bool IsAnythingDirty
        {
            get
            {
                //foreach( var o in InterfaceBoardSections)
                //{
                //	if (o.IsAnythingDirty == true)
                //		return true;
                //}
                return IsDirty;
            }
        }

        public CredentialFormat Clone(CredentialFormat e)
        {
            return new CredentialFormat(e);
        }

        public bool Equals(CredentialFormat other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(CredentialFormat other)
        {
            if (other == null)
                return false;

            if (other.CredentialFormatUid != this.CredentialFormatUid)
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


#if NetCoreApi
#else
        [DataMember]
#endif
        public bool IsAllowed { get; set; }

#if NetCoreApi
#else
        [DataMember]
#endif
        public Guid EntityId { get; set; }
    }
}

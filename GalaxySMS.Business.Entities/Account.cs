﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;

namespace GalaxySMS.Business.Entities
{
    [DataContract]
    public class Account : EntityBase, IIdentifiableEntity, IAccountOwnedEntity
    {
        [DataMember]
        public Guid AccountGuid { get; set; }

        [DataMember]
        public int AccountId { get; set; }

        [DataMember]
        public string LoginEmail { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public string City { get; set; }

        [DataMember]
        public string State { get; set; }

        [DataMember]
        public string ZipCode { get; set; }

        [DataMember]
        public string CreditCard { get; set; }

        [DataMember]
        public string ExpDate { get; set; }

        #region IIdentifiableEntity members

        public int EntityId
        {
            get { return AccountId; }
            set { AccountId = value; }
        }

        public Guid EntityGuid
        {
            get { return AccountGuid; }
            set { AccountGuid = value; }

        }
        #endregion

        #region IAccountOwnedEntity

        public int OwnerAccountId
        {
            get { return AccountId; }
        }

        #endregion


    }
}

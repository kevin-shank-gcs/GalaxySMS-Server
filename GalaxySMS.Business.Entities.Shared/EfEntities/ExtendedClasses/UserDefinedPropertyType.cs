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
	public partial class UserDefinedPropertyType
    {
        public UserDefinedPropertyType()
        {
            Initialize();
        }

        public UserDefinedPropertyType(UserDefinedPropertyType e)
        {
            Initialize(e);
        }

        public void Initialize()
        {
            this.UserDefinedProperties = new HashSet<UserDefinedProperty>();
            this.ConcurrencyValue = 0;
        }

        public void Initialize(UserDefinedPropertyType e)
        {
            Initialize();
            if (e == null)
                return;

            this.IsDirty = e.IsDirty;
            this.PropertyTypeUid = e.PropertyTypeUid;
            this.PropertyType = e.PropertyType;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.UserDefinedProperties = e.UserDefinedProperties.ToCollection();

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

        public UserDefinedPropertyType Clone(UserDefinedPropertyType e)
        {
            return new UserDefinedPropertyType(e);
        }

        public bool Equals(UserDefinedPropertyType other)
        {
            return base.Equals(other);
        }

        public bool IsPrimaryKeyEqual(UserDefinedPropertyType other)
        {
            if (other == null)
                return false;

            if (other.PropertyTypeUid != this.PropertyTypeUid)
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

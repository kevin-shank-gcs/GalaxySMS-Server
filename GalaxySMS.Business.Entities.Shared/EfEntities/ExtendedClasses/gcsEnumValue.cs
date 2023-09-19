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
	public partial class gcsEnumValue
    {
        public gcsEnumValue()
        {
            Initialize();
        }
        
        public gcsEnumValue(gcsEnumValue e)
        {
            Initialize(e);
        }
        
        public void Initialize()
        {
            this.ConcurrencyValue = 0;
        }

        public void Initialize(gcsEnumValue e)
        {
            Initialize();
            if( e == null )
                return;
            this.EnumValueId = e.EnumValueId;
            this.EnumNamespaceId = e.EnumNamespaceId;
            this.Value = e.Value;
            this.Description = e.Description;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
        		
        }
        
        public gcsEnumValue Clone(gcsEnumValue e)
        {
            return new gcsEnumValue(e);
        }
        
        public bool Equals(gcsEnumValue other)
        {
            return base.Equals(other);
        }
        	
        public bool IsPrimaryKeyEqual(gcsEnumValue other)
        {
            if( other == null ) 
                return false;
        
            if(other.EnumValueId != this.EnumValueId )
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



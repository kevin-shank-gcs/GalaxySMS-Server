using System;
using System.Collections.Generic;
using GCS.Core.Common.Contracts;
using GCS.Core.Common.Core;
using GCS.Core.Common.Extensions;
    
namespace GalaxySMS.Business.Entities
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



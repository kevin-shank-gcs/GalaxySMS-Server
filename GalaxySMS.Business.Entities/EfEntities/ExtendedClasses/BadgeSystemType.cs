    using System;
    using System.Collections.Generic;
    using GCS.Core.Common.Contracts;
	using GCS.Core.Common.Core;
    using GCS.Core.Common.Extensions;
    
    namespace GalaxySMS.Business.Entities
    {
        public partial class BadgeSystemType
        {
        	public BadgeSystemType()
        	{
        		Initialize();
        	}
        
        	public BadgeSystemType(BadgeSystemType e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        	}
        
        	public void Initialize(BadgeSystemType e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        
        		this.IsDirty = e.IsDirty;
        		this.BadgeSystemTypeUid = e.BadgeSystemTypeUid;
        		this.Name = e.Name;
        		this.TypeCode = e.TypeCode;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		
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
        
        	public BadgeSystemType Clone(BadgeSystemType e)
        	{
        		return new BadgeSystemType(e);
        	}
        
        	public bool Equals(BadgeSystemType other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(BadgeSystemType other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.BadgeSystemTypeUid != this.BadgeSystemTypeUid )
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
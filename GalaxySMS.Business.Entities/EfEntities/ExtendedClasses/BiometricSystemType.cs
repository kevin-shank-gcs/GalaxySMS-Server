    using System;
    using System.Collections.Generic;
    using GCS.Core.Common.Contracts;
	using GCS.Core.Common.Core;
    using GCS.Core.Common.Extensions;
    
    namespace GalaxySMS.Business.Entities
    {
        public partial class BiometricSystemType
        {
        	public BiometricSystemType()
        	{
        		Initialize();
        	}
        
        	public BiometricSystemType(BiometricSystemType e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        	}
        
        	public void Initialize(BiometricSystemType e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        
        		this.IsDirty = e.IsDirty;
        		this.BiometricSystemTypeUid = e.BiometricSystemTypeUid;
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
        
        	public BiometricSystemType Clone(BiometricSystemType e)
        	{
        		return new BiometricSystemType(e);
        	}
        
        	public bool Equals(BiometricSystemType other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(BiometricSystemType other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.BiometricSystemTypeUid != this.BiometricSystemTypeUid )
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

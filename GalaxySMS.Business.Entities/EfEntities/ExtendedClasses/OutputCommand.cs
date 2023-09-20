    using System;
    using System.Collections.Generic;
    using GCS.Core.Common.Contracts;
	using GCS.Core.Common.Core;
    using GCS.Core.Common.Extensions;
    
    namespace GalaxySMS.Business.Entities
    {
        public partial class OutputCommand
        {
        	public OutputCommand()
        	{
        		Initialize();
        	}
        
        	public OutputCommand(OutputCommand e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
                this.OutputModeIds = new HashSet<Guid>();
        	}
        
        	public void Initialize(OutputCommand e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        
        		this.IsDirty = e.IsDirty;
        		this.OutputCommandUid = e.OutputCommandUid;
        		this.CommandCode = e.CommandCode;
        		this.IsActive = e.IsActive;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
	            if (e.OutputModeIds != null)
	                this.OutputModeIds = e.OutputModeIds.ToCollection();

	            // IHasDisplayResource & IHasDescriptionResource members
	            this.Display = e.Display;
	            this.DisplayResourceKey = e.DisplayResourceKey;
	            this.Description = e.Description;
	            this.DescriptionResourceKey = e.DescriptionResourceKey;
	            this.ResourceClassName = e.ResourceClassName;
	            this.UniqueResourceName = e.UniqueResourceName;
	            this.DisplayResourceName = e.DisplayResourceName;
	            this.DescriptionResourceName = e.DescriptionResourceName;
      		
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
        
        	public OutputCommand Clone(OutputCommand e)
        	{
        		return new OutputCommand(e);
        	}
        
        	public bool Equals(OutputCommand other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(OutputCommand other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.OutputCommandUid != this.OutputCommandUid )
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

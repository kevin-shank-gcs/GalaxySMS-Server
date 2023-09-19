    using System;
    using System.Collections.Generic;
    using GCS.Core.Common.Contracts;
	using GCS.Core.Common.Core;
    using GCS.Core.Common.Extensions;
    
    namespace GalaxySMS.Business.Entities
    {
        public partial class InputOutputGroupCommand
        {
        	public InputOutputGroupCommand()
        	{
        		Initialize();
        	}
        
        	public InputOutputGroupCommand(InputOutputGroupCommand e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		this.InputOutputGroupGalaxyPanelModelIds = new HashSet<Guid>();
        	}
        
        	public void Initialize(InputOutputGroupCommand e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        
        		this.IsDirty = e.IsDirty;
        		this.InputOutputGroupCommandUid = e.InputOutputGroupCommandUid;
        		this.CommandCode = e.CommandCode;
        		this.IsActive = e.IsActive;
        		this.IsAccessPortalGroupCommand = e.IsAccessPortalGroupCommand;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
	            if (e.InputOutputGroupGalaxyPanelModelIds != null)
	                this.InputOutputGroupGalaxyPanelModelIds = e.InputOutputGroupGalaxyPanelModelIds.ToCollection();

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
        
        	public InputOutputGroupCommand Clone(InputOutputGroupCommand e)
        	{
        		return new InputOutputGroupCommand(e);
        	}
        
        	public bool Equals(InputOutputGroupCommand other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(InputOutputGroupCommand other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.InputOutputGroupCommandUid != this.InputOutputGroupCommandUid )
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

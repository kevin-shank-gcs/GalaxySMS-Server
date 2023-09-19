    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
	using GCS.Core.Common.Core;
	using GCS.Core.Common.Contracts;	using FluentValidation;
    using System.Collections.ObjectModel;
    using GCS.Core.Common.Extensions;
    
    namespace GalaxySMS.Client.Entities
    {
        public partial class OutputCommandGalaxyOutputMode
        {
        	public OutputCommandGalaxyOutputMode() : base()
        	{
        		Initialize();
        	}
        
        	public OutputCommandGalaxyOutputMode(OutputCommandGalaxyOutputMode e) : base(e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        		base.Initialize();
        }
        
        	public void Initialize(OutputCommandGalaxyOutputMode e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.OutputCommandGalaxyOutputModeUid = e.OutputCommandGalaxyOutputModeUid;
        		this.OutputCommandUid = e.OutputCommandUid;
        		this.GalaxyOutputModeUid = e.GalaxyOutputModeUid;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		
        	}
        
        	public OutputCommandGalaxyOutputMode Clone(OutputCommandGalaxyOutputMode e)
        	{
        		return new OutputCommandGalaxyOutputMode(e);
        	}
        
        	public bool Equals(OutputCommandGalaxyOutputMode other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(OutputCommandGalaxyOutputMode other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.OutputCommandGalaxyOutputModeUid != this.OutputCommandGalaxyOutputModeUid )
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

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GalaxySMS.Client.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
	using GCS.Core.Common.Core;
	using FluentValidation;

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A galaxy CPU logging control. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	[DataContract]
	public partial class GalaxyCpuLoggingControl : DbObjectBase
    {
    
    /*	// Move to partial class
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
	using GCS.Core.Common.Core;
	using FluentValidation;
    using System.Collections.ObjectModel;
    using GCS.Core.Common.Extensions;
    
    namespace GalaxySMS.Client.Entities
    {
        public partial class GalaxyCpuLoggingControl
        {
        	public GalaxyCpuLoggingControl()
        	{
        		Initialize();
        	}
        
        	public GalaxyCpuLoggingControl(GalaxyCpuLoggingControl e)
        	{
        		Initialize(e);
        	}
        
        	public void Initialize()
        	{
        }
        
        	public void Initialize(GalaxyCpuLoggingControl e)
        	{
        		Initialize();
        		if( e == null )
        			return;
        		this.CpuUid = e.CpuUid;
        		this.LastLogIndex = e.LastLogIndex;
        		this.InsertDate = e.InsertDate;
        		this.UpdateDate = e.UpdateDate;
        		
        	}
        
        	public GalaxyCpuLoggingControl Clone(GalaxyCpuLoggingControl e)
        	{
        		return new GalaxyCpuLoggingControl(e);
        	}
        
        	public bool Equals(GalaxyCpuLoggingControl other)
        	{
        		return base.Equals(other);
        	}
        	
        	public bool IsPrimaryKeyEqual(GalaxyCpuLoggingControl other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.CpuUid != this.CpuUid )
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
    */
    
    	
        /// <summary>   The CPU UID. </summary>
    	private System.Guid _cpuUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the CPU UID. </summary>
        ///
        /// <value> The CPU UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public System.Guid CpuUid
    	{ 
    		get { return _cpuUid; }
    		set
    		{
    			if (_cpuUid != value )
    			{
    				_cpuUid = value;
    				OnPropertyChanged(() => CpuUid);
    			}
    		}
    	}
    	
        /// <summary>   Zero-based index of the last log. </summary>
    	private int _lastLogIndex;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the zero-based index of the last log. </summary>
        ///
        /// <value> The last log index. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public int LastLogIndex
    	{ 
    		get { return _lastLogIndex; }
    		set
    		{
    			if (_lastLogIndex != value )
    			{
    				_lastLogIndex = value;
    				OnPropertyChanged(() => LastLogIndex);
    			}
    		}
    	}
    	
        /// <summary>   The insert date. </summary>
    	private System.DateTimeOffset _insertDate;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the insert date. </summary>
        ///
        /// <value> The insert date. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public System.DateTimeOffset InsertDate
    	{ 
    		get { return _insertDate; }
    		set
    		{
    			if (_insertDate != value )
    			{
    				_insertDate = value;
    				OnPropertyChanged(() => InsertDate);
    			}
    		}
    	}
    	
        /// <summary>   The update. </summary>
    	private Nullable<System.DateTimeOffset> _updateDate;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the update. </summary>
        ///
        /// <value> The update date. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

    	[DataMember]
    	public Nullable<System.DateTimeOffset> UpdateDate
    	{ 
    		get { return _updateDate; }
    		set
    		{
    			if (_updateDate != value )
    			{
    				_updateDate = value;
    				OnPropertyChanged(() => UpdateDate);
    			}
    		}
    	}
    }
    
}

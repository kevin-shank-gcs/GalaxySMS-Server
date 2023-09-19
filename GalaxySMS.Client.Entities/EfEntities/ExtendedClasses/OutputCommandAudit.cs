////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\ExtendedClasses\OutputCommandAudit.cs
//
// summary:	Implements the output command audit class
////////////////////////////////////////////////////////////////////////////////////////////////////

    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
	using GCS.Core.Common.Core;
	using GCS.Core.Common.Contracts;	using FluentValidation;
    using System.Collections.ObjectModel;
    using GCS.Core.Common.Extensions;
    
    namespace GalaxySMS.Client.Entities
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   An output command audit. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public partial class OutputCommandAudit
        {
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Default constructor. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

        	public OutputCommandAudit() : base()
        	{
        		Initialize();
        	}

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Constructor. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ///
            /// <param name="e">    The OutputCommandAudit to process. </param>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

        	public OutputCommandAudit(OutputCommandAudit e) : base(e)
        	{
        		Initialize(e);
        	}

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Initializes this OutputCommandAudit. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

        	public void Initialize()
        	{
        		base.Initialize();
        }

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Initializes this OutputCommandAudit. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ///
            /// <param name="e">    The OutputCommandAudit to process. </param>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

        	public void Initialize(OutputCommandAudit e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.OutputCommandAuditUid = e.OutputCommandAuditUid;
        		this.UserId = e.UserId;
        		this.OutputCommandUid = e.OutputCommandUid;
        		this.OutputDeviceUid = e.OutputDeviceUid;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		
        	}

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Makes a deep copy of this OutputCommandAudit. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ///
            /// <param name="e">    The OutputCommandAudit to process. </param>
            ///
            /// <returns>   A copy of this OutputCommandAudit. </returns>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

        	public OutputCommandAudit Clone(OutputCommandAudit e)
        	{
        		return new OutputCommandAudit(e);
        	}

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Tests if this OutputCommandAudit is considered equal to another. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ///
            /// <param name="other">    The other. </param>
            ///
            /// <returns>   True if the objects are considered equal, false if they are not. </returns>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

        	public bool Equals(OutputCommandAudit other)
        	{
        		return base.Equals(other);
        	}

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Query if 'other' is primary key equal. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ///
            /// <param name="other">    The other. </param>
            ///
            /// <returns>   True if primary key equal, false if not. </returns>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

        	public bool IsPrimaryKeyEqual(OutputCommandAudit other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.OutputCommandAuditUid != this.OutputCommandAuditUid )
        			return false;
        		return true;
        	}

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Serves as the default hash function. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ///
            /// <returns>   A hash code for the current object. </returns>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

        	public override int GetHashCode()
        	{
        		return base.GetHashCode();
        	}

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Returns a string that represents the current object. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ///
            /// <returns>   A string that represents the current object. </returns>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

        	public override string ToString()
        	{
        		return base.ToString();
        	}
        }
    }

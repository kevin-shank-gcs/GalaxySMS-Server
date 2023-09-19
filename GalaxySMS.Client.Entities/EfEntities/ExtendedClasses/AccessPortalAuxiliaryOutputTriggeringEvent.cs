////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\ExtendedClasses\AccessPortalAuxiliaryOutputTriggeringEvent.cs
//
// summary:	Implements the access portal auxiliary output triggering event class
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
        /// <summary>   The access portal auxiliary output triggering event. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public partial class AccessPortalAuxiliaryOutputTriggeringEvent
        {
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Default constructor. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

        	public AccessPortalAuxiliaryOutputTriggeringEvent() : base()
        	{
        		Initialize();
        	}

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Constructor. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ///
            /// <param name="e">    The AccessPortalAuxiliaryOutputTriggeringEvent to process. </param>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

        	public AccessPortalAuxiliaryOutputTriggeringEvent(AccessPortalAuxiliaryOutputTriggeringEvent e) : base(e)
        	{
        		Initialize(e);
        	}

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Initializes this AccessPortalAuxiliaryOutputTriggeringEvent. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

        	public void Initialize()
        	{
        		base.Initialize();
        }

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Initializes this AccessPortalAuxiliaryOutputTriggeringEvent. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ///
            /// <param name="e">    The AccessPortalAuxiliaryOutputTriggeringEvent to process. </param>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

        	public void Initialize(AccessPortalAuxiliaryOutputTriggeringEvent e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.AccessPortalAuxiliaryOutputTriggeringEventUid = e.AccessPortalAuxiliaryOutputTriggeringEventUid;
        		this.AccessPortalAuxiliaryOutputUid = e.AccessPortalAuxiliaryOutputUid;
        		this.AccessPortalAlertEventTypeUid = e.AccessPortalAlertEventTypeUid;
        		this.Selected = e.Selected;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		
        	}

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Makes a deep copy of this AccessPortalAuxiliaryOutputTriggeringEvent. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ///
            /// <param name="e">    The AccessPortalAuxiliaryOutputTriggeringEvent to process. </param>
            ///
            /// <returns>   A copy of this AccessPortalAuxiliaryOutputTriggeringEvent. </returns>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

        	public AccessPortalAuxiliaryOutputTriggeringEvent Clone(AccessPortalAuxiliaryOutputTriggeringEvent e)
        	{
        		return new AccessPortalAuxiliaryOutputTriggeringEvent(e);
        	}

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>
            /// Tests if this AccessPortalAuxiliaryOutputTriggeringEvent is considered equal to another.
            /// </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ///
            /// <param name="other">    The other. </param>
            ///
            /// <returns>   True if the objects are considered equal, false if they are not. </returns>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

        	public bool Equals(AccessPortalAuxiliaryOutputTriggeringEvent other)
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

        	public bool IsPrimaryKeyEqual(AccessPortalAuxiliaryOutputTriggeringEvent other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.AccessPortalAuxiliaryOutputTriggeringEventUid != this.AccessPortalAuxiliaryOutputTriggeringEventUid )
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
////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\ExtendedClasses\AccessPortalAlertEvent.cs
//
// summary:	Implements the access portal alert event class
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
        /// <summary>   The access portal alert event. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public partial class AccessPortalAlertEvent
        {
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Default constructor. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

        	public AccessPortalAlertEvent() : base()
        	{
        		Initialize();
        	}

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Constructor. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ///
            /// <param name="e">    The AccessPortalAlertEvent to process. </param>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

        	public AccessPortalAlertEvent(AccessPortalAlertEvent e) : base(e)
        	{
        		Initialize(e);
        	}

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Initializes this AccessPortalAlertEvent. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

        	public void Initialize()
        	{
        		base.Initialize();
                Note = new Note() { Category = GalaxySMS.Common.Constants.NoteCategories.AccessPortalAlertEventInstructions };
            }

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Initializes this AccessPortalAlertEvent. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ///
            /// <param name="e">    The AccessPortalAlertEvent to process. </param>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

            public void Initialize(AccessPortalAlertEvent e)
            {
                Initialize();
                base.Initialize(e);

                if (e == null)
                    return;
                this.AccessPortalAlertEventUid = e.AccessPortalAlertEventUid;
                this.AccessPortalUid = e.AccessPortalUid;
                this.InputOutputGroupUid = e.InputOutputGroupUid;
                this.AcknowledgeTimeScheduleUid = e.AcknowledgeTimeScheduleUid;
                this.AudioBinaryResourceUid = e.AudioBinaryResourceUid;
                this.ResponseInstructionsUid = e.ResponseInstructionsUid;
                this.AccessPortalAlertEventTypeUid = e.AccessPortalAlertEventTypeUid;
                this.InputOutputGroupAssignmentUid = e.InputOutputGroupAssignmentUid;
                this.AcknowledgePriority = e.AcknowledgePriority;
                this.ResponseRequired = e.ResponseRequired;
                this.IsActive = e.IsActive;
                this.InsertName = e.InsertName;
                this.InsertDate = e.InsertDate;
                this.UpdateName = e.UpdateName;
                this.UpdateDate = e.UpdateDate;
                this.ConcurrencyValue = e.ConcurrencyValue;

                if (e.gcsBinaryResource != null)
                    this.gcsBinaryResource = new gcsBinaryResource(e.gcsBinaryResource);
                if (e.AccessPortalAlertEventType != null)
                    this.AccessPortalAlertEventType = new AccessPortalAlertEventType(e.AccessPortalAlertEventType);
                if (e.Note != null)
                    this.Note = new Note(e.Note);
            }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Makes a deep copy of this AccessPortalAlertEvent. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The AccessPortalAlertEvent to process. </param>
        ///
        /// <returns>   A copy of this AccessPortalAlertEvent. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public AccessPortalAlertEvent Clone(AccessPortalAlertEvent e)
        	{
        		return new AccessPortalAlertEvent(e);
        	}

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Tests if this AccessPortalAlertEvent is considered equal to another. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ///
            /// <param name="other">    The other. </param>
            ///
            /// <returns>   True if the objects are considered equal, false if they are not. </returns>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

        	public bool Equals(AccessPortalAlertEvent other)
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

        	public bool IsPrimaryKeyEqual(AccessPortalAlertEvent other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.AccessPortalAlertEventUid != this.AccessPortalAlertEventUid )
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

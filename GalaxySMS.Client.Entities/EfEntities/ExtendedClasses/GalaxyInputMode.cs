////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\ExtendedClasses\GalaxyInputMode.cs
//
// summary:	Implements the galaxy input mode class
////////////////////////////////////////////////////////////////////////////////////////////////////

    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;
	using GCS.Core.Common.Core;
	using GCS.Core.Common.Contracts;
    using System.Collections.ObjectModel;
    using GCS.Core.Common.Extensions;
    
    namespace GalaxySMS.Client.Entities
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A galaxy input mode. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public partial class GalaxyInputMode
        {
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Default constructor. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

        	public GalaxyInputMode() : base()
        	{
        		Initialize();
        	}

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Constructor. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ///
            /// <param name="e">    The GalaxyInputMode to process. </param>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

        	public GalaxyInputMode(GalaxyInputMode e) : base(e)
        	{
        		Initialize(e);
        	}

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Initializes this GalaxyInputMode. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

        	public void Initialize()
        	{
        		base.Initialize();
        }

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Initializes this GalaxyInputMode. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ///
            /// <param name="e">    The GalaxyInputMode to process. </param>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

        	public void Initialize(GalaxyInputMode e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.GalaxyInputModeUid = e.GalaxyInputModeUid;
        		this.Display = e.Display;
        		this.DisplayResourceKey = e.DisplayResourceKey;
        		this.Description = e.Description;
        		this.DescriptionResourceKey = e.DescriptionResourceKey;
        		this.Code = e.Code;
        		this.DisplayOrder = e.DisplayOrder;
        		this.IsDefault = e.IsDefault;
        		this.IsActive = e.IsActive;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		
        	}

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Makes a deep copy of this GalaxyInputMode. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ///
            /// <param name="e">    The GalaxyInputMode to process. </param>
            ///
            /// <returns>   A copy of this GalaxyInputMode. </returns>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

        	public GalaxyInputMode Clone(GalaxyInputMode e)
        	{
        		return new GalaxyInputMode(e);
        	}

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Tests if this GalaxyInputMode is considered equal to another. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ///
            /// <param name="other">    The other. </param>
            ///
            /// <returns>   True if the objects are considered equal, false if they are not. </returns>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

        	public bool Equals(GalaxyInputMode other)
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

        	public bool IsPrimaryKeyEqual(GalaxyInputMode other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.GalaxyInputModeUid != this.GalaxyInputModeUid )
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
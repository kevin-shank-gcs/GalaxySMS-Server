////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\ExtendedClasses\GalaxyInputDelayType.cs
//
// summary:	Implements the galaxy input delay type class
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
        /// <summary>   A galaxy input delay type. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public partial class GalaxyInputDelayType
        {
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Default constructor. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

        	public GalaxyInputDelayType() : base()
        	{
        		Initialize();
        	}

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Constructor. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ///
            /// <param name="e">    The GalaxyInputDelayType to process. </param>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

        	public GalaxyInputDelayType(GalaxyInputDelayType e) : base(e)
        	{
        		Initialize(e);
        	}

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Initializes this GalaxyInputDelayType. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

        	public void Initialize()
        	{
        		base.Initialize();
        }

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Initializes this GalaxyInputDelayType. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ///
            /// <param name="e">    The GalaxyInputDelayType to process. </param>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

        	public void Initialize(GalaxyInputDelayType e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.GalaxyInputDelayTypeUid = e.GalaxyInputDelayTypeUid;
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
            /// <summary>   Makes a deep copy of this GalaxyInputDelayType. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ///
            /// <param name="e">    The GalaxyInputDelayType to process. </param>
            ///
            /// <returns>   A copy of this GalaxyInputDelayType. </returns>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

        	public GalaxyInputDelayType Clone(GalaxyInputDelayType e)
        	{
        		return new GalaxyInputDelayType(e);
        	}

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Tests if this GalaxyInputDelayType is considered equal to another. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ///
            /// <param name="other">    The other. </param>
            ///
            /// <returns>   True if the objects are considered equal, false if they are not. </returns>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

        	public bool Equals(GalaxyInputDelayType other)
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

        	public bool IsPrimaryKeyEqual(GalaxyInputDelayType other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.GalaxyInputDelayTypeUid != this.GalaxyInputDelayTypeUid )
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

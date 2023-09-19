////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\ExtendedClasses\LiquidCrystalDisplayEntityMap.cs
//
// summary:	Implements the liquid crystal display entity map class
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
        /// <summary>   Map of liquid crystal display entities. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public partial class LiquidCrystalDisplayEntityMap
        {
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Default constructor. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

        	public LiquidCrystalDisplayEntityMap() : base()
        	{
        		Initialize();
        	}

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Constructor. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ///
            /// <param name="e">    The LiquidCrystalDisplayEntityMap to process. </param>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

        	public LiquidCrystalDisplayEntityMap(LiquidCrystalDisplayEntityMap e) : base(e)
        	{
        		Initialize(e);
        	}

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Initializes this LiquidCrystalDisplayEntityMap. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

        	public void Initialize()
        	{
        		base.Initialize();
        }

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Initializes this LiquidCrystalDisplayEntityMap. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ///
            /// <param name="e">    The LiquidCrystalDisplayEntityMap to process. </param>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

        	public void Initialize(LiquidCrystalDisplayEntityMap e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.LiquidCrystalDisplayEntityMapUid = e.LiquidCrystalDisplayEntityMapUid;
        		this.LiquidCrystalDisplayUid = e.LiquidCrystalDisplayUid;
        		this.EntityId = e.EntityId;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		
        	}

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Makes a deep copy of this LiquidCrystalDisplayEntityMap. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ///
            /// <param name="e">    The LiquidCrystalDisplayEntityMap to process. </param>
            ///
            /// <returns>   A copy of this LiquidCrystalDisplayEntityMap. </returns>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

        	public LiquidCrystalDisplayEntityMap Clone(LiquidCrystalDisplayEntityMap e)
        	{
        		return new LiquidCrystalDisplayEntityMap(e);
        	}

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>
            /// Tests if this LiquidCrystalDisplayEntityMap is considered equal to another.
            /// </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ///
            /// <param name="other">    The other. </param>
            ///
            /// <returns>   True if the objects are considered equal, false if they are not. </returns>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

        	public bool Equals(LiquidCrystalDisplayEntityMap other)
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

        	public bool IsPrimaryKeyEqual(LiquidCrystalDisplayEntityMap other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.LiquidCrystalDisplayEntityMapUid != this.LiquidCrystalDisplayEntityMapUid )
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

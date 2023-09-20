////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\ExtendedClasses\LiquidCrystalDisplayGalaxyHardwareAddress.cs
//
// summary:	Implements the liquid crystal display galaxy hardware address class
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
        /// <summary>   A liquid crystal display galaxy hardware address. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public partial class LiquidCrystalDisplayGalaxyHardwareAddress
        {
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Default constructor. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

        	public LiquidCrystalDisplayGalaxyHardwareAddress() : base()
        	{
        		Initialize();
        	}

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Constructor. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ///
            /// <param name="e">    The LiquidCrystalDisplayGalaxyHardwareAddress to process. </param>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

        	public LiquidCrystalDisplayGalaxyHardwareAddress(LiquidCrystalDisplayGalaxyHardwareAddress e) : base(e)
        	{
        		Initialize(e);
        	}

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Initializes this LiquidCrystalDisplayGalaxyHardwareAddress. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

        	public void Initialize()
        	{
        		base.Initialize();
        }

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Initializes this LiquidCrystalDisplayGalaxyHardwareAddress. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ///
            /// <param name="e">    The LiquidCrystalDisplayGalaxyHardwareAddress to process. </param>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

        	public void Initialize(LiquidCrystalDisplayGalaxyHardwareAddress e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.LiquidCrystalDisplayGalaxyHardwareAddressUid = e.LiquidCrystalDisplayGalaxyHardwareAddressUid;
        		this.LiquidCrystalDisplayUid = e.LiquidCrystalDisplayUid;
        		this.GalaxyInterfaceBoardSectionNodeUid = e.GalaxyInterfaceBoardSectionNodeUid;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		
        	}

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Makes a deep copy of this LiquidCrystalDisplayGalaxyHardwareAddress. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ///
            /// <param name="e">    The LiquidCrystalDisplayGalaxyHardwareAddress to process. </param>
            ///
            /// <returns>   A copy of this LiquidCrystalDisplayGalaxyHardwareAddress. </returns>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

        	public LiquidCrystalDisplayGalaxyHardwareAddress Clone(LiquidCrystalDisplayGalaxyHardwareAddress e)
        	{
        		return new LiquidCrystalDisplayGalaxyHardwareAddress(e);
        	}

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>
            /// Tests if this LiquidCrystalDisplayGalaxyHardwareAddress is considered equal to another.
            /// </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ///
            /// <param name="other">    The other. </param>
            ///
            /// <returns>   True if the objects are considered equal, false if they are not. </returns>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

        	public bool Equals(LiquidCrystalDisplayGalaxyHardwareAddress other)
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

        	public bool IsPrimaryKeyEqual(LiquidCrystalDisplayGalaxyHardwareAddress other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.LiquidCrystalDisplayGalaxyHardwareAddressUid != this.LiquidCrystalDisplayGalaxyHardwareAddressUid )
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

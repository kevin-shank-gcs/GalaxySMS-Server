////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\ExtendedClasses\OutputDeviceGalaxyHardwareAddress.cs
//
// summary:	Implements the output device galaxy hardware address class
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
        /// <summary>   An output device galaxy hardware address. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public partial class OutputDeviceGalaxyHardwareAddress
        {
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Default constructor. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

        	public OutputDeviceGalaxyHardwareAddress() : base()
        	{
        		Initialize();
        	}

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Constructor. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ///
            /// <param name="e">    The OutputDeviceGalaxyHardwareAddress to process. </param>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

        	public OutputDeviceGalaxyHardwareAddress(OutputDeviceGalaxyHardwareAddress e) : base(e)
        	{
        		Initialize(e);
        	}

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Initializes this OutputDeviceGalaxyHardwareAddress. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

        	public void Initialize()
        	{
        		base.Initialize();
        }

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Initializes this OutputDeviceGalaxyHardwareAddress. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ///
            /// <param name="e">    The OutputDeviceGalaxyHardwareAddress to process. </param>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

        	public void Initialize(OutputDeviceGalaxyHardwareAddress e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.OutputDeviceGalaxyHardwareAddressUid = e.OutputDeviceGalaxyHardwareAddressUid;
        		this.OutputDeviceUid = e.OutputDeviceUid;
        		this.GalaxyInterfaceBoardSectionNodeUid = e.GalaxyInterfaceBoardSectionNodeUid;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		
        	}

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Makes a deep copy of this OutputDeviceGalaxyHardwareAddress. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ///
            /// <param name="e">    The OutputDeviceGalaxyHardwareAddress to process. </param>
            ///
            /// <returns>   A copy of this OutputDeviceGalaxyHardwareAddress. </returns>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

        	public OutputDeviceGalaxyHardwareAddress Clone(OutputDeviceGalaxyHardwareAddress e)
        	{
        		return new OutputDeviceGalaxyHardwareAddress(e);
        	}

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>
            /// Tests if this OutputDeviceGalaxyHardwareAddress is considered equal to another.
            /// </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ///
            /// <param name="other">    The other. </param>
            ///
            /// <returns>   True if the objects are considered equal, false if they are not. </returns>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

        	public bool Equals(OutputDeviceGalaxyHardwareAddress other)
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

        	public bool IsPrimaryKeyEqual(OutputDeviceGalaxyHardwareAddress other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.OutputDeviceGalaxyHardwareAddressUid != this.OutputDeviceGalaxyHardwareAddressUid )
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

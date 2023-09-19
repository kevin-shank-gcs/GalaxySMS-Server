////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\ExtendedClasses\InputDeviceSupervisionTypeInterfaceBoardSectionMode.cs
//
// summary:	Implements the input device supervision type interface board section mode class
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
        /// <summary>   An input device supervision type interface board section mode. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public partial class InputDeviceSupervisionTypeInterfaceBoardSectionMode
        {
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Default constructor. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

        	public InputDeviceSupervisionTypeInterfaceBoardSectionMode() : base()
        	{
        		Initialize();
        	}

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Constructor. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ///
            /// <param name="e">    The InputDeviceSupervisionTypeInterfaceBoardSectionMode to process. </param>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

        	public InputDeviceSupervisionTypeInterfaceBoardSectionMode(InputDeviceSupervisionTypeInterfaceBoardSectionMode e) : base(e)
        	{
        		Initialize(e);
        	}

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Initializes this InputDeviceSupervisionTypeInterfaceBoardSectionMode. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

        	public void Initialize()
        	{
        		base.Initialize();
        }

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Initializes this InputDeviceSupervisionTypeInterfaceBoardSectionMode. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ///
            /// <param name="e">    The InputDeviceSupervisionTypeInterfaceBoardSectionMode to process. </param>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

        	public void Initialize(InputDeviceSupervisionTypeInterfaceBoardSectionMode e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.InputDeviceSupervisionTypeInterfaceBoardSectionModeUid = e.InputDeviceSupervisionTypeInterfaceBoardSectionModeUid;
        		this.InterfaceBoardSectionModeUid = e.InterfaceBoardSectionModeUid;
        		this.InputDeviceSupervisionTypeUid = e.InputDeviceSupervisionTypeUid;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		
        	}

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>
            /// Makes a deep copy of this InputDeviceSupervisionTypeInterfaceBoardSectionMode.
            /// </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ///
            /// <param name="e">    The InputDeviceSupervisionTypeInterfaceBoardSectionMode to process. </param>
            ///
            /// <returns>   A copy of this InputDeviceSupervisionTypeInterfaceBoardSectionMode. </returns>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

        	public InputDeviceSupervisionTypeInterfaceBoardSectionMode Clone(InputDeviceSupervisionTypeInterfaceBoardSectionMode e)
        	{
        		return new InputDeviceSupervisionTypeInterfaceBoardSectionMode(e);
        	}

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>
            /// Tests if this InputDeviceSupervisionTypeInterfaceBoardSectionMode is considered equal to
            /// another.
            /// </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ///
            /// <param name="other">    The other. </param>
            ///
            /// <returns>   True if the objects are considered equal, false if they are not. </returns>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

        	public bool Equals(InputDeviceSupervisionTypeInterfaceBoardSectionMode other)
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

        	public bool IsPrimaryKeyEqual(InputDeviceSupervisionTypeInterfaceBoardSectionMode other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.InputDeviceSupervisionTypeInterfaceBoardSectionModeUid != this.InputDeviceSupervisionTypeInterfaceBoardSectionModeUid )
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
////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\ExtendedClasses\RoleInputOutputGroup.cs
//
// summary:	Implements the role input output group class
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
        /// <summary>   A role input output group. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public partial class RoleInputOutputGroup
        {
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Default constructor. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

        	public RoleInputOutputGroup() : base()
        	{
        		Initialize();
        	}

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Constructor. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ///
            /// <param name="e">    The RoleInputOutputGroup to process. </param>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

        	public RoleInputOutputGroup(RoleInputOutputGroup e) : base(e)
        	{
        		Initialize(e);
        	}

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Initializes this RoleInputOutputGroup. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

        	public void Initialize()
        	{
        		base.Initialize();
        		this.RoleInputOutputGroupPermissions = new HashSet<RoleInputOutputGroupPermission>();
        }

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Initializes this RoleInputOutputGroup. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ///
            /// <param name="e">    The RoleInputOutputGroup to process. </param>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

        	public void Initialize(RoleInputOutputGroup e)
        	{
        		Initialize();
        		base.Initialize(e);
        
        		if( e == null )
        			return;
        		this.RoleInputOutputGroupUid = e.RoleInputOutputGroupUid;
        		this.RoleId = e.RoleId;
        		this.InputOutputGroupUid = e.InputOutputGroupUid;
        		this.InsertName = e.InsertName;
        		this.InsertDate = e.InsertDate;
        		this.UpdateName = e.UpdateName;
        		this.UpdateDate = e.UpdateDate;
        		this.ConcurrencyValue = e.ConcurrencyValue;
        		this.RoleInputOutputGroupPermissions = e.RoleInputOutputGroupPermissions.ToCollection();
                this.InputOutputGroupName = e.InputOutputGroupName;

            }

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Makes a deep copy of this RoleInputOutputGroup. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ///
            /// <param name="e">    The RoleInputOutputGroup to process. </param>
            ///
            /// <returns>   A copy of this RoleInputOutputGroup. </returns>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

        	public RoleInputOutputGroup Clone(RoleInputOutputGroup e)
        	{
        		return new RoleInputOutputGroup(e);
        	}

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Tests if this RoleInputOutputGroup is considered equal to another. </summary>
            ///
            /// <remarks>   Kevin, 12/26/2018. </remarks>
            ///
            /// <param name="other">    The other. </param>
            ///
            /// <returns>   True if the objects are considered equal, false if they are not. </returns>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

        	public bool Equals(RoleInputOutputGroup other)
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

        	public bool IsPrimaryKeyEqual(RoleInputOutputGroup other)
        	{
        		if( other == null ) 
        			return false;
        
        		if(other.RoleInputOutputGroupUid != this.RoleInputOutputGroupUid )
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

#if NetCoreApi
#else
            [DataMember]
#endif
            public string InputOutputGroupName { get; set; }

    }
}

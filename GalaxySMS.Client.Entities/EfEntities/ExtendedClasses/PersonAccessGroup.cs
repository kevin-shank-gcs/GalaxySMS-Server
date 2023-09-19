////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\ExtendedClasses\PersonAccessGroup.cs
//
// summary:	Implements the person access group class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using GCS.Core.Common.Core;
using GCS.Core.Common.Contracts;
using FluentValidation;
using System.Collections.ObjectModel;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A person access group. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class PersonAccessGroup
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public PersonAccessGroup() : base()
        {
            Initialize();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The PersonAccessGroup to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public PersonAccessGroup(PersonAccessGroup e) : base(e)
        {
            Initialize(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this PersonAccessGroup. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize()
        {
            base.Initialize();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initializes this PersonAccessGroup. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The PersonAccessGroup to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Initialize(PersonAccessGroup e)
        {
            Initialize();
            base.Initialize(e);

            if (e == null)
                return;
            this.PersonAccessGroupUid = e.PersonAccessGroupUid;
            this.AccessGroupUid = e.AccessGroupUid;
            this.PersonClusterPermissionUid = e.PersonClusterPermissionUid;
            this.OrderNumber = e.OrderNumber;
            this.InsertName = e.InsertName;
            this.InsertDate = e.InsertDate;
            this.UpdateName = e.UpdateName;
            this.UpdateDate = e.UpdateDate;
            this.ConcurrencyValue = e.ConcurrencyValue;
            this.AccessGroupNumber = e.AccessGroupNumber;
            this.AccessGroupName = e.AccessGroupName;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Makes a deep copy of this PersonAccessGroup. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="e">    The PersonAccessGroup to process. </param>
        ///
        /// <returns>   A copy of this PersonAccessGroup. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public PersonAccessGroup Clone(PersonAccessGroup e)
        {
            return new PersonAccessGroup(e);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Tests if this PersonAccessGroup is considered equal to another. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="other">    The other. </param>
        ///
        /// <returns>   True if the objects are considered equal, false if they are not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool Equals(PersonAccessGroup other)
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

        public bool IsPrimaryKeyEqual(PersonAccessGroup other)
        {
            if (other == null)
                return false;

            if (other.PersonAccessGroupUid != this.PersonAccessGroupUid)
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

        private int _accessGroupNumber;
       
        [DataMember]

        public int AccessGroupNumber
        {
            get { return _accessGroupNumber; }
            set
            {
                if (_accessGroupNumber != value)
                {
                    _accessGroupNumber = value;
                    OnPropertyChanged(() => AccessGroupNumber);
                }
            }
        }


        private string _AccessGroupName;

        [DataMember]
        public string AccessGroupName
        {
            get { return _AccessGroupName; }
            set
            {
                if (_AccessGroupName != value)
                {
                    _AccessGroupName = value;
                    OnPropertyChanged(() => AccessGroupName);
                }
            }
        }

    }
}


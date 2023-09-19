////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\UserEntitySelect.cs
//
// summary:	Implements the user entity select class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;
using GCS.Framework.Security;
using FluentValidation;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A user entity select. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class UserEntitySelect : UserEntity
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public UserEntitySelect() : base()
        {
            Init();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="o">    The UserEntitySelect to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public UserEntitySelect(UserEntity o) : base(o)
        {

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="o">    The UserEntitySelect to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public UserEntitySelect(UserEntitySelect o) :base(o)
        {
            Init(o);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initialises this UserEntitySelect. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void Init()
        {
            base.Init();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initialises this UserEntitySelect. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="o">    The UserEntitySelect to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void Init(UserEntitySelect o)
        {
            base.Init(o);
            this.Selected = o.Selected;
        }

        /// <summary>   True if selected. </summary>
        private bool _selected;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether the selected. </summary>
        ///
        /// <value> True if selected, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public bool Selected
        {
            get { return _selected; }
            set
            {
                if (_selected != value)
                {
                    _selected = value;
                    OnPropertyChanged(() => Selected);
                }
            }
        }

        //private Guid _EntityMapPermissionLevelUid;

        //[DataMember]
        //public Guid EntityMapPermissionLevelUid
        //{
        //    get { return _EntityMapPermissionLevelUid; }
        //    set
        //    {
        //        if (_EntityMapPermissionLevelUid != value)
        //        {
        //            _EntityMapPermissionLevelUid = value;
        //            OnPropertyChanged(() => EntityMapPermissionLevelUid);
        //        }
        //    }
        //}

        /// <summary>   True if this UserEntitySelect is owner. </summary>
        private bool _isOwner;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether this UserEntitySelect is owner. </summary>
        ///
        /// <value> True if this UserEntitySelect is owner, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public bool IsOwner
        {
            get { return _isOwner; }
            set
            {
                if (_isOwner != value)
                {
                    _isOwner = value;
                    OnPropertyChanged(() => IsOwner, false);
                }
            }
        }
    }
}

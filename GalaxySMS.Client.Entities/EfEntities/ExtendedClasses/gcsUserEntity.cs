////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	EfEntities\ExtendedClasses\gcsUserEntity.cs
//
// summary:	Implements the gcs user entity class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Extensions;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The gcs user entity. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public partial class gcsUserEntity
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsUserEntity()
        {
            this.UserEntityRoles = new HashSet<gcsUserEntityRole>();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="userEntity">   The user entity. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public gcsUserEntity(gcsUserEntity userEntity)
        {
            if (userEntity != null)
            {
                this.ConcurrencyValue = userEntity.ConcurrencyValue;
                this.EntityId = userEntity.EntityId;
                this.IsAdministrator = userEntity.IsAdministrator;
                this.InheritParentRoles = userEntity.InheritParentRoles;
                this.InsertDate = userEntity.InsertDate;
                this.InsertName = userEntity.InsertName;
                this.UpdateDate = userEntity.UpdateDate;
                this.UpdateName = userEntity.UpdateName;
                this.UserEntityId = userEntity.UserEntityId;
                this.UserId = userEntity.UserId;
                this.EntityName = userEntity.EntityName;
                //this.gcsEntity = userEntity.gcsEntity;
                //this.gcsUser = userEntity.gcsUser;
                this.UserEntityRoles = userEntity.UserEntityRoles.ToObservableCollection();
                //this.ApplicationsPermittedToEntity = userEntity.ApplicationsPermittedToEntity.ToObservableCollection();
                //this.ApplicationsAuthorizedForUser = userEntity.ApplicationsAuthorizedForUser.ToObservableCollection();
                //this.ApplicationsNotAuthorizedForUser = userEntity.ApplicationsNotAuthorizedForUser.ToObservableCollection();
            }
        }

        //// This is a collection of all Applications that are allowable for this entity
        //private ObservableCollection<gcsApplication> _applicationsPermittedToEntity = new ObservableCollection<gcsApplication>();

        //[DataMember]
        //public virtual ObservableCollection<gcsApplication> ApplicationsPermittedToEntity
        //{
        //    get { return _applicationsPermittedToEntity; }
        //    set
        //    {
        //        if (_applicationsPermittedToEntity != value)
        //        {
        //            _applicationsPermittedToEntity = value;
        //            OnPropertyChanged(() => ApplicationsPermittedToEntity);
        //        }
        //    }
        //}

        //private ObservableCollection<gcsApplication> _applicationsAuthorizedForUser = new ObservableCollection<gcsApplication>();

        //[DataMember]
        //public virtual ObservableCollection<gcsApplication> ApplicationsAuthorizedForUser
        //{
        //    get { return _applicationsAuthorizedForUser; }
        //    set
        //    {
        //        if (_applicationsAuthorizedForUser != value)
        //        {
        //            _applicationsAuthorizedForUser = value;
        //            OnPropertyChanged(() => ApplicationsAuthorizedForUser);
        //        }
        //    }
        //}

        //private ObservableCollection<gcsApplication> _applicationsNotAuthorizedForUser = new ObservableCollection<gcsApplication>();
        //[DataMember]
        //public virtual ObservableCollection<gcsApplication> ApplicationsNotAuthorizedForUser
        //{
        //    get { return _applicationsNotAuthorizedForUser; }
        //    set
        //    {
        //        if (_applicationsNotAuthorizedForUser != value)
        //        {
        //            _applicationsNotAuthorizedForUser = value;
        //            OnPropertyChanged(() => ApplicationsNotAuthorizedForUser);
        //        }
        //    }
        //}
        private string _entityName;

        [DataMember]
        public string EntityName
        {
            get { return _entityName; }
            set
            {
                if (_entityName != value)
                {
                    _entityName = value;
                    OnPropertyChanged(() => EntityName, false);
                }
            }
        }

    }

}

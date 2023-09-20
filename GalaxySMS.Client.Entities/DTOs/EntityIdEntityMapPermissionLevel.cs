////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	DTOs\EntityIdEntityMapPermissionLevel.cs
//
// summary:	Implements the entity identifier entity map permission level class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Core;

namespace GalaxySMS.Client.Entities
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   An entity identifier entity map permission level. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public class EntityIdEntityMapPermissionLevel : DbObjectBase
    {
        /// <summary>   Identifier for the entity. </summary>
        private Guid _EntityId;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the entity. </summary>
        ///
        /// <value> The identifier of the entity. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid EntityId
        {
            get { return _EntityId; }
            set
            {
                if (_EntityId != value)
                {
                    _EntityId = value;
                    OnPropertyChanged(() => EntityId);
                }
            }
        }

        /// <summary>   The entity map permission level UID. </summary>
        private Guid _EntityMapPermissionLevelUid;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the entity map permission level UID. </summary>
        ///
        /// <value> The entity map permission level UID. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid EntityMapPermissionLevelUid
        {
            get { return _EntityMapPermissionLevelUid; }
            set
            {
                if (_EntityMapPermissionLevelUid != value)
                {
                    _EntityMapPermissionLevelUid = value;
                    OnPropertyChanged(() => EntityMapPermissionLevelUid);
                }
            }
        }


    }
}

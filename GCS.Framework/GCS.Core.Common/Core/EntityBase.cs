////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Core\EntityBase.cs
//
// summary:	Implements the entity base class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using GCS.Core.Common.Extensions;

namespace GCS.Core.Common.Core
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   An entity base. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public abstract class EntityBase : DataContractBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public EntityBase()
        {
            EntityGuid = Guid.Empty;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="o">    The EntityBase to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public EntityBase(EntityBase o)
        {
            if (o != null)
            {
                EntityIdentifier = o.EntityIdentifier;
                EntityGuid = o.EntityGuid;
            }
            else
            {
                EntityGuid = Guid.Empty;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the entity. </summary>
        ///
        /// <value> The identifier of the entity. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public int EntityIdentifier { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a unique identifier of the entity. </summary>
        ///
        /// <value> Unique identifier of the entity. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid EntityGuid { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether this EntityBase is dirty. </summary>
        ///
        /// <value> True if this EntityBase is dirty, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public bool IsDirty { get; set; }

        //[DataMember]
        //public bool IsAnyPropertyDirty { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether this EntityBase is panel data dirty.
        /// </summary>
        ///
        /// <value> True if this EntityBase is panel data dirty, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public bool IsPanelDataDirty { get; set; }

        //public virtual bool IsAnythingDirty()
        //{
        //    bool isDirty = this.IsDirty;

        //    if (isDirty == false)
        //    {
        //        WalkObjectGraph(
        //            o =>
        //            {
        //                if (o.IsDirty)
        //                {
        //                    isDirty = true;
        //                    IsAnyPropertyDirty = isDirty;
        //                    return isDirty; // short circuit
        //                }
        //                else
        //                {
        //                    IsAnyPropertyDirty = false;
        //                    return false;
        //                }
        //            }, coll => { });
        //    }
        //    IsAnyPropertyDirty = isDirty;
        //    return isDirty;
        //}
        ////[DataMember]
        ////public Guid UserSessionGuid { get; set; }

        ////#region IExtensibleDataObject Members

        ////public ExtensionDataObject ExtensionData { get; set; }

        ////#endregion
        //#region Protected methods

        //protected void WalkObjectGraph(Func<EntityBase, bool> snippetForObject,
        //                               Action<IList> snippetForCollection,
        //                               params string[] exemptProperties)
        //{
        //    List<EntityBase> visited = new List<EntityBase>();
        //    Action<EntityBase> walk = null;

        //    List<string> exemptions = new List<string>();
        //    if (exemptProperties != null)
        //        exemptions = exemptProperties.ToList();

        //    walk = (o) =>
        //    {
        //        if (o != null && !visited.Contains(o))
        //        {
        //            visited.Add(o);

        //            bool exitWalk = snippetForObject.Invoke(o);

        //            if (!exitWalk)
        //            {
        //                PropertyInfo[] properties = o.GetBrowsableProperties();
        //                foreach (PropertyInfo property in properties)
        //                {
        //                    if (!exemptions.Contains(property.Name))
        //                    {
        //                        if (property.PropertyType.IsSubclassOf(typeof(EntityBase)))
        //                        {
        //                            EntityBase obj = (EntityBase)(property.GetValue(o, null));
        //                            walk(obj);
        //                        }
        //                        else
        //                        {
        //                            IList coll = property.GetValue(o, null) as IList;
        //                            if (coll != null)
        //                            {
        //                                snippetForCollection.Invoke(coll);

        //                                foreach (object item in coll)
        //                                {
        //                                    if (item is EntityBase)
        //                                        walk((EntityBase)item);
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    };

        //    walk(this);
        //}

        //#endregion

    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   An entity base simple. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    [DataContract]
    public abstract class EntityBaseSimple : DataContractBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public EntityBaseSimple()
        {
            EntityGuid = Guid.Empty;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="o">    The EntityBase to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public EntityBaseSimple(EntityBase o)
        {
            if (o != null)
            {
                EntityIdentifier = o.EntityIdentifier;
                EntityGuid = o.EntityGuid;
            }
            else
            {
                EntityGuid = Guid.Empty;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the entity. </summary>
        ///
        /// <value> The identifier of the entity. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public int EntityIdentifier { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a unique identifier of the entity. </summary>
        ///
        /// <value> Unique identifier of the entity. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        [DataMember]
        public Guid EntityGuid { get; set; }



    }
}

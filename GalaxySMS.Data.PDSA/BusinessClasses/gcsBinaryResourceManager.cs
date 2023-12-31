using System;
using System.Collections.Generic;
using GalaxySMS.Business.Entities;
using GalaxySMS.EntityLayer;
using GCS.Core.Common.Utils;

namespace GalaxySMS.BusinessLayer
{
    /// <summary>
    ///     This class is used when you need to add, edit, delete, select and validate data for the gcsBinaryResourcePDSA
    ///     table.
    ///     This class is generated by the Haystack Code Generator for .NET.
    ///     You may add additional methods to this class.
    /// </summary>
    public partial class gcsBinaryResourcePDSAManager
    {
        #region TrackChanges Method

        /// <summary>
        ///     Implement your change tracking logic here
        /// </summary>
        /// <param name="action">Can be 'Insert', 'Update', 'Delete', or anything you want</param>
        public void TrackChanges(string action)
        {
        }

        #endregion

        #region Your Custom Properties and Methods

        #endregion

        #region InitEntityObject Method

        /// <summary>
        ///     Call this method to initialize the 'Entity' object with any default values
        /// </summary>
        public void InitEntityObject()
        {
            InitEntityObject(Entity);
        }

        public void InitEntityObject(gcsBinaryResource entity)
        {
            SimpleMapper.PropertyMap(entity, Entity);
        }

        public IEnumerable<gcsBinaryResource> ConvertPDSACollection(gcsBinaryResourcePDSACollection pdsaCollection)
        {
            var results = new List<gcsBinaryResource>();
            foreach (var pdsaEntity in pdsaCollection)
            {
                var convertedEntity = new gcsBinaryResource();
                SimpleMapper.PropertyMap(pdsaEntity, convertedEntity);
                results.Add(convertedEntity);
            }
            return results;
        }

        /// <summary>
        ///     Call this method to initialize an gcsBinaryResourcePDSA object with any default values
        /// </summary>
        /// <param name="entity">An gcsBinaryResourcePDSA object</param>
        public void InitEntityObject(gcsBinaryResourcePDSA entity)
        {
            // TODO: Set any defaults here
            // Below is an Example 
            // entity.StartDate = DateTimeOffset.Now;

            entity.InsertName = PDSALoginName;
            entity.InsertDate = DateTimeOffset.Now;
            entity.UpdateName = PDSALoginName;
            entity.UpdateDate = DateTimeOffset.Now;
            entity.ConcurrencyValue = 1;
        }

        #endregion
    }
}
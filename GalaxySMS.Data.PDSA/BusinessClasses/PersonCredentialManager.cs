using GalaxySMS.Business.Entities;
using GalaxySMS.EntityLayer;
using GCS.Core.Common.Utils;
using System;
using System.Collections.Generic;

namespace GalaxySMS.BusinessLayer
{
    /// <summary>
    /// This class is used when you need to add, edit, delete, select and validate data for the PersonCredentialPDSA table.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// You may add additional methods to this class.
    /// </summary>
    public partial class PersonCredentialPDSAManager
    {
        #region Your Custom Properties and Methods

        #endregion

        #region InitEntityObject Method
        /// <summary>
        /// Call this method to initialize the 'Entity' object with any default values
        /// </summary>
        public void InitEntityObject()
        {
            InitEntityObject(Entity);
        }

        /// <summary>
        /// Call this method to initialize an PersonCredentialPDSA object with any default values
        /// </summary>
        /// <param name="entity">An PersonCredentialPDSA object</param>
        public void InitEntityObject(PersonCredentialPDSA entity)
        {
            // TODO: Set any defaults here
            // Below is an Example 
            // entity.StartDate = DateTimeOffset.Now;

            entity.InsertName = this.PDSALoginName;
            entity.InsertDate = DateTimeOffset.Now;
            entity.UpdateName = this.PDSALoginName;
            entity.UpdateDate = DateTimeOffset.Now;
            entity.ConcurrencyValue = 1;
        }

        /// <summary>
        /// Call this method to initialize the 'Entity' object from an object that can be mapped 
        /// </summary>
        public void InitEntityObject(PersonCredential entity)
        {
            SimpleMapper.PropertyMap(entity, Entity);
        }

        #endregion

        #region ConvertPDSACollection
        /// <summary>
        /// Call this method to convert a PDSACollection to an IEnumerable collection of an equivalent PersonCredential objects
        /// </summary>
        public IEnumerable<PersonCredential> ConvertPDSACollection(PersonCredentialPDSACollection pdsaCollection)
        {
            var results = new List<PersonCredential>();
            foreach (var pdsaEntity in pdsaCollection)
            {
                var convertedEntity = new PersonCredential();
                SimpleMapper.PropertyMap(pdsaEntity, convertedEntity);
                results.Add(convertedEntity);
            }
            return results;
        }

        /// <summary>
        /// Call this method to convert a IEnumerable<T> to an IEnumerable collection of an equivalent PersonCredential objects
        /// </summary>
        public IEnumerable<PersonCredential> ConvertPDSACollection(IEnumerable<PersonCredentialPDSA> pdsaCollection)
        {
            var results = new List<PersonCredential>();
            foreach (var pdsaEntity in pdsaCollection)
            {
                var convertedEntity = new PersonCredential();
                SimpleMapper.PropertyMap(pdsaEntity, convertedEntity);
                results.Add(convertedEntity);
            }
            return results;
        }
        #endregion

        #region TrackChanges Method
        /// <summary>
        /// Implement your change tracking logic here
        /// </summary>
        /// <param name="action">Can be 'Insert', 'Update', 'Delete', or anything you want</param>
        public void TrackChanges(string action)
        {
        }
        #endregion
    }
}


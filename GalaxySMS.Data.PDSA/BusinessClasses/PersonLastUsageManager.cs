

using GalaxySMS.EntityLayer;

namespace GalaxySMS.BusinessLayer
{
    /// <summary>
    /// This class is used when you need to add, edit, delete, select and validate data for the PersonLastUsagePDSA table.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// You may add additional methods to this class.
    /// </summary>
    public partial class PersonLastUsagePDSAManager
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
        /// Call this method to initialize an PersonLastUsagePDSA object with any default values
        /// </summary>
        /// <param name="entity">An PersonLastUsagePDSA object</param>
        public void InitEntityObject(PersonLastUsagePDSA entity)
        {
            // TODO: Set any defaults here
            // Below is an Example 
            // entity.StartDate = DateTimeOffset.Now;

        }

        /// <summary>
        /// Call this method to initialize the 'Entity' object from an object that can be mapped 
        /// </summary>
        //public void InitEntityObject(gcsClass entity)
        //{
        //    SimpleMapper.PropertyMap(entity, Entity);
        //}

        #endregion

        #region ConvertPDSACollection
        //  /// <summary>
        //  /// Call this method to convert a PDSACollection to an IEnumerable collection of an equivalent gcsClass objects
        //  /// </summary>
        //  public IEnumerable<gcsClass> ConvertPDSACollection(gcsClassPDSACollection pdsaCollection)
        //  {	
        //var results = new List<gcsClass>();
        //    foreach (var pdsaEntity in pdsaCollection)
        //    {
        //      var convertedEntity = new gcsClass();
        //      SimpleMapper.PropertyMap(pdsaEntity, convertedEntity);
        //      results.Add(convertedEntity);
        //    }
        //    return results;
        //  }

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


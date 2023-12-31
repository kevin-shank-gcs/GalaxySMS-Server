using System;

using PDSA.Common;
using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all properties of the BackgroundJobDataPDSA class.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class BackgroundJobDataPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private BackgroundJobDataPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new BackgroundJobDataPDSA Entity
    {
      get { return _Entity; }
      set
      {
        _Entity = value;
        base.Entity = value;
      }
    }
    #endregion
    
    #region Clone Entity Class
    /// <summary>
    /// Clones the current BackgroundJobDataPDSA
    /// </summary>
    /// <returns>A cloned BackgroundJobDataPDSA object</returns>
    public BackgroundJobDataPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in BackgroundJobDataPDSA
    /// </summary>
    /// <param name="entityToClone">The BackgroundJobDataPDSA entity to clone</param>
    /// <returns>A cloned BackgroundJobDataPDSA object</returns>
    public BackgroundJobDataPDSA CloneEntity(BackgroundJobDataPDSA entityToClone)
    {
      BackgroundJobDataPDSA newEntity = new BackgroundJobDataPDSA();

      newEntity.BackgroundJobUid = entityToClone.BackgroundJobUid;
      newEntity.Data = entityToClone.Data;

      return newEntity;
    }
    #endregion

    #region CreateProperties Method
    /// <summary>
    /// Creates the collection of PDSAProperty objects. These are used to control validation and null handling.
    /// </summary>
    /// <returns>A collection of PDSAProperty objects</returns>
    public override PDSAProperties CreateProperties()
    {
      PDSAProperties props = new PDSAProperties();
      
      props.Add(PDSAProperty.Create(BackgroundJobDataPDSAValidator.ColumnNames.BackgroundJobUid, GetResourceMessage("GCS_BackgroundJobDataPDSA_BackgroundJobUid_Header", "Background Job Uid"), true, typeof(Guid), -1, GetResourceMessage("GCS_BackgroundJobDataPDSA_BackgroundJobUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(BackgroundJobDataPDSAValidator.ColumnNames.Data, GetResourceMessage("GCS_BackgroundJobDataPDSA_Data_Header", "Data"), true, typeof(string), 1073741823, GetResourceMessage("GCS_BackgroundJobDataPDSA_Data_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      
      return props;
    }
    #endregion

    #region Initialize Entity
    /// <summary>
    /// This method is called from the CreateNewEntity Method. All the properties for the Entity are set to default values here by the code generator.
    /// </summary>
    protected override void InitializeEntity()
    {
      Entity.BackgroundJobUid = Guid.Empty;
      Entity.Data = string.Empty;

      Entity.ResetAllIsDirtyProperties();
    }
    #endregion
    
    #region InitProperties Method
    /// <summary>
    /// Called by the constructor to create the PDSAProperties collection of all properties that will be validated.
    /// </summary>
    protected override void InitProperties()
    {
      // Set the Properties collection to the collection of Entity Properties
      Properties = CreateProperties();
    }
    #endregion

    #region EntityDataToProperties Method
    /// <summary>
    /// Moves the Entity class data into the Properties collection.
    /// </summary>
    protected override void EntityDataToProperties()
    {
      if (Properties == null)
        InitProperties();
      
      if(!Properties.GetByName(BackgroundJobDataPDSAValidator.ColumnNames.BackgroundJobUid).SetAsNull)
        Properties.GetByName(BackgroundJobDataPDSAValidator.ColumnNames.BackgroundJobUid).Value = Entity.BackgroundJobUid;
      if(!Properties.GetByName(BackgroundJobDataPDSAValidator.ColumnNames.Data).SetAsNull)
        Properties.GetByName(BackgroundJobDataPDSAValidator.ColumnNames.Data).Value = Entity.Data;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
        InitProperties();

      if(Properties.GetByName(BackgroundJobDataPDSAValidator.ColumnNames.BackgroundJobUid).IsNull == false)
        Entity.BackgroundJobUid = Properties.GetByName(BackgroundJobDataPDSAValidator.ColumnNames.BackgroundJobUid).GetAsGuid();
      if(Properties.GetByName(BackgroundJobDataPDSAValidator.ColumnNames.Data).IsNull == false)
        Entity.Data = Properties.GetByName(BackgroundJobDataPDSAValidator.ColumnNames.Data).GetAsString();
    }
    #endregion
    
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the BackgroundJobDataPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'BackgroundJobUid'
    /// </summary>
    public static string BackgroundJobUid = "BackgroundJobUid";
    /// <summary>
    /// Returns 'Data'
    /// </summary>
    public static string Data = "Data";
    }
    #endregion
  }
}

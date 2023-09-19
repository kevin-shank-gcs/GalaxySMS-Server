using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the gcsEntityCountPDSA_InsertPanelCountPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class gcsEntityCountPDSA_InsertPanelCountPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private gcsEntityCountPDSA_InsertPanelCountPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new gcsEntityCountPDSA_InsertPanelCountPDSA Entity
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
    /// Clones the current gcsEntityCountPDSA_InsertPanelCountPDSA
    /// </summary>
    /// <returns>A cloned gcsEntityCountPDSA_InsertPanelCountPDSA object</returns>
    public gcsEntityCountPDSA_InsertPanelCountPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in gcsEntityCountPDSA_InsertPanelCountPDSA
    /// </summary>
    /// <param name="entityToClone">The gcsEntityCountPDSA_InsertPanelCountPDSA entity to clone</param>
    /// <returns>A cloned gcsEntityCountPDSA_InsertPanelCountPDSA object</returns>
    public gcsEntityCountPDSA_InsertPanelCountPDSA CloneEntity(gcsEntityCountPDSA_InsertPanelCountPDSA entityToClone)
    {
      gcsEntityCountPDSA_InsertPanelCountPDSA newEntity = new gcsEntityCountPDSA_InsertPanelCountPDSA();


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
      
      props.Add(PDSAProperty.Create(gcsEntityCountPDSA_InsertPanelCountPDSAValidator.ParameterNames.EntityId, GetResourceMessage("GCS_gcsEntityCountPDSA_InsertPanelCountPDSA_EntityId_Header", "Entity Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_gcsEntityCountPDSA_InsertPanelCountPDSA_EntityId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(gcsEntityCountPDSA_InsertPanelCountPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_gcsEntityCountPDSA_InsertPanelCountPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_gcsEntityCountPDSA_InsertPanelCountPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
      return props;
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
      {
        InitProperties();
      }
      
      Properties.GetByName(gcsEntityCountPDSA_InsertPanelCountPDSAValidator.ParameterNames.EntityId).Value = Entity.EntityId;
      Properties.GetByName(gcsEntityCountPDSA_InsertPanelCountPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
      {
        InitProperties();
      }

      if(Properties.GetByName(gcsEntityCountPDSA_InsertPanelCountPDSAValidator.ParameterNames.EntityId).IsNull == false)
        Entity.EntityId = Properties.GetByName(gcsEntityCountPDSA_InsertPanelCountPDSAValidator.ParameterNames.EntityId).GetAsGuid();
      if(Properties.GetByName(gcsEntityCountPDSA_InsertPanelCountPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = Properties.GetByName(gcsEntityCountPDSA_InsertPanelCountPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the gcsEntityCountPDSA_InsertPanelCountPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@EntityId'
    /// </summary>
    public static string EntityId = "@EntityId";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}

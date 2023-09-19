using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the ResetConcurrencyValuePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class ResetConcurrencyValuePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private ResetConcurrencyValuePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new ResetConcurrencyValuePDSA Entity
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
    /// Clones the current ResetConcurrencyValuePDSA
    /// </summary>
    /// <returns>A cloned ResetConcurrencyValuePDSA object</returns>
    public ResetConcurrencyValuePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in ResetConcurrencyValuePDSA
    /// </summary>
    /// <param name="entityToClone">The ResetConcurrencyValuePDSA entity to clone</param>
    /// <returns>A cloned ResetConcurrencyValuePDSA object</returns>
    public ResetConcurrencyValuePDSA CloneEntity(ResetConcurrencyValuePDSA entityToClone)
    {
      ResetConcurrencyValuePDSA newEntity = new ResetConcurrencyValuePDSA();


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
      
      props.Add(PDSAProperty.Create(ResetConcurrencyValuePDSAValidator.ParameterNames.tableName, GetResourceMessage("GCS_ResetConcurrencyValuePDSA_tableName_Header", "table Name"), false, typeof(string), 8000, GetResourceMessage("GCS_ResetConcurrencyValuePDSA_tableName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(ResetConcurrencyValuePDSAValidator.ParameterNames.uidColumn, GetResourceMessage("GCS_ResetConcurrencyValuePDSA_uidColumn_Header", "uid Column"), false, typeof(string), 8000, GetResourceMessage("GCS_ResetConcurrencyValuePDSA_uidColumn_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(ResetConcurrencyValuePDSAValidator.ParameterNames.uid, GetResourceMessage("GCS_ResetConcurrencyValuePDSA_uid_Header", "uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_ResetConcurrencyValuePDSA_uid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(ResetConcurrencyValuePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_ResetConcurrencyValuePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_ResetConcurrencyValuePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      Properties.GetByName(ResetConcurrencyValuePDSAValidator.ParameterNames.tableName).Value = Entity.tableName;
      Properties.GetByName(ResetConcurrencyValuePDSAValidator.ParameterNames.uidColumn).Value = Entity.uidColumn;
      Properties.GetByName(ResetConcurrencyValuePDSAValidator.ParameterNames.uid).Value = Entity.uid;
      Properties.GetByName(ResetConcurrencyValuePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(Properties.GetByName(ResetConcurrencyValuePDSAValidator.ParameterNames.tableName).IsNull == false)
        Entity.tableName = Properties.GetByName(ResetConcurrencyValuePDSAValidator.ParameterNames.tableName).GetAsString();
      if(Properties.GetByName(ResetConcurrencyValuePDSAValidator.ParameterNames.uidColumn).IsNull == false)
        Entity.uidColumn = Properties.GetByName(ResetConcurrencyValuePDSAValidator.ParameterNames.uidColumn).GetAsString();
      if(Properties.GetByName(ResetConcurrencyValuePDSAValidator.ParameterNames.uid).IsNull == false)
        Entity.uid = Properties.GetByName(ResetConcurrencyValuePDSAValidator.ParameterNames.uid).GetAsGuid();
      if(Properties.GetByName(ResetConcurrencyValuePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = Properties.GetByName(ResetConcurrencyValuePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the ResetConcurrencyValuePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@tableName'
    /// </summary>
    public static string tableName = "@tableName";
    /// <summary>
    /// Returns '@uidColumn'
    /// </summary>
    public static string uidColumn = "@uidColumn";
    /// <summary>
    /// Returns '@uid'
    /// </summary>
    public static string uid = "@uid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}

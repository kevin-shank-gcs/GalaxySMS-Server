using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the OutputDeviceUids_SelectForUserIdPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class OutputDeviceUids_SelectForUserIdPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private OutputDeviceUids_SelectForUserIdPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new OutputDeviceUids_SelectForUserIdPDSA Entity
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
    /// Clones the current OutputDeviceUids_SelectForUserIdPDSA
    /// </summary>
    /// <returns>A cloned OutputDeviceUids_SelectForUserIdPDSA object</returns>
    public OutputDeviceUids_SelectForUserIdPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in OutputDeviceUids_SelectForUserIdPDSA
    /// </summary>
    /// <param name="entityToClone">The OutputDeviceUids_SelectForUserIdPDSA entity to clone</param>
    /// <returns>A cloned OutputDeviceUids_SelectForUserIdPDSA object</returns>
    public OutputDeviceUids_SelectForUserIdPDSA CloneEntity(OutputDeviceUids_SelectForUserIdPDSA entityToClone)
    {
      OutputDeviceUids_SelectForUserIdPDSA newEntity = new OutputDeviceUids_SelectForUserIdPDSA();

      newEntity.OutputDeviceUid = entityToClone.OutputDeviceUid;

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
      
      props.Add(PDSAProperty.Create(OutputDeviceUids_SelectForUserIdPDSAValidator.ParameterNames.UserId, GetResourceMessage("GCS_OutputDeviceUids_SelectForUserIdPDSA_UserId_Header", "User Id"), false, typeof(Guid), 0, GetResourceMessage("GCS_OutputDeviceUids_SelectForUserIdPDSA_UserId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(OutputDeviceUids_SelectForUserIdPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_OutputDeviceUids_SelectForUserIdPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_OutputDeviceUids_SelectForUserIdPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      if (this.Properties == null)
      {
        this.InitProperties();
      }
      
      this.Properties.GetByName(OutputDeviceUids_SelectForUserIdPDSAValidator.ParameterNames.UserId).Value = Entity.UserId;
      this.Properties.GetByName(OutputDeviceUids_SelectForUserIdPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (this.Properties == null)
      {
        this.InitProperties();
      }

      if(this.Properties.GetByName(OutputDeviceUids_SelectForUserIdPDSAValidator.ParameterNames.UserId).IsNull == false)
        Entity.UserId = this.Properties.GetByName(OutputDeviceUids_SelectForUserIdPDSAValidator.ParameterNames.UserId).GetAsGuid();
      if(this.Properties.GetByName(OutputDeviceUids_SelectForUserIdPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(OutputDeviceUids_SelectForUserIdPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the OutputDeviceUids_SelectForUserIdPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'OutputDeviceUid'
    /// </summary>
    public static string OutputDeviceUid = "OutputDeviceUid";
    /// <summary>
    /// Returns '@UserId'
    /// </summary>
    public static string UserId = "@UserId";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the OutputDeviceUids_SelectForUserIdPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@UserId'
    /// </summary>
    public static string UserId = "@UserId";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}

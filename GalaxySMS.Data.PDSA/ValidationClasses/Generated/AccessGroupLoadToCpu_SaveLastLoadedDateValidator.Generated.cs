using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the AccessGroupLoadToCpu_SaveLastLoadedDatePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class AccessGroupLoadToCpu_SaveLastLoadedDatePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private AccessGroupLoadToCpu_SaveLastLoadedDatePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new AccessGroupLoadToCpu_SaveLastLoadedDatePDSA Entity
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
    /// Clones the current AccessGroupLoadToCpu_SaveLastLoadedDatePDSA
    /// </summary>
    /// <returns>A cloned AccessGroupLoadToCpu_SaveLastLoadedDatePDSA object</returns>
    public AccessGroupLoadToCpu_SaveLastLoadedDatePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in AccessGroupLoadToCpu_SaveLastLoadedDatePDSA
    /// </summary>
    /// <param name="entityToClone">The AccessGroupLoadToCpu_SaveLastLoadedDatePDSA entity to clone</param>
    /// <returns>A cloned AccessGroupLoadToCpu_SaveLastLoadedDatePDSA object</returns>
    public AccessGroupLoadToCpu_SaveLastLoadedDatePDSA CloneEntity(AccessGroupLoadToCpu_SaveLastLoadedDatePDSA entityToClone)
    {
      AccessGroupLoadToCpu_SaveLastLoadedDatePDSA newEntity = new AccessGroupLoadToCpu_SaveLastLoadedDatePDSA();


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
      
      props.Add(PDSAProperty.Create(AccessGroupLoadToCpu_SaveLastLoadedDatePDSAValidator.ParameterNames.CpuUid, GetResourceMessage("GCS_AccessGroupLoadToCpu_SaveLastLoadedDatePDSA_CpuUid_Header", "Cpu Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_AccessGroupLoadToCpu_SaveLastLoadedDatePDSA_CpuUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessGroupLoadToCpu_SaveLastLoadedDatePDSAValidator.ParameterNames.AccessGroupNumber, GetResourceMessage("GCS_AccessGroupLoadToCpu_SaveLastLoadedDatePDSA_AccessGroupNumber_Header", "Access Group Number"), false, typeof(int), 0, GetResourceMessage("GCS_AccessGroupLoadToCpu_SaveLastLoadedDatePDSA_AccessGroupNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(AccessGroupLoadToCpu_SaveLastLoadedDatePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_AccessGroupLoadToCpu_SaveLastLoadedDatePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_AccessGroupLoadToCpu_SaveLastLoadedDatePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      Properties.GetByName(AccessGroupLoadToCpu_SaveLastLoadedDatePDSAValidator.ParameterNames.CpuUid).Value = Entity.CpuUid;
      Properties.GetByName(AccessGroupLoadToCpu_SaveLastLoadedDatePDSAValidator.ParameterNames.AccessGroupNumber).Value = Entity.AccessGroupNumber;
      Properties.GetByName(AccessGroupLoadToCpu_SaveLastLoadedDatePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(Properties.GetByName(AccessGroupLoadToCpu_SaveLastLoadedDatePDSAValidator.ParameterNames.CpuUid).IsNull == false)
        Entity.CpuUid = Properties.GetByName(AccessGroupLoadToCpu_SaveLastLoadedDatePDSAValidator.ParameterNames.CpuUid).GetAsGuid();
      if(Properties.GetByName(AccessGroupLoadToCpu_SaveLastLoadedDatePDSAValidator.ParameterNames.AccessGroupNumber).IsNull == false)
        Entity.AccessGroupNumber = Properties.GetByName(AccessGroupLoadToCpu_SaveLastLoadedDatePDSAValidator.ParameterNames.AccessGroupNumber).GetAsInteger();
      if(Properties.GetByName(AccessGroupLoadToCpu_SaveLastLoadedDatePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = Properties.GetByName(AccessGroupLoadToCpu_SaveLastLoadedDatePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the AccessGroupLoadToCpu_SaveLastLoadedDatePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@CpuUid'
    /// </summary>
    public static string CpuUid = "@CpuUid";
    /// <summary>
    /// Returns '@AccessGroupNumber'
    /// </summary>
    public static string AccessGroupNumber = "@AccessGroupNumber";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}

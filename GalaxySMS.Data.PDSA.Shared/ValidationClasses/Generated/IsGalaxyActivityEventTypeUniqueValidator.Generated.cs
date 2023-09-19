using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsGalaxyActivityEventTypeUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsGalaxyActivityEventTypeUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsGalaxyActivityEventTypeUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsGalaxyActivityEventTypeUniquePDSA Entity
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
    /// Clones the current IsGalaxyActivityEventTypeUniquePDSA
    /// </summary>
    /// <returns>A cloned IsGalaxyActivityEventTypeUniquePDSA object</returns>
    public IsGalaxyActivityEventTypeUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsGalaxyActivityEventTypeUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsGalaxyActivityEventTypeUniquePDSA entity to clone</param>
    /// <returns>A cloned IsGalaxyActivityEventTypeUniquePDSA object</returns>
    public IsGalaxyActivityEventTypeUniquePDSA CloneEntity(IsGalaxyActivityEventTypeUniquePDSA entityToClone)
    {
      IsGalaxyActivityEventTypeUniquePDSA newEntity = new IsGalaxyActivityEventTypeUniquePDSA();

      newEntity.Result = entityToClone.Result;

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
      
      props.Add(PDSAProperty.Create(IsGalaxyActivityEventTypeUniquePDSAValidator.ParameterNames.GalaxyActivityEventTypeUid, GetResourceMessage("GCS_IsGalaxyActivityEventTypeUniquePDSA_GalaxyActivityEventTypeUid_Header", "Galaxy Activity Event Type Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsGalaxyActivityEventTypeUniquePDSA_GalaxyActivityEventTypeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyActivityEventTypeUniquePDSAValidator.ParameterNames.EventType, GetResourceMessage("GCS_IsGalaxyActivityEventTypeUniquePDSA_EventType_Header", "Event Type"), false, typeof(string), 8000, GetResourceMessage("GCS_IsGalaxyActivityEventTypeUniquePDSA_EventType_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyActivityEventTypeUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsGalaxyActivityEventTypeUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsGalaxyActivityEventTypeUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyActivityEventTypeUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsGalaxyActivityEventTypeUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsGalaxyActivityEventTypeUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsGalaxyActivityEventTypeUniquePDSAValidator.ParameterNames.GalaxyActivityEventTypeUid).Value = Entity.GalaxyActivityEventTypeUid;
      this.Properties.GetByName(IsGalaxyActivityEventTypeUniquePDSAValidator.ParameterNames.EventType).Value = Entity.EventType;
      this.Properties.GetByName(IsGalaxyActivityEventTypeUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsGalaxyActivityEventTypeUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsGalaxyActivityEventTypeUniquePDSAValidator.ParameterNames.GalaxyActivityEventTypeUid).IsNull == false)
        Entity.GalaxyActivityEventTypeUid = this.Properties.GetByName(IsGalaxyActivityEventTypeUniquePDSAValidator.ParameterNames.GalaxyActivityEventTypeUid).GetAsGuid();
      if(this.Properties.GetByName(IsGalaxyActivityEventTypeUniquePDSAValidator.ParameterNames.EventType).IsNull == false)
        Entity.EventType = this.Properties.GetByName(IsGalaxyActivityEventTypeUniquePDSAValidator.ParameterNames.EventType).GetAsString();
      if(this.Properties.GetByName(IsGalaxyActivityEventTypeUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsGalaxyActivityEventTypeUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsGalaxyActivityEventTypeUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsGalaxyActivityEventTypeUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsGalaxyActivityEventTypeUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'Result'
    /// </summary>
    public static string Result = "Result";
    /// <summary>
    /// Returns '@GalaxyActivityEventTypeUid'
    /// </summary>
    public static string GalaxyActivityEventTypeUid = "@GalaxyActivityEventTypeUid";
    /// <summary>
    /// Returns '@EventType'
    /// </summary>
    public static string EventType = "@EventType";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsGalaxyActivityEventTypeUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@GalaxyActivityEventTypeUid'
    /// </summary>
    public static string GalaxyActivityEventTypeUid = "@GalaxyActivityEventTypeUid";
    /// <summary>
    /// Returns '@EventType'
    /// </summary>
    public static string EventType = "@EventType";
    /// <summary>
    /// Returns '@Result'
    /// </summary>
    public static string Result = "@Result";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}

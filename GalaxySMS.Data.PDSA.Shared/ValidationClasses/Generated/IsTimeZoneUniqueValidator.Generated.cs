using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsTimeZoneUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsTimeZoneUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsTimeZoneUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsTimeZoneUniquePDSA Entity
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
    /// Clones the current IsTimeZoneUniquePDSA
    /// </summary>
    /// <returns>A cloned IsTimeZoneUniquePDSA object</returns>
    public IsTimeZoneUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsTimeZoneUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsTimeZoneUniquePDSA entity to clone</param>
    /// <returns>A cloned IsTimeZoneUniquePDSA object</returns>
    public IsTimeZoneUniquePDSA CloneEntity(IsTimeZoneUniquePDSA entityToClone)
    {
      IsTimeZoneUniquePDSA newEntity = new IsTimeZoneUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsTimeZoneUniquePDSAValidator.ParameterNames.TimeZoneUid, GetResourceMessage("GCS_IsTimeZoneUniquePDSA_TimeZoneUid_Header", "Time Zone Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsTimeZoneUniquePDSA_TimeZoneUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsTimeZoneUniquePDSAValidator.ParameterNames.Id, GetResourceMessage("GCS_IsTimeZoneUniquePDSA_Id_Header", "Id"), false, typeof(string), 8000, GetResourceMessage("GCS_IsTimeZoneUniquePDSA_Id_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsTimeZoneUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsTimeZoneUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsTimeZoneUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsTimeZoneUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsTimeZoneUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsTimeZoneUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsTimeZoneUniquePDSAValidator.ParameterNames.TimeZoneUid).Value = Entity.TimeZoneUid;
      this.Properties.GetByName(IsTimeZoneUniquePDSAValidator.ParameterNames.Id).Value = Entity.Id;
      this.Properties.GetByName(IsTimeZoneUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsTimeZoneUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsTimeZoneUniquePDSAValidator.ParameterNames.TimeZoneUid).IsNull == false)
        Entity.TimeZoneUid = this.Properties.GetByName(IsTimeZoneUniquePDSAValidator.ParameterNames.TimeZoneUid).GetAsGuid();
      if(this.Properties.GetByName(IsTimeZoneUniquePDSAValidator.ParameterNames.Id).IsNull == false)
        Entity.Id = this.Properties.GetByName(IsTimeZoneUniquePDSAValidator.ParameterNames.Id).GetAsString();
      if(this.Properties.GetByName(IsTimeZoneUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsTimeZoneUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsTimeZoneUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsTimeZoneUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsTimeZoneUniquePDSA class.
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
    /// Returns '@TimeZoneUid'
    /// </summary>
    public static string TimeZoneUid = "@TimeZoneUid";
    /// <summary>
    /// Returns '@Id'
    /// </summary>
    public static string Id = "@Id";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsTimeZoneUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@TimeZoneUid'
    /// </summary>
    public static string TimeZoneUid = "@TimeZoneUid";
    /// <summary>
    /// Returns '@Id'
    /// </summary>
    public static string Id = "@Id";
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

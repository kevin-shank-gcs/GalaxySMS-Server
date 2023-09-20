using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsPersonNumberPropertyUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsPersonNumberPropertyUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsPersonNumberPropertyUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsPersonNumberPropertyUniquePDSA Entity
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
    /// Clones the current IsPersonNumberPropertyUniquePDSA
    /// </summary>
    /// <returns>A cloned IsPersonNumberPropertyUniquePDSA object</returns>
    public IsPersonNumberPropertyUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsPersonNumberPropertyUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsPersonNumberPropertyUniquePDSA entity to clone</param>
    /// <returns>A cloned IsPersonNumberPropertyUniquePDSA object</returns>
    public IsPersonNumberPropertyUniquePDSA CloneEntity(IsPersonNumberPropertyUniquePDSA entityToClone)
    {
      IsPersonNumberPropertyUniquePDSA newEntity = new IsPersonNumberPropertyUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsPersonNumberPropertyUniquePDSAValidator.ParameterNames.PersonNumberPropertyUid, GetResourceMessage("GCS_IsPersonNumberPropertyUniquePDSA_PersonNumberPropertyUid_Header", "Person Number Property Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsPersonNumberPropertyUniquePDSA_PersonNumberPropertyUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsPersonNumberPropertyUniquePDSAValidator.ParameterNames.PersonUid, GetResourceMessage("GCS_IsPersonNumberPropertyUniquePDSA_PersonUid_Header", "Person Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsPersonNumberPropertyUniquePDSA_PersonUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsPersonNumberPropertyUniquePDSAValidator.ParameterNames.UserDefinedPropertyUid, GetResourceMessage("GCS_IsPersonNumberPropertyUniquePDSA_UserDefinedPropertyUid_Header", "User Defined Property Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsPersonNumberPropertyUniquePDSA_UserDefinedPropertyUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsPersonNumberPropertyUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsPersonNumberPropertyUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsPersonNumberPropertyUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsPersonNumberPropertyUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsPersonNumberPropertyUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsPersonNumberPropertyUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsPersonNumberPropertyUniquePDSAValidator.ParameterNames.PersonNumberPropertyUid).Value = Entity.PersonNumberPropertyUid;
      this.Properties.GetByName(IsPersonNumberPropertyUniquePDSAValidator.ParameterNames.PersonUid).Value = Entity.PersonUid;
      this.Properties.GetByName(IsPersonNumberPropertyUniquePDSAValidator.ParameterNames.UserDefinedPropertyUid).Value = Entity.UserDefinedPropertyUid;
      this.Properties.GetByName(IsPersonNumberPropertyUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsPersonNumberPropertyUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsPersonNumberPropertyUniquePDSAValidator.ParameterNames.PersonNumberPropertyUid).IsNull == false)
        Entity.PersonNumberPropertyUid = this.Properties.GetByName(IsPersonNumberPropertyUniquePDSAValidator.ParameterNames.PersonNumberPropertyUid).GetAsGuid();
      if(this.Properties.GetByName(IsPersonNumberPropertyUniquePDSAValidator.ParameterNames.PersonUid).IsNull == false)
        Entity.PersonUid = this.Properties.GetByName(IsPersonNumberPropertyUniquePDSAValidator.ParameterNames.PersonUid).GetAsGuid();
      if(this.Properties.GetByName(IsPersonNumberPropertyUniquePDSAValidator.ParameterNames.UserDefinedPropertyUid).IsNull == false)
        Entity.UserDefinedPropertyUid = this.Properties.GetByName(IsPersonNumberPropertyUniquePDSAValidator.ParameterNames.UserDefinedPropertyUid).GetAsGuid();
      if(this.Properties.GetByName(IsPersonNumberPropertyUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsPersonNumberPropertyUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsPersonNumberPropertyUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsPersonNumberPropertyUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsPersonNumberPropertyUniquePDSA class.
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
    /// Returns '@PersonNumberPropertyUid'
    /// </summary>
    public static string PersonNumberPropertyUid = "@PersonNumberPropertyUid";
    /// <summary>
    /// Returns '@PersonUid'
    /// </summary>
    public static string PersonUid = "@PersonUid";
    /// <summary>
    /// Returns '@UserDefinedPropertyUid'
    /// </summary>
    public static string UserDefinedPropertyUid = "@UserDefinedPropertyUid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsPersonNumberPropertyUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@PersonNumberPropertyUid'
    /// </summary>
    public static string PersonNumberPropertyUid = "@PersonNumberPropertyUid";
    /// <summary>
    /// Returns '@PersonUid'
    /// </summary>
    public static string PersonUid = "@PersonUid";
    /// <summary>
    /// Returns '@UserDefinedPropertyUid'
    /// </summary>
    public static string UserDefinedPropertyUid = "@UserDefinedPropertyUid";
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

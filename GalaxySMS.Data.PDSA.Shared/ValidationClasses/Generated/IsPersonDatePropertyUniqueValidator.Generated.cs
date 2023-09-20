using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsPersonDatePropertyUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsPersonDatePropertyUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsPersonDatePropertyUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsPersonDatePropertyUniquePDSA Entity
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
    /// Clones the current IsPersonDatePropertyUniquePDSA
    /// </summary>
    /// <returns>A cloned IsPersonDatePropertyUniquePDSA object</returns>
    public IsPersonDatePropertyUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsPersonDatePropertyUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsPersonDatePropertyUniquePDSA entity to clone</param>
    /// <returns>A cloned IsPersonDatePropertyUniquePDSA object</returns>
    public IsPersonDatePropertyUniquePDSA CloneEntity(IsPersonDatePropertyUniquePDSA entityToClone)
    {
      IsPersonDatePropertyUniquePDSA newEntity = new IsPersonDatePropertyUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsPersonDatePropertyUniquePDSAValidator.ParameterNames.PersonDatePropertyUid, GetResourceMessage("GCS_IsPersonDatePropertyUniquePDSA_PersonDatePropertyUid_Header", "Person Date Property Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsPersonDatePropertyUniquePDSA_PersonDatePropertyUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsPersonDatePropertyUniquePDSAValidator.ParameterNames.PersonUid, GetResourceMessage("GCS_IsPersonDatePropertyUniquePDSA_PersonUid_Header", "Person Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsPersonDatePropertyUniquePDSA_PersonUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsPersonDatePropertyUniquePDSAValidator.ParameterNames.UserDefinedPropertyUid, GetResourceMessage("GCS_IsPersonDatePropertyUniquePDSA_UserDefinedPropertyUid_Header", "User Defined Property Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsPersonDatePropertyUniquePDSA_UserDefinedPropertyUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsPersonDatePropertyUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsPersonDatePropertyUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsPersonDatePropertyUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsPersonDatePropertyUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsPersonDatePropertyUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsPersonDatePropertyUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsPersonDatePropertyUniquePDSAValidator.ParameterNames.PersonDatePropertyUid).Value = Entity.PersonDatePropertyUid;
      this.Properties.GetByName(IsPersonDatePropertyUniquePDSAValidator.ParameterNames.PersonUid).Value = Entity.PersonUid;
      this.Properties.GetByName(IsPersonDatePropertyUniquePDSAValidator.ParameterNames.UserDefinedPropertyUid).Value = Entity.UserDefinedPropertyUid;
      this.Properties.GetByName(IsPersonDatePropertyUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsPersonDatePropertyUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsPersonDatePropertyUniquePDSAValidator.ParameterNames.PersonDatePropertyUid).IsNull == false)
        Entity.PersonDatePropertyUid = this.Properties.GetByName(IsPersonDatePropertyUniquePDSAValidator.ParameterNames.PersonDatePropertyUid).GetAsGuid();
      if(this.Properties.GetByName(IsPersonDatePropertyUniquePDSAValidator.ParameterNames.PersonUid).IsNull == false)
        Entity.PersonUid = this.Properties.GetByName(IsPersonDatePropertyUniquePDSAValidator.ParameterNames.PersonUid).GetAsGuid();
      if(this.Properties.GetByName(IsPersonDatePropertyUniquePDSAValidator.ParameterNames.UserDefinedPropertyUid).IsNull == false)
        Entity.UserDefinedPropertyUid = this.Properties.GetByName(IsPersonDatePropertyUniquePDSAValidator.ParameterNames.UserDefinedPropertyUid).GetAsGuid();
      if(this.Properties.GetByName(IsPersonDatePropertyUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsPersonDatePropertyUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsPersonDatePropertyUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsPersonDatePropertyUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsPersonDatePropertyUniquePDSA class.
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
    /// Returns '@PersonDatePropertyUid'
    /// </summary>
    public static string PersonDatePropertyUid = "@PersonDatePropertyUid";
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
    /// Contains static string properties that represent the name of each property in the IsPersonDatePropertyUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@PersonDatePropertyUid'
    /// </summary>
    public static string PersonDatePropertyUid = "@PersonDatePropertyUid";
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

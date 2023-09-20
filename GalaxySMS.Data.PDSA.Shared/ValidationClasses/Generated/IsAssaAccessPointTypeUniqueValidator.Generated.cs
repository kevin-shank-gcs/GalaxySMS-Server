using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsAssaAccessPointTypeUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsAssaAccessPointTypeUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsAssaAccessPointTypeUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsAssaAccessPointTypeUniquePDSA Entity
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
    /// Clones the current IsAssaAccessPointTypeUniquePDSA
    /// </summary>
    /// <returns>A cloned IsAssaAccessPointTypeUniquePDSA object</returns>
    public IsAssaAccessPointTypeUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsAssaAccessPointTypeUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsAssaAccessPointTypeUniquePDSA entity to clone</param>
    /// <returns>A cloned IsAssaAccessPointTypeUniquePDSA object</returns>
    public IsAssaAccessPointTypeUniquePDSA CloneEntity(IsAssaAccessPointTypeUniquePDSA entityToClone)
    {
      IsAssaAccessPointTypeUniquePDSA newEntity = new IsAssaAccessPointTypeUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsAssaAccessPointTypeUniquePDSAValidator.ParameterNames.AssaAccessPointTypeUid, GetResourceMessage("GCS_IsAssaAccessPointTypeUniquePDSA_AssaAccessPointTypeUid_Header", "Assa Access Point Type Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsAssaAccessPointTypeUniquePDSA_AssaAccessPointTypeUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAssaAccessPointTypeUniquePDSAValidator.ParameterNames.Id, GetResourceMessage("GCS_IsAssaAccessPointTypeUniquePDSA_Id_Header", "Id"), false, typeof(string), 8000, GetResourceMessage("GCS_IsAssaAccessPointTypeUniquePDSA_Id_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAssaAccessPointTypeUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsAssaAccessPointTypeUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsAssaAccessPointTypeUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsAssaAccessPointTypeUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsAssaAccessPointTypeUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsAssaAccessPointTypeUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsAssaAccessPointTypeUniquePDSAValidator.ParameterNames.AssaAccessPointTypeUid).Value = Entity.AssaAccessPointTypeUid;
      this.Properties.GetByName(IsAssaAccessPointTypeUniquePDSAValidator.ParameterNames.Id).Value = Entity.Id;
      this.Properties.GetByName(IsAssaAccessPointTypeUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsAssaAccessPointTypeUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsAssaAccessPointTypeUniquePDSAValidator.ParameterNames.AssaAccessPointTypeUid).IsNull == false)
        Entity.AssaAccessPointTypeUid = this.Properties.GetByName(IsAssaAccessPointTypeUniquePDSAValidator.ParameterNames.AssaAccessPointTypeUid).GetAsGuid();
      if(this.Properties.GetByName(IsAssaAccessPointTypeUniquePDSAValidator.ParameterNames.Id).IsNull == false)
        Entity.Id = this.Properties.GetByName(IsAssaAccessPointTypeUniquePDSAValidator.ParameterNames.Id).GetAsString();
      if(this.Properties.GetByName(IsAssaAccessPointTypeUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsAssaAccessPointTypeUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsAssaAccessPointTypeUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsAssaAccessPointTypeUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsAssaAccessPointTypeUniquePDSA class.
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
    /// Returns '@AssaAccessPointTypeUid'
    /// </summary>
    public static string AssaAccessPointTypeUid = "@AssaAccessPointTypeUid";
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
    /// Contains static string properties that represent the name of each property in the IsAssaAccessPointTypeUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@AssaAccessPointTypeUid'
    /// </summary>
    public static string AssaAccessPointTypeUid = "@AssaAccessPointTypeUid";
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

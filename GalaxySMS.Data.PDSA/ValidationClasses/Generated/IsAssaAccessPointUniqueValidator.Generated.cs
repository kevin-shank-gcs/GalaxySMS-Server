using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsAssaAccessPointUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsAssaAccessPointUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsAssaAccessPointUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsAssaAccessPointUniquePDSA Entity
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
    /// Clones the current IsAssaAccessPointUniquePDSA
    /// </summary>
    /// <returns>A cloned IsAssaAccessPointUniquePDSA object</returns>
    public IsAssaAccessPointUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsAssaAccessPointUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsAssaAccessPointUniquePDSA entity to clone</param>
    /// <returns>A cloned IsAssaAccessPointUniquePDSA object</returns>
    public IsAssaAccessPointUniquePDSA CloneEntity(IsAssaAccessPointUniquePDSA entityToClone)
    {
      IsAssaAccessPointUniquePDSA newEntity = new IsAssaAccessPointUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsAssaAccessPointUniquePDSAValidator.ParameterNames.AssaAccessPointUid, GetResourceMessage("GCS_IsAssaAccessPointUniquePDSA_AssaAccessPointUid_Header", "Assa Access Point Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsAssaAccessPointUniquePDSA_AssaAccessPointUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAssaAccessPointUniquePDSAValidator.ParameterNames.AssaDsrUid, GetResourceMessage("GCS_IsAssaAccessPointUniquePDSA_AssaDsrUid_Header", "Assa Dsr Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsAssaAccessPointUniquePDSA_AssaDsrUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAssaAccessPointUniquePDSAValidator.ParameterNames.SerialNumber, GetResourceMessage("GCS_IsAssaAccessPointUniquePDSA_SerialNumber_Header", "Serial Number"), false, typeof(string), 8000, GetResourceMessage("GCS_IsAssaAccessPointUniquePDSA_SerialNumber_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAssaAccessPointUniquePDSAValidator.ParameterNames.AssaUniqueId, GetResourceMessage("GCS_IsAssaAccessPointUniquePDSA_AssaUniqueId_Header", "Assa Unique Id"), false, typeof(string), 8000, GetResourceMessage("GCS_IsAssaAccessPointUniquePDSA_AssaUniqueId_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsAssaAccessPointUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsAssaAccessPointUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsAssaAccessPointUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsAssaAccessPointUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsAssaAccessPointUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsAssaAccessPointUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsAssaAccessPointUniquePDSAValidator.ParameterNames.AssaAccessPointUid).Value = Entity.AssaAccessPointUid;
      this.Properties.GetByName(IsAssaAccessPointUniquePDSAValidator.ParameterNames.AssaDsrUid).Value = Entity.AssaDsrUid;
      this.Properties.GetByName(IsAssaAccessPointUniquePDSAValidator.ParameterNames.SerialNumber).Value = Entity.SerialNumber;
      this.Properties.GetByName(IsAssaAccessPointUniquePDSAValidator.ParameterNames.AssaUniqueId).Value = Entity.AssaUniqueId;
      this.Properties.GetByName(IsAssaAccessPointUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsAssaAccessPointUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsAssaAccessPointUniquePDSAValidator.ParameterNames.AssaAccessPointUid).IsNull == false)
        Entity.AssaAccessPointUid = this.Properties.GetByName(IsAssaAccessPointUniquePDSAValidator.ParameterNames.AssaAccessPointUid).GetAsGuid();
      if(this.Properties.GetByName(IsAssaAccessPointUniquePDSAValidator.ParameterNames.AssaDsrUid).IsNull == false)
        Entity.AssaDsrUid = this.Properties.GetByName(IsAssaAccessPointUniquePDSAValidator.ParameterNames.AssaDsrUid).GetAsGuid();
      if(this.Properties.GetByName(IsAssaAccessPointUniquePDSAValidator.ParameterNames.SerialNumber).IsNull == false)
        Entity.SerialNumber = this.Properties.GetByName(IsAssaAccessPointUniquePDSAValidator.ParameterNames.SerialNumber).GetAsString();
      if(this.Properties.GetByName(IsAssaAccessPointUniquePDSAValidator.ParameterNames.AssaUniqueId).IsNull == false)
        Entity.AssaUniqueId = this.Properties.GetByName(IsAssaAccessPointUniquePDSAValidator.ParameterNames.AssaUniqueId).GetAsString();
      if(this.Properties.GetByName(IsAssaAccessPointUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsAssaAccessPointUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsAssaAccessPointUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsAssaAccessPointUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsAssaAccessPointUniquePDSA class.
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
    /// Returns '@AssaAccessPointUid'
    /// </summary>
    public static string AssaAccessPointUid = "@AssaAccessPointUid";
    /// <summary>
    /// Returns '@AssaDsrUid'
    /// </summary>
    public static string AssaDsrUid = "@AssaDsrUid";
    /// <summary>
    /// Returns '@SerialNumber'
    /// </summary>
    public static string SerialNumber = "@SerialNumber";
    /// <summary>
    /// Returns '@AssaUniqueId'
    /// </summary>
    public static string AssaUniqueId = "@AssaUniqueId";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsAssaAccessPointUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@AssaAccessPointUid'
    /// </summary>
    public static string AssaAccessPointUid = "@AssaAccessPointUid";
    /// <summary>
    /// Returns '@AssaDsrUid'
    /// </summary>
    public static string AssaDsrUid = "@AssaDsrUid";
    /// <summary>
    /// Returns '@SerialNumber'
    /// </summary>
    public static string SerialNumber = "@SerialNumber";
    /// <summary>
    /// Returns '@AssaUniqueId'
    /// </summary>
    public static string AssaUniqueId = "@AssaUniqueId";
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

using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsMercScpUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsMercScpUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsMercScpUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsMercScpUniquePDSA Entity
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
    /// Clones the current IsMercScpUniquePDSA
    /// </summary>
    /// <returns>A cloned IsMercScpUniquePDSA object</returns>
    public IsMercScpUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsMercScpUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsMercScpUniquePDSA entity to clone</param>
    /// <returns>A cloned IsMercScpUniquePDSA object</returns>
    public IsMercScpUniquePDSA CloneEntity(IsMercScpUniquePDSA entityToClone)
    {
      IsMercScpUniquePDSA newEntity = new IsMercScpUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsMercScpUniquePDSAValidator.ParameterNames.MercScpUid, GetResourceMessage("GCS_IsMercScpUniquePDSA_MercScpUid_Header", "Merc Scp Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsMercScpUniquePDSA_MercScpUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsMercScpUniquePDSAValidator.ParameterNames.MercScpGroupUid, GetResourceMessage("GCS_IsMercScpUniquePDSA_MercScpGroupUid_Header", "Merc Scp Group Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsMercScpUniquePDSA_MercScpGroupUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsMercScpUniquePDSAValidator.ParameterNames.MacAddress, GetResourceMessage("GCS_IsMercScpUniquePDSA_MacAddress_Header", "Mac Address"), false, typeof(string), 8000, GetResourceMessage("GCS_IsMercScpUniquePDSA_MacAddress_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsMercScpUniquePDSAValidator.ParameterNames.ScpName, GetResourceMessage("GCS_IsMercScpUniquePDSA_ScpName_Header", "Scp Name"), false, typeof(string), 8000, GetResourceMessage("GCS_IsMercScpUniquePDSA_ScpName_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsMercScpUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsMercScpUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsMercScpUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsMercScpUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsMercScpUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsMercScpUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsMercScpUniquePDSAValidator.ParameterNames.MercScpUid).Value = Entity.MercScpUid;
      this.Properties.GetByName(IsMercScpUniquePDSAValidator.ParameterNames.MercScpGroupUid).Value = Entity.MercScpGroupUid;
      this.Properties.GetByName(IsMercScpUniquePDSAValidator.ParameterNames.MacAddress).Value = Entity.MacAddress;
      this.Properties.GetByName(IsMercScpUniquePDSAValidator.ParameterNames.ScpName).Value = Entity.ScpName;
      this.Properties.GetByName(IsMercScpUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsMercScpUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsMercScpUniquePDSAValidator.ParameterNames.MercScpUid).IsNull == false)
        Entity.MercScpUid = this.Properties.GetByName(IsMercScpUniquePDSAValidator.ParameterNames.MercScpUid).GetAsGuid();
      if(this.Properties.GetByName(IsMercScpUniquePDSAValidator.ParameterNames.MercScpGroupUid).IsNull == false)
        Entity.MercScpGroupUid = this.Properties.GetByName(IsMercScpUniquePDSAValidator.ParameterNames.MercScpGroupUid).GetAsGuid();
      if(this.Properties.GetByName(IsMercScpUniquePDSAValidator.ParameterNames.MacAddress).IsNull == false)
        Entity.MacAddress = this.Properties.GetByName(IsMercScpUniquePDSAValidator.ParameterNames.MacAddress).GetAsString();
      if(this.Properties.GetByName(IsMercScpUniquePDSAValidator.ParameterNames.ScpName).IsNull == false)
        Entity.ScpName = this.Properties.GetByName(IsMercScpUniquePDSAValidator.ParameterNames.ScpName).GetAsString();
      if(this.Properties.GetByName(IsMercScpUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsMercScpUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsMercScpUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsMercScpUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsMercScpUniquePDSA class.
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
    /// Returns '@MercScpUid'
    /// </summary>
    public static string MercScpUid = "@MercScpUid";
    /// <summary>
    /// Returns '@MercScpGroupUid'
    /// </summary>
    public static string MercScpGroupUid = "@MercScpGroupUid";
    /// <summary>
    /// Returns '@MacAddress'
    /// </summary>
    public static string MacAddress = "@MacAddress";
    /// <summary>
    /// Returns '@ScpName'
    /// </summary>
    public static string ScpName = "@ScpName";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsMercScpUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@MercScpUid'
    /// </summary>
    public static string MercScpUid = "@MercScpUid";
    /// <summary>
    /// Returns '@MercScpGroupUid'
    /// </summary>
    public static string MercScpGroupUid = "@MercScpGroupUid";
    /// <summary>
    /// Returns '@MacAddress'
    /// </summary>
    public static string MacAddress = "@MacAddress";
    /// <summary>
    /// Returns '@ScpName'
    /// </summary>
    public static string ScpName = "@ScpName";
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

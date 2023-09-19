using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsMercScpIdReportUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsMercScpIdReportUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsMercScpIdReportUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsMercScpIdReportUniquePDSA Entity
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
    /// Clones the current IsMercScpIdReportUniquePDSA
    /// </summary>
    /// <returns>A cloned IsMercScpIdReportUniquePDSA object</returns>
    public IsMercScpIdReportUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsMercScpIdReportUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsMercScpIdReportUniquePDSA entity to clone</param>
    /// <returns>A cloned IsMercScpIdReportUniquePDSA object</returns>
    public IsMercScpIdReportUniquePDSA CloneEntity(IsMercScpIdReportUniquePDSA entityToClone)
    {
      IsMercScpIdReportUniquePDSA newEntity = new IsMercScpIdReportUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsMercScpIdReportUniquePDSAValidator.ParameterNames.MercScpIdReportUid, GetResourceMessage("GCS_IsMercScpIdReportUniquePDSA_MercScpIdReportUid_Header", "Merc Scp Id Report Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsMercScpIdReportUniquePDSA_MercScpIdReportUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsMercScpIdReportUniquePDSAValidator.ParameterNames.MacAddress, GetResourceMessage("GCS_IsMercScpIdReportUniquePDSA_MacAddress_Header", "Mac Address"), false, typeof(string), 8000, GetResourceMessage("GCS_IsMercScpIdReportUniquePDSA_MacAddress_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsMercScpIdReportUniquePDSAValidator.ParameterNames.DeviceVersion, GetResourceMessage("GCS_IsMercScpIdReportUniquePDSA_DeviceVersion_Header", "Device Version"), false, typeof(string), 8000, GetResourceMessage("GCS_IsMercScpIdReportUniquePDSA_DeviceVersion_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsMercScpIdReportUniquePDSAValidator.ParameterNames.SerialNumber, GetResourceMessage("GCS_IsMercScpIdReportUniquePDSA_SerialNumber_Header", "Serial Number"), false, typeof(string), 8000, GetResourceMessage("GCS_IsMercScpIdReportUniquePDSA_SerialNumber_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsMercScpIdReportUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsMercScpIdReportUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsMercScpIdReportUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsMercScpIdReportUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsMercScpIdReportUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsMercScpIdReportUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsMercScpIdReportUniquePDSAValidator.ParameterNames.MercScpIdReportUid).Value = Entity.MercScpIdReportUid;
      this.Properties.GetByName(IsMercScpIdReportUniquePDSAValidator.ParameterNames.MacAddress).Value = Entity.MacAddress;
      this.Properties.GetByName(IsMercScpIdReportUniquePDSAValidator.ParameterNames.DeviceVersion).Value = Entity.DeviceVersion;
      this.Properties.GetByName(IsMercScpIdReportUniquePDSAValidator.ParameterNames.SerialNumber).Value = Entity.SerialNumber;
      this.Properties.GetByName(IsMercScpIdReportUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsMercScpIdReportUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsMercScpIdReportUniquePDSAValidator.ParameterNames.MercScpIdReportUid).IsNull == false)
        Entity.MercScpIdReportUid = this.Properties.GetByName(IsMercScpIdReportUniquePDSAValidator.ParameterNames.MercScpIdReportUid).GetAsGuid();
      if(this.Properties.GetByName(IsMercScpIdReportUniquePDSAValidator.ParameterNames.MacAddress).IsNull == false)
        Entity.MacAddress = this.Properties.GetByName(IsMercScpIdReportUniquePDSAValidator.ParameterNames.MacAddress).GetAsString();
      if(this.Properties.GetByName(IsMercScpIdReportUniquePDSAValidator.ParameterNames.DeviceVersion).IsNull == false)
        Entity.DeviceVersion = this.Properties.GetByName(IsMercScpIdReportUniquePDSAValidator.ParameterNames.DeviceVersion).GetAsString();
      if(this.Properties.GetByName(IsMercScpIdReportUniquePDSAValidator.ParameterNames.SerialNumber).IsNull == false)
        Entity.SerialNumber = this.Properties.GetByName(IsMercScpIdReportUniquePDSAValidator.ParameterNames.SerialNumber).GetAsString();
      if(this.Properties.GetByName(IsMercScpIdReportUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsMercScpIdReportUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsMercScpIdReportUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsMercScpIdReportUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsMercScpIdReportUniquePDSA class.
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
    /// Returns '@MercScpIdReportUid'
    /// </summary>
    public static string MercScpIdReportUid = "@MercScpIdReportUid";
    /// <summary>
    /// Returns '@MacAddress'
    /// </summary>
    public static string MacAddress = "@MacAddress";
    /// <summary>
    /// Returns '@DeviceVersion'
    /// </summary>
    public static string DeviceVersion = "@DeviceVersion";
    /// <summary>
    /// Returns '@SerialNumber'
    /// </summary>
    public static string SerialNumber = "@SerialNumber";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsMercScpIdReportUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@MercScpIdReportUid'
    /// </summary>
    public static string MercScpIdReportUid = "@MercScpIdReportUid";
    /// <summary>
    /// Returns '@MacAddress'
    /// </summary>
    public static string MacAddress = "@MacAddress";
    /// <summary>
    /// Returns '@DeviceVersion'
    /// </summary>
    public static string DeviceVersion = "@DeviceVersion";
    /// <summary>
    /// Returns '@SerialNumber'
    /// </summary>
    public static string SerialNumber = "@SerialNumber";
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

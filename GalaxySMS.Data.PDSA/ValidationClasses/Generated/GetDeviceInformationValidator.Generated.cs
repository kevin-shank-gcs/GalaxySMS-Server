using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the GetDeviceInformationPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class GetDeviceInformationPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private GetDeviceInformationPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new GetDeviceInformationPDSA Entity
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
    /// Clones the current GetDeviceInformationPDSA
    /// </summary>
    /// <returns>A cloned GetDeviceInformationPDSA object</returns>
    public GetDeviceInformationPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in GetDeviceInformationPDSA
    /// </summary>
    /// <param name="entityToClone">The GetDeviceInformationPDSA entity to clone</param>
    /// <returns>A cloned GetDeviceInformationPDSA object</returns>
    public GetDeviceInformationPDSA CloneEntity(GetDeviceInformationPDSA entityToClone)
    {
      GetDeviceInformationPDSA newEntity = new GetDeviceInformationPDSA();

      newEntity.Id = entityToClone.Id;
      newEntity.Name = entityToClone.Name;
      newEntity.DeviceType = entityToClone.DeviceType;

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
      
      props.Add(PDSAProperty.Create(GetDeviceInformationPDSAValidator.ParameterNames.Uid, GetResourceMessage("GCS_GetDeviceInformationPDSA_Uid_Header", "Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_GetDeviceInformationPDSA_Uid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GetDeviceInformationPDSAValidator.ParameterNames.DeviceType, GetResourceMessage("GCS_GetDeviceInformationPDSA_DeviceType_Header", "Device Type"), false, typeof(string), 8000, GetResourceMessage("GCS_GetDeviceInformationPDSA_DeviceType_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GetDeviceInformationPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_GetDeviceInformationPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_GetDeviceInformationPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(GetDeviceInformationPDSAValidator.ParameterNames.Uid).Value = Entity.Uid;
      this.Properties.GetByName(GetDeviceInformationPDSAValidator.ParameterNames.DeviceType).Value = Entity.DeviceType;
      this.Properties.GetByName(GetDeviceInformationPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(GetDeviceInformationPDSAValidator.ParameterNames.Uid).IsNull == false)
        Entity.Uid = this.Properties.GetByName(GetDeviceInformationPDSAValidator.ParameterNames.Uid).GetAsGuid();
      if(this.Properties.GetByName(GetDeviceInformationPDSAValidator.ParameterNames.DeviceType).IsNull == false)
        Entity.DeviceType = this.Properties.GetByName(GetDeviceInformationPDSAValidator.ParameterNames.DeviceType).GetAsString();
      if(this.Properties.GetByName(GetDeviceInformationPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(GetDeviceInformationPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the GetDeviceInformationPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ColumnNames
    {
    /// <summary>
    /// Returns 'Id'
    /// </summary>
    public static string Id = "Id";
    /// <summary>
    /// Returns 'Name'
    /// </summary>
    public static string Name = "Name";
    /// <summary>
    /// Returns 'DeviceType'
    /// </summary>
    public static string DeviceType = "DeviceType";
    /// <summary>
    /// Returns '@Uid'
    /// </summary>
    public static string Uid = "@Uid";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the GetDeviceInformationPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@Uid'
    /// </summary>
    public static string Uid = "@Uid";
    /// <summary>
    /// Returns '@DeviceTypeCode'
    /// </summary>
    public static string DeviceType = "@DeviceType";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}

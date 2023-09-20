using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the IsGalaxyFlashImageUniquePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class IsGalaxyFlashImageUniquePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private IsGalaxyFlashImageUniquePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new IsGalaxyFlashImageUniquePDSA Entity
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
    /// Clones the current IsGalaxyFlashImageUniquePDSA
    /// </summary>
    /// <returns>A cloned IsGalaxyFlashImageUniquePDSA object</returns>
    public IsGalaxyFlashImageUniquePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in IsGalaxyFlashImageUniquePDSA
    /// </summary>
    /// <param name="entityToClone">The IsGalaxyFlashImageUniquePDSA entity to clone</param>
    /// <returns>A cloned IsGalaxyFlashImageUniquePDSA object</returns>
    public IsGalaxyFlashImageUniquePDSA CloneEntity(IsGalaxyFlashImageUniquePDSA entityToClone)
    {
      IsGalaxyFlashImageUniquePDSA newEntity = new IsGalaxyFlashImageUniquePDSA();

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
      
      props.Add(PDSAProperty.Create(IsGalaxyFlashImageUniquePDSAValidator.ParameterNames.GalaxyFlashImageUid, GetResourceMessage("GCS_IsGalaxyFlashImageUniquePDSA_GalaxyFlashImageUid_Header", "Galaxy Flash Image Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsGalaxyFlashImageUniquePDSA_GalaxyFlashImageUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyFlashImageUniquePDSAValidator.ParameterNames.GalaxyCpuModelUid, GetResourceMessage("GCS_IsGalaxyFlashImageUniquePDSA_GalaxyCpuModelUid_Header", "Galaxy Cpu Model Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_IsGalaxyFlashImageUniquePDSA_GalaxyCpuModelUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyFlashImageUniquePDSAValidator.ParameterNames.Package, GetResourceMessage("GCS_IsGalaxyFlashImageUniquePDSA_Package_Header", "Package"), false, typeof(string), 8000, GetResourceMessage("GCS_IsGalaxyFlashImageUniquePDSA_Package_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyFlashImageUniquePDSAValidator.ParameterNames.Version, GetResourceMessage("GCS_IsGalaxyFlashImageUniquePDSA_Version_Header", "Version"), false, typeof(string), 8000, GetResourceMessage("GCS_IsGalaxyFlashImageUniquePDSA_Version_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyFlashImageUniquePDSAValidator.ParameterNames.DataFormat, GetResourceMessage("GCS_IsGalaxyFlashImageUniquePDSA_DataFormat_Header", "Data Format"), false, typeof(string), 8000, GetResourceMessage("GCS_IsGalaxyFlashImageUniquePDSA_DataFormat_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyFlashImageUniquePDSAValidator.ParameterNames.Checksum, GetResourceMessage("GCS_IsGalaxyFlashImageUniquePDSA_Checksum_Header", "Checksum"), false, typeof(string), 8000, GetResourceMessage("GCS_IsGalaxyFlashImageUniquePDSA_Checksum_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyFlashImageUniquePDSAValidator.ParameterNames.Result, GetResourceMessage("GCS_IsGalaxyFlashImageUniquePDSA_Result_Header", "Result"), false, typeof(int), 0, GetResourceMessage("GCS_IsGalaxyFlashImageUniquePDSA_Result_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(IsGalaxyFlashImageUniquePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_IsGalaxyFlashImageUniquePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_IsGalaxyFlashImageUniquePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      this.Properties.GetByName(IsGalaxyFlashImageUniquePDSAValidator.ParameterNames.GalaxyFlashImageUid).Value = Entity.GalaxyFlashImageUid;
      this.Properties.GetByName(IsGalaxyFlashImageUniquePDSAValidator.ParameterNames.GalaxyCpuModelUid).Value = Entity.GalaxyCpuModelUid;
      this.Properties.GetByName(IsGalaxyFlashImageUniquePDSAValidator.ParameterNames.Package).Value = Entity.Package;
      this.Properties.GetByName(IsGalaxyFlashImageUniquePDSAValidator.ParameterNames.Version).Value = Entity.Version;
      this.Properties.GetByName(IsGalaxyFlashImageUniquePDSAValidator.ParameterNames.DataFormat).Value = Entity.DataFormat;
      this.Properties.GetByName(IsGalaxyFlashImageUniquePDSAValidator.ParameterNames.Checksum).Value = Entity.Checksum;
      this.Properties.GetByName(IsGalaxyFlashImageUniquePDSAValidator.ParameterNames.Result).Value = Entity.Result;
      this.Properties.GetByName(IsGalaxyFlashImageUniquePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(this.Properties.GetByName(IsGalaxyFlashImageUniquePDSAValidator.ParameterNames.GalaxyFlashImageUid).IsNull == false)
        Entity.GalaxyFlashImageUid = this.Properties.GetByName(IsGalaxyFlashImageUniquePDSAValidator.ParameterNames.GalaxyFlashImageUid).GetAsGuid();
      if(this.Properties.GetByName(IsGalaxyFlashImageUniquePDSAValidator.ParameterNames.GalaxyCpuModelUid).IsNull == false)
        Entity.GalaxyCpuModelUid = this.Properties.GetByName(IsGalaxyFlashImageUniquePDSAValidator.ParameterNames.GalaxyCpuModelUid).GetAsGuid();
      if(this.Properties.GetByName(IsGalaxyFlashImageUniquePDSAValidator.ParameterNames.Package).IsNull == false)
        Entity.Package = this.Properties.GetByName(IsGalaxyFlashImageUniquePDSAValidator.ParameterNames.Package).GetAsString();
      if(this.Properties.GetByName(IsGalaxyFlashImageUniquePDSAValidator.ParameterNames.Version).IsNull == false)
        Entity.Version = this.Properties.GetByName(IsGalaxyFlashImageUniquePDSAValidator.ParameterNames.Version).GetAsString();
      if(this.Properties.GetByName(IsGalaxyFlashImageUniquePDSAValidator.ParameterNames.DataFormat).IsNull == false)
        Entity.DataFormat = this.Properties.GetByName(IsGalaxyFlashImageUniquePDSAValidator.ParameterNames.DataFormat).GetAsString();
      if(this.Properties.GetByName(IsGalaxyFlashImageUniquePDSAValidator.ParameterNames.Checksum).IsNull == false)
        Entity.Checksum = this.Properties.GetByName(IsGalaxyFlashImageUniquePDSAValidator.ParameterNames.Checksum).GetAsString();
      if(this.Properties.GetByName(IsGalaxyFlashImageUniquePDSAValidator.ParameterNames.Result).IsNull == false)
        Entity.Result = this.Properties.GetByName(IsGalaxyFlashImageUniquePDSAValidator.ParameterNames.Result).GetAsInteger();
      if(this.Properties.GetByName(IsGalaxyFlashImageUniquePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = this.Properties.GetByName(IsGalaxyFlashImageUniquePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion
        
    #region ColumnNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsGalaxyFlashImageUniquePDSA class.
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
    /// Returns '@GalaxyFlashImageUid'
    /// </summary>
    public static string GalaxyFlashImageUid = "@GalaxyFlashImageUid";
    /// <summary>
    /// Returns '@GalaxyCpuModelUid'
    /// </summary>
    public static string GalaxyCpuModelUid = "@GalaxyCpuModelUid";
    /// <summary>
    /// Returns '@Package'
    /// </summary>
    public static string Package = "@Package";
    /// <summary>
    /// Returns '@Version'
    /// </summary>
    public static string Version = "@Version";
    /// <summary>
    /// Returns '@DataFormat'
    /// </summary>
    public static string DataFormat = "@DataFormat";
    /// <summary>
    /// Returns '@Checksum'
    /// </summary>
    public static string Checksum = "@Checksum";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the IsGalaxyFlashImageUniquePDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@GalaxyFlashImageUid'
    /// </summary>
    public static string GalaxyFlashImageUid = "@GalaxyFlashImageUid";
    /// <summary>
    /// Returns '@GalaxyCpuModelUid'
    /// </summary>
    public static string GalaxyCpuModelUid = "@GalaxyCpuModelUid";
    /// <summary>
    /// Returns '@Package'
    /// </summary>
    public static string Package = "@Package";
    /// <summary>
    /// Returns '@Version'
    /// </summary>
    public static string Version = "@Version";
    /// <summary>
    /// Returns '@DataFormat'
    /// </summary>
    public static string DataFormat = "@DataFormat";
    /// <summary>
    /// Returns '@Checksum'
    /// </summary>
    public static string Checksum = "@Checksum";
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

using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the GalaxyCpu_UpdateInformationPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class GalaxyCpu_UpdateInformationPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private GalaxyCpu_UpdateInformationPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new GalaxyCpu_UpdateInformationPDSA Entity
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
    /// Clones the current GalaxyCpu_UpdateInformationPDSA
    /// </summary>
    /// <returns>A cloned GalaxyCpu_UpdateInformationPDSA object</returns>
    public GalaxyCpu_UpdateInformationPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in GalaxyCpu_UpdateInformationPDSA
    /// </summary>
    /// <param name="entityToClone">The GalaxyCpu_UpdateInformationPDSA entity to clone</param>
    /// <returns>A cloned GalaxyCpu_UpdateInformationPDSA object</returns>
    public GalaxyCpu_UpdateInformationPDSA CloneEntity(GalaxyCpu_UpdateInformationPDSA entityToClone)
    {
      GalaxyCpu_UpdateInformationPDSA newEntity = new GalaxyCpu_UpdateInformationPDSA();


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
      
      props.Add(PDSAProperty.Create(GalaxyCpu_UpdateInformationPDSAValidator.ParameterNames.CpuUid, GetResourceMessage("GCS_GalaxyCpu_UpdateInformationPDSA_CpuUid_Header", "Cpu Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_GalaxyCpu_UpdateInformationPDSA_CpuUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpu_UpdateInformationPDSAValidator.ParameterNames.SerialNumber, GetResourceMessage("GCS_GalaxyCpu_UpdateInformationPDSA_SerialNumber_Header", "Serial Number"), false, typeof(string), 8000, GetResourceMessage("GCS_GalaxyCpu_UpdateInformationPDSA_SerialNumber_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpu_UpdateInformationPDSAValidator.ParameterNames.IpAddress, GetResourceMessage("GCS_GalaxyCpu_UpdateInformationPDSA_IpAddress_Header", "Ip Address"), false, typeof(string), 8000, GetResourceMessage("GCS_GalaxyCpu_UpdateInformationPDSA_IpAddress_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, string.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpu_UpdateInformationPDSAValidator.ParameterNames.Model, GetResourceMessage("GCS_GalaxyCpu_UpdateInformationPDSA_Model_Header", "Model"), false, typeof(int), 0, GetResourceMessage("GCS_GalaxyCpu_UpdateInformationPDSA_Model_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpu_UpdateInformationPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_GalaxyCpu_UpdateInformationPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_GalaxyCpu_UpdateInformationPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      if (Properties == null)
      {
        InitProperties();
      }
      
      Properties.GetByName(GalaxyCpu_UpdateInformationPDSAValidator.ParameterNames.CpuUid).Value = Entity.CpuUid;
      Properties.GetByName(GalaxyCpu_UpdateInformationPDSAValidator.ParameterNames.SerialNumber).Value = Entity.SerialNumber;
      Properties.GetByName(GalaxyCpu_UpdateInformationPDSAValidator.ParameterNames.IpAddress).Value = Entity.IpAddress;
      Properties.GetByName(GalaxyCpu_UpdateInformationPDSAValidator.ParameterNames.Model).Value = Entity.Model;
      Properties.GetByName(GalaxyCpu_UpdateInformationPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
    }

    /// <summary>
    /// Moves the Properties collection objects into the Entity properties
    /// </summary>
    protected override void PropertiesToEntityData()
    {
      if (Properties == null)
      {
        InitProperties();
      }

      if(Properties.GetByName(GalaxyCpu_UpdateInformationPDSAValidator.ParameterNames.CpuUid).IsNull == false)
        Entity.CpuUid = Properties.GetByName(GalaxyCpu_UpdateInformationPDSAValidator.ParameterNames.CpuUid).GetAsGuid();
      if(Properties.GetByName(GalaxyCpu_UpdateInformationPDSAValidator.ParameterNames.SerialNumber).IsNull == false)
        Entity.SerialNumber = Properties.GetByName(GalaxyCpu_UpdateInformationPDSAValidator.ParameterNames.SerialNumber).GetAsString();
      if(Properties.GetByName(GalaxyCpu_UpdateInformationPDSAValidator.ParameterNames.IpAddress).IsNull == false)
        Entity.IpAddress = Properties.GetByName(GalaxyCpu_UpdateInformationPDSAValidator.ParameterNames.IpAddress).GetAsString();
      if(Properties.GetByName(GalaxyCpu_UpdateInformationPDSAValidator.ParameterNames.Model).IsNull == false)
        Entity.Model = Properties.GetByName(GalaxyCpu_UpdateInformationPDSAValidator.ParameterNames.Model).GetAsInteger();
      if(Properties.GetByName(GalaxyCpu_UpdateInformationPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = Properties.GetByName(GalaxyCpu_UpdateInformationPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the GalaxyCpu_UpdateInformationPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// Do not modify this class or add methods as it is intended to be able to be re-generated at any time.
    /// </summary>
    public class ParameterNames
    {
    /// <summary>
    /// Returns '@CpuUid'
    /// </summary>
    public static string CpuUid = "@CpuUid";
    /// <summary>
    /// Returns '@SerialNumber'
    /// </summary>
    public static string SerialNumber = "@SerialNumber";
    /// <summary>
    /// Returns '@IpAddress'
    /// </summary>
    public static string IpAddress = "@IpAddress";
    /// <summary>
    /// Returns '@Model'
    /// </summary>
    public static string Model = "@Model";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}

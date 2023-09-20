using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the CredentialToLoadToCpu_SaveLastCredentialLoadedDateByCredentialDataPDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class CredentialToLoadToCpu_SaveLastCredentialLoadedDateByCredentialDataPDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private CredentialToLoadToCpu_SaveLastCredentialLoadedDateByCredentialDataPDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new CredentialToLoadToCpu_SaveLastCredentialLoadedDateByCredentialDataPDSA Entity
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
    /// Clones the current CredentialToLoadToCpu_SaveLastCredentialLoadedDateByCredentialDataPDSA
    /// </summary>
    /// <returns>A cloned CredentialToLoadToCpu_SaveLastCredentialLoadedDateByCredentialDataPDSA object</returns>
    public CredentialToLoadToCpu_SaveLastCredentialLoadedDateByCredentialDataPDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in CredentialToLoadToCpu_SaveLastCredentialLoadedDateByCredentialDataPDSA
    /// </summary>
    /// <param name="entityToClone">The CredentialToLoadToCpu_SaveLastCredentialLoadedDateByCredentialDataPDSA entity to clone</param>
    /// <returns>A cloned CredentialToLoadToCpu_SaveLastCredentialLoadedDateByCredentialDataPDSA object</returns>
    public CredentialToLoadToCpu_SaveLastCredentialLoadedDateByCredentialDataPDSA CloneEntity(CredentialToLoadToCpu_SaveLastCredentialLoadedDateByCredentialDataPDSA entityToClone)
    {
      CredentialToLoadToCpu_SaveLastCredentialLoadedDateByCredentialDataPDSA newEntity = new CredentialToLoadToCpu_SaveLastCredentialLoadedDateByCredentialDataPDSA();


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
      
      props.Add(PDSAProperty.Create(CredentialToLoadToCpu_SaveLastCredentialLoadedDateByCredentialDataPDSAValidator.ParameterNames.CpuUid, GetResourceMessage("GCS_CredentialToLoadToCpu_SaveLastCredentialLoadedDateByCredentialDataPDSA_CpuUid_Header", "Cpu Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_CredentialToLoadToCpu_SaveLastCredentialLoadedDateByCredentialDataPDSA_CpuUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(CredentialToLoadToCpu_SaveLastCredentialLoadedDateByCredentialDataPDSAValidator.ParameterNames.CredentialData, GetResourceMessage("GCS_CredentialToLoadToCpu_SaveLastCredentialLoadedDateByCredentialDataPDSA_CredentialData_Header", "Credential Data"), false, typeof(byte[]), 32, GetResourceMessage("GCS_CredentialToLoadToCpu_SaveLastCredentialLoadedDateByCredentialDataPDSA_CredentialData_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, new byte[0], @"", ""));
      props.Add(PDSAProperty.Create(CredentialToLoadToCpu_SaveLastCredentialLoadedDateByCredentialDataPDSAValidator.ParameterNames.LastCredentialLoadedDate, GetResourceMessage("GCS_CredentialToLoadToCpu_SaveLastCredentialLoadedDateByCredentialDataPDSA_LastCredentialLoadedDate_Header", "Last Credential Loaded Date"), false, typeof(DateTimeOffset), 0, GetResourceMessage("GCS_CredentialToLoadToCpu_SaveLastCredentialLoadedDateByCredentialDataPDSA_LastCredentialLoadedDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, Convert.ToDateTime("1753-1-1", System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat), @"", ""));
      props.Add(PDSAProperty.Create(CredentialToLoadToCpu_SaveLastCredentialLoadedDateByCredentialDataPDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_CredentialToLoadToCpu_SaveLastCredentialLoadedDateByCredentialDataPDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_CredentialToLoadToCpu_SaveLastCredentialLoadedDateByCredentialDataPDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      Properties.GetByName(CredentialToLoadToCpu_SaveLastCredentialLoadedDateByCredentialDataPDSAValidator.ParameterNames.CpuUid).Value = Entity.CpuUid;
      Properties.GetByName(CredentialToLoadToCpu_SaveLastCredentialLoadedDateByCredentialDataPDSAValidator.ParameterNames.CredentialData).Value = Entity.CredentialData;
      Properties.GetByName(CredentialToLoadToCpu_SaveLastCredentialLoadedDateByCredentialDataPDSAValidator.ParameterNames.LastCredentialLoadedDate).Value = Entity.LastCredentialLoadedDate;
      Properties.GetByName(CredentialToLoadToCpu_SaveLastCredentialLoadedDateByCredentialDataPDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(Properties.GetByName(CredentialToLoadToCpu_SaveLastCredentialLoadedDateByCredentialDataPDSAValidator.ParameterNames.CpuUid).IsNull == false)
        Entity.CpuUid = Properties.GetByName(CredentialToLoadToCpu_SaveLastCredentialLoadedDateByCredentialDataPDSAValidator.ParameterNames.CpuUid).GetAsGuid();
      if(Properties.GetByName(CredentialToLoadToCpu_SaveLastCredentialLoadedDateByCredentialDataPDSAValidator.ParameterNames.CredentialData).IsNull == false)
        Entity.CredentialData = Properties.GetByName(CredentialToLoadToCpu_SaveLastCredentialLoadedDateByCredentialDataPDSAValidator.ParameterNames.CredentialData).GetAsByteArray();
      if(Properties.GetByName(CredentialToLoadToCpu_SaveLastCredentialLoadedDateByCredentialDataPDSAValidator.ParameterNames.LastCredentialLoadedDate).IsNull == false)
        Entity.LastCredentialLoadedDate = Properties.GetByName(CredentialToLoadToCpu_SaveLastCredentialLoadedDateByCredentialDataPDSAValidator.ParameterNames.LastCredentialLoadedDate).GetAsDateTimeOffset();
      if(Properties.GetByName(CredentialToLoadToCpu_SaveLastCredentialLoadedDateByCredentialDataPDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = Properties.GetByName(CredentialToLoadToCpu_SaveLastCredentialLoadedDateByCredentialDataPDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the CredentialToLoadToCpu_SaveLastCredentialLoadedDateByCredentialDataPDSA class.
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
    /// Returns '@CredentialData'
    /// </summary>
    public static string CredentialData = "@CredentialData";
    /// <summary>
    /// Returns '@LastCredentialLoadedDate'
    /// </summary>
    public static string LastCredentialLoadedDate = "@LastCredentialLoadedDate";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}

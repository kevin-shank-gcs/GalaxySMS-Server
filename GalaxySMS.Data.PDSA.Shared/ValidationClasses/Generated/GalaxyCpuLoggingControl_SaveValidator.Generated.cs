using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the GalaxyCpuLoggingControl_SavePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class GalaxyCpuLoggingControl_SavePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private GalaxyCpuLoggingControl_SavePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new GalaxyCpuLoggingControl_SavePDSA Entity
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
    /// Clones the current GalaxyCpuLoggingControl_SavePDSA
    /// </summary>
    /// <returns>A cloned GalaxyCpuLoggingControl_SavePDSA object</returns>
    public GalaxyCpuLoggingControl_SavePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in GalaxyCpuLoggingControl_SavePDSA
    /// </summary>
    /// <param name="entityToClone">The GalaxyCpuLoggingControl_SavePDSA entity to clone</param>
    /// <returns>A cloned GalaxyCpuLoggingControl_SavePDSA object</returns>
    public GalaxyCpuLoggingControl_SavePDSA CloneEntity(GalaxyCpuLoggingControl_SavePDSA entityToClone)
    {
      GalaxyCpuLoggingControl_SavePDSA newEntity = new GalaxyCpuLoggingControl_SavePDSA();


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
      
      props.Add(PDSAProperty.Create(GalaxyCpuLoggingControl_SavePDSAValidator.ParameterNames.CpuUid, GetResourceMessage("GCS_GalaxyCpuLoggingControl_SavePDSA_CpuUid_Header", "Cpu Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_GalaxyCpuLoggingControl_SavePDSA_CpuUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuLoggingControl_SavePDSAValidator.ParameterNames.LastLogIndex, GetResourceMessage("GCS_GalaxyCpuLoggingControl_SavePDSA_LastLogIndex_Header", "Last Log Index"), false, typeof(int), 0, GetResourceMessage("GCS_GalaxyCpuLoggingControl_SavePDSA_LastLogIndex_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuLoggingControl_SavePDSAValidator.ParameterNames.UpdateDate, GetResourceMessage("GCS_GalaxyCpuLoggingControl_SavePDSA_UpdateDate_Header", "Update Date"), false, typeof(DateTimeOffset), 0, GetResourceMessage("GCS_GalaxyCpuLoggingControl_SavePDSA_UpdateDate_Req", PDSAValidationMessages.MustBeFilledIn), DateTimeOffset.MinValue, DateTimeOffset.MaxValue, 0, Convert.ToDateTime("1753-1-1", System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat), @"", ""));
      props.Add(PDSAProperty.Create(GalaxyCpuLoggingControl_SavePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_GalaxyCpuLoggingControl_SavePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_GalaxyCpuLoggingControl_SavePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      Properties.GetByName(GalaxyCpuLoggingControl_SavePDSAValidator.ParameterNames.CpuUid).Value = Entity.CpuUid;
      Properties.GetByName(GalaxyCpuLoggingControl_SavePDSAValidator.ParameterNames.LastLogIndex).Value = Entity.LastLogIndex;
      Properties.GetByName(GalaxyCpuLoggingControl_SavePDSAValidator.ParameterNames.UpdateDate).Value = Entity.UpdateDate;
      Properties.GetByName(GalaxyCpuLoggingControl_SavePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(Properties.GetByName(GalaxyCpuLoggingControl_SavePDSAValidator.ParameterNames.CpuUid).IsNull == false)
        Entity.CpuUid = Properties.GetByName(GalaxyCpuLoggingControl_SavePDSAValidator.ParameterNames.CpuUid).GetAsGuid();
      if(Properties.GetByName(GalaxyCpuLoggingControl_SavePDSAValidator.ParameterNames.LastLogIndex).IsNull == false)
        Entity.LastLogIndex = Properties.GetByName(GalaxyCpuLoggingControl_SavePDSAValidator.ParameterNames.LastLogIndex).GetAsInteger();
      if(Properties.GetByName(GalaxyCpuLoggingControl_SavePDSAValidator.ParameterNames.UpdateDate).IsNull == false)
        Entity.UpdateDate = Properties.GetByName(GalaxyCpuLoggingControl_SavePDSAValidator.ParameterNames.UpdateDate).GetAsDateTimeOffset();
      if(Properties.GetByName(GalaxyCpuLoggingControl_SavePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = Properties.GetByName(GalaxyCpuLoggingControl_SavePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the GalaxyCpuLoggingControl_SavePDSA class.
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
    /// Returns '@LastLogIndex'
    /// </summary>
    public static string LastLogIndex = "@LastLogIndex";
    /// <summary>
    /// Returns '@UpdateDate'
    /// </summary>
    public static string UpdateDate = "@UpdateDate";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}

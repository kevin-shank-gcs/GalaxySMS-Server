using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// Used to validate all parameters of the AccessGroupAccessPortalLoadToCpu_SaveLastLoadedDatePDSA class.
  /// This class is generated using the Haystack Code Generator for .NET.
  /// You should NOT modify this class as it is intended to be re-generated.
  /// </summary>
  public partial class AccessGroupAccessPortalLoadToCpu_SaveLastLoadedDatePDSAValidator : PDSAValidatorBase
  {
    #region Public Entity Property
    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    private AccessGroupAccessPortalLoadToCpu_SaveLastLoadedDatePDSA _Entity = null;

    /// <summary>
    /// Get/Set the Entity class with the properties to validate
    /// </summary>
    public new AccessGroupAccessPortalLoadToCpu_SaveLastLoadedDatePDSA Entity
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
    /// Clones the current AccessGroupAccessPortalLoadToCpu_SaveLastLoadedDatePDSA
    /// </summary>
    /// <returns>A cloned AccessGroupAccessPortalLoadToCpu_SaveLastLoadedDatePDSA object</returns>
    public AccessGroupAccessPortalLoadToCpu_SaveLastLoadedDatePDSA CloneEntity()
    {
      return CloneEntity(this.Entity);
    }
    
    /// <summary>
    /// Clones the passed in AccessGroupAccessPortalLoadToCpu_SaveLastLoadedDatePDSA
    /// </summary>
    /// <param name="entityToClone">The AccessGroupAccessPortalLoadToCpu_SaveLastLoadedDatePDSA entity to clone</param>
    /// <returns>A cloned AccessGroupAccessPortalLoadToCpu_SaveLastLoadedDatePDSA object</returns>
    public AccessGroupAccessPortalLoadToCpu_SaveLastLoadedDatePDSA CloneEntity(AccessGroupAccessPortalLoadToCpu_SaveLastLoadedDatePDSA entityToClone)
    {
      AccessGroupAccessPortalLoadToCpu_SaveLastLoadedDatePDSA newEntity = new AccessGroupAccessPortalLoadToCpu_SaveLastLoadedDatePDSA();


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
      
      props.Add(PDSAProperty.Create(AccessGroupAccessPortalLoadToCpu_SaveLastLoadedDatePDSAValidator.ParameterNames.CpuUid, GetResourceMessage("GCS_AccessGroupAccessPortalLoadToCpu_SaveLastLoadedDatePDSA_CpuUid_Header", "Cpu Uid"), false, typeof(Guid), 0, GetResourceMessage("GCS_AccessGroupAccessPortalLoadToCpu_SaveLastLoadedDatePDSA_CpuUid_Req", PDSAValidationMessages.MustBeFilledIn), null, null, 0, Guid.Empty, @"", ""));
      props.Add(PDSAProperty.Create(AccessGroupAccessPortalLoadToCpu_SaveLastLoadedDatePDSAValidator.ParameterNames.AccessGroupNumber, GetResourceMessage("GCS_AccessGroupAccessPortalLoadToCpu_SaveLastLoadedDatePDSA_AccessGroupNumber_Header", "Access Group Number"), false, typeof(int), 0, GetResourceMessage("GCS_AccessGroupAccessPortalLoadToCpu_SaveLastLoadedDatePDSA_AccessGroupNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(AccessGroupAccessPortalLoadToCpu_SaveLastLoadedDatePDSAValidator.ParameterNames.BoardNumber, GetResourceMessage("GCS_AccessGroupAccessPortalLoadToCpu_SaveLastLoadedDatePDSA_BoardNumber_Header", "Board Number"), false, typeof(int), 0, GetResourceMessage("GCS_AccessGroupAccessPortalLoadToCpu_SaveLastLoadedDatePDSA_BoardNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(AccessGroupAccessPortalLoadToCpu_SaveLastLoadedDatePDSAValidator.ParameterNames.SectionNumber, GetResourceMessage("GCS_AccessGroupAccessPortalLoadToCpu_SaveLastLoadedDatePDSA_SectionNumber_Header", "Section Number"), false, typeof(int), 0, GetResourceMessage("GCS_AccessGroupAccessPortalLoadToCpu_SaveLastLoadedDatePDSA_SectionNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(AccessGroupAccessPortalLoadToCpu_SaveLastLoadedDatePDSAValidator.ParameterNames.NodeNumber, GetResourceMessage("GCS_AccessGroupAccessPortalLoadToCpu_SaveLastLoadedDatePDSA_NodeNumber_Header", "Node Number"), false, typeof(int), 0, GetResourceMessage("GCS_AccessGroupAccessPortalLoadToCpu_SaveLastLoadedDatePDSA_NodeNumber_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      props.Add(PDSAProperty.Create(AccessGroupAccessPortalLoadToCpu_SaveLastLoadedDatePDSAValidator.ParameterNames.RETURNVALUE, GetResourceMessage("GCS_AccessGroupAccessPortalLoadToCpu_SaveLastLoadedDatePDSA_RETURNVALUE_Header", "return value"), false, typeof(int), 0, GetResourceMessage("GCS_AccessGroupAccessPortalLoadToCpu_SaveLastLoadedDatePDSA_RETURNVALUE_Req", PDSAValidationMessages.MustBeFilledIn), Convert.ToInt32("-2147483648"), Convert.ToInt32("2147483647"), 0, 0, @"", ""));
      
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
      
      Properties.GetByName(AccessGroupAccessPortalLoadToCpu_SaveLastLoadedDatePDSAValidator.ParameterNames.CpuUid).Value = Entity.CpuUid;
      Properties.GetByName(AccessGroupAccessPortalLoadToCpu_SaveLastLoadedDatePDSAValidator.ParameterNames.AccessGroupNumber).Value = Entity.AccessGroupNumber;
      Properties.GetByName(AccessGroupAccessPortalLoadToCpu_SaveLastLoadedDatePDSAValidator.ParameterNames.BoardNumber).Value = Entity.BoardNumber;
      Properties.GetByName(AccessGroupAccessPortalLoadToCpu_SaveLastLoadedDatePDSAValidator.ParameterNames.SectionNumber).Value = Entity.SectionNumber;
      Properties.GetByName(AccessGroupAccessPortalLoadToCpu_SaveLastLoadedDatePDSAValidator.ParameterNames.NodeNumber).Value = Entity.NodeNumber;
      Properties.GetByName(AccessGroupAccessPortalLoadToCpu_SaveLastLoadedDatePDSAValidator.ParameterNames.RETURNVALUE).Value = Entity.RETURNVALUE;
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

      if(Properties.GetByName(AccessGroupAccessPortalLoadToCpu_SaveLastLoadedDatePDSAValidator.ParameterNames.CpuUid).IsNull == false)
        Entity.CpuUid = Properties.GetByName(AccessGroupAccessPortalLoadToCpu_SaveLastLoadedDatePDSAValidator.ParameterNames.CpuUid).GetAsGuid();
      if(Properties.GetByName(AccessGroupAccessPortalLoadToCpu_SaveLastLoadedDatePDSAValidator.ParameterNames.AccessGroupNumber).IsNull == false)
        Entity.AccessGroupNumber = Properties.GetByName(AccessGroupAccessPortalLoadToCpu_SaveLastLoadedDatePDSAValidator.ParameterNames.AccessGroupNumber).GetAsInteger();
      if(Properties.GetByName(AccessGroupAccessPortalLoadToCpu_SaveLastLoadedDatePDSAValidator.ParameterNames.BoardNumber).IsNull == false)
        Entity.BoardNumber = Properties.GetByName(AccessGroupAccessPortalLoadToCpu_SaveLastLoadedDatePDSAValidator.ParameterNames.BoardNumber).GetAsInteger();
      if(Properties.GetByName(AccessGroupAccessPortalLoadToCpu_SaveLastLoadedDatePDSAValidator.ParameterNames.SectionNumber).IsNull == false)
        Entity.SectionNumber = Properties.GetByName(AccessGroupAccessPortalLoadToCpu_SaveLastLoadedDatePDSAValidator.ParameterNames.SectionNumber).GetAsInteger();
      if(Properties.GetByName(AccessGroupAccessPortalLoadToCpu_SaveLastLoadedDatePDSAValidator.ParameterNames.NodeNumber).IsNull == false)
        Entity.NodeNumber = Properties.GetByName(AccessGroupAccessPortalLoadToCpu_SaveLastLoadedDatePDSAValidator.ParameterNames.NodeNumber).GetAsInteger();
      if(Properties.GetByName(AccessGroupAccessPortalLoadToCpu_SaveLastLoadedDatePDSAValidator.ParameterNames.RETURNVALUE).IsNull == false)
        Entity.RETURNVALUE = Properties.GetByName(AccessGroupAccessPortalLoadToCpu_SaveLastLoadedDatePDSAValidator.ParameterNames.RETURNVALUE).GetAsInteger();
    }
    #endregion

    #region ParameterNames Class
    /// <summary>
    /// Contains static string properties that represent the name of each property in the AccessGroupAccessPortalLoadToCpu_SaveLastLoadedDatePDSA class.
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
    /// Returns '@AccessGroupNumber'
    /// </summary>
    public static string AccessGroupNumber = "@AccessGroupNumber";
    /// <summary>
    /// Returns '@BoardNumber'
    /// </summary>
    public static string BoardNumber = "@BoardNumber";
    /// <summary>
    /// Returns '@SectionNumber'
    /// </summary>
    public static string SectionNumber = "@SectionNumber";
    /// <summary>
    /// Returns '@NodeNumber'
    /// </summary>
    public static string NodeNumber = "@NodeNumber";
    /// <summary>
    /// Returns '@RETURN_VALUE'
    /// </summary>
    public static string RETURNVALUE = "@RETURN_VALUE";
    }
    #endregion
  }
}

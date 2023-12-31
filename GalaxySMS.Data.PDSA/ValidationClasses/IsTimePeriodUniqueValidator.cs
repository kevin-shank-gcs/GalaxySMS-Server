using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
  /// <summary>
  /// This class contains custom business rules used to validate input parameters to this stored procedure.
  /// This class is generated by the Haystack Code Generator for .NET.
  /// You may add business rules to the ValidateCore method in this class.
  /// </summary>
  public partial class IsTimePeriodUniquePDSAValidator
  {
    #region Constructor
    /// <summary>
    /// Constructor for the IsTimePeriodUniquePDSAValidator class
    /// </summary>
    /// <param name="entity">An instance of a IsTimePeriodUniquePDSA</param>
    public IsTimePeriodUniquePDSAValidator(IsTimePeriodUniquePDSA entity) : base()
    {
      Entity = entity;
      ClassName = "IsTimePeriodUniquePDSAValidator";

      // Create Properties for each field in the IsTimePeriodUniquePDSA entity class
      InitProperties();
      
      // Add any additional business rules to the Properties.
      AddBusinessRulesToProperties();
    }
    #endregion

    #region ValidateCore Method
    /// <summary>
    /// Add any additional business rules you need to ensure that the parameters passed into this stored procedure are valid.
    /// This method is called by the Execute() method and will throw an exception if any business rules fail.
    /// </summary>
    protected override void ValidateCore()
    {
      // Write Custom Business Rules Here


      // Sample:
      // if (Entity.Price < Entity.Cost)
      //   AddBusinessRuleMessage("Cost", "Cost must be less than price");
      // 
      // if (Entity.Cost == 20)
      //   AddBusinessRuleMessage("Cost", "Cost can not be equal to 20");
    }
    #endregion

    #region AddBusinessRulesToProperties
    /// <summary>
    /// If you wish to change any of the standard validation properties of any of the parameters, retrieve the parameters from the Properties collection, then change the appropriate properties.
    /// </summary>
    protected override void AddBusinessRulesToProperties()
    {
      // Add any standard rules here.
      //PDSAProperty prop;

      //prop = Properties.GetByName(IsTimePeriodUniquePDSAValidator.ColumnNames.ColumnNameHere);
      //prop.MinLength = 6;

      //prop = Properties.GetByName(IsTimePeriodUniquePDSAValidator.ColumnNames.DateColumnNameHere);
      //prop.MinValue = Convert.ToDateTime("2000-01-01");
      //prop.MaxValue = DateTimeOffset.Now;
    }
    #endregion

    #region GetResourceMessage Method
    /// <summary>
    /// Gets a Resource Message. You can modify this to get the messages from a Resource file, an XML file, or a database for a multi-lingual application.
    /// </summary>
    /// <param name="resourceCode">A unique identifier for this resource</param>
    /// <param name="message">The validation message if the resource is not found</param>
    /// <returns>The message</returns>
    protected override string GetResourceMessage(string resourceCode, string message)
    {
      // You can change this to call your own method here for retrieving messages 
      // from a resource file, a database table, etc.
      return message;
    }
    #endregion
  }
}


using System;

using PDSA.Validation;

using GalaxySMS.EntityLayer;

namespace GalaxySMS.ValidationLayer
{
    /// <summary>
    /// Used to validate business rules on the TimePeriodPDSA class.
    /// This class is generated by the Haystack Code Generator for .NET.
    /// You may add business rules to the ValidateCore method in this class.
    /// </summary>
    public partial class TimePeriodPDSAValidator
    {
        #region Constructor
        /// <summary>
        /// Constructor for the TimePeriodPDSAValidator class
        /// </summary>
        /// <param name="entity">An instance of a TimePeriodPDSA</param>
        public TimePeriodPDSAValidator(TimePeriodPDSA entity) : base()
        {
            Entity = entity;
            ClassName = "TimePeriodPDSAValidator";

            // Create Properties for each field in the TimePeriodPDSA entity class
            InitProperties();

            // Add any additional business rules to the Properties.
            AddBusinessRulesToProperties();
        }
        #endregion

        #region CreateNewEntity Method
        /// <summary>
        /// This method is called when a new instance of the Validator class is created. It calls the InitializeEntity method first. You can then modify this method to set your own default values.
        /// </summary>
        /// <returns>A TimePeriodPDSA object</returns>
        public TimePeriodPDSA CreateNewEntity()
        {
            // Create new Entity Object
            Entity = new TimePeriodPDSA();

            // Initialize new Entity
            InitializeEntity();
            // Reset all SetAsNull properties
            ResetAllSetAsNullProperties(false);

            // Set any custom default values here
            // For Example:
            //  Entity.CurrentDate = DateTimeOffset.Now;

            return Entity;
        }
        #endregion

        #region ValidateCore Method
        /// <summary>
        /// Used to validate any custom business rules on your TimePeriodPDSA class.
        /// You can add any additional business rules to this method that you want.
        /// This method is called by the Insert() and Update() methods and will throw a PDSAValidationException if any business rules fail.
        /// </summary>
        protected override void ValidateCore()
        {
            // Write Custom Business Rules Here


            // Sample:
            if (Entity.EndTime <= Entity.StartTime)
                AddBusinessRuleMessage("EndTime", "EndTime must be greater than StartTime.");

            //if (Entity.Cost == 20)
            //    AddBusinessRuleMessage("Cost", "Cost can not be equal to 20");

            // You can check to see if the Insert() or Update() method called ValidateCore
            // by checking the DataModificationAction property.
            //if (DataModificationAction == PDSADataModificationState.Insert)
            //{
            //  // Do something that you would only do when performing an Insert
            //}
        }
        #endregion

        #region AddBusinessRulesToProperties
        /// <summary>
        /// If you wish to change any of the standard validation properties of any of the columns, retrieve the columns from this method, then change the appropriate properties.
        /// </summary>
        protected override void AddBusinessRulesToProperties()
        {
            // Add any standard rules here.
            //PDSAProperty prop;

            //prop = Properties.GetByName(TimePeriodPDSAValidator.ColumnNames.ColumnNameHere);
            //prop.MinLength = 6;
            //prop = Properties.GetByName(TimePeriodPDSAValidator.ColumnNames.StartTime);
            //prop.MinValue = new TimeSpan(0,0,0);
            //prop.MaxValue = Entity.EndTime - TimeSpan.FromMinutes(1);

            //prop = Properties.GetByName(TimePeriodPDSAValidator.ColumnNames.EndTime);
            //prop.MinValue = Entity.StartTime + TimeSpan.FromMinutes(1);
            //prop.MaxValue = new TimeSpan(23, 59, 59);
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


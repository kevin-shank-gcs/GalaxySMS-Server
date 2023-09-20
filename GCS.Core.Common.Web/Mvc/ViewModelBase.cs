////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Mvc\ViewModelBase.cs
//
// summary:	Implements the view model base class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Core.Common.Web.Mvc
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A view model base. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class ViewModelBase
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Default constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ViewModelBase()
        {
            Init();
        }

//        public List<KeyValuePair<string, string>> ValidationErrors { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the validation errors. </summary>
        ///
        /// <value> The validation errors. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public List<CustomError> ValidationErrors { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the mode. </summary>
        ///
        /// <value> The mode. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string Mode { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a value indicating whether this ViewModelBase is valid. </summary>
        ///
        /// <value> True if this ViewModelBase is valid, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool IsValid { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the event command. </summary>
        ///
        /// <value> The event command. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string EventCommand { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the event argument. </summary>
        ///
        /// <value> The event argument. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string EventArgument { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether this ViewModelBase is detail area visible.
        /// </summary>
        ///
        /// <value> True if this ViewModelBase is detail area visible, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool IsDetailAreaVisible { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether this ViewModelBase is list area visible.
        /// </summary>
        ///
        /// <value> True if this ViewModelBase is list area visible, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool IsListAreaVisible { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Gets or sets a value indicating whether this ViewModelBase is search area visible.
        /// </summary>
        ///
        /// <value> True if this ViewModelBase is search area visible, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool IsSearchAreaVisible { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Initialises this ViewModelBase. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected virtual void Init()
        {
            EventCommand = "List";
            EventArgument = string.Empty;
//            ValidationErrors = new List<KeyValuePair<string, string>>();
            ValidationErrors = new List<CustomError>();

            ListMode();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets this ViewModelBase. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected virtual void Get()
        {
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Handles the request. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public virtual void HandleRequest()
        {
            switch (EventCommand.ToLower())
            {
                case "list":
                case "search":
                    Get();
                    break;

                case "add":
                    Add();
                    break;

                case "edit":
                    IsValid = true;
                    Edit();
                    break;

                case "delete":
                    ResetSearch();
                    Delete();
                    break;

                case "save":
                    Save();
                    Get();
                    break;

                case "cancel":
                    ListMode();
                    Get();
                    break;

                case "resetsearch":
                    ResetSearch();
                    Get();
                    break;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   List mode. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected virtual void ListMode()
        {
            IsValid = true;
            IsDetailAreaVisible = false;
            IsListAreaVisible = true;
            IsSearchAreaVisible = true;

            Mode = "List";
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Adds mode. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected virtual void AddMode()
        {
            IsDetailAreaVisible = true;
            IsListAreaVisible = false;
            IsSearchAreaVisible = false;

            Mode = "Add";
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Edit mode. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected virtual void EditMode()
        {
            IsDetailAreaVisible = true;
            IsListAreaVisible = false;
            IsSearchAreaVisible = false;

            Mode = "Edit";
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Adds.  </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected virtual void Add()
        {

            // Put ViewModel into Add Mode
            AddMode();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Edits this ViewModelBase. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected virtual void Edit()
        {

            // Put View Model into Edit Mode
            EditMode();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Deletes this ViewModelBase. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected virtual void Delete()
        {

            // Set back to normal mode
            ListMode();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves this ViewModelBase. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected virtual void Save()
        {
            if (ValidationErrors.Count > 0)
            {
                IsValid = false;
            }

            if (!IsValid)
            {
                if (Mode == "Add")
                {
                    AddMode();
                }
                else
                {
                    EditMode();
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Resets the search. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        protected virtual void ResetSearch()
        {
        }

    }

}

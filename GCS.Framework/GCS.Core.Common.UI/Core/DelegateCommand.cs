////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Core\DelegateCommand.cs
//
// summary:	Implements the delegate command class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace GCS.Core.Common.UI.Core
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A delegate command. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ///
    /// <typeparam name="T">    Generic type parameter. </typeparam>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class DelegateCommand<T> : ICommand
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="execute">  The execute. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DelegateCommand(Action<T> execute) : this(execute, null) { }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="execute">      The execute. </param>
        /// <param name="canExecute">   The can execute. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DelegateCommand(Action<T> execute, Predicate<T> canExecute) : this(execute, canExecute, "") { }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="execute">      The execute. </param>
        /// <param name="canExecute">   The can execute. </param>
        /// <param name="label">        The label. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DelegateCommand(Action<T> execute, Predicate<T> canExecute, string label)
        {
            _Execute = execute;
            _CanExecute = canExecute;

            Label = label;
        }

        /// <summary>   The execute. </summary>
        readonly Action<T> _Execute = null;
        /// <summary>   The can execute. </summary>
        readonly Predicate<T> _CanExecute = null;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the label. </summary>
        ///
        /// <value> The label. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string Label { get; set; }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Defines the method to be called when the command is invoked. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameter">    Data used by the command.  If the command does not require data
        ///                             to be passed, this object can be set to null. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void Execute(object parameter)
        {
            _Execute((T)parameter);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="parameter">    Data used by the command.  If the command does not require data
        ///                             to be passed, this object can be set to null. </param>
        ///
        /// <returns>   true if this command can be executed; otherwise, false. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool CanExecute(object parameter)
        {
            return _CanExecute == null ? true : _CanExecute((T)parameter);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (_CanExecute != null)
                    CommandManager.RequerySuggested += value;
            }
            remove
            {
                if (_CanExecute != null)
                    CommandManager.RequerySuggested -= value;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Raises the can execute changed event. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }
    }
}

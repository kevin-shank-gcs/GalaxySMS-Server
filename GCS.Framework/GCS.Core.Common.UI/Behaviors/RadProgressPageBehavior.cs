////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Behaviors\RadProgressPageBehavior.cs
//
// summary:	Implements the radians progress page behavior class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using Telerik.Windows.Controls;

namespace GCS.Core.Common.UI.Behaviors
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   The radians progress page behavior. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

	public class RadProgressPageBehavior
	{
        /// <summary>   The page. </summary>
		private readonly WizardPage page = null;
        /// <summary>   The timer. </summary>
		private DispatcherTimer timer;
        /// <summary>   The progress bar. </summary>
		private RadProgressBar progressBar;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Constructor. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="page"> The page. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public RadProgressPageBehavior(WizardPage page)
		{
			this.page = page;
		}

        /// <summary>   The is enabled property. </summary>
		public static readonly DependencyProperty IsEnabledProperty
			= DependencyProperty.RegisterAttached("IsEnabled", typeof(bool), typeof(RadProgressPageBehavior),
				new PropertyMetadata(new PropertyChangedCallback(OnIsEnabledPropertyChanged)));

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sets is enabled. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="dependencyObject"> The dependency object. </param>
        /// <param name="enabled">          True to enable, false to disable. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

		public static void SetIsEnabled(DependencyObject dependencyObject, bool enabled)
		{
			dependencyObject.SetValue(IsEnabledProperty, enabled);
		}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets is enabled. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="dependencyObject"> The dependency object. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

		public static bool GetIsEnabled(DependencyObject dependencyObject)
		{
			return (bool)dependencyObject.GetValue(IsEnabledProperty);
		}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Raises the dependency property changed event. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="dependencyObject"> The dependency object. </param>
        /// <param name="e">                Event information to send to registered event handlers. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

		private static void OnIsEnabledPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
		{
			var page = dependencyObject as WizardPage;
			if (page != null)
			{
				if ((bool)e.NewValue)
				{
					var behavior = new RadProgressPageBehavior(page);
					behavior.Attach();
				}
			}
		}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Attaches this RadProgressPageBehavior. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

		private void Attach()
		{
			this.timer = new DispatcherTimer();
			this.timer.Interval = TimeSpan.FromMilliseconds(10.0);
			this.timer.Tick += new EventHandler(this.Timer_Tick);

			if (page != null)
			{
				page.Loaded += page_Loaded;
			}
		}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by Timer for tick events. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

		private void Timer_Tick(object sender, EventArgs e)
		{
			this.progressBar.Value += 1;
		}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by page for loaded events. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        Routed event information. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

		void page_Loaded(object sender, RoutedEventArgs e)
		{
			var page = sender as WizardPage;
			if (page.Name == "progressPage")
			{
				SetAllowProperties(page, false);
				this.progressBar = page.ChildrenOfType<RadProgressBar>().FirstOrDefault();
				if (this.progressBar != null)
				{
					this.progressBar.ValueChanged += progressBar_ValueChanged;
					this.progressBar.Value = 0;
					this.timer.Start();
				}		
			}
		}		

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Event handler. Called by progressBar for value changed events. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sender">   Source of the event. </param>
        /// <param name="e">        The RoutedPropertyChangedEventArgs&lt;double&gt; to process. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

		void progressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			var wizard = this.progressBar.ParentOfType<RadWizard>();
			if (this.progressBar.Value == this.progressBar.Maximum && wizard != null)
			{
				SetAllowProperties(wizard.SelectedPage, true);
				this.timer.Stop();
			}
		}

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Sets allow properties. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="page">     The page. </param>
        /// <param name="value">    True to value. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

		private void SetAllowProperties(WizardPage page, bool value)
		{
			page.AllowNext = value;
			page.AllowPrevious = value;
			page.AllowCancel = value;
		}
	}
}

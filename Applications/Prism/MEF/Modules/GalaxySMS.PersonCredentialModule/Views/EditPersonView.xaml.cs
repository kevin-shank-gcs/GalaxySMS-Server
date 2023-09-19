using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GCS.Core.Common.UI.Core;
using GCS.Core.Prism;

namespace GalaxySMS.PersonCredential.Views
{
    /// <summary>
    /// Interaction logic for EditPersonView.xaml
    /// </summary>
    public partial class EditPersonView : UserControlViewBase, ISupportDataContext
    {
        public EditPersonView()
        {
            InitializeComponent();
        }

        private void RadTabControl_SelectionChanged(object sender, Telerik.Windows.Controls.RadSelectionChangedEventArgs e)
        {
            //var dependencyObject = sender as DependencyObject;
            //ReMarkInvalid(dependencyObject);
        }

        //public static void ReMarkInvalid(DependencyObject obj)
        //{
        //    if (Validation.GetHasError(obj))
        //    {
        //        List<ValidationError> errors = new List<ValidationError>(Validation.GetErrors(obj));
        //        foreach (ValidationError error in errors)
        //        {
        //            Validation.ClearInvalid((BindingExpressionBase)error.BindingInError);
        //            Validation.MarkInvalid((BindingExpressionBase)error.BindingInError, error);
        //        }
        //    }

        //    for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
        //    {
        //        ReMarkInvalid(VisualTreeHelper.GetChild(obj, i));
        //    }
        //}
    }
}

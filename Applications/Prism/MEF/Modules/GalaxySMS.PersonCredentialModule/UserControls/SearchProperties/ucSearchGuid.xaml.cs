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
using GCS.Core.Common.Extensions;

namespace GalaxySMS.PersonCredential.UserControls.SearchProperties
{
    /// <summary>
    /// Interaction logic for ucSearchGuid.xaml
    /// </summary>
    public partial class ucSearchGuid : UserControl
    {
        public ucSearchGuid()
        {
            InitializeComponent();
        }

        private void RadMaskedTextInput_PreviewKeyDown(object sender, KeyEventArgs e)
        {    
            var gVal = txtGuidValue.Value;
            var c = e.Key.ToString().FirstOrDefault();
            if (string.IsNullOrEmpty(gVal) && e.Key == Key.X) // allow X only 
                return;
            if (c.IsHex() == false)
            {
                e.Handled = true;
            }

            switch (e.Key)
            {
                case Key.NumPad0:
                case Key.NumPad1:
                case Key.NumPad2:
                case Key.NumPad3:
                case Key.NumPad4:
                case Key.NumPad5:
                case Key.NumPad6:
                case Key.NumPad7:
                case Key.NumPad8:
                case Key.NumPad9:
                case Key.D0:
                case Key.D1:
                case Key.D2:
                case Key.D3:
                case Key.D4:
                case Key.D5:
                case Key.D6:
                case Key.D7:
                case Key.D8:
                case Key.D9:
                case Key.A:
                case Key.B:
                case Key.C:
                case Key.D:
                case Key.E:
                case Key.F:
                    break;

                case Key.V:
                    if( (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
                        break;
                    e.Handled = true;
                    break;

                default:
                    if( (Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control)
                        break;
                    e.Handled = true;
                    break;
            }

        }
    }
}

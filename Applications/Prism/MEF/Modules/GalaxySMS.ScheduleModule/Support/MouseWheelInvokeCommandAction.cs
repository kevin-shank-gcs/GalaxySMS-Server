using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Interactivity;

namespace GalaxySMS.Schedule.Support
{
    public class MouseWheelInvokeCommandAction : InvokeCommandAction
    {
        protected override void Invoke(object parameter)
        {
            MouseWheelEventArgs mouseWheelEventArgs = parameter as MouseWheelEventArgs;
            if (mouseWheelEventArgs != null)
                base.Invoke(new MouseWheelInfo(mouseWheelEventArgs.Delta));
            else
                base.Invoke(parameter);
        }
    }
}

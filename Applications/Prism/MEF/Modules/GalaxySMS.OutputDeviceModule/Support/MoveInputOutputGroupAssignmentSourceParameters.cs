using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Client.Entities;

namespace GalaxySMS.OutputDevice.Support
{
    public class MoveInputOutputGroupAssignmentSourceParameters
    {
        public MoveInputOutputGroupAssignmentSourceParameters()
        {
            SelectedInputOutputGroupAssignmentSources = new ObservableCollection<InputOutputGroupAssignmentSource>();
        }
        public ObservableCollection<InputOutputGroupAssignmentSource> SelectedInputOutputGroupAssignmentSources { get; set; }
        public GalaxyOutputDeviceInputSource GalaxyOutputDeviceInputSource { get; set; }
    }
}

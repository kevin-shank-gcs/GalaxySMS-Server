using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.UI.Core;

namespace GalaxySMS.FacilityManager.ViewModels
{
    [Export(typeof(MainWindowViewModel))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class NewDocumentViewModel:ViewModelBase, INewDocumentViewModel
    {
        [ImportingConstructor]
        public NewDocumentViewModel()
        {

        }
        private string _prismRegionName;

        public string PrismRegionName
        {
            get { return _prismRegionName; }
            set
            {
                if (_prismRegionName != value)
                {
                    _prismRegionName = value;
                    OnPropertyChanged(() => PrismRegionName, false);
                }
            }
        }

    }
}

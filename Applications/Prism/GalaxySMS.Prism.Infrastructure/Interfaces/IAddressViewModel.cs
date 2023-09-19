using System.Collections.ObjectModel;
using GalaxySMS.Client.Entities;
using GCS.Core.Common.UI.Core;

namespace GalaxySMS.Prism.Infrastructure
{
    public interface IAddressViewModel
    {
        ReadOnlyCollection<Country> Countries { get; set; }
        Country SelectedCountry { get; set; }
        ReadOnlyCollection<StateProvince> StatesProvinces { get; set; }
        StateProvince SelectedStateProvince { get; set; }
        Address Address { get; set; }
        DelegateCommand<string> LookupZipCodeCommand { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.UI.Core;

namespace GCS.Framework.DataAccess.ViewModels
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class DataImportWizardViewModel : ViewModelBase
    {
        #region Private Fields

        private SqlServerPickerViewModel _sqlServerPickerVM;
        private SqlServerDataImportViewModel _sqlServerDataImportVM;
        private SqlServerDataImportMapperViewModel _sqlServerDataImportMapperVM;

        #endregion

        #region Constructors

        [ImportingConstructor]
        public DataImportWizardViewModel()
        {
            SqlServerPickerVM = new SqlServerPickerViewModel();
            SqlServerDataImportVM = new SqlServerDataImportViewModel();
            SqlServerDataImportMapperVM = new SqlServerDataImportMapperViewModel();
        }

        #endregion

        #region Public Properties

        public SqlServerPickerViewModel SqlServerPickerVM
        {
            get { return _sqlServerPickerVM; }
            set
            {
                if (_sqlServerPickerVM != value)
                {
                    _sqlServerPickerVM = value;
                    OnPropertyChanged(() => SqlServerPickerVM, false);
                }
            }
        }


        public SqlServerDataImportViewModel SqlServerDataImportVM
        {
            get { return _sqlServerDataImportVM; }
            set
            {
                if (_sqlServerDataImportVM != value)
                {
                    _sqlServerDataImportVM = value;
                    OnPropertyChanged(() => SqlServerDataImportVM, false);
                }
            }
        }


        public SqlServerDataImportMapperViewModel SqlServerDataImportMapperVM
        {
            get { return _sqlServerDataImportMapperVM; }
            set
            {
                if (_sqlServerDataImportMapperVM != value)
                {
                    _sqlServerDataImportMapperVM = value;
                    OnPropertyChanged(() => SqlServerDataImportMapperVM, false);
                }
            }
        }

        #endregion
        
        
    }
}

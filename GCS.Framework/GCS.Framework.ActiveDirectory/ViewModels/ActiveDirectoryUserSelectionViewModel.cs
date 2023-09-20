using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.Logger;
using GCS.Core.Common.UI.Core;
using System.Collections.ObjectModel;

namespace GCS.Framework.ActiveDirectory
{
    public class ActiveDirectoryUserSelectionViewModel : ViewModelBase
    {
        private ReadOnlyCollection<GCSADUser> _adUsers;
        private GCSADUser _selectedAdUser;

        public ActiveDirectoryUserSelectionViewModel()
        {
            ReadADUserData();
        }

        #region Public Properties

        public ReadOnlyCollection<GCSADUser> ADUsers
        {
            get { return _adUsers; }
            set
            {
                if (_adUsers != value)
                {
                    _adUsers = value;
                    OnPropertyChanged(() => ADUsers, false);
                }
            }
        }

        public GCSADUser SelectedADUser
        {
            get { return _selectedAdUser; }
            set
            {
                if (_selectedAdUser != value)
                {
                    _selectedAdUser = value;
                    OnPropertyChanged(() => SelectedADUser, false);
                }
            }
        }

        #endregion

        private void ReadADUserData()
        {
            try
            {
                GCSADManager.ReadActiveDirectoryUserDataParameters parameters = new GCSADManager.ReadActiveDirectoryUserDataParameters();
                parameters.WhatToLookFor = GCSADManager.LookForUserDataType.AllUsers;
                byte[] cookieBytes;
                ADUsers = GCSADManager.ReadActiveDirectoryUserData(parameters, string.Empty, false, out cookieBytes);
            }
            catch (Exception ex)
            {
                this.Log().DebugFormat(ex.Message);
            }

        }


    }
}

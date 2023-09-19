using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Effects;
using GalaxySMS.Client.Entities;
using GalaxySMS.Client.SDK;
using GalaxySMS.Client.SDK.Managers;
using GalaxySMS.Common.Constants;
using GalaxySMS.FacilityManager.Properties;
using GalaxySMS.FacilityManager.Views;
using GalaxySMS.Prism.Infrastructure;
using GCS.Core.Common;
using GCS.Core.Common.Extensions;
using GCS.Core.Common.Logger;
using GCS.Core.Common.UI;
using GCS.Core.Common.UI.Core;
using GCS.Framework.Security;
using GCS.Framework.Utilities;

namespace GalaxySMS.FacilityManager.Helpers
{
    public class ApplicationServices //: ViewModelBase
    {

        #region Private fields
        private static ApplicationServices _instance;
        #endregion

        #region Private Methods
        public ApplicationServices()
        {

        }

        #endregion


        public static ApplicationServices Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ApplicationServices();
                }
                return _instance;
            }
        }

    }
}

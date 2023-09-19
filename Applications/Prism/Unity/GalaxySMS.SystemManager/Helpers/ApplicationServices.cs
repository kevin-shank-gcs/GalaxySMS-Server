using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCS.Core.Common.UI.Core;
using GCS.Framework.Utilities;

namespace GalaxySMS.Prism.Helpers
{
    public class ApplicationServices : ViewModelBase
    {
        private static ApplicationServices _instance;
        private ApplicationServices()
        {
        }

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

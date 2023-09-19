using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.BusinessLayer
{
    public class Globals
    {
        private static Globals _instance;
        private Globals()
        {
            int timeoutValue = 0;
            var configValue = ConfigurationManager.AppSettings["sqlCommandTimeout"];
            if( !string.IsNullOrEmpty(configValue) && int.TryParse(configValue, out timeoutValue))
            {
                SqlCommandTimeout = timeoutValue;
            }
            else
                SqlCommandTimeout = 60;
        }

        public static Globals Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Globals();
                }
                return _instance;
            }
        }

        public int SqlCommandTimeout { get; set; }
    }
}

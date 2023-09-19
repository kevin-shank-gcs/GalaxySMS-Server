using GalaxySMS.Business.Entities.Api.NetCore;

namespace GalaxySMS.Cdn.Support
{
    public class Globals
    {
        private static Globals _instance;

        public static Globals Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Globals()
                    {
                        CorsMaxAge = 3600,
                    };
                }
                return _instance;
            }
        }

        public int CorsMaxAge { get; set; }

        public CdnConnectionInfo CdnConnectionInfo { get; internal set; } = new CdnConnectionInfo();
    }
}

using GalaxySMS.Business.Entities;
using System;

namespace GalaxySMS.MercuryApi.Support
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
                        //CorsAllowedOrigins = new List<string>(),
                        CorsMaxAge = 3600,

                    };
                }
                return _instance;
            }
        }

        public Guid ClusterUid { get; set; }
        public Guid NoAreaUid { get; set; }
        public Guid TimeScheduleNeverUid => GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Never;
        public Guid TimeScheduleAlwaysUid => GalaxySMS.Common.Constants.TimeScheduleIds.TimeSchedule_Always;

        //public List<string> CorsAllowedOrigins { get; set; }
        public int CorsMaxAge { get; set; }
        public UserSignInResult UserSignInResult { get; set; }
        public long MaxUploadFileSize { get; set; }
    }
}

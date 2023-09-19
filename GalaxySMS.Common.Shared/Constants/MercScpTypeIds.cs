////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\GalaxyCpuTypeIds.cs
//
// summary:	Implements the galaxy CPU type identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A galaxy CPU type identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class MercScpTypeIds
    {
        public static readonly Guid Lp1501 = new Guid("00000000-0000-0000-0000-000000001501");
        public static readonly Guid Lp1502 = new Guid("00000000-0000-0000-0000-000000001502");
        public static readonly Guid Lp2500 = new Guid("00000000-0000-0000-0000-000000002500");
        public static readonly Guid Lp4502 = new Guid("00000000-0000-0000-0000-000000004502");

        // Types that exist but we do not support
        // 
        public static readonly Guid SCP = new Guid("00000000-0000-0000-0001-000000000000");
        public static readonly Guid SCPC = new Guid("00000000-0000-0000-0001-000000000001");
        public static readonly Guid SCPE = new Guid("00000000-0000-0000-0001-000000000002");
        public static readonly Guid PW5000 = new Guid("00000000-0000-0000-0001-000000000003");
        public static readonly Guid PW5000A = new Guid("00000000-0000-0000-0001-000000000004");
        public static readonly Guid PW3000 = new Guid("00000000-0000-0000-0001-000000000005");
        public static readonly Guid EP1501 = new Guid("00000000-0000-0000-0001-000000001501");
        public static readonly Guid EP1502 = new Guid("00000000-0000-0000-0001-000000001502");
        public static readonly Guid EP2500 = new Guid("00000000-0000-0000-0001-000000002500");
        public static readonly Guid EP4502 = new Guid("00000000-0000-0000-0001-000000004502");
        public static readonly Guid PW6000 = new Guid("00000000-0000-0000-0001-000000000010");
        public static readonly Guid PRO3200 = new Guid("00000000-0000-0000-0001-000000000011");
        public static readonly Guid NXT = new Guid("00000000-0000-0000-0001-000000000012");
        public static readonly Guid MIRS4 = new Guid("00000000-0000-0000-0001-000000000013");
        public static readonly Guid MIXL16 = new Guid("00000000-0000-0000-0001-000000000014");
        public static readonly Guid MSICS = new Guid("00000000-0000-0000-0001-000000000015");
        public static readonly Guid M5IC = new Guid("00000000-0000-0000-0001-000000000016");
        public static readonly Guid SSC = new Guid("00000000-0000-0000-0001-000000000017");
        public static readonly Guid AP2 = new Guid("00000000-0000-0000-0001-000000000018");
        public static readonly Guid X1100 = new Guid("00000000-0000-0000-0001-000000000023");
        public static readonly Guid PW7000 = new Guid("00000000-0000-0000-0001-000000000024");
        public static readonly Guid PRO4200 = new Guid("00000000-0000-0000-0001-000000000025");


    }
}

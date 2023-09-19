// RF IDeas, Inc. Proprietary and Confidential
// Copyright © 2016 RF IDeas, Inc. as an unpublished work.
// All Rights Reserved

using System.Runtime.InteropServices;
//
// This provides a C# wrapper class on top of the pcProxAPI.dll
// so that the functions may be called from C#
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Framework.CredentialProcessor
{
    class pcproxlib
    {

        [DllImport("pcProxAPI.dll")]
        public static extern ushort usbConnect();
        [DllImport("pcProxAPI.dll")]
        public static extern IntPtr getPartNumberString();
        [DllImport("pcProxAPI.dll")]
        public static extern int GetLUID();
        [DllImport("pcProxAPI.dll")]
        public static extern short GetDevCnt();
        [DllImport("pcProxAPI.dll")]
        public static extern IntPtr GetVidPidVendorName();
        [DllImport("pcProxAPI.dll")]
        public static extern ushort SetActDev(short iNdx);
        [DllImport("pcProxAPI.dll")]
        public static extern ushort GetLibVersion(ref short major, ref short minor, ref short ver);
        [DllImport("pcProxAPI.dll")]
        public static extern ushort GetActiveID32(IntPtr result1, short buffSize);
        [DllImport("pcProxAPI.dll")]
        public static extern ushort SetDevTypeSrch(short iSrchType);
        [DllImport("pcProxAPI.dll")]
        public static extern IntPtr getESN();

        //Function to set Library Path
        public static void setLibPath()
        {
            bool is64 = System.Environment.Is64BitProcess;
            String existingPathValue = System.Environment.GetEnvironmentVariable("PATH");  
            if(is64)
            {

                System.Environment.SetEnvironmentVariable("PATH", existingPathValue + ";" + @"..\..\..\..\lib\64");
            }
            else
            {
                System.Environment.SetEnvironmentVariable("PATH", existingPathValue + ";" + @"..\..\..\..\lib\32");
            }

            
        }
    }
}

// Copyright © RF IDeas, Inc. Proprietary and confidential.
// EOF
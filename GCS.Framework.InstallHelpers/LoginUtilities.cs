using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Framework.InstallHelpers
{
    public static class LoginUtilities
    {
        public static void GrantUserLogOnAsAService(string userName)
        {
            try
            {
                LsaWrapper lsaUtility = new LsaWrapper();
 
                lsaUtility.SetRight(userName, "SeServiceLogonRight");
 
                Console.WriteLine("Logon as a Service right is granted successfully to " + userName);
            }            
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

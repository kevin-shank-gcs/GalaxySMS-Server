using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace GCS.Framework.Biometrics.MorphoManager.BioBridge
{
    public enum BioBridgeEnrollReturnCodes : int { Aborted = -1, Canceled = 1, FingersEnrolled = 2, FaceEnrolled = 3, FingersAndFaceEnrolled = 4 };
    public class BioBridgeUserEnrollmentResult
    {
        public int EmployeeId { get; set; }
        public int CardId { get; set; }
        public BioBridgeEnrollReturnCodes ResultCode { get; set; }
    }

    public class BioBridgeUser
    {
        public string BioBridgeUserID;
        public string BioBridgeGroupingNameArray;
        public string DisplayIdentifier;
        public string FirstName;
        public string MiddleName;
        public string LastName;
        public string DOB;
        public string WiegandUserValue1;
        public string WiegandUserValue2;
        public string WiegandUserValue3;
        public string WiegandUserValue4;
        public string WiegandUserValue5;
        public string WiegandUserValue6;
        public string WiegandUserValue7;
        public string WiegandUserValue8;
        public string WiegandUserValue9;
        public string WiegandUserValue10;
        public string BioManagerUserName;
        public string BioManagerPassword;

        public static string GetBioBridgeDesktopEnrollmentPath()
        {
            return (string)Registry.LocalMachine.OpenSubKey("Software", false)?.OpenSubKey("Identity One", false)?.GetValue("ID1.BioBridge1Enrollment1");
        }

        public static bool IsBioBridgeInstalled()
        {
            var path = GetBioBridgeDesktopEnrollmentPath();
            return !string.IsNullOrEmpty(path);
        }

        public static int LaunchBioBridgeDesktopEnrollment(BioBridgeUser user, bool waitForProcessToExit)
        {
            if (user == null)
                throw new ArgumentNullException("user cannot be null");
            int result = 0;
            string filePath = GetBioBridgeDesktopEnrollmentPath();
            if( string.IsNullOrEmpty(filePath))
                throw new Exception("BioBridge is not installed");

            Process eeClient = new Process();
            eeClient.StartInfo = new ProcessStartInfo()
            {
                Arguments = PopulateArguments(user),
                FileName = filePath,
                UseShellExecute = false,
                WorkingDirectory = Path.GetDirectoryName(filePath)
            };
            if (eeClient.Start() && waitForProcessToExit)
            {
                eeClient.WaitForExit();
                result = eeClient.ExitCode;
            }

            return result;
        }

        private static string PopulateArguments(BioBridgeUser user)
        {
            string arguments = "";

            if (!string.IsNullOrEmpty(user.BioManagerUserName))
                arguments += "/BioManagerUserName: \"" + user.BioManagerUserName + "\" ";
            if (!string.IsNullOrEmpty(user.BioManagerPassword))
                arguments += "/BioManagerPassword: \"" + user.BioManagerPassword + "\" ";

            if (!string.IsNullOrEmpty(user.BioBridgeUserID))
                arguments += "/BioBridgeUserID: \"" + user.BioBridgeUserID + "\" ";
            if (!string.IsNullOrEmpty(user.BioBridgeGroupingNameArray))
                arguments += "/BioBridgeGroupingNameArray: \"" + user.BioBridgeGroupingNameArray + "\" ";

            if (!string.IsNullOrEmpty(user.DisplayIdentifier))
                arguments += "/DisplayIdentifier: \"" + user.DisplayIdentifier + "\" ";
            if (!string.IsNullOrEmpty(user.FirstName))
                arguments += "/FirstName: \"" + user.FirstName + "\" ";
            if (!string.IsNullOrEmpty(user.MiddleName))
                arguments += "/MiddleName: \"" + user.MiddleName + "\" ";
            if (!string.IsNullOrEmpty(user.LastName))
                arguments += "/LastName: \"" + user.LastName + "\" ";
            if (!string.IsNullOrEmpty(user.DOB))
                arguments += "/LastName: \"" + user.DOB + "\" ";

            if (!string.IsNullOrEmpty(user.WiegandUserValue1))
                arguments += "/WiegandUserValue1: \"" + user.WiegandUserValue1 + "\" ";
            if (!string.IsNullOrEmpty(user.WiegandUserValue2))
                arguments += "/WiegandUserValue2: \"" + user.WiegandUserValue2 + "\" ";
            if (!string.IsNullOrEmpty(user.WiegandUserValue3))
                arguments += "/WiegandUserValue3: \"" + user.WiegandUserValue3 + "\" ";
            if (!string.IsNullOrEmpty(user.WiegandUserValue4))
                arguments += "/WiegandUserValue4: \"" + user.WiegandUserValue4 + "\" ";
            if (!string.IsNullOrEmpty(user.WiegandUserValue5))
                arguments += "/WiegandUserValue5: \"" + user.WiegandUserValue5 + "\" ";
            if (!string.IsNullOrEmpty(user.WiegandUserValue6))
                arguments += "/WiegandUserValue6: \"" + user.WiegandUserValue6 + "\" ";
            if (!string.IsNullOrEmpty(user.WiegandUserValue7))
                arguments += "/WiegandUserValue7: \"" + user.WiegandUserValue7 + "\" ";
            if (!string.IsNullOrEmpty(user.WiegandUserValue8))
                arguments += "/WiegandUserValue8: \"" + user.WiegandUserValue8 + "\" ";
            if (!string.IsNullOrEmpty(user.WiegandUserValue9))
                arguments += "/WiegandUserValue9: \"" + user.WiegandUserValue9 + "\" ";
            if (!string.IsNullOrEmpty(user.WiegandUserValue10))
                arguments += "/WiegandUserValue10: \"" + user.WiegandUserValue10 + "\" ";
            return arguments;
        }

        public int LaunchBioBridgeDesktopEnrollment()
        {
            return LaunchBioBridgeDesktopEnrollment(this, true);
        }
    }

}

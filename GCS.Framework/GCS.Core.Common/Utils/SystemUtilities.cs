////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Utils\SystemUtilities.cs
//
// summary:	Implements the system utilities class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GCS.Framework.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Core.Common.Utils
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A system utilities. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static class SystemUtilities
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if 'name' is process running. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="name"> The name. </param>
        ///
        /// <returns>   True if process running, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static bool IsProcessRunning(string name)
        {
//            Process[] procs = Process.GetProcesses();
            //here we're going to get a list of all running processes on
            //the computer
            foreach (Process clsProcess in Process.GetProcessesByName(name))//Process.GetProcesses())
            {
                //now we're going to see if any of the running processes
                //match the currently running processes. Be sure to not
                //add the .exe to the name you provide, i.e: NOTEPAD,
                //not NOTEPAD.EXE or false is always returned even if
                //notepad is running.
                //Remember, if you have the process running more than once, 
                //say IE open 4 times the loop thr way it is now will close all 4,
                //if you want it to just close the first one it finds
                //then add a return; after the Kill
                if (clsProcess.ProcessName.Contains(name))
                {
                    //if the process is found to be running then we
                    //return a true
                    return true;
                }
            }
            //otherwise we return a false
            return false;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Prior process. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   The Process. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static Process PriorProcess()
        {
            // Returns a System.Diagnostics.Process pointing to
            // a pre-existing process with the same name as the
            // current one, if any; or null if the current process
            // is unique.
            Process curr = Process.GetCurrentProcess();
            Process[] procs = Process.GetProcessesByName(curr.ProcessName);
            foreach (Process p in procs)
            {
                if ((p.Id != curr.Id) && (p.MainModule.FileName == curr.MainModule.FileName))
                    return p;
            }
            return null;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets running process. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="name"> The name. </param>
        ///
        /// <returns>   The running process. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static Process GetRunningProcess(string name)
        {
            //here we're going to get a list of all running processes on
            //the computer

            foreach (Process clsProcess in Process.GetProcessesByName(name))//Process.GetProcesses())
            {
                //now we're going to see if any of the running processes
                //match the currently running processes. Be sure to not
                //add the .exe to the name you provide, i.e: NOTEPAD,
                //not NOTEPAD.EXE or false is always returned even if
                //notepad is running.
                //Remember, if you have the process running more than once, 
                //say IE open 4 times the loop thr way it is now will close all 4,
                //if you want it to just close the first one it finds
                //then add a return; after the Kill
                if (clsProcess.ProcessName.Contains(name))
                {
                    //if the process is found to be running then we
                    //return a true
                    return clsProcess;
                }
            }
            //otherwise we return a false
            return null;

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets assembly attributes. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="assem">    [in,out] The assem. </param>
        ///
        /// <returns>   The assembly attributes. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static AssemblyAttributes GetAssemblyAttributes(ref Assembly assem)
        {
            AssemblyAttributes assAttr = new AssemblyAttributes();
            // Iterate through the attributes for the assembly.
            foreach (Attribute attr in Attribute.GetCustomAttributes(assem))
            {
                // Check for the AssemblyTitle attribute.
                if (attr.GetType() == typeof(AssemblyTitleAttribute))
                    assAttr.Title = ((AssemblyTitleAttribute)attr).Title;

                // Check for the AssemblyDescription attribute.
                else if (attr.GetType() ==
                    typeof(AssemblyDescriptionAttribute))
                    assAttr.Description = ((AssemblyDescriptionAttribute)attr).Description;

                // Check for the AssemblyCompany attribute.
                else if (attr.GetType() == typeof(AssemblyCompanyAttribute))
                    assAttr.Company = ((AssemblyCompanyAttribute)attr).Company;

                // Check for the AssemblyProduct attribute.
                else if (attr.GetType() == typeof(AssemblyProductAttribute))
                    assAttr.Product = ((AssemblyProductAttribute)attr).Product;

                    // Check for the AssemblyCopyrightAttribute attribute.
                else if (attr.GetType() == typeof(AssemblyCopyrightAttribute))
                    assAttr.Copyright = ((AssemblyCopyrightAttribute)attr).Copyright;

                    // Check for the AssemblyCopyrightAttribute attribute.
                else if (attr.GetType() == typeof(AssemblyConfigurationAttribute))
                    assAttr.Configuration = ((AssemblyConfigurationAttribute)attr).Configuration;

                    // Check for the AssemblyCopyrightAttribute attribute.
                else if (attr.GetType() == typeof(AssemblyCopyrightAttribute))
                    assAttr.Copyright = ((AssemblyCopyrightAttribute)attr).Copyright;

                else if (attr.GetType() == typeof(AssemblyTrademarkAttribute))
                    assAttr.Trademark = ((AssemblyTrademarkAttribute)attr).Trademark;
                // Check for the AssemblyCultureAttribute attribute.
                else if (attr.GetType() == typeof(AssemblyFileVersionAttribute))
                    assAttr.AssemblyFileVersion = ((AssemblyFileVersionAttribute)attr).Version;
                // Check for the AssemblyCultureAttribute attribute.
                else if (attr.GetType() == typeof(AssemblyCultureAttribute))
                    assAttr.Culture = ((AssemblyCultureAttribute)attr).Culture;
                //// Check for the ThemeInfoAttribute attribute.
                //else if (attr.GetType() == typeof(ThemeInfoAttribute))
                //    assAttr.ThemeInfo = ((ThemeInfoAttribute)attr);
                else
                {
                    Type t = attr.GetType();
                }
            }

            assAttr.Version = assem.GetName().Version;
            return assAttr;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets processor information. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   The processor information. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static ManagementObject GetProcessorInfo()
        {
            ManagementObjectSearcher processorSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
            foreach (ManagementObject obj in processorSearcher.Get())
            {

            }
            return null;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets logical drive information. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="sPath">    Full pathname of the file. </param>
        ///
        /// <returns>   The logical drive information. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static LogicalDriveInfo GetLogicalDriveInfo(string sPath)
        {
            LogicalDriveInfo ldi = new LogicalDriveInfo();
            try
            {
                ManagementScope ms = new ManagementScope();
                ObjectQuery oq = new ObjectQuery("select * from Win32_LogicalDisk where DriveType=3");    // local disk\

                ManagementObjectSearcher mos = new ManagementObjectSearcher(ms, oq);
                ManagementObjectCollection moc = mos.Get();

                foreach (ManagementObject mo in moc)
                {
                    object obj = mo["DeviceID"];
                    if (obj != null)
                    {
                        string devID = obj.ToString();

                        if (sPath.StartsWith(devID))
                        {
                            obj = mo["VolumeSerialNumber"];
                            if (obj != null)
                                ldi.VolumeSerialNumber = obj.ToString();   // this is what SG / Client GW uses

                            obj = mo["VolumeName"];
                            if (obj != null)
                                ldi.VolumeName = obj.ToString();

                            obj = mo["SystemName"];
                            if (obj != null)
                                ldi.SystemName = obj.ToString();

                            obj = mo["Name"];
                            if (obj != null)
                                ldi.Name = obj.ToString();

                            obj = mo["Caption"];
                            if (obj != null)
                                ldi.Caption = obj.ToString();

                            obj = mo["Description"];
                            if (obj != null)
                                ldi.Description = obj.ToString();

                            obj = mo["FileSystem"];
                            if (obj != null)
                                ldi.FileSystem = obj.ToString();
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return ldi;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets drive information. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   An array of hard drive information. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static HardDriveInfo[] GetDriveInfo()
        {
            List<HardDriveInfo> hdCollection = new List<HardDriveInfo>();

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
            foreach (ManagementObject wmi_HD in searcher.Get())
            {
                HardDriveInfo hd = new HardDriveInfo();
                string desc = wmi_HD["Description"].ToString().Trim();
                string devID = wmi_HD["DeviceID"].ToString().Trim();
                string name = wmi_HD["Name"].ToString().Trim();
                hd.SerialNo = wmi_HD["SerialNumber"].ToString().Trim();
                string systemName = wmi_HD["SystemName"].ToString().Trim();

                hd.ModelNo = wmi_HD["Model"].ToString().Trim();
                hd.Type = wmi_HD["InterfaceType"].ToString().Trim();
                hdCollection.Add(hd);
            }
            searcher = new
            ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");
            int i = 0;
            foreach (ManagementObject wmi_HD in searcher.Get())
            {
                // get the hard drive from collection
                // using index
                if (i == hdCollection.Count) break;
                HardDriveInfo hd = (HardDriveInfo)hdCollection[i];
                // get the hardware serial no.
                if (wmi_HD["SerialNumber"] == null)
                    hd.SerialNo = "None";
                else
                    hd.SerialNo = wmi_HD["SerialNumber"].ToString().Trim();

                i++;

            }
            return hdCollection.ToArray();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   My machine name. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string MyMachineName()
        {
            return Dns.GetHostName();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   My IP addresses. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   An IPAddress[]. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static IPAddress[] MyIPAddresses()
        {
            string strHostName = Dns.GetHostName();
            // Find host by name
            IPHostEntry iphostentry = Dns.GetHostEntry(strHostName);

            return iphostentry.AddressList;

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   My assembly name. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <returns>   A string. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string MyAssemblyName()
        {
            Assembly myAss = Assembly.GetExecutingAssembly();
            return myAss.FullName;
        }

        public static AssemblyAttributes MyAssemblyAttributes()
        {
            Assembly myAss = Assembly.GetExecutingAssembly();
            return GetAssemblyAttributes(ref myAss);
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the name of my process. </summary>
        ///
        /// <value> The name of my process. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string MyProcessName
        {
			  get
			  {
				  Process myProc = Process.GetCurrentProcess();
				  return myProc.ProcessName;
			  }

        }

          ////////////////////////////////////////////////////////////////////////////////////////////////////
          /// <summary> Gets my folder location. </summary>
          ///
          /// <value>   my folder location. </value>
          ////////////////////////////////////////////////////////////////////////////////////////////////////

		  public static string MyFolderLocation
		  {
			  get
			  {
				  Process myProc = Process.GetCurrentProcess();
				  return Path.GetDirectoryName(myProc.Modules[0].FileName);
			  }
		  }

          ////////////////////////////////////////////////////////////////////////////////////////////////////
          /// <summary> Gets my process. </summary>
          ///
          /// <value>   my process. </value>
          ////////////////////////////////////////////////////////////////////////////////////////////////////

		  public static Process MyProcess
		  {
			  get
			  {
				  Process myProc = Process.GetCurrentProcess();
				  return myProc;
			  }

		  }
     }
}

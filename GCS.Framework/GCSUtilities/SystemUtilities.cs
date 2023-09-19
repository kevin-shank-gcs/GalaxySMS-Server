using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Reflection;
using System.IO;
using System.Net;
using GCS.Framework.Utilities.Computer;

namespace GCS.Framework.Utilities
{
    public static partial class SystemUtilities
    {
        //[DllImport("user32.dll")]
        //public static extern Boolean ShowWindow(IntPtr hWnd, Int32 nCmdShow);
        //[DllImport("user32.dll")]
        //public static extern bool SetForegroundWindow(IntPtr hWnd);

        //public static bool IsProcessRunning(string name)
        //{
        //    //            Process[] procs = Process.GetProcesses();
        //    //here we're going to get a list of all running processes on
        //    //the computer
        //    return Process.GetProcessesByName(name).Any(clsProcess => clsProcess.ProcessName.Contains(name));
        //    //otherwise we return a false
        //}

        //public static Process PriorProcess()
        //{
        //    // Returns a System.Diagnostics.Process pointing to
        //    // a pre-existing process with the same name as the
        //    // current one, if any; or null if the current process
        //    // is unique.
        //    Process curr = Process.GetCurrentProcess();
        //    Process[] procs = Process.GetProcessesByName(curr.ProcessName);
        //    return procs.FirstOrDefault(p => (p.Id != curr.Id) && (p.MainModule.FileName == curr.MainModule.FileName));
        //}

        //public static Process GetRunningProcess(string name)
        //{
        //    //here we're going to get a list of all running processes on
        //    //the computer

        //    return Process.GetProcessesByName(name).FirstOrDefault(clsProcess => clsProcess.ProcessName.Contains(name));
        //    //otherwise we return a false
        //}

        //public static AssemblyAttributes GetEntryAssemblyAttributes()
        //{
        //    Assembly assem = System.Reflection.Assembly.GetEntryAssembly();
        //    return GetAssemblyAttributes(ref assem);
        //}

        //public static AssemblyAttributes GetAssemblyAttributes(ref Assembly assem)
        //{
        //    if (assem == null)
        //        assem = System.Reflection.Assembly.GetEntryAssembly();
        //    if (assem == null)
        //        assem = System.Reflection.Assembly.GetExecutingAssembly();

        //    AssemblyAttributes assAttr = new AssemblyAttributes();
        //    // Iterate through the attributes for the assembly.
        //    foreach (Attribute attr in Attribute.GetCustomAttributes(assem))
        //    {
        //        // Check for the AssemblyTitle attribute.
        //        if (attr.GetType() == typeof(AssemblyTitleAttribute))
        //            assAttr.Title = ((AssemblyTitleAttribute)attr).Title;

        //        // Check for the AssemblyDescription attribute.
        //        else if (attr.GetType() ==
        //            typeof(AssemblyDescriptionAttribute))
        //            assAttr.Description = ((AssemblyDescriptionAttribute)attr).Description;

        //            // Check for the AssemblyCopyrightAttribute attribute.
        //        else if (attr.GetType() == typeof(AssemblyConfigurationAttribute))
        //            assAttr.Configuration = ((AssemblyConfigurationAttribute)attr).Configuration;

        //        // Check for the AssemblyCompany attribute.
        //        else if (attr.GetType() == typeof(AssemblyCompanyAttribute))
        //            assAttr.Company = ((AssemblyCompanyAttribute)attr).Company;

        //        // Check for the AssemblyProduct attribute.
        //        else if (attr.GetType() == typeof(AssemblyProductAttribute))
        //            assAttr.Product = ((AssemblyProductAttribute)attr).Product;

        //            // Check for the AssemblyCopyrightAttribute attribute.
        //        else if (attr.GetType() == typeof(AssemblyCopyrightAttribute))
        //            assAttr.Copyright = ((AssemblyCopyrightAttribute)attr).Copyright;

        //        else if (attr.GetType() == typeof(AssemblyTrademarkAttribute))
        //            assAttr.Trademark = ((AssemblyTrademarkAttribute)attr).Trademark;
        //        // Check for the AssemblyCultureAttribute attribute.
        //        else if (attr.GetType() == typeof(AssemblyCultureAttribute))
        //            assAttr.Culture = ((AssemblyCultureAttribute)attr).Culture;
        //        // Check for the AssemblyCultureAttribute attribute.
        //        else if (attr.GetType() == typeof(AssemblyFileVersionAttribute))
        //            assAttr.AssemblyFileVersion = ((AssemblyFileVersionAttribute)attr).Version;
        //        //// Check for the ThemeInfoAttribute attribute.
        //        //else if (attr.GetType() == typeof(ThemeInfoAttribute))
        //        //    assAttr.ThemeInfo = ((ThemeInfoAttribute)attr);
        //        else
        //        {
        //            Type t = attr.GetType();
        //        }
        //    }

        //    assAttr.Version = assem.GetName().Version;

        //    var attributes = assem.GetCustomAttributes(typeof(GuidAttribute), true);
        //    if (attributes != null && attributes.Length > 0)
        //    {
        //        var attribute = (GuidAttribute)attributes[0];
        //        var id = attribute.Value;
        //        Guid gValue;
        //        if (Guid.TryParse(id, out gValue))
        //            assAttr.Guid = gValue;
        //    }
        //    return assAttr;
        //}

        public static List<ManagementObject> GetProcessorInfo()
        {
            var processorSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
            var results = new List<ManagementObject>();
            foreach (ManagementObject obj in processorSearcher.Get())
            {
                results.Add(obj);
            }
            return results;
        }

        public static LogicalDriveInformation GetLogicalDriveInfo(string sPath)
        {
            LogicalDriveInformation ldi = new LogicalDriveInformation();
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

                        if( string.IsNullOrEmpty(sPath))
                        {
                            sPath = MyFolderLocation;
                        }
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

        public static HardDriveInformation[] GetDriveInfo()
        {
            List<HardDriveInformation> hdCollection = new List<HardDriveInformation>();

            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
            foreach (ManagementObject wmi_HD in searcher.Get())
            {
                HardDriveInformation hd = new HardDriveInformation();
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
                HardDriveInformation hd = (HardDriveInformation)hdCollection[i];
                // get the hardware serial no.
                if (wmi_HD["SerialNumber"] == null)
                    hd.SerialNo = "None";
                else
                    hd.SerialNo = wmi_HD["SerialNumber"].ToString().Trim();

                i++;

            }
            return hdCollection.ToArray();
        }

        //public static string MyMachineName()
        //{
        //    return Dns.GetHostName();
        //}

        //public static IPAddress[] MyIPAddresses()
        //{
        //    string strHostName = Dns.GetHostName();
        //    // Find host by name
        //    IPHostEntry iphostentry = Dns.GetHostEntry(strHostName);

        //    return iphostentry.AddressList;

        //}

        //public static string MyAssemblyName()
        //{
        //    Assembly myAss = Assembly.GetExecutingAssembly();
        //    return myAss.FullName;
        //}

        //public static string MyProcessName
        //{
        //    get
        //    {
        //        Process myProc = Process.GetCurrentProcess();
        //        return myProc.ProcessName;
        //    }

        //}

        //public static string MyFolderLocation
        //{
        //    get
        //    {
        //        Process myProc = Process.GetCurrentProcess();
        //        return Path.GetDirectoryName(myProc.Modules[0].FileName);
        //    }
        //}

        //public static Process MyProcess
        //{
        //    get
        //    {
        //        Process myProc = Process.GetCurrentProcess();
        //        return myProc;
        //    }

        //}

        //public static Assembly ExecutingAssembly
        //{
        //    get { return Assembly.GetExecutingAssembly(); }

        //}
        //public static string ExecutingAssemblyPath
        //{
        //    get
        //    {
        //        return SystemUtilities.ExecutingAssembly.Location;
        //    }
        //}
        //public static Assembly EntryAssembly
        //{
        //    get { return Assembly.GetEntryAssembly(); }

        //}
        //public static string EntryAssemblyPath
        //{
        //    get
        //    {
        //        return SystemUtilities.EntryAssembly.Location;
        //    }
        //}
    }
}

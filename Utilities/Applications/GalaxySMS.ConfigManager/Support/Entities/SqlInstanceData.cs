using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.ConfigManager.Support.Entities
{
    public class SqlInstanceData
    {
        private string currentVersionFromRegistry;

        public SqlInstanceData()
        {

        }

        public SqlInstanceData(SqlInstanceData o)
        {
            if (o == null)
                return;
            this.InstanceName = o.InstanceName;
            InstanceData = o.InstanceData;
            CurrentVersionFromRegistry = o.CurrentVersionFromRegistry;
            SqlVersionParts = o.SqlVersionParts;
            AllowInstallNewInstance = o.AllowInstallNewInstance;
            DataFilePath = o.DataFilePath;
            LogFilePath = o.LogFilePath;
            ConnectionString = o.ConnectionString;
            IsConnectionValid = o.IsConnectionValid;
            SqlCmdConnectString = o.SqlCmdConnectString;
        }

        public string InstanceName { get; set; }
        public string InstanceData { get; set; }
        public string CurrentVersionFromRegistry
        {
            get => currentVersionFromRegistry;
            set
            {
                currentVersionFromRegistry = value;
                SqlVersionParts = currentVersionFromRegistry.Split(new string[] { "." }, StringSplitOptions.None);
            }
        }

        public int SqlVersionRawNumber
        {
            get
            {
                if (SqlVersionParts == null || SqlVersionParts.Length == 0)
                    return 0;
                int number = 0;
                if (int.TryParse(SqlVersionParts[0], out number))
                    return number;
                return 0;
            }
        }

        public int SqlVersionNumber
        {
            get
            {
                switch (SqlVersionRawNumber)
                {
                    case 8:
                        return 2000;
                    case 9:
                        return 2005;
                    case 10:
                        return 2008;
                    case 11:
                        return 2012;
                    case 12:
                        return 2014;
                    case 13:
                        return 2016;
                    case 14:
                        return 2017;
                    case 15:
                        return 2019;

                    default:
                        return 0;
                }
            }
        }

        public string SqlVersionString
        {
            get
            {
                return $"SQL Server {SqlVersionNumber}";
            }
        }

        public string[] SqlVersionParts { get; internal set; }

        public bool IsSqlVersionOrGreater(int version)
        {
            return SqlVersionNumber >= version;
        }

        public bool IsSqlVersion(int version)
        {
            return SqlVersionNumber == version;
        }

        public bool AllowInstallNewInstance { get; set; }
        public override string ToString()
        {
            if (SqlVersionNumber > 0)
                return $"{InstanceName} ({SqlVersionString})";
            return InstanceName;
        }

        public string DataFilePath { get; set; }
        public string LogFilePath { get; set; }
        public string ConnectionString {get;set;}
        public string SqlCmdConnectString { get; set; }
        public bool IsConnectionValid { get; set; }
    }


}

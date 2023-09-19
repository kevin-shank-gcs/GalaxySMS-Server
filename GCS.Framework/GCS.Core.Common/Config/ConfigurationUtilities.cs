////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Config\ConfigurationUtilities.cs
//
// summary:	Implements the configuration utilities class
////////////////////////////////////////////////////////////////////////////////////////////////////

using GCS.Core.Common.Logger;
using System;
using System.Configuration;

namespace GCS.Core.Common.Config
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A configuration utilities. </summary>
    ///
    /// <remarks>   Kevin, 12/26/2018. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public static class ConfigurationUtilities
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves an application setting. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="configFilename">   Filename of the configuration file. </param>
        /// <param name="sectionName">      Name of the section. </param>
        /// <param name="key">              The key. </param>
        /// <param name="value">            The value. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void SaveAppSetting(string configFilename, string sectionName, string key, string value)
        {
            try
            {
                if (string.IsNullOrEmpty(configFilename))
                    configFilename = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
                ExeConfigurationFileMap configMap = new ExeConfigurationFileMap();
                configMap.ExeConfigFilename = configFilename;
                Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
                if (config != null)
                {
                    if (string.IsNullOrEmpty(sectionName))
                        sectionName = "appSettings";

                    AppSettingsSection appSettingsSection =
                      (AppSettingsSection)config.GetSection(sectionName);

                    if (appSettingsSection != null)
                    {
                        KeyValueConfigurationElement kv = appSettingsSection.Settings[key];//, chkInsertCard.Checked.ToString());
                        if (kv != null)
                        {
                            kv.Value = value;
                        }
                        else
                        {
                            appSettingsSection.Settings.Add(key, value);
                        }

                    }
                    config.Save(ConfigurationSaveMode.Modified);
                }
            }
            catch (Exception ex)
            {
                LogManager.GetLogger<object>().ErrorFormat($"SaveAppSetting Section:{sectionName}, Key:{key}, Value:{value} error: {ex.Message}");
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets application setting. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="configFilename">       Filename of the configuration file. </param>
        /// <param name="sectionName">          Name of the section. </param>
        /// <param name="key">                  The key. </param>
        /// <param name="defaultIfNotFound">    True to default if not found. </param>
        /// <param name="createIfNotFound">     True to create if not found. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static string GetAppSetting(string configFilename, string sectionName, string key, string defaultIfNotFound, Boolean createIfNotFound)
        {
            try
            {
                if (string.IsNullOrEmpty(configFilename))
                    configFilename = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;


                ExeConfigurationFileMap configMap = new ExeConfigurationFileMap();
                configMap.ExeConfigFilename = configFilename;
                Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
                if (config != null)
                {
                    if (string.IsNullOrEmpty(sectionName))
                        sectionName = "appSettings";

                    AppSettingsSection appSettingsSection =
                      (AppSettingsSection)config.GetSection(sectionName);

                    if (appSettingsSection != null)
                    {
                        KeyValueConfigurationElement kv = appSettingsSection.Settings[key];
                        if (kv != null)
                        {
                            return kv.Value;
                        }
                        else
                        {
                            if (createIfNotFound == true)
                                SaveAppSetting(configFilename, sectionName, key, defaultIfNotFound);
                            return defaultIfNotFound;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.GetLogger<object>().ErrorFormat("GetAppSetting error: {0}", ex.Message);
            }
            if (createIfNotFound == true)
                SaveAppSetting(configFilename, sectionName, key, defaultIfNotFound);
            return defaultIfNotFound;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets application setting. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="configFilename">       Filename of the configuration file. </param>
        /// <param name="sectionName">          Name of the section. </param>
        /// <param name="key">                  The key. </param>
        /// <param name="defaultIfNotFound">    True to default if not found. </param>
        /// <param name="createIfNotFound">     True to create if not found. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static int GetAppSetting(string configFilename, string sectionName, string key, int defaultIfNotFound, Boolean createIfNotFound)
        {
            try
            {
                if (string.IsNullOrEmpty(configFilename))
                    configFilename = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
                ExeConfigurationFileMap configMap = new ExeConfigurationFileMap();
                configMap.ExeConfigFilename = configFilename;
                Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
                if (config != null)
                {
                    if (string.IsNullOrEmpty(sectionName))
                        sectionName = "appSettings";


                    AppSettingsSection appSettingsSection =
                      (AppSettingsSection)config.GetSection(sectionName);

                    if (appSettingsSection != null)
                    {
                        KeyValueConfigurationElement kv = appSettingsSection.Settings[key];
                        if (kv != null)
                        {
                            int returnValue;
                            if (int.TryParse(kv.Value, out returnValue) == true)
                                return returnValue;
                            else
                            {
                                if (createIfNotFound == true)
                                    SaveAppSetting(configFilename, sectionName, key, defaultIfNotFound.ToString());
                                return defaultIfNotFound;
                            }
                        }
                        else
                        {
                            if (createIfNotFound == true)
                                SaveAppSetting(configFilename, sectionName, key, defaultIfNotFound.ToString());
                            return defaultIfNotFound;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.GetLogger<object>().ErrorFormat("GetAppSetting error: {0}", ex.Message);
            }
            if (createIfNotFound == true)
                SaveAppSetting(configFilename, sectionName, key, defaultIfNotFound.ToString());
            return defaultIfNotFound;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets application setting. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="configFilename">       Filename of the configuration file. </param>
        /// <param name="sectionName">          Name of the section. </param>
        /// <param name="key">                  The key. </param>
        /// <param name="defaultIfNotFound">    True to default if not found. </param>
        /// <param name="createIfNotFound">     True to create if not found. </param>
        ///
        /// <returns>   True if it succeeds, false if it fails. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static bool GetAppSetting(string configFilename, string sectionName, string key, bool defaultIfNotFound, Boolean createIfNotFound)
        {
            try
            {
                if (string.IsNullOrEmpty(configFilename))
                    configFilename = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
                ExeConfigurationFileMap configMap = new ExeConfigurationFileMap();
                configMap.ExeConfigFilename = configFilename;
                Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configMap, ConfigurationUserLevel.None);
                if (config != null)
                {
                    if (string.IsNullOrEmpty(sectionName))
                        sectionName = "appSettings";


                    AppSettingsSection appSettingsSection =
                      (AppSettingsSection)config.GetSection(sectionName);

                    if (appSettingsSection != null)
                    {
                        KeyValueConfigurationElement kv = appSettingsSection.Settings[key];
                        if (kv != null)
                        {
                            bool returnValue;
                            if (bool.TryParse(kv.Value, out returnValue) == true)
                                return returnValue;
                            else
                            {
                                if (createIfNotFound == true)
                                    SaveAppSetting(configFilename, sectionName, key, defaultIfNotFound.ToString());
                                return defaultIfNotFound;
                            }
                        }
                        else
                        {
                            if (createIfNotFound == true)
                                SaveAppSetting(configFilename, sectionName, key, defaultIfNotFound.ToString());
                            return defaultIfNotFound;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.GetLogger<object>().ErrorFormat("GetAppSetting error: {0}", ex.Message);
            }
            if (createIfNotFound == true)
                SaveAppSetting(configFilename, sectionName, key, defaultIfNotFound.ToString());
            return defaultIfNotFound;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Protect connection string. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="configFilename">   Filename of the configuration file. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void ProtectConnectionString(string configFilename)
        {
            ToggleConnectionStringProtection(configFilename, true);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Unprotect connection string. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="configFilename">   Filename of the configuration file. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void UnprotectConnectionString(string configFilename)
        {
            ToggleConnectionStringProtection(configFilename, false);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Toggle connection string protection. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="configFilename">   Filename of the configuration file. </param>
        /// <param name="protect">          True to protect. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private static void ToggleConnectionStringProtection(string configFilename, bool protect)
        {
            ToggleSectionProtection(configFilename, "connectionStrings", protect);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Protect section. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="configFilename">   Filename of the configuration file. </param>
        /// <param name="section">          The section. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void ProtectSection(string configFilename, string section)
        {
            ToggleSectionProtection(configFilename, section, true);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Unprotect section. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="configFilename">   Filename of the configuration file. </param>
        /// <param name="section">          The section. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void UnprotectSection(string configFilename, string section)
        {
            ToggleSectionProtection(configFilename, section, false);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Toggle section protection. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        ///
        /// <param name="configFilename">   Filename of the configuration file. </param>
        /// <param name="section">          The section. </param>
        /// <param name="protect">          True to protect. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private static void ToggleSectionProtection(string configFilename, string section, bool protect)
        {
            // Define the Dpapi provider name.
            string strProvider = "DataProtectionConfigurationProvider";
            // string strProvider = "RSAProtectedConfigurationProvider";


            try
            {
                // Open the configuration file and retrieve the section section.

                // For Web!
                // oConfiguration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");

                // For Windows!
                // Takes the executable file name without the config extension.
                if (string.IsNullOrEmpty(configFilename))
                {
                    configFilename = GCS.Framework.Utilities.SystemUtilities.EntryAssemblyPath;
                    //pathName = path + ".config";
                }

                var oConfiguration = System.Configuration.ConfigurationManager.OpenExeConfiguration(configFilename);
                if (oConfiguration != null)
                {
                    bool blnChanged = false;
                    var oSection = oConfiguration.GetSection(section);

                    if (oSection != null)
                    {
                        if ((!(oSection.ElementInformation.IsLocked)) && (!(oSection.SectionInformation.IsLocked)))
                        {
                            if (protect)
                            {
                                if (!(oSection.SectionInformation.IsProtected))
                                {
                                    blnChanged = true;

                                    // Encrypt the section.
                                    oSection.SectionInformation.ProtectSection(strProvider);
                                }
                            }
                            else
                            {
                                if (oSection.SectionInformation.IsProtected)
                                {
                                    blnChanged = true;

                                    // Remove encryption.
                                    oSection.SectionInformation.UnprotectSection();
                                }
                            }
                        }

                        if (blnChanged)
                        {
                            // Indicates whether the associated configuration section will be saved even if it has not been modified.
                            oSection.SectionInformation.ForceSave = true;

                            // Save the current configuration.
                            oConfiguration.Save();
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw (ex);
            }
            finally
            {
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if 'configFilename' is section protected. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <exception cref="Exception">    Thrown when an exception error condition occurs. </exception>
        ///
        /// <param name="configFilename">   Filename of the configuration file. </param>
        /// <param name="section">          The section. </param>
        ///
        /// <returns>   True if section protected, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static bool IsSectionProtected(string configFilename, string section)
        {
            // Define the Dpapi provider name.
            string strProvider = "DataProtectionConfigurationProvider";
            // string strProvider = "RSAProtectedConfigurationProvider";


            try
            {
                // Open the configuration file and retrieve the section section.

                // For Web!
                // oConfiguration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");

                // For Windows!
                // Takes the executable file name without the config extension.
                if (string.IsNullOrEmpty(configFilename))
                {
                    configFilename = GCS.Framework.Utilities.SystemUtilities.EntryAssemblyPath;
                    //pathName = path + ".config";
                }

                var oConfiguration = System.Configuration.ConfigurationManager.OpenExeConfiguration(configFilename);

                if (oConfiguration != null)
                {
                    bool blnChanged = false;
                    var oSection = oConfiguration.GetSection(section);

                    if (oSection != null)
                    {
                        return oSection.SectionInformation.IsProtected;
                    }
                }
            }
            catch (System.Exception ex)
            {
                throw (ex);
            }
            finally
            {
            }
            return false;

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Query if 'configFilename' is connection strings section protected. </summary>
        ///
        /// <remarks>   Kevin, 12/26/2018. </remarks>
        ///
        /// <param name="configFilename">   Filename of the configuration file. </param>
        ///
        /// <returns>   True if connection strings section protected, false if not. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static bool IsConnectionStringsSectionProtected(string configFilename)
        {
            return IsSectionProtected(configFilename, "connectionStrings");
        }


    }

}

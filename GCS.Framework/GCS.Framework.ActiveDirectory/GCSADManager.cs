using System;
using System.Collections;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Net;
using System.Security.Permissions;
using System.Text;
using System.DirectoryServices.Protocols;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.ObjectModel;
using DirectorySynchronizationOptions = System.DirectoryServices.Protocols.DirectorySynchronizationOptions;
using SearchScope = System.DirectoryServices.Protocols.SearchScope;
using System.Windows.Navigation;

namespace GCS.Framework.ActiveDirectory
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Manager for gcsads. </summary>
    ///
    /// <remarks>   Kevin, 6/10/2014. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class GCSADManager
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Values that represent LookForUserDataType. </summary>
        ///
        /// <remarks>   Kevin, 6/10/2014. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public enum LookForUserDataType { AllUsers, ChangesOnly, DeletedUsers }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A read active directory user data parameters. </summary>
        ///
        /// <remarks>   Kevin, 6/10/2014. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public class ReadActiveDirectoryUserDataParameters
        {

            public ReadActiveDirectoryUserDataParameters()
            {
                OrganizationalUnits = new List<string>();
                UserAttributesToRead = new List<string>();
                FilterMembersOfGroup = new List<GCSADGroup>();
            }
            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>   Gets or sets the what to look for. </summary>
            ///
            /// <value> The what to look for. </value>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

            public LookForUserDataType WhatToLookFor { get; set; }

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>
            /// Gets or sets a value indicating whether the group membership should be included.
            /// </summary>
            ///
            /// <value> true if include group membership, false if not. </value>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

            public bool IncludeGroupMembership { get; set; }

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>
            /// Gets or sets a value indicating whether the primary group should be included.
            /// </summary>
            ///
            /// <value> true if include primary group, false if not. </value>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

            public bool IncludePrimaryGroup { get; set; }

            public string ServerName { get; set; }

            public List<string> OrganizationalUnits { get; internal set; }

            public List<GCSADGroup> FilterMembersOfGroup { get; internal set; }

            public List<string> UserAttributesToRead { get; set; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Reads active directory user data. </summary>
        ///
        /// <remarks>   Kevin, 6/10/2014. </remarks>
        ///
        /// <param name="parameters">           Options for controlling the operation. </param>
        /// <param name="strCookiesFilename">   Filename of the cookies file. </param>
        /// <param name="bSaveCookie">          true to save cookie. </param>
        /// <param name="cookie">               [out] The cookie. </param>
        ///
        /// <returns>   The active directory user data. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static ReadOnlyCollection<GCSADUser> ReadActiveDirectoryUserData(ReadActiveDirectoryUserDataParameters parameters, string strCookiesFilename, bool bSaveCookie, out byte[] cookie)
        {
            List<GCSADUser> users = new List<GCSADUser>();

            Dictionary<int, string> groupNames = new Dictionary<int, string>();

            //Deserialize the cookie from a file if exists
            BinaryFormatter bFormat = new BinaryFormatter();
            if (strCookiesFilename == string.Empty)
                strCookiesFilename = "cookie.bin";

            cookie = null;
            //byte[] cookie = null;
            if (parameters.WhatToLookFor == LookForUserDataType.ChangesOnly || parameters.WhatToLookFor == LookForUserDataType.DeletedUsers)
            {
                if (File.Exists(strCookiesFilename))
                {
                    using (FileStream fsStream = new FileStream(strCookiesFilename, FileMode.OpenOrCreate))
                    {
                        cookie = (byte[])bFormat.Deserialize(fsStream);
                    }
                }
            }

            string str_dcName = System.DirectoryServices.ActiveDirectory.Domain.GetCurrentDomain().FindDomainController().Name;
            string path = "LDAP://rootDSE";

            System.DirectoryServices.DirectoryEntry rootDSE = new System.DirectoryServices.DirectoryEntry(path);
            LdapConnection connection = new LdapConnection(str_dcName);

            string sFilter = string.Empty;
            if (parameters.WhatToLookFor != LookForUserDataType.DeletedUsers)
            {
                sFilter = string.Format("(&(objectCategory=person)(objectClass=user)(displayName=*)(sn=*)");
                //sFilter = string.Format("(sAMAccountType=805306368)");
                if (parameters.FilterMembersOfGroup.Count > 0)
                {
                    sFilter += string.Format("(|(");
                    foreach (GCSADGroup group in parameters.FilterMembersOfGroup)
                    {
                        if (string.IsNullOrEmpty(group.DistinguishedName) == false)
                        {
                            sFilter += string.Format("(memberOf={0})", group.DistinguishedName);
                        }
                    }
                    sFilter += string.Format("))");
                }
                sFilter += string.Format(")");
            }
            else
            {
                sFilter = String.Format("(&(isDeleted=TRUE)(objectclass=user))");
            }

            //string dn = string.Format("OU=Technical,OU=Walkersville,OU=Locations,{0}", rootDSE.Properties["defaultNamingContext"].Value.ToString());
            //string dn = string.Format("OU=Locations,{0}", rootDSE.Properties["defaultNamingContext"].Value.ToString());
            string dn = string.Format("{0}", rootDSE.Properties["defaultNamingContext"].Value.ToString());
            // TODO:  Change null to parameter list to restrict the properties to be returned
            SearchRequest request = new SearchRequest(dn, sFilter, SearchScope.Subtree, null);
            DirSyncRequestControl dirSyncRC = new DirSyncRequestControl(cookie, DirectorySynchronizationOptions.IncrementalValues, Int32.MaxValue);
            request.Controls.Add(dirSyncRC);

            System.Diagnostics.Trace.WriteLine(string.Format("Generating AD request: dn:{0}: filter:{1}", dn, sFilter));

            connection.Timeout = new TimeSpan(0, 0, 60, 0);
            bool bMoreData = true;
            SearchResponse searchResponse = (SearchResponse)connection.SendRequest(request);

            System.Diagnostics.Trace.WriteLine(string.Format("connection.SendRequest finished"));

            while (bMoreData) //Initial Search handler - since we're unable to combine with paged search
            {
                foreach (SearchResultEntry entry in searchResponse.Entries)
                {
                    //System.Diagnostics.Trace.WriteLine(string.Format("******************************************"));
                    //System.Diagnostics.Trace.WriteLine(string.Format("{0}:{1}",
                    //     searchResponse.Entries.IndexOf(entry),
                    //     entry.DistinguishedName));
                    GCSADUser user = new GCSADUser();
                    user.DistinquishedName = entry.DistinguishedName;
                    foreach (DictionaryEntry de in entry.Attributes)
                    {
                        user.ProcessDictionaryEntry(de);
                    }

                    if (parameters.WhatToLookFor == LookForUserDataType.ChangesOnly)
                    {
                        GCSADUser fullUserData = ReadActiveDirectoryUserData(user.ObjectGUID, parameters.IncludePrimaryGroup, parameters.IncludeGroupMembership);
                        user.FullUserData = fullUserData;
                    }

                    //if (user.IsStringNullOrEmpty(user.DisplayName) == false &&
                    //    user.IsStringNullOrEmpty(user.LastName) == false)
                    //{
                    users.Add(user);
                    System.Diagnostics.Trace.WriteLine(string.Format("Adding user {0}: {1}", users.Count, user.DisplayName));
                    //}

                }

                //Get the cookie from the response to use it in next searches
                foreach (DirectoryControl control in searchResponse.Controls)
                {
                    if (control is DirSyncResponseControl)
                    {
                        DirSyncResponseControl dsrc = control as DirSyncResponseControl;
                        cookie = dsrc.Cookie;
                        bMoreData = dsrc.MoreData;
                        break;
                    }
                }
                dirSyncRC.Cookie = cookie;
                searchResponse = (SearchResponse)connection.SendRequest(request);
            }


            //Serialize the cookie into a file to use in next searches
            if (parameters.WhatToLookFor == LookForUserDataType.ChangesOnly || parameters.WhatToLookFor == LookForUserDataType.DeletedUsers)
            {
                if (bSaveCookie == true)
                {
                    SaveCookieFile(strCookiesFilename, ref cookie);
                }
            }


            int numberOfUsers = users.Count;
            int cnt = 0;
            /////////////////////////////////////////
            if (parameters.WhatToLookFor != LookForUserDataType.DeletedUsers && parameters.IncludePrimaryGroup == true)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("Adding primary groups"));
                foreach (GCSADUser user in users)
                {
                    cnt++;
                    Int32 primaryGroupId = 0;
                    if (user.PrimaryGroupId == string.Empty)
                    {
                        if (user.FullUserData != null)
                        {
                            if (user.FullUserData.PrimaryGroupId != user.PrimaryGroupId)
                            {
                                user.PrimaryGroupId = user.FullUserData.PrimaryGroupId;
                                user.PrimaryGroupName = user.FullUserData.PrimaryGroupName;
                            }
                        }
                    }

                    if (Int32.TryParse(user.PrimaryGroupId, out primaryGroupId) == true)
                    {
                        byte[] objectsid = (byte[])user.GetPropertyValue("objectsid");
                        if (objectsid != null)
                        {
                            string groupName = string.Empty;
                            if (groupNames.TryGetValue(primaryGroupId, out groupName))
                                user.PrimaryGroupName = groupName;
                            else
                            {
                                int startingTicks = Environment.TickCount;
                                List<string> groups = GetPrimaryGroup(primaryGroupId, objectsid, ref rootDSE, ref connection);
                                int totalTicks = Environment.TickCount - startingTicks;
                                System.Diagnostics.Trace.WriteLine(string.Format("GetPrimaryGroup ticks:{0}", totalTicks));

                                if (groups != null)
                                {
                                    if (groups.Count != 0)
                                    {
                                        user.PrimaryGroupName = groups[0];
                                        groupNames.Add(primaryGroupId, groups[0]);
                                    }
                                }
                            }
                        }
                    }
                    System.Diagnostics.Trace.WriteLine(string.Format("{0} of {1}: User: {2}, Primary Group: {3}", cnt, numberOfUsers, user.DisplayName, user.PrimaryGroupName));
                    //                   System.Diagnostics.Trace.WriteLine(string.Format("****************** Primary Group Membership: {0}, Primary Group:{1}", user.DisplayName, user.PrimaryGroupName));
                }
            }

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (parameters.WhatToLookFor != LookForUserDataType.DeletedUsers && parameters.IncludeGroupMembership == true)
            {
                foreach (GCSADUser user in users)
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("******************************************"));
                    System.Diagnostics.Trace.WriteLine(string.Format("Group Membership: {0}", user.DistinquishedName));

                    string sGroupMembershipFilter = String.Format("(&(objectcategory=group)(member={0}))", user.DistinquishedName);

                    SearchRequest groupMembershipRequest = new SearchRequest(rootDSE.Properties["defaultNamingContext"].Value.ToString(), sGroupMembershipFilter, SearchScope.Subtree, null);
                    DirSyncRequestControl dirSyncGroupRequestRC = new DirSyncRequestControl(null, DirectorySynchronizationOptions.PublicDataOnly, Int32.MaxValue);
                    groupMembershipRequest.Controls.Add(dirSyncGroupRequestRC);

                    SearchResponse searchGroupMembershipResponse = (SearchResponse)connection.SendRequest(groupMembershipRequest);

                    foreach (SearchResultEntry entry in searchGroupMembershipResponse.Entries)
                    {
                        System.Diagnostics.Trace.WriteLine(string.Format("{0}:{1}",
                             searchResponse.Entries.IndexOf(entry),
                             entry.DistinguishedName));

                        foreach (DictionaryEntry de in entry.Attributes)
                        {
                            if (de.Key.ToString().ToLower() == "name")
                            {
                                Type t = de.Value.GetType();
                                DirectoryAttribute da = (DirectoryAttribute)de.Value;
                                object[] strValues = da.GetValues(typeof(String));
                                if (strValues != null)
                                {
                                    foreach (object s in strValues)
                                    {
                                        //                                       System.Diagnostics.Trace.WriteLine(string.Format("{0}:{1}", de.Key, s));
                                        if (s != null)
                                        {
                                            string[] values = ((string)s).Split('\n');
                                            foreach (string s1 in values)
                                                user.AddGroupMembership(s1);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return new ReadOnlyCollection<GCSADUser>(users);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Reads active directory group data. </summary>
        ///
        /// <remarks>   Kevin, 6/10/2014. </remarks>
        ///
        /// <param name="strCookiesFilename">   Filename of the cookies file. </param>
        ///
        /// <returns>   The active directory group data. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static ReadOnlyCollection<GCSADGroup> ReadActiveDirectoryGroupData(string strCookiesFilename)
        {
            List<GCSADGroup> groups = new List<GCSADGroup>();

            //Deserialize the cookie from a file if exists
            BinaryFormatter bFormat = new BinaryFormatter();
            byte[] cookie = null;
            if (strCookiesFilename != string.Empty)
            {
                if (File.Exists(strCookiesFilename))
                {
                    using (FileStream fsStream = new FileStream(strCookiesFilename, FileMode.OpenOrCreate))
                    {
                        cookie = (byte[])bFormat.Deserialize(fsStream);
                    }
                }
            }

            string str_dcName = System.DirectoryServices.ActiveDirectory.Domain.GetCurrentDomain().FindDomainController().Name;
            System.DirectoryServices.DirectoryEntry rootDSE = new System.DirectoryServices.DirectoryEntry("LDAP://rootDSE");
            LdapConnection connection = new LdapConnection(str_dcName);

            string sFilter = String.Format("(&(objectcategory=group))");

            SearchRequest request = new SearchRequest(rootDSE.Properties["defaultNamingContext"].Value.ToString(), sFilter, SearchScope.Subtree, null);
            DirSyncRequestControl dirSyncRC = new DirSyncRequestControl(cookie, DirectorySynchronizationOptions.IncrementalValues, Int32.MaxValue);
            request.Controls.Add(dirSyncRC);

            bool bMoreData = true;
            SearchResponse searchResponse = (SearchResponse)connection.SendRequest(request);

            while (bMoreData) //Initial Search handler - since we're unable to combine with paged search
            {
                foreach (SearchResultEntry entry in searchResponse.Entries)
                {
                    //System.Diagnostics.Trace.WriteLine(string.Format("******************************************"));
                    //System.Diagnostics.Trace.WriteLine(string.Format("{0}:{1}",
                    //     searchResponse.Entries.IndexOf(entry),
                    //     entry.DistinguishedName));

                    GCSADGroup group = new GCSADGroup();
                    group.DistinguishedName = entry.DistinguishedName;
                    foreach (DictionaryEntry de in entry.Attributes)
                    {
                        group.ProcessDictionaryEntry(de);
                    }

                    groups.Add(group);
                }

                //Get the cookie from the response to use it in next searches


                foreach (DirectoryControl control in searchResponse.Controls)
                {
                    if (control is DirSyncResponseControl)
                    {
                        DirSyncResponseControl dsrc = control as DirSyncResponseControl;
                        cookie = dsrc.Cookie;
                        bMoreData = dsrc.MoreData;
                        break;
                    }
                }
                dirSyncRC.Cookie = cookie;
                searchResponse = (SearchResponse)connection.SendRequest(request);
            }


            if (strCookiesFilename != string.Empty)
            {
                using (FileStream fsStream = new FileStream(strCookiesFilename, FileMode.Create))
                {
                    //Serialize the data to the steam. To get the data for 
                    //the cookie, call the GetDirectorySynchronizationCookie method.
                    bFormat.Serialize(fsStream, cookie);
                }
            }


            return new ReadOnlyCollection<GCSADGroup>(groups);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Saves a cookie file. </summary>
        ///
        /// <remarks>   Kevin, 6/10/2014. </remarks>
        ///
        /// <param name="strFilename">  Filename of the file. </param>
        /// <param name="cookieData">   [in,out] Information describing the cookie. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static void SaveCookieFile(string strFilename, ref byte[] cookieData)
        {
            using (FileStream fsStream = new FileStream(strFilename, FileMode.Create))
            {
                BinaryFormatter bFormat = new BinaryFormatter();
                //Serialize the data to the steam. To get the data for 
                //the cookie, call the GetDirectorySynchronizationCookie method.
                bFormat.Serialize(fsStream, cookieData);
            }

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets primary group. </summary>
        ///
        /// <remarks>   Kevin, 6/10/2014. </remarks>
        ///
        /// <param name="primaryGroupId">   Identifier for the primary group. </param>
        /// <param name="objectSid">        The object SID. </param>
        /// <param name="rootDSE">          [in,out] The root dse. </param>
        /// <param name="connection">       [in,out] The connection. </param>
        ///
        /// <returns>   The primary group. </returns>
        private static List<string> GetPrimaryGroup(int primaryGroupId, byte[] objectSid, ref System.DirectoryServices.DirectoryEntry rootDSE, ref LdapConnection connection)
        {
            List<string> retArray = new List<string>();
            // Copy over everything but the last four bytes(sub-authority)
            // Doing so gives us the RID of the domain

            if (objectSid != null)
            {
                byte[] sidBytes = CreatePrimaryGroupSID(objectSid, primaryGroupId);
                string adsPath = String.Format("LDAP://<SID={0}>", BuildOctetString(sidBytes));
                DirectoryEntry primaryGroup = new DirectoryEntry(adsPath, null, null, AuthenticationTypes.Secure);
                //we now have our primary group 
                using (primaryGroup)
                {
                    retArray.Add(primaryGroup.Properties["name"].Value.ToString());
                }


            }
            return retArray;

        }
        private static List<string> GetPrimaryGroup(int primaryGroupId, byte[] objectSid, ref System.DirectoryServices.DirectoryEntry rootDSE)
        {
            List<string> retArray = new List<string>();
            // Copy over everything but the last four bytes(sub-authority)
            // Doing so gives us the RID of the domain

            if (objectSid != null)
            {
                byte[] sidBytes = CreatePrimaryGroupSID(objectSid, primaryGroupId);
                string adsPath = String.Format("LDAP://<SID={0}>", BuildOctetString(sidBytes));
                DirectoryEntry primaryGroup = new DirectoryEntry(adsPath, null, null, AuthenticationTypes.Secure);
                //we now have our primary group 
                using (primaryGroup)
                {
                    retArray.Add(primaryGroup.Properties["name"].Value.ToString());
                }


            }
            return retArray;

        }

        private static byte[] CreatePrimaryGroupSID(byte[] userSid, int primaryGroupID)
        {
            //convert the int into a byte array     
            byte[] rid = BitConverter.GetBytes(primaryGroupID);
            //place the bytes into the user's SID byte array     
            // //overwriting them as necessary

            for (int i = 0; i < rid.Length; i++)
            {
                userSid.SetValue(rid[i], new long[] { userSid.Length - (rid.Length - i) });
            }
            return userSid;
        }

        private static string BuildOctetString(byte[] bytes)
        {
            StringBuilder sb = new StringBuilder(); for (int i = 0; i < bytes.Length; i++)

            { sb.Append(bytes[i].ToString("X2")); }
            return sb.ToString();
        }


        /// <summary>   Convert unique identifier to LDAP format. </summary>
        ///
        /// <remarks>   Kevin, 6/10/2014. </remarks>
        ///
        /// <param name="objectGuid">   Unique identifier for the object. </param>
        ///
        /// <returns>   The unique converted identifier to LDAP format. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private static string ConvertGUIDToLDAPFormat(Guid objectGuid)
        {
            StringBuilder result = new StringBuilder();
            byte[] bytes = objectGuid.ToByteArray();
            for (int i = 0; i < bytes.Length; i++)
            {
                String transformed = string.Format("{0:X2}", ((int)bytes[i] & 0xFF));

                result.Append("\\");
                result.Append(transformed);
            }


            return result.ToString();

        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Reads active directory user data. </summary>
        ///
        /// <remarks>   Kevin, 6/10/2014. </remarks>
        ///
        /// <param name="objectGuid">               Unique identifier for the object. </param>
        /// <param name="bIncludePrimaryGroup">     true to include, false to exclude the primary group. </param>
        /// <param name="bIncludeGroupMembership">  true to include, false to exclude the group
        ///                                         membership. </param>
        ///
        /// <returns>   The active directory user data. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static GCSADUser ReadActiveDirectoryUserData(Guid objectGuid, bool bIncludePrimaryGroup, bool bIncludeGroupMembership)
        {

            //var user = new DirectoryEntry("LDAP://<GUID=119d0d80-699d-4e81-8e4e-5477e22ac1b3>");
            GCSADUser user = new GCSADUser();

            string str_dcName = System.DirectoryServices.ActiveDirectory.Domain.GetCurrentDomain().FindDomainController().Name;
            System.DirectoryServices.DirectoryEntry rootDSE = new System.DirectoryServices.DirectoryEntry("LDAP://rootDSE");
            LdapConnection connection = new LdapConnection(str_dcName);

            string sFilter = String.Format("(&(objectcategory=person)(objectclass=user)(objectGUID={0}))", ConvertGUIDToLDAPFormat(objectGuid));

            SearchRequest request = new SearchRequest(rootDSE.Properties["defaultNamingContext"].Value.ToString(), sFilter, SearchScope.Subtree, null);
            DirSyncRequestControl dirSyncRC = new DirSyncRequestControl(null, DirectorySynchronizationOptions.IncrementalValues, Int32.MaxValue);
            request.Controls.Add(dirSyncRC);

            bool bMoreData = true;
            SearchResponse searchResponse = (SearchResponse)connection.SendRequest(request);
            byte[] cookie = null;

            while (bMoreData) //Initial Search handler - since we're unable to combine with paged search
            {
                foreach (SearchResultEntry entry in searchResponse.Entries)
                {
                    //System.Diagnostics.Trace.WriteLine(string.Format("******************************************"));
                    //System.Diagnostics.Trace.WriteLine(string.Format("{0}:{1}",
                    //     searchResponse.Entries.IndexOf(entry),
                    //     entry.DistinguishedName));

                    user.DistinquishedName = entry.DistinguishedName;
                    foreach (DictionaryEntry de in entry.Attributes)
                    {
                        user.ProcessDictionaryEntry(de);
                    }
                }

                //Get the cookie from the response to use it in next searches
                foreach (DirectoryControl control in searchResponse.Controls)
                {
                    if (control is DirSyncResponseControl)
                    {
                        DirSyncResponseControl dsrc = control as DirSyncResponseControl;
                        cookie = dsrc.Cookie;
                        bMoreData = dsrc.MoreData;
                        break;
                    }
                }
                dirSyncRC.Cookie = cookie;
                searchResponse = (SearchResponse)connection.SendRequest(request);
            }

            /////////////////////////////////////////
            if (bIncludePrimaryGroup == true)
            {
                Int32 primaryGroupId;
                if (Int32.TryParse(user.PrimaryGroupId, out primaryGroupId) == true)
                {
                    List<string> groups = GetPrimaryGroup(primaryGroupId, (byte[])user.GetPropertyValue("objectsid"), ref rootDSE, ref connection);
                    if (groups != null)
                        if (groups.Count != 0)
                            user.PrimaryGroupName = groups[0];
                }
                //                System.Diagnostics.Trace.WriteLine(string.Format("****************** Primary Group Membership: {0}, Primary Group:{1}", user.DisplayName, user.PrimaryGroupName));
            }

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (bIncludeGroupMembership == true)
            {
                //System.Diagnostics.Trace.WriteLine(string.Format("******************************************"));
                //System.Diagnostics.Trace.WriteLine(string.Format("Group Membership: {0}", user.DistinquishedName));

                string sGroupMembershipFilter = String.Format("(&(objectcategory=group)(member={0}))", user.DistinquishedName);

                SearchRequest groupMembershipRequest = new SearchRequest(rootDSE.Properties["defaultNamingContext"].Value.ToString(), sGroupMembershipFilter, SearchScope.Subtree, null);
                DirSyncRequestControl dirSyncGroupRequestRC = new DirSyncRequestControl(null, DirectorySynchronizationOptions.PublicDataOnly, Int32.MaxValue);
                groupMembershipRequest.Controls.Add(dirSyncGroupRequestRC);

                SearchResponse searchGroupMembershipResponse = (SearchResponse)connection.SendRequest(groupMembershipRequest);

                foreach (SearchResultEntry entry in searchGroupMembershipResponse.Entries)
                {
                    //System.Diagnostics.Trace.WriteLine(string.Format("{0}:{1}",
                    //     searchResponse.Entries.IndexOf(entry),
                    //     entry.DistinguishedName));

                    foreach (DictionaryEntry de in entry.Attributes)
                    {
                        if (de.Key.ToString().ToLower() == "name")
                        {
                            Type t = de.Value.GetType();
                            DirectoryAttribute da = (DirectoryAttribute)de.Value;
                            object[] strValues = da.GetValues(typeof(String));
                            if (strValues != null)
                            {
                                foreach (object s in strValues)
                                {
                                    //                                   System.Diagnostics.Trace.WriteLine(string.Format("{0}:{1}", de.Key, s));
                                    if (s != null)
                                    {
                                        string[] values = ((string)s).Split('\n');
                                        foreach (string s1 in values)
                                            user.AddGroupMembership(s1);
                                    }
                                }
                            }
                        }
                    }
                }
            }


            return user;
        }


        public static string[] GetGroupsForUser(string userName)
        {
            string str_dcName = System.DirectoryServices.ActiveDirectory.Domain.GetCurrentDomain().FindDomainController().Name;
            System.DirectoryServices.DirectoryEntry rootDSE = new System.DirectoryServices.DirectoryEntry("LDAP://rootDSE");
            LdapConnection connection = new LdapConnection(str_dcName);

            var groups = new System.Collections.Generic.List<string>();
            string sGroupMembershipFilter = String.Format("(&(objectcategory=group)(member={0}))", userName);

            SearchRequest groupMembershipRequest = new SearchRequest(rootDSE.Properties["defaultNamingContext"].Value.ToString(), sGroupMembershipFilter, SearchScope.Subtree, null);
            DirSyncRequestControl dirSyncGroupRequestRC = new DirSyncRequestControl(null, DirectorySynchronizationOptions.PublicDataOnly, Int32.MaxValue);
            groupMembershipRequest.Controls.Add(dirSyncGroupRequestRC);

            SearchResponse searchGroupMembershipResponse = (SearchResponse)connection.SendRequest(groupMembershipRequest);

            foreach (SearchResultEntry entry in searchGroupMembershipResponse.Entries)
            {
                //System.Diagnostics.Trace.WriteLine(string.Format("{0}:{1}",
                //     searchResponse.Entries.IndexOf(entry),
                //     entry.DistinguishedName));

                foreach (DictionaryEntry de in entry.Attributes)
                {
                    if (de.Key.ToString().ToLower() == "name")
                    {
                        Type t = de.Value.GetType();
                        DirectoryAttribute da = (DirectoryAttribute)de.Value;
                        object[] strValues = da.GetValues(typeof(String));
                        if (strValues != null)
                        {
                            foreach (object s in strValues)
                            {
                                //                                   System.Diagnostics.Trace.WriteLine(string.Format("{0}:{1}", de.Key, s));
                                if (s != null)
                                {
                                    string[] values = ((string)s).Split('\n');
                                    foreach (string s1 in values)
                                        groups.Add(s1);
                                }
                            }
                        }
                    }
                }
            }
            return groups.ToArray();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets a d users. </summary>
        ///
        /// <remarks>   Kevin, 6/10/2014. </remarks>
        ///
        /// <returns>   a d users. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static ReadOnlyCollection<GCSADUser> GetADUsers(ReadActiveDirectoryUserDataParameters parameters, string strCookiesFilename, bool bSaveCookie, out byte[] cookie)
        {
            List<GCSADUser> users = new List<GCSADUser>();

            Dictionary<int, string> groupNames = new Dictionary<int, string>();

            //Deserialize the cookie from a file if exists
            BinaryFormatter bFormat = new BinaryFormatter();
            if (strCookiesFilename == string.Empty)
                strCookiesFilename = "cookie.bin";

            cookie = null;

            DirectoryEntry rootDSE = new DirectoryEntry("LDAP://RootDSE");
            string defaultNamingContext = rootDSE.Properties["defaultNamingContext"].Value.ToString();

            string DomainPath = string.Format("LDAP://{0}", defaultNamingContext);
            System.DirectoryServices.DirectoryEntry searchRoot = new System.DirectoryServices.DirectoryEntry(DomainPath);
            System.DirectoryServices.DirectorySearcher search = new System.DirectoryServices.DirectorySearcher(searchRoot);
            search.Filter = "(&(objectClass=user)(objectCategory=person))";
            if (parameters.WhatToLookFor == LookForUserDataType.ChangesOnly || parameters.WhatToLookFor == LookForUserDataType.DeletedUsers)
            {
                if (File.Exists(strCookiesFilename))
                {
                    using (FileStream fsStream = new FileStream(strCookiesFilename, FileMode.OpenOrCreate))
                    {
                        cookie = (byte[])bFormat.Deserialize(fsStream);
                    }
                }

                search.DirectorySynchronization = new DirectorySynchronization(
                        System.DirectoryServices.DirectorySynchronizationOptions.None,
                        cookie);
            }

            if (parameters.WhatToLookFor != LookForUserDataType.DeletedUsers)
            {
                search.Filter = string.Format("(&(objectCategory=person)(objectClass=user)(displayName=*)(sn=*)");
                //sFilter = string.Format("(sAMAccountType=805306368)");
                if (parameters.FilterMembersOfGroup.Count > 0)
                {
                    search.Filter += string.Format("(|(");
                    foreach (GCSADGroup group in parameters.FilterMembersOfGroup)
                    {
                        if (string.IsNullOrEmpty(group.DistinguishedName) == false)
                        {
                            search.Filter += string.Format("(memberOf={0})", group.DistinguishedName);
                        }
                    }
                    search.Filter += string.Format("))");
                }
                search.Filter += string.Format(")");
            }
            else
            {
                search.Filter = String.Format("(&(isDeleted=TRUE)(objectclass=user))");
                search.Tombstone = true;
            }

            System.DirectoryServices.SearchResult result;
            System.DirectoryServices.SearchResultCollection resultCol = search.FindAll();
            if (resultCol != null)
            {
                foreach (SearchResult res in resultCol)
                {
                    GCSADUser user = new GCSADUser();
                    if (parameters.WhatToLookFor != LookForUserDataType.DeletedUsers)
                    {
                        DirectoryEntry entry = res.GetDirectoryEntry();
                        user.ProcessDirectoryEntry(entry);

                        if (parameters.WhatToLookFor == LookForUserDataType.ChangesOnly)
                        {
                            GCSADUser fullUserData = ReadActiveDirectoryUserData(user.ObjectGUID,
                                parameters.IncludePrimaryGroup, parameters.IncludeGroupMembership);
                            user.FullUserData = fullUserData;
                        }
                    }
                    else
                    {
                        user.ProcessSearchResult(res);
                    }
                    users.Add(user);
                }

                //for (int counter = 0; counter < resultCol.Count; counter++)
                //{
                //    result = resultCol[counter];
                //    GCSADUser user = new GCSADUser();

                //    DirectoryEntry entry = result.GetDirectoryEntry();
                //    user.ProcessDirectoryEntry(entry);

                //    if (parameters.WhatToLookFor == LookForUserDataType.ChangesOnly)
                //    {
                //        GCSADUser fullUserData = ReadActiveDirectoryUserData(user.ObjectGUID, parameters.IncludePrimaryGroup, parameters.IncludeGroupMembership);
                //        user.FullUserData = fullUserData;
                //    }

                //    users.Add(user);
                //}
            }

            //Serialize the cookie into a file to use in next searches
            if (parameters.WhatToLookFor == LookForUserDataType.ChangesOnly || parameters.WhatToLookFor == LookForUserDataType.DeletedUsers)
            {
                if (bSaveCookie == true && search.DirectorySynchronization != null)
                {
                    cookie = search.DirectorySynchronization.GetDirectorySynchronizationCookie();
                    SaveCookieFile(strCookiesFilename, ref cookie);
                }
            }

            int numberOfUsers = users.Count;
            int cnt = 0;
            /////////////////////////////////////////
            if (parameters.WhatToLookFor != LookForUserDataType.DeletedUsers && parameters.IncludePrimaryGroup == true)
            {
                System.Diagnostics.Trace.WriteLine(string.Format("Adding primary groups"));
                foreach (GCSADUser user in users)
                {
                    cnt++;
                    Int32 primaryGroupId = 0;
                    if (user.PrimaryGroupId == string.Empty)
                    {
                        if (user.FullUserData != null)
                        {
                            if (user.FullUserData.PrimaryGroupId != user.PrimaryGroupId)
                            {
                                user.PrimaryGroupId = user.FullUserData.PrimaryGroupId;
                                user.PrimaryGroupName = user.FullUserData.PrimaryGroupName;
                            }
                        }
                    }

                    if (Int32.TryParse(user.PrimaryGroupId, out primaryGroupId) == true)
                    {
                        byte[] objectsid = (byte[])user.ObjectSID;
                        if (user.ObjectSID != null)
                        {
                            string groupName = string.Empty;
                            if (groupNames.TryGetValue(primaryGroupId, out groupName))
                                user.PrimaryGroupName = groupName;
                            else
                            {
                                int startingTicks = Environment.TickCount;
                                List<string> groups = GetPrimaryGroup(primaryGroupId, objectsid, ref rootDSE);
                                int totalTicks = Environment.TickCount - startingTicks;
                                System.Diagnostics.Trace.WriteLine(string.Format("GetPrimaryGroup ticks:{0}", totalTicks));

                                if (groups != null)
                                {
                                    if (groups.Count != 0)
                                    {
                                        user.PrimaryGroupName = groups[0];
                                        groupNames.Add(primaryGroupId, groups[0]);
                                    }
                                }
                            }
                        }
                    }
                    System.Diagnostics.Trace.WriteLine(string.Format("{0} of {1}: User: {2}, Primary Group: {3}", cnt, numberOfUsers, user.DisplayName, user.PrimaryGroupName));
                    //                   System.Diagnostics.Trace.WriteLine(string.Format("****************** Primary Group Membership: {0}, Primary Group:{1}", user.DisplayName, user.PrimaryGroupName));
                }
            }

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (parameters.WhatToLookFor != LookForUserDataType.DeletedUsers && parameters.IncludeGroupMembership == true)
            {
                foreach (GCSADUser user in users)
                {
                    System.Diagnostics.Trace.WriteLine(string.Format("******************************************"));
                    System.Diagnostics.Trace.WriteLine(string.Format("Group Membership: {0}", user.DistinquishedName));

                    System.DirectoryServices.DirectoryEntry searchGroupRoot = new System.DirectoryServices.DirectoryEntry(DomainPath);
                    System.DirectoryServices.DirectorySearcher searchGroups = new System.DirectoryServices.DirectorySearcher(searchGroupRoot);
                    searchGroups.Filter = String.Format("(&(objectcategory=group)(member={0}))", user.DistinquishedName);

                    searchGroups.PropertiesToLoad.Add("name");
                    searchGroups.PageSize = 1000;
                    System.DirectoryServices.SearchResult resultGroups;
                    System.DirectoryServices.SearchResultCollection resultGroupsCol = searchGroups.FindAll();
                    if (resultGroupsCol != null)
                    {
                        for (int counter = 0; counter < resultGroupsCol.Count; counter++)
                        {
                            resultGroups = resultGroupsCol[counter];
                            if (resultGroups.Properties.Contains("name"))
                            {
                                string sGroupName = resultGroups.Properties["name"][0].ToString();
                                user.AddGroupMembership(sGroupName);
                                System.Diagnostics.Trace.WriteLine(string.Format("  Group Membership: {0},", sGroupName));
                            }
                        }
                    }
                }
            }

            return new ReadOnlyCollection<GCSADUser>(users);
        }

        public static List<GCSADOrganizationalUnit> GetOrganizationalUnits(string server)
        {
            List<GCSADOrganizationalUnit> organizationalUnits = new List<GCSADOrganizationalUnit>();

            try
            {
                string DomainPath = string.Empty;
                if (string.IsNullOrEmpty(server))
                {
                    DirectoryEntry rootDSE = new DirectoryEntry("LDAP://RootDSE");
                    string defaultNamingContext = rootDSE.Properties["defaultNamingContext"].Value.ToString();

                    DomainPath = string.Format("LDAP://{0}", defaultNamingContext);

                }
                else
                {
                    DomainPath = string.Format("LDAP://{0}", server);
                }
                List<GCSADUser> lstADUsers = new List<GCSADUser>();
                System.DirectoryServices.DirectoryEntry searchRoot = new System.DirectoryServices.DirectoryEntry(DomainPath);
                System.DirectoryServices.DirectorySearcher search = new System.DirectoryServices.DirectorySearcher(searchRoot);
                search.Filter = "(objectCategory=organizationalUnit)";
                search.PropertiesToLoad.Add("objectguid");
                search.PropertiesToLoad.Add("name");
                search.PropertiesToLoad.Add("distinguishedName");
                System.DirectoryServices.SearchResult result;
                System.DirectoryServices.SearchResultCollection resultCol = search.FindAll();
                if (resultCol != null)
                {
                    for (int counter = 0; counter < resultCol.Count; counter++)
                    {
                        string UserNameEmailString = string.Empty;
                        result = resultCol[counter];
                        if (result.Properties.Contains("objectguid") &&
                                 result.Properties.Contains("name") &&
                            result.Properties.Contains("distinguishedName"))
                        {
                            GCSADOrganizationalUnit au = new GCSADOrganizationalUnit();
                            au.Name = result.Properties["name"][0].ToString();
                            au.DistinguishedName = result.Properties["distinguishedName"][0].ToString();
                            organizationalUnits.Add(au);
                        }
                    }
                }
                return organizationalUnits;
            }
            catch (InvalidOperationException ex)
            {
                int x = 0;
            }
            catch (NotSupportedException ex)
            {
                int x = 0;
            }
            return null;
        }

        public static ReadOnlyCollection<GCSADGroup> GetGroups(string server, bool bIncludeEmpty)
        {
            List<GCSADGroup> groups = new List<GCSADGroup>();

            try
            {
                string DomainPath = string.Empty;
                if (string.IsNullOrEmpty(server))
                {
                    DirectoryEntry rootDSE = new DirectoryEntry("LDAP://RootDSE");
                    string defaultNamingContext = rootDSE.Properties["defaultNamingContext"].Value.ToString();

                    DomainPath = string.Format("LDAP://{0}", defaultNamingContext);

                }
                else
                {
                    DomainPath = string.Format("LDAP://{0}", server);
                }
                System.DirectoryServices.DirectoryEntry searchRoot = new System.DirectoryServices.DirectoryEntry(DomainPath);
                System.DirectoryServices.DirectorySearcher search = new System.DirectoryServices.DirectorySearcher(searchRoot);
                search.Filter = "(&(objectCategory=group)(name=*))";
                search.PropertiesToLoad.Add("name");
                search.PropertiesToLoad.Add("distinguishedname");
                search.PageSize = 1000;
                System.DirectoryServices.SearchResult result;
                System.DirectoryServices.SearchResultCollection resultCol = search.FindAll();
                if (resultCol != null)
                {
                    for (int counter = 0; counter < resultCol.Count; counter++)
                    {
                        result = resultCol[counter];
                        if (result.Properties.Contains("name") &&
                            result.Properties.Contains("distinguishedname"))
                        {
                            GCSADGroup group = new GCSADGroup();
                            group.DistinguishedName = result.Properties["distinguishedname"][0].ToString();
                            group.Name = result.Properties["name"][0].ToString();
                            groups.Add(group);
                            //System.Diagnostics.Trace.WriteLine(string.Format("Added group. {0}", group.Name));
                        }
                        //else
                        //{
                        //    System.Diagnostics.Trace.WriteLine(string.Format("Skipping group. Does not contain name or distinguishedname {0}: {1}", 
                        //        result.Properties["name"][0].ToString(), 
                        //        result.Properties["distinguishedname"][0].ToString()));

                        //}
                    }
                }
                if (bIncludeEmpty == true)
                {
                    GCSADGroup group = new GCSADGroup();
                    group.Name = "** ALL USERS **";
                    groups.Add(group);
                }
                return new ReadOnlyCollection<GCSADGroup>(groups);
            }
            catch (InvalidOperationException ex)
            {
                int x = 0;
            }
            catch (NotSupportedException ex)
            {
                int x = 0;
            }
            return null;
        }

        public static List<string> GetLocalGroups()
        {
            var groups = new List<string>();

            var localMachine = new DirectoryEntry
                ("WinNT://" + Environment.MachineName + ",Computer");
            foreach (DirectoryEntry de in localMachine.Children)
            {
                if (de.SchemaClassName == "Group")
                {
                    groups.Add(de.Name);
                }
            }

            return groups;
        }

        public static bool DoesLocalGroupExist(string groupName)
        {
            try
            {
                var localMachine = new DirectoryEntry("WinNT://" + Environment.MachineName + ",Computer");
                var de = localMachine.Children.Find(groupName, "Group");
                return de != null;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public static bool DoesLocalUserExist(string userName)
        {
            try
            {
                var localMachine = new DirectoryEntry("WinNT://" + Environment.MachineName + ",Computer");
                var de = localMachine.Children.Find(userName, "User");
                return de != null;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static List<string> GetLocalUsers()
        {
            var users = new List<string>();

            var localMachine = new DirectoryEntry
                ("WinNT://" + Environment.MachineName + ",Computer");

            foreach (DirectoryEntry de in localMachine.Children)
            {
                if (de.SchemaClassName == "User")
                {
                    users.Add(de.Name);
                }
            }

            return users;
        }


        public static bool CreateLocalGroup(string name, string description)
        {
            try
            {
                var localGroups = GetLocalGroups();
                var g = localGroups.FirstOrDefault(o => o == name);
                if (!string.IsNullOrEmpty(g))
                    return true;

                DirectoryEntry AD = new DirectoryEntry("WinNT://" +
                                    Environment.MachineName + ",computer");
                DirectoryEntry NewGroup = AD.Children.Add(name, "group");
                NewGroup.Invoke("Put", new object[] { "Description", description });
                NewGroup.CommitChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
            return false;

        }

        public static bool CreateLocalUser(string name, string password, string description, List<string> groups)
        {
            try
            {
                var localUsers = GetLocalUsers();
                var u = localUsers.FirstOrDefault(o => o == name);
                if (!string.IsNullOrEmpty(u))
                    return true;

                DirectoryEntry AD = new DirectoryEntry("WinNT://" +
                                    Environment.MachineName + ",computer");
                DirectoryEntry NewUser = AD.Children.Add(name, "user");
                NewUser.Invoke("SetPassword", new object[] { password });
                NewUser.Invoke("Put", new object[] { "Description", description });
                NewUser.CommitChanges();
                DirectoryEntry grp;

                foreach (var g in groups)
                {
                    grp = AD.Children.Find(g, "group");
                    if (grp != null)
                    { grp.Invoke("Add", new object[] { NewUser.Path.ToString() }); }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
            return false;

        }

    }


}


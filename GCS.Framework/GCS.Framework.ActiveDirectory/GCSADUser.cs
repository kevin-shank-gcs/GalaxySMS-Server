
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.DirectoryServices.Protocols;
using System.Collections;
using System.Collections.ObjectModel;

namespace GCS.Framework.ActiveDirectory
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   Values that represent MyTriState. </summary>
    ///
    /// <remarks>   Kevin, 6/10/2014. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public enum MyTriState { Unknown = 0, No, Yes }

    public class AttributeNames
    {
        public const string ObjectSID = "objectsid";
        public const string GivenName = "givenname";
        public const string SurName = "sn";
        public const string HomePhone = "homephone";
        public const string StreetAddress = "streetaddress";
        public const string Country = "co";
        public const string CountryAbbreviation = "c";
        public const string CountryCode = "countrycode";
        public const string Comment = "comment";
        public const string Company = "company";
        public const string Department = "department";
        public const string Description = "description";
        public const string DisplayName = "displayname";
        public const string DistinquishedName = "distinguishedname";
        public const string Division = "division";
        public const string EmployeeId = "employeeid";
        public const string FaxTelephoneNumber = "facsimiletelephonenumber";
        public const string Info = "info";
        public const string Initials = "initials";
        public const string IPPhoneNumber = "ipphone";
        public const string City = "l";
        public const string EmailAddress = "mail";
        public const string Manager = "manager";
        public const string MemberOf = "memberOf";
        public const string MiddleName = "middlename";
        public const string MobilePhoneNumber = "mobile";
        public const string Title = "title";
        public const string PersonalTitle = "personaltitle";
        public const string PostalCode = "postalcode";
        public const string PostOfficeBox = "postofficebox";
        public const string SamAccountName = "samaccountname";
        public const string State = "st";
        public const string TelephoneNumber = "telephoneNumber";
        public const string UserLogonName = "userprincipalname";
        public const string WwwHomePage = "wwwhomepage";
        public const string UserAccountControl = "useraccountcontrol";
        public const string Name = "name";
        public const string ObjectGuid = "objectguid";
        public const string ParentGuid = "parentguid";
        public const string CommonName = "cn";
        public const string WhenCreated = "whencreated";
        public const string MailNickname = "mailnickname";
        public const string IsDeleted = "isdeleted";
        public const string ThumbnailPhoto = "thumbnailphoto";
        public const string JpegPhoto = "jpegphoto";
        public const string PrimaryGroupId = "primarygroupid";
    }
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A gcsad user. </summary>
    ///
    /// <remarks>   Kevin, 6/10/2014. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class GCSADUser
    {
        private object _objectSid = null;

        /// <summary>   Unique identifier for the object. </summary>
        private Guid _objectGuid = Guid.Empty;
        /// <summary>   Unique identifier for the parent. </summary>
        private Guid _parentGuid = Guid.Empty;

        /// <summary>   The name. </summary>
        private string _Name = string.Empty;
        /// <summary>   The person's first name. </summary>
        private string _FirstName = string.Empty;
        /// <summary>   The person's last name. </summary>
        private string _LastName = string.Empty;
        /// <summary>   The person's middle name. </summary>
        private string _MiddleName = string.Empty;
        /// <summary>   The initials. </summary>
        private string _Initials = string.Empty;
        /// <summary>   Name of the display. </summary>
        private string _DisplayName = string.Empty;
        /// <summary>   The description. </summary>
        private string _Description = string.Empty;
        /// <summary>   The office. </summary>
        private string _Office = string.Empty;
        /// <summary>   The phone number. </summary>
        private string _PhoneNumber = string.Empty;
        /// <summary>   The email address. </summary>
        private string _EmailAddress = string.Empty;
        /// <summary>   The home page. </summary>
        private string _HomePage = string.Empty;
        /// <summary>   Name of the distinquished. </summary>
        private string _DistinquishedName = string.Empty;
        /// <summary>   Name of the department. </summary>
        private string _DepartmentName = string.Empty;
        /// <summary>   The state. </summary>
        private string _State = string.Empty;
        /// <summary>   The country. </summary>
        private string _Country = string.Empty;
        /// <summary>   The country abbreviation. </summary>
        private string _CountryAbbreviation = string.Empty;
        /// <summary>   The post office box. </summary>
        private string _PostOfficeBox = string.Empty;
        /// <summary>   The country code. </summary>
        private string _CountryCode = string.Empty;
        /// <summary>   The street address. </summary>
        private string _StreetAddress = string.Empty;
        /// <summary>   The postal code. </summary>
        private string _PostalCode = string.Empty;
        /// <summary>   The city. </summary>
        private string _City = string.Empty;
        /// <summary>   The fax number. </summary>
        private string _FaxNumber = string.Empty;
        /// <summary>   The mobile phone number. </summary>
        private string _MobilePhoneNumber = string.Empty;
        /// <summary>   The IP phone number. </summary>
        private string _IpPhoneNumber = string.Empty;
        /// <summary>   The notes. </summary>
        private string _Notes = string.Empty;
        /// <summary>   The home phone. </summary>
        private string _HomePhone = string.Empty;
        /// <summary>   The company. </summary>
        private string _Company = string.Empty;
        /// <summary>   The job title. </summary>
        private string _JobTitle = string.Empty;
        /// <summary>   The personal title. </summary>
        private string _PersonalTitle = string.Empty;
        /// <summary>   The cn. </summary>
        private string _Cn = string.Empty;
        /// <summary>   The comment. </summary>
        private string _Comment = string.Empty;
        /// <summary>   The division. </summary>
        private string _Division = string.Empty;
        /// <summary>   Identifier for the employee. </summary>
        private string _EmployeeId = string.Empty;
        /// <summary>   The manager. </summary>
        private string _Manager = string.Empty;
        /// <summary>   The member of. </summary>
        private string _MemberOf = string.Empty;
        /// <summary>   The pager. </summary>
        private string _Pager = string.Empty;
        /// <summary>   Name of a m account. </summary>
        private string _sAMAccountName = string.Empty;
        /// <summary>   Name of the user login. </summary>
        private string _UserLoginName = string.Empty;
        /// <summary>   The mail nickname. </summary>
        private string _MailNickname = string.Empty;
        /// <summary>   Identifier for the primary group. </summary>
        private string _PrimaryGroupId = string.Empty;
        /// <summary>   Name of the primary group. </summary>
        private string _PrimaryGroupName = string.Empty;

        /// <summary>   The when created Date/Time. </summary>
        private DateTimeOffset _WhenCreated = DateTimeOffset.MinValue;
        /// <summary>   The when changed Date/Time. </summary>
        private DateTimeOffset _WhenChanged = DateTimeOffset.MinValue;

        /// <summary>   The user account control. </summary>
        private UInt32 _UserAccountControl = 0;
        /// <summary>   true if this object is deleted. </summary>
        private bool _isDeleted = false;

        /// <summary>   The thumbnail photo. </summary>
        private Byte[] _ThumbnailPhoto;
        /// <summary>   The photo. </summary>
        private Byte[] _Photo;
        /// <summary>   The JPEG photo. </summary>
        private Byte[] _JpegPhoto;

        /// <summary>   The properties. </summary>
        private Dictionary<String, object> _properties = new Dictionary<String, object>();
        /// <summary>   The group membership. </summary>
        private List<String> _groupMembership = new List<string>();

        /// <summary>   Information describing the full user. </summary>
        private GCSADUser _fullUserData = null;

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// public ReadOnlyDictionary<String, object> Properties
        /// {
        ///     get { return new ReadOnlyDictionary<String, object>(_properties); }
        /// }
        /// </summary>
        ///
        /// <value> The properties. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public IDictionary<String, object> Properties
        {
            get { return _properties; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the group membership. </summary>
        ///
        /// <value> The group membership. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public ReadOnlyCollection<String> GroupMembership
        {
            get { return new ReadOnlyCollection<String>(_groupMembership); }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Adds a group membership. </summary>
        ///
        /// <remarks>   Kevin, 6/10/2014. </remarks>
        ///
        /// <param name="value">    The value. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void AddGroupMembership(String value)
        {
            if (_groupMembership.Contains(value) == false)
                _groupMembership.Add(value);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Convert a d date time string to date time. </summary>
        ///
        /// <remarks>   Kevin, 6/10/2014. </remarks>
        ///
        /// <param name="value">    The value. </param>
        ///
        /// <returns>   a converted d date time string to date time. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private DateTimeOffset ConvertADDateTimeStringToDateTime(string value)
        {
            if (value == string.Empty)
                return DateTimeOffset.MinValue;

            string format = "yyyyMMddHHmmss.0Z";
            return DateTimeOffset.ParseExact(value, format, System.Globalization.CultureInfo.InvariantCulture);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Adds a property to 'value'. </summary>
        ///
        /// <remarks>   Kevin, 6/10/2014. </remarks>
        ///
        /// <param name="sKey">     The key. </param>
        /// <param name="value">    The value. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void AddProperty(String sKey, object value)
        {
            //System.Diagnostics.Trace.WriteLine(string.Format("Key = {0}, Value = {1}", sKey, value));

            string key = sKey.ToLower();
            if (_properties.ContainsKey(key) == true)
                RemoveProperty(key);

            if (key == AttributeNames.ObjectSID)
                _properties.Add(key, value);
            switch (key)
            {
                case AttributeNames.GivenName:
                    FirstName = value as String;
                    break;

                case AttributeNames.SurName:
                    LastName = value as String;
                    break;

                case AttributeNames.HomePhone:
                    HomePhone = value as String;
                    break;

                case AttributeNames.StreetAddress:
                    StreetAddress = value as String;
                    break;

                case AttributeNames.Country:
                    Country = value as String;
                    break;

                case AttributeNames.CountryAbbreviation:
                    CountryAbbreviation = value as String;
                    break;

                case AttributeNames.CountryCode:
                    CountryCode = value as String;
                    break;

                case AttributeNames.Comment:
                    Comment = value as String;
                    break;

                case AttributeNames.Company:
                    Company = value as String;
                    break;

                case AttributeNames.Department:
                    DepartmentName = value as String;
                    break;

                case AttributeNames.Description:
                    Description = value as String;
                    break;

                case AttributeNames.DisplayName:
                    DisplayName = value as String;
                    break;

                case AttributeNames.DistinquishedName:
                    DistinquishedName = value as String;
                    break;

                case AttributeNames.Division:
                    Division = value as String;
                    break;

                case AttributeNames.EmployeeId:
                    EmployeeId = value as String;
                    break;

                case AttributeNames.FaxTelephoneNumber:
                    FaxNumber = value as String;
                    break;

                case AttributeNames.Info:
                    Notes = value as String;
                    break;

                case AttributeNames.Initials:
                    Initials = value as String;
                    break;

                case AttributeNames.IPPhoneNumber:
                    IpPhoneNumber = value as String;
                    break;

                case AttributeNames.City:
                    City = value as String;
                    break;

                case AttributeNames.EmailAddress:
                    EmailAddress = value as String;
                    break;

                case AttributeNames.Manager:
                    Manager = value as String;
                    break;

                case AttributeNames.MemberOf:
                    MemberOf = value as String;
                    break;

                case AttributeNames.MiddleName:
                    MiddleName = value as String;
                    break;

                case AttributeNames.MobilePhoneNumber:
                    MobilePhoneNumber = value as String;
                    break;

                case AttributeNames.Title:
                    JobTitle = value as String;
                    break;

                case AttributeNames.PersonalTitle:
                    PersonalTitle = value as String;
                    break;

                case AttributeNames.PostalCode:
                    PostalCode = value as String;
                    break;

                case AttributeNames.PostOfficeBox:
                    PostOfficeBox = value as String;
                    break;

                case AttributeNames.SamAccountName:
                    UserLogonNamePreWindows2000 = value as String;
                    break;

                case AttributeNames.State:
                    State = value as String;
                    break;

                case AttributeNames.TelephoneNumber:
                    PhoneNumber = value as String;
                    break;

                case AttributeNames.UserLogonName:
                    UserLogonName = value as String;
                    break;

                case AttributeNames.WwwHomePage:
                    HomePage = value as String;
                    break;

                case AttributeNames.UserAccountControl:
                    UInt32.TryParse(value as string, out _UserAccountControl);
                    break;

                case AttributeNames.Name:
                    Name = value as String;
                    break;

                case AttributeNames.ObjectGuid:
                    ObjectGUID = (Guid)value;
                    break;

                case AttributeNames.ParentGuid:
                    ParentGUID = (Guid)value;
                    break;

                case AttributeNames.CommonName:
                    Cn = value as String;
                    break;

                case AttributeNames.WhenCreated:
                    WhenCreated = ConvertADDateTimeStringToDateTime(value as String);
                    break;

                case AttributeNames.MailNickname:
                    MailNickname = value as String;
                    break;

                case AttributeNames.IsDeleted:
                    if (value != null)
                    {
                        if ((value as String).ToLower() == "true")
                            _isDeleted = true;
                        else
                            _isDeleted = false;
                    }
                    else
                        _isDeleted = false;
                    break;

                case AttributeNames.ThumbnailPhoto:
                    ThumbnailPhoto = value as byte[];
                    break;

                case AttributeNames.JpegPhoto:
                    JpegPhoto = value as byte[];
                    break;

                case AttributeNames.PrimaryGroupId:
                    PrimaryGroupId = value as String;
                    break;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Removes the property described by sKey. </summary>
        ///
        /// <remarks>   Kevin, 6/10/2014. </remarks>
        ///
        /// <param name="sKey"> The key. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void RemoveProperty(String sKey)
        {
            _properties.Remove(sKey.ToLower());
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets property value. </summary>
        ///
        /// <remarks>   Kevin, 6/10/2014. </remarks>
        ///
        /// <param name="sKey"> The key. </param>
        ///
        /// <returns>   The property value. </returns>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public object GetPropertyValue(String sKey)
        {
            string key = sKey.ToLower();
            if (_properties.ContainsKey(key) == true)
                return _properties[key];
            return null;
        }

        public bool IsSelected { get; set; }
        
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets a value indicating whether this object is deleted. </summary>
        ///
        /// <value> true if this object is deleted, false if not. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool IsDeleted
        {
            get { return _isDeleted; }
        }

        public object ObjectSID
        {
            get { return _objectSid; }
            set { _objectSid = value; }
        }
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the normal account. </summary>
        ///
        /// <value> The normal account. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public MyTriState NormalAccount
        {
            get
            {
                if (_UserAccountControl == (UInt32)GCSADUserAccountControlFlag.None)
                    return MyTriState.Unknown;
                if ((_UserAccountControl & (UInt32)GCSADUserAccountControlFlag.NORMAL_ACCOUNT) != 0)
                    return MyTriState.Yes;
                else
                    return MyTriState.No;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the account disabled. </summary>
        ///
        /// <value> The account disabled. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public MyTriState AccountDisabled
        {
            get
            {
                if (_UserAccountControl == 0)
                    return MyTriState.Unknown;
                if ((_UserAccountControl & (UInt32)GCSADUserAccountControlFlag.ACCOUNTDISABLE) != 0)
                    return MyTriState.Yes;
                else
                    return MyTriState.No;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the lockout. </summary>
        ///
        /// <value> The lockout. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public MyTriState Lockout
        {
            get
            {
                if (_UserAccountControl == 0)
                    return MyTriState.Unknown;
                if ((_UserAccountControl & (UInt32)GCSADUserAccountControlFlag.LOCKOUT) != 0)
                    return MyTriState.Yes;
                else
                    return MyTriState.No;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the password not required. </summary>
        ///
        /// <value> The password not required. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public MyTriState PasswordNotRequired
        {
            get
            {
                if (_UserAccountControl == 0)
                    return MyTriState.Unknown;
                if ((_UserAccountControl & (UInt32)GCSADUserAccountControlFlag.PASSWD_NOTREQD) != 0)
                    return MyTriState.Yes;
                else
                    return MyTriState.No;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets the password expired. </summary>
        ///
        /// <value> The password expired. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public MyTriState PasswordExpired
        {
            get
            {
                if (_UserAccountControl == 0)
                    return MyTriState.Unknown;
                if ((_UserAccountControl & (UInt32)GCSADUserAccountControlFlag.PASSWORD_EXPIRED) != 0)
                    return MyTriState.Yes;
                else
                    return MyTriState.No;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a unique identifier of the object. </summary>
        ///
        /// <value> Unique identifier of the object. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Guid ObjectGUID
        {
            get { return _objectGuid; }
            set { _objectGuid = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets a unique identifier of the parent. </summary>
        ///
        /// <value> Unique identifier of the parent. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Guid ParentGUID
        {
            get { return _parentGuid; }
            set { _parentGuid = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the cn. </summary>
        ///
        /// <value> The cn. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string Cn
        {
            get { return _Cn; }
            set { _Cn = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name. </summary>
        ///
        /// <value> The name. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the person's first name. </summary>
        ///
        /// <value> The name of the first. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the person's last name. </summary>
        ///
        /// <value> The name of the last. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string LastName
        {
            get { return _LastName; }
            set { _LastName = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the person's middle name. </summary>
        ///
        /// <value> The name of the middle. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string MiddleName
        {
            get { return _MiddleName; }
            set { _MiddleName = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the initials. </summary>
        ///
        /// <value> The initials. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string Initials
        {
            get { return _Initials; }
            set { _Initials = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the display. </summary>
        ///
        /// <value> The name of the display. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string DisplayName
        {
            get { return _DisplayName; }
            set { _DisplayName = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the mail nickname. </summary>
        ///
        /// <value> The mail nickname. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string MailNickname
        {
            get { return _MailNickname; }
            set { _MailNickname = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the description. </summary>
        ///
        /// <value> The description. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the office. </summary>
        ///
        /// <value> The office. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string Office
        {
            get { return _Office; }
            set { _Office = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the phone number. </summary>
        ///
        /// <value> The phone number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string PhoneNumber
        {
            get { return _PhoneNumber; }
            set { _PhoneNumber = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the email address. </summary>
        ///
        /// <value> The email address. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string EmailAddress
        {
            get { return _EmailAddress; }
            set { _EmailAddress = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the home page. </summary>
        ///
        /// <value> The home page. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string HomePage
        {
            get { return _HomePage; }
            set { _HomePage = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the distinquished. </summary>
        ///
        /// <value> The name of the distinquished. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string DistinquishedName
        {
            get { return _DistinquishedName; }
            set { _DistinquishedName = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the department. </summary>
        ///
        /// <value> The name of the department. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string DepartmentName
        {
            get { return _DepartmentName; }
            set { _DepartmentName = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the state. </summary>
        ///
        /// <value> The state. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string State
        {
            get { return _State; }
            set { _State = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the country. </summary>
        ///
        /// <value> The country. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string Country
        {
            get { return _Country; }
            set { _Country = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the country abbreviation. </summary>
        ///
        /// <value> The country abbreviation. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string CountryAbbreviation
        {
            get { return _CountryAbbreviation; }
            set { _CountryAbbreviation = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the post office box. </summary>
        ///
        /// <value> The post office box. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string PostOfficeBox
        {
            get { return _PostOfficeBox; }
            set { _PostOfficeBox = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the country code. </summary>
        ///
        /// <value> The country code. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string CountryCode
        {
            get { return _CountryCode; }
            set { _CountryCode = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the street address. </summary>
        ///
        /// <value> The street address. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string StreetAddress
        {
            get { return _StreetAddress; }
            set { _StreetAddress = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the postal code. </summary>
        ///
        /// <value> The postal code. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string PostalCode
        {
            get { return _PostalCode; }
            set { _PostalCode = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the city. </summary>
        ///
        /// <value> The city. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string City
        {
            get { return _City; }
            set { _City = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the fax number. </summary>
        ///
        /// <value> The fax number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string FaxNumber
        {
            get { return _FaxNumber; }
            set { _FaxNumber = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the mobile phone number. </summary>
        ///
        /// <value> The mobile phone number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string MobilePhoneNumber
        {
            get { return _MobilePhoneNumber; }
            set { _MobilePhoneNumber = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the IP phone number. </summary>
        ///
        /// <value> The IP phone number. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string IpPhoneNumber
        {
            get { return _IpPhoneNumber; }
            set { _IpPhoneNumber = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the notes. </summary>
        ///
        /// <value> The notes. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string Notes
        {
            get { return _Notes; }
            set { _Notes = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the home phone. </summary>
        ///
        /// <value> The home phone. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string HomePhone
        {
            get { return _HomePhone; }
            set { _HomePhone = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the company. </summary>
        ///
        /// <value> The company. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string Company
        {
            get { return _Company; }
            set { _Company = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the job title. </summary>
        ///
        /// <value> The job title. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string JobTitle
        {
            get { return _JobTitle; }
            set { _JobTitle = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the personal title. </summary>
        ///
        /// <value> The personal title. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string PersonalTitle
        {
            get { return _PersonalTitle; }
            set { _PersonalTitle = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the comment. </summary>
        ///
        /// <value> The comment. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string Comment
        {
            get { return _Comment; }
            set { _Comment = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the division. </summary>
        ///
        /// <value> The division. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string Division
        {
            get { return _Division; }
            set { _Division = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the employee. </summary>
        ///
        /// <value> The identifier of the employee. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string EmployeeId
        {
            get { return _EmployeeId; }
            set { _EmployeeId = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the manager. </summary>
        ///
        /// <value> The manager. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string Manager
        {
            get { return _Manager; }
            set { _Manager = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the member of. </summary>
        ///
        /// <value> The member of. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string MemberOf
        {
            get { return _MemberOf; }
            set { _MemberOf = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the pager. </summary>
        ///
        /// <value> The pager. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string Pager
        {
            get { return _Pager; }
            set { _Pager = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the user logon name pre windows 2000. </summary>
        ///
        /// <value> The user logon name pre windows 2000. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string UserLogonNamePreWindows2000
        {
            get { return _sAMAccountName; }
            set { _sAMAccountName = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the user logon. </summary>
        ///
        /// <value> The name of the user logon. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string UserLogonName
        {
            get { return _UserLoginName; }
            set { _UserLoginName = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the identifier of the primary group. </summary>
        ///
        /// <value> The identifier of the primary group. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string PrimaryGroupId
        {
            get { return _PrimaryGroupId; }
            set { _PrimaryGroupId = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the name of the primary group. </summary>
        ///
        /// <value> The name of the primary group. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public string PrimaryGroupName
        {
            get { return _PrimaryGroupName; }
            set { _PrimaryGroupName = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the user account control. </summary>
        ///
        /// <value> The user account control. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public UInt32 UserAccountControl
        {
            get { return _UserAccountControl; }
            set
            {
                _UserAccountControl = value;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets information describing the full user. </summary>
        ///
        /// <value> Information describing the full user. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public GCSADUser FullUserData
        {
            get { return _fullUserData; }
            set { _fullUserData = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the Date/Time of the when created. </summary>
        ///
        /// <value> The when created. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DateTimeOffset WhenCreated
        {
            get { return _WhenCreated; }
            set { _WhenCreated = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the Date/Time of the when changed. </summary>
        ///
        /// <value> The when changed. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public DateTimeOffset WhenChanged
        {
            get { return _WhenChanged; }
            set { _WhenChanged = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the thumbnail photo. </summary>
        ///
        /// <value> The thumbnail photo. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Byte[] ThumbnailPhoto
        {
            get { return _ThumbnailPhoto; }
            set { _ThumbnailPhoto = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the photo. </summary>
        ///
        /// <value> The photo. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Byte[] Photo
        {
            get { return _Photo; }
            set { _Photo = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Gets or sets the JPEG photo. </summary>
        ///
        /// <value> The JPEG photo. </value>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Byte[] JpegPhoto
        {
            get { return _JpegPhoto; }
            set { _JpegPhoto = value; }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Process the dictionary entry described by de. </summary>
        ///
        /// <remarks>   Kevin, 6/10/2014. </remarks>
        ///
        /// <param name="de">   The de. </param>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void ProcessDictionaryEntry(DictionaryEntry de)
        {
            //						System.Diagnostics.Trace.WriteLine(string.Format("Key = {0}, Value = {1}", de.Key, de.Value));
            //System.Diagnostics.Trace.Write(string.Format("Key:{0}, Value:", de.Key));
            if (de.Value is DirectoryAttribute)
            {
                DirectoryAttribute da = de.Value as DirectoryAttribute;
                if (da != null)
                {

                    Type t = typeof(string);
                    String sKey = de.Key as String;
                    bool bUseByteArray = false;
                    switch (sKey.ToLower())
                    {
                        case "objectguid":
                        case "parentguid":
                            t = typeof(Guid);
                            bUseByteArray = true;
                            break;

                        case "objectsid":
                        case "thumbnailphoto":
                        case "jpegphoto":
                            bUseByteArray = true;
                            break;
                    }

                    object[] strValues = da.GetValues(typeof(String));
                    object[] baValues = da.GetValues(typeof(byte[]));
                    if (strValues.Length != baValues.Length)
                        System.Diagnostics.Trace.WriteLine("length mismatch");

                    if (bUseByteArray == false)
                    {
                        if (strValues.Length == 0)
                        {
                            this.AddProperty(sKey, null);
                        }
                        else if (strValues.Length > 1)
                        {
                            List<String> values = new List<string>();
                            foreach (string s in strValues)
                            {
                                values.Add(s);
                            }
                            this.AddProperty(sKey, values);
                        }
                        else
                        {
                            foreach (string s in strValues)
                            {
                                if (t != typeof(Guid))
                                    this.AddProperty(sKey, s);
                            }
                        }
                    }
                    else
                    {
                        foreach (byte[] ba in baValues)
                        {
                            if (t == typeof(Guid))
                            {
                                Guid g = new Guid(ba);
                                this.AddProperty(sKey, g);
                            }
                            else
                            {
                                String s = System.Text.Encoding.Default.GetString(ba);
                                this.AddProperty(sKey, ba);
                            }
                        }
                    }
                }
                else
                {
                    //System.Diagnostics.Trace.WriteLine(de.Value.ToString());
                }
            }
            //else
            //    System.Diagnostics.Trace.WriteLine(de.Value.ToString());

        }

        public void ProcessSearchResult(SearchResult r)
        {
            ObjectGUID = GetPropertyAsGuid(ref r, AttributeNames.ObjectGuid);
            Name = GetPropertyAsString(ref r, AttributeNames.Name);
            _isDeleted = (bool)GetProperty(ref r, AttributeNames.IsDeleted);

            ParentGUID = (Guid)GetPropertyAsGuid(ref r, AttributeNames.ParentGuid);
            ObjectSID = GetProperty(ref r, AttributeNames.ObjectSID);
            DistinquishedName = GetPropertyAsString(ref r, AttributeNames.DistinquishedName);
            FirstName = GetPropertyAsString(ref r, AttributeNames.GivenName);
            LastName = GetPropertyAsString(ref r, AttributeNames.SurName);
            HomePhone = GetPropertyAsString(ref r, AttributeNames.HomePhone);
            StreetAddress = GetPropertyAsString(ref r, AttributeNames.StreetAddress);
            Country = GetPropertyAsString(ref r, AttributeNames.Country);
            CountryAbbreviation = GetPropertyAsString(ref r, AttributeNames.CountryAbbreviation);
            CountryCode = GetPropertyAsString(ref r, AttributeNames.CountryCode);
            Comment = GetPropertyAsString(ref r, AttributeNames.Comment);
            Company = GetPropertyAsString(ref r, AttributeNames.Company);
            DepartmentName = GetPropertyAsString(ref r, AttributeNames.Department);
            Description = GetPropertyAsString(ref r, AttributeNames.Description);
            DisplayName = GetPropertyAsString(ref r, AttributeNames.DisplayName);
            Division = GetPropertyAsString(ref r, AttributeNames.Division);
            EmployeeId = GetPropertyAsString(ref r, AttributeNames.EmployeeId);
            FaxNumber = GetPropertyAsString(ref r, AttributeNames.FaxTelephoneNumber);
            Notes = GetPropertyAsString(ref r, AttributeNames.Info);
            Initials = GetPropertyAsString(ref r, AttributeNames.Initials);
            IpPhoneNumber = GetPropertyAsString(ref r, AttributeNames.IPPhoneNumber);
            City = GetPropertyAsString(ref r, AttributeNames.City);
            EmailAddress = GetPropertyAsString(ref r, AttributeNames.EmailAddress);
            Manager = GetPropertyAsString(ref r, AttributeNames.Manager);
            MemberOf = GetPropertyAsString(ref r, AttributeNames.MemberOf);
            MiddleName = GetPropertyAsString(ref r, AttributeNames.MiddleName);
            MobilePhoneNumber = GetPropertyAsString(ref r, AttributeNames.MobilePhoneNumber);
            JobTitle = GetPropertyAsString(ref r, AttributeNames.Title);
            PersonalTitle = GetPropertyAsString(ref r, AttributeNames.PersonalTitle);
            PostalCode = GetPropertyAsString(ref r, AttributeNames.PostalCode);
            PostOfficeBox = GetPropertyAsString(ref r, AttributeNames.PostOfficeBox);
            UserLogonNamePreWindows2000 = GetPropertyAsString(ref r, AttributeNames.SamAccountName);
            State = GetPropertyAsString(ref r, AttributeNames.State);
            PhoneNumber = GetPropertyAsString(ref r, AttributeNames.TelephoneNumber);
            UserLogonName = GetPropertyAsString(ref r, AttributeNames.UserLogonName);
            HomePage = GetPropertyAsString(ref r, AttributeNames.WwwHomePage);

            string sUac = GetPropertyAsString(ref r, AttributeNames.UserAccountControl);
            UInt32.TryParse(sUac, out _UserAccountControl);

            Cn = GetPropertyAsString(ref r, AttributeNames.CommonName);

            WhenCreated = GetPropertyAsDateTime(ref r, AttributeNames.WhenCreated);

            MailNickname = GetPropertyAsString(ref r, AttributeNames.MailNickname);

            object oIsDeleted = GetProperty(ref r, AttributeNames.IsDeleted);
            if (oIsDeleted != null)
            {
                if (oIsDeleted.ToString().ToLower() == "true")
                    _isDeleted = true;
                else
                    _isDeleted = false;
            }
            else
                _isDeleted = false;

            object oThumbnail = GetProperty(ref r, AttributeNames.ThumbnailPhoto);
            if (oThumbnail != null)
                ThumbnailPhoto = oThumbnail as byte[];

            object oJpg = GetProperty(ref r, AttributeNames.JpegPhoto);
            if (oJpg != null)
                JpegPhoto = oJpg as byte[];

            PrimaryGroupId = GetPropertyAsString(ref r, AttributeNames.PrimaryGroupId);
        }

        public void ProcessDirectoryEntry(DirectoryEntry de)
        {
            ObjectGUID = (Guid)GetPropertyAsGuid(ref de, AttributeNames.ObjectGuid);
            ParentGUID = (Guid)GetPropertyAsGuid(ref de, AttributeNames.ParentGuid);
            Name = GetPropertyAsString(ref de, AttributeNames.Name);
            ObjectSID = GetProperty(ref de, AttributeNames.ObjectSID);
            DistinquishedName = GetPropertyAsString(ref de, AttributeNames.DistinquishedName);
            FirstName = GetPropertyAsString(ref de, AttributeNames.GivenName);
            LastName = GetPropertyAsString(ref de, AttributeNames.SurName);
            HomePhone = GetPropertyAsString(ref de, AttributeNames.HomePhone);
            StreetAddress = GetPropertyAsString(ref de, AttributeNames.StreetAddress);
            Country = GetPropertyAsString(ref de, AttributeNames.Country);
            CountryAbbreviation = GetPropertyAsString(ref de, AttributeNames.CountryAbbreviation);
            CountryCode = GetPropertyAsString(ref de, AttributeNames.CountryCode);
            Comment = GetPropertyAsString(ref de, AttributeNames.Comment);
            Company = GetPropertyAsString(ref de, AttributeNames.Company);
            DepartmentName = GetPropertyAsString(ref de, AttributeNames.Department);
            Description = GetPropertyAsString(ref de, AttributeNames.Description);
            DisplayName = GetPropertyAsString(ref de, AttributeNames.DisplayName);
            Division = GetPropertyAsString(ref de, AttributeNames.Division);
            EmployeeId = GetPropertyAsString(ref de, AttributeNames.EmployeeId);
            FaxNumber = GetPropertyAsString(ref de, AttributeNames.FaxTelephoneNumber);
            Notes = GetPropertyAsString(ref de, AttributeNames.Info);
            Initials = GetPropertyAsString(ref de, AttributeNames.Initials);
            IpPhoneNumber = GetPropertyAsString(ref de, AttributeNames.IPPhoneNumber);
            City = GetPropertyAsString(ref de, AttributeNames.City);
            EmailAddress = GetPropertyAsString(ref de, AttributeNames.EmailAddress);
            Manager = GetPropertyAsString(ref de, AttributeNames.Manager);
            MemberOf = GetPropertyAsString(ref de, AttributeNames.MemberOf);
            MiddleName = GetPropertyAsString(ref de, AttributeNames.MiddleName);
            MobilePhoneNumber = GetPropertyAsString(ref de, AttributeNames.MobilePhoneNumber);
            JobTitle = GetPropertyAsString(ref de, AttributeNames.Title);
            PersonalTitle = GetPropertyAsString(ref de, AttributeNames.PersonalTitle);
            PostalCode = GetPropertyAsString(ref de, AttributeNames.PostalCode);
            PostOfficeBox = GetPropertyAsString(ref de, AttributeNames.PostOfficeBox);
            UserLogonNamePreWindows2000 = GetPropertyAsString(ref de, AttributeNames.SamAccountName);
            State = GetPropertyAsString(ref de, AttributeNames.State);
            PhoneNumber = GetPropertyAsString(ref de, AttributeNames.TelephoneNumber);
            UserLogonName = GetPropertyAsString(ref de, AttributeNames.UserLogonName);
            HomePage = GetPropertyAsString(ref de, AttributeNames.WwwHomePage);

            string sUac = GetPropertyAsString(ref de, AttributeNames.UserAccountControl);
            UInt32.TryParse(sUac, out _UserAccountControl);

            Cn = GetPropertyAsString(ref de, AttributeNames.CommonName);

            WhenCreated = GetPropertyAsDateTime(ref de, AttributeNames.WhenCreated);

            MailNickname = GetPropertyAsString(ref de, AttributeNames.MailNickname);

            object oIsDeleted = GetProperty(ref de, AttributeNames.IsDeleted);
            if (oIsDeleted != null)
            {
                if ((oIsDeleted as String).ToLower() == "true")
                    _isDeleted = true;
                else
                    _isDeleted = false;
            }
            else
                _isDeleted = false;

            object oThumbnail = GetProperty(ref de, AttributeNames.ThumbnailPhoto);
            if (oThumbnail != null)
                ThumbnailPhoto = oThumbnail as byte[];

            object oJpg = GetProperty(ref de, AttributeNames.JpegPhoto);
            if (oJpg != null)
                JpegPhoto = oJpg as byte[];

            PrimaryGroupId = GetPropertyAsString(ref de, AttributeNames.PrimaryGroupId);

        }

        private string GetPropertyAsString(ref DirectoryEntry de, string propertyName)
        {
            if (de == null)
                return string.Empty;
            if (string.IsNullOrEmpty(propertyName))
                return string.Empty;
            if (de.Properties.Contains(propertyName))
            {
                var prop = de.Properties[propertyName];
                if (prop != null && prop.Value != null)
                    return prop.Value.ToString();
            }
            return string.Empty;
        }


        private Guid GetPropertyAsGuid(ref DirectoryEntry de, string propertyName)
        {
            if (de == null)
                return Guid.Empty;
            if (string.IsNullOrEmpty(propertyName))
                return Guid.Empty;
            if (de.Properties.Contains(propertyName))
            {
                var prop = de.Properties[propertyName];
                if (prop != null && prop.Value != null)
                {
                    Type tString = typeof(string);
                    Type tByteArray = typeof(byte[]);
                    Type valueType = prop.Value.GetType();
                    if (valueType == tByteArray)
                        return new Guid((byte[])prop.Value);
                    if (valueType == tString)
                        return new Guid(prop.Value.ToString());
                }
            }
            return Guid.Empty;
        }

        private DateTimeOffset GetPropertyAsDateTime(ref DirectoryEntry de, string propertyName)
        {
            if (de == null)
                return DateTimeOffset.MinValue;
            if (string.IsNullOrEmpty(propertyName))
                return DateTimeOffset.MinValue;
            if (de.Properties.Contains(propertyName))
            {
                var prop = de.Properties[propertyName];
                if (prop != null && prop.Value != null)
                {
                    Type tString = typeof(string);
                    Type tDateTime = typeof(DateTimeOffset);
                    Type valueType = prop.Value.GetType();
                    if (valueType == tDateTime)
                        return (DateTimeOffset)prop.Value;
                }
            }
            return DateTimeOffset.MinValue;
        }

        private object GetProperty(ref DirectoryEntry de, string propertyName)
        {
            if (de == null)
                return null;
            if (string.IsNullOrEmpty(propertyName))
                return null;
            if (de.Properties.Contains(propertyName))
            {
                var prop = de.Properties[propertyName];
                if (prop != null )
                {
                    return prop.Value;
                }
            }
            return null;
        }


        private string GetPropertyAsString(ref SearchResult r, string propertyName)
        {
            if (r == null)
                return string.Empty;
            if (string.IsNullOrEmpty(propertyName))
                return string.Empty;
            if (r.Properties.Contains(propertyName))
            {
                var prop = r.Properties[propertyName];
                if (prop != null && prop.Count > 0 && prop[0] != null)
                {
                    return prop[0].ToString();
                }
            }
            return string.Empty;
        }


        private Guid GetPropertyAsGuid(ref SearchResult r, string propertyName)
        {
            if (r == null)
                return Guid.Empty;
            if (string.IsNullOrEmpty(propertyName))
                return Guid.Empty;
            if (r.Properties.Contains(propertyName))
            {
                var prop = r.Properties[propertyName];
                if (prop != null && prop.Count > 0 && prop[0] != null)
                {
                    Type tString = typeof(string);
                    Type tByteArray = typeof(byte[]);
                    Type valueType = prop[0].GetType();
                    if (valueType == tByteArray)
                        return new Guid((byte[])prop[0]);
                    if (valueType == tString)
                        return new Guid(prop[0].ToString());
                }
            }
            return Guid.Empty;
        }

        private DateTimeOffset GetPropertyAsDateTime(ref SearchResult r, string propertyName)
        {
            if (r == null)
                return DateTimeOffset.MinValue;
            if (string.IsNullOrEmpty(propertyName))
                return DateTimeOffset.MinValue;
            if (r.Properties.Contains(propertyName))
            {
                var prop = r.Properties[propertyName];
                if (prop != null && prop.Count > 0 && prop[0] != null)
                {
                    Type tString = typeof(string);
                    Type tDateTime = typeof(DateTimeOffset);
                    Type valueType = prop[0].GetType();
                    if (valueType == tDateTime)
                        return (DateTimeOffset)prop[0];
                }
            }
            return DateTimeOffset.MinValue;
        }

        private object GetProperty(ref SearchResult r, string propertyName)
        {
            if (r == null)
                return null;
            if (string.IsNullOrEmpty(propertyName))
                return null;
            if (r.Properties.Contains(propertyName))
            {
                var prop = r.Properties[propertyName];
                if (prop != null && prop.Count > 0 && prop[0] != null)
                {
                    return prop[0];
                }
            }
            return null;
        }        
        
        
        public bool IsStringNullOrEmpty(string s)
        {
            if (string.IsNullOrEmpty(s))
                return true;
            if (string.IsNullOrWhiteSpace(s))
                return true;
            return false;
        }
    }
}

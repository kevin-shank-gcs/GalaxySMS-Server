////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\PermissionCategoryIds.cs
//
// summary:	Implements the permission category identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A permission category identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class PermissionCategoryIds
    {
        /// <summary>   Identifier for the galaxy SMS admin can execute category. </summary>
        public static readonly Guid GalaxySMS_Admin_CanExecuteCategoryId = new Guid("169E6C39-006E-47E3-A22B-5268C9DE2C18");

        /// <summary>   Identifier for the communication control category. </summary>
        public static readonly Guid CommunicationControlCategoryId = new Guid("91CAD692-F918-445D-8A41-CA356074626E");
        /// <summary>   Identifier for the langauge data access editing category. </summary>
        public static readonly Guid LangaugeDataAccessEditingCategoryId = new Guid("05359104-D166-4634-BF44-33D5E4EACA49");
        /// <summary>   Identifier for the application data access editing category. </summary>
        public static readonly Guid ApplicationDataAccessEditingCategoryId = new Guid("4A307BF6-CD23-4F78-8C81-A0A9D0A6403E");
        /// <summary>   Identifier for the entity data access editing category. </summary>
        public static readonly Guid EntityDataAccessEditingCategoryId = new Guid("E39F2DFF-93A8-44DA-82A8-6BC823480324");
        /// <summary>   Identifier for the role data access editing category. </summary>
        public static readonly Guid RoleDataAccessEditingCategoryId = new Guid("BD5C0719-48B4-423C-830A-A64992382819");
        /// <summary>   Identifier for the permission category data access editing category. </summary>
        public static readonly Guid PermissionCategoryDataAccessEditingCategoryId = new Guid("154C0A1C-77B9-493B-B031-3753AB0F4550");
        /// <summary>   Identifier for the permission data access editing category. </summary>
        public static readonly Guid PermissionDataAccessEditingCategoryId = new Guid("91C9C3BF-1C4E-44B2-89CE-E8FEA91A4C7B");
        /// <summary>   Identifier for the user data access editing category. </summary>
        public static readonly Guid UserDataAccessEditingCategoryId = new Guid("F7D70327-38FC-4E55-A8C3-C36AAE58FAFC");

        /// <summary>   Identifier for the galaxy SMS facility manager can execute category. </summary>
        public static readonly Guid GalaxySMS_FacilityManager_CanExecuteCategoryId = new Guid("B66C032C-EA84-4FC5-AD71-326ED2B3CD68");
        /// <summary>   Identifier for the country data access editing category. </summary>
        public static readonly Guid CountryDataAccessEditingCategoryId = new Guid("0D67B686-FAAC-4FB4-B4DB-CD331E519E5F");
        /// <summary>   Identifier for the state province data access editing category. </summary>
        public static readonly Guid StateProvinceDataAccessEditingCategoryId = new Guid("7D8E7043-A2CE-4641-B82A-5A48C33CE9C6");
        /// <summary>   Identifier for the region data access editing category. </summary>
        public static readonly Guid RegionDataAccessEditingCategoryId = new Guid("42D15ACD-F836-4CA5-8FA8-19D93286CDE8");
        /// <summary>   Identifier for the site data access editing category. </summary>
        public static readonly Guid SiteDataAccessEditingCategoryId = new Guid("FF2FED8F-E639-41BF-B873-E812274D8AC8");
        /// <summary>   Identifier for the access portal data access editing category. </summary>
        public static readonly Guid AccessPortalDataAccessEditingCategoryId = new Guid("682849CD-4264-437A-B3A0-C956BC76EBF9");
        /// <summary>   Identifier for the monitored device data access editing category. </summary>
        public static readonly Guid MonitoredDeviceDataAccessEditingCategoryId = new Guid("E8883C0A-8039-4299-A241-B8CFCFC34F3F");
        /// <summary>   Identifier for the output device data access editing category. </summary>
        public static readonly Guid OutputDeviceDataAccessEditingCategoryId = new Guid("6D458B8E-2CF0-4527-91A7-0866568844C0");
        /// <summary>   Identifier for the time schedule data access editing category. </summary>
        public static readonly Guid TimeScheduleDataAccessEditingCategoryId = new Guid("06B257FC-477D-4036-B56E-1E00E7C02B29");
        /// <summary>   Identifier for the access permission data access editing category. </summary>
        public static readonly Guid AccessPermissionDataAccessEditingCategoryId = new Guid("01A6FF6A-390E-4CAB-8B04-FC5D6986F56D");
        /// <summary>   Identifier for the access profile data access editing category. </summary>
        public static readonly Guid AccessProfileDataAccessEditingCategoryId = new Guid("00D494A9-6E25-4216-B0C3-BB016EECB080");
        /// <summary>   Identifier for the personnel data access editing category. </summary>
        public static readonly Guid PersonnelDataAccessEditingCategoryId = new Guid("15C2B738-30DE-4326-9E93-367E0317764B");
        /// <summary>   Identifier for the credential data access editing category. </summary>
        public static readonly Guid CredentialDataAccessEditingCategoryId = new Guid("2DA5FB66-693B-44F8-B778-D8490CB094B5");
        /// <summary>   Identifier for the system hardware data access editing category. </summary>
        public static readonly Guid SystemHardwareDataAccessEditingCategoryId = new Guid("FC1B6698-922D-49F9-B146-A50D0206A7B6");
        /// <summary>   Identifier for the badge layout data access editing category. </summary>
        public static readonly Guid BadgeLayoutDataAccessEditingCategoryId = new Guid("1FA691FC-2362-4EA2-8EBC-CBC961205909");

        /// <summary>   Identifier for the personnel property access category. </summary>
        public static readonly Guid PersonnelPropertyAccessCategoryId = new Guid("2bb6a30e-4148-45a4-b2ab-cd6875ca2bc9");
        /// <summary>   Identifier for the personnel access control property access category. </summary>
        public static readonly Guid PersonnelAccessControlPropertyAccessCategoryId = new Guid("038d5f11-e8d6-41aa-a72a-08491ddf0895");

        /// <summary>   Identifier for the access portal command category. </summary>
        public static readonly Guid AccessPortalCommandCategoryId = new Guid("40EDD3BE-0C2F-4354-8F4D-0F4624FDD0E4");
        /// <summary>   Identifier for the input device command category. </summary>
        public static readonly Guid InputDeviceCommandCategoryId = new Guid("FF7AB8F1-A056-417A-9031-94E4BB18A917");
        /// <summary>   Identifier for the elevator command category. </summary>
        public static readonly Guid ElevatorCommandCategoryId = new Guid("2D123D5E-0F45-4CEC-92F2-54CB96D0C726");
        /// <summary>   Identifier for the input output group command category. </summary>
        public static readonly Guid InputOutputGroupCommandCategoryId = new Guid("A57015C9-3EF9-411F-B436-44F62CEAE395");
        /// <summary>   Identifier for the output device command category. </summary>
        public static readonly Guid OutputDeviceCommandCategoryId = new Guid("71873653-A3A3-4A16-A197-AD1941E201AE");
        /// <summary>   Identifier for the cluster command category. </summary>
        public static readonly Guid ClusterCommandCategoryId = new Guid("70BE1C2C-26AD-4B53-ADAA-DF8E1D3EE695");
        /// <summary>   Identifier for the access portal group command category. </summary>
        public static readonly Guid AccessPortalGroupCommandCategoryId = new Guid("82A4CB3B-B00E-4AD5-B130-A29750CA7982");


    }
}

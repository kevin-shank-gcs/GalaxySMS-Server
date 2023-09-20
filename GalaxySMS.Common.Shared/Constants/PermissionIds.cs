////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\PermissionIds.cs
//
// summary:	Implements the permission identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   A permission identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class PermissionIds
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A can execute identifiers. </summary>
        ///
        /// <remarks>   Kevin, 1/3/2019. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public class CanExecuteIds
        {
            /// <summary>   Identifier for the galaxy SMS admin can execute. </summary>
            public static readonly Guid GalaxySMS_Admin_CanExecuteId = new Guid("D5D269F9-2420-4C38-89B1-182274AEA0C4");
            /// <summary>   Identifier for the galaxy SMS facility manager can execute. </summary>
            public static readonly Guid GalaxySMS_FacilityManager_CanExecuteId = new Guid("0B313140-02E3-40FD-9A9C-664EAECF8E3D");
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   A galaxy SMS admin data access editing identifiers. </summary>
        ///
        /// <remarks>   Kevin, 1/3/2019. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public class GalaxySMSAdminDataAccessEditingIds
        {
            //public static readonly Guid CanViewId = new Guid("");
            //public static readonly Guid CanAddId = new Guid("");
            //public static readonly Guid CanUpdateId = new Guid("");
            //public static readonly Guid CanDeleteId = new Guid("");


            //public static readonly Guid CanViewId = new Guid("");
            //public static readonly Guid CanAddId = new Guid("");
            //public static readonly Guid CanUpdateId = new Guid("");
            //public static readonly Guid CanDeleteId = new Guid("");
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Galaxy SMS data access permission descriptor. </summary>
        ///
        /// <remarks>   Kevin, 1/3/2019. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public class GalaxySMSDataAccessPermission
        {
            //public static readonly Guid CanViewId = new Guid("");
            //public static readonly Guid CanAddId = new Guid("");
            //public static readonly Guid CanUpdateId = new Guid("");
            //public static readonly Guid CanDeleteId = new Guid("");
            /// <summary>   The none. </summary>
            public static readonly Guid None = Guid.Empty;
            public static readonly Guid IsLoggedOn = new Guid("FFFFFFFF-FFFF-FFFF-FFFF-FFFFFFFFFFFF");

            /// <summary>   Identifier for the communication control can view. </summary>
            public static readonly Guid CommunicationControlCanViewId = new Guid("03DF4FF6-B11C-4568-A272-4442A9AE9A60");

            /// <summary>   Identifier for the language can view. </summary>
            public static readonly Guid LanguageCanViewId = new Guid("B55D28BE-DA96-460E-9B7E-0A33D2DC4287");
            /// <summary>   Identifier for the language can add. </summary>
            public static readonly Guid LanguageCanAddId = new Guid("24398A13-6CA4-48E5-9FB7-92533A1EC6A4");
            /// <summary>   Identifier for the language can update. </summary>
            public static readonly Guid LanguageCanUpdateId = new Guid("E25B3E1D-9395-4C91-B5B8-77DAED66E3B4");
            /// <summary>   Identifier for the language can delete. </summary>
            public static readonly Guid LanguageCanDeleteId = new Guid("D2BBA53F-4431-4F7C-8E21-F000A147A27F");

            /// <summary>   Identifier for the entity can view. </summary>
            public static readonly Guid EntityCanViewId = new Guid("21CCA784-A73E-4328-8D3C-DEBD7E34A000");
            /// <summary>   Identifier for the entity can add. </summary>
            public static readonly Guid EntityCanAddId = new Guid("4B4F527F-6563-4AE4-92A2-BE10D40240F5");
            /// <summary>   Identifier for the entity can update. </summary>
            public static readonly Guid EntityCanUpdateId = new Guid("88EF1AF2-F7BA-4F13-BF84-EC1EE091303D");
            /// <summary>   Identifier for the entity can delete. </summary>
            public static readonly Guid EntityCanDeleteId = new Guid("C2871222-0DD3-4E15-BA10-F6C9FA7998DE");

            /// <summary>   Identifier for the application can view. </summary>
            public static readonly Guid ApplicationCanViewId = new Guid("AF1D7067-31EC-423B-BE63-AE6CBEFEF383");
            /// <summary>   Identifier for the application can add. </summary>
            public static readonly Guid ApplicationCanAddId = new Guid("57B85A25-6FDC-47F4-9532-CB2DF634E0F0");
            /// <summary>   Identifier for the application can update. </summary>
            public static readonly Guid ApplicationCanUpdateId = new Guid("A734D672-EA52-4FD8-BB2C-D95A45801557");
            /// <summary>   Identifier for the application can delete. </summary>
            public static readonly Guid ApplicationCanDeleteId = new Guid("2FACD1C1-37FF-49CE-8CCD-F45911D451F4");

            /// <summary>   Identifier for the role can view. </summary>
            public static readonly Guid RoleCanViewId = new Guid("D3490978-31FD-4A77-9363-94846A9B6B51");
            /// <summary>   Identifier for the role can add. </summary>
            public static readonly Guid RoleCanAddId = new Guid("359A79EB-E31A-45CB-B56C-F3EB28C6B594");
            /// <summary>   Identifier for the role can update. </summary>
            public static readonly Guid RoleCanUpdateId = new Guid("517D7D19-A4AE-4D9F-A74D-EBD26E60273D");
            /// <summary>   Identifier for the role can delete. </summary>
            public static readonly Guid RoleCanDeleteId = new Guid("F89AC8A4-59D9-45C3-9D2F-AB102078E684");

            /// <summary>   Identifier for the permission category can view. </summary>
            public static readonly Guid PermissionCategoryCanViewId = new Guid("9396E2F8-1BA0-4826-AA0E-E12E3733306A");
            /// <summary>   Identifier for the permission category can add. </summary>
            public static readonly Guid PermissionCategoryCanAddId = new Guid("69B5D464-2C9C-42B7-BD43-6AE375F30850");
            /// <summary>   Identifier for the permission category can update. </summary>
            public static readonly Guid PermissionCategoryCanUpdateId = new Guid("0F23F80E-2386-46C9-A42F-0837F639F0C2");
            /// <summary>   Identifier for the permission category can delete. </summary>
            public static readonly Guid PermissionCategoryCanDeleteId = new Guid("D955B38C-1001-4D4A-9CFA-7B86902F0E44");

            /// <summary>   Identifier for the permission can view. </summary>
            public static readonly Guid PermissionCanViewId = new Guid("9587DE79-4DE5-43EB-8480-A3A3F8A640D6");
            /// <summary>   Identifier for the permission can add. </summary>
            public static readonly Guid PermissionCanAddId = new Guid("B3269414-081D-4F0C-9199-BF001DA7EC2C");
            /// <summary>   Identifier for the permission can update. </summary>
            public static readonly Guid PermissionCanUpdateId = new Guid("6D650969-7A35-46F8-A967-9F8893558806");
            /// <summary>   Identifier for the permission can delete. </summary>
            public static readonly Guid PermissionCanDeleteId = new Guid("1F8D3219-9953-4330-875D-BC0BD4456E31");

            /// <summary>   Identifier for the user can view. </summary>
            public static readonly Guid UserCanViewId = new Guid("BA51076F-9DF4-4C71-BCB1-BC7D8B9FF5D8");
            /// <summary>   Identifier for the user can add. </summary>
            public static readonly Guid UserCanAddId = new Guid("464CD0CE-A9CF-4838-B650-051F25AB066E");
            /// <summary>   Identifier for the user can update. </summary>
            public static readonly Guid UserCanUpdateId = new Guid("32BBACC8-3A51-4F0B-944A-08610979A0C1");
            /// <summary>   Identifier for the user can delete. </summary>
            public static readonly Guid UserCanDeleteId = new Guid("BFDB27D8-84E2-4409-9546-141C174579E2");

            /// <summary>   Identifier for the country can view. </summary>
            public static readonly Guid CountryCanViewId = new Guid("CDB9C1E7-0485-473D-B33B-D62CDCF385DF");
            /// <summary>   Identifier for the country can add. </summary>
            public static readonly Guid CountryCanAddId = new Guid("C077B8FE-F97E-440F-BF5A-0D17647D58EC");
            /// <summary>   Identifier for the country can update. </summary>
            public static readonly Guid CountryCanUpdateId = new Guid("975FFF6E-9C67-4768-9CBA-1A38BC8EBA66");
            /// <summary>   Identifier for the country can delete. </summary>
            public static readonly Guid CountryCanDeleteId = new Guid("C702FC8B-198F-4B57-BBF3-17B7EA32ED21");

            /// <summary>   Identifier for the state province can view. </summary>
            public static readonly Guid StateProvinceCanViewId = new Guid("4BA6E02D-3CBD-4D5D-BC34-51571385E727");
            /// <summary>   Identifier for the state province can add. </summary>
            public static readonly Guid StateProvinceCanAddId = new Guid("AFBC8B7B-B84A-48F4-A7F8-72DC0AD4A708");
            /// <summary>   Identifier for the state province can update. </summary>
            public static readonly Guid StateProvinceCanUpdateId = new Guid("41BE392E-13B0-4F91-9FFA-67BFBD7FC7D3");
            /// <summary>   Identifier for the state province can delete. </summary>
            public static readonly Guid StateProvinceCanDeleteId = new Guid("2FABFD35-B873-40DD-B13F-8AFEBABEC553");

            /// <summary>   Identifier for the region can view. </summary>
            public static readonly Guid RegionCanViewId = new Guid("A84D18D4-E2BB-4FB9-AEB5-6FAFF22D4CD5");
            /// <summary>   Identifier for the region can add. </summary>
            public static readonly Guid RegionCanAddId = new Guid("C8CF2C67-90F8-410D-A67C-C956EEE6B5EB");
            /// <summary>   Identifier for the region can update. </summary>
            public static readonly Guid RegionCanUpdateId = new Guid("65401169-AF71-4C94-98CF-75D1F07576FF");
            /// <summary>   Identifier for the region can delete. </summary>
            public static readonly Guid RegionCanDeleteId = new Guid("5587AE6A-EB2F-49C2-9E0E-842E0F876AB7");

            /// <summary>   Identifier for the site can view. </summary>
            public static readonly Guid SiteCanViewId = new Guid("12F4FB9D-FBD9-4023-8B74-A24DFFB1B9B8");
            /// <summary>   Identifier for the site can add. </summary>
            public static readonly Guid SiteCanAddId = new Guid("C0ADA9FC-804A-413A-A337-91732DF27DCB");
            /// <summary>   Identifier for the site can update. </summary>
            public static readonly Guid SiteCanUpdateId = new Guid("759EE9EB-C948-495A-B233-B178CE1FE8E0");
            /// <summary>   Identifier for the site can delete. </summary>
            public static readonly Guid SiteCanDeleteId = new Guid("A5BF9EBB-5AF2-44D1-A03C-2F25AAD6B6CB");

            /// <summary>   Identifier for the access portal can view. </summary>
            public static readonly Guid AccessPortalCanViewId = new Guid("8689567A-7028-43D6-92C2-B4BD1CC5F890");
            /// <summary>   Identifier for the access portal can add. </summary>
            public static readonly Guid AccessPortalCanAddId = new Guid("C8F9FFA5-AEB6-4EFB-8091-9C7797CB3719");
            /// <summary>   Identifier for the access portal can update. </summary>
            public static readonly Guid AccessPortalCanUpdateId = new Guid("D9E42E53-D1E3-4512-B761-4841CADDEB1F");
            /// <summary>   Identifier for the access portal can delete. </summary>
            public static readonly Guid AccessPortalCanDeleteId = new Guid("7CD42715-1033-490B-BC51-0C41B2358203");

            /// <summary>   Identifier for the monitored device can view. </summary>
            public static readonly Guid InputDeviceCanViewId = new Guid("CBFF7A23-C0A6-4613-AB73-C52AB709AE49");
            /// <summary>   Identifier for the monitored device can add. </summary>
            public static readonly Guid InputDeviceCanAddId = new Guid("23BBAFFE-22A0-4D38-900E-A6403EB3A798");
            /// <summary>   Identifier for the monitored device can update. </summary>
            public static readonly Guid InputDeviceCanUpdateId = new Guid("C6FA206E-A7DF-440B-96B3-BBC6E8696FB3");
            /// <summary>   Identifier for the monitored device can delete. </summary>
            public static readonly Guid InputDeviceCanDeleteId = new Guid("FAAF3A0F-9021-439F-9C24-5E8876D25F0A");

            /// <summary>   Identifier for the output device can view. </summary>
            public static readonly Guid OutputDeviceCanViewId = new Guid("17275422-2136-4DCF-B55E-3087CDD44E61");
            /// <summary>   Identifier for the output device can add. </summary>
            public static readonly Guid OutputDeviceCanAddId = new Guid("147A1554-9551-40A2-92F4-0AD85E98B3AE");
            /// <summary>   Identifier for the output device can update. </summary>
            public static readonly Guid OutputDeviceCanUpdateId = new Guid("40D7D68C-FC95-41D7-906F-C121DD9A36BD");
            /// <summary>   Identifier for the output device can delete. </summary>
            public static readonly Guid OutputDeviceCanDeleteId = new Guid("37CED93A-7EA7-4C8D-B972-5D494A82C245");

            /// <summary>   Time schedules includes day types, holidays and time periods. </summary>
            public static readonly Guid TimeScheduleCanViewId = new Guid("18420284-1A68-4ED2-B30A-13904C08ED36");
            /// <summary>   Identifier for the time schedule can add. </summary>
            public static readonly Guid TimeScheduleCanAddId = new Guid("3DE225B7-C689-4FAC-9DF8-868B4356C234");
            /// <summary>   Identifier for the time schedule can update. </summary>
            public static readonly Guid TimeScheduleCanUpdateId = new Guid("CD8B245C-3FFA-4682-8E53-7FF15685977D");
            /// <summary>   Identifier for the time schedule can delete. </summary>
            public static readonly Guid TimeScheduleCanDeleteId = new Guid("459B65AD-E706-4959-82A7-564B021935E6");

            /// <summary>   Access Permissions includes access group and door access. </summary>
            public static readonly Guid AccessPermissionCanViewId = new Guid("B8DA02F1-8641-4F1A-B810-FFFD95AD5CAD");
            /// <summary>   Identifier for the access permission can add. </summary>
            public static readonly Guid AccessPermissionCanAddId = new Guid("F7D6A2A1-7D9A-4FDD-9848-A28C73E68606");
            /// <summary>   Identifier for the access permission can update. </summary>
            public static readonly Guid AccessPermissionCanUpdateId = new Guid("D3BA0532-B7B8-415E-A085-A50331CB3F02");
            /// <summary>   Identifier for the access permission can delete. </summary>
            public static readonly Guid AccessPermissionCanDeleteId = new Guid("F27665A6-901B-4007-A9E9-97148D9F2C2B");

            /// <summary>   Identifier for the access profile can view. </summary>
            public static readonly Guid AccessProfileCanViewId = new Guid("A32E7AC1-0F17-4E78-A857-2AFBC837EF91");
            /// <summary>   Identifier for the access profile can add. </summary>
            public static readonly Guid AccessProfileCanAddId = new Guid("F51C18CA-69F5-4FF1-ABB4-F5D007E5F98F");
            /// <summary>   Identifier for the access profile can update. </summary>
            public static readonly Guid AccessProfileCanUpdateId = new Guid("1D71FA37-235C-44A8-A0A7-8E3EEE715245");
            /// <summary>   Identifier for the access profile can delete. </summary>
            public static readonly Guid AccessProfileCanDeleteId = new Guid("321CC6DE-0E39-49A7-95E4-0F8EFF726B14");

            
            /// <summary>   Identifier for the department can view. </summary>
            public static readonly Guid DepartmentCanViewId = new Guid("f5fa0191-4e1e-41fd-805b-cfcab592a0b0");
            /// <summary>   Identifier for the department can add. </summary>
            public static readonly Guid DepartmentCanAddId = new Guid("10a8968a-0539-4e0d-96e4-944c7d98b99e");
            /// <summary>   Identifier for the department can update. </summary>
            public static readonly Guid DepartmentCanUpdateId = new Guid("38ce005f-de95-4dc3-8533-7f0357c5a4bc");
            /// <summary>   Identifier for the department can delete. </summary>
            public static readonly Guid DepartmentCanDeleteId = new Guid("76ba90e0-b8b0-4555-970f-18a48451bb00");

            /// <summary>   Identifier for the person selection item can view. </summary>
            public static readonly Guid PersonSelectionItemCanViewId = new Guid("DF883F9F-1A65-4145-B889-339A8A74C1CE");
            /// <summary>   Identifier for the person selection item can add. </summary>
            public static readonly Guid PersonSelectionItemCanAddId = new Guid("210877F5-FE77-42D5-BA19-55EFEF156840");
            /// <summary>   Identifier for the person selection item can update. </summary>
            public static readonly Guid PersonSelectionItemCanUpdateId = new Guid("F95E5C77-C37D-426D-974B-072355AEB91D");
            /// <summary>   Identifier for the person selection item can delete. </summary>
            public static readonly Guid PersonSelectionItemCanDeleteId = new Guid("DAA943E7-1B48-4031-9CCF-05EF6BF17437");
           
            /// <summary>   Identifier for the badge can view. </summary>
            public static readonly Guid BadgeTemplateCanViewId = new Guid("d786f6fb-c158-4a64-9d5c-e1eb87c45030");
            /// <summary>   Identifier for the badge can add. </summary>
            public static readonly Guid BadgeTemplateCanAddId = new Guid("f5e5330d-fb7c-4fc4-a33a-e3bf1fe5333a");
            /// <summary>   Identifier for the badge can update. </summary>
            public static readonly Guid BadgeTemplateCanUpdateId = new Guid("043effae-0534-43f9-80d8-2fe6c923bc57");
            /// <summary>   Identifier for the badge can delete. </summary>
            public static readonly Guid BadgeTemplateCanDeleteId = new Guid("e853b78c-b98d-4693-92e1-fb15966b6f25");

            /// <summary>   Identifier for the personnel can view. </summary>
            public static readonly Guid PersonnelCanViewId = new Guid("52AC662A-F462-4E85-A332-AA5A6973159A");
            /// <summary>   Identifier for the personnel can add. </summary>
            public static readonly Guid PersonnelCanAddId = new Guid("BEACD348-5258-46A0-9791-E792E4AC26BC");
            /// <summary>   Identifier for the personnel can update. </summary>
            public static readonly Guid PersonnelCanUpdateId = new Guid("22EA4D94-9C37-47A6-9B58-EED85434D51D");
            /// <summary>   Identifier for the personnel can delete. </summary>
            public static readonly Guid PersonnelCanDeleteId = new Guid("3ACBC580-0C8A-48D8-9EFB-98C029801F4C");

            /// <summary>   Identifier for the credential can view. </summary>
            public static readonly Guid CredentialCanViewId = new Guid("FE603CA1-7237-4BFE-BE14-438199FA93E2");
            /// <summary>   Identifier for the credential can add. </summary>
            public static readonly Guid CredentialCanAddId = new Guid("D3D38E9D-6C26-47E4-9899-03E97941D389");
            /// <summary>   Identifier for the credential can update. </summary>
            public static readonly Guid CredentialCanUpdateId = new Guid("E6646A74-E475-4A52-A99F-DBDB2EA81265");
            /// <summary>   Identifier for the credential can delete. </summary>
            public static readonly Guid CredentialCanDeleteId = new Guid("93247C4B-F3D4-4047-8ED5-62099A0B2572");

            ////////////////////////////////////////////////////////////////////////////////////////////////////
            /// <summary>
            /// System hardware includes all access control, alarm panel, elevator and video system devices.
            /// </summary>
            ////////////////////////////////////////////////////////////////////////////////////////////////////

            public static readonly Guid SystemHardwareCanViewId = new Guid("19611017-7367-47DB-A193-DDC7A7C8B57B");
            /// <summary>   Identifier for the system hardware can add. </summary>
            public static readonly Guid SystemHardwareCanAddId = new Guid("24AB27D9-6B0F-4407-9D5B-B1B2C8783EBA");
            /// <summary>   Identifier for the system hardware can update. </summary>
            public static readonly Guid SystemHardwareCanUpdateId = new Guid("3B04435B-28B6-4DE7-95D5-C9734A5ABCFC");
            /// <summary>   Identifier for the system hardware can delete. </summary>
            public static readonly Guid SystemHardwareCanDeleteId = new Guid("5C46698B-4698-4D25-A42C-C575E3467AFE");

            /// <summary>   Identifier for the badge layout can view. </summary>
            public static readonly Guid BadgeLayoutCanViewId = new Guid("74F801AB-FBB5-414F-81FB-F071592992AD");
            /// <summary>   Identifier for the badge layout can add. </summary>
            public static readonly Guid BadgeLayoutCanAddId = new Guid("A15EA9B4-CB86-4FD2-A649-E0F85E90C328");
            /// <summary>   Identifier for the badge layout can update. </summary>
            public static readonly Guid BadgeLayoutCanUpdateId = new Guid("C21B84E3-7E91-4C3D-A7D5-B68411257821");
            /// <summary>   Identifier for the badge layout can delete. </summary>
            public static readonly Guid BadgeLayoutCanDeleteId = new Guid("87B82BF1-75F9-4C31-B9E7-DB47489000C3");
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Galaxy SMS property access permission descriptor. </summary>
        ///
        /// <remarks>   Kevin, 1/3/2019. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public class GalaxySMSPropertyAccessPermission
        {
            /// <summary>   Identifier for the personnel public property access can view. </summary>
            public static readonly Guid PersonnelPublicPropertyAccessCanViewId = new Guid("3CB9CA8C-0A63-4146-8580-30C443944092");
            /// <summary>   Identifier for the personnel public property access can edit. </summary>
            public static readonly Guid PersonnelPublicPropertyAccessCanEditId = new Guid("9FF6FE24-8FB5-4AE2-AFA6-85CFD3187C33");
            /// <summary>   Identifier for the personnel confidential property access can view. </summary>
            public static readonly Guid PersonnelConfidentialPropertyAccessCanViewId = new Guid("714daf25-84a0-4668-b954-fccdf5da9626");
            /// <summary>   Identifier for the personnel confidential property access can edit. </summary>
            public static readonly Guid PersonnelConfidentialPropertyAccessCanEditId = new Guid("74c2e106-b9b2-4ace-be4a-bdeff793aa70");
            /// <summary>   Identifier for the personnel access control property access can view. </summary>
            public static readonly Guid PersonnelAccessControlPropertyAccessCanViewId = new Guid("706bf379-7f1f-4f5f-a220-b0cb5fff05d6");
            /// <summary>   Identifier for the personnel access control property access can edit. </summary>
            public static readonly Guid PersonnelAccessControlPropertyAccessCanEditId = new Guid("72602a4e-c480-4083-b8e6-da0de04857ce");
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Galaxy SMS access portal command permission descriptor. </summary>
        ///
        /// <remarks>   Kevin, 1/3/2019. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public class GalaxySMSAccessPortalCommandPermission
        {
            /// <summary>   The lock. </summary>
            public static readonly Guid Lock = new Guid("401840BD-16DA-4DE6-ADF2-6C72CDC5EA9B");
            /// <summary>   The unlock. </summary>
            public static readonly Guid Unlock = new Guid("554CD9A1-F5C5-40FB-A739-89A2C5C620E7");
            /// <summary>   The unlock momentarily. </summary>
            public static readonly Guid UnlockMomentarily = new Guid("F9616267-3642-4C89-85DC-7D9BE1E25098");
            /// <summary>   The enable. </summary>
            public static readonly Guid Enable = new Guid("ADDA8DB5-3A34-40E1-B594-42681157F26E");
            /// <summary>   The disable. </summary>
            public static readonly Guid Disable = new Guid("94299C0C-0E57-41BC-B915-C8855DCA946F");
            /// <summary>   The relay 2 on. </summary>
            public static readonly Guid Relay2On = new Guid("4A8D826E-9DA8-4D0A-8FDA-00CF84F4C392");
            /// <summary>   The relay 2 off. </summary>
            public static readonly Guid Relay2Off = new Guid("42C649E4-4A98-48D6-A9FB-92BBFC04ABEE");
            /// <summary>   State of the set LED temporary. </summary>
            public static readonly Guid SetLedTemporaryState = new Guid("197CCB41-D55B-434A-9FB9-1F9CF258F75F");
            /// <summary>   The request status. </summary>
            public static readonly Guid RequestStatus = new Guid("36B82241-A44E-4DC0-B1C8-3A4D359B4CD8");            
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Galaxy SMS access portal group command permission descriptor. </summary>
        ///
        /// <remarks>   Kevin, 1/3/2019. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public class GalaxySMSAccessPortalGroupCommandPermission
        {
            /// <summary>   The lock. </summary>
            public static readonly Guid Lock = new Guid("7E672E6B-C90D-4508-9507-288D4E0F1FF7");
            /// <summary>   The unlock. </summary>
            public static readonly Guid Unlock = new Guid("6A2FE856-4301-4393-833E-15881ECF3E3D");
            /// <summary>   The enable. </summary>
            public static readonly Guid Enable = new Guid("B0F2E36A-8CAE-4B9E-9639-D8E63582E23A");
            /// <summary>   The disable. </summary>
            public static readonly Guid Disable = new Guid("6653B6D7-E78E-49FB-B4BD-E3CDF54F1960");
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Galaxy SMS input output group command permission descriptor. </summary>
        ///
        /// <remarks>   Kevin, 1/3/2019. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public class GalaxySMSInputOutputGroupCommandPermission
        {
            /// <summary>   The shunt. </summary>
            public static readonly Guid Shunt = new Guid("AA69FBF9-3450-4082-A3AE-BF697A05975F");
            /// <summary>   The unshunt. </summary>
            public static readonly Guid Unshunt = new Guid("BC470138-8751-4331-8EC7-0AA9D8DB2EBE");
            /// <summary>   The arm. </summary>
            public static readonly Guid Arm = new Guid("0B5F2B57-9EAA-4AD3-980F-2D3A808E379B");
            /// <summary>   The disarm. </summary>
            public static readonly Guid Disarm = new Guid("026A5257-9D9E-41FC-A017-31AEDF889159");
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Galaxy SMS input command permission descriptor. </summary>
        ///
        /// <remarks>   Kevin, 1/3/2019. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public class GalaxySMSInputCommandPermission
        {
            /// <summary>   The disable. </summary>
            public static readonly Guid Disable = new Guid("639D04A7-1F07-4CA1-9F4B-63EA77E468EC");
            /// <summary>   The enable. </summary>
            public static readonly Guid Enable = new Guid("75F2C8D0-7C9B-404C-8A29-439B6894F318");
            /// <summary>   The shunt. </summary>
            public static readonly Guid Shunt = new Guid("20D8CB90-A5AC-4EC4-9B81-895E83847E93");
            /// <summary>   The unshunt. </summary>
            public static readonly Guid Unshunt = new Guid("24CD279C-021A-4940-B695-CCDF91539893");
            /// <summary>   The request status. </summary>
            public static readonly Guid RequestStatus = new Guid("A1CA0B07-BB12-4FC1-8644-E8C3A132312F");  

            /// <summary>   The read voltages. </summary>
            public static readonly Guid ReadVoltages = new Guid("762DB1CD-B026-47B6-B3AF-5E144ACF1743");            
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Galaxy SMS output command permission descriptor. </summary>
        ///
        /// <remarks>   Kevin, 1/3/2019. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public class GalaxySMSOutputCommandPermission
        {
            /// <summary>   The disable. </summary>
            public static readonly Guid Disable = new Guid("EAAADF9C-D53D-4491-8C9F-B15ACAC51613");
            /// <summary>   The enable. </summary>
            public static readonly Guid Enable = new Guid("DAEF0493-0815-4361-9964-A44E8C128B79");
            /// <summary>   The on. </summary>
            public static readonly Guid On = new Guid("1F1BB326-17AD-4412-BA68-39655284CE25");
            /// <summary>   The off. </summary>
            public static readonly Guid Off = new Guid("987886AD-81DD-41AD-958E-7FA41B2F4BC2");
            /// <summary>   The request status. </summary>
            public static readonly Guid RequestStatus = new Guid("E663F9D9-E489-4D47-B5D0-66623D8E3A36");            
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Galaxy SMS elevator output command permission descriptor. </summary>
        ///
        /// <remarks>   Kevin, 1/3/2019. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public class GalaxySMSElevatorOutputCommandPermission
        {
            /// <summary>   The activate momentarily. </summary>
            public static readonly Guid ActivateMomentarily = new Guid("45DCB8FC-A327-4A3B-A148-C062B82ED76A");
            /// <summary>   The early on. </summary>
            public static readonly Guid EarlyOn = new Guid("E28BD703-6DAA-4CF5-87A7-950DFBAD027F");
            /// <summary>   The early off. </summary>
            public static readonly Guid EarlyOff = new Guid("011AD2A1-423A-4825-B01F-FB8ED70AE1FF");
            /// <summary>   The cancel early on. </summary>
            public static readonly Guid CancelEarlyOn = new Guid("AE364965-72D5-4D8B-9B4D-17D644208A24");
            /// <summary>   The cancel early off. </summary>
            public static readonly Guid CancelEarlyOff = new Guid("7F994314-720E-45C2-9941-41B9BFAC8D31");
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>   Galaxy SMS cluster command permission descriptor. </summary>
        ///
        /// <remarks>   Kevin, 1/3/2019. </remarks>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public class GalaxySMSClusterCommandPermission
        {
            /// <summary>   The activate crisis mode. </summary>
            public static readonly Guid ActivateCrisisMode = new Guid("AC1D6FFC-7F2F-4F9E-B217-38D552A9ED90");
            /// <summary>   The reset crisis mode. </summary>
            public static readonly Guid ResetCrisisMode = new Guid("92E965F1-8B03-400A-871C-F2528C74BEEE");
            /// <summary>   The reset panel warm. </summary>
            public static readonly Guid ResetPanelWarm = new Guid("F4262362-6CB4-49E6-AB41-E6CCF7904144");
            /// <summary>   The reset panel cold. </summary>
            public static readonly Guid ResetPanelCold = new Guid("424C7DE5-1506-429C-AB0E-E632CA42C91E");
            /// <summary>   The forgive passback. </summary>
            public static readonly Guid ForgivePassback = new Guid("03EF9E17-A11F-432A-B18C-CC057E35210C");
            /// <summary>   The forgive all passback. </summary>
            public static readonly Guid ForgiveAllPassback = new Guid("4ABD93BC-FEEC-40D1-9BBB-1B4B0EF329BB");
            /// <summary>   The load panel flash. </summary>
            public static readonly Guid LoadPanelFlash = new Guid("DC8DC85A-C978-4A60-9698-3263646B9C49");
            /// <summary>   Buffer for clear log data. </summary>
            public static readonly Guid ClearLogBuffer = new Guid("EA89E659-1272-4CEF-B96E-220B63AA27B0");
            /// <summary>   The delete all cards. </summary>
            public static readonly Guid DeleteAllCards = new Guid("32410D01-12BB-4B88-8F74-FE91D05CE285");
            /// <summary>   The enable credential. </summary>
            public static readonly Guid EnableCredential= new Guid("4EBFD363-4362-437B-B2B2-48781FA06B10");
            /// <summary>   The disable credential. </summary>
            public static readonly Guid DisableCredential = new Guid("B57CBA78-8060-4E05-99C0-925BE77D6461");
        }

        public class GalaxySMSAlarmAlertCommandPermission
        {
            /// <summary>   The lock. </summary>
            public static readonly Guid Acknowledge = new Guid("0B8BABC2-C9B0-4C98-BDCD-A46F6EE2FEE4");
            /// <summary>   The unlock. </summary>
            public static readonly Guid Unacknowledge = new Guid("9E5A948F-54F2-41F6-A1D5-99844AD8A074");
        }
    }
}

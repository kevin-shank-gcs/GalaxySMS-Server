////////////////////////////////////////////////////////////////////////////////////////////////////
// file:	Constants\ApplicationAuditTypeIds.cs
//
// summary:	Implements the application audit type identifiers class
////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Common.Constants
{
    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   An application audit type identifiers. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class ApplicationAuditTypeIds
    {
        /// <summary>   The galaxy SMS application launched. </summary>
        public static readonly Guid GalaxySMS_ApplicationLaunched = new Guid("650E5E92-5967-4A5B-B69E-0C3324321B09");
        /// <summary>   The galaxy SMS application shutdown. </summary>
        public static readonly Guid GalaxySMS_ApplicationShutdown = new Guid("E81131FC-2ACE-4386-8CA3-27F2FB637DE3");
        /// <summary>   The galaxy SMS user sign in request. </summary>
        public static readonly Guid GalaxySMS_UserSignInRequest = new Guid("7E16B997-048B-461C-8D39-B6C380C62D02");
        /// <summary>   The galaxy SMS user sign out. </summary>
        public static readonly Guid GalaxySMS_UserSignOut = new Guid("568A3683-2A6F-4209-9D11-2DF19F1F741B");
        /// <summary>   The galaxy SMS user sign in result success. </summary>
        public static readonly Guid GalaxySMS_UserSignInResultSuccess = new Guid("ABC696E3-014D-4121-9A83-A0A6FE732CD4");
        /// <summary>   The galaxy SMS user sign in success information none. </summary>
        public static readonly Guid GalaxySMS_UserSignInSuccessInfoNone = new Guid("5585C450-D731-4D62-98C4-BACF1E72615F");

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// The galaxy SMS user sign in success information user account soon to expire.
        /// </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static readonly Guid GalaxySMS_UserSignInSuccessInfoUserAccountSoonToExpire = new Guid("A5D952F4-C540-44D6-B95D-34B080D8FEE8");
        /// <summary>   The galaxy SMS user sign in success information password must be changed. </summary>
        public static readonly Guid GalaxySMS_UserSignInSuccessInfoPasswordMustBeChanged = new Guid("18E2A69E-6658-4654-85A9-B751545F02CB");
        /// <summary>   Name of the galaxy SMS user sign in result invalid user. </summary>
        public static readonly Guid GalaxySMS_UserSignInResultInvalidUserName = new Guid("0E9D2824-DE07-4737-A387-679D5988FC87");
        /// <summary>   The galaxy SMS user sign in result invalid password. </summary>
        public static readonly Guid GalaxySMS_UserSignInResultInvalidPassword = new Guid("477FAE58-205C-42B2-A15C-A691DAE2E234");
        /// <summary>   The galaxy SMS user sign in result user account is not active. </summary>
        public static readonly Guid GalaxySMS_UserSignInResultUserAccountIsNotActive = new Guid("D8FD6994-1445-405F-9E41-F742389FB10B");
        /// <summary>   The galaxy SMS user sign in result user account is locked out. </summary>
        public static readonly Guid GalaxySMS_UserSignInResultUserAccountIsLockedOut = new Guid("35417618-2107-4559-AC4E-AF168B2AD27A");
        /// <summary>   The galaxy SMS user sign in result application not permitted. </summary>
        public static readonly Guid GalaxySMS_UserSignInResultApplicationNotPermitted = new Guid("10404C47-9153-4B02-93F7-BBE8EFF4F548");
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    /// <summary>   An application audit type codes. </summary>
    ///
    /// <remarks>   Kevin, 1/3/2019. </remarks>
    ////////////////////////////////////////////////////////////////////////////////////////////////////

    public class ApplicationAuditTypeCodes
    {
        /// <summary>   The galaxy SMS application launched. </summary>
        public static readonly string GalaxySMS_ApplicationLaunched = "ApplicationLaunched";
        /// <summary>   The galaxy SMS application shutdown. </summary>
        public static readonly string GalaxySMS_ApplicationShutdown = "ApplicationShutdown";
        /// <summary>   The galaxy SMS user sign in request. </summary>
        public static readonly string GalaxySMS_UserSignInRequest = "UserSignInRequest";
        /// <summary>   The galaxy SMS user sign out. </summary>
        public static readonly string GalaxySMS_UserSignOut = "UserSignOut";
        /// <summary>   The galaxy SMS user sign in result success. </summary>
        public static readonly string GalaxySMS_UserSignInResultSuccess = "UserSignInResultSuccess";
        /// <summary>   The galaxy SMS user sign in success information none. </summary>
        public static readonly string GalaxySMS_UserSignInSuccessInfoNone = "UserSignInSuccessInfoNone";

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// The galaxy SMS user sign in success information user account soon to expire.
        /// </summary>
        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public static readonly string GalaxySMS_UserSignInSuccessInfoUserAccountSoonToExpire = "UserSignInSuccessInfoUserAccountSoonToExpire";
        /// <summary>   The galaxy SMS user sign in success information password must be changed. </summary>
        public static readonly string GalaxySMS_UserSignInSuccessInfoPasswordMustBeChanged = "UserSignInSuccessInfoPasswordMustBeChanged";
        /// <summary>   Name of the galaxy SMS user sign in result invalid user. </summary>
        public static readonly string GalaxySMS_UserSignInResultInvalidUserName = "UserSignInResultInvalidUserName";
        /// <summary>   The galaxy SMS user sign in result invalid password. </summary>
        public static readonly string GalaxySMS_UserSignInResultInvalidPassword = "UserSignInResultInvalidPassword";
        /// <summary>   The galaxy SMS user sign in result user account is not active. </summary>
        public static readonly string GalaxySMS_UserSignInResultUserAccountIsNotActive = "UserSignInResultUserAccountIsNotActive";
        /// <summary>   The galaxy SMS user sign in result user account is locked out. </summary>
        public static readonly string GalaxySMS_UserSignInResultUserAccountIsLockedOut = "UserSignInResultUserAccountIsLockedOut";
        /// <summary>   The galaxy SMS user sign in result application not permitted. </summary>
        public static readonly string GalaxySMS_UserSignInResultApplicationNotPermitted = "UserSignInResultApplicationNotPermitted";
    }
}
        

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCS.Framework.Badging.IdProducer.Entities
{
    //public class User
    //{
    //    public int ID { get; set; }
    //    public int SubscriptionID { get; set; }
    //    public int InitialSubscriptionID { get; set; }
    //    public int SubscriptionOwnerTypeID { get; set; }
    //    public object RoleID { get; set; }
    //    public long PermissionBits { get; set; }
    //    public string UserName { get; set; }
    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }
    //    public string Password { get; set; }
    //    public object TimeZone { get; set; }
    //    public string PreferredLanguageCode { get; set; }
    //    public bool IsEmailVerified { get; set; }
    //    public object EmailVerificationGuid { get; set; }
    //    public object ResetPswGuid { get; set; }
    //    public bool MarkedForDeletion { get; set; }
    //}


    public class UsersResponse
    {
        public User[] Users { get; set; }
        public bool IsSuccessful { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorCodeStr { get; set; }
        public string ErrorMessage { get; set; }
        public string UserWhoMadeCall { get; set; }
    }

    public class User
    {
        public int ID { get; set; }
        public int SubscriptionID { get; set; }
        public int InitialSubscriptionID { get; set; }
        public int SubscriptionOwnerTypeID { get; set; }
        public int? RoleID { get; set; }
        public long PermissionBits { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public object TimeZone { get; set; }
        public string PreferredLanguageCode { get; set; }
        public bool IsEmailVerified { get; set; }
        public object EmailVerificationGuid { get; set; }
        public object ResetPswGuid { get; set; }
        public bool MarkedForDeletion { get; set; }
    }

}

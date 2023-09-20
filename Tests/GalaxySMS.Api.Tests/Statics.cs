using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalaxySMS.Api.Tests
{
    public class Statics
    {
        public static string ApiUri = "http://localhost:25000/api";
        public static string UserName = "administrator";
        public static string Password = "P@$$word";
        public static string SignInResultNull = "_signInResult == null";
        public static System.Guid TestEntityId = new Guid("00000000-0000-0000-0000-00000000ffff");
    }
}

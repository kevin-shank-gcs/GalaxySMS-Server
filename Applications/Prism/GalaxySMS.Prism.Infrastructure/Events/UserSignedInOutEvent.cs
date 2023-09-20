using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaxySMS.Client.Entities;

namespace GalaxySMS.Prism.Infrastructure.Events
{
    public class UserSignedInOutEvent
    {
        public enum SignedInOutAction { SignedIn, SignedOut}

        public UserSignedInOutEvent(UserSessionToken userSessionToken, SignedInOutAction userAction)
        {
            UserAction = userAction;
            UserSessionToken = userSessionToken;
            Message = string.Empty;
        }

        public UserSignedInOutEvent(UserSessionToken userSessionToken, SignedInOutAction userAction, string message)
        {
            UserAction = userAction;
            UserSessionToken = userSessionToken;
            Message = message;
        }

        public UserSessionToken UserSessionToken { get; set; }
        public string Message { get; set; }
        public SignedInOutAction UserAction { get; set; }

    }

}

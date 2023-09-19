using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using GalaxySMS.Common.Constants;
using GalaxySMS.Common.Interfaces;
using Microsoft.AspNetCore.Http;

namespace GalaxySMS.Data.NetCore.Helpers
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            Claims = httpContextAccessor.HttpContext?.User?.Claims.AsEnumerable().Select(item => new KeyValuePair<string, string>(item.Type, item.Value)).ToList();
            SessionId = Claims?.FirstOrDefault(o => o.Key == GalaxySMSClaimTypes.SessionId).Value;
        }

        public string UserId { get; }
        public List<KeyValuePair<string, string>> Claims { get; set; }

        public string SessionId { get; }
    }
}

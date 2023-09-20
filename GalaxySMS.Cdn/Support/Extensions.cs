using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace GalaxySMS.Cdn.Support
{
    public static class Extensions
    {
        public static StringValues GetAuthHeader(this ControllerBase controller)
        {
            var h = new StringValues();
            if (controller.Request == null)
                return h;

            if (controller.Request.Headers.TryGetValue("Authorization", out h))
                return h;
            return h;
        }

        public static StringValues GetAuthHeader(this HttpRequest request)
        {
            var h = new StringValues();
            if (request == null)
                return h;

            if (request.Headers.TryGetValue("Authorization", out h))
                return h;
            return h;
        }
        public static StringValues GetHeader(this ControllerBase controller, string key)
        {
            var h = new StringValues();
            if (controller.Request == null)
                return h;

            if (controller.Request.Headers.TryGetValue(key, out h))
                return h;
            return h;
        }

        public static StringValues GetHeader(this HttpRequest request, string key)
        {
            var h = new StringValues();
            if (request == null)
                return h;

            if (request.Headers.TryGetValue(key, out h))
                return h;
            return h;
        }
        public static Guid GetHeaderGuidValue(this HttpRequest request, string key)
        {
            if (request == null)
                return Guid.Empty;

            var h = new StringValues();

            if (!request.Headers.TryGetValue(key, out h)) return Guid.Empty;
            if (h.Count > 0)
            {
                return h[0].ToGuid();
            }
            return Guid.Empty;
        }
        public static string GetHeaderStringValue(this HttpRequest request, string key)
        {
            if (request == null)
                return string.Empty;

            var h = new StringValues();

            if (!request.Headers.TryGetValue(key, out h)) return string.Empty;
            if (h.Count > 0)
            {
                return h[0];
            }
            return string.Empty;
        }
        public static JwtSecurityToken GetJwtSecurityToken(this ControllerBase controller)
        {
            JwtSecurityToken jwtToken = null;
            var authHeader = controller.GetAuthHeader();
            if (authHeader.Count > 0)
            {
                var bearerPrefix = "bearer ";
                if (string.IsNullOrEmpty(authHeader[0]) || String.Compare(authHeader[0].Substring(0, bearerPrefix.Length).ToLower(), bearerPrefix, StringComparison.Ordinal) != 0)
                    throw new ArgumentException("The request is missing a valid JWT bearer Authorization header.");
                var incomingToken = authHeader[0].Substring(bearerPrefix.Length);
                var handler = new JwtSecurityTokenHandler();
                jwtToken = handler.ReadJwtToken(incomingToken);
            }
            return jwtToken;
        }

        public static JwtSecurityToken GetJwtSecurityToken(this HttpRequest request)
        {
            JwtSecurityToken jwtToken = null;
            var authHeader = request.GetAuthHeader();
            if (authHeader.Count > 0)
            {
                var bearerPrefix = "bearer ";
                if (string.IsNullOrEmpty(authHeader[0]) || String.Compare(authHeader[0].Substring(0, bearerPrefix.Length).ToLower(), bearerPrefix, StringComparison.Ordinal) != 0)
                    throw new ArgumentException("The request is missing a valid JWT bearer Authorization header.");
                var incomingToken = authHeader[0].Substring(bearerPrefix.Length);
                var handler = new JwtSecurityTokenHandler();
                jwtToken = handler.ReadJwtToken(incomingToken);
            }
            return jwtToken;
        }

        public static Claim GetClaim(this JwtSecurityToken token, string claimType)
        {
            if (token == null || string.IsNullOrEmpty(claimType))
                return null;

            return token.Claims.FirstOrDefault(c => c.Type == claimType);
        }

        public static Guid GetClaimGuid(this JwtSecurityToken token, string claimType)
        {
            var c = token.GetClaim(claimType);
            if (c == null)
                return Guid.Empty;

            return c.Value.ToGuid();
        }

        public static Guid GetClaimGuid(this ControllerBase controller, string claimType)
        {
            var token = controller.GetJwtSecurityToken();
            if (token == null)
                return Guid.Empty;

            var c = token.GetClaim(claimType);
            if (c == null)
                return Guid.Empty;

            return c.Value.ToGuid();
        }

        public static string GetClaimString(this JwtSecurityToken token, string claimType)
        {
            var c = token.GetClaim(claimType);
            if (c == null)
                return string.Empty;

            return c.Value;
        }

        public static string GetClaimString(this ControllerBase controller, string claimType)
        {
            var token = controller.GetJwtSecurityToken();
            if (token == null)
                return string.Empty;

            var c = token.GetClaim(claimType);
            if (c == null)
                return string.Empty;

            return c.Value;
        }

        public static Guid ToGuid(this string s)
        {
            var g = Guid.Empty;
            if (Guid.TryParse(s, out g))
                return g;
            return Guid.Empty;
        }


    }
}

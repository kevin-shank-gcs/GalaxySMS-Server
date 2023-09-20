using GalaxySMS.Cdn.Support;

namespace GalaxySMS.Cdn.Middleware
{
    // This is needed to overcome a limitation of .NET Core and how OPTIONS / preflight requests are handled. By default, a 204 status code is returned, which is technically proper, however Firefox
    // blocks this response and requires 200 instead. 

    public class OptionsMiddleware
    {
        private readonly RequestDelegate _next;

        public OptionsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {
            return BeginInvoke(context);
        }

        private Task BeginInvoke(HttpContext context)
        {
            context.Response.Headers.Add("Access-Control-Allow-Origin", new[] { (string)context.Request.Headers["Origin"] });

            // Allow all headers. Take headers from incoming request and copy them to the response
            context.Response.Headers.Add("Access-Control-Allow-Headers", new[] { (string)context.Request.Headers["Access-Control-Request-Headers"] });

            // Allow only these methods
            context.Response.Headers.Add("Access-Control-Allow-Methods", new[] { "GET, POST, PUT, DELETE, OPTIONS" }); //{ context.Request.Method });

            context.Response.Headers.Add("Access-Control-Allow-Credentials", new[] { "true" });

            // Set the max age
            context.Response.Headers.Add("Access-Control-Max-Age", new[] { Globals.Instance.CorsMaxAge.ToString() });

            if (context.Request.Method == "OPTIONS")
            {
                context.Response.StatusCode = 200;
                return context.Response.WriteAsync("OK");
            }

            return _next.Invoke(context);
        }


    }

    public static class OptionsMiddlewareExtensions
    {
        public static IApplicationBuilder UseOptions(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<OptionsMiddleware>();
        }
    }
}
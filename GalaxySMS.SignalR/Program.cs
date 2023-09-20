using GalaxySMS.SignalR.Hubs;
using GCS.Framework.Utilities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting.WindowsServices;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Security.Claims;
using System.Text;

var configuration = new ConfigurationBuilder()
    .SetBasePath(SystemUtilities.MyFolderLocation)
    .AddJsonFile("appsettings.json")
    .Build();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .CreateLogger();

IWebHostEnvironment _env;
bool _useHttps = false;
bool _logApiRequests = false;
bool _ignoreNullValues = false;

IConfiguration Configuration = null;

string MyAllowAnyOrigin = "_myAllowAnyOrigin";

try
{
    //Serilog.Debugging.SelfLog.Enable(msg => System.Diagnostics.Debug.WriteLine(msg));
    var file = File.CreateText($"{Path.GetTempPath()}{GCS.Framework.Utilities.SystemUtilities.MyProcessName}-Serilog.log");
    Serilog.Debugging.SelfLog.Enable(TextWriter.Synchronized(file));
    Log.Information("Starting GalaxySMS SignalR host");

    var options = new WebApplicationOptions
    {
        ApplicationName = typeof(Program).Assembly.FullName,
        Args = args,
        ContentRootPath = WindowsServiceHelpers.IsWindowsService() ? AppContext.BaseDirectory : default
    };
    var builder = WebApplication.CreateBuilder(options);
    _env = builder.Environment;
    Configuration = builder.Configuration;
    _useHttps = Convert.ToBoolean(Configuration["UseHttps"]);
    _logApiRequests = Convert.ToBoolean(Configuration["LogApiRequests"]);
    _ignoreNullValues = Convert.ToBoolean(Configuration["IgnoreNullValues"]);

    var _corsMaxAge = Convert.ToInt32(Configuration["Cors:MaxAge"]);

    builder.Host.UseWindowsService()
        .UseSerilog();

    // Add CORS Policy
    builder.Services.AddCors(option =>
    {
        option.AddPolicy("cors", policy =>
        {
            policy.AllowAnyHeader().AllowAnyMethod().SetIsOriginAllowed((host) => true).AllowCredentials();
        });
    });

    builder.Services.AddSignalR();

    builder.Services.Configure<CookiePolicyOptions>(options =>
    {
        // This lambda determines whether user consent for non-essential cookies is needed for a given request.
        options.CheckConsentNeeded = context => true;
        options.MinimumSameSitePolicy = SameSiteMode.None;
    });

    builder.Services.AddHttpContextAccessor();
    builder.Services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();

    //builder.Services.AddAuthorization(options =>
    //{
    //    //options.AddPolicy(Roles.GalaxyAdmin.ToString(), policy => policy.RequireRole(Roles.GalaxyAdmin.ToString()));
    //    //options.AddPolicy(Roles.GalaxyUser.ToString(), policy => policy.RequireRole(Roles.GalaxyUser.ToString()));
    //    //options.AddPolicy(Roles.GalaxyRep.ToString(), policy => policy.RequireRole(Roles.GalaxyRep.ToString()));
    //    //options.AddPolicy(Roles.Dealer.ToString(), policy => policy.RequireRole(Roles.Dealer.ToString()));
    //    //options.AddPolicy(Roles.EndUser.ToString(), policy => policy.RequireRole(Roles.EndUser.ToString()));
    //    //options.AddPolicy("Has Some Claim", policy => policy.RequireClaim("SomeClaimName", "123", "456"));
    //});

    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(cfg =>
        {
            cfg.RequireHttpsMetadata = false;
            cfg.SaveToken = true;
            cfg.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidIssuer = Configuration["Tokens:Issuer"],
                ValidAudience = Configuration["Tokens:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Tokens:Key"])),
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ClockSkew = TimeSpan.FromSeconds(5),
            };
            cfg.Events = new JwtBearerEvents
            {
                OnMessageReceived = context =>
                {
                    var accessToken = string.Empty;
                    if (context.Request.Query.ContainsKey("access_token"))
                    {
                        accessToken = context.Request.Query["access_token"];
                    }
                    else if (context.Request.Headers.TryGetValue("Authorization", out var value) && value.Count > 0)
                    {
                        accessToken = value[0].Substring("Bearer ".Length);
                    }
                    // If the request is for our hub...
                    var path = context.HttpContext.Request.Path;
                    if (!string.IsNullOrEmpty(accessToken) &&
                        (path.StartsWithSegments("/signalr/galaxySMSSignalRHub")))
                    {
                        // Read the token out of the query string
                        context.Token = accessToken;
                    }
                    return Task.CompletedTask;
                }
            };
        });

    builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy(JwtBearerDefaults.AuthenticationScheme, policy =>
        {
            policy.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);
            policy.RequireClaim(ClaimTypes.NameIdentifier);
        });
        //options.AddPolicy(Roles.GalaxyAdmin.ToString(), policy => policy.RequireRole(Roles.GalaxyAdmin.ToString()));
        //options.AddPolicy(Roles.GalaxyUser.ToString(), policy => policy.RequireRole(Roles.GalaxyUser.ToString()));
        //options.AddPolicy(Roles.GalaxyRep.ToString(), policy => policy.RequireRole(Roles.GalaxyRep.ToString()));
        //options.AddPolicy(Roles.Dealer.ToString(), policy => policy.RequireRole(Roles.Dealer.ToString()));
        //options.AddPolicy(Roles.EndUser.ToString(), policy => policy.RequireRole(Roles.EndUser.ToString()));
        //options.AddPolicy("Has Some Claim", policy => policy.RequireClaim("SomeClaimName", "123", "456"));
    });



    var app = builder.Build();
    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    if (_useHttps)
        app.UseHttpsRedirection();
    app.UseCors("cors");
    app.UseRouting();
    app.UseAuthorization();
    app.UseAuthentication();
    app.MapHub<GalaxySMSSignalRHub>("/signalr/galaxysmssignalrhub");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "GalaxySMS SignalR host terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}


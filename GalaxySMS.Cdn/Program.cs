using GalaxySMS.Cdn.Support;
using GCS.Core.Common.NetCore.Middleware;
using GCS.Framework.Utilities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting.WindowsServices;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Serilog;
using Swashbuckle.AspNetCore.Filters;
using System.Text;
using System.Text.Json.Serialization;

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
long _logMaxRequestLength = 0;
long _logMaxResponseLength = 0;
bool _ignoreNullValues = false;
string _fileStoragePath = string.Empty;

IConfiguration Configuration = null;

string MyAllowAnyOrigin = "_myAllowAnyOrigin";

try
{
    //Serilog.Debugging.SelfLog.Enable(msg => System.Diagnostics.Debug.WriteLine(msg));
    var file = File.CreateText($"{Path.GetTempPath()}{GCS.Framework.Utilities.SystemUtilities.MyProcessName}-Serilog.log");
    Serilog.Debugging.SelfLog.Enable(TextWriter.Synchronized(file));
    Log.Information("Starting GalaxySMS Cdn host");
    //var builder = WebApplication.CreateBuilder(args);
    //var contentRootPath = Path.GetFullPath(Directory.GetCurrentDirectory());
    var options = new WebApplicationOptions
    {
        ApplicationName = typeof(Program).Assembly.FullName,
        Args = args,
        ContentRootPath = WindowsServiceHelpers.IsWindowsService() ? AppContext.BaseDirectory : default
    };
    var builder = WebApplication.CreateBuilder(options);

    //var builder = WebApplication.CreateBuilder(new WebApplicationOptions
    //{
    //    ApplicationName = typeof(Program).Assembly.FullName,
    //    ContentRootPath = Path.GetFullPath(Directory.GetCurrentDirectory()),
    //    //WebRootPath = "wwwroot",
    //    Args = args
    //});

    _env = builder.Environment;
    Configuration = builder.Configuration;
    _useHttps = Convert.ToBoolean(Configuration["UseHttps"]);
    _logApiRequests = Convert.ToBoolean(Configuration["ApiLogging:LogApiRequests"]);
    _logMaxRequestLength = Convert.ToInt64(Configuration["ApiLogging:LogMaxRequestLength"]);
    _logMaxResponseLength = Convert.ToInt64(Configuration["ApiLogging:LogMaxResponseLength"]);
    _ignoreNullValues = Convert.ToBoolean(Configuration["IgnoreNullValues"]);
    _fileStoragePath = Configuration["FileStoragePath"];

    Globals.Instance.CorsMaxAge = Convert.ToInt32(Configuration["Cors:MaxAge"]);


    var myLocation = GCS.Framework.Utilities.SystemUtilities.MyFolderLocation;
    var pathParts = GCS.Framework.Utilities.SystemUtilities.MyFolderLocation.Split('\\');
    var goodParts = new List<String>();
    var cdnPath = string.Empty;
    foreach (var path in pathParts)
    {
        var p = path.ToLower();
        if (p != "bin" && p != "debug" && p != "release" && !p.StartsWith("net"))
        {
            goodParts.Add(path);
        }
    }

    //goodParts.RemoveAt(goodParts.Count - 1);
    foreach (var p in goodParts)
    {
        cdnPath += $"{p}\\";
    }


    Globals.Instance.CdnConnectionInfo.FileSystemPath = _fileStoragePath;
    if (string.IsNullOrEmpty(Globals.Instance.CdnConnectionInfo.FileSystemPath))
    {
        Globals.Instance.CdnConnectionInfo.FileSystemPath = $"{cdnPath}uploads";
        //if (!Directory.Exists(Globals.Instance.CdnConnectionInfo.FileSystemPath))
        //    Directory.CreateDirectory(Globals.Instance.CdnConnectionInfo.FileSystemPath);
    }

    Globals.Instance.CdnConnectionInfo.PublicUrl = $"{Configuration["PublicUrlForLinks"]}";


    builder.Host.UseWindowsService()
        .UseSerilog();


    builder.Services.AddCors(opt =>
    {
        opt.AddPolicy(name: MyAllowAnyOrigin,
        b =>
        {
            b.AllowAnyOrigin();
            b.AllowAnyHeader();
            b.WithMethods("GET", "POST", "PUT", "DELETE", "OPTIONS");
            b.SetPreflightMaxAge(new TimeSpan(0, 0, Globals.Instance.CorsMaxAge));
        });
    });


    builder.Services.AddLocalization(o =>
    {
        // We will put our translations in a folder called Resources
        o.ResourcesPath = "Resources";
    });

    builder.Services.Configure<CookiePolicyOptions>(options =>
    {
        // This lambda determines whether user consent for non-essential cookies is needed for a given request.
        options.CheckConsentNeeded = context => true;
        options.MinimumSameSitePolicy = SameSiteMode.None;
    });

    builder.Services.AddHttpContextAccessor();
    builder.Services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();

    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    builder.Services.AddAuthorization(options =>
    {
        //options.AddPolicy(Roles.GalaxyAdmin.ToString(), policy => policy.RequireRole(Roles.GalaxyAdmin.ToString()));
        //options.AddPolicy(Roles.GalaxyUser.ToString(), policy => policy.RequireRole(Roles.GalaxyUser.ToString()));
        //options.AddPolicy(Roles.GalaxyRep.ToString(), policy => policy.RequireRole(Roles.GalaxyRep.ToString()));
        //options.AddPolicy(Roles.Dealer.ToString(), policy => policy.RequireRole(Roles.Dealer.ToString()));
        //options.AddPolicy(Roles.EndUser.ToString(), policy => policy.RequireRole(Roles.EndUser.ToString()));
        //options.AddPolicy("Has Some Claim", policy => policy.RequireClaim("SomeClaimName", "123", "456"));
    });

    builder.Services.AddAuthentication()
        .AddCookie(cfg => cfg.SlidingExpiration = true)
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
        });

    builder.Services.ConfigureApplicationCookie(
        options =>
        {
            options.LoginPath = "/Home/Login";
            // This prevents unauthorized calls to the API from being redirected to the login page.
            // https://app.pluralsight.com/player?course=aspdotnetcore-implementing-securing-api&author=shawn-wildermuth&name=aspdotnetcore-implementing-securing-api-m7&clip=6&mode=live
            options.Events = new CookieAuthenticationEvents()
            {
                OnRedirectToLogin = (ctx) =>
                {
                    if (ctx.Request.Path.StartsWithSegments("/api") && ctx.Response.StatusCode == 200)
                    {
                        ctx.Response.StatusCode = 401;
                        return Task.CompletedTask;
                    }
                    ctx.Response.Redirect(ctx.RedirectUri);
                    return Task.FromResult<object>(null);
                },
                OnRedirectToAccessDenied = (ctx) =>
                {
                    if (ctx.Request.Path.StartsWithSegments("/api") && ctx.Response.StatusCode == 200)
                    {
                        ctx.Response.StatusCode = 403;
                        return Task.CompletedTask;
                    }
                    ctx.Response.Redirect(ctx.RedirectUri);
                    return Task.FromResult<object>(null);
                },
            };
        });


    builder.Services.AddMvc(o =>
        {
            if (_env.IsDevelopment())
                o.SslPort = 5003;
            if (_useHttps)
                o.Filters.Add(new RequireHttpsAttribute());
            o.Filters.Add(typeof(ExtractHeadersActionFilter));

        })
        .SetCompatibilityVersion(CompatibilityVersion.Latest);

    // Add services to the container.
    builder.Services.AddRazorPages();
    builder.Services.AddControllers()
        .AddNewtonsoftJson(options =>
        {
            options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            if (_ignoreNullValues)
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
        }).AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            if (_ignoreNullValues)
                options.JsonSerializerOptions.IgnoreNullValues = true;
        });

    // Version support
    //https://dotnetdetail.net/implement-api-versioning-in-asp-net-core-5-web-api/#:~:text=Implement%20API%20versioning%20in%20Asp%20Net%20Core%205.0,4%20Step%20%23%204%3A%20Configure%20API%20Versioning.%20
    builder.Services.AddApiVersioning(config =>
    {
        config.DefaultApiVersion = ApiVersion.Default;// new ApiVersion(1, 0);
        config.AssumeDefaultVersionWhenUnspecified = true;
        config.ReportApiVersions = true;
        config.ApiVersionReader = ApiVersionReader.Combine(
            new MediaTypeApiVersionReader("x-api-version"),
            new HeaderApiVersionReader("x-api-version"));
    });

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "GalaxySMS Cdn",
            Description = "Content Delivery Network for GalaxySMS static files",
            TermsOfService = null
        });
        options.OperationFilter<SwaggerOperationFilter>();
        options.OperationFilter<SwaggerHeaderFilter>();
        options.ExampleFilters();
        var securityScheme = new OpenApiSecurityScheme()
        {
            Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
            Name = "Authorization",
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            },
        };
        options.AddSecurityDefinition("Bearer", securityScheme);
        options.AddSecurityRequirement(new OpenApiSecurityRequirement {
            {
                securityScheme,
                new [] {
                    "readAccess",
                    "writeAccess"
                }
            }
        });

        options.IncludeXmlComments(GetLocalXmlCommentsPath());
        options.IncludeXmlComments(GetDataClassesXmlCommentsPath());
        options.CustomSchemaIds(x => x.FullName);
    });

    builder.Services.AddSwaggerExamplesFromAssemblyOf<UploadExamples>();


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

    var staticOptions = new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider(
            Path.Combine(builder.Environment.ContentRootPath, "uploads")),
        RequestPath = "/uploads"
    };

    if (!string.IsNullOrEmpty(_fileStoragePath))
    {
        staticOptions.FileProvider = new PhysicalFileProvider(_fileStoragePath);
    }

    app.UseStaticFiles(staticOptions);

    app.UseRouting();

    app.UseAuthorization();

    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
    });

    app.UseReDoc(c =>
    {
        c.RoutePrefix = "redocs";
        c.SpecUrl("/v1/swagger.json");
    });

    //Add our new middleware to the pipeline
    if (_logApiRequests)
    {
      // app.UseMiddleware<ApiLoggingMiddleware>();
        app.UseMiddleware<ApiLoggingMiddleware>(new ApiLoggingOptions()
        {
            MaxRequestLength = _logMaxRequestLength,
            MaxResponseLength = _logMaxResponseLength
        });
    }

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });

    app.MapRazorPages();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "GalaxySMS Cdn host terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}



string GetLocalXmlCommentsPath()
{
    var app = System.AppContext.BaseDirectory;
    return System.IO.Path.Combine(app, "GalaxySMS.Cdn.xml");
}

string GetDataClassesXmlCommentsPath()
{
    var app = System.AppContext.BaseDirectory;
    return System.IO.Path.Combine(app, "GalaxySMS.Business.Entities.Api.NetCore.xml");
}

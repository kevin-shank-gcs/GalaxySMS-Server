extern alias NetCoreCommon;

using GalaxySMS.Api.Middleware;
//using AutoMapper;
using GalaxySMS.Api.Support;
using GalaxySMS.Client.SDK.DataClasses;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NetCoreCommon::GCS.Core.Common.NetCore.Middleware;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GalaxySMS.Api
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;
        private bool _useHttps = false;
        private bool _logApiRequests = false;
        private long _logMaxRequestLength = 0;
        private long _logMaxResponseLength = 0;
        private bool _ignoreNullValues = false;
        readonly string MyAllowAnyOrigin = "_myAllowAnyOrigin";

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            _env = env;
            Configuration = configuration;
            _useHttps = Convert.ToBoolean(Configuration["UseHttps"]);
            _logApiRequests = Convert.ToBoolean(Configuration["ApiLogging:LogApiRequests"]);
            _logMaxRequestLength = Convert.ToInt64(Configuration["ApiLogging:LogMaxRequestLength"]);
            _logMaxResponseLength = Convert.ToInt64(Configuration["ApiLogging:LogMaxResponseLength"]);
            _ignoreNullValues = Convert.ToBoolean(Configuration["IgnoreNullValues"]);
            Globals.Instance.CorsMaxAge = Convert.ToInt32(Configuration["Cors:MaxAge"]);
            Globals.Instance.MaxUploadFileSize = Convert.ToInt64(Configuration["MaxUploadFileSize"]);

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors(opt =>
            {
                opt.AddPolicy(name: MyAllowAnyOrigin,
                builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyHeader();
                    builder.WithMethods("GET", "POST", "PUT", "DELETE", "OPTIONS");
                    builder.SetPreflightMaxAge(new TimeSpan(0, 0, Globals.Instance.CorsMaxAge));
                });
            });


            services.AddLocalization(o =>
            {
                // We will put our translations in a folder called Resources
                o.ResourcesPath = "Resources";
            });

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddHttpContextAccessor();
            services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddAuthorization(options =>
            {
                //options.AddPolicy(Roles.GalaxyAdmin.ToString(), policy => policy.RequireRole(Roles.GalaxyAdmin.ToString()));
                //options.AddPolicy(Roles.GalaxyUser.ToString(), policy => policy.RequireRole(Roles.GalaxyUser.ToString()));
                //options.AddPolicy(Roles.GalaxyRep.ToString(), policy => policy.RequireRole(Roles.GalaxyRep.ToString()));
                //options.AddPolicy(Roles.Dealer.ToString(), policy => policy.RequireRole(Roles.Dealer.ToString()));
                //options.AddPolicy(Roles.EndUser.ToString(), policy => policy.RequireRole(Roles.EndUser.ToString()));
                //options.AddPolicy("Has Some Claim", policy => policy.RequireClaim("SomeClaimName", "123", "456"));
            });

            services.AddAuthentication()
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

            services.ConfigureApplicationCookie(
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


            var executingAssem = Assembly.GetExecutingAssembly();
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(executingAssem));

            var dataClasses = typeof(GalaxySiteServerConnection).Assembly;
            catalog.Catalogs.Add(new AssemblyCatalog(dataClasses));

            //var proxies = typeof(ServiceFactory).Assembly;
            //catalog.Catalogs.Add(new AssemblyCatalog(proxies));

            //GCS.Core.Common.Core.StaticObjects.Container = MEFLoader.Init(catalog.Catalogs);
            NetCoreCommon.GCS.Core.Common.Core.StaticObjects.Container = MEFLoader.Init(catalog.Catalogs);
            
            services.AddMemoryCache();

            services.AddSingleton<IRedisCacheService, RedisCacheService>();
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = Configuration["Redis-Cache:Url"];
            });
            
            services.AddMvc(o =>
                {
                    //var policy = new AuthorizationPolicyBuilder()
                    //    .RequireAuthenticatedUser()
                    //    .Build();
                    //o.Filters.Add(new AuthorizeFilter(policy));
                    if (_env.IsDevelopment())
                        o.SslPort = 5003;
                    if (_useHttps)
                        o.Filters.Add(new RequireHttpsAttribute());
                    o.Filters.Add(typeof(ExtractHeadersActionFilter));

                })
                .SetCompatibilityVersion(CompatibilityVersion.Latest);

            services.AddControllers()
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
            services.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = ApiVersion.Default;// new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
                config.ApiVersionReader = ApiVersionReader.Combine(
                    new MediaTypeApiVersionReader("x-api-version"),
                    new HeaderApiVersionReader("x-api-version"));
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "GalaxySMS API",
                    Description = "GalaxySMS Web API",
                    TermsOfService = null,
                    //Contact = new OpenApiContact() { Name = "Talking Dotnet", Email = "apisupport@galaxysys.com", Url = new Uri("http://www.galaxysys.com") }
                });

                c.OperationFilter<SwaggerOperationFilter>();
                c.OperationFilter<SwaggerHeaderFilter>();
                c.ExampleFilters();
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
                c.AddSecurityDefinition("Bearer", securityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                 {
                  securityScheme,
                  new [] {
                   "readAccess",
                   "writeAccess"
                  }
                 }
                });
                c.EnableAnnotations();
                c.IncludeXmlComments(GetLocalXmlCommentsPath());
                c.IncludeXmlComments(GetDataClassesXmlCommentsPath());
                c.CustomSchemaIds(x => x.FullName);
                //                c.DescribeAllEnumsAsStrings();
                //c.TagActionsBy(api=>api.HttpMethod);  // Causes all methods to be grouped by verb (DELETE/GET/POST/PUT)
                //c.OrderActionsBy((apiDesc) => $"{apiDesc.ActionDescriptor.RouteValues["controller"]}_{apiDesc.HttpMethod}");
                //c.OrderActionsBy((apiDesc) => $"{apiDesc.HttpMethod}_{apiDesc.ActionDescriptor.RouteValues["controller"]}");
                //c.UseReferencedDefinitionsForEnums();
            });

            services.AddSwaggerExamplesFromAssemblyOf<SaveEntityExamples>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseOptions();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            IList<CultureInfo> supportedCultures = new List<CultureInfo>
            {
                new CultureInfo("en-US"),
                //new CultureInfo("fi-FI"),
            };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en-US"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });


            if (_useHttps)
                app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();

            //if (!string.IsNullOrEmpty(_allowedOrigins))
            //{
            //    app.UseCors(MyAllowSpecificOrigins);
            //}
            //else
            //{
            app.UseCors();
            //}

            app.UseAuthorization();
            app.UseAuthentication();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "GalaxySMS API V1");
                c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
            });

            app.UseReDoc(c =>
               {
                   c.RoutePrefix = "redocs";
                   c.SpecUrl("/v1/swagger.json");
               });

            //Add our new middleware to the pipeline
            if (_logApiRequests)
            {
//                app.UseMiddleware<ApiLoggingMiddleware>();
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

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");
            //});
        }


        private string GetLocalXmlCommentsPath()
        {
            var app = System.AppContext.BaseDirectory;
            return System.IO.Path.Combine(app, "GalaxySMS.Api.xml");
        }
        private string GetDataClassesXmlCommentsPath()
        {
            var app = System.AppContext.BaseDirectory;
            return System.IO.Path.Combine(app, "GalaxySMS.Business.Entities.Api.NetCore.xml");
        }
    }
}

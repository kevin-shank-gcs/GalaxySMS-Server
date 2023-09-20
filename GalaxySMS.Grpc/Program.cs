using System.Security.Cryptography.X509Certificates;
using GalaxySMS.Common.Interfaces;
using GalaxySMS.Data.NetCore;
using GalaxySMS.Data.NetCore.Helpers;
using GalaxySMS.Data.NetCore.Interfaces;
using GalaxySMS.Data.NetCore.Repositories;
using GalaxySMS.Grpc.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();

RegisterServices(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGrpcService<MercuryScpService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();


static void RegisterServices(WebApplicationBuilder bldr)
{
   // bldr.Services.AddScoped<JwtTokenValidationService>();
    //bldr.Services.AddAuthentication()
    //    .AddJwtBearer(cfg =>
    //    {
    //        cfg.TokenValidationParameters = new MeterReaderTokenValidationParameters(bldr.Configuration);
    //    })
    //    .AddCertificate(opt =>
    //    {
    //        opt.AllowedCertificateTypes = CertificateTypes.All;
    //        opt.RevocationMode = X509RevocationMode.NoCheck; // Self-Signed

    //        opt.Events = new CertificateAuthenticationEvents()
    //        {
    //            OnCertificateValidated = ctx =>
    //            {
    //                if (ctx.ClientCertificate.Issuer == "CN=MeterRootCert")
    //                {
    //                    ctx.Success();
    //                }
    //                else
    //                {
    //                    ctx.Fail("Invalid Certificate Issuer");
    //                }
    //                return Task.CompletedTask;
    //            }
    //        };
    //    });

    //bldr.Services.AddCors(cfg =>
    //{
    //    cfg.AddPolicy("AllowAll", builder =>
    //    {
    //        builder.AllowAnyOrigin()
    //            .AllowAnyMethod()
    //            .AllowAnyHeader();
    //    });
    //});

    var connectionString = bldr.Configuration.GetConnectionString("DefaultConnection");
    bldr.Services.AddDbContext<GalaxySMSDbContext>(options =>
        options.UseSqlServer(connectionString));

    //bldr.Services.AddDatabaseDeveloperPageExceptionFilter();

    //bldr.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    //    .AddEntityFrameworkStores<ReadingContext>();
    bldr.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

    bldr.Services.AddScoped<IGalaxySMSDbContext,GalaxySMSDbContext>();
    bldr.Services.AddScoped<IEfcRepository, EfcRepository<GalaxySMSDbContext>>();
    bldr.Services.AddScoped<ICurrentUserService, CurrentUserService>();

    bldr.Services.AddRazorPages();

    bldr.Services.AddGrpc(cfg => cfg.EnableDetailedErrors = true);

}

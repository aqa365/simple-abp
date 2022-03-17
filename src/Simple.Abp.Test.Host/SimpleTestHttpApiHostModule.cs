using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.OpenApi.Models;
using Simple.Abp.Account.Public.Web;
using Simple.Abp.Test.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using Volo.Abp;
using Volo.Abp.AspNetCore.Authentication.JwtBearer;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.AntiForgery;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Auditing;
using Volo.Abp.Autofac;
using Volo.Abp.GlobalFeatures;
using Volo.Abp.Identity;
using Volo.Abp.Identity.AspNetCore;
using Volo.Abp.IdentityServer;
using Volo.Abp.Json;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.Swashbuckle;
using Volo.Abp.UI.Navigation.Urls;
using Volo.Abp.VirtualFileSystem;
using Volo.CmsKit.GlobalFeatures;

namespace Simple.Abp.Test
{
    [DependsOn(
        typeof(SimpleTestHttpApiModule),
        typeof(SimpleTestApplicationModule),
        typeof(SimpleTestEntityFrameworkCoreModule),
        typeof(AbpAutofacModule),
        typeof(AbpAspNetCoreAuthenticationJwtBearerModule),
        typeof(AbpAspNetCoreSerilogModule),
        typeof(AbpSwashbuckleModule),
        typeof(SimpleAccountPublicWebModule)
    )]
    public class SimpleTestHttpApiHostModule : AbpModule
    {
        private const string DefaultCorsPolicyName = "Default";

        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();

            context.Services.PreConfigure<AbpIdentityAspNetCoreOptions>(options =>
            {
                options.ConfigureAuthentication = false;
            });

            PreConfigureCertificates(configuration);
        }


        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();
            var hostingEnvironment = context.Services.GetHostingEnvironment();

            //ConfigureConventionalControllers();
            ConfigureAuthentication(context, configuration);
            ConfigureLocalization();
            ConfigureVirtualFileSystem(context);
            ConfigureSwaggerServices(context, configuration);

            Configure<AbpAntiForgeryOptions>(options =>
            {
                options.TokenCookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Lax;
                options.TokenCookie.Expiration = TimeSpan.FromDays(365);
                //options.AutoValidateIgnoredHttpMethods.Add("POST");
            });


            //Configure<IdentityServerOptions>(options =>
            //{
            //    options.UserInteraction = new UserInteractionOptions()
            //    {
            //        LogoutUrl = "/account/logout",
            //        LoginUrl = "/account/login",
            //        LoginReturnUrlParameter = "returnUrl"
            //    };
            //});

            Configure<AbpAuditingOptions>(options =>
            {
                options.ApplicationName = "ka_api";

                options.EntityHistorySelectors.Add(
                   new NamedTypeSelector(
                       "UserName",
                       type =>
                       {
                           if (typeof(IdentityUser).IsAssignableFrom(type))
                           {
                               return true;
                           }
                           else
                           {
                               return false;
                           }
                       }
                   )
               );
            });

            Configure<AppUrlOptions>(options =>
            {
                options.Applications["MVC"].RootUrl = configuration["App:SelfUrl"];
            });

            context.Services.AddCors(options =>
            {
                options.AddPolicy(DefaultCorsPolicyName, builder =>
                {
                    builder
                        .WithOrigins(
                            configuration["App:CorsOrigins"]
                                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                                .Select(o => o.RemovePostFix("/"))
                                .ToArray()
                        )
                        .WithAbpExposedHeaders()
                        .SetIsOriginAllowedToAllowWildcardSubdomains()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()
                        ;
                });
            });

            Configure<AbpJsonOptions>(options => options.DefaultDateTimeFormat = "yyyy-MM-dd HH:mm:ss");

            context.Services.AddHttpClient();
        }

        private void ConfigureVirtualFileSystem(ServiceConfigurationContext context)
        {
            var hostingEnvironment = context.Services.GetHostingEnvironment();

            if (hostingEnvironment.IsDevelopment())
            {
                Configure<AbpVirtualFileSystemOptions>(options =>
                {
                    options.FileSets.ReplaceEmbeddedByPhysical<SimpleTestDomainSharedModule>(
                        Path.Combine(hostingEnvironment.ContentRootPath,
                            $"..{Path.DirectorySeparatorChar}Simple.Abp.Test.Domain.Shared"));
                    options.FileSets.ReplaceEmbeddedByPhysical<SimpleTestDomainModule>(
                        Path.Combine(hostingEnvironment.ContentRootPath,
                            $"..{Path.DirectorySeparatorChar}Simple.Abp.Test.Domain"));
                    options.FileSets.ReplaceEmbeddedByPhysical<SimpleTestApplicationContractsModule>(
                        Path.Combine(hostingEnvironment.ContentRootPath,
                            $"..{Path.DirectorySeparatorChar}Simple.Abp.Test.Application.Contracts"));
                    options.FileSets.ReplaceEmbeddedByPhysical<SimpleTestApplicationModule>(
                        Path.Combine(hostingEnvironment.ContentRootPath,
                            $"..{Path.DirectorySeparatorChar}Simple.Abp.Test.Application"));
                });
            }
        }

        private void ConfigureConventionalControllers()
        {
            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.ConventionalControllers.Create(typeof(SimpleTestApplicationModule).Assembly);
            });
        }

        private void ConfigureAuthentication(ServiceConfigurationContext context, IConfiguration configuration)
        {
            context.Services.AddAuthentication()
                .AddJwtBearer(options =>
                {
                    options.Authority = configuration["AuthServer:Authority"];
                    options.RequireHttpsMetadata = Convert.ToBoolean(configuration["AuthServer:RequireHttpsMetadata"]);
                    options.Audience = "ka_api";
                });
        }

        private static void ConfigureSwaggerServices(ServiceConfigurationContext context, IConfiguration configuration)
        {

            context.Services.AddAbpSwaggerGenWithOAuth(
                configuration["AuthServer:Authority"],
                new Dictionary<string, string>
                {
                    {"ka_api", "Simple Abp Test API"}
                },
                options =>
                {
                    options.CustomSchemaIds(type => type.FullName);
                    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Simple Abp Test API", Version = "v1" });
                    options.DocInclusionPredicate((docName, description) => true);
                    //options.OperationFilter<SwaggerFileUploadFilter>();
                });

        }

        private void ConfigureLocalization()
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Languages.Add(new LanguageInfo("en", "en", "English", "en.svg"));
                options.Languages.Add(new LanguageInfo("zh-Hans", "zh-Hans", "简体中文", "zh-Hans.svg"));
            });
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var test = GlobalFeatureManager.Instance.IsEnabled<CommentsFeature>();
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAbpRequestLocalization();

            //if (!env.IsDevelopment())
            //{
            //    app.UseErrorPage();
            //}

            ConfigureEndpointHttps(app);

            app.UseCorrelationId();
            app.UseStaticFiles();
            app.UseCors(DefaultCorsPolicyName);

            app.UseRouting();
            app.UseAuthentication();
            app.UseJwtTokenMiddleware();
            app.UseIdentityServer();
            app.UseAuthorization();
            app.UseUnitOfWork();
            app.UseSwagger();
            app.UseAbpSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Simple Abp Test API");
                var configuration = context.GetConfiguration();

                if (env.IsDevelopment())
                {
                    options.OAuthClientId(configuration["AuthServer:SwaggerClientId"]);
                    options.OAuthClientSecret(configuration["AuthServer:SwaggerClientSecret"]);
                }
            });


            app.UseAuditing();
            app.UseConfiguredEndpoints();
        }
        private void PreConfigureCertificates(IConfiguration configuration)
        {
            var filePath = Path.Combine(AppContext.BaseDirectory, configuration["Certificates:CerPath"] ?? "");
            if (!File.Exists(filePath))
                return;

            //禁止生成开发的id4证书
            PreConfigure<AbpIdentityServerBuilderOptions>(options =>
            {
                options.AddDeveloperSigningCredential = false;

            });

            PreConfigure<IIdentityServerBuilder>(opt =>
            {
                var certificate2 = new X509Certificate2(filePath, configuration["Certificates:Password"]);
                opt.AddSigningCredential(certificate2);
            });
        }

        private void ConfigureEndpointHttps(IApplicationBuilder app)
        {
            var forwardOptions = new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto,
                RequireHeaderSymmetry = false
            };

            forwardOptions.KnownNetworks.Clear();
            forwardOptions.KnownProxies.Clear();

            // ref: https://github.com/aspnet/Docs/issues/2384
            app.UseForwardedHeaders(forwardOptions);
        }
    }
}

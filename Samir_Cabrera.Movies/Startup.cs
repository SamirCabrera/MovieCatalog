using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Samir_Cabrera.Movies.Data;
using Microsoft.OpenApi.Models;

namespace Samir_Cabrera.Movies
{
    public class Startup
    {
        private readonly string _apiVersion = "v1";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<MovieContext>(options => options.UseSqlite("Data Source=moviecatalog_api.db"));

            services.AddSwaggerInApi(Configuration, _apiVersion);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwaggerInApi(Configuration, _apiVersion);

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }

    }

    public static class StartupExtensions
    {
        public static IServiceCollection AddSwaggerInApi(this IServiceCollection services, IConfiguration configuration, string apiVersion)
        {
            services.AddSwaggerGen(options =>
            {

                options.SwaggerDoc(apiVersion, new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = $"Listado de peliculas - ({apiVersion})",
                    Version = apiVersion,
                    Description = "CRUD Peliculas",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact()
                    {
                        Name = "Samir",
                        Email = "samircm1406@gmail.com"
                    }
                });

                /*options.AddSecurityDefinition("Azure AD OAuth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        Implicit = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri($"{configuration["AzureAd:Instance"]}{configuration["AzureAd:TenantId"]}/oauth2/v2.0/authorize"),
                            TokenUrl = new Uri($"{configuration["AzureAd:Instance"]}{configuration["AzureAd:TenantId"]}/oauth2/v2.0/token"),
                            RefreshUrl = new Uri($"{configuration["AzureAd:Instance"]}{configuration["AzureAd:TenantId"]}/oauth2/v2.0/token"),
                            Scopes = new Dictionary<string, string>
                            {
                                { "api://jarranz-blog/Api.Use", "Access to use the API" },
                                { "api://jarranz-blog/Api.Categories", "Access to categories" },
                                { "api://jarranz-blog/Api.Posts", "Access to posts" }
                            }
                        }
                    }
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement{
                    {
                        new OpenApiSecurityScheme{
                            Reference = new OpenApiReference{
                                Id = "Azure AD OAuth2", //The name of the previously defined security scheme.
                                Type = ReferenceType.SecurityScheme
                            }
                        },
                        new List<string>() //{ "api://jarranz-blog/Api.Use", "api://jarranz-blog/Api.Categories", "api://jarranz-blog/Api.Posts" }
                    }
                    });*/

            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerInApi(this IApplicationBuilder app, IConfiguration configuration, string apiVersion)
        {
            app.UseSwagger().UseSwaggerUI(o =>
            {
                o.SwaggerEndpoint($"/swagger/{apiVersion}/swagger.json", apiVersion);
                o.RoutePrefix = string.Empty;
                /*o.OAuthClientId(configuration["AzureAd:ClientId"]);
                o.OAuthClientId(configuration["AzureAd:ClientId"]);
                o.OAuthClientSecret(configuration["AzureAd:ClientSecret"]);
                o.OAuthAppName("jarranz-blog");
                o.OAuthUseBasicAuthenticationWithAccessCodeGrant();
                o.OAuthScopeSeparator(" ");*/

            });

            return app;
        }
    }
}

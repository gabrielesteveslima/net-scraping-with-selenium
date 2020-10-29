namespace SibSample.API
{
    using Configuration;
    using Configuration.Docs;
    using Configuration.ProblemDetails;
    using Hellang.Middleware.ProblemDetails;
    using Infrastructure;
    using JsonApiSerializer.ContractResolvers;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Diagnostics.HealthChecks;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Diagnostics.HealthChecks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using System;
    using Microsoft.AspNetCore.Cors.Infrastructure;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services
                .AddControllers(c =>
                {
                    c.Conventions.Add(new ApiExplorerGroupPerVersionConvention());
                })
                .AddNewtonsoftJson(opt =>
                {
                    opt.SerializerSettings.ContractResolver = new JsonApiContractResolver
                    {
                        NamingStrategy = new CamelCaseNamingStrategy()
                    };
                    opt.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                });
            
            services
                .AddVersioningSystem()
                .AddSwaggerDocumentation()
                .AddProblemDetailsMiddleware()
                .AddHealthChecks();
            
            services.AddCors(options =>
            {
                options.AddPolicy("EnableCORS", builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().Build();
                });
            });

            services.Configure<ProjectConfig>(Configuration.GetSection("ProjectConfig"));

            return ApplicationStartup.Initialize(
                services, Configuration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseProblemDetails();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/healthcheck",
                    new HealthCheckOptions
                    {
                        ResultStatusCodes =
                        {
                            [HealthStatus.Healthy] = StatusCodes.Status200OK,
                            [HealthStatus.Degraded] = StatusCodes.Status200OK,
                            [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable
                        }
                    });
            });

            app.UseCors("EnableCORS");
            app.UseSwaggerDocumentation();
        }
    }
}
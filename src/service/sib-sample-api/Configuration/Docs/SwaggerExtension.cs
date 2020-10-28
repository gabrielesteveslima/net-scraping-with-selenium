namespace SibSample.API.Configuration.Docs
{
    using Filters;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi.Models;
    using Swashbuckle.AspNetCore.SwaggerGen;
    using System.Collections.Generic;

    /// <summary>
    ///     Represents extension services <see cref="SwaggerExtension" />
    /// </summary>
    internal static class SwaggerExtension
    {
        internal static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(setup =>
            {
                setup.DocumentFilter<LowercaseDocumentFilter>();
                setup.SwaggerDoc("v1", new OpenApiInfo {Title = "Sib Sample Api Playground", Version = "v1"});
            });

            return services;
        }

        internal static void UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(setup =>
            {
                setup.SwaggerEndpoint("/swagger/v1/swagger.json", "Sib Sample Api Playground");
            });
        }
    }
}
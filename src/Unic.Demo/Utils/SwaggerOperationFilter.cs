using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Unic.Demo.Utils
{
    public class SwaggerOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var filterPipeline = context.ApiDescription.ActionDescriptor.FilterDescriptors;
            var isAuthorized = filterPipeline.Select(filterInfo => filterInfo.Filter).Any(filter => filter is AuthorizeUserAttribute);
            var allowAnonymous = filterPipeline.Select(filterInfo => filterInfo.Filter).Any(filter => filter is IAllowAnonymousFilter);

            if (isAuthorized)
            {
                AddSecurityRequirements(operation);
            }
        }

        private void AddSecurityRequirements(OpenApiOperation operation)
        {
            OpenApiSecurityRequirement securityRequirement = new OpenApiSecurityRequirement();
            OpenApiSecurityScheme securityDefinition = new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            };
            securityRequirement.Add(securityDefinition, new string[] { });
            operation.Security.Add(securityRequirement);
        }


    }
}

using Microsoft.AspNetCore.Builder;
using Swashbuckle.AspNetCore.SwaggerUI;
using Scalar.AspNetCore;
using NetCore2BlocklyNew;
namespace OpenAPISwaggerUI;

public static class ExtensionsOpenAPISwaggerUI
{
    public static WebApplication UseOpenAPISwaggerUI(this WebApplication app)
    {
        //goto /swagger-Swashbuckle
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/openapi/v1.json", "v1");
            options.RoutePrefix = "swagger-Swashbuckle";
        });
        //scalar
        //goto swagger-scalar/v1
        app.MapScalarApiReference(opt =>
        {
            opt.EndpointPathPrefix = "/swagger-scalar/{documentName}";
        });
        //redoc
        //goto /api-docs
        app.UseReDoc(options =>
        {
            options.SpecUrl("/openapi/v1.json");
            options.RoutePrefix = "swagger-redoc";
        });

        //goto /nswag-swagger
        app.UseSwaggerUi(options =>
        {
            options.DocumentPath = "/openapi/v1.json";
            options.Path = "/swagger-nswag";
        });

        app.UseBlocklyUI(app.Environment);
        app.UseBlocklyAutomation();
        return app;
    }


}

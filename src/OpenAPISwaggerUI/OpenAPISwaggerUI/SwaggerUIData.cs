namespace OpenAPISwaggerUI;
internal class SwaggerUIData
{
    public SwaggerUIData()
    {
        MyName = Generated.OpenAPISwaggerUI.TheAssemblyInfo.GeneratedNameNice;
        AssemblyName = Generated.OpenAPISwaggerUI.TheAssemblyInfo.AssemblyName;
    }
    public string MyName;
    public string AssemblyName;
    public string SwaggerEndpoint { get; set; } = "/openapi/v1.json";
    public string Swashbuckle = "/swagger-Swashbuckle";
    public string Scalar = "/swagger-scalar/v1";
    public string ReDoc = "/swagger-redoc";
    public string NSwag = "/swagger-nswag";
    public string Blockly = "/blocklyautomation";

}

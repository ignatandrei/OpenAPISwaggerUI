# OpenAPISwaggerUI


This nuget package adds multiple Swagger UI to your ASP.NET 9 project.

## Installation

1. Add the nuget package to your project.

```powershell
dotnet add package OpenAPISwaggerUI --version 9.2024.1215.2209
```

2. In Program.cs, ensure you have

```csharp
app.MapOpenApi();
app.UseOpenAPISwaggerUI();
```

## Usage

Browse to /swagger and you will see links to UI with 

Swashbuckle
NSwag
Redoc
Scalar
Visual Automation

## License

MIT

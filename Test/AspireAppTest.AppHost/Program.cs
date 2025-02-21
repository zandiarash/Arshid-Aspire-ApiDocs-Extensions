using Arshid.Aspire.ApiDocs.Extensions;

var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.AspireAppTest_ApiService>("apiservice")
    .WithScalar()
    .WithSwagger()
    .WithOpenApi()
    .WithCustomUrl("https://127.0.0.1:5000/CustomRoute/CustomPage1")
    .WithRoute("/CustomRoute/CustomPage2"); //The URL become something like this {protocol}://{url}:{port}/CustomRoute/CustomPage2

builder.Build().Run();

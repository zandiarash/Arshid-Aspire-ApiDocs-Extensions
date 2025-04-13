using Arshid.Aspire.ApiDocs.Extensions;

var builder = DistributedApplication.CreateBuilder(args);

var ApiService = builder.AddProject<Projects.AspireAppTest_ApiService>("ApiService")
    .WithScalar()
    .WithSwagger()
    .WithOpenApi();

var BlazorApp = builder.AddProject<Projects.AspireAppTest_BlazorApp>("BlazorApp")
    .WithCustomUrl("http://127.0.0.1:5001/CustomRoute/CustomPage1")
    .WithCustomUrl("http://127.0.0.1:5001/Counter")
    .WithRoute("/Counter") //The URL become something like this {protocol}://{url}:{port}/CustomRoute/.../CustomPage2
    .WithRoute("/CustomRoute/CustomPage"); //The URL become something like this {protocol}://{url}:{port}/CustomRoute/.../CustomPage2

builder.Build().Run();

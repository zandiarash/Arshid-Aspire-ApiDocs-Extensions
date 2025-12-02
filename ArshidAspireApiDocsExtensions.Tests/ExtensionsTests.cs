using Aspire.Hosting.Testing;

namespace ArshidAspireApiDocsExtensions.Tests;

[TestClass]
public class ExtensionsTests
{
    [TestMethod]
    public async Task WithSwagger_AddsCommandToResource()
    {
        // Arrange
        var appHost = await DistributedApplicationTestingBuilder
            .CreateAsync<Projects.AspireAppTest_AppHost>();

        await using var app = await appHost.BuildAsync();

        // Act
        var apiService = app.Services.GetRequiredService<DistributedApplicationModel>()
            .Resources
            .FirstOrDefault(r => r.Name == "ApiService");

        // Assert
        Assert.IsNotNull(apiService, "ApiService resource should exist");
        
        var commands = apiService.Annotations.OfType<ResourceCommandAnnotation>().ToList();
        Assert.IsTrue(commands.Any(c => c.Name == "Swagger"), "Swagger command should be registered");
    }

    [TestMethod]
    public async Task WithScalar_AddsCommandToResource()
    {
        // Arrange
        var appHost = await DistributedApplicationTestingBuilder
            .CreateAsync<Projects.AspireAppTest_AppHost>();

        await using var app = await appHost.BuildAsync();

        // Act
        var apiService = app.Services.GetRequiredService<DistributedApplicationModel>()
            .Resources
            .FirstOrDefault(r => r.Name == "ApiService");

        // Assert
        Assert.IsNotNull(apiService, "ApiService resource should exist");
        
        var commands = apiService.Annotations.OfType<ResourceCommandAnnotation>().ToList();
        Assert.IsTrue(commands.Any(c => c.Name == "Scalar"), "Scalar command should be registered");
    }

    [TestMethod]
    public async Task WithOpenApi_AddsCommandToResource()
    {
        // Arrange
        var appHost = await DistributedApplicationTestingBuilder
            .CreateAsync<Projects.AspireAppTest_AppHost>();

        await using var app = await appHost.BuildAsync();

        // Act
        var apiService = app.Services.GetRequiredService<DistributedApplicationModel>()
            .Resources
            .FirstOrDefault(r => r.Name == "ApiService");

        // Assert
        Assert.IsNotNull(apiService, "ApiService resource should exist");
        
        var commands = apiService.Annotations.OfType<ResourceCommandAnnotation>().ToList();
        Assert.IsTrue(commands.Any(c => c.Name == "OpenApi"), "OpenApi command should be registered");
    }


    [TestMethod]
    public async Task WithCustomUrl_AddsCommandToResource()
    {
        // Arrange
        var appHost = await DistributedApplicationTestingBuilder
            .CreateAsync<Projects.AspireAppTest_AppHost>();

        await using var app = await appHost.BuildAsync();

        // Act
        var blazorApp = app.Services.GetRequiredService<DistributedApplicationModel>()
            .Resources
            .FirstOrDefault(r => r.Name == "BlazorApp");

        // Assert
        Assert.IsNotNull(blazorApp, "BlazorApp resource should exist");
        
        var commands = blazorApp.Annotations.OfType<ResourceCommandAnnotation>().ToList();
        Assert.IsTrue(commands.Any(c => c.Name == "CustomUrl"), "CustomUrl command should be registered");
    }

    [TestMethod]
    public async Task WithRoute_AddsCommandToResource()
    {
        // Arrange
        var appHost = await DistributedApplicationTestingBuilder
            .CreateAsync<Projects.AspireAppTest_AppHost>();

        await using var app = await appHost.BuildAsync();

        // Act
        var blazorApp = app.Services.GetRequiredService<DistributedApplicationModel>()
            .Resources
            .FirstOrDefault(r => r.Name == "BlazorApp");

        // Assert
        Assert.IsNotNull(blazorApp, "BlazorApp resource should exist");
        
        var commands = blazorApp.Annotations.OfType<ResourceCommandAnnotation>().ToList();
        Assert.IsTrue(commands.Any(c => c.Name == "/Counter"), "Route command should be registered");
    }

    [TestMethod]
    public async Task ApiService_HasAllExpectedCommands()
    {
        // Arrange
        var appHost = await DistributedApplicationTestingBuilder
            .CreateAsync<Projects.AspireAppTest_AppHost>();

        await using var app = await appHost.BuildAsync();

        // Act
        var apiService = app.Services.GetRequiredService<DistributedApplicationModel>()
            .Resources
            .FirstOrDefault(r => r.Name == "ApiService");

        // Assert
        Assert.IsNotNull(apiService, "ApiService resource should exist");
        
        var commands = apiService.Annotations.OfType<ResourceCommandAnnotation>().ToList();
        
        Assert.IsTrue(commands.Any(c => c.Name == "Swagger"), "Swagger command should exist");
        Assert.IsTrue(commands.Any(c => c.Name == "Scalar"), "Scalar command should exist");
        Assert.IsTrue(commands.Any(c => c.Name == "OpenApi"), "OpenApi command should exist");
    }

    [TestMethod]
    public async Task BlazorApp_HasAllExpectedCommands()
    {
        // Arrange
        var appHost = await DistributedApplicationTestingBuilder
            .CreateAsync<Projects.AspireAppTest_AppHost>();

        await using var app = await appHost.BuildAsync();

        // Act
        var blazorApp = app.Services.GetRequiredService<DistributedApplicationModel>()
            .Resources
            .FirstOrDefault(r => r.Name == "BlazorApp");

        // Assert
        Assert.IsNotNull(blazorApp, "BlazorApp resource should exist");
        
        var commands = blazorApp.Annotations.OfType<ResourceCommandAnnotation>().ToList();
        
        Assert.IsTrue(commands.Any(c => c.Name == "CustomUrl"), "CustomUrl command should exist");
        Assert.IsTrue(commands.Any(c => c.Name == "/Counter"), "Counter route command should exist");
        Assert.IsTrue(commands.Any(c => c.Name == "/CustomRoute/CustomPage"), "CustomPage route command should exist");
    }
}

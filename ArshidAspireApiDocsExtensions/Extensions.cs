namespace Arshid.Aspire.ApiDocs.Extensions;

/// <summary>
/// Extension methods for adding API documentation links to .NET Aspire dashboard.
/// </summary>
public static class Extensions
{
    /// <summary>
    /// Adds a custom route link to the Aspire dashboard for the specified project.
    /// </summary>
    /// <param name="builder">The resource builder for the project.</param>
    /// <param name="CustomRoute">The custom route path (e.g., "/CustomRoute/Page1"). The URL will be constructed as {protocol}://{host}:{port}{CustomRoute}.</param>
    /// <returns>The resource builder for chaining.</returns>
    /// <example>
    /// <code>
    /// builder.AddProject&lt;Projects.MyApi&gt;("api")
    ///     .WithRoute("/health");
    /// </code>
    /// </example>
    public static IResourceBuilder<ProjectResource> WithRoute(
       this IResourceBuilder<ProjectResource> builder, string CustomRoute)
    {
        builder.WithCommand(
            name: CustomRoute,
            displayName: CustomRoute,
            executeCommand: context => OnLinkOpenerCommandAsync(builder, context, CustomRoute),
            commandOptions: new CommandOptions
            {
                IconName = "Accessibility",
                IconVariant = IconVariant.Filled
            });
        return builder;
    }

    /// <summary>
    /// Adds a custom URL link to the Aspire dashboard for the specified project.
    /// </summary>
    /// <param name="builder">The resource builder for the project.</param>
    /// <param name="CustomUrl">The full custom URL to open (e.g., "https://example.com/docs").</param>
    /// <returns>The resource builder for chaining.</returns>
    /// <example>
    /// <code>
    /// builder.AddProject&lt;Projects.MyApi&gt;("api")
    ///     .WithCustomUrl("https://docs.myapi.com");
    /// </code>
    /// </example>
    public static IResourceBuilder<ProjectResource> WithCustomUrl(
        this IResourceBuilder<ProjectResource> builder, string CustomUrl)
    {
        builder.WithCommand(
            name: "CustomUrl",
            displayName: CustomUrl,
            executeCommand: context => OnLinkOpenerCommandAsync(builder, context, CustomUrl: CustomUrl),
            commandOptions: new CommandOptions
            {
                IconName = "Accessibility",
                IconVariant = IconVariant.Filled
            });
        return builder;
    }


    /// <summary>
    /// Adds an OpenAPI JSON endpoint link to the Aspire dashboard.
    /// </summary>
    /// <param name="builder">The resource builder for the project.</param>
    /// <param name="IsHttps">If true, uses HTTPS protocol; otherwise uses HTTP. Default is false.</param>
    /// <returns>The resource builder for chaining.</returns>
    /// <remarks>
    /// The default route is "/OpenApi/v1.json". Ensure your API project has OpenAPI configured.
    /// </remarks>
    /// <example>
    /// <code>
    /// builder.AddProject&lt;Projects.MyApi&gt;("api")
    ///     .WithOpenApi(IsHttps: true);
    /// </code>
    /// </example>
    public static IResourceBuilder<ProjectResource> WithOpenApi(
        this IResourceBuilder<ProjectResource> builder, bool IsHttps = false)
    {
        builder.WithCommand(
            name: "OpenApi",
            displayName: "OpenApi",
            executeCommand: context => OnLinkOpenerCommandAsync(builder, context, "/OpenApi/v1.json", IsHttps: IsHttps),
            commandOptions: new CommandOptions
            {
                IconName = "Accessibility",
                IconVariant = IconVariant.Filled
            });
        return builder;
    }

    /// <summary>
    /// Adds a Scalar API documentation link to the Aspire dashboard.
    /// </summary>
    /// <param name="builder">The resource builder for the project.</param>
    /// <param name="IsHttps">If true, uses HTTPS protocol; otherwise uses HTTP. Default is false.</param>
    /// <returns>The resource builder for chaining.</returns>
    /// <remarks>
    /// Scalar is a modern alternative to Swagger UI. The default route is "/Scalar/v1".
    /// Ensure your API project has Scalar configured via <c>app.MapScalarApiReference()</c>.
    /// </remarks>
    /// <example>
    /// <code>
    /// builder.AddProject&lt;Projects.MyApi&gt;("api")
    ///     .WithScalar();
    /// </code>
    /// </example>
    public static IResourceBuilder<ProjectResource> WithScalar(
        this IResourceBuilder<ProjectResource> builder, bool IsHttps = false)
    {
        builder.WithCommand(
            name: "Scalar",
            displayName: "Scalar",
            executeCommand: context => OnLinkOpenerCommandAsync(builder, context, "/Scalar/v1", IsHttps: IsHttps),
            commandOptions: new CommandOptions
            {
                IconName = "Accessibility",
                IconVariant = IconVariant.Filled
            });
        return builder;
    }

    /// <summary>
    /// Adds a Swagger UI link to the Aspire dashboard.
    /// </summary>
    /// <param name="builder">The resource builder for the project.</param>
    /// <param name="IsHttps">If true, uses HTTPS protocol; otherwise uses HTTP. Default is false.</param>
    /// <returns>The resource builder for chaining.</returns>
    /// <remarks>
    /// The default route is "/Swagger/index.html". Ensure your API project has Swagger configured
    /// via <c>app.UseSwagger()</c> and <c>app.UseSwaggerUI()</c>.
    /// </remarks>
    /// <example>
    /// <code>
    /// builder.AddProject&lt;Projects.MyApi&gt;("api")
    ///     .WithSwagger(IsHttps: true);
    /// </code>
    /// </example>
    public static IResourceBuilder<ProjectResource> WithSwagger(
        this IResourceBuilder<ProjectResource> builder, bool IsHttps = false)
    {
        builder.WithCommand(
            name: "Swagger",
            displayName: "Swagger",
            executeCommand: context => OnLinkOpenerCommandAsync(builder, context, "/Swagger/index.html", IsHttps: IsHttps),
            commandOptions: new CommandOptions
            {
                IconName = "Accessibility",
                IconVariant = IconVariant.Filled
            });
        return builder;
    }

    private static Task<ExecuteCommandResult> OnLinkOpenerCommandAsync(
        IResourceBuilder<ProjectResource> builder,
        ExecuteCommandContext context,
        string? Route = null,
        string? CustomUrl = null,
        bool IsHttps = false
        )
    {
        string? url;
        if (!string.IsNullOrEmpty(CustomUrl))
            url = CustomUrl;
        else
            url = $"{builder.GetEndpoint(IsHttps ? "https" : "http").Url}{Route}";
        var ps = new System.Diagnostics.ProcessStartInfo(url)
        {
            UseShellExecute = true,
            Verb = "open"
        };
        System.Diagnostics.Process.Start(ps);
        return Task.FromResult(CommandResults.Success());
    }
}

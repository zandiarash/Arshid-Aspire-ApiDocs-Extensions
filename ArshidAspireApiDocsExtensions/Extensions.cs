namespace Arshid.Aspire.ApiDocs.Extensions;

/// <summary>
/// Extension methods for adding API documentation links to .NET Aspire dashboard.
/// </summary>
public static class Extensions
{
    /// <summary>
    /// Adds a custom route link to the Aspire dashboard for the specified project.
    /// </summary>
    /// <typeparam name="T">The resource type. Any resource with endpoints (e.g. <c>DotnetProjectResource</c>, <c>ProjectResource</c>).</typeparam>
    /// <param name="builder">The resource builder for the project.</param>
    /// <param name="CustomRoute">The custom route path (e.g., "/CustomRoute/Page1"). The URL will be constructed as {protocol}://{host}:{port}{CustomRoute}.</param>
    /// <returns>The resource builder for chaining.</returns>
    /// <example>
    /// <code>
    /// builder.AddDotnetProject("api", "../MyApi/MyApi.csproj")
    ///     .WithRoute("/health");
    /// </code>
    /// </example>
    public static IResourceBuilder<T> WithRoute<T>(
       this IResourceBuilder<T> builder, string CustomRoute)
        where T : IResourceWithEndpoints
    {
        builder.WithCommand(
            name: CustomRoute,
            displayName: CustomRoute,
            executeCommand: context => OnLinkOpenerCommandAsync(builder, context, CustomRoute),
            commandOptions: new CommandOptions
            {
                IconName = "Link",
                IconVariant = IconVariant.Filled
            });
        return builder;
    }

    /// <summary>
    /// Adds a custom URL link to the Aspire dashboard for the specified project.
    /// </summary>
    /// <typeparam name="T">The resource type. Any resource with endpoints (e.g. <c>DotnetProjectResource</c>, <c>ProjectResource</c>).</typeparam>
    /// <param name="builder">The resource builder for the project.</param>
    /// <param name="CustomUrl">The full custom URL to open (e.g., "https://example.com/docs").</param>
    /// <returns>The resource builder for chaining.</returns>
    /// <example>
    /// <code>
    /// builder.AddDotnetProject("api", "../MyApi/MyApi.csproj")
    ///     .WithCustomUrl("https://docs.myapi.com");
    /// </code>
    /// </example>
    public static IResourceBuilder<T> WithCustomUrl<T>(
        this IResourceBuilder<T> builder, string CustomUrl)
        where T : IResourceWithEndpoints
    {
        builder.WithCommand(
            name: "CustomUrl",
            displayName: CustomUrl,
            executeCommand: context => OnLinkOpenerCommandAsync(builder, context, CustomUrl: CustomUrl),
            commandOptions: new CommandOptions
            {
                IconName = "Globe",
                IconVariant = IconVariant.Filled
            });
        return builder;
    }


    /// <summary>
    /// Adds an OpenAPI JSON endpoint link to the Aspire dashboard.
    /// </summary>
    /// <typeparam name="T">The resource type. Any resource with endpoints (e.g. <c>DotnetProjectResource</c>, <c>ProjectResource</c>).</typeparam>
    /// <param name="builder">The resource builder for the project.</param>
    /// <param name="IsHttps">If true, uses HTTPS protocol; otherwise uses HTTP. Default is false.</param>
    /// <returns>The resource builder for chaining.</returns>
    /// <remarks>
    /// The default route is "/OpenApi/v1.json". Ensure your API project has OpenAPI configured.
    /// </remarks>
    /// <example>
    /// <code>
    /// builder.AddDotnetProject("api", "../MyApi/MyApi.csproj")
    ///     .WithOpenApi(IsHttps: true);
    /// </code>
    /// </example>
    public static IResourceBuilder<T> WithOpenApi<T>(
        this IResourceBuilder<T> builder, bool IsHttps = false)
        where T : IResourceWithEndpoints
    {
        builder.WithCommand(
            name: "OpenApi",
            displayName: "OpenApi",
            executeCommand: context => OnLinkOpenerCommandAsync(builder, context, "/OpenApi/v1.json", IsHttps: IsHttps),
            commandOptions: new CommandOptions
            {
                IconName = "Document",
                IconVariant = IconVariant.Filled
            });
        return builder;
    }

    /// <summary>
    /// Adds a Scalar API documentation link to the Aspire dashboard.
    /// </summary>
    /// <typeparam name="T">The resource type. Any resource with endpoints (e.g. <c>DotnetProjectResource</c>, <c>ProjectResource</c>).</typeparam>
    /// <param name="builder">The resource builder for the project.</param>
    /// <param name="IsHttps">If true, uses HTTPS protocol; otherwise uses HTTP. Default is false.</param>
    /// <returns>The resource builder for chaining.</returns>
    /// <remarks>
    /// Scalar is a modern alternative to Swagger UI. The default route is "/Scalar/v1".
    /// Ensure your API project has Scalar configured via <c>app.MapScalarApiReference()</c>.
    /// </remarks>
    /// <example>
    /// <code>
    /// builder.AddDotnetProject("api", "../MyApi/MyApi.csproj")
    ///     .WithScalar();
    /// </code>
    /// </example>
    public static IResourceBuilder<T> WithScalar<T>(
        this IResourceBuilder<T> builder, bool IsHttps = false)
        where T : IResourceWithEndpoints
    {
        builder.WithCommand(
            name: "Scalar",
            displayName: "Scalar",
            executeCommand: context => OnLinkOpenerCommandAsync(builder, context, "/Scalar/v1", IsHttps: IsHttps),
            commandOptions: new CommandOptions
            {
                IconName = "BookOpen",
                IconVariant = IconVariant.Filled
            });
        return builder;
    }

    /// <summary>
    /// Adds a Swagger UI link to the Aspire dashboard.
    /// </summary>
    /// <typeparam name="T">The resource type. Any resource with endpoints (e.g. <c>DotnetProjectResource</c>, <c>ProjectResource</c>).</typeparam>
    /// <param name="builder">The resource builder for the project.</param>
    /// <param name="IsHttps">If true, uses HTTPS protocol; otherwise uses HTTP. Default is false.</param>
    /// <returns>The resource builder for chaining.</returns>
    /// <remarks>
    /// The default route is "/Swagger/index.html". Ensure your API project has Swagger configured
    /// via <c>app.UseSwagger()</c> and <c>app.UseSwaggerUI()</c>.
    /// </remarks>
    /// <example>
    /// <code>
    /// builder.AddDotnetProject("api", "../MyApi/MyApi.csproj")
    ///     .WithSwagger(IsHttps: true);
    /// </code>
    /// </example>
    public static IResourceBuilder<T> WithSwagger<T>(
        this IResourceBuilder<T> builder, bool IsHttps = false)
        where T : IResourceWithEndpoints
    {
        builder.WithCommand(
            name: "Swagger",
            displayName: "Swagger",
            executeCommand: context => OnLinkOpenerCommandAsync(builder, context, "/Swagger/index.html", IsHttps: IsHttps),
            commandOptions: new CommandOptions
            {
                IconName = "Code",
                IconVariant = IconVariant.Filled
            });
        return builder;
    }

    private static Task<ExecuteCommandResult> OnLinkOpenerCommandAsync<T>(
        IResourceBuilder<T> builder,
        ExecuteCommandContext context,
        string? Route = null,
        string? CustomUrl = null,
        bool IsHttps = false
        )
        where T : IResourceWithEndpoints
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
